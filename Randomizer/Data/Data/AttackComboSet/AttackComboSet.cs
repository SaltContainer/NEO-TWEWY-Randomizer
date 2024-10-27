﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class AttackComboSet
    {
        [JsonProperty("mId")]
        public Label Id { get; set; }
        [JsonProperty("mAttack")]
        public IList<Attack.Label> AttackList { get; set; }

        public enum Label : int
        {
            CmbSlash_01_NoAttribute_00 = 100,
            CmbSlash_02_Fire_00 = 101,
            CmbSlash_03_Fire_01 = 102,
            CmbSlash_04_NoAttribute_01 = 103,
            CmbSlash_05_NoAttribute_00 = 104,
            CmbSlash_06_Wind_00 = 105,
            CmbSlash_07_Dark_00 = 106,
            CmbSlash_08_Dark_01 = 107,
            CmbSlash_09_Noise_00 = 108,
            CmbSlashUP_00_NoAttribute_00 = 109,
            CmbSlashUP_01_Fire_00 = 110,
            CmbSlashUP_02_Fire_01 = 111,
            CmbSlashUP_03_NoAttribute_01 = 112,
            CmbSlashUP_04_NoAttribute_02 = 113,
            CmbSlashUP_05_Water_00 = 114,
            CmbSlashAll_00_Wind_00 = 115,
            CmbSlashAll_01_Wind_01 = 116,
            CmbSlashAll_02_Light_00 = 117,
            CmbSlashAll_03_Light_01 = 118,
            CmbSlash_Pair00_Sound_00 = 119,
            CmbSlash_Pair01_Sound_01 = 120,
            CmbSlashUP_Pair00_Light_00 = 121,
            CmbSlashAll_pair00_Water_00 = 122,
            RushPunch0_00_00 = 200,
            RushPunch0_01_00 = 201,
            RushPunch0_02_00 = 202,
            RushPunch0_03_00 = 203,
            RushPunch0_04_00 = 204,
            RushPunch0_05_00 = 205,
            RushPunch0_06_00 = 206,
            RushPunch0_07_00 = 207,
            RushPunch0_08_00 = 208,
            RushPunch1_00_00 = 209,
            RushPunch1_01_00 = 210,
            RushPunch1_02_00 = 211,
            RushPunch1_03_00 = 212,
            RushPunch0_09_00 = 213,
            CmbBigSpear_00_NoAttribute_00 = 300,
            CmbBigSpear_01_NoAttribute_01 = 301,
            CmbBigSpear_02_NoAttribute_02 = 302,
            CmbStabSpear0_03_00 = 303,
            CmbStabSpear0_04_00 = 304,
            CmbAssassin_00_Dark_00 = 305,
            CmbStabSpear1_01_00 = 306,
            CmbStabSpear1_02_00 = 307,
            CmbStabSpear1_03_00 = 308,
            CmbAssassin_04_Noise_00 = 309,
            CmbDownSpear_00_Thunder_00 = 310,
            CmbDownSpear_01_Thunder_01 = 311,
            CmbDownSpear_02_Thunder_02 = 312,
            CmbStabSpear2_03_00 = 313,
            CmbStabSpear2_04_00 = 314,
            CmbBigSpear_pair00_Light_00 = 315,
            CmbTap_00_NoAttribute_00 = 400,
            CmbTap_01_NoAttribute_01 = 401,
            CmbTap_02_NoAttribute_02 = 402,
            CmbTap_03_Thunder_00 = 403,
            CmbTap_04_Thunder_01 = 404,
            CmbTap_05_Ice_00 = 405,
            CmbTap_06_Ice_01 = 406,
            CmbTap_07_Scrap_00 = 407,
            CmbTap_08_Scrap_00 = 408,
            CmbTap_09_Poison_00 = 409,
            CmbTap_10_Noise_00 = 410,
            CmbTap_11_Ice_02 = 411,
            CmbTap_12_Sound_00 = 412,
            CmbTap_13_Sound_01 = 413,
            CmbTap_14_Light_00 = 414,
            CmbTap_15_Light_01 = 415,
            CmbTap_16_Shuriken_00 = 416,
            CmbTap_17_Shuriken_01 = 417,
            CmbHomingTap_00_Normal_00 = 418,
            CmbHomingTap_01_Normal_01 = 419,
            CmbHomingTap_02_Fire_00 = 420,
            CmbHomingTap_03_Fire_01 = 421,
            CmbHomingTap_04_Dark_00 = 422,
            CmbHomingTap_05_Dark_01 = 423,
            CmbHomingTap_06_Noise_00 = 424,
            CmbTap_18_Poison_01 = 425,
            CmbHomingTap_pair00_Thunder_00 = 426,
            CmbTap_pair00_Light_00 = 427,
            Arrow1 = 500,
            CmbArrow0_01_00 = 501,
            CmbArrow0_02_00 = 502,
            CmbArrow0_03_00 = 503,
            CmbArrow0_04_00 = 504,
            CmbArrow0_05_00 = 505,
            CmbArrow0_06_00 = 506,
            CmbArrow_07_Gravitation_00 = 507,
            CmbArrow0_08_00 = 508,
            LandBomb = 600,
            CmbBomb0_01_00 = 601,
            CmbBomb0_02_00 = 602,
            CmbBomb0_03_00 = 603,
            CmbBomb0_04_00 = 604,
            CmbBomb0_05_00 = 605,
            CmbBomb0_06_00 = 606,
            CmbBomb0_07_00 = 607,
            CmbBomb0_08_00 = 608,
            CmbBomb0_09_00 = 609,
            CmbBomb0_10_00 = 610,
            CmbBomb0_11_00 = 611,
            CmbBomb0_12_00 = 612,
            CmbBomb0_13_00 = 613,
            CmbBomb0_14_00 = 614,
            CmbBomb0_15_00 = 615,
            CmbBomb0_16_00 = 616,
            CmbBomb0_17_00 = 617,
            Dash = 700,
            CmbDash0_01_00 = 701,
            CmbDash0_02_00 = 702,
            CmbDash0_03_00 = 703,
            CmbDash0_04_00 = 704,
            CmbDash0_05_00 = 705,
            CmbDash0_06_00 = 706,
            CmbThunder0_00_00 = 800,
            CmbThunder0_01_00 = 801,
            CmbThunder0_02_00 = 802,
            CmbThunder0_03_00 = 803,
            CmbThunder0_04_00 = 804,
            CmbThunder0_05_00 = 805,
            CmbThunder0_06_00 = 806,
            CmbThunder0_07_00 = 807,
            CmbKick_00_NoAttribute_00 = 900,
            CmbKick_01_NoAttribute_01 = 901,
            CmbKick_02_Wind_00 = 902,
            CmbKick_03_Wind_01 = 903,
            CmbKick_04_Sound_00 = 904,
            CmbKick_05_Sound_01 = 905,
            CmbKick_06_Fire_00 = 906,
            CmbKick_07_Fire_01 = 907,
            CmbKick_08_Noise_00 = 908,
            CmbKick_pair00_Light_00 = 909,
            CmbFall0_00_00 = 1000,
            CmbFall0_01_00 = 1001,
            CmbFall0_02_00 = 1002,
            CmbFall0_03_00 = 1003,
            CmbFall0_04_00 = 1004,
            CmbFall0_05_00 = 1005,
            CmbFall_06_Noise_00 = 1006,
            CmbFall_07_scrap_00 = 1007,
            CmbFall_08_scrap_01 = 1008,
            CmbFall_09_scrap_02 = 1009,
            CmbFall_pair00_Fire_00 = 1010,
            CmbUpper_00_Ice_00 = 1100,
            CmbUpper0_01_00 = 1101,
            CmbUpper0_02_00 = 1102,
            CmbUpper_03_Rock_00 = 1103,
            CmbUpper_04_Rock_01 = 1104,
            CmbUpper_05_Fire_00 = 1105,
            CmbUpper0_06_00 = 1106,
            CmbUpper0_07_00 = 1107,
            CmbUpper_08_Noise_00 = 1108,
            CmbUpper_pair00_Scrap_00 = 1109,
            Napalm = 1200,
            CmbNpm0_01_00 = 1201,
            CmbNpm0_02_00 = 1202,
            CmbNpm0_03_00 = 1203,
            CmbNpm0_04_00 = 1204,
            CmbNpm0_05_00 = 1205,
            CmbNpm0_06_00 = 1206,
            CmbNpm0_07_00 = 1207,
            CmbNpm0_08_00 = 1208,
            CmbNpm0_09_00 = 1209,
            CmbLWire_00_NoAttribute_00 = 1300,
            CmbLWire_01_NoAttribute_01 = 1301,
            CmbLWire_02_Fire_00 = 1302,
            CmbLWire_03_Fire_01 = 1303,
            CmbLWire_04_Ice_00 = 1304,
            CmbLWire_05_Ice_01 = 1305,
            CmbLWire_06_Thunder_00 = 1306,
            CmbLWire_07_Thunder_01 = 1307,
            CmbLWire_08_Poison_00 = 1308,
            CmbLWire_09_Time_00 = 1309,
            CmbLWire_10_NoAttribute_02 = 1310,
            CmbLWire_11_NoAttribute_03 = 1311,
            CmbLWire_12_Poison_01 = 1312,
            CmbLWire_13_Light_00 = 1313,
            CmbLWire_14_Noise_00 = 1314,
            CmbBmr_00_NoAttribute_00 = 1400,
            CmbBmr_01_NoAttribute_01 = 1401,
            CmbBmr_02_Scrap_00 = 1402,
            CmbBmr_03_Scrap_01 = 1403,
            CmbBmr_04_Gravitation_00 = 1404,
            CmbBmr_05_Gravitation_01 = 1405,
            CmbBmr_06_Ice_00 = 1406,
            CmbBmr_07_Noise_00 = 1407,
            CmbBmr_pair00_Explosion_00 = 1408,
            CmbSnpr2_00_Explosion_00 = 1500,
            CmbSnpr2_01_Explosion_01 = 1501,
            CmbSnpr2_02_Sound_00 = 1502,
            CmbSnpr2_03_Water_00 = 1503,
            CmbSnpr2_04_Water_01 = 1504,
            CmbSnpr2_05_Dark_00 = 1505,
            CmbSnpr2_06_Dark_01 = 1506,
            CmbSnpr2_07_NoAttribute_00 = 1507,
            CmbSnpr2_08_NoAttribute_01 = 1508,
            CmbSnpr2_09_Chain_00 = 1509,
            CmbSnpr2_10_Chain_01 = 1510,
            CmbSnpr2_11_Poison_00 = 1511,
            CmbFish0_00_00 = 1700,
            CmbFish0_01_00 = 1701,
            CmbFish0_02_00 = 1702,
            CmbFish0_03_00 = 1703,
            CmbFish0_04_00 = 1704,
            CmbFish0_05_00 = 1705,
            CmbFish0_06_00 = 1706,
            CmbFish0_07_00 = 1707,
            CmbFish0_08_00 = 1708,
            CmbFish0_09_00 = 1709,
            CmbFish1_00_00 = 1710,
            CmbFish1_01_00 = 1711,
            CmbFish1_02_00 = 1712,
            CmbFish1_03_00 = 1713,
            CmbFish0_10_00 = 1714,
            CmbFish1_04_00 = 1715,
            CmbLaser_00_Light_00 = 1800,
            CmbLaser_01_Light_01 = 1801,
            CmbLaser_02_Thunder_00 = 1802,
            CmbLaser0_03_00 = 1803,
            CmbLaser0_04_00 = 1804,
            CmbLaser0_05_00 = 1805,
            CmbLaser0_06_00 = 1806,
            CmbLaser_07_Ice_02 = 1807,
            CmbLaser_08_Gravitation_00 = 1808,
            CmbLaser_09_Dark_00 = 1809,
            CmbLaser_10_Noise_00 = 1810,
            CmbChanneling_00_Fire_00 = 1900,
            CmbChanneling_01_Fire_01 = 1901,
            CmbChanneling_02_ChaseFire_00 = 1902,
            CmbChanneling_03_ChaseFire_01 = 1903,
            CmbChanneling_04_Thunder_00 = 1904,
            CmbChanneling_05_Thunder_01 = 1905,
            CmbChanneling_06_Rock_00 = 1906,
            CmbChanneling_07_Gravitation_00 = 1907,
            CmbChanneling_08_Gravitation_01 = 1908,
            CmbChanneling_09_Gravitation_02 = 1909,
            CmbChanneling_10_NoAttribute_00 = 1910,
            CmbChanneling_11_Noise_00 = 1911,
            CmbChanneling0_12_00 = 1912,
            CmbBlackHole = 1913,
            CmbBlackHole_01_00 = 1914,
            CmbBlackHole_02_00 = 1915,
            CmbBlackHole_03_00 = 1916,
            CmbBlackHole_04_00 = 1917,
            CmbBlackHole_05_00 = 1918,
            CmbChanneling_pair00_Dark_00 = 1919,
            CmbTornado0_00_00 = 2000,
            CmbTornado0_01_00 = 2001,
            CmbTornado0_02_00 = 2002,
            CmbTornado0_03_00 = 2003,
            CmbTornado0_04_00 = 2004,
            CmbTornado0_05_00 = 2005,
            CmbTackle0_00_00 = 2200,
            CmbTackle0_01_00 = 2201,
            CmbTackle_02_Thunder_00 = 2202,
            CmbTackle_03_Thunder_01 = 2203,
            CmbTackle_04_Fire_00 = 2204,
            CmbTackle_05_Fire_01 = 2205,
            CmbTackle_06_Explosion_00_00 = 2206,
            CmbTackle_07_Noise_00 = 2207,
            Speaker0_00_00 = 2300,
            Speaker0_01_00 = 2301,
            Speaker0_02_00 = 2302,
            Speaker0_03_00 = 2303,
            Speaker0_04_00 = 2304,
            Speaker0_05_00 = 2305,
            Speaker0_06_00 = 2306,
            Speaker0_07_00 = 2307,
            Speaker0_08_00 = 2308,
            Speaker0_09_00 = 2309,
            Speaker0_10_00 = 2310,
            Speaker0_11_00 = 2311,
            Speaker1_00_00 = 2312,
            Speaker1_01_00 = 2313,
            Speaker1_02_00 = 2314,
            Speaker1_03_00 = 2315,
            Speaker1_04_00 = 2316,
            Speaker1_05_00 = 2317,
            Speaker1_06_00 = 2318,
            CmbPsyK_00_Scrap_00 = 2400,
            CmbPsyK_01_Scrap_01 = 2401,
            CmbPsyK_02_Scrap_02 = 2402,
            CmbPsyK_03_Scrap_03 = 2403,
            CmbPsyK_04_Noise_00 = 2404,
            CmbPsyK_05_Scrap_04 = 2405,
            CmbBranchLaser0_00_00 = 2500,
            CmbBranchLaser0_01_00 = 2501,
            CmbBranchLaser0_02_00 = 2502,
            CmbBranchLaser0_03_00 = 2503,
            CmbBranchLaser0_04_00 = 2504,
            CmbBranchLaser0_05_00 = 2505,
            CmbBranchLaser0_06_00 = 2506,
            CmbBranchLaser0_07_00 = 2507,
            CmbShotgun_00_NoAttribute_00 = 2600,
            CmbShotgun_01_Gravitation_00 = 2601,
            CmbShotgun_02_Time_00 = 2602,
            CmbShotgun_03_Ligrt_00 = 2603,
            CmbShotgun_04_Dark_00 = 2604,
            CmbShotgun_05_Thunder_00 = 2605,
            CmbShotgun_pair00_Light_00 = 2606,
            CmbBlowTrap = 2800,
            CmbBlowTrap_01_00 = 2801,
            CmbBlowTrap_02_00 = 2802,
            CmbBlowTrap_03_00 = 2803,
            CmbBlowTrap_04_00 = 2804,
            CmbBlowTrap_05_00 = 2805,
            CmbBlowTrap_06_00 = 2806,
            CmbDNoise_00_Gravitation_00 = 2900,
            CmbDNoise_01_Gravitation_01 = 2901,
            CmbDNoise_02_Grab_00 = 2902,
            CmbDNoise_03_Grab_01 = 2903,
            CmbDNoise_04_Noise_00 = 2904,
            CmbDNoise_pair00_Grab_00 = 2905,
            CmbDNoise_05_Grab_02 = 2906,
            CmbDNoise_06_Gravitation_02 = 2907,
            CmbSnpr_00_Explosion_00 = 8000,
            Tackle = 8001,
            Speaker = 8002,
            CmbKick0_00_00 = 8003,
            CmbSlash0_00_00 = 8004,
            CmbSlash0_01_01 = 8005,
            CmbSlash0_02_01 = 8006,
            CmbSlash0_04_01 = 8007,
            CmbSlash1_00_01 = 8008,
            CmbSlash1_00_02 = 8009,
            CmbSlash2_01_01 = 8010,
            CmbSlash3_00_01 = 8011,
            CmbSlash3_01_01 = 8012,
            CmbTap0_00_00 = 8013,
            CmbTap0_01_01 = 8014,
            CmbTap0_02_01 = 8015,
            CmbTap0_03_01 = 8016,
            CmbTap0_04_01 = 8017,
            CmbTap0_05_00 = 8018,
            CmbTap1_01_01 = 8019,
            CmbTap1_02_01 = 8020,
            CmbTap1_03_01 = 8021,
            CmbTap2_00_01 = 8022,
            CmbTap2_01_01 = 8023,
            CmbTap2_02_01 = 8024,
            CmbTap3_00_00 = 8025,
            CmbTap3_01_00 = 8026,
            CmbTap3_02_00 = 8027,
            CmbTap3_03_00 = 8028,
            Upper1 = 8029,
            Drag1 = 8030,
            Meteor1 = 8031,
            Hold1 = 8032,
            Multi1 = 8033,
            Object1 = 8034,
            Laser1 = 8035,
            Trap = 8036,
            WaterSpray = 8037,
            RollSlash = 8038,
            Hammer = 8039,
            Object3 = 8040,
            SearchTrap1 = 8041,
            ChargeLaser1 = 8042,
            TrackingFire = 8043,
            LoveWire = 8044,
            LoveWireSide = 8045,
            TestSlash1 = 8046,
            TestTap1 = 8047,
            ChargeMeteor1 = 8048,
            SniperTest = 8049,
            SpeakerShield = 8050,
            LandBomb_Botsu = 8051,
            EnemyAttack001 = 10000,
            EnemyAttackBear01 = 10010,
            EnemyAttackBear01b = 10015,
            EnemyAttackBear02 = 10011,
            EnemyAttackBear02b = 10012,
            EnemyAttackBear03 = 10013,
            EnemyAttackBear03b = 10014,
            EnemyAttackCrow01 = 10020,
            EnemyAttackCrow02 = 10021,
            EnemyAttackCrow03 = 10022,
            EnemyAttackFrog01 = 10030,
            EnemyAttackFrog02 = 10031,
            EnemyAttackFrog03 = 10032,
            EnemyAttackFrog02b = 10033,
            EnemyAttackFrog04 = 10034,
            EnemyAttackWolf01 = 10040,
            EnemyAttackWolf02 = 10041,
            EnemyAttackWolf02b = 10043,
            EnemyAttackWolf03 = 10042,
            EnemyAttackKangaroo01 = 10050,
            EnemyAttackJellyFishTwister = 10060,
            EnemyAttackJellyFishDivision = 10061,
            EnemyAttackJellyFishThunder = 10062,
            EnemyAttackJellyFishThunder2 = 10065,
            EnemyAttackJellyFishTwister2 = 10063,
            EnemyAttackJellyFishTwister3 = 10064,
            EnemyAttackRhino01 = 10070,
            EnemyAttackRhino02 = 10071,
            EnemyAttackRhino03 = 10072,
            EnemyAttackRhino01b = 10073,
            EnemyAttackRhino01c = 10074,
            EnemyAttackShark01 = 10080,
            EnemyAttackShark01b = 10081,
            EnemyAttackShark01c = 10082,
            EnemyAttackShark02 = 10083,
            EnemyAttackShark02b = 10084,
            EnemyAttackShark03 = 10085,
            EnemyAttackElephantShower01 = 10090,
            EnemyAttackElephantShower02 = 10091,
            EnemyAttackElephantBeam01 = 10092,
            EnemyAttackElephantBeam02 = 10093,
            EnemyAttackElephantBinta = 10094,
            EnemyAttackElephantShockWave = 10095,
            EnemyAttackElephantWalk = 10096,
            EnemyAttackElephantSuck = 10097,
            EnemyAttackElephantWalkShower = 10098,
            EnemyAttackElephantRain = 10099,
            EnemyAttackPenguin01 = 10100,
            EnemyAttackPenguin01Freezing = 10101,
            EnemyAttackPenguin02 = 10103,
            EnemyAttackPenguin02Freezing = 10104,
            EnemyAttackPenguin03 = 10105,
            EnemyAttackPorcupinefish01 = 10140,
            EnemyAttackPorcupinefish01b = 10141,
            EnemyAttackPorcupinefish01c = 10142,
            EnemyAttackPorcupinefish01d = 10143,
            EnemyAttackPorcupinefish02 = 10144,
            EnemyAttackPorcupinefish02b = 10149,
            EnemyAttackPorcupinefish03 = 10145,
            EnemyAttackPorcupinefish03a = 10146,
            EnemyAttackPorcupinefish03b = 10147,
            EnemyAttackPorcupinefish03c = 10148,
            EnemyAttackPorcupinefish03_Asskc = 10171,
            EnemyAttackPorcupinefish02c = 10159,
            EnemyAttackScorpion01 = 10150,
            EnemyAttackScorpion01b = 10151,
            EnemyAttackScorpion01c = 10170,
            EnemyAttackScorpion02 = 10152,
            EnemyAttackScorpion02b = 10153,
            EnemyAttackScorpion02c = 10165,
            EnemyAttackScorpion03 = 10154,
            EnemyAttackScorpion03b = 10155,
            EnemyAttackScorpion01d = 10156,
            EnemyAttackScorpion02d = 10157,
            EnemyAttackScorpion03d = 10158,
            EnemyAttackChameleon01 = 10160,
            EnemyAttackChameleon02 = 10161,
            EnemyAttackChameleon03 = 10162,
            EnemyAttackChameleon04 = 10163,
            EnemyAttackChameleon05 = 10164,
            EnemyAttackTyrannoBite = 10180,
            EnemyAttackTyrannoBiteFrenzy = 10181,
            EnemyAttackTyrannoTailBlowA = 10182,
            EnemyAttackTyrannoTailBlowB = 10183,
            EnemyAttackTyrannoTailBlowFrenzyA = 10184,
            EnemyAttackTyrannoTailBlowFrenzyB = 10185,
            EnemyAttackTyrannoRoar = 10186,
            EnemyAttackTyrannoRoarFrenzy = 10187,
            EnemyAttackTyrannoTrample = 10188,
            EnemyAttackTyrannoTrampleFrenzy = 10189,
            EnemyAttackTyrannoPredatoryBite = 10190,
            EnemyAttackPigExplosion = 10300,
            EnemyAttackGorilla01 = 11010,
            EnemyAttackGorilla02 = 11011,
            EnemyAttackGorilla03 = 11012,
            EnemyAttackGorilla04 = 11013,
            EnemyAttackGorilla06 = 11015,
            EnemyAttackGorilla06F = 11016,
            EnemyAttackNyanTanS01 = 11040,
            EnemyAttackNyanTanM01 = 12040,
            EnemyAttackNyanTanM02 = 12041,
            EnemyAttackNyanTanHuge01 = 11050,
            EnemyAttackNyanTanHuge02 = 11051,
            EnemyAttackTsugumi01 = 11060,
            EnemyAttackTsugumi02 = 11061,
            EnemyAttackTsugumi03 = 11062,
            EnemyAttackTsugumi04 = 11063,
            EnemyAttackTsugumi05 = 11064,
            EnemyAttackTsugumi06 = 11065,
            EnemyAttackTsugumi01A = 11066,
            EnemyAttackMinamimotoCounter = 11080,
            EnemyAttackMinamimotoLowKick = 11081,
            EnemyAttackMinamimotoRotaryKick = 11082,
            EnemyAttackMinamimotoHeelDrop = 11083,
            EnemyAttackMinamimotoFireClaw = 11084,
            EnemyAttackMinamimotoDoubleClaw = 11085,
            EnemyAttackMinamimotoGroundStrike = 11086,
            EnemyAttackMinamimotoInfinityFinish = 11087,
            EnemyAttackMinamimotoAura = 11088,
            EnemyAttackAMinamimotoCounter = 111080,
            EnemyAttackAMinamimotoLowKick = 111081,
            EnemyAttackAMinamimotoRotaryKick = 111082,
            EnemyAttackAMinamimotoHeelDrop = 111083,
            EnemyAttackAMinamimotoFireClaw = 111084,
            EnemyAttackAMinamimotoDoubleClaw = 111085,
            EnemyAttackAMinamimotoGroundStrike = 111086,
            EnemyAttackAMinamimotoInfinityFinish = 111087,
            EnemyAttackAMinamimotoAura = 111088,
            EnemyAttackPsychicerA01 = 12010,
            EnemyAttackPsychicerA02 = 12011,
            EnemyAttackPsychicerA03 = 12012,
            EnemyAttackPsychicerB01 = 12013,
            EnemyAttackPsychicerBomb1 = 12020,
            EnemyAttackPsychicerBomb2 = 12021,
            EnemyAttackPsychicerWire1 = 12022,
            EnemyAttackSusukichi01 = 12030,
            EnemyAttackSusukichi02 = 12031,
            EnemyAttackSusukichi03 = 12032,
            EnemyAttackSusukichi04 = 12033,
            EnemyAttackSusukichi05 = 12034,
            EnemyAttackSusukichi06 = 12035,
            EnemyAttackSusukichi07 = 12036,
            EnemyAttackAyano01 = 11070,
            EnemyAttackAyano02 = 11071,
            EnemyAttackAyano03 = 11072,
            EnemyAttackAyano04 = 11073,
            EnemyAttackAyano05 = 11074,
            EnemyAttackAyano06 = 11075,
            EnemyAttackAyano07 = 11076,
            EnemyAttackAyano01F = 511070,
            EnemyAttackAyano02F = 511071,
            EnemyAttackAyano03F = 511072,
            EnemyAttackAyano04F = 511073,
            EnemyAttackAyano05F = 511074,
            EnemyAttackAyano06F = 511075,
            EnemyAttackAyano07F = 511076,
            EnemyAttackAnotherAyano03 = 12070,
            EnemyAttackAnotherAyano05 = 12071,
            EnemyAttackAnotherAyano06 = 12072,
            EnemyAttackAnotherAyano04 = 12073,
            EnemyAttackSusukichiNoise01 = 11090,
            EnemyAttackSusukichiNoise02 = 11091,
            EnemyAttackSusukichiNoise03 = 11092,
            EnemyAttackSusukichiNoise04 = 11093,
            EnemyAttackSusukichiNoise05 = 11094,
            EnemyAttackSusukichiNoiseBig01 = 12090,
            EnemyAttackSusukichiNoiseBig02 = 12091,
            EnemyAttackSusukichiNoiseBig03 = 12092,
            EnemyAttackSusukichiNoiseBig04 = 12093,
            EnemyAttackSusukichiNoiseBig05 = 12094,
            EnemyAttackShiiba01 = 11110,
            EnemyAttackShiiba02 = 11111,
            EnemyAttackShiiba03 = 11112,
            EnemyAttackShiiba04 = 11113,
            EnemyAttackShiiba05 = 11114,
            EnemyAttackShiiba06 = 11115,
            EnemyAttackShiiba_S02 = 11116,
            EnemyAttackShiiba07 = 11117,
            EnemyAttackShiiba_S04 = 11118,
            EnemyAttackReplayNoise01 = 11120,
            EnemyAttackPhoenix01 = 11130,
            EnemyAttackPhoenix02 = 11131,
            EnemyAttackPhoenix03 = 11132,
            EnemyAttackPhoenix04 = 11133,
            EnemyAttackPhoenix05 = 11134,
            EnemyAttackPhoenix06 = 11135,
            EnemyAttackPhoenix07 = 11136,
            EnemyAttackPhoenix08 = 11137,
            EnemyAttackPhoenix09 = 11138,
            EnemyAttackPhoenixTail01 = 11140,
            EnemyAttackPhoenixTail02 = 11141,
            EnemyAttackPhoenixTail03 = 11142,
            EnemyAttackPhoenixTail04 = 11143,
            EnemyAttackPhoenixTail05 = 11144,
            EnemyAttackPhoenixTail06 = 11145,
            EnemyAttackPhoenixGateTail01 = 11150,
            EnemyAttackPhoenixGateTail02 = 11151,
            EnemyAttackPhoenixGateTail03 = 11152,
            EnemyAttackPhoenixGateTail04 = 11153,
            EnemyAttackPhoenixGateTail05 = 11154,
            EnemyAttackPhoenixGateTail06 = 11155,
            Invalid = -1,
        }
    }
}
