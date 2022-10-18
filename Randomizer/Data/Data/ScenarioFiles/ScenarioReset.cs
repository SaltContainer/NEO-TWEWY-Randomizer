using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ScenarioReset
    {
        [JsonProperty("m_ResetItemGroup")]
        public UnityFile ResetItemGroup { get; set; }
    }
}
