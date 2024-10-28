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

        public const string EnemyDataAssetName = "EnemyData";
        public const string EnemyReportAssetName = "EnemyReport";
        public const string PigDataAssetName = "PigData";
        public const string BadgeAssetName = "Badge";
        public const string PsychicAssetName = "Psychic";
        public const string AttackComboSetAssetName = "AttackComboSet";
        public const string AttackAssetName = "Attack";
        public const string AttackHitAssetName = "AttackHit";
        public const string ScenarioRewardsAssetName = "ScenarioRewards";
        public const string SkillAssetName = "Skill";
        public const string SkillTreeAssetName = "SkillTree";

        public const string W1D2PinMissionAssetName = "story_w1d2_01_050_mission";
        public const string W2D5PinMissionAssetName = "story_w2d5_01_066_mission";
    }
}
