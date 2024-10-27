using AssetsTools.NET;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioKindExtension
    {
        public ScenarioIndexKind IndexKind { get; set; }
        public IList<ScenarioCounterExtension> ScenarioCounterList { get; set; }
        public IList<ScenarioDoneExtension> ScenarioDoneList { get; set; }
        public IList<ScenarioMapExtension> ScenarioMapList { get; set; }
        public IList<ScenarioBadgeExtension> ScenarioBadgeList { get; set; }
        public IList<AreaChangeExtension> AreaChangeList { get; set; }
        public IList<ShopExtension> ShopList { get; set; }
        public IList<StrugglePointExtension> StrugglePointList { get; set; }
        public IList<StruggleBossExtension> StruggleBossList { get; set; }
        public IList<StruggleTeamMemberExtension> StruggleTeamMemberList { get; set; }
        public IList<StruggleTeamAreaExtension> StruggleTeamAreaList { get; set; }
        public IList<StruggleNoiseExtension> StruggleNoiseList { get; set; }
        public IList<StruggleAreaControllExtension> StruggleAreaControllList { get; set; }
        public IList<GroupAreaChangeExtension> GroupAreaChangeList { get; set; }
        public IList<ReminderExtension> ReminderExtensionList { get; set; }
        public IList<ImprintResultExtension> ImprintResultExtensionList { get; set; }
        public IList<AddCharacterExtension> AddCharacterList { get; set; }
        public IList<ScenarioResetExtension> ScenarioResetList { get; set; }

        public static ScenarioKindExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioKindExtension()
            {
                IndexKind = (ScenarioIndexKind)baseField["m_SerializeScenarioIndexKind"].AsInt,
                ScenarioCounterList = baseField["m_ScenarioCounterList"]["Array"].Select(ScenarioCounterExtension.CreateFromMono).ToList(),
                ScenarioDoneList = baseField["m_ScenarioDoneList"]["Array"].Select(ScenarioDoneExtension.CreateFromMono).ToList(),
                ScenarioMapList = baseField["m_ScenarioMapList"]["Array"].Select(ScenarioMapExtension.CreateFromMono).ToList(),
                ScenarioBadgeList = baseField["m_ScenarioBadgeList"]["Array"].Select(ScenarioBadgeExtension.CreateFromMono).ToList(),
                AreaChangeList = baseField["m_AreaChangeList"]["Array"].Select(AreaChangeExtension.CreateFromMono).ToList(),
                ShopList = baseField["m_ShopList"]["Array"].Select(ShopExtension.CreateFromMono).ToList(),
                StrugglePointList = baseField["m_StrugglePointList"]["Array"].Select(StrugglePointExtension.CreateFromMono).ToList(),
                StruggleBossList = baseField["m_StruggleBossList"]["Array"].Select(StruggleBossExtension.CreateFromMono).ToList(),
                StruggleTeamMemberList = baseField["m_StruggleTeamMemberList"]["Array"].Select(StruggleTeamMemberExtension.CreateFromMono).ToList(),
                StruggleTeamAreaList = baseField["m_StruggleTeamAreaList"]["Array"].Select(StruggleTeamAreaExtension.CreateFromMono).ToList(),
                StruggleNoiseList = baseField["m_StruggleNoiseList"]["Array"].Select(StruggleNoiseExtension.CreateFromMono).ToList(),
                StruggleAreaControllList = baseField["m_StruggleAreaControllList"]["Array"].Select(StruggleAreaControllExtension.CreateFromMono).ToList(),
                GroupAreaChangeList = baseField["m_GroupAreaChangeList"]["Array"].Select(GroupAreaChangeExtension.CreateFromMono).ToList(),
                ReminderExtensionList = baseField["m_ReminderExtensionList"]["Array"].Select(ReminderExtension.CreateFromMono).ToList(),
                ImprintResultExtensionList = baseField["m_ImprintResultExtensionList"]["Array"].Select(ImprintResultExtension.CreateFromMono).ToList(),
                AddCharacterList = baseField["m_AddCharacterList"]["Array"].Select(AddCharacterExtension.CreateFromMono).ToList(),
                ScenarioResetList = baseField["m_ScenarioResetList"]["Array"].Select(ScenarioResetExtension.CreateFromMono).ToList(),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            baseField["m_SerializeScenarioIndexKind"].AsInt = (int)IndexKind;
            baseField["m_ScenarioCounterList"]["Array"].ReplaceArray(ScenarioCounterList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ScenarioDoneList"]["Array"].ReplaceArray(ScenarioDoneList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ScenarioMapList"]["Array"].ReplaceArray(ScenarioMapList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ScenarioBadgeList"]["Array"].ReplaceArray(ScenarioBadgeList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_AreaChangeList"]["Array"].ReplaceArray(AreaChangeList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ShopList"]["Array"].ReplaceArray(ShopList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_StrugglePointList"]["Array"].ReplaceArray(StrugglePointList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_StruggleBossList"]["Array"].ReplaceArray(StruggleBossList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_StruggleTeamMemberList"]["Array"].ReplaceArray(StruggleTeamMemberList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_StruggleTeamAreaList"]["Array"].ReplaceArray(StruggleTeamAreaList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_StruggleNoiseList"]["Array"].ReplaceArray(StruggleNoiseList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_StruggleAreaControllList"]["Array"].ReplaceArray(StruggleAreaControllList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_GroupAreaChangeList"]["Array"].ReplaceArray(GroupAreaChangeList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ReminderExtensionList"]["Array"].ReplaceArray(ReminderExtensionList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ImprintResultExtensionList"]["Array"].ReplaceArray(ImprintResultExtensionList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_AddCharacterList"]["Array"].ReplaceArray(AddCharacterList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ScenarioResetList"]["Array"].ReplaceArray(ScenarioResetList, (x, baseField) => x.ExportToMono(baseField));
        }
    }
}
