using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ScenarioEvent
    {
        [JsonProperty("m_Kind")]
        public SerializedString Kind { get; set; }
        [JsonProperty("m_Index")]
        public SerializedString Index { get; set; }
        [JsonProperty("m_ScenarioKindExtension")]
        public ScenarioKindExtension ScenarioKindExtension { get; set; }
        [JsonProperty("m_Inverse")]
        public int Inverse { get; set; }
    }
}
