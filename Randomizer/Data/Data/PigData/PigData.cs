using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class PigData
    {
        [JsonProperty("mId")]
        public Label Id { get; set; }
        [JsonProperty("mGroupId")]
        public GroupDataName GroupId { get; set; }
        [JsonProperty("mExp")]
        public uint Exp { get; set; }
        [JsonProperty("mBp")]
        public uint Bp { get; set; }
        [JsonProperty("mBattleTime")]
        public float BattleTime { get; set; }
        [JsonProperty("mDrop")]
        public Badge.Label Drop { get; set; }
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

        public enum Label : int
        {
            PigDataDefault = 999,
            n1w2d_dgen000_PIG00 = 1203100,
            n1w2d_dgen000_PIG01 = 1203900,
            n1w3d_s104000_PIG00 = 1302900,
            n1w3d_cent000_PIG00 = 1302101,
            n1w3d_cent000_PIG01 = 1303900,
            n1w4d_scra000_PIG00 = 1402101,
            n1w4d_cado000_PIG00 = 1404900,
            n1w4d_east000_PIG00 = 1408900,
            n1w5d_chdr000_06 = 150106,
            n1w5d_cent000_06 = 150206,
            n1w5d_spin000_06 = 150306,
            n1w5d_spin000_07 = 150307,
            n1w5d_scra000_06 = 150906,
            n1w5d_scra000_07 = 150907,
            n1w5d_scra000_Ev02 = 1509102,
            n1w6d_spin000_PIG00 = 1605900,
            n1w6d_cent000_PIG00 = 1606900,
            n1w6d_udgw000_PIG00 = 1608900,
            n1w7d_spin000_PIG00 = 1702900,
            n1w7d_dgen000_PIG00 = 1708900,
            n2w1d_take000_PIG00 = 2101900,
            n2w1d_hara000_PIG00 = 2102900,
            n2w2d_cado000_PIG00 = 2204900,
            n2w2d_cats000_PIG00 = 2205900,
            n2w3d_cado000_PIG00 = 2302900,
            n2w3d_scra000_PIG00 = 2303900,
            n2w4d_west000_PIG00 = 2402900,
            n2w4d_chdr000_PIG00 = 2407900,
            n2w5d_hodo000_PIG00 = 2503900,
            n2w5d_udgw000_PIG00 = 2510900,
            n2w6d_spin000_PIG00 = 2602900,
            n2w6d_east000_PIG00 = 2605900,
            n2w7d_cats000_PIG00 = 2707900,
            n2w7d_strm000_PIG00 = 2715900,
            n3w1d_cats000_PIG00 = 3107900,
            n3w1d_cent000_PIG00 = 3110900,
            n3w2d_east000_PIG00 = 3211900,
            n3w2d_west000_PIG00 = 3213900,
            n3w3d_dgen000_PIG00 = 3302900,
            n3w3d_cent000_PIG00 = 3305900,
            n3w4d_s104000_PIG00 = 3401900,
            n3w4d_miya000_PIG00 = 3402900,
            n3w5d_cado000_PIG00 = 3501900,
            n3w5d_hodo000_PIG00 = 3504900,
            n3w5d_hara000_PIG00 = 3517900,
            n3w6d_chdr000_PIG00 = 3601900,
            n3w6d_cado000_PIG00 = 3608900,
            n3w7d_take000_PIG00 = 3702900,
            n3w7d_strm000_PIG00 = 3716900,
            n4w1d_s104000_PIG00 = 4105900,
            n4w1d_cado000_PIG00 = 4106900,
            n4w1d_east000_PIG00 = 4107900,
            n4w1d_cats000_PIG00 = 4108900,
            n4w1d_cent000_PIG00 = 4109900,
            Pig_Normal_test = 10000,
            Pig_Normal1 = 10100,
            PigTNormal2 = 10101,
            PigTNormal3 = 10102,
            PigTNormal4 = 10103,
            Pig_King = 10104,
            PigTFewtime1 = 10110,
            PigTFewtime2 = 10111,
            PigTFewtime3 = 10112,
            PigTDamage1 = 10120,
            PigTDamage2 = 10121,
            PigTDamage3 = 10122,
            PigTSpeedup1 = 10130,
            PigTSpeedup2 = 10131,
            PigTSpeedup3 = 10132,
            PigTHighHp = 10150,
            Pig_Same1 = 10200,
            PigTSame2HpRecover = 10201,
            PigTSame3 = 10202,
            PigTSame4 = 10203,
            Pig_Weak1 = 10300,
            PigTWeak2 = 10301,
            PigTWeak3 = 10302,
            PigTWeak4 = 10303,
            PigTWeak5 = 10304,
            PigTWeakMix1 = 10320,
            PigTWeakMix2 = 10321,
            PigTWeakMix3 = 10330,
            Pig_WeakMsh1 = 10350,
            PigTWeakMsh2 = 10351,
            PigTWeakMsh3 = 10352,
            PigTWeakMsh4 = 10353,
            PigTWeakMsh5 = 10354,
            PigTWeakMsh6 = 10370,
            PigTWeakMsh7 = 10380,
            Pig_Div1 = 10400,
            Pig_Div2 = 10401,
            PigTDiv3 = 10402,
            PigTDiv4 = 10403,
            PigTDiv5 = 10404,
            PigTColor1 = 10500,
            PigTColor2 = 10501,
            PigTColor3 = 10502,
            PigTColor4 = 10503,
            PigTColor5 = 10504,
            PigTestGold = 11000,
            PigTestGoldFake = 11001,
            PigTFake = 11010,
            PigTFake5 = 11020,
            PigTGold1 = 11030,
            PigTGold5 = 11040,
            PigTDivisionBig1 = 11100,
            PigTDivisionBigHpChange = 11110,
            PigTColorRedBlue2 = 11200,
            PigTColorRedBlue4 = 11201,
            PigTColorlExplosion00 = 11210,
            PigTColorlExplosion01 = 11211,
            PigTestWeakFire00 = 11300,
            PigTWeakFireWater = 11301,
            PigTWeakMashUpFire00 = 11310,
            PigTWeakMashUpFireWater00 = 11311,
            Pig_Weak_Multi6 = 11500,
            Pig_Weak_Single6 = 11501,
            Pig_Same_RevSlow2 = 11600,
            Pig_Same_RevNormal2 = 11601,
            Pig_Same_RevFast2 = 11602,
            Pig_Same_RevNormal4 = 11603,
            Pig_Same_RevNormal6 = 11604,
            Pig_Color4_Bomb1 = 11800,
            Pig_Color6_Bomb2 = 11801,
            Pig_Color8_Bomb2 = 11802,
            Pig_SoftColor8_Bomb2 = 11803,
            Pig_FuyaAndGold = 11900,
            PigTestDivScra = 12000,
            PigTestDivAest = 12001,
            PigTestDivCent = 12002,
            PigTestDivSpin = 12003,
            PigTestDivDgen = 12004,
            PigTestDiv104 = 12005,
            PigTestDivTowaRecord = 12006,
            PigTestDivChidori = 12007,
            PigTestDivTakeshita = 12008,
            PigTestDivLafor = 12009,
            PigTestDivHigashiHikarime = 12010,
            PigTestDivHighway = 12011,
            PigTestDivShibuyaSyutroem = 12012,
            PigTestDivNishiguchiBus = 12013,
            PigTestDivCatStreet = 12014,
            PigTestDivMiyashitaPark = 12015,
            PigTestDivUtagawa = 12016,
            Invalid = -1,
        }
    }
}
