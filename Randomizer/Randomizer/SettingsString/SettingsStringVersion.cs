using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class SettingsStringVersion
    {
        [JsonProperty("values")]
        public Dictionary<string, SettingsStringValue> Values { get; set; }
        [JsonProperty("version")]
        public uint Version { get; set; }
        [JsonProperty("changed_values")]
        public IList<string> ChangedValues { get; set; }
    }
}
