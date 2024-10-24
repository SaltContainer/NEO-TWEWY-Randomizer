using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class DataClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
    }
}
