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

        public const string TextDataBundleKey = "text-data";
        public const string W1D2ScenarioBundleKey = "w1d2-scenario";
        public const string W2D5ScenarioBundleKey = "w2d5-scenario";

        public const string EnemyDataClassName = "EnemyData";
        public const string EnemyReportClassName = "EnemyReport";
        public const string PigDataClassName = "PigData";
        public const string BadgeClassName = "Badge";
        public const string PsychicClassName = "Psychic";
        public const string AttackComboSetClassName = "AttackComboSet";
        public const string AttackClassName = "Attack";
        public const string AttackHitClassName = "AttackHit";
        public const string ScenarioRewardsClassName = "ScenarioRewards";
    }
}
