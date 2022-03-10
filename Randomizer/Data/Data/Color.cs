using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class Color
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
