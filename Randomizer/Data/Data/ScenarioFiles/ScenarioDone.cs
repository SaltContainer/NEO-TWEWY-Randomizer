using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ScenarioDone
    {
        [JsonProperty("m_DoneItemGroup")]
        public UnityFile DoneItemGroup { get; set; }
    }
}
