using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class SettingsStringVersion
    {
        [JsonProperty("values")]
        public Dictionary<string, SettingsStringValue> Values { get; set; }
        [JsonProperty("version")]
        public uint Version { get; set; }
        [JsonProperty("character_count")]
        public uint CharacterCount { get; set; }
        [JsonProperty("changed_values")]
        public IList<string> ChangedValues { get; set; }
    }
}
