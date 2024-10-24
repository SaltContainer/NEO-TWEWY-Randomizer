using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class SettingsStringValue
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
