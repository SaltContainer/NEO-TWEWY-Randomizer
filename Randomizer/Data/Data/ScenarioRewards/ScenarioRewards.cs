using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioRewards
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
