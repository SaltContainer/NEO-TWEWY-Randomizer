using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class SettingsStringValue
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
