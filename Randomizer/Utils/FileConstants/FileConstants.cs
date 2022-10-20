using NEO_TWEWY_Randomizer.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class FileConstants
    {
        public static Dictionary<string, DataBundle> Bundles { get; } = JsonConvert.DeserializeObject<Dictionary<string, DataBundle>>(Resources.bundle_constants);
        public static EnemyDuplicateList EnemyDataDuplicates { get; } = JsonConvert.DeserializeObject<EnemyDuplicateList>(Resources.enemy_sets);
        public static SettingsStringVersionList SettingsStringVersions { get; } = JsonConvert.DeserializeObject<SettingsStringVersionList>(Resources.settings_string_versions);
        public static ItemNames ItemNames { get; } = JsonConvert.DeserializeObject<ItemNames>(Resources.id_list);

        public static string TextAssetType { get; } = "text";
        public static string TextAssetAttributeKey { get; } = "m_Script";

        public static string ScenarioAssetType { get; } = "scenario";

        public static string QuotaAssetType { get; } = "quota";
        public static string BrandQuotaSubType { get; } = "brand";
        public static string ItemQuotaSubType { get; } = "item";
        public static string OwnPinQuotaSubType { get; } = "pin";
        public static string NoiseQuotaSubType { get; } = "noise";
        public static string BossNoiseQuotaSubType { get; } = "noise-boss";
        public static string RelationshipQuotaSubType { get; } = "relationship";
        public static string TrophyQuotaSubType { get; } = "trophy";
        public static string ReductionQuotaSubType { get; } = "reduction";
    }
}
