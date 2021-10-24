﻿using NEO_TWEWY_Randomizer.Properties;
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
        public static string TextDataBundleKey { get; } = "text-data";
        public static string EnemyDataClassName { get; } = "EnemyData";
    }
}
