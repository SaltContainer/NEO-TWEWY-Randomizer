using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class SerializedString
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("m_SerializedValue")]
        public long SerializedValue { get; set; }
    }
}
