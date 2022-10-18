using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class LogicalScenarioEvent
    {
        [JsonProperty("m_Logic")]
        public SerializedString Logic { get; set; }
        [JsonProperty("m_Inverse")]
        public long Inverse { get; set; }
        [JsonProperty("m_List")]
        public IList<ScenarioEvent> List { get; set; }
    }
}
