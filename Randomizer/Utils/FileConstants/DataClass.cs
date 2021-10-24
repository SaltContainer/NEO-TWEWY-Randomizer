using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class DataClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
    }
}
