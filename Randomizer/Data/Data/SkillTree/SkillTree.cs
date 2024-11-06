using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class SkillTree
    {
        [JsonProperty("mId")]
        public Label Id { get; set; }
        [JsonProperty("mCharaName")]
        public string CharaName { get; set; }
        [JsonProperty("mCharaInfo")]
        public IList<string> CharaInfo { get; set; }
        [JsonProperty("mInfoUpdateIfConnect")]
        public bool InfoUpdateIfConnect { get; set; }
        [JsonProperty("mInfoUpdateScenario")]
        public ScenarioName InfoUpdateScenario { get; set; }
        [JsonProperty("mDayText")]
        public string DayText { get; set; }
        [JsonProperty("mPlaceText")]
        public string PlaceText { get; set; }
        [JsonProperty("mShop")]
        public ShopLabel Shop { get; set; }
        [JsonProperty("mReleaseValue")]
        public int ReleaseValue { get; set; }
        [JsonProperty("mBoard")]
        public AllBoardLabel Board { get; set; }
        [JsonProperty("mSkill")]
        public Skill.Label Skill { get; set; }
        [JsonProperty("mCharaIcon")]
        public IList<string> CharaIcon { get; set; }
        [JsonProperty("mEntryDay")]
        public DayInfoLabel EntryDay { get; set; }
        [JsonProperty("mConnectDay")]
        public DayInfoLabel ConnectDay { get; set; }
        [JsonProperty("mParent")]
        public Label Parent { get; set; }
        [JsonProperty("mSaveIndex")]
        public int SaveIndex { get; set; }

        public enum Label : int
        {
            SPH_m001 = 0,
            SPH_m002 = 1,
            SPH_m002sub = 2,
            SPH_m003 = 3,
            SPH_m004 = 4,
            SPH_m005 = 5,
            SPH_m006 = 6,
            SPH_m007 = 7,
            SPH_m008 = 8,
            SPH_m009 = 9,
            SPH_m010 = 10,
            SPH_m011 = 11,
            SPH_m012 = 12,
            SPH_m013 = 13,
            SPH_m014 = 14,
            SPH_m015 = 15,
            SPH_m016 = 16,
            SPH_m017 = 17,
            SPH_m018 = 18,
            SPH_m019 = 19,
            SPH_m020 = 20,
            SPH_m021 = 21,
            SPH_m022 = 22,
            SPH_m023 = 23,
            SPH_m024 = 24,
            SPH_m025 = 25,
            SPH_m026 = 26,
            SPH_m027 = 27,
            SPH_m028 = 28,
            SPH_m029 = 29,
            SPH_m030 = 30,
            SPH_m031 = 31,
            SPH_m032 = 32,
            SPH_m033 = 33,
            SPH_m034 = 34,
            SPH_m035 = 35,
            SPH_m036 = 36,
            SPH_m037 = 37,
            SPH_m038 = 38,
            SPH_m039 = 39,
            SPH_m040 = 40,
            SPH_m041 = 41,
            SPH_m042 = 42,
            SPH_m043 = 43,
            SPH_m044 = 44,
            SPH_m045 = 45,
            SPH_m046 = 46,
            SPH_m047 = 47,
            SPH_m048 = 48,
            SPH_m049 = 49,
            SPH_m050 = 50,
            SPH_m051 = 51,
            SPH_m052 = 52,
            SPH_m053 = 53,
            SPH_m054 = 54,
            SPH_m055 = 55,
            SPH_m056 = 56,
            SPH_m057 = 57,
            SPH_m058 = 58,
            SPH_m059 = 59,
            SPH_m060 = 60,
            SPH_m061 = 61,
            SPH_m062 = 62,
            SPH_m063 = 63,
            SPH_m064 = 64,
            SPH_m065 = 65,
            SPH_m066 = 66,
            SPH_m067 = 67,
            SPH_m068 = 68,
            SPH_m069 = 69,
            SPH_m070 = 70,
            SPH_m071 = 71,
            SPH_m072 = 72,
            SPH_m073 = 73,
            SPH_m074 = 74,
            SPH_m075 = 75,
            SPH_m076 = 76,
            SPH_m077 = 77,
            SPH_m078 = 78,
            SPH_m079 = 79,
            SPH_m080 = 80,
            SPH_m081 = 81,
            SPH_m082 = 82,
            SPH_m083 = 83,
            SPH_m084 = 84,
            SPH_m085 = 85,
            SPH_m086 = 86,
            SPH_m087 = 87,
            SPH_m088 = 88,
            SPH_m089 = 89,
            SPH_m090 = 90,
            SPH_m091 = 91,
            SPH_m092 = 92,
            SPH_m093 = 93,
            SPH_m094 = 94,
            SPH_m095 = 95,
            SPH_m096 = 96,
            SPH_m097 = 97,
            SPH_m098 = 98,
            SPH_m099 = 99,
            SPH_m100 = 100,
            SPH_m101 = 101,
            SPH_m102 = 102,
            SPH_m103 = 103,
            SPH_m104 = 104,
            SPH_m105 = 105,
            SPH_m106 = 106,
            SPH_m107 = 107,
            SPH_m108 = 108,
            SPH_m109 = 109,
            SPH_m110 = 110,
            Invalid = -1,
        }
    }
}
