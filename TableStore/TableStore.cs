﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Xbim.CobieExpress.IO.TableStore.TableMapping;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;

namespace Xbim.CobieExpress.IO.TableStore
{
    public class TableStore
    {
        public IModel Model { get; private set; }
        public ModelMapping Mapping { get; private set; }
        public ExpressMetaData MetaData { get { return Model.Metadata; } }

        private const int CellTextLimit = 1024;

        //dictionary of all styles for different data statuses
        private Dictionary<DataStatus, ICellStyle> _styles;

        //cache of latest row number in different sheets
        private Dictionary<string, int> _rowNumCache = new Dictionary<string, int>();


        public TableStore(IModel model, ModelMapping mapping)
        {
            Model = model;
            Mapping = mapping;

            Mapping.Init(MetaData);
        }

        public void Store(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            var ext = Path.GetExtension(path).ToLower().Trim('.');
            if (ext != "xls" && ext != "xlsx")
            {
                //XLSX is Spreadsheet XML representation which is capable of storing more data
                path += ".xlsx";
                ext = "xlsx";
            }
            using (var file = File.Create(path))
            {
                var type = ext == "xlsx" ? ExcelTypeEnum.XLSX : ExcelTypeEnum.XLS;
                Store(file, type);
                file.Close();
            }

            
        }

        public void Store(Stream stream, ExcelTypeEnum type, Stream template = null, bool recalculate = false)
        {
            IWorkbook workbook;
            switch (type)
            {
                case ExcelTypeEnum.XLS:
                    workbook = template != null ? new HSSFWorkbook(template) : new HSSFWorkbook();
                    break;
                case ExcelTypeEnum.XLSX: //this is as it should be according to a standard
                    workbook = template != null ? new XSSFWorkbook(template) : new XSSFWorkbook();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            Store(workbook);
            workbook.Write(stream);

            if (!recalculate || template == null) return;

            //refresh formulas
            switch (type)
            {
                case ExcelTypeEnum.XLS:
                    HSSFFormulaEvaluator.EvaluateAllFormulaCells(workbook);
                    break;
                case ExcelTypeEnum.XLSX:
                    XSSFFormulaEvaluator.EvaluateAllFormulaCells(workbook);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public void Store(IWorkbook workbook)
        {
            //if there are no mappings do nothing
            if (Mapping.ClassMappings == null || !Mapping.ClassMappings.Any()) return;

            _rowNumCache = new Dictionary<string, int>();
            _styles = new Dictionary<DataStatus, ICellStyle>();

            //creates tables in defined order if they are not there yet
            SetUpTables(workbook, Mapping);

            //start from root definitions
            var rootClasses = Mapping.ClassMappings.Where(m => m.IsRoot);
            foreach (var classMapping in rootClasses)
            {
                if (classMapping.PropertyMappings == null) 
                    continue;
                
                var eType = classMapping.Type;
                if (eType == null)
                {
                    Debug.WriteLine("Type not found: " + classMapping.Class);
                    continue;
                }

                //root definitions will always have parent == null
                Store(workbook, classMapping, eType, null);
            }

            //AdjustAllColumns(workbook, Mapping);
        }

        private void Store(IWorkbook workbook, ClassMapping mapping, ExpressType expType, IPersistEntity parent)
        {
            if (mapping.PropertyMappings == null)
                return;

            var entities = parent == null ?
                Model.Instances.OfType(expType.Name.ToUpper(), false).ToList() :
                mapping.GetInstances(parent).ToList();

            if(!entities.Any()) return;

            var tableName = mapping.TableName ?? "Default";
            var sheet = workbook.GetSheet(tableName) ?? workbook.CreateSheet(tableName);

            foreach (var entity in entities)
            {
                Store(sheet, entity, mapping, expType, parent);

                foreach (var childrenMapping in mapping.ChildrenMappings)
                {
                    Store(workbook, childrenMapping, childrenMapping.Type, entity);
                }
            }
        }

        private void Store(ISheet sheet, IPersistEntity entity, ClassMapping mapping, ExpressType expType, IPersistEntity parent)
        {
            var multiRow = -1;
            List<string> multiValues = null;
            PropertyMapping multiMapping = null;
            var row = GetRow(sheet);

            foreach (var propertyMapping in mapping.PropertyMappings)
            {
                object value = null;
                foreach (var path in propertyMapping.PathsEnumeration)
                {
                    value = GetValue(entity, expType, path, parent);
                    if (value != null) break;
                }
                if (value == null && propertyMapping.Status == DataStatus.Required)
                    value = propertyMapping.DefaultValue ?? "n/a";

                var isMultiRow = IsMultiRow(value, propertyMapping);
                if (isMultiRow)
                {
                    multiRow = row.RowNum;
                    var values = new List<string>();
                    var enumerable = value as IEnumerable<string>;
                    if (enumerable != null)
                        values.AddRange(enumerable);

                    //get only first value and store it
                    var first = values.First();
                    Store(row, first, propertyMapping);

                    //set the rest for the processing as multiValue
                    values.Remove(first);
                    multiValues = values;
                    multiMapping = propertyMapping;
                }
                else
                {
                    Store(row, value, propertyMapping);
                }

            }

            if (row.RowNum == 1)
            {
                //adjust width of the columns after first row
                //adjusting fully populated workbook takes ages. This should be almost all right
                AdjustAllColumns(sheet, mapping);
            }

            //add repeated rows if necessary
            if (multiRow <= 0 || multiValues == null || !multiValues.Any()) return;

            foreach (var value in multiValues)
            {
                var rowNum = GetNextRowNum(sheet);
                var copy = sheet.CopyRow(multiRow, rowNum);
                Store(copy, value, multiMapping);    
            }
            
        }


        private bool IsMultiRow(object value, PropertyMapping mapping)
        {
            if (value == null)
                return false;
            if (mapping.MultiRow == MultiRow.None) 
                return false;

            var values = value as IEnumerable<string>;
            if (values == null) 
                return false;

            var strings = values.ToList();
            var count = strings.Count;
            if (count > 1 && mapping.MultiRow == MultiRow.Always)
                return true;

            var single = string.Join(Mapping.ListSeparator, strings);
            return single.Length > CellTextLimit && mapping.MultiRow == MultiRow.IfNecessary;
        }

        private void Store(IRow row, object value, PropertyMapping mapping)
        {
            if (value == null)
                return;

            var cellIndex = CellReference.ConvertColStringToIndex(mapping.Column);
            var cell = row.GetCell(cellIndex) ?? row.CreateCell(cellIndex);

            //set column style to cell
            cell.CellStyle = row.Sheet.GetColumnStyle(cellIndex);

            //simplify any eventual enumeration into a single string
            var enumVal = value as IEnumerable;
            if (enumVal != null && !(value is string))
            {
                var strValue = string.Join(Mapping.ListSeparator, enumVal.Cast<object>());
                cell.SetCellType(CellType.String);
                cell.SetCellValue(strValue);
                return;
            }

            //string value
            var str = value as string;
            if (str != null)
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(str);
                return;
            }

            //numeric point types
            if (value is double || value is float || value is int || value is long || value is short || value is byte || value is uint || value is ulong ||
                value is ushort)
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue(Convert.ToDouble(value));
                return;
            }

            //boolean value
            if (value is bool)
            {
                cell.SetCellType(CellType.Boolean);
                cell.SetCellValue((bool)value);
                return;
            }

            //enumeration
            if (value is Enum)
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(Enum.GetName(value.GetType(), value));
                return;
            }

            throw new NotSupportedException("Only base types are supported");
        }

        private object GetValue(IPersistEntity entity, ExpressType type, string path, IPersistEntity parent)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new XbimException("Path not defined");

            if (path.ToLower().StartsWith("parent."))
            {
                path = path.Substring(7); //trim "parent." from the beginning
                return GetValue(parent, parent.ExpressType, path, null);
            }

            if (string.Equals(path, "[sheet]", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(path, "[table]", StringComparison.OrdinalIgnoreCase))
            {
                var parentMapping = Mapping.ClassMappings.FirstOrDefault(m => m.Type == type || m.Type.SubTypes.Contains(type));
                if(parentMapping == null)
                    throw  new XbimException("No sheet mapping defined for " + type.Name);
                return parentMapping.TableName;
            }

            var parts = path.Split(new [] {'.'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var multiResult = new List<string>();
            for (var i = 0; i < parts.Count; i++)
            {
                var value = GetPropertyValue(parts[i], entity, type);

                if (value == null)
                    return null;

                var ent = value as IPersistEntity;
                if (ent != null)
                {
                    entity = ent;
                    type = ent.ExpressType;
                    continue;
                }

                var expVal = value as IExpressValueType;
                if (expVal != null)
                    return expVal.Value;

                var expValEnum = value as IEnumerable<IExpressValueType>;
                if (expValEnum != null)
                    return expValEnum.Select(v => v.Value);

                //it is a multivalue result
                var entEnum = value as IEnumerable<IPersistEntity>;
                if (entEnum != null)
                {
                    var subParts = parts.GetRange(i + 1, parts.Count - i - 1);
                    var subPath = string.Join(".", subParts);
                    foreach (var persistEntity in entEnum)
                    {
                        var subValue = GetValue(persistEntity, persistEntity.ExpressType, subPath, null);
                        if (subValue == null) continue;
                        var subString = subValue as string;
                        if (subString != null)
                        {
                            multiResult.Add(subString);
                            continue;
                        }
                        multiResult.Add(subValue.ToString());
                    }
                    return multiResult;
                }

                //deal with simple values
                return value;
            }

            //if there is only entity itself to return, try to get 'Name' or 'Value' property as a fallback
            return GetFallbackValue(entity, type);
        }

        private object GetPropertyValue(string pathPart, IPersistEntity entity, ExpressType type)
        {
            var propName = pathPart;
            var isIndexed = propName.Contains("[") && propName.Contains("]");
            object propIndex = null;
            if (isIndexed)
            {
                var match = new Regex("((?<name>).+)?\\[(?<index>.+)\\]")
                    .Match(propName);
                var indexString = match.Groups["index"].Value;
                propName = match.Groups["name"].Value;

                if (indexString.Contains("'") || indexString.Contains("\""))
                {
                    propIndex = indexString.Trim('\'', '"');
                }
                else
                {
                    //try to convert it to integer access
                    int indexInt;
                    if (int.TryParse(indexString, out indexInt))
                        propIndex = indexInt;
                    else
                        propIndex = indexString;
                }
            }
            PropertyInfo pInfo;
            if (isIndexed && string.IsNullOrWhiteSpace(propName))
            {
                pInfo = type.Type.GetProperty("Item");
                if (pInfo == null)
                    throw new XbimException(string.Format("{0} doesn't have an index access", type.Name));

                var iParams = pInfo.GetIndexParameters();
                if (iParams.All(p => p.ParameterType != propIndex.GetType()))
                    throw new XbimException(string.Format("{0} doesn't have an index access for type {1}", type.Name, propIndex.GetType().Name));
            }
            else
            {
                var expProp =
                    type.Properties.Values.FirstOrDefault(p => p.Name == propName) ??
                    type.Inverses.FirstOrDefault(p => p.Name == propName) ??
                    type.Derives.FirstOrDefault(p => p.Name == propName);
                if (expProp == null)
                    throw new XbimException(string.Format("It wasn't possible to find property {0} in the object of type {1}", propName, type.Name));
                pInfo = expProp.PropertyInfo;
                if (isIndexed)
                {
                    var iParams = pInfo.GetIndexParameters();
                    if (iParams.All(p => p.ParameterType != propIndex.GetType()))
                        throw new XbimException(string.Format("Property {0} in the object of type {1} doesn't have an index access for type {2}", propName, type.Name, propIndex.GetType().Name));
                }
            }

            var value = pInfo.GetValue(entity, propIndex == null ? null : new[] { propIndex });
            return value;
        }

        private object GetFallbackValue(IPersistEntity entity, ExpressType type)
        {
            var nameProp = type.Properties.Values.FirstOrDefault(p => p.Name == "Name");
            var valProp = type.Properties.Values.FirstOrDefault(p => p.Name == "Value");
            if (nameProp == null && valProp == null)
                return entity.ToString();

            if (nameProp != null && valProp != null)
            {
                var nValue = nameProp.PropertyInfo.GetValue(entity, null);
                var vValue = valProp.PropertyInfo.GetValue(entity, null);
                if (nValue != null && vValue != null)
                    return string.Join(":", vValue, nValue);
            }

            if (nameProp != null)
            {
                var nameValue = nameProp.PropertyInfo.GetValue(entity, null);
                if (nameValue != null)
                    return nameValue.ToString();
            }

            if (valProp != null)
            {
                var valValue = valProp.PropertyInfo.GetValue(entity, null);
                if (valValue != null)
                    return valValue.ToString();
            }
            return entity.ToString();
        }

        private IRow GetRow(ISheet sheet)
        {
            //get the next row in rowNumber is less than 1 or use the argument to get or create new row
            int lastIndex;
            if (!_rowNumCache.TryGetValue(sheet.SheetName, out lastIndex))
            {
                lastIndex = -1;
                _rowNumCache.Add(sheet.SheetName, -1);
            }
            var row = lastIndex < 0
                ? GetNextEmptyRow(sheet)
                : (sheet.GetRow(lastIndex + 1) ?? sheet.CreateRow(lastIndex + 1));

            if (row.RowNum == 0)
                row = sheet.CreateRow(1);

            //cache the latest row index
            _rowNumCache[sheet.SheetName] = row.RowNum;
            return row;
        }

        private int GetNextRowNum(ISheet sheet)
        {
            int lastIndex;
            //no raws were created in this sheet so far
            if (!_rowNumCache.TryGetValue(sheet.SheetName, out lastIndex))
                return -1;

            lastIndex++;
            _rowNumCache[sheet.SheetName] = lastIndex;
            return lastIndex;
        }

        private IRow GetNextEmptyRow(ISheet sheet)
        {
            foreach (IRow row in sheet)
            {
                var isEmpty = true;
                foreach (ICell cell in row)
                {
                    if (cell.CellType == CellType.Blank) continue;

                    isEmpty = false;
                    break;
                }
                if (isEmpty) return row;
            }
            return sheet.CreateRow(sheet.LastRowNum + 1);
        }



        private void SetUpHeader(ISheet sheet, ClassMapping classMapping)
        {
            var workbook = sheet.Workbook;
            var row = sheet.GetRow(0) ?? sheet.CreateRow(0);

            //create header and column style for every mapped column
            foreach (var mapping in classMapping.PropertyMappings)
            {
                var cellIndex = CellReference.ConvertColStringToIndex(mapping.Column);
                var cell = row.GetCell(cellIndex) ?? row.CreateCell(cellIndex);
                cell.SetCellType(CellType.String);
                cell.SetCellValue(mapping.Header);
                cell.CellStyle = GetStyle(DataStatus.Header, workbook);

                //set default column style if not defined but available
                var style = GetStyle(mapping.Status, workbook);
                if(mapping.Status == DataStatus.None) continue;
                var existStyle = sheet.GetColumnStyle(cellIndex);
                if (
                    existStyle != null && 
                    existStyle.FillForegroundColor == style.FillForegroundColor &&
                    existStyle.BorderTop == style.BorderTop &&
                    existStyle.TopBorderColor == style.TopBorderColor
                    ) continue;

                //create new style
                sheet.SetDefaultColumnStyle(cellIndex, style);
                sheet.SetColumnHidden(cellIndex, false);
                sheet.SetColumnWidth(cellIndex, 256*20);
            }
        }

        private ICellStyle GetStyle(DataStatus status, IWorkbook workbook)
        {
            if(_styles == null)
                _styles = new Dictionary<DataStatus, ICellStyle>();

            ICellStyle style;
            if (_styles.TryGetValue(status, out style))
                return style;

            style = workbook.CreateCellStyle();
            var representation = Mapping.StatusRepresentations.FirstOrDefault(r => r.Status == status);
            if (representation == null)
            {
                _styles.Add(status, style);
                return style;
            }

            style.FillPattern = FillPattern.SolidForeground;
            style.FillForegroundColor = GetClosestColour(representation.Colour);
            if (representation.Border)
            {
                style.BorderBottom = style.BorderTop = style.BorderLeft = style.BorderRight
                    = BorderStyle.Thin;
                style.BottomBorderColor = style.TopBorderColor = style.LeftBorderColor = style.RightBorderColor
                    = IndexedColors.Black.Index;    
            }
            var font = workbook.CreateFont();
            switch (representation.FontWeight)
            {
                case FontWeight.Normal:
                    break;
                case FontWeight.Bold:
                    font.Boldweight = (short) FontBoldWeight.Bold;
                    break;
                case FontWeight.Italics:
                    font.IsItalic = true;
                    break;
                case FontWeight.BoldItalics:
                    font.Boldweight = (short) FontBoldWeight.Bold;
                    font.IsItalic = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            style.SetFont(font);
            _styles.Add(status, style);
            return style;
        }

        //This operation takes very long time
        private void AdjustAllColumns(ISheet sheet, ClassMapping mapping)
        {
            foreach (var propertyMapping in mapping.PropertyMappings)
            {
                var colIndex = CellReference.ConvertColStringToIndex(propertyMapping.Column);
                sheet.AutoSizeColumn(colIndex);
            }
        }

        private void SetUpTables(IWorkbook workbook, ModelMapping mapping)
        {
            if (mapping == null || mapping.ClassMappings == null || !mapping.ClassMappings.Any())
                return;

            var i = 0;
            foreach (var classMapping in Mapping.ClassMappings.Where(classMapping => string.IsNullOrWhiteSpace(classMapping.TableName)))
            {
                classMapping.TableName = string.Format("NoName({0})", i++);
            }

            var names = Mapping.ClassMappings.OrderBy(m => m.TableOrder).Select(m => m.TableName).Distinct();
            foreach (var name in names)
            {
                var sheet = workbook.GetSheet(name) ?? workbook.CreateSheet(name);
                var classMapping = Mapping.ClassMappings.First(m => m.TableName == name);
                SetUpHeader(sheet, classMapping);

                ////set colour of the tab: Not implemented exception in NPOI
                //if (classMapping.TableStatus == DataStatus.None) continue;
                //var style = GetStyle(classMapping.TableStatus, workbook);
                //sheet.TabColorIndex = style.FillForegroundColor;
            }
        }

        private static readonly Dictionary<string, short> ColourCodeCache = new Dictionary<string, short>();
        private static readonly List<IndexedColors> IndexedColoursList = new List<IndexedColors>();

        private short GetClosestColour(string rgb)
        {
            if (!IndexedColoursList.Any())
            {
                var props = typeof (IndexedColors).GetFields(BindingFlags.Static | BindingFlags.Public).Where(p => p.FieldType == typeof (IndexedColors));
                foreach (var info in props)
                {
                    IndexedColoursList.Add((IndexedColors) info.GetValue(null));
                }
            }

            if (string.IsNullOrWhiteSpace(rgb))
                return IndexedColors.Automatic.Index;
            rgb = rgb.Trim('#').Trim();
            short result;
            if (ColourCodeCache.TryGetValue(rgb, out result))
                return result;

            var triplet = rgb.Length == 3;
            var hR = triplet ? rgb.Substring(0, 1) + rgb.Substring(0, 1) : rgb.Substring(0, 2);
            var hG = triplet ? rgb.Substring(1, 1) + rgb.Substring(1, 1) : rgb.Substring(2, 2);
            var hB = triplet ? rgb.Substring(2, 1) + rgb.Substring(1, 1) : rgb.Substring(4, 2);

            var r = Convert.ToByte(hR, 16);
            var g = Convert.ToByte(hG, 16);
            var b = Convert.ToByte(hB, 16);

            var rgbBytes = new[] {r, g, b};
            var distance = double.NaN;
            var colour = IndexedColors.Automatic;
            foreach (var col in IndexedColoursList)
            {
                var dist = ColourDistance(rgbBytes, col.RGB);
                if (double.IsNaN(distance)) distance = dist;

                if (!(distance > dist)) continue;
                distance = dist;
                colour = col;
            }
            ColourCodeCache.Add(rgb, colour.Index);
            return colour.Index;
        }

        private static double ColourDistance(byte[] a, byte[] b)
        {
            return Math.Sqrt(Math.Pow(a[0] - b[0], 2) + Math.Pow(a[1] - b[1], 2) + Math.Pow(a[2] - b[2], 2));
        }

        #region Reading from Spreadsheet

        //private static void SetSimpleValue(PropertyInfo info, object obj, ICell cell, TextWriter log)
        //{
        //    var type = info.PropertyType;
        //    type = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
        //        ? Nullable.GetUnderlyingType(type)
        //        : type;

        //    if (typeof(string).IsAssignableFrom(type))
        //    {
        //        string value = null;
        //        switch (cell.CellType)
        //        {
        //            case CellType.Numeric:
        //                value = cell.NumericCellValue.ToString(CultureInfo.InvariantCulture);
        //                break;
        //            case CellType.String:
        //                value = cell.StringCellValue;
        //                break;
        //            case CellType.Boolean:
        //                value = cell.BooleanCellValue.ToString();
        //                break;
        //            default:
        //                log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                    info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                    cell.Sheet.SheetName);
        //                break;
        //        }
        //        info.SetValue(obj, value);
        //        return;
        //    }

        //    if (type == typeof(DateTime))
        //    {
        //        var date = default(DateTime);
        //        switch (cell.CellType)
        //        {
        //            case CellType.Numeric:
        //                date = cell.DateCellValue;
        //                break;
        //            case CellType.String:
        //                if (!DateTime.TryParse(cell.StringCellValue, null, DateTimeStyles.RoundtripKind, out date))
        //                    //set to default value according to specification
        //                    date = DateTime.Parse("1900-12-31T23:59:59", null, DateTimeStyles.RoundtripKind);
        //                break;
        //            default:
        //                log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                    info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                    cell.Sheet.SheetName);
        //                break;
        //        }
        //        info.SetValue(obj, date);
        //        return;
        //    }

        //    if (type == typeof(double))
        //    {
        //        switch (cell.CellType)
        //        {
        //            case CellType.Numeric:
        //                info.SetValue(obj, cell.NumericCellValue);
        //                break;
        //            case CellType.String:
        //                double d;
        //                if (double.TryParse(cell.StringCellValue, out d))
        //                    info.SetValue(obj, d);
        //                break;
        //            default:
        //                log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                    info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                    cell.Sheet.SheetName);
        //                break;
        //        }
        //        return;
        //    }

        //    if (type == typeof(int))
        //    {
        //        switch (cell.CellType)
        //        {
        //            case CellType.Numeric:
        //                info.SetValue(obj, (int)cell.NumericCellValue);
        //                break;
        //            case CellType.String:
        //                int i;
        //                if (int.TryParse(cell.StringCellValue, out i))
        //                    info.SetValue(obj, i);
        //                break;
        //            default:
        //                log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                    info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                    cell.Sheet.SheetName);
        //                break;
        //        }
        //        return;
        //    }

        //    if (type == typeof(bool))
        //    {
        //        switch (cell.CellType)
        //        {
        //            case CellType.Numeric:
        //                info.SetValue(obj, ((int)cell.NumericCellValue) != 0);
        //                break;
        //            case CellType.String:
        //                bool i;
        //                if (bool.TryParse(cell.StringCellValue, out i))
        //                    info.SetValue(obj, i);
        //                else
        //                {
        //                    log.WriteLine("Wrong boolean format of {0} in cell {1}{2}, sheet {3}",
        //                        cell.StringCellValue, CellReference.ConvertNumToColString(cell.ColumnIndex),
        //                        cell.RowIndex + 1,
        //                        cell.Sheet.SheetName);
        //                }
        //                break;
        //            case CellType.Boolean:
        //                info.SetValue(obj, cell.BooleanCellValue);
        //                break;
        //            default:
        //                log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                    info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                    cell.Sheet.SheetName);
        //                break;
        //        }
        //        return;
        //    }

        //    //enumeration
        //    if (type.IsEnum)
        //    {
        //        if (cell.CellType != CellType.String)
        //        {
        //            log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                cell.Sheet.SheetName);
        //            return;
        //        }
        //        try
        //        {
        //            //if there was no alias try to parse the value
        //            var val = Enum.Parse(type, cell.StringCellValue, true);
        //            info.SetValue(obj, val);
        //            return;
        //        }
        //        catch (Exception)
        //        {
        //            log.WriteLine("There is no suitable value for {0} in cell {1}{2}, sheet {3}",
        //                info.Name, CellReference.ConvertNumToColString(cell.ColumnIndex), cell.RowIndex + 1,
        //                cell.Sheet.SheetName);
        //        }
        //    }

        //    //if not suitable type was found, report it 
        //    throw new Exception("Unsupported type " + type.Name + " for value '" + cell + "'");
        //}

        #endregion
    }

    public enum ExcelTypeEnum
    {
        XLS,
        XLSX
    }
}