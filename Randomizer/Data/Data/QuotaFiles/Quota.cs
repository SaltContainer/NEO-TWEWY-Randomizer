using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    abstract class Quota
    {
        [JsonProperty("type")]
        public string QuotaType { get; set; }
        [JsonProperty("m_GameObject")]
        public UnityFile GameObject { get; set; }
        [JsonProperty("m_Enabled")]
        public int Enabled { get; set; }
        [JsonProperty("m_Script")]
        public UnityFile Script { get; set; }
        [JsonProperty("m_Name")]
        public string Name { get; set; }
    }
}
