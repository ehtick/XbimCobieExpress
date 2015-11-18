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
    /// Readonly interface for CobieSpare
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @ICobieSpare : ICobieReferencedObject
	{
		string @Name { get; }
		string @Description { get; }
		ICobiePickValue @SpareType { get; }
		ICobieType @Type { get; }
		IEnumerable<ICobieContact> @Suppliers { get; }
		string @SetNumber { get; }
		string @PartNumber { get; }
	
	}
}

namespace Xbim.CobieExpress
{
	[IndexedClass]
	[ExpressType("Spare", 27)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @CobieSpare : CobieReferencedObject, IInstantiableEntity, ICobieSpare, IEqualityComparer<@CobieSpare>, IEquatable<@CobieSpare>
	{
		#region ICobieSpare explicit implementation
		string ICobieSpare.Name { get { return @Name; } }	
		string ICobieSpare.Description { get { return @Description; } }	
		ICobiePickValue ICobieSpare.SpareType { get { return @SpareType; } }	
		ICobieType ICobieSpare.Type { get { return @Type; } }	
		IEnumerable<ICobieContact> ICobieSpare.Suppliers { get { return @Suppliers; } }	
		string ICobieSpare.SetNumber { get { return @SetNumber; } }	
		string ICobieSpare.PartNumber { get { return @PartNumber; } }	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal CobieSpare(IModel model) : base(model) 		{ 
			Model = model; 
			_suppliers = new ItemSet<CobieContact>( this, 0 );
		}

		#region Explicit attribute fields
		private string _name;
		private string _description;
		private CobiePickValue _spareType;
		private CobieType _type;
		private ItemSet<CobieContact> _suppliers;
		private string _setNumber;
		private string _partNumber;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 5)]
		public string @Name 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _name;
				((IPersistEntity)this).Activate(false);
				return _name;
			} 
			set
			{
				SetValue( v =>  _name = v, _name, value,  "Name");
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 6)]
		public string @Description 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _description;
				((IPersistEntity)this).Activate(false);
				return _description;
			} 
			set
			{
				SetValue( v =>  _description = v, _description, value,  "Description");
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 7)]
		public CobiePickValue @SpareType 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _spareType;
				((IPersistEntity)this).Activate(false);
				return _spareType;
			} 
			set
			{
				SetValue( v =>  _spareType = v, _spareType, value,  "SpareType");
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 8)]
		public CobieType @Type 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _type;
				((IPersistEntity)this).Activate(false);
				return _type;
			} 
			set
			{
				SetValue( v =>  _type = v, _type, value,  "Type");
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, 0, -1, 9)]
		public ItemSet<CobieContact> @Suppliers 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _suppliers;
				((IPersistEntity)this).Activate(false);
				return _suppliers;
			} 
		}	
		[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 10)]
		public string @SetNumber 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _setNumber;
				((IPersistEntity)this).Activate(false);
				return _setNumber;
			} 
			set
			{
				SetValue( v =>  _setNumber = v, _setNumber, value,  "SetNumber");
			} 
		}	
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 11)]
		public string @PartNumber 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _partNumber;
				((IPersistEntity)this).Activate(false);
				return _partNumber;
			} 
			set
			{
				SetValue( v =>  _partNumber = v, _partNumber, value,  "PartNumber");
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 4: 
					_name = value.StringVal;
					return;
				case 5: 
					_description = value.StringVal;
					return;
				case 6: 
					_spareType = (CobiePickValue)(value.EntityVal);
					return;
				case 7: 
					_type = (CobieType)(value.EntityVal);
					return;
				case 8: 
					if (_suppliers == null) _suppliers = new ItemSet<CobieContact>( this );
					_suppliers.InternalAdd((CobieContact)value.EntityVal);
					return;
				case 9: 
					_setNumber = value.StringVal;
					return;
				case 10: 
					_partNumber = value.StringVal;
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
        public bool Equals(@CobieSpare other)
	    {
	        return this == other;
	    }

	    public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (GetType() != obj.GetType()) return false;

            // Cast as @CobieSpare
            var root = (@CobieSpare)obj;
            return this == root;
        }
        public override int GetHashCode()
        {
            //good enough as most entities will be in collections of  only one model, equals distinguishes for model
            return EntityLabel.GetHashCode(); 
        }

        public static bool operator ==(@CobieSpare left, @CobieSpare right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
                return true;

            // If one is null, but not both, return false.
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return (left.EntityLabel == right.EntityLabel) && (left.Model == right.Model);

        }

        public static bool operator !=(@CobieSpare left, @CobieSpare right)
        {
            return !(left == right);
        }


        public bool Equals(@CobieSpare x, @CobieSpare y)
        {
            return x == y;
        }

        public int GetHashCode(@CobieSpare obj)
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