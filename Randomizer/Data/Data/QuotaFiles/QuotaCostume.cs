using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class QuotaCostume
    {
        [JsonProperty("CostumeID")]
        public int CostumeID { get; set; }
        [JsonProperty("m_Value")]
        public int Value { get; set; }
    }
}
