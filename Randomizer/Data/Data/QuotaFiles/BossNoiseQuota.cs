using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class BossNoiseQuota : Quota
    {
        [JsonProperty("NoiseID")]
        public int NoiseID { get; set; }
        [JsonProperty("NoiseSymbolId")]
        public int NoiseSymbolID { get; set; }
        [JsonProperty("Count")]
        public int Count { get; set; }
        [JsonProperty("BattleScenarioID")]
        public int BattleScenarioID { get; set; }
    }
}
