using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ScenarioRewards
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mReward1st")]
        public int FirstReward { get; set; }
        [JsonProperty("mReward1stCount")]
        public int FirstRewardCount { get; set; }
        [JsonProperty("mReward2nd")]
        public int SecondReward { get; set; }
        [JsonProperty("mReward2ndCount")]
        public int SecondRewardCount { get; set; }
        [JsonProperty("mSaveIndex")]
        public int SaveIndex { get; set; }
    }
}
