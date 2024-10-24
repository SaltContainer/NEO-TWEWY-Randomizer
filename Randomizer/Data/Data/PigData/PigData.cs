using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class PigData
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mGroupId")]
        public int GroupId { get; set; }
        [JsonProperty("mExp")]
        public int Exp { get; set; }
        [JsonProperty("mBp")]
        public int Bp { get; set; }
        [JsonProperty("mBattleTime")]
        public int BattleTime { get; set; }
        [JsonProperty("mDrop")]
        public int Drop { get; set; }
        [JsonProperty("mRankTimeTable")]
        public int RankTimeTable { get; set; }
        [JsonProperty("mColorReaderMinimum")]
        public int ColorReaderMinimum { get; set; }
        [JsonProperty("mColorReaderFluctuation")]
        public int ColorReaderFluctuation { get; set; }
        [JsonProperty("mColorExplosionDamageType")]
        public int ColorExplosionDamageType { get; set; }
        [JsonProperty("mDivisionTable")]
        public int DivisionTable { get; set; }
        [JsonProperty("mSametimeTable")]
        public int SametimeTable { get; set; }
        [JsonProperty("mWeakReaderMinimum")]
        public int WeakReaderMinimum { get; set; }
        [JsonProperty("mWeakReaderFluctuation")]
        public int WeakReaderFluctuation { get; set; }
        [JsonProperty("mGroupType")]
        public string GroupType { get; set; }
    }
}
