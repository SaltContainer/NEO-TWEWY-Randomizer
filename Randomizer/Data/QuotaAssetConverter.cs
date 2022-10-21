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
    class QuotaAssetConverter
    {
        public static JObject ConvertFromBaseField(AssetTypeValueField baseField, string subtype)
        {
            JObject jobject = MonoBehaviorConverter.ConvertFromBaseField(baseField);
            ((JObject)jobject[FileConstants.ScriptJObject]).Add("type", subtype);
            return jobject;
        }

        public static void InsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            baseField["m_GameObject"]["m_FileID"].GetValue().Set(newValue["m_GameObject"]["m_FileID"].Value<long>());
            baseField["m_GameObject"]["m_PathID"].GetValue().Set(newValue["m_GameObject"]["m_PathID"].Value<long>());

            baseField["m_Enabled"].GetValue().Set(newValue["m_Enabled"].Value<int>());

            baseField["m_Script"]["m_FileID"].GetValue().Set(newValue["m_Script"]["m_FileID"].Value<long>());
            baseField["m_Script"]["m_PathID"].GetValue().Set(newValue["m_Script"]["m_PathID"].Value<long>());

            baseField["m_Name"].GetValue().Set(newValue["m_Name"].Value<string>());

            string subtype = newValue["type"].Value<string>();

            if (subtype == FileConstants.BrandQuotaSubType) BrandQuotaInsertInBaseField(baseField, newValue);
            else if (subtype == FileConstants.ItemQuotaSubType) ItemQuotaInsertInBaseField(baseField, newValue);
            else if (subtype == FileConstants.OwnPinQuotaSubType) OwnBadgeQuotaInsertInBaseField(baseField, newValue);
            else if (subtype == FileConstants.NoiseQuotaSubType) NoiseQuotaInsertInBaseField(baseField, newValue);
            else if (subtype == FileConstants.BossNoiseQuotaSubType) BossNoiseQuotaInsertInBaseField(baseField, newValue);
            else if (subtype == FileConstants.RelationshipQuotaSubType) RelationshipQuotaInsertInBaseField(baseField, newValue);
            else if (subtype == FileConstants.TrophyQuotaSubType) TrophyQuotaInsertInBaseField(baseField, newValue);
            else ReductionQuotaInsertInBaseField(baseField, newValue);
        }

        private static void BrandQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            baseField["BrandID"].GetValue().Set(newValue["BrandID"].Value<int>());
            InsertIntList(baseField["EquipSlots"]["Array"], (JArray)newValue["EquipSlots"]);
            baseField["EvenOne"].GetValue().Set(newValue["EvenOne"].Value<int>());
        }

        private static void ItemQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            InsertIntList(baseField["BadgeID"]["Array"], (JArray)newValue["BadgeID"]);
            InsertCostumeList(baseField["m_CostumeList"]["Array"], (JArray)newValue["m_CostumeList"]);
        }

        private static void OwnBadgeQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            InsertBadgeList(baseField["m_BadgeList"]["Array"], (JArray)newValue["m_BadgeList"]);
        }

        private static void NoiseQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            InsertIntList(baseField["MapID"]["Array"], (JArray)newValue["MapID"]);
            InsertIntList(baseField["NoiseID"]["Array"], (JArray)newValue["NoiseID"]);
            baseField["Count"].GetValue().Set(newValue["Count"].Value<int>());
        }

        private static void BossNoiseQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            baseField["NoiseID"].GetValue().Set(newValue["NoiseID"].Value<int>());
            baseField["NoiseSymbolId"].GetValue().Set(newValue["NoiseSymbolId"].Value<int>());
            baseField["Count"].GetValue().Set(newValue["Count"].Value<int>());
            baseField["BattleScenarioID"].GetValue().Set(newValue["BattleScenarioID"].Value<int>());
        }

        private static void RelationshipQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            baseField["SkillTreeID"].GetValue().Set(newValue["SkillTreeID"].Value<int>());
            baseField["Status"].GetValue().Set(newValue["Status"].Value<int>());
        }

        private static void TrophyQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            baseField["TrophyType"].GetValue().Set(newValue["TrophyType"].Value<int>());
        }

        private static void ReductionQuotaInsertInBaseField(AssetTypeValueField baseField, JObject newValue)
        {
            InsertIntList(baseField["MapID"]["Array"], (JArray)newValue["MapID"]);
            baseField["Count"].GetValue().Set(newValue["Count"].Value<int>());
        }

        private static void InsertIntList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i].GetValue().Set(item.Value<int>());
            }
        }

        private static void InsertCostumeList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["CostumeID"].GetValue().Set(item["CostumeID"].Value<int>());
                field[i]["m_Value"].GetValue().Set(item["m_Value"].Value<int>());
            }
        }

        private static void InsertBadgeList(AssetTypeValueField field, JArray value)
        {
            AdjustArrayLength(field, value);
            for (int i = 0; i < value.Count; i++)
            {
                var item = value[i];

                field[i]["m_BadgeID"]["Name"].GetValue().Set(item["m_BadgeID"]["Name"].Value<string>());
                field[i]["m_BadgeID"]["m_SerializedValue"].GetValue().Set(item["m_BadgeID"]["m_SerializedValue"].Value<long>());
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
