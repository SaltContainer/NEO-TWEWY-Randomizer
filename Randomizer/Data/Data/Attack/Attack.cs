﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class Attack
    {
        [JsonProperty("mId")]
        public Label Id { get; set; }
        [JsonProperty("mHit")]
        public IList<AttackHit.Label> HitList { get; set; }
        [JsonProperty("mEffect")]
        public IList<EffectName> EffectList { get; set; }
        [JsonProperty("mEffectAttach")]
        public IList<int> EffectAttachList { get; set; }
        [JsonProperty("mEffectParent")]
        public IList<string> EffectParentList { get; set; }
        [JsonProperty("mEffectPlayOption")]
        public IList<int> EffectPlayOptionList { get; set; }

        public enum Label : int
        {
            AtkSlash_NoAttribute01_00 = 100,
            AtkSlash_NoAttribute02_00 = 101,
            AtkSlash_NoAttribute03_00 = 102,
            AtkSlash_NoAttribute_Back_00 = 103,
            AtkSlash_NoAttribute_Back_01 = 104,
            AtkSlash_NoAttribute_Up_00 = 105,
            AtkSlash_NoAttribute_Up_01 = 106,
            AtkSlash_NoAttribute_Up_02 = 107,
            AtkSlash_Fire01_00 = 108,
            AtkSlash_Fire02_00 = 109,
            AtkSlash_Fire03_00 = 110,
            AtkSlash_Fire_Back_00 = 111,
            AtkSlash_Fire_Back_01 = 112,
            AtkSlash_Fire_Up_00 = 113,
            AtkSlash_Fire_Up_01 = 114,
            AtkSlash_Fire_Up_02 = 115,
            AtkSlash_Fire_Forward_00 = 116,
            AtkSlash_Wind01_00 = 117,
            AtkSlash_Wind02_00 = 118,
            AtkSlash_Wind03_00 = 119,
            AtkSlash_Wind_Back_00 = 120,
            AtkSlash_Wind_Back_01 = 121,
            AtkSlash_Wind_Back_02 = 122,
            AtkSlash_Wind_All_00 = 123,
            AtkSlash_Wind_All_01 = 124,
            AtkSlash_Wind_All_02 = 125,
            AtkSlash_Wind_Forward_00 = 126,
            AtkSlash_Dark01_00 = 127,
            AtkSlash_Dark02_00 = 128,
            AtkSlash_Dark03_00 = 129,
            AtkSlash_Dark_Back_00 = 130,
            AtkSlash_Dark_Back_01 = 131,
            AtkSlash_Water01_00 = 132,
            AtkSlash_Water02_00 = 133,
            AtkSlash_Water03_00 = 134,
            AtkSlash_Water_Up_00 = 135,
            AtkSlash_Water_Up_01 = 136,
            AtkSlash_Water_Forward_00 = 137,
            AtkSlash_Water_Forward_01 = 138,
            AtkSlash_Light01_00 = 139,
            AtkSlash_Light02_00 = 140,
            AtkSlash_Light03_00 = 141,
            AtkSlash_Light_All_00 = 142,
            AtkSlash_Light_All_01 = 143,
            AtkSlash_Light_All_02 = 144,
            AtkSlash_Light_All_04 = 163,
            AtkSlash_Light_All_03 = 145,
            AtkSlash_Noise01_00 = 146,
            AtkSlash_Noise02_00 = 147,
            AtkSlash_Noise03_00 = 148,
            AtkSlash_Noise_Back_00 = 149,
            AtkSlash_Noise_Forward_00 = 150,
            AtkSlash_pairSound01_00 = 151,
            AtkSlash_pairSound02_00 = 152,
            AtkSlash_pairSound03_00 = 153,
            AtkSlash_pairSound_Back_00 = 154,
            AtkSlash_pairSound_Back_01 = 161,
            AtkSlash_pairSound_Up_00 = 155,
            AtkSlash_pairSound_Forward_00 = 162,
            AtkSlash_pairWater01_00 = 156,
            AtkSlash_pairWater02_00 = 157,
            AtkSlash_pairWater03_00 = 158,
            AtkSlash_pairWater_All_02 = 159,
            AtkSlash_pairWater_All_03 = 160,
            AtkSlash_pairWater_Forward_00 = 164,
            AtkSlash_pairWater_Back_00 = 165,
            AtkSlash_pairLight01_00 = 166,
            AtkSlash_pairLight02_00 = 167,
            AtkSlash_pairLight03_00 = 168,
            AtkSlash_pairLight_Back_00 = 169,
            AtkSlash_pairLight_Back_01 = 170,
            AtkSlash_pairLight_Up_00 = 171,
            AtkSlash_pairLight_Forward_00 = 172,
            AtkSlash_pairLight_All_00 = 173,
            AtkSlash_pairSound01_01 = 174,
            AtkSlash_pairSound02_01 = 175,
            AtkSlash_pairSound03_01 = 176,
            AtkSlash_pairSound_Forward_01 = 177,
            AtkSlash_tutorial01_00 = 178,
            AtkSlash_tutorial02_00 = 179,
            AtkSlash_tutorial_Back_00 = 180,
            AtkSlash_AutoSlash01_00 = 181,
            AtkSlash_AutoSlash02_00 = 182,
            AtkSlash_AutoSlash03_00 = 183,
            AtkSlash_AutoSlash_Up_00 = 184,
            AtkSlash_NoAttribute3_01_00 = 185,
            AtkSlash_NoAttribute3_02_00 = 186,
            AtkSlash_NoAttribute3_03_00 = 187,
            AtkSlash_NoAttribute3_Back_00 = 188,
            AtkSlash_NoAttribute3_Back_01 = 189,
            AtkRushPunch0_00_00_00 = 200,
            AtkRushPunch0_00_00_01 = 201,
            AtkRushPunch0_00_00_02 = 202,
            AtkRushPunch0_00_00_03 = 203,
            AtkRushPunch0_00_00_04 = 204,
            AtkRushPunch0_01_00_00 = 205,
            AtkRushPunch0_01_00_01 = 206,
            AtkRushPunch0_01_00_02 = 207,
            AtkRushPunch0_01_00_03 = 208,
            AtkRushPunch0_01_00_04 = 209,
            AtkRushPunch0_02_00_00 = 210,
            AtkRushPunch0_02_00_01 = 211,
            AtkRushPunch0_02_00_02 = 212,
            AtkRushPunch0_02_00_03 = 213,
            AtkRushPunch0_02_00_04 = 214,
            AtkRushPunch0_03_00_00 = 215,
            AtkRushPunch0_03_00_01 = 216,
            AtkRushPunch0_03_00_02 = 217,
            AtkRushPunch0_03_00_03 = 218,
            AtkRushPunch0_03_00_04 = 219,
            AtkRushPunch0_04_00_00 = 220,
            AtkRushPunch0_04_00_01 = 221,
            AtkRushPunch0_04_00_02 = 222,
            AtkRushPunch0_04_00_03 = 223,
            AtkRushPunch0_04_00_04 = 224,
            AtkRushPunch0_05_00_00 = 225,
            AtkRushPunch0_05_00_01 = 226,
            AtkRushPunch0_05_00_02 = 227,
            AtkRushPunch0_05_00_03 = 228,
            AtkRushPunch0_05_00_04 = 229,
            AtkRushPunch0_06_00_00 = 230,
            AtkRushPunch0_06_00_01 = 231,
            AtkRushPunch0_06_00_02 = 232,
            AtkRushPunch0_06_00_03 = 233,
            AtkRushPunch0_06_00_04 = 234,
            AtkRushPunch0_07_00_00 = 235,
            AtkRushPunch0_07_00_01 = 236,
            AtkRushPunch0_07_00_02 = 237,
            AtkRushPunch0_07_00_03 = 238,
            AtkRushPunch0_07_00_04 = 239,
            AtkRushPunch0_08_00_00 = 240,
            AtkRushPunch0_08_00_01 = 241,
            AtkRushPunch0_08_00_02 = 242,
            AtkRushPunch0_08_00_03 = 243,
            AtkRushPunch0_08_00_04 = 244,
            AtkRushPunch1_00_00_00 = 245,
            AtkRushPunch1_00_00_01 = 246,
            AtkRushPunch1_00_00_02 = 247,
            AtkRushPunch1_00_00_03 = 248,
            AtkRushPunch1_01_00_00 = 249,
            AtkRushPunch1_01_00_01 = 250,
            AtkRushPunch1_01_00_02 = 251,
            AtkRushPunch1_01_00_03 = 252,
            AtkRushPunch1_02_00_00 = 253,
            AtkRushPunch1_02_00_01 = 254,
            AtkRushPunch1_02_00_02 = 255,
            AtkRushPunch1_02_00_03 = 256,
            AtkRushPunch1_03_00_00 = 257,
            AtkRushPunch1_03_00_01 = 258,
            AtkRushPunch1_03_00_02 = 259,
            AtkRushPunch1_03_00_03 = 260,
            AtkRushPunch0_09_00_00 = 261,
            AtkRushPunch0_09_00_01 = 262,
            AtkRushPunch0_09_00_02 = 263,
            AtkRushPunch0_09_00_03 = 264,
            AtkRushPunch0_09_00_04 = 265,
            AtkBigSpear_00_NoAttribute_00_00 = 300,
            AtkBigSpear_00_NoAttribute_00_01 = 301,
            AtkBigSpear_01_NoAttribute_01_00 = 302,
            AtkBigSpear_01_NoAttribute_01_01 = 303,
            AtkBigSpear_02_NoAttribute_02_00 = 304,
            AtkBigSpear_02_NoAttribute_02_01 = 305,
            AtkStabSpear0_03_00_00 = 306,
            AtkStabSpear0_03_00_01 = 307,
            AtkStabSpear0_04_00_00 = 308,
            AtkStabSpear0_04_00_01 = 309,
            AtkAssassin_00_Dark_00_00 = 310,
            AtkAssassin_00_Dark_00_01 = 311,
            AtkStabSpear1_01_00_00 = 312,
            AtkStabSpear1_01_00_01 = 313,
            AtkStabSpear1_02_00_00 = 314,
            AtkStabSpear1_02_00_01 = 315,
            AtkStabSpear1_03_00_00 = 316,
            AtkStabSpear1_03_00_01 = 317,
            AtkAssassin_04_Noise_00_00 = 318,
            AtkAssassin_04_Noise_00_01 = 319,
            AtkDownSpear_00_Thunder_00_00 = 320,
            AtkDownSpear_00_Thunder_00_01 = 321,
            AtkDownSpear_01_Thunder_01_00 = 322,
            AtkDownSpear_01_Thunder_01_01 = 323,
            AtkDownSpear_02_Thunder_02_00 = 324,
            AtkDownSpear_02_Thunder_02_01 = 325,
            AtkStabSpear2_03_00_00 = 326,
            AtkStabSpear2_03_00_01 = 327,
            AtkStabSpear2_04_00_00 = 328,
            AtkStabSpear2_04_00_01 = 329,
            AtkBigSpear_pair00_Light_00_00 = 330,
            AtkBigSpear_pair00_Light_00_01 = 331,
            AtkTap_00_NoAttribute_00_00 = 400,
            AtkTap_00_NoAttribute_00_01 = 401,
            AtkTap_00_NoAttribute_00_02 = 402,
            AtkTap_01_NoAttribute_01_00 = 403,
            AtkTap_01_NoAttribute_01_01 = 404,
            AtkTap_01_NoAttribute_01_02 = 405,
            AtkTap_02_NoAttribute_02_00 = 406,
            AtkTap_02_NoAttribute_02_01 = 407,
            AtkTap_02_NoAttribute_02_02 = 408,
            AtkTap_03_Thunder_00_00 = 409,
            AtkTap_03_Thunder_00_01 = 410,
            AtkTap_03_Thunder_00_02 = 411,
            AtkTap_04_Thunder_01_00 = 412,
            AtkTap_04_Thunder_01_01 = 413,
            AtkTap_04_Thunder_01_02 = 414,
            AtkTap_05_Ice_00_00 = 415,
            AtkTap_05_Ice_00_01 = 416,
            AtkTap_05_Ice_00_02 = 417,
            AtkTap_06_Ice_01_00 = 418,
            AtkTap_06_Ice_01_01 = 419,
            AtkTap_06_Ice_01_02 = 420,
            AtkTap_07_Scrap_00 = 421,
            AtkTap_07_Scrap_01 = 422,
            AtkTap_07_Scrap_02 = 423,
            AtkTap_08_Scrap_00 = 424,
            AtkTap_08_Scrap_01 = 425,
            AtkTap_08_Scrap_02 = 426,
            AtkTap_09_Poison_00 = 427,
            AtkTap_09_Poison_01 = 428,
            AtkTap_09_Poison_02 = 429,
            AtkTap_10_Noise_00_00 = 430,
            AtkTap_10_Noise_00_01 = 431,
            AtkTap_10_Noise_00_02 = 432,
            AtkTap_11_Ice_02_00 = 433,
            AtkTap_11_Ice_02_01 = 434,
            AtkTap_11_Ice_02_02 = 435,
            AtkTap_12_Sound_00_00 = 436,
            AtkTap_12_Sound_00_01 = 437,
            AtkTap_12_Sound_00_02 = 438,
            AtkTap_13_Sound_01_00 = 439,
            AtkTap_13_Sound_01_01 = 440,
            AtkTap_13_Sound_01_02 = 441,
            AtkTap_14_Light_00_00 = 442,
            AtkTap_14_Light_00_01 = 443,
            AtkTap_14_Light_00_02 = 444,
            AtkTap_15_Light_01_00 = 445,
            AtkTap_15_Light_01_01 = 446,
            AtkTap_15_Light_01_02 = 447,
            AtkTap_16_Shuriken_00_00 = 448,
            AtkTap_16_Shuriken_00_01 = 449,
            AtkTap_16_Shuriken_00_02 = 450,
            AtkTap_17_Shuriken_01_00 = 451,
            AtkTap_17_Shuriken_01_01 = 452,
            AtkTap_17_Shuriken_01_02 = 453,
            AtkHomingTap_00_Normal_00_00 = 454,
            AtkHomingTap_00_Normal_00_01 = 455,
            AtkHomingTap_00_Normal_00_02 = 456,
            AtkHomingTap_01_Normal_01_00 = 457,
            AtkHomingTap_01_Normal_01_01 = 458,
            AtkHomingTap_01_Normal_01_02 = 459,
            AtkHomingTap_02_Fire_00_00 = 460,
            AtkHomingTap_02_Fire_00_01 = 461,
            AtkHomingTap_02_Fire_00_02 = 462,
            AtkHomingTap_03_Fire_01_00 = 463,
            AtkHomingTap_03_Fire_01_01 = 464,
            AtkHomingTap_03_Fire_01_02 = 465,
            AtkHomingTap_04_Dark_00_00 = 466,
            AtkHomingTap_04_Dark_00_01 = 467,
            AtkHomingTap_04_Dark_00_02 = 468,
            AtkHomingTap_05_Dark_01_00 = 469,
            AtkHomingTap_05_Dark_01_01 = 470,
            AtkHomingTap_05_Dark_01_02 = 471,
            AtkHomingTap_06_Noise_00_00 = 472,
            AtkHomingTap_06_Noise_00_01 = 473,
            AtkHomingTap_06_Noise_00_02 = 474,
            AtkTap_18_Poison_01_00 = 475,
            AtkTap_18_Poison_01_01 = 476,
            AtkTap_18_Poison_01_02 = 477,
            AtkHomingTap_pair00_Thunder_00_00 = 478,
            AtkHomingTap_pair00_Thunder_00_01 = 479,
            AtkHomingTap_pair00_Thunder_00_02 = 480,
            AtkTap_pair00_Light_00 = 481,
            AtkTap_pair00_Light_01 = 482,
            AtkTap_pair00_Light_02 = 483,
            Arrow1_1 = 500,
            Arrow1_Explosion = 501,
            AtkArrow0_01_00_00 = 502,
            AtkArrow0_01_00_01 = 503,
            AtkArrow0_02_00_00 = 504,
            AtkArrow0_02_00_01 = 505,
            AtkArrow0_03_00_00 = 506,
            AtkArrow0_03_00_01 = 507,
            AtkArrow0_04_00_00 = 508,
            AtkArrow0_04_00_01 = 509,
            AtkArrow0_05_00_00 = 510,
            AtkArrow0_05_00_01 = 511,
            AtkArrow0_06_00_00 = 512,
            AtkArrow0_06_00_01 = 513,
            AtkArrow_07_Gravitation_00_00 = 514,
            AtkArrow_07_Gravitation_00_01 = 515,
            AtkArrow0_08_00_00 = 516,
            AtkArrow0_08_00_01 = 517,
            LandBomb = 600,
            AtkBomb0_01_00_00 = 601,
            AtkBomb0_02_00_00 = 602,
            AtkBomb0_03_00_00 = 603,
            AtkBomb0_04_00_00 = 604,
            AtkBomb0_05_00_00 = 605,
            AtkBomb0_06_00_00 = 606,
            AtkBomb0_07_00_00 = 607,
            AtkBomb0_08_00_00 = 608,
            AtkBomb0_09_00_00 = 609,
            AtkBomb0_10_00_00 = 610,
            AtkBomb0_11_00_00 = 611,
            AtkBomb0_12_00_00 = 612,
            AtkBomb0_13_00_00 = 613,
            AtkBomb0_14_00_00 = 614,
            AtkBomb0_15_00_00 = 615,
            AtkBomb0_16_00_00 = 616,
            AtkBomb0_17_00_00 = 617,
            Dash1 = 700,
            Dash2 = 701,
            AtkDash0_01_00_00 = 702,
            AtkDash0_01_00_01 = 703,
            AtkDash0_02_00_00 = 704,
            AtkDash0_02_00_01 = 705,
            AtkDash0_03_00_00 = 706,
            AtkDash0_03_00_01 = 707,
            AtkDash0_04_00_00 = 708,
            AtkDash0_04_00_01 = 709,
            AtkDash0_05_00_00 = 710,
            AtkDash0_05_00_01 = 711,
            AtkDash0_06_00_00 = 712,
            AtkDash0_06_00_01 = 713,
            AtkThunder0_00_00_00 = 800,
            AtkThunder0_01_00_00 = 801,
            AtkThunder0_02_00_00 = 802,
            AtkThunder0_03_00_00 = 803,
            AtkThunder0_04_00_00 = 804,
            AtkThunder0_05_00_00 = 805,
            AtkThunder0_06_00_00 = 806,
            AtkThunder0_07_00_00 = 807,
            AtkKick_00_NoAttribute_00_00 = 900,
            AtkKick_00_NoAttribute_00_01 = 901,
            AtkKick_01_NoAttribute_01_00 = 902,
            AtkKick_01_NoAttribute_01_01 = 903,
            AtkKick_02_Wind_00_00 = 904,
            AtkKick_02_Wind_00_01 = 905,
            AtkKick_03_Wind_01_00 = 906,
            AtkKick_03_Wind_01_01 = 907,
            AtkKick_04_Sound_00_00 = 908,
            AtkKick_04_Sound_00_01 = 909,
            AtkKick_05_Sound_01_00 = 910,
            AtkKick_05_Sound_01_01 = 911,
            AtkKick_06_Fire_00_00 = 912,
            AtkKick_06_Fire_00_01 = 913,
            AtkKick_07_Fire_00_02 = 922,
            AtkKick_07_Fire_01_00 = 914,
            AtkKick_07_Fire_01_01 = 915,
            AtkKick_07_Fire_01_02 = 923,
            AtkKick_08_Noise_00_00 = 916,
            AtkKick_08_Noise_00_01 = 917,
            AtkKick_08_Noise_00_02 = 918,
            AtkKick_08_Noise_00_03 = 919,
            AtkKick_pair00_Light_00_00 = 920,
            AtkKick_pair00_Light_00_01 = 921,
            AtkFall0_00_00_00 = 1000,
            AtkFall0_01_00_00 = 1001,
            AtkFall0_02_00_00 = 1002,
            AtkFall0_02_00_01 = 1003,
            AtkFall0_03_00_00 = 1004,
            AtkFall0_04_00_00 = 1005,
            AtkFall0_05_00_00 = 1006,
            AtkFall0_05_00_01 = 1007,
            AtkFall_06_Noise_00_00 = 1008,
            AtkFall_07_scrap_00_00 = 1009,
            AtkFall_08_scrap_01_00 = 1010,
            AtkFall_09_scrap_02_00 = 1011,
            AtkFall_pair00_Fire_00_00 = 1012,
            AtkUpper_00_Ice_00 = 1100,
            AtkUpper0_01_00_00 = 1101,
            AtkUpper0_02_00_00 = 1102,
            AtkUpper_03_Rock_00_00 = 1103,
            AtkUpper_04_Rock_01_00 = 1104,
            AtkUpper_05_Fire_00_00 = 1105,
            AtkUpper0_06_00_00 = 1106,
            AtkUpper0_07_00_00 = 1107,
            AtkUpper_08_Noise_00_00 = 1108,
            AtkUpper_pair00_Scrap_00_00 = 1109,
            Napalm = 1200,
            AtkNpm0_01_00_00 = 1201,
            AtkNpm0_02_00_00 = 1202,
            AtkNpm0_03_00_00 = 1203,
            AtkNpm0_04_00_00 = 1204,
            AtkNpm0_05_00_00 = 1205,
            AtkNpm0_06_00_00 = 1206,
            AtkNpm0_07_00_00 = 1207,
            AtkNpm0_08_00_00 = 1208,
            AtkNpm0_09_00_00 = 1209,
            AtkLWire_00_NoAttribute_00_00 = 1300,
            AtkLWire_01_NoAttribute_01_00 = 1301,
            AtkLWire_02_Fire_00_00 = 1302,
            AtkLWire_03_Fire_01_00 = 1303,
            AtkLWire_04_Ice_00_00 = 1304,
            AtkLWire_05_Ice_01_00 = 1305,
            AtkLWire_06_Thunder_00_00 = 1306,
            AtkLWire_07_Thunder_01_00 = 1307,
            AtkLWire_08_Poison_00_00 = 1308,
            AtkLWire_09_Time_00_00 = 1309,
            AtkLWire_10_NoAttribute_02_00 = 1310,
            AtkLWire_11_NoAttribute_03_00 = 1311,
            AtkLWire_12_Poison_01_00 = 1312,
            AtkLWire_13_Light_00_00 = 1313,
            AtkLWire_14_Noise_00_00 = 1314,
            AtkBmr_00_NoAttribute_00 = 1400,
            AtkBmr_01_NoAttribute_01 = 1401,
            AtkBmr_02_KeepOut_Yellow = 1402,
            AtkBmr_02_Gear_big = 1403,
            AtkBmr_02_Pipe = 1404,
            AtkBmr_03_KeepOut_Yellow = 1405,
            AtkBmr_03_Gear_big = 1406,
            AtkBmr_03_Pipe = 1407,
            AtkBmr_03_Dustbox = 1408,
            AtkBmr_03_Gear = 1409,
            AtkBmr_04_Gravitation_00 = 1410,
            AtkBmr_05_Gravitation_01 = 1411,
            AtkBmr_06_Ice_00 = 1412,
            AtkBmr_07_Noise_00 = 1413,
            AtkBmr_pair00_Explosion_00_00 = 1414,
            AtkBmr_pair00_Explosion_00_01 = 1415,
            AtkSnpr2_00_Explosion_00_00 = 1500,
            AtkSnpr2_01_Explosion_01_00 = 1501,
            AtkSnpr2_02_Sound_00_00 = 1502,
            AtkSnpr2_03_Water_00_00 = 1503,
            AtkSnpr2_04_Water_01_00 = 1504,
            AtkSnpr2_05_Dark_00_00 = 1505,
            AtkSnpr2_06_Dark_01_00 = 1506,
            AtkSnpr2_07_NoAttribute_00_00 = 1507,
            AtkSnpr2_08_NoAttribute_01_00 = 1508,
            AtkSnpr2_09_Chain_00_00 = 1509,
            AtkSnpr2_10_Chain_01_00 = 1510,
            AtkSnpr2_11_Poison_00_00 = 1511,
            AtkFish0_00_00_00 = 1700,
            AtkFish0_00_00_01 = 1701,
            AtkFish0_01_00_00 = 1702,
            AtkFish0_01_00_01 = 1703,
            AtkFish0_02_00_00 = 1704,
            AtkFish0_02_00_01 = 1705,
            AtkFish0_03_00_00 = 1706,
            AtkFish0_03_00_01 = 1707,
            AtkFish0_04_00_00 = 1708,
            AtkFish0_04_00_01 = 1709,
            AtkFish0_05_00_00 = 1710,
            AtkFish0_05_00_01 = 1711,
            AtkFish0_06_00_00 = 1712,
            AtkFish0_06_00_01 = 1713,
            AtkFish0_07_00_00 = 1714,
            AtkFish0_07_00_01 = 1715,
            AtkFish0_08_00_00 = 1716,
            AtkFish0_08_00_01 = 1717,
            AtkFish0_09_00_00 = 1718,
            AtkFish0_09_00_01 = 1719,
            AtkFish1_00_00_00 = 1720,
            AtkFish1_00_00_01 = 1721,
            AtkFish1_01_00_00 = 1722,
            AtkFish1_01_00_01 = 1723,
            AtkFish1_02_00_00 = 1724,
            AtkFish1_02_00_01 = 1725,
            AtkFish1_03_00_00 = 1726,
            AtkFish1_03_00_01 = 1727,
            AtkFish0_10_00_00 = 1728,
            AtkFish0_10_00_01 = 1729,
            AtkFish1_04_00_00 = 1730,
            AtkFish1_04_00_01 = 1731,
            AtkLaser_00_Light_00_00 = 1800,
            AtkLaser_01_Light_01_00 = 1801,
            AtkLaser_02_Thunder_00_00 = 1802,
            AtkLaser0_03_00_00 = 1803,
            AtkLaser0_04_00_00 = 1804,
            AtkLaser0_05_00_00 = 1805,
            AtkLaser0_06_00_00 = 1806,
            AtkLaser_07_Ice_02_00 = 1807,
            AtkLaser_08_Gravitation_00 = 1808,
            AtkLaser_09_Dark_00 = 1809,
            AtkLaser_10_Noise_00 = 1810,
            AtkChanneling_00_Fire_00_00 = 1900,
            AtkChanneling_01_Fire_01_00 = 1901,
            AtkChanneling_02_ChaseFire_00_00 = 1902,
            AtkChanneling_03_ChaseFire_01_00 = 1903,
            AtkChanneling_04_Thunder_00_00 = 1904,
            AtkChanneling_05_Thunder_01_00 = 1905,
            AtkChanneling_06_Rock_00_00 = 1906,
            AtkChanneling_07_Gravitation_00_00 = 1907,
            AtkChanneling_08_Gravitation_01_00 = 1908,
            AtkChanneling_09_Gravitation_02_00 = 1909,
            AtkChanneling_10_NoAttribute_00_00 = 1910,
            AtkChanneling_11_Noise_00_00 = 1911,
            AtkBlackHole = 1912,
            AtkBlackHole_01_00_00 = 1913,
            AtkBlackHole_02_00_00 = 1914,
            AtkBlackHole_03_00_00 = 1915,
            AtkBlackHole_04_00_00 = 1916,
            AtkBlackHole_05_00_00 = 1917,
            AtkChanneling_pair00_Dark_00_00 = 1918,
            AtkTornado0_00_00_00 = 2000,
            AtkTornado0_01_00_00 = 2001,
            AtkTornado0_02_00_00 = 2002,
            AtkTornado0_03_00_00 = 2003,
            AtkTornado0_04_00_00 = 2004,
            AtkTornado0_05_00_00 = 2005,
            AtkTackle0_00_00_00 = 2200,
            AtkTackle0_01_00_00 = 2201,
            AtkTackle_02_Thunder_00_00 = 2202,
            AtkTackle_03_Thunder_01_00 = 2203,
            AtkTackle_04_Fire_00_00 = 2204,
            AtkTackle_05_Fire_01_00 = 2205,
            AtkTackle_06_Explosion_00_00 = 2206,
            AtkTackle_07_Noise_00_00 = 2207,
            AtkSpeaker0_00_00 = 2300,
            AtkSpeaker0_01_00 = 2301,
            AtkSpeaker0_02_00 = 2302,
            AtkSpeaker0_03_00 = 2303,
            AtkSpeaker0_04_00 = 2304,
            AtkSpeaker0_05_00 = 2305,
            AtkSpeaker0_06_00 = 2306,
            AtkSpeaker0_07_00 = 2307,
            AtkSpeaker0_08_00 = 2308,
            AtkSpeaker0_09_00 = 2309,
            AtkSpeaker0_10_00 = 2310,
            AtkSpeaker0_11_00 = 2311,
            AtkSpeaker1_00_00 = 2312,
            AtkSpeaker1_01_00 = 2313,
            AtkSpeaker1_02_00 = 2314,
            AtkSpeaker1_03_00 = 2315,
            AtkSpeaker1_04_00 = 2316,
            AtkSpeaker1_05_00 = 2317,
            AtkSpeaker1_06_00 = 2318,
            AtkPsyK_00_Scrap_00_00 = 2400,
            AtkPsyK_01_Scrap_01_00 = 2401,
            AtkPsyK_02_Scrap_02_00 = 2402,
            AtkPsyK_03_Scrap_03_00 = 2403,
            AtkPsyK_04_Noise_00_00 = 2404,
            AtkPsyK_05_Scrap_04_00 = 2405,
            AtkBranchLaser0_00_00_00 = 2500,
            AtkBranchLaser0_01_00_00 = 2501,
            AtkBranchLaser0_02_00_00 = 2502,
            AtkBranchLaser0_03_00_00 = 2503,
            AtkBranchLaser0_04_00_00 = 2504,
            AtkBranchLaser0_05_00_00 = 2505,
            AtkBranchLaser0_06_00_00 = 2506,
            AtkBranchLaser0_07_00_00 = 2507,
            AtkShotgun_00_NoAttribute_00_00 = 2600,
            AtkShotgun_00_NoAttribute_00_01 = 2601,
            AtkShotgun_01_Gravitation_00_00 = 2602,
            AtkShotgun_01_Gravitation_00_01 = 2603,
            AtkShotgun_02_Time_00_00 = 2604,
            AtkShotgun_02_Time_00_01 = 2605,
            AtkShotgun_03_Ligrt_00_00 = 2606,
            AtkShotgun_03_Ligrt_00_01 = 2607,
            AtkShotgun_04_Dark_00_00 = 2608,
            AtkShotgun_04_Dark_00_01 = 2609,
            AtkShotgun_05_Thunder_00_00 = 2610,
            AtkShotgun_05_Thunder_00_01 = 2611,
            AtkShotgun_pair00_Light_00_00 = 2612,
            AtkShotgun_pair00_Light_00_01 = 2613,
            AtkBlowTrap = 2800,
            AtkBlowTrap0_01_00_00 = 2801,
            AtkBlowTrap0_02_00_00 = 2802,
            AtkBlowTrap0_03_00_00 = 2803,
            AtkBlowTrap0_04_00_00 = 2804,
            AtkBlowTrap0_05_00_00 = 2805,
            AtkBlowTrap0_06_00_00 = 2806,
            AtkDNoise_00_Gravitation_00 = 2900,
            AtkDNoise_01_Gravitation_01 = 2901,
            AtkDNoise_02_Grab_00 = 2902,
            AtkDNoise_03_Grab_01 = 2903,
            AtkDNoise_04_Noise_00 = 2904,
            AtkDNoise_pair00_Grab_00 = 2905,
            AtkDNoise_05_Grab_02 = 2906,
            AtkDNoise_06_Gravitation_02 = 2907,
            LandBomb_Botsu = 8000,
            SpeakerShield = 8001,
            AtkSnpr_00_Explosion_00_00 = 8002,
            Tackle = 8003,
            Speaker = 8004,
            AtkChanneling0_12_00_00 = 8005,
            AtkKick0_00_00_00 = 8006,
            AtkSlash0_00_00_00 = 8007,
            AtkSlash0_00_00_01 = 8008,
            AtkSlash0_00_00_02 = 8009,
            AtkSlash0_01_01_00 = 8010,
            AtkSlash0_01_01_01 = 8011,
            AtkSlash0_01_01_02 = 8012,
            AtkSlash0_02_01_00 = 8013,
            AtkSlash0_02_01_01 = 8014,
            AtkSlash0_02_01_02 = 8015,
            AtkSlash0_04_01_00 = 8016,
            AtkSlash0_04_01_01 = 8017,
            AtkSlash0_04_01_02 = 8018,
            AtkSlash1_00_01_00 = 8019,
            AtkSlash1_00_01_01 = 8020,
            AtkSlash1_00_01_02 = 8021,
            AtkSlash1_00_02_00 = 8022,
            AtkSlash1_00_02_01 = 8023,
            AtkSlash1_00_02_02 = 8024,
            AtkSlash2_01_01_00 = 8025,
            AtkSlash2_01_01_01 = 8026,
            AtkSlash2_01_01_02 = 8027,
            AtkSlash3_00_00_00 = 8028,
            AtkSlash3_00_00_01 = 8029,
            AtkSlash3_00_00_02 = 8030,
            AtkSlash3_00_01_00 = 8031,
            AtkSlash3_00_01_01 = 8032,
            AtkSlash3_00_01_02 = 8033,
            AtkSlash3_01_00_00 = 8034,
            AtkSlash3_01_00_01 = 8035,
            AtkSlash3_01_00_02 = 8036,
            AtkSlash3_01_01_00 = 8037,
            AtkSlash3_01_01_01 = 8038,
            AtkSlash3_01_01_02 = 8039,
            AtkTap0_00_00_00 = 8040,
            AtkTap0_00_00_01 = 8041,
            AtkTap0_00_00_02 = 8042,
            AtkTap0_01_01_00 = 8043,
            AtkTap0_01_01_01 = 8044,
            AtkTap0_01_01_02 = 8045,
            AtkTap0_02_01_00 = 8046,
            AtkTap0_02_01_01 = 8047,
            AtkTap0_02_01_02 = 8048,
            AtkTap0_03_01_00 = 8049,
            AtkTap0_03_01_01 = 8050,
            AtkTap0_03_01_02 = 8051,
            AtkTap0_04_01_00 = 8052,
            AtkTap0_04_01_01 = 8053,
            AtkTap0_04_01_02 = 8054,
            AtkTap0_05_00_00 = 8055,
            AtkTap0_05_00_01 = 8056,
            AtkTap0_05_00_02 = 8057,
            AtkTap1_01_01_00 = 8058,
            AtkTap1_01_01_01 = 8059,
            AtkTap1_01_01_02 = 8060,
            AtkTap1_02_01_00 = 8061,
            AtkTap1_02_01_01 = 8062,
            AtkTap1_02_01_02 = 8063,
            AtkTap1_03_01_00 = 8064,
            AtkTap1_03_01_01 = 8065,
            AtkTap1_03_01_02 = 8066,
            AtkTap2_00_01_00 = 8067,
            AtkTap2_00_01_01 = 8068,
            AtkTap2_00_01_02 = 8069,
            AtkTap2_01_01_00 = 8070,
            AtkTap2_01_01_01 = 8071,
            AtkTap2_01_01_02 = 8072,
            AtkTap2_02_01_00 = 8073,
            AtkTap2_02_01_01 = 8074,
            AtkTap2_02_01_02 = 8075,
            AtkTap3_00_00_00 = 8076,
            AtkTap3_00_00_01 = 8077,
            AtkTap3_00_00_02 = 8078,
            AtkTap3_01_00_00 = 8079,
            AtkTap3_01_00_01 = 8080,
            AtkTap3_01_00_02 = 8081,
            AtkTap3_02_00_00 = 8082,
            AtkTap3_02_00_01 = 8083,
            AtkTap3_02_00_02 = 8084,
            AtkTap3_03_00_00 = 8085,
            AtkTap3_03_00_01 = 8086,
            AtkTap3_03_00_02 = 8087,
            Upper1 = 8088,
            Drag1_1 = 8089,
            Meteor1_1 = 8090,
            Hold1_1 = 8091,
            Hit_10 = 8092,
            Multi1_1 = 8093,
            Object1_1 = 8094,
            Laser1 = 8095,
            Trap = 8096,
            WaterSpray = 8097,
            RollSlash = 8098,
            Hammer = 8099,
            Object3_1 = 8100,
            SearchTrap1_1 = 8101,
            ChargeLaser1_1 = 8102,
            TrackingFire = 8103,
            LoveWire = 8104,
            LoveWireSide = 8105,
            TestSlash1_1 = 8106,
            TestSlash1_2 = 8107,
            TestSlash1_3 = 8108,
            TestTap1_1 = 8109,
            TestTap1_2 = 8110,
            TestTap1_3 = 8111,
            ChargeMeteor1_1 = 8112,
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
            EnemyAttackChameleonDischarge = 10160,
            EnemyAttackChameleonLaser = 10161,
            EnemyAttackChameleonStickyTongue = 10162,
            EnemyAttackChameleonHealField = 10163,
            EnemyAttackChameleonRescue = 10164,
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
            EnemyAttackGorilla11 = 11016,
            EnemyAttackGorilla12 = 11017,
            EnemyAttackGorilla06F = 11018,
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
            EnemyAttackNyanTanS01 = 11040,
            EnemyAttackNyanTanM01 = 12040,
            EnemyAttackNyanTanM02 = 12041,
            EnemyAttackNyanTanM11 = 12042,
            EnemyAttackNyanTanM12 = 12043,
            EnemyAttackNyanTanHuge01 = 11050,
            EnemyAttackNyanTanHuge02 = 11051,
            EnemyAttackTsugumi01 = 11060,
            EnemyAttackTsugumi02 = 11061,
            EnemyAttackTsugumi03 = 11062,
            EnemyAttackTsugumi04 = 11063,
            EnemyAttackTsugumi05 = 11064,
            EnemyAttackTsugumi06 = 11065,
            EnemyAttackTsugumi01A = 11066,
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
            EnemyAttackAnotherAyano03 = 11156,
            EnemyAttackAnotherAyano05 = 11157,
            EnemyAttackAnotherAyano06 = 11158,
            EnemyAttackAnotherAyano13 = 11159,
            EnemyAttackAnotherAyano04 = 11160,
            Invalid = -1,
        }
    }
}
