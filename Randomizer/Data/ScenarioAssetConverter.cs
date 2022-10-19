using AssetsTools.NET;
using AssetsTools.NET.Extra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class ScenarioAssetConverter
    {
        public static string ConvertFromBaseField(AssetTypeValueField baseField)
        {
            return MonoBehaviorConverter.ConvertFromBaseField(baseField);
        }

        public static void InsertInBaseField(AssetTypeValueField baseField, string newValue)
        {
            Scenario scenario = JsonConvert.DeserializeObject<Scenario>(newValue);

            baseField["m_GameObject"]["m_FileID"].GetValue().Set(scenario.GameObject.FileID);
            baseField["m_GameObject"]["m_PathID"].GetValue().Set(scenario.GameObject.PathID);

            baseField["m_Enabled"].GetValue().Set(scenario.Enabled);

            baseField["m_Script"]["m_FileID"].GetValue().Set(scenario.Script.FileID);
            baseField["m_Script"]["m_PathID"].GetValue().Set(scenario.Script.PathID);

            baseField["m_Name"].GetValue().Set(scenario.Name);

            InsertAssetList(baseField["m_List"]["Array"], scenario.AssetList);

            baseField["m_BootTiming"]["Name"].GetValue().Set(scenario.BootTiming.Name);
            baseField["m_BootTiming"]["m_SerializedValue"].GetValue().Set(scenario.BootTiming.SerializedValue);

            baseField["m_Generation"]["m_Logic"]["Name"].GetValue().Set(scenario.Generation.Logic.Name);
            baseField["m_Generation"]["m_Logic"]["m_SerializedValue"].GetValue().Set(scenario.Generation.Logic.SerializedValue);
            baseField["m_Generation"]["m_Inverse"].GetValue().Set(scenario.Generation.Inverse);
            InsertScenarioEventList(baseField["m_Generation"]["m_List"]["Array"], scenario.Generation.List);

            InsertScenarioEventList(baseField["m_Preparation"]["Array"], scenario.Preparation);

            baseField["m_Ready"]["m_Logic"]["Name"].GetValue().Set(scenario.Ready.Logic.Name);
            baseField["m_Ready"]["m_Logic"]["m_SerializedValue"].GetValue().Set(scenario.Ready.Logic.SerializedValue);
            baseField["m_Ready"]["m_Inverse"].GetValue().Set(scenario.Ready.Inverse);
            InsertScenarioEventList(baseField["m_Ready"]["m_List"]["Array"], scenario.Ready.List);

            baseField["m_Done"]["m_Logic"]["Name"].GetValue().Set(scenario.Done.Logic.Name);
            baseField["m_Done"]["m_Logic"]["m_SerializedValue"].GetValue().Set(scenario.Done.Logic.SerializedValue);
            baseField["m_Done"]["m_Inverse"].GetValue().Set(scenario.Done.Inverse);
            InsertScenarioEventList(baseField["m_Done"]["m_List"]["Array"], scenario.Done.List);

            InsertScenarioEventList(baseField["m_Result"]["Array"], scenario.Result);

            InsertUnityFileList(baseField["m_NextList"]["Array"], scenario.NextList);

            InsertUnityFileList(baseField["m_ReplayBootList"]["Array"], scenario.ReplayBootList);

            baseField["m_ReplayDone"]["m_Logic"]["Name"].GetValue().Set(scenario.ReplayDone.Logic.Name);
            baseField["m_ReplayDone"]["m_Logic"]["m_SerializedValue"].GetValue().Set(scenario.ReplayDone.Logic.SerializedValue);
            baseField["m_ReplayDone"]["m_Inverse"].GetValue().Set(scenario.ReplayDone.Inverse);
            InsertScenarioEventList(baseField["m_ReplayDone"]["m_List"]["Array"], scenario.ReplayDone.List);

            InsertUnityFileList(baseField["m_StruggleList"]["Array"], scenario.StruggleList);

            baseField["m_Permanent"].GetValue().Set(scenario.Permanent);

            baseField["m_DoneNextStatus"].GetValue().Set(scenario.DoneNextStatus);

            baseField["m_DisablePermanentConditions"]["m_Logic"]["Name"].GetValue().Set(scenario.DisablePermanentConditions.Logic.Name);
            baseField["m_DisablePermanentConditions"]["m_Logic"]["m_SerializedValue"].GetValue().Set(scenario.DisablePermanentConditions.Logic.SerializedValue);
            baseField["m_DisablePermanentConditions"]["m_Inverse"].GetValue().Set(scenario.DisablePermanentConditions.Inverse);
            InsertScenarioEventList(baseField["m_DisablePermanentConditions"]["m_List"]["Array"], scenario.DisablePermanentConditions.List);

            baseField["m_IsDoneNextImmediate"].GetValue().Set(scenario.IsDoneNextImmediate);

            baseField["m_IsBootTimingCheckField"].GetValue().Set(scenario.IsBootTimingCheckField);

            InsertUnityFileList(baseField["m_MarkerList"]["Array"], scenario.MarkerList);

            baseField["m_DayEndScenario"].GetValue().Set(scenario.DayEndScenario);

            baseField["m_EventID"].GetValue().Set(scenario.EventID);
        }

        private static void InsertAssetList(AssetTypeValueField field, IList<UnityAssetInfo> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_GUID"].GetValue().Set(item.GUID);
                field[i]["m_AssetPath"].GetValue().Set(item.AssetPath);
                field[i]["m_AssetBundleFilePath"].GetValue().Set(item.AssetBundleFilePath);
                field[i]["m_AssetBundleName"].GetValue().Set(item.AssetBundleName);
                field[i]["m_ObjectName"].GetValue().Set(item.ObjectName);
                field[i]["m_TransformPath"].GetValue().Set(item.TransformPath);
                field[i]["m_IsImmediateRelease"].GetValue().Set(item.IsImmediateRelease);
            }
        }

        private static void InsertScenarioEventList(AssetTypeValueField field, IList<ScenarioEvent> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                InsertScenarioEvent(field[i], value[i]);
            }
        }

        private static void InsertScenarioCounterList(AssetTypeValueField field, IList<ScenarioCounter> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_CalcOperator"]["Name"].GetValue().Set(item.CalcOperator.Name);
                field[i]["m_CalcOperator"]["m_SerializedValue"].GetValue().Set(item.CalcOperator.SerializedValue);
                field[i]["m_ComparisonValue"].GetValue().Set(item.ComparisonValue);
            }
        }

        private static void InsertScenarioDoneList(AssetTypeValueField field, IList<ScenarioDone> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_DoneItemGroup"]["m_FileID"].GetValue().Set(item.DoneItemGroup.FileID);
                field[i]["m_DoneItemGroup"]["m_PathID"].GetValue().Set(item.DoneItemGroup.PathID);
            }
        }

        private static void InsertScenarioMapList(AssetTypeValueField field, IList<ScenarioMap> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_PositionTag"].GetValue().Set(item.PositionTag);
            }
        }

        private static void InsertAreaChangeList(AssetTypeValueField field, IList<AreaChange> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_AreaChangeStatus"]["Name"].GetValue().Set(item.AreaChangeStatus.Name);
                field[i]["m_AreaChangeStatus"]["m_SerializedValue"].GetValue().Set(item.AreaChangeStatus.SerializedValue);
            }
        }

        private static void InsertScenarioShopList(AssetTypeValueField field, IList<ScenarioShop> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ShopStatus"]["Name"].GetValue().Set(item.ShopStatus.Name);
                field[i]["m_ShopStatus"]["m_SerializedValue"].GetValue().Set(item.ShopStatus.SerializedValue);
            }
        }

        private static void InsertStruggleBossList(AssetTypeValueField field, IList<StruggleBoss> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_TeamType"]["Name"].GetValue().Set(item.TeamType.Name);
                field[i]["m_TeamType"]["m_SerializedValue"].GetValue().Set(item.TeamType.SerializedValue);
            }
        }

        private static void InsertStruggleTeamMemberList(AssetTypeValueField field, IList<StruggleTeamMember> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_TeamMember"]["Name"].GetValue().Set(item.TeamMember.Name);
                field[i]["m_TeamMember"]["m_SerializedValue"].GetValue().Set(item.TeamMember.SerializedValue);
                field[i]["m_TargetArea"]["Name"].GetValue().Set(item.TargetArea.Name);
                field[i]["m_TargetArea"]["m_SerializedValue"].GetValue().Set(item.TargetArea.SerializedValue);
            }
        }

        private static void InsertReminderExtensionList(AssetTypeValueField field, IList<ReminderExtension> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ReminderStatus"]["Name"].GetValue().Set(item.ReminderStatus.Name);
                field[i]["m_ReminderStatus"]["m_SerializedValue"].GetValue().Set(item.ReminderStatus.SerializedValue);
            }
        }

        private static void InsertImprintResultExtensionList(AssetTypeValueField field, IList<ImprintResultExtension> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ImprintResultOperator"]["Name"].GetValue().Set(item.ImprintResultOperator.Name);
                field[i]["m_ImprintResultOperator"]["m_SerializedValue"].GetValue().Set(item.ImprintResultOperator.SerializedValue);
                field[i]["m_ImprintResult"]["Name"].GetValue().Set(item.ImprintResult.Name);
                field[i]["m_ImprintResult"]["m_SerializedValue"].GetValue().Set(item.ImprintResult.SerializedValue);
            }
        }

        private static void InsertAddCharacterList(AssetTypeValueField field, IList<AddCharacter> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_CalcOperator"]["Name"].GetValue().Set(item.CalcOperator.Name);
                field[i]["m_CalcOperator"]["m_SerializedValue"].GetValue().Set(item.CalcOperator.SerializedValue);
            }
        }

        private static void InsertScenarioResetList(AssetTypeValueField field, IList<ScenarioReset> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ResetItemGroup"]["m_FileID"].GetValue().Set(item.ResetItemGroup.FileID);
                field[i]["m_ResetItemGroup"]["m_PathID"].GetValue().Set(item.ResetItemGroup.PathID);
            }
        }

        private static void InsertScenarioEvent(AssetTypeValueField field, ScenarioEvent value)
        {
            field["m_Kind"]["Name"].GetValue().Set(value.Kind.Name);
            field["m_Kind"]["m_SerializedValue"].GetValue().Set(value.Kind.SerializedValue);
            field["m_Index"]["Name"].GetValue().Set(value.Index.Name);
            field["m_Index"]["m_SerializedValue"].GetValue().Set(value.Index.SerializedValue);
            field["m_ScenarioKindExtension"]["m_SerializeScenarioIndexKind"].GetValue().Set(value.ScenarioKindExtension.IndexKind);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_ScenarioCounterList"]["Array"], value.ScenarioKindExtension.ScenarioCounterList);
            InsertScenarioDoneList(field["m_ScenarioKindExtension"]["m_ScenarioDoneList"]["Array"], value.ScenarioKindExtension.ScenarioDoneList);
            InsertScenarioMapList(field["m_ScenarioKindExtension"]["m_ScenarioMapList"]["Array"], value.ScenarioKindExtension.ScenarioMapList);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_ScenarioBadgeList"]["Array"], value.ScenarioKindExtension.ScenarioBadgeList);
            InsertAreaChangeList(field["m_ScenarioKindExtension"]["m_AreaChangeList"]["Array"], value.ScenarioKindExtension.AreaChangeList);
            InsertScenarioShopList(field["m_ScenarioKindExtension"]["m_ShopList"]["Array"], value.ScenarioKindExtension.ShopList);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_StrugglePointList"]["Array"], value.ScenarioKindExtension.StrugglePointList);
            InsertStruggleBossList(field["m_ScenarioKindExtension"]["m_StruggleBossList"]["Array"], value.ScenarioKindExtension.StruggleBossList);
            InsertStruggleTeamMemberList(field["m_ScenarioKindExtension"]["m_StruggleTeamMemberList"]["Array"], value.ScenarioKindExtension.StruggleTeamMemberList);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_StruggleTeamAreaList"]["Array"], value.ScenarioKindExtension.StruggleTeamAreaList);
            InsertStruggleBossList(field["m_ScenarioKindExtension"]["m_StruggleAreaControllList"]["Array"], value.ScenarioKindExtension.StruggleAreaControllList);
            InsertAreaChangeList(field["m_ScenarioKindExtension"]["m_GroupAreaChangeList"]["Array"], value.ScenarioKindExtension.GroupAreaChangeList);
            InsertReminderExtensionList(field["m_ScenarioKindExtension"]["m_ReminderExtensionList"]["Array"], value.ScenarioKindExtension.ReminderExtensionList);
            InsertImprintResultExtensionList(field["m_ScenarioKindExtension"]["m_ImprintResultExtensionList"]["Array"], value.ScenarioKindExtension.ImprintResultExtensionList);
            InsertAddCharacterList(field["m_ScenarioKindExtension"]["m_AddCharacterList"]["Array"], value.ScenarioKindExtension.AddCharacterList);
            InsertScenarioResetList(field["m_ScenarioKindExtension"]["m_ScenarioResetList"]["Array"], value.ScenarioKindExtension.ScenarioResetList);
        }

        private static void InsertUnityFileList(AssetTypeValueField field, IList<UnityFile> value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_FileID"].GetValue().Set(item.FileID);
                field[i]["m_PathID"].GetValue().Set(item.PathID);
            }
        }

        private static void AdjustArrayLength<T>(AssetTypeValueField field, IList<T> value)
        {
            if (value.Count <= field.childrenCount) field.SetChildrenList(field.children.Take(value.Count).ToArray());
            else
            {
                List<AssetTypeValueField> extra = new List<AssetTypeValueField>();
                for (int i = field.childrenCount; i < value.Count; i++) extra.Add(ValueBuilder.DefaultValueFieldFromArrayTemplate(field));
                field.SetChildrenList(field.children.Concat(extra).ToArray());
            }
        }
    }
}
