using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioRewardsList
    {
        [JsonProperty("mTarget")]
        public IList<ScenarioRewards> Items { get; set; }
    }
}
