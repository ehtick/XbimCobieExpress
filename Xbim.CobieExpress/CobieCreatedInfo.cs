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
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.CobieExpress.Interfaces;
using Xbim.CobieExpress;
//## Custom using statements
//##

namespace Xbim.CobieExpress.Interfaces
{
	/// <summary>
    /// Readonly interface for CobieCreatedInfo
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @ICobieCreatedInfo : IPersistEntity
	{
		ICobieContact @CreatedBy { get;  set; }
		DateTimeValue @CreatedOn { get;  set; }
	
	}
}

namespace Xbim.CobieExpress
{
	[ExpressType("CreatedInfo", 10)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @CobieCreatedInfo : PersistEntity, IInstantiableEntity, ICobieCreatedInfo, IContainsEntityReferences, IEquatable<@CobieCreatedInfo>
	{
		#region ICobieCreatedInfo explicit implementation
		ICobieContact ICobieCreatedInfo.CreatedBy { 
 
 
			get { return @CreatedBy; } 
			set { CreatedBy = value as CobieContact;}
		}	
		DateTimeValue ICobieCreatedInfo.CreatedOn { 
 
			get { return @CreatedOn; } 
			set { CreatedOn = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal CobieCreatedInfo(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private CobieContact _createdBy;
		private DateTimeValue _createdOn;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
		public CobieContact @CreatedBy 
		{ 
			get 
			{
				if(_activated) return _createdBy;
				Activate();
				return _createdBy;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _createdBy = v, _createdBy, value,  "CreatedBy", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
		public DateTimeValue @CreatedOn 
		{ 
			get 
			{
				if(_activated) return _createdOn;
				Activate();
				return _createdOn;
			} 
			set
			{
				SetValue( v =>  _createdOn = v, _createdOn, value,  "CreatedOn", 2);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_createdBy = (CobieContact)(value.EntityVal);
					return;
				case 1: 
					_createdOn = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@CobieCreatedInfo other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@CreatedBy != null)
					yield return @CreatedBy;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}