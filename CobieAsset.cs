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
    /// Readonly interface for CobieAsset
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @ICobieAsset : ICobieReferencedObject
	{
		string @Name { get; }
		string @Description { get; }
		IEnumerable<ICobieCategory> @Categories { get; }
		IEnumerable<ICobieImpact> @Impacts { get; }
		IEnumerable<ICobieDocument> @Documents { get; }
		IEnumerable<ICobieAttribute> @Attributes { get; }
		IEnumerable<ICobieIssue> @CausingIssues {  get; }
		IEnumerable<ICobieIssue> @AffectedBy {  get; }
	
	}
}

namespace Xbim.CobieExpress
{
	[IndexedClass]
	[ExpressType("Asset", 13)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @CobieAsset : CobieReferencedObject, ICobieAsset, IEqualityComparer<@CobieAsset>, IEquatable<@CobieAsset>
	{
		#region ICobieAsset explicit implementation
		string ICobieAsset.Name { get { return @Name; } }	
		string ICobieAsset.Description { get { return @Description; } }	
		IEnumerable<ICobieCategory> ICobieAsset.Categories { get { return @Categories; } }	
		IEnumerable<ICobieImpact> ICobieAsset.Impacts { get { return @Impacts; } }	
		IEnumerable<ICobieDocument> ICobieAsset.Documents { get { return @Documents; } }	
		IEnumerable<ICobieAttribute> ICobieAsset.Attributes { get { return @Attributes; } }	
		 
		IEnumerable<ICobieIssue> ICobieAsset.CausingIssues {  get { return @CausingIssues; } }
		IEnumerable<ICobieIssue> ICobieAsset.AffectedBy {  get { return @AffectedBy; } }
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal CobieAsset(IModel model) : base(model) 		{ 
			Model = model; 
			_categories = new ItemSet<CobieCategory>( this, 0 );
			_impacts = new OptionalItemSet<CobieImpact>( this, 0 );
			_documents = new OptionalItemSet<CobieDocument>( this, 0 );
			_attributes = new OptionalItemSet<CobieAttribute>( this, 0 );
		}

		#region Explicit attribute fields
		private string _name;
		private string _description;
		private ItemSet<CobieCategory> _categories;
		private OptionalItemSet<CobieImpact> _impacts;
		private OptionalItemSet<CobieDocument> _documents;
		private OptionalItemSet<CobieAttribute> _attributes;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 6)]
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
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 7)]
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
		[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, 1, -1, 8)]
		public ItemSet<CobieCategory> @Categories 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _categories;
				((IPersistEntity)this).Activate(false);
				return _categories;
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, 0, -1, 9)]
		public OptionalItemSet<CobieImpact> @Impacts 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _impacts;
				((IPersistEntity)this).Activate(false);
				return _impacts;
			} 
		}	
		[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, 0, -1, 10)]
		public OptionalItemSet<CobieDocument> @Documents 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _documents;
				((IPersistEntity)this).Activate(false);
				return _documents;
			} 
		}	
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, 0, -1, 11)]
		public OptionalItemSet<CobieAttribute> @Attributes 
		{ 
			get 
			{
				if(ActivationStatus != ActivationStatus.NotActivated) return _attributes;
				((IPersistEntity)this).Activate(false);
				return _attributes;
			} 
		}	
		#endregion



		#region Inverse attributes
		[InverseProperty("Causing")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 0, -1, 12)]
		public IEnumerable<CobieIssue> @CausingIssues 
		{ 
			get 
			{
				return Model.Instances.Where<CobieIssue>(e => (e.Causing as CobieAsset) == this, "Causing", this);
			} 
		}
		[InverseProperty("Affected")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 0, -1, 13)]
		public IEnumerable<CobieIssue> @AffectedBy 
		{ 
			get 
			{
				return Model.Instances.Where<CobieIssue>(e => (e.Affected as CobieAsset) == this, "Affected", this);
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 5: 
					_name = value.StringVal;
					return;
				case 6: 
					_description = value.StringVal;
					return;
				case 7: 
					if (_categories == null) _categories = new ItemSet<CobieCategory>( this );
					_categories.InternalAdd((CobieCategory)value.EntityVal);
					return;
				case 8: 
					if (_impacts == null) _impacts = new OptionalItemSet<CobieImpact>( this );
					_impacts.InternalAdd((CobieImpact)value.EntityVal);
					return;
				case 9: 
					if (_documents == null) _documents = new OptionalItemSet<CobieDocument>( this );
					_documents.InternalAdd((CobieDocument)value.EntityVal);
					return;
				case 10: 
					if (_attributes == null) _attributes = new OptionalItemSet<CobieAttribute>( this );
					_attributes.InternalAdd((CobieAttribute)value.EntityVal);
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
        public bool Equals(@CobieAsset other)
	    {
	        return this == other;
	    }

	    public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (GetType() != obj.GetType()) return false;

            // Cast as @CobieAsset
            var root = (@CobieAsset)obj;
            return this == root;
        }
        public override int GetHashCode()
        {
            //good enough as most entities will be in collections of  only one model, equals distinguishes for model
            return EntityLabel.GetHashCode(); 
        }

        public static bool operator ==(@CobieAsset left, @CobieAsset right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
                return true;

            // If one is null, but not both, return false.
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return (left.EntityLabel == right.EntityLabel) && (left.Model == right.Model);

        }

        public static bool operator !=(@CobieAsset left, @CobieAsset right)
        {
            return !(left == right);
        }


        public bool Equals(@CobieAsset x, @CobieAsset y)
        {
            return x == y;
        }

        public int GetHashCode(@CobieAsset obj)
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