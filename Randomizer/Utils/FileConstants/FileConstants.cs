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
    }
}
