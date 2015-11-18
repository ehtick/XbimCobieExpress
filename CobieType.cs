// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.CobieExpress.Interfaces;
using Xbim.CobieExpress;

namespace Xbim.CobieExpress.Interfaces
{
	/// <summary>
    /// Readonly interface for CobieType
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @ICobieType : ICobieAsset
	{
		ICobiePickValue @AssetType { get; }
		ICobieContact @Manufacturer { get; }
		string @ModelNumber { get; }
		ICobieWarranty @Warranty { get; }
		double? @ReplacementCost { get; }
		double? @ExpectedLife { get; }
		ICobiePickValue @DurationUnit { get; }
		double @NominalLength { get; }
		double @NominalWidth { get; }
		double @NominalHeight { get; }
		string @ModelReference { get; }
		string @Shape { get; }
		string @Size { get; }
		string @Color { get; }
		string @Finish { get; }
		string @Grade { get; }
		string @Material { get; }
		string @Constituents { get; }
		string @Features { get; }
		string @AccessibilityPerformance { get; }
		string @CodePerformance { get; }
		string @SustainabilityPerformance { get; }
		IEnumerable<ICobieType> @AssemblyOf { get; }
		IEnumerable<ICobieJob> @Jobs { get; }
		IEnumerable<ICobieComponent> @Components {  get; }
		IEnumerable<ICobieSpare> @Spares {  get; }
	
	}
}

namespace Xbim.CobieExpress
{
	[IndexedClass]
	[ExpressType("Type", 22)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @CobieType : CobieAsset, IInstantiableEntity, ICobieType, IEqualityComparer<@CobieType>, IEquatable<@CobieType>
	{
		#region ICobieType explicit implementation
		ICobiePickValue ICobieType.AssetType { get { return @AssetType; } }	
		ICobieContact ICobieType.Manufacturer { get { return @Manufacturer; } }	
		string ICobieType.ModelNumber { get { return @ModelNumber; } }	
		ICobieWarranty ICobieType.Warranty { get { return @Warranty; } }	
		double? ICobieType.ReplacementCost { get { return @ReplacementCost; } }	
		double? ICobieType.ExpectedLife { get { return @ExpectedLife; } }	
		ICobiePickValue ICobieType.DurationUnit { get { return @DurationUnit; } }	
		double ICobieType.NominalLength { get { return @NominalLength; } }	
		double ICobieType.NominalWidth { get { return @NominalWidth; } }	
		double ICobieType.NominalHeight { get { return @NominalHeight; } }	
		string ICobieType.ModelReference { get { return @ModelReference; } }	
		string ICobieType.Shape { get { return @Shape; } }	
		string ICobieType.Size { get { return @Size; } }	
		string ICobieType.Color { get { return @Color; } }	
		string ICobieType.Finish { get { return @Finish; } }	
		string ICobieType.Grade { get { return @Grade; } }	
		string ICobieType.Material { get { return @Material; } }	
		string ICobieType.Constituents { get { return @Constituents; } }	
		string ICobieType.Features { get { return @Features; } }	
		string ICobieType.AccessibilityPerformance { get { return @AccessibilityPerformance; } }	
		string ICobieType.CodePerformance { get { return @CodePerformance; } }	
		string ICobieType.SustainabilityPerformance { get { return @SustainabilityPerformance; } }	
		IEnumerable<ICobieType> ICobieType.AssemblyOf { get { return @AssemblyOf; } }	
		IEnumerable<ICobieJob> ICobieType.Jobs { get { return @Jobs; } }	
		 
		IEnumerable<ICobieComponent> ICobieType.Components {  get { return @Components; } }
		IEnumerable<ICobieSpare> ICobieType.Spares {  get { return @Spares; } }
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal CobieType(IModel model) : base(model) 		{ 
			Model = model; 
			_assemblyOf = new ItemSet<CobieType>( this, 0 );
			_jobs = new ItemSet<CobieJob>( this, 0 );
		}

		#region Explicit attribute fields
		private CobiePickValue _assetType;
		private CobieContact _manufacturer;
		private string _modelNumber;
		private CobieWarranty _warranty;
		private double? _replacementCost;
		private double? _expectedLife;
		private CobiePickValue _durationUnit;
		private double _nominalLength;
		private double _nominalWidth;
		private double _nominalHeight;
		private string _modelReference;
		private string _shape;
		private string _size;
		private string _color;
		private string _finish;
		private string _grade;
		private string _material;
		private string _constituents;
		private string _features;
		private string _accessibilityPerformance;
		private string _codePerformance;
		private string _sustainabilityPerformance;
		private ItemSet<CobieType> _assemblyOf;
		private ItemSet<CobieJob> _jobs;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 13)]
		public CobiePickValue @AssetType 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _assetType;
				((IPersistEntity)this).Activate(false);
				return _assetType;
			} 
			set
			{
				SetValue( v =>  _assetType = v, _assetType, value,  "AssetType");
			} 
		}	
		[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 14)]
		public CobieContact @Manufacturer 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _manufacturer;
				((IPersistEntity)this).Activate(false);
				return _manufacturer;
			} 
			set
			{
				SetValue( v =>  _manufacturer = v, _manufacturer, value,  "Manufacturer");
			} 
		}	
		[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 15)]
		public string @ModelNumber 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _modelNumber;
				((IPersistEntity)this).Activate(false);
				return _modelNumber;
			} 
			set
			{
				SetValue( v =>  _modelNumber = v, _modelNumber, value,  "ModelNumber");
			} 
		}	
		[EntityAttribute(14, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 16)]
		public CobieWarranty @Warranty 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _warranty;
				((IPersistEntity)this).Activate(false);
				return _warranty;
			} 
			set
			{
				SetValue( v =>  _warranty = v, _warranty, value,  "Warranty");
			} 
		}	
		[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 17)]
		public double? @ReplacementCost 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _replacementCost;
				((IPersistEntity)this).Activate(false);
				return _replacementCost;
			} 
			set
			{
				SetValue( v =>  _replacementCost = v, _replacementCost, value,  "ReplacementCost");
			} 
		}	
		[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 18)]
		public double? @ExpectedLife 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _expectedLife;
				((IPersistEntity)this).Activate(false);
				return _expectedLife;
			} 
			set
			{
				SetValue( v =>  _expectedLife = v, _expectedLife, value,  "ExpectedLife");
			} 
		}	
		[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 19)]
		public CobiePickValue @DurationUnit 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _durationUnit;
				((IPersistEntity)this).Activate(false);
				return _durationUnit;
			} 
			set
			{
				SetValue( v =>  _durationUnit = v, _durationUnit, value,  "DurationUnit");
			} 
		}	
		[EntityAttribute(18, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 20)]
		public double @NominalLength 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _nominalLength;
				((IPersistEntity)this).Activate(false);
				return _nominalLength;
			} 
			set
			{
				SetValue( v =>  _nominalLength = v, _nominalLength, value,  "NominalLength");
			} 
		}	
		[EntityAttribute(19, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 21)]
		public double @NominalWidth 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _nominalWidth;
				((IPersistEntity)this).Activate(false);
				return _nominalWidth;
			} 
			set
			{
				SetValue( v =>  _nominalWidth = v, _nominalWidth, value,  "NominalWidth");
			} 
		}	
		[EntityAttribute(20, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 22)]
		public double @NominalHeight 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _nominalHeight;
				((IPersistEntity)this).Activate(false);
				return _nominalHeight;
			} 
			set
			{
				SetValue( v =>  _nominalHeight = v, _nominalHeight, value,  "NominalHeight");
			} 
		}	
		[EntityAttribute(21, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 23)]
		public string @ModelReference 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _modelReference;
				((IPersistEntity)this).Activate(false);
				return _modelReference;
			} 
			set
			{
				SetValue( v =>  _modelReference = v, _modelReference, value,  "ModelReference");
			} 
		}	
		[EntityAttribute(22, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 24)]
		public string @Shape 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _shape;
				((IPersistEntity)this).Activate(false);
				return _shape;
			} 
			set
			{
				SetValue( v =>  _shape = v, _shape, value,  "Shape");
			} 
		}	
		[EntityAttribute(23, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 25)]
		public string @Size 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _size;
				((IPersistEntity)this).Activate(false);
				return _size;
			} 
			set
			{
				SetValue( v =>  _size = v, _size, value,  "Size");
			} 
		}	
		[EntityAttribute(24, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 26)]
		public string @Color 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _color;
				((IPersistEntity)this).Activate(false);
				return _color;
			} 
			set
			{
				SetValue( v =>  _color = v, _color, value,  "Color");
			} 
		}	
		[EntityAttribute(25, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 27)]
		public string @Finish 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _finish;
				((IPersistEntity)this).Activate(false);
				return _finish;
			} 
			set
			{
				SetValue( v =>  _finish = v, _finish, value,  "Finish");
			} 
		}	
		[EntityAttribute(26, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 28)]
		public string @Grade 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _grade;
				((IPersistEntity)this).Activate(false);
				return _grade;
			} 
			set
			{
				SetValue( v =>  _grade = v, _grade, value,  "Grade");
			} 
		}	
		[EntityAttribute(27, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 29)]
		public string @Material 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _material;
				((IPersistEntity)this).Activate(false);
				return _material;
			} 
			set
			{
				SetValue( v =>  _material = v, _material, value,  "Material");
			} 
		}	
		[EntityAttribute(28, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 30)]
		public string @Constituents 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _constituents;
				((IPersistEntity)this).Activate(false);
				return _constituents;
			} 
			set
			{
				SetValue( v =>  _constituents = v, _constituents, value,  "Constituents");
			} 
		}	
		[EntityAttribute(29, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 31)]
		public string @Features 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _features;
				((IPersistEntity)this).Activate(false);
				return _features;
			} 
			set
			{
				SetValue( v =>  _features = v, _features, value,  "Features");
			} 
		}	
		[EntityAttribute(30, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 32)]
		public string @AccessibilityPerformance 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _accessibilityPerformance;
				((IPersistEntity)this).Activate(false);
				return _accessibilityPerformance;
			} 
			set
			{
				SetValue( v =>  _accessibilityPerformance = v, _accessibilityPerformance, value,  "AccessibilityPerformance");
			} 
		}	
		[EntityAttribute(31, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 33)]
		public string @CodePerformance 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _codePerformance;
				((IPersistEntity)this).Activate(false);
				return _codePerformance;
			} 
			set
			{
				SetValue( v =>  _codePerformance = v, _codePerformance, value,  "CodePerformance");
			} 
		}	
		[EntityAttribute(32, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 34)]
		public string @SustainabilityPerformance 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _sustainabilityPerformance;
				((IPersistEntity)this).Activate(false);
				return _sustainabilityPerformance;
			} 
			set
			{
				SetValue( v =>  _sustainabilityPerformance = v, _sustainabilityPerformance, value,  "SustainabilityPerformance");
			} 
		}	
		[EntityAttribute(33, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, 1, -1, 35)]
		public ItemSet<CobieType> @AssemblyOf 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _assemblyOf;
				((IPersistEntity)this).Activate(false);
				return _assemblyOf;
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(34, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, 0, -1, 36)]
		public ItemSet<CobieJob> @Jobs 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _jobs;
				((IPersistEntity)this).Activate(false);
				return _jobs;
			} 
		}	
		#endregion



		#region Inverse attributes
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, -1, -1, 37)]
		public IEnumerable<CobieComponent> @Components 
		{ 
			get 
			{
				return Model.Instances.Where<CobieComponent>(e => (e.Type as CobieType) == this);
			} 
		}
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, -1, -1, 38)]
		public IEnumerable<CobieSpare> @Spares 
		{ 
			get 
			{
				return Model.Instances.Where<CobieSpare>(e => (e.Type as CobieType) == this);
			} 
		}
		#endregion


		#region IPersist implementation
		public  override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
				case 1: 
				case 2: 
				case 3: 
				case 4: 
				case 5: 
				case 6: 
				case 7: 
				case 8: 
				case 9: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 10: 
					_assetType = (CobiePickValue)(value.EntityVal);
					return;
				case 11: 
					_manufacturer = (CobieContact)(value.EntityVal);
					return;
				case 12: 
					_modelNumber = value.StringVal;
					return;
				case 13: 
					_warranty = (CobieWarranty)(value.EntityVal);
					return;
				case 14: 
					_replacementCost = value.RealVal;
					return;
				case 15: 
					_expectedLife = value.RealVal;
					return;
				case 16: 
					_durationUnit = (CobiePickValue)(value.EntityVal);
					return;
				case 17: 
					_nominalLength = value.RealVal;
					return;
				case 18: 
					_nominalWidth = value.RealVal;
					return;
				case 19: 
					_nominalHeight = value.RealVal;
					return;
				case 20: 
					_modelReference = value.StringVal;
					return;
				case 21: 
					_shape = value.StringVal;
					return;
				case 22: 
					_size = value.StringVal;
					return;
				case 23: 
					_color = value.StringVal;
					return;
				case 24: 
					_finish = value.StringVal;
					return;
				case 25: 
					_grade = value.StringVal;
					return;
				case 26: 
					_material = value.StringVal;
					return;
				case 27: 
					_constituents = value.StringVal;
					return;
				case 28: 
					_features = value.StringVal;
					return;
				case 29: 
					_accessibilityPerformance = value.StringVal;
					return;
				case 30: 
					_codePerformance = value.StringVal;
					return;
				case 31: 
					_sustainabilityPerformance = value.StringVal;
					return;
				case 32: 
					if (_assemblyOf == null) _assemblyOf = new ItemSet<CobieType>( this );
					_assemblyOf.InternalAdd((CobieType)value.EntityVal);
					return;
				case 33: 
					if (_jobs == null) _jobs = new ItemSet<CobieJob>( this );
					_jobs.InternalAdd((CobieJob)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		
		public  override string WhereRule() 
		{
			return "";
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@CobieType other)
	    {
	        return this == other;
	    }

	    public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (GetType() != obj.GetType()) return false;

            // Cast as @CobieType
            var root = (@CobieType)obj;
            return this == root;
        }
        public override int GetHashCode()
        {
            //good enough as most entities will be in collections of  only one model, equals distinguishes for model
            return EntityLabel.GetHashCode(); 
        }

        public static bool operator ==(@CobieType left, @CobieType right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
                return true;

            // If one is null, but not both, return false.
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return (left.EntityLabel == right.EntityLabel) && (left.Model == right.Model);

        }

        public static bool operator !=(@CobieType left, @CobieType right)
        {
            return !(left == right);
        }


        public bool Equals(@CobieType x, @CobieType y)
        {
            return x == y;
        }

        public int GetHashCode(@CobieType obj)
        {
            return obj == null ? -1 : obj.GetHashCode();
        }
        #endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}