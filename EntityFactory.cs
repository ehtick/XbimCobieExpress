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
using Xbim.Common;

namespace Xbim.CobieExpress
{
	public sealed class EntityFactory : IEntityFactory
	{
		public T New<T>(IModel model, int entityLabel, bool activated) where T: IInstantiableEntity
		{
			return (T)New(model, typeof(T), entityLabel, activated);
		}

		public T New<T>(IModel model, Action<T> init, int entityLabel, bool activated) where T: IInstantiableEntity
		{
			var o = New<T>(model, entityLabel, activated);
			init(o);
			return o;
		}

		public IInstantiableEntity New(IModel model, Type t, int entityLabel, bool activated)
		{
			//check that the type is from this assembly
			if(t.Assembly != GetType().Assembly)
				throw new Exception("This factory only creates types from its assembly");

			return New(model, t.Name, entityLabel, activated);
		}

		public IInstantiableEntity New(IModel model, string typeName, int entityLabel, bool activated)
		{
			if (model == null || typeName == null)
				throw new ArgumentNullException();

			var name = typeName.ToUpper();
			switch(name)
			{
				case "COBIEPHASE": return new CobiePhase ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "PHASE": return new CobiePhase ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEEXTERNALSYSTEM": return new CobieExternalSystem ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "EXTERNALSYSTEM": return new CobieExternalSystem ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECREATEDINFO": return new CobieCreatedInfo ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "CREATEDINFO": return new CobieCreatedInfo ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECONTACT": return new CobieContact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "CONTACT": return new CobieContact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEFACILITY": return new CobieFacility ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "FACILITY": return new CobieFacility ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEPROJECT": return new CobieProject ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "PROJECT": return new CobieProject ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIESITE": return new CobieSite ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "SITE": return new CobieSite ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEFLOOR": return new CobieFloor ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "FLOOR": return new CobieFloor ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIESPACE": return new CobieSpace ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "SPACE": return new CobieSpace ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEZONE": return new CobieZone ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ZONE": return new CobieZone ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIETYPE": return new CobieType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "TYPE": return new CobieType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEWARRANTY": return new CobieWarranty ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "WARRANTY": return new CobieWarranty ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECOMPONENT": return new CobieComponent ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COMPONENT": return new CobieComponent ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIESYSTEM": return new CobieSystem ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "SYSTEM": return new CobieSystem ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECONNECTION": return new CobieConnection ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "CONNECTION": return new CobieConnection ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIESPARE": return new CobieSpare ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "SPARE": return new CobieSpare ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIERESOURCE": return new CobieResource ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "RESOURCE": return new CobieResource ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEJOB": return new CobieJob ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "JOB": return new CobieJob ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEIMPACT": return new CobieImpact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "IMPACT": return new CobieImpact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEDOCUMENT": return new CobieDocument ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "DOCUMENT": return new CobieDocument ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEATTRIBUTE": return new CobieAttribute ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ATTRIBUTE": return new CobieAttribute ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEISSUE": return new CobieIssue ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ISSUE": return new CobieIssue ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECATEGORY": return new CobieCategory ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "CATEGORY": return new CobieCategory ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEROLE": return new CobieRole ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ROLE": return new CobieRole ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIELINEARUNIT": return new CobieLinearUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "LINEARUNIT": return new CobieLinearUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEAREAUNIT": return new CobieAreaUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "AREAUNIT": return new CobieAreaUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEVOLUMEUNIT": return new CobieVolumeUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "VOLUMEUNIT": return new CobieVolumeUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECURRENCYUNIT": return new CobieCurrencyUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "CURRENCYUNIT": return new CobieCurrencyUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEDURATIONUNIT": return new CobieDurationUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "DURATIONUNIT": return new CobieDurationUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEASSETTYPE": return new CobieAssetType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ASSETTYPE": return new CobieAssetType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIECONNECTIONTYPE": return new CobieConnectionType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "CONNECTIONTYPE": return new CobieConnectionType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIESPARETYPE": return new CobieSpareType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "SPARETYPE": return new CobieSpareType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIERESOURCETYPE": return new CobieResourceType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "RESOURCETYPE": return new CobieResourceType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEJOBTYPE": return new CobieJobType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "JOBTYPE": return new CobieJobType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEJOBSTATUSTYPE": return new CobieJobStatusType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "JOBSTATUSTYPE": return new CobieJobStatusType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEIMPACTTYPE": return new CobieImpactType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "IMPACTTYPE": return new CobieImpactType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEIMPACTSTAGE": return new CobieImpactStage ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "IMPACTSTAGE": return new CobieImpactStage ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEIMPACTUNIT": return new CobieImpactUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "IMPACTUNIT": return new CobieImpactUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEDOCUMENTTYPE": return new CobieDocumentType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "DOCUMENTTYPE": return new CobieDocumentType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIESTAGETYPE": return new CobieStageType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "STAGETYPE": return new CobieStageType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEAPPROVALTYPE": return new CobieApprovalType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "APPROVALTYPE": return new CobieApprovalType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEISSUETYPE": return new CobieIssueType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ISSUETYPE": return new CobieIssueType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEISSUECHANCE": return new CobieIssueChance ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ISSUECHANCE": return new CobieIssueChance ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEISSUERISK": return new CobieIssueRisk ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ISSUERISK": return new CobieIssueRisk ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "COBIEISSUEIMPACT": return new CobieIssueImpact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case "ISSUEIMPACT": return new CobieIssueImpact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				default:
					return null;
			}
		}
		public IInstantiableEntity New(IModel model, int typeId, int entityLabel, bool activated)
		{
			if (model == null)
				throw new ArgumentNullException();

			switch(typeId)
			{
				case 7: return new CobiePhase ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 8: return new CobieExternalSystem ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 9: return new CobieCreatedInfo ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 11: return new CobieContact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 13: return new CobieFacility ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 14: return new CobieProject ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 15: return new CobieSite ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 16: return new CobieFloor ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 17: return new CobieSpace ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 18: return new CobieZone ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 19: return new CobieType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 20: return new CobieWarranty ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 21: return new CobieComponent ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 22: return new CobieSystem ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 23: return new CobieConnection ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 24: return new CobieSpare ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 25: return new CobieResource ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 26: return new CobieJob ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 27: return new CobieImpact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 28: return new CobieDocument ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 29: return new CobieAttribute ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 30: return new CobieIssue ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 32: return new CobieCategory ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 33: return new CobieRole ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 34: return new CobieLinearUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 35: return new CobieAreaUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 36: return new CobieVolumeUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 37: return new CobieCurrencyUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 38: return new CobieDurationUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 39: return new CobieAssetType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 40: return new CobieConnectionType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 41: return new CobieSpareType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 42: return new CobieResourceType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 43: return new CobieJobType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 44: return new CobieJobStatusType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 45: return new CobieImpactType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 46: return new CobieImpactStage ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 47: return new CobieImpactUnit ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 48: return new CobieDocumentType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 49: return new CobieStageType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 50: return new CobieApprovalType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 51: return new CobieIssueType ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 52: return new CobieIssueChance ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 53: return new CobieIssueRisk ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				case 54: return new CobieIssueImpact ( model ) { ActivationStatus = activated ? ActivationStatus.ActivatedRead : ActivationStatus.NotActivated, EntityLabel = entityLabel };
				default:
					return null;
			}
		}

		public IExpressValueType New(string typeName)
		{
		if (typeName == null)
				throw new ArgumentNullException();

			var name = typeName.ToUpper();
			switch(name)
			{
				case "STRINGVALUE": return new StringValue ();
				case "INTEGERVALUE": return new IntegerValue ();
				case "FLOATVALUE": return new FloatValue ();
				case "BOOLEANVALUE": return new BooleanValue ();
				case "DATETIMEVALUE": return new DateTimeValue ();
				default:
					return null;
			}
		}

		private static readonly List<string> _schemasIds = new List<string> { "COBIE_EXPRESS" };
		public IEnumerable<string> SchemasIds { get { return _schemasIds; } }

	}
}
