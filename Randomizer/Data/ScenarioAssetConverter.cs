using AssetsTools.NET;
using AssetsTools.NET.Extra;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class ScenarioAssetConverter
    {
        public static JObject ConvertFromBaseField(AssetTypeValueField baseField)
        {
            return MonoBehaviorConverter.ConvertFromBaseField(baseField);
        }

        public static void InsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            baseField["m_GameObject"]["m_FileID"].GetValue().Set(newValue["m_GameObject"]["m_FileID"].Value<long>());
            baseField["m_GameObject"]["m_PathID"].GetValue().Set(newValue["m_GameObject"]["m_PathID"].Value<long>());

            baseField["m_Enabled"].GetValue().Set(newValue["m_Enabled"].Value<int>());

            baseField["m_Script"]["m_FileID"].GetValue().Set(newValue["m_Script"]["m_FileID"].Value<long>());
            baseField["m_Script"]["m_PathID"].GetValue().Set(newValue["m_Script"]["m_PathID"].Value<long>());

            baseField["m_Name"].GetValue().Set(newValue["m_Name"].Value<string>());

            InsertAssetList(baseField["m_List"]["Array"], (JArray)newValue["m_List"]);

            baseField["m_BootTiming"]["Name"].GetValue().Set(newValue["m_BootTiming"]["Name"].Value<string>());
            baseField["m_BootTiming"]["m_SerializedValue"].GetValue().Set(newValue["m_BootTiming"]["m_SerializedValue"].Value<long>());

            baseField["m_Generation"]["m_Logic"]["Name"].GetValue().Set(newValue["m_Generation"]["m_Logic"]["Name"].Value<string>());
            baseField["m_Generation"]["m_Logic"]["m_SerializedValue"].GetValue().Set(newValue["m_Generation"]["m_Logic"]["m_SerializedValue"].Value<long>());
            baseField["m_Generation"]["m_Inverse"].GetValue().Set(newValue["m_Generation"]["m_Inverse"].Value<long>());
            InsertScenarioEventList(baseField["m_Generation"]["m_List"]["Array"], (JArray)newValue["m_Generation"]["m_List"]);

            InsertScenarioEventList(baseField["m_Preparation"]["Array"], (JArray)newValue["m_Preparation"]);

            baseField["m_Ready"]["m_Logic"]["Name"].GetValue().Set(newValue["m_Ready"]["m_Logic"]["Name"].Value<string>());
            baseField["m_Ready"]["m_Logic"]["m_SerializedValue"].GetValue().Set(newValue["m_Ready"]["m_Logic"]["m_SerializedValue"].Value<long>());
            baseField["m_Ready"]["m_Inverse"].GetValue().Set(newValue["m_Ready"]["m_Logic"].Value<long>());
            InsertScenarioEventList(baseField["m_Ready"]["m_List"]["Array"], (JArray)newValue["m_Ready"]["m_List"]);

            baseField["m_Done"]["m_Logic"]["Name"].GetValue().Set(newValue["m_Done"]["m_Logic"]["Name"].Value<string>());
            baseField["m_Done"]["m_Logic"]["m_SerializedValue"].GetValue().Set(newValue["m_Done"]["m_Logic"]["m_SerializedValue"].Value<long>());
            baseField["m_Done"]["m_Inverse"].GetValue().Set(newValue["m_Done"]["m_Inverse"].Value<long>());
            InsertScenarioEventList(baseField["m_Done"]["m_List"]["Array"], (JArray)newValue["m_Done"]["m_List"]);

            InsertScenarioEventList(baseField["m_Result"]["Array"], (JArray)newValue["m_Result"]);

            InsertUnityFileList(baseField["m_NextList"]["Array"], (JArray)newValue["m_NextList"]);

            InsertUnityFileList(baseField["m_ReplayBootList"]["Array"], (JArray)newValue["m_ReplayBootList"]);

            baseField["m_ReplayDone"]["m_Logic"]["Name"].GetValue().Set(newValue["m_ReplayDone"]["m_Logic"]["Name"].Value<string>());
            baseField["m_ReplayDone"]["m_Logic"]["m_SerializedValue"].GetValue().Set(newValue["m_ReplayDone"]["m_Logic"]["m_SerializedValue"].Value<long>());
            baseField["m_ReplayDone"]["m_Inverse"].GetValue().Set(newValue["m_ReplayDone"]["m_Inverse"].Value<long>());
            InsertScenarioEventList(baseField["m_ReplayDone"]["m_List"]["Array"], (JArray)newValue["m_ReplayDone"]["m_List"]);

            InsertUnityFileList(baseField["m_StruggleList"]["Array"], (JArray)newValue["m_StruggleList"]);

            baseField["m_Permanent"].GetValue().Set(newValue["m_Permanent"].Value<int>());

            baseField["m_DoneNextStatus"].GetValue().Set(newValue["m_DoneNextStatus"].Value<int>());

            baseField["m_DisablePermanentConditions"]["m_Logic"]["Name"].GetValue().Set(newValue["m_DisablePermanentConditions"]["m_Logic"]["Name"].Value<string>());
            baseField["m_DisablePermanentConditions"]["m_Logic"]["m_SerializedValue"].GetValue().Set(newValue["m_DisablePermanentConditions"]["m_Logic"]["m_SerializedValue"].Value<long>());
            baseField["m_DisablePermanentConditions"]["m_Inverse"].GetValue().Set(newValue["m_DisablePermanentConditions"]["m_Inverse"].Value<long>());
            InsertScenarioEventList(baseField["m_DisablePermanentConditions"]["m_List"]["Array"], (JArray)newValue["m_DisablePermanentConditions"]["m_List"]);

            baseField["m_IsDoneNextImmediate"].GetValue().Set(newValue["m_IsDoneNextImmediate"].Value<int>());

            baseField["m_IsBootTimingCheckField"].GetValue().Set(newValue["m_IsBootTimingCheckField"].Value<int>());

            InsertUnityFileList(baseField["m_MarkerList"]["Array"], (JArray)newValue["m_MarkerList"]);

            baseField["m_DayEndScenario"].GetValue().Set(newValue["m_DayEndScenario"].Value<int>());

            baseField["m_EventID"].GetValue().Set(newValue["m_EventID"].Value<long>());
        }

        private static void InsertAssetList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_GUID"].GetValue().Set(item["m_GUID"].Value<string>());
                field[i]["m_AssetPath"].GetValue().Set(item["m_AssetPath"].Value<string>());
                field[i]["m_AssetBundleFilePath"].GetValue().Set(item["m_AssetBundleFilePath"].Value<string>());
                field[i]["m_AssetBundleName"].GetValue().Set(item["m_AssetBundleName"].Value<string>());
                field[i]["m_ObjectName"].GetValue().Set(item["m_ObjectName"].Value<string>());
                field[i]["m_TransformPath"].GetValue().Set(item["m_TransformPath"].Value<string>());
                field[i]["m_IsImmediateRelease"].GetValue().Set(item["m_IsImmediateRelease"].Value<int>());
            }
        }

        private static void InsertScenarioEventList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                InsertScenarioEvent(field[i], (JObject)value[i]);
            }
        }

        private static void InsertScenarioCounterList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_CalcOperator"]["Name"].GetValue().Set(item["m_CalcOperator"]["Name"].Value<string>());
                field[i]["m_CalcOperator"]["m_SerializedValue"].GetValue().Set(item["m_CalcOperator"]["m_SerializedValue"].Value<long>());
                field[i]["m_ComparisonValue"].GetValue().Set(item["m_ComparisonValue"].Value<int>());
            }
        }

        private static void InsertScenarioDoneList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_DoneItemGroup"]["m_FileID"].GetValue().Set(item["m_DoneItemGroup"]["m_FileID"].Value<long>());
                field[i]["m_DoneItemGroup"]["m_PathID"].GetValue().Set(item["m_DoneItemGroup"]["m_PathID"].Value<long>());
            }
        }

        private static void InsertScenarioMapList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_PositionTag"].GetValue().Set(item["m_PositionTag"].Value<string>());
            }
        }

        private static void InsertAreaChangeList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_AreaChangeStatus"]["Name"].GetValue().Set(item["m_AreaChangeStatus"]["Name"].Value<string>());
                field[i]["m_AreaChangeStatus"]["m_SerializedValue"].GetValue().Set(item["m_AreaChangeStatus"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertScenarioShopList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ShopStatus"]["Name"].GetValue().Set(item["m_ShopStatus"]["Name"].Value<string>());
                field[i]["m_ShopStatus"]["m_SerializedValue"].GetValue().Set(item["m_ShopStatus"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertStruggleBossList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_TeamType"]["Name"].GetValue().Set(item["m_TeamType"]["Name"].Value<string>());
                field[i]["m_TeamType"]["m_SerializedValue"].GetValue().Set(item["m_TeamType"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertStruggleTeamMemberList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_TeamMember"]["Name"].GetValue().Set(item["m_TeamMember"]["Name"].Value<string>());
                field[i]["m_TeamMember"]["m_SerializedValue"].GetValue().Set(item["m_TeamMember"]["m_SerializedValue"].Value<long>());
                field[i]["m_TargetArea"]["Name"].GetValue().Set(item["m_TargetArea"]["Name"].Value<string>());
                field[i]["m_TargetArea"]["m_SerializedValue"].GetValue().Set(item["m_TargetArea"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertReminderExtensionList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ReminderStatus"]["Name"].GetValue().Set(item["m_ReminderStatus"]["Name"].Value<string>());
                field[i]["m_ReminderStatus"]["m_SerializedValue"].GetValue().Set(item["m_ReminderStatus"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertImprintResultExtensionList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ImprintResultOperator"]["Name"].GetValue().Set(item["m_ImprintResultOperator"]["Name"].Value<string>());
                field[i]["m_ImprintResultOperator"]["m_SerializedValue"].GetValue().Set(item["m_ImprintResultOperator"]["m_SerializedValue"].Value<long>());
                field[i]["m_ImprintResult"]["Name"].GetValue().Set(item["m_ImprintResult"]["Name"].Value<string>());
                field[i]["m_ImprintResult"]["m_SerializedValue"].GetValue().Set(item["m_ImprintResult"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertAddCharacterList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_CalcOperator"]["Name"].GetValue().Set(item["m_CalcOperator"]["Name"].Value<string>());
                field[i]["m_CalcOperator"]["m_SerializedValue"].GetValue().Set(item["m_CalcOperator"]["m_SerializedValue"].Value<long>());
            }
        }

        private static void InsertScenarioResetList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_ResetItemGroup"]["m_FileID"].GetValue().Set(item["m_ResetItemGroup"]["m_FileID"].Value<long>());
                field[i]["m_ResetItemGroup"]["m_PathID"].GetValue().Set(item["m_ResetItemGroup"]["m_PathID"].Value<long>());
            }
        }

        private static void InsertScenarioEvent(AssetTypeValueField field, JObject value)
        {
            field["m_Kind"]["Name"].GetValue().Set(value["m_Kind"]["Name"].Value<string>());
            field["m_Kind"]["m_SerializedValue"].GetValue().Set(value["m_Kind"]["m_SerializedValue"].Value<long>());
            field["m_Index"]["Name"].GetValue().Set(value["m_Index"]["Name"].Value<string>());
            field["m_Index"]["m_SerializedValue"].GetValue().Set(value["m_Index"]["m_SerializedValue"].Value<long>());
            field["m_ScenarioKindExtension"]["m_SerializeScenarioIndexKind"].GetValue().Set(value["m_ScenarioKindExtension"]["m_SerializeScenarioIndexKind"].Value<long>());
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_ScenarioCounterList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ScenarioCounterList"]);
            InsertScenarioDoneList(field["m_ScenarioKindExtension"]["m_ScenarioDoneList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ScenarioDoneList"]);
            InsertScenarioMapList(field["m_ScenarioKindExtension"]["m_ScenarioMapList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ScenarioMapList"]);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_ScenarioBadgeList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ScenarioBadgeList"]);
            InsertAreaChangeList(field["m_ScenarioKindExtension"]["m_AreaChangeList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_AreaChangeList"]);
            InsertScenarioShopList(field["m_ScenarioKindExtension"]["m_ShopList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ShopList"]);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_StrugglePointList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_StrugglePointList"]);
            InsertStruggleBossList(field["m_ScenarioKindExtension"]["m_StruggleBossList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_StruggleBossList"]);
            InsertStruggleTeamMemberList(field["m_ScenarioKindExtension"]["m_StruggleTeamMemberList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_StruggleTeamMemberList"]);
            InsertScenarioCounterList(field["m_ScenarioKindExtension"]["m_StruggleTeamAreaList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_StruggleTeamAreaList"]);
            InsertStruggleBossList(field["m_ScenarioKindExtension"]["m_StruggleAreaControllList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_StruggleAreaControllList"]);
            InsertAreaChangeList(field["m_ScenarioKindExtension"]["m_GroupAreaChangeList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_GroupAreaChangeList"]);
            InsertReminderExtensionList(field["m_ScenarioKindExtension"]["m_ReminderExtensionList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ReminderExtensionList"]);
            InsertImprintResultExtensionList(field["m_ScenarioKindExtension"]["m_ImprintResultExtensionList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ImprintResultExtensionList"]);
            InsertAddCharacterList(field["m_ScenarioKindExtension"]["m_AddCharacterList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_AddCharacterList"]);
            InsertScenarioResetList(field["m_ScenarioKindExtension"]["m_ScenarioResetList"]["Array"], (JArray)value["m_ScenarioKindExtension"]["m_ScenarioResetList"]);
        }

        private static void InsertUnityFileList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_FileID"].GetValue().Set(item["m_FileID"].Value<long>());
                field[i]["m_PathID"].GetValue().Set(item["m_PathID"].Value<long>());
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
