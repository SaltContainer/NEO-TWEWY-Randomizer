using NEO_TWEWY_Randomizer.Properties;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public static class FileConstants
    {
        public static Dictionary<string, DataBundle> Bundles { get; } = JsonConvert.DeserializeObject<Dictionary<string, DataBundle>>(Resources.bundle_constants);
        public static EnemyDuplicateList EnemyDataDuplicates { get; } = JsonConvert.DeserializeObject<EnemyDuplicateList>(Resources.enemy_sets);
        public static SettingsStringVersionList SettingsStringVersions { get; } = JsonConvert.DeserializeObject<SettingsStringVersionList>(Resources.settings_string_versions);
        public static ItemNames ItemNames { get; } = JsonConvert.DeserializeObject<ItemNames>(Resources.id_list);
        public static string TextDataBundleKey { get; } = "text-data";
        public static string EnemyDataClassName { get; } = "EnemyData";
        public static string EnemyReportClassName { get; } = "EnemyReport";
        public static string PigDataClassName { get; } = "PigData";
        public static string BadgeClassName { get; } = "Badge";
        public static string PsychicClassName { get; } = "Psychic";
        public static string AttackComboSetClassName { get; } = "AttackComboSet";
        public static string AttackClassName { get; } = "Attack";
        public static string AttackHitClassName { get; } = "AttackHit";
        public static string ScenarioRewardsClassName { get; } = "ScenarioRewards";
    }
}
