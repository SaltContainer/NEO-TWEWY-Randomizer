using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class Badge
    {
        [JsonProperty("mId")]
        public Label Id { get; set; }
        [JsonProperty("mItemId")]
        public AllItemsLabel ItemId { get; set; }
        [JsonProperty("mBrand")]
        public BrandLabel Brand { get; set; }
        [JsonProperty("mNameChance")]
        public string BeatdropName { get; set; }
        [JsonProperty("mInfoChance")]
        public string BeatdropDescription { get; set; }
        [JsonProperty("mPsychic")]
        public Psychic.Name Psychic { get; set; }
        [JsonProperty("mPsychicKey")]
        public PsychicKeysName Button { get; set; }
        [JsonProperty("mAttack")]
        public float Power { get; set; }
        [JsonProperty("mAddAttack")]
        public float PowerScaling { get; set; }
        [JsonProperty("mMaxValue")]
        public float Limit { get; set; }
        [JsonProperty("mAddMaxValue")]
        public float LimitScaling { get; set; }
        [JsonProperty("mHoldBasicCost")]
        public float HoldBasicCost { get; set; }
        [JsonProperty("mChargeTime")]
        public float Charge { get; set; }
        [JsonProperty("mComboCount")]
        public int ComboCount { get; set; }
        [JsonProperty("mRebootTime")]
        public float Reboot { get; set; }
        [JsonProperty("mRebootTimeDec")]
        public float RebootScaling { get; set; }
        [JsonProperty("mBootTime")]
        public float Boot { get; set; }
        [JsonProperty("mBootTimeDec")]
        public float BootScaling { get; set; }
        [JsonProperty("mAutoRecoverTime")]
        public float Recover { get; set; }
        [JsonProperty("mAutoRecoverTimeDec")]
        public float RecoverScaling { get; set; }
        [JsonProperty("mMaxLevel")]
        public int MaxLevel { get; set; }
        [JsonProperty("mLevelUpType")]
        public BadgeLvUpTypeLabel Growth { get; set; }
        [JsonProperty("mLevelUpRate")]
        public float GrowthRate { get; set; }
        [JsonProperty("mAbility")]
        public IList<AbilityAbility> Abilities { get; set; }
        [JsonProperty("mPairAbility")]
        public AbilityAbility EnsembleAbility { get; set; }
        [JsonProperty("mComboDamage")]
        public int ComboDamage { get; set; }
        [JsonProperty("mAddSellPrice")]
        public int SellPriceScaling { get; set; }
        [JsonProperty("mSellPrice")]
        public int SellPrice { get; set; }
        [JsonProperty("mRarity")]
        public BadgeRarityType Uber { get; set; }
        [JsonProperty("mSortIndex")]
        public int SortIndex { get; set; }
        [JsonProperty("mSortPsychic")]
        public int SortPsychic { get; set; }
        [JsonProperty("mBadgeSpriteName")]
        public string SpriteName { get; set; }
        [JsonProperty("mBadgeSpriteAtlas")]
        public string SpriteAtlas { get; set; }
        [JsonProperty("mBadgeClass")]
        public BadgeClassLabel PinClass { get; set; }
        [JsonProperty("mBadgeCategory")]
        public BadgeCategoryType PinCategory { get; set; }
        [JsonProperty("mPsychicType")]
        public BadgePsychicType PsychicType { get; set; }
        [JsonProperty("mEvolutionLevel")]
        public int EvolutionLevel { get; set; }
        [JsonProperty("mEcolutionCommon")]
        public Label EvolutionSingle { get; set; }
        [JsonProperty("mEvolutionBadge")]
        public IList<Label> EvolutionList { get; set; }
        [JsonProperty("mChancetimeType")]
        public BadgeChancetimeType BeatdropType { get; set; }
        [JsonProperty("mMashupElement")]
        public ElementType MashUpAffinity { get; set; }
        [JsonProperty("mInfoMovie")]
        public MovieLabel MovieId { get; set; }

        public enum Label : int
        {
            Psi_01_00_01_00 = 100,
            Psi_01_00_04_00 = 101,
            Psi_01_00_05_00 = 102,
            Psi_01_00_02_00 = 104,
            Psi_01_00_03_00 = 105,
            Psi_01_00_06_00 = 103,
            Psi_01_00_07_00 = 106,
            Psi_01_00_08_00 = 107,
            Psi_01_00_09_00 = 108,
            FpsSlash1 = 109,
            Psi_01_01_03_00 = 112,
            Psi_01_01_04_00 = 113,
            Psi_01_01_01_00 = 110,
            Psi_01_01_02_00 = 111,
            Psi_01_01_05_00 = 114,
            AirSlash = 115,
            Psi_01_02_01_00 = 116,
            Psi_01_02_02_00 = 117,
            Psi_01_02_03_00 = 118,
            Psi_02_00_00_00 = 200,
            Psi_02_00_01_00 = 201,
            Psi_02_00_02_00 = 202,
            Psi_02_00_03_00 = 203,
            Psi_02_00_04_00 = 204,
            Psi_02_00_05_00 = 205,
            Psi_02_00_06_00 = 206,
            Psi_02_00_07_00 = 207,
            Psi_02_00_08_00 = 208,
            Psi_02_01_00_00 = 209,
            Psi_02_01_01_00 = 210,
            Psi_02_01_02_00 = 211,
            Psi_02_01_03_00 = 212,
            Psi_03_00_00_00 = 300,
            Psi_03_00_01_00 = 301,
            Psi_03_00_02_00 = 302,
            Psi_03_00_03_00 = 303,
            Psi_03_00_04_00 = 304,
            Psi_03_01_00_00 = 305,
            Psi_03_01_01_00 = 306,
            Psi_03_01_02_00 = 307,
            Psi_03_01_03_00 = 308,
            Psi_03_01_04_00 = 309,
            Psi_03_02_00_00 = 310,
            Psi_03_02_01_00 = 311,
            Psi_03_02_02_00 = 312,
            Psi_03_02_03_00 = 313,
            Psi_03_02_04_00 = 314,
            ScreenTap1 = 400,
            Psi_04_00_01_00 = 401,
            Psi_04_00_02_00 = 402,
            Psi_04_00_03_00 = 403,
            Psi_04_00_04_00 = 404,
            IceTap1 = 405,
            Psi_04_00_06_00 = 406,
            Psi_04_00_07_00 = 407,
            Psi_04_00_08_00 = 408,
            Psi_04_00_09_00 = 409,
            Psi_04_00_10_00 = 410,
            Psi_04_01_00_00 = 411,
            Psi_04_01_01_00 = 412,
            Psi_04_01_02_00 = 413,
            Psi_04_01_03_00 = 414,
            Psi_04_01_04_00 = 415,
            Psi_04_01_05_00 = 416,
            Psi_04_01_06_00 = 417,
            Psi_04_02_00_00 = 418,
            Psi_04_02_01_00 = 419,
            Psi_04_02_02_00 = 420,
            Psi_04_02_03_00 = 421,
            Psi_04_02_04_00 = 422,
            Psi_04_02_05_00 = 423,
            Psi_04_02_06_00 = 424,
            Arrow = 500,
            Psi_05_00_01_00 = 501,
            Psi_05_00_02_00 = 502,
            Psi_05_00_03_00 = 503,
            Psi_05_00_04_00 = 504,
            Psi_05_00_05_00 = 505,
            Psi_05_00_06_00 = 506,
            Psi_05_00_07_00 = 507,
            Psi_04_01_07_00 = 425,
            LandBomb = 600,
            Psi_06_00_03_00 = 603,
            Psi_06_00_04_00 = 604,
            Psi_06_00_05_00 = 605,
            Psi_06_00_01_00 = 601,
            Psi_06_00_02_00 = 602,
            Psi_06_00_06_00 = 606,
            Psi_06_00_07_00 = 607,
            Psi_06_00_08_00 = 608,
            Psi_06_00_09_00 = 609,
            Psi_06_00_10_00 = 610,
            Psi_06_00_11_00 = 611,
            Psi_06_00_12_00 = 612,
            Psi_06_00_13_00 = 613,
            Psi_06_00_14_00 = 614,
            Psi_06_00_15_00 = 615,
            Psi_06_00_16_00 = 616,
            Psi_06_00_17_00 = 617,
            Dash = 700,
            Psi_07_00_01_00 = 701,
            Psi_07_00_02_00 = 702,
            Psi_07_00_03_00 = 703,
            Psi_07_00_04_00 = 704,
            Psi_07_00_05_00 = 705,
            Psi_07_00_06_00 = 706,
            Psi_08_00_00_00 = 800,
            Psi_08_00_01_00 = 801,
            Psi_08_00_02_00 = 802,
            Psi_08_00_03_00 = 803,
            Psi_08_00_04_00 = 804,
            Psi_08_00_05_00 = 805,
            Psi_08_00_06_00 = 806,
            Psi_25_00_00_00 = 2500,
            Psi_25_00_01_00 = 2501,
            Psi_25_00_02_00 = 2502,
            Psi_25_00_03_00 = 2503,
            Psi_25_00_04_00 = 2504,
            Psi_25_00_05_00 = 2505,
            Psi_25_00_06_00 = 2506,
            Psi_25_00_07_00 = 2507,
            BlowAway = 900,
            Psi_09_00_01_00 = 901,
            Psi_09_00_02_00 = 902,
            Psi_09_00_03_00 = 903,
            Psi_09_00_04_00 = 904,
            Psi_09_00_05_00 = 905,
            Psi_09_00_06_00 = 906,
            Psi_09_00_07_00 = 907,
            Psi_09_00_08_00 = 908,
            Psi_10_00_00_00 = 1000,
            Psi_10_00_01_00 = 1001,
            Psi_10_00_02_00 = 1002,
            Psi_10_00_03_00 = 1003,
            Psi_10_00_04_00 = 1004,
            Psi_10_00_05_00 = 1005,
            Psi_10_00_06_00 = 1006,
            Psi_10_01_00_00 = 1007,
            Psi_10_01_01_00 = 1008,
            Psi_10_01_02_00 = 1009,
            ChargeUpper = 1100,
            Psi_11_00_01_00 = 1101,
            Psi_11_00_02_00 = 1102,
            Psi_11_00_03_00 = 1103,
            Psi_11_00_04_00 = 1104,
            Psi_11_00_05_00 = 1105,
            Psi_11_00_06_00 = 1106,
            Psi_11_00_07_00 = 1107,
            Psi_11_00_08_00 = 1108,
            Napalm = 1200,
            Psi_12_00_01_00 = 1201,
            Psi_12_00_02_00 = 1202,
            Psi_12_00_03_00 = 1203,
            Psi_12_00_04_00 = 1204,
            Psi_12_00_05_00 = 1205,
            Psi_12_00_06_00 = 1206,
            Psi_12_00_07_00 = 1207,
            Psi_12_00_08_00 = 1208,
            Psi_17_00_04_00 = 1704,
            Psi_13_00_00_00 = 1300,
            Psi_13_00_01_00 = 1301,
            Psi_13_00_02_00 = 1302,
            Psi_13_00_03_00 = 1303,
            Psi_13_00_04_00 = 1304,
            Psi_13_00_05_00 = 1305,
            Psi_13_00_06_00 = 1306,
            Psi_13_00_07_00 = 1307,
            Psi_13_00_08_00 = 1308,
            Psi_13_00_09_00 = 1309,
            Psi_13_01_00_00 = 1310,
            Psi_13_01_01_00 = 1311,
            Psi_13_01_02_00 = 1312,
            Psi_13_01_03_00 = 1313,
            Psi_13_01_04_00 = 1314,
            Psi_14_00_00_00 = 1400,
            Psi_14_00_01_00 = 1401,
            Psi_14_00_02_00 = 1402,
            Psi_14_00_03_00 = 1403,
            Psi_14_00_04_00 = 1404,
            Psi_14_00_05_00 = 1405,
            Psi_14_00_06_00 = 1406,
            Psi_14_00_07_00 = 1407,
            Psi_15_01_00_00 = 1500,
            Psi_15_01_01_00 = 1501,
            Psi_15_01_02_00 = 1502,
            Psi_15_01_03_00 = 1503,
            Psi_15_01_04_00 = 1504,
            Psi_15_01_05_00 = 1505,
            Psi_15_01_06_00 = 1506,
            Psi_26_00_00_00 = 2600,
            Psi_26_00_01_00 = 2601,
            Psi_26_00_02_00 = 2602,
            Psi_26_00_03_00 = 2603,
            Psi_26_00_04_00 = 2604,
            Psi_26_00_05_00 = 2605,
            Psi_23_00_00_00 = 2300,
            Psi_23_00_08_00 = 2308,
            Psi_23_00_10_00 = 2310,
            Psi_23_00_11_00 = 2311,
            Psi_23_01_00_00 = 2312,
            Psi_23_01_01_00 = 2313,
            Psi_23_01_02_00 = 2314,
            Psi_23_01_03_00 = 2315,
            Psi_23_01_04_00 = 2316,
            Psi_23_01_06_00 = 2318,
            Psi_23_01_05_00 = 2317,
            Psi_17_00_00_00 = 1700,
            Psi_17_00_01_00 = 1701,
            Psi_17_00_02_00 = 1702,
            Psi_17_00_03_00 = 1703,
            Psi_17_00_05_00 = 1705,
            Psi_17_01_00_00 = 1710,
            Psi_17_01_01_00 = 1711,
            Psi_17_01_02_00 = 1712,
            Psi_17_01_03_00 = 1713,
            Psi_18_00_00_00 = 1800,
            Psi_18_00_01_00 = 1801,
            Psi_18_00_02_00 = 1802,
            Psi_18_00_03_00 = 1803,
            Psi_18_00_04_00 = 1804,
            Psi_18_00_05_00 = 1805,
            Psi_18_00_06_00 = 1806,
            Psi_18_00_07_00 = 1807,
            Psi_18_00_08_00 = 1808,
            Psi_18_00_09_00 = 1809,
            Psi_18_01_00_00 = 1810,
            Psi_19_00_04_00 = 1904,
            Psi_19_00_05_00 = 1905,
            Psi_19_00_06_00 = 1906,
            Psi_19_00_07_00 = 1907,
            Psi_19_00_08_00 = 1908,
            Psi_19_00_09_00 = 1909,
            Psi_19_01_04_00 = 1915,
            Psi_28_00_05_00 = 2805,
            Psi_28_00_06_00 = 2806,
            Psi_19_01_02_00 = 1913,
            Psi_19_01_03_00 = 1914,
            Psi_19_01_05_00 = 1916,
            Psi_19_00_02_00 = 1900,
            ChannelingFire = 1901,
            Psi_19_00_01_00 = 1902,
            Psi_19_00_03_00 = 1903,
            Psi_19_00_11_00 = 1910,
            Psi_20_00_00_00 = 2000,
            Psi_20_00_01_00 = 2001,
            Psi_20_00_02_00 = 2002,
            Psi_20_00_03_00 = 2003,
            Psi_20_00_04_00 = 2004,
            Psi_20_00_05_00 = 2005,
            Psi_19_01_00_00 = 1911,
            Psi_19_01_01_00 = 1912,
            Psi_28_00_00_00 = 2800,
            Psi_28_00_01_00 = 2801,
            Psi_28_00_02_00 = 2802,
            Psi_28_00_03_00 = 2803,
            Psi_28_00_04_00 = 2804,
            Psi_15_01_07_00 = 1507,
            Psi_15_01_08_00 = 1508,
            Psi_15_01_09_00 = 1509,
            Psi_15_01_10_00 = 1510,
            Psi_17_00_06_00 = 1706,
            Psi_17_00_07_00 = 1707,
            Psi_29_00_02_00 = 2902,
            Psi_29_00_03_00 = 2903,
            Psi_17_00_08_00 = 1708,
            Psi_17_00_09_00 = 1709,
            Psi_15_01_11_00 = 1511,
            Psi_24_00_04_00 = 2404,
            Psi_22_00_00_00 = 2200,
            Psi_22_00_01_00 = 2201,
            Psi_22_00_02_00 = 2202,
            Psi_22_00_03_00 = 2203,
            Psi_22_00_04_00 = 2204,
            Psi_22_00_05_00 = 2205,
            Psi_22_00_06_00 = 2206,
            Psi_22_00_07_00 = 2207,
            Psi_23_00_01_00 = 2301,
            Psi_23_00_02_00 = 2302,
            Psi_23_00_09_00 = 2309,
            Psi_23_00_03_00 = 2303,
            Psi_23_00_04_00 = 2304,
            Psi_23_00_05_00 = 2305,
            Psi_23_00_07_00 = 2307,
            Psi_23_00_06_00 = 2306,
            Psi_24_00_00_00 = 2400,
            Psi_24_00_01_00 = 2401,
            Psi_24_00_02_00 = 2402,
            Psi_24_00_03_00 = 2403,
            Psi_29_00_00_00 = 2900,
            Psi_29_00_01_00 = 2901,
            Psi_29_00_04_00 = 2904,
            Psi_03_00_05_00 = 3002,
            Psi_04_02_07_00 = 3003,
            Psi_10_00_07_00 = 3004,
            Psi_11_00_09_00 = 3005,
            Psi_17_00_10_00 = 3006,
            Psi_19_00_13_00 = 3007,
            Psi_01_01_06_00 = 3008,
            Psi_04_00_11_00 = 3009,
            Psi_09_00_09_00 = 3010,
            Psi_26_00_06_00 = 3011,
            Psi_02_00_09_00 = 3012,
            Psi_29_00_05_00 = 3013,
            Psi_01_02_04_00 = 3014,
            Psi_08_00_07_00 = 3015,
            Psi_14_00_08_00 = 3016,
            Psi_01_03_00_00 = 3000,
            Psi_01_03_01_00 = 3001,
            Psi_29_00_06_00 = 3017,
            Psi_17_01_04_00 = 3018,
            Psi_29_00_07_00 = 3019,
            Psi_24_00_05_00 = 3020,
            bad_99_00_00 = 5000,
            bad_99_00_01 = 5001,
            bad_99_00_02 = 5002,
            bad_99_00_03 = 5003,
            bad_99_00_04 = 5004,
            bad_99_00_05 = 5005,
            bad_99_00_06 = 5006,
            bad_99_00_07 = 5007,
            bad_99_00_08 = 5008,
            bad_99_00_09 = 5009,
            bad_99_01_00 = 5100,
            bad_99_01_01 = 5101,
            bad_99_01_02 = 5102,
            bad_99_01_03 = 5103,
            bad_99_01_04 = 5104,
            bad_99_01_05 = 5105,
            bad_99_01_06 = 5106,
            bad_99_01_07 = 5107,
            bad_99_01_08 = 5108,
            bad_99_01_09 = 5109,
            bad_99_01_10 = 5110,
            Invalid = -1,
        }
    }
}
