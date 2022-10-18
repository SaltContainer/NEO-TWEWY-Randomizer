using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ScenarioCounter
    {
        [JsonProperty("m_CalcOperator")]
        public SerializedString CalcOperator { get; set; }
        [JsonProperty("m_ComparisonValue")]
        public int ComparisonValue { get; set; }
    }
}
