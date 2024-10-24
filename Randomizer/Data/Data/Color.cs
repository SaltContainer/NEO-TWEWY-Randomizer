using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class Color
    {
        [JsonProperty("r")]
        public float R { get; set; }
        [JsonProperty("g")]
        public float G { get; set; }
        [JsonProperty("b")]
        public float B { get; set; }
        [JsonProperty("a")]
        public float A { get; set; }
    }
}
