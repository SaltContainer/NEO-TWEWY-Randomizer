using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class EnemyData
    {
        [JsonProperty("mId")]
        public Name Id { get; set; }
        [JsonProperty("mClass")]
        public EnemyClass Class { get; set; }
        [JsonProperty("mType")]
        public EnemyTypeLabel Type { get; set; }
        [JsonProperty("mTypeVersion")]
        public uint TypeVersion { get; set; }
        [JsonProperty("mSoFileName")]
        public string SoFileName { get; set; }
        [JsonProperty("mResourceData")]
        public EnemyResourceDataLabel ResourceData { get; set; }
        [JsonProperty("mBaseParam")]
        public BattleCharacterLabel BaseParam { get; set; }
        [JsonProperty("mAttack")]
        public IList<EnemyAttackName> Attack { get; set; }
        [JsonProperty("mAttackWeightEasy")]
        public IList<float> AttackWeightEasy { get; set; }
        [JsonProperty("mAttackWeightNormal")]
        public IList<float> AttackWeightNormal { get; set; }
        [JsonProperty("mAttackWeightHard")]
        public IList<float> AttackWeightHard { get; set; }
        [JsonProperty("mAttackWeightUltimate")]
        public IList<float> AttackWeightUltimate { get; set; }
        [JsonProperty("mShacHateGaugeMax")]
        public float ShacHateGaugeMax { get; set; }
        [JsonProperty("mShacTriggerLine")]
        public float ShacTriggerLine { get; set; }
        [JsonProperty("mShacAttackIndex")]
        public int ShacAttackIndex { get; set; }
        [JsonProperty("mShacStateName")]
        public string ShacStateName { get; set; }
        [JsonProperty("mSightAngle")]
        public float SightAngle { get; set; }
        [JsonProperty("mScale")]
        public float Scale { get; set; }
        [JsonProperty("mExp")]
        public uint Exp { get; set; }
        [JsonProperty("mBp")]
        public uint Bp { get; set; }
        [JsonProperty("mBattleTime")]
        public float BattleTime { get; set; }
        [JsonProperty("mParam")]
        public IList<float> Param { get; set; }
        [JsonProperty("mBlowedColRadius")]
        public float BlowedColRadius { get; set; }
        [JsonProperty("mDesperateSe")]
        public SeLabelLabel DesperateSe { get; set; }
        [JsonProperty("mEscapeSe")]
        public SeLabelLabel EscapeSe { get; set; }
        [JsonProperty("mDesperateVoice")]
        public VoiceLabelLabel DesperateVoice { get; set; }
        [JsonProperty("mDrop")]
        public IList<Badge.Label> Drop { get; set; }
        [JsonProperty("mDropRate")]
        public IList<float> DropRate { get; set; }
        [JsonProperty("mDynamicBoneFps")]
        public float DynamicBoneFps { get; set; }
        [JsonProperty("mDynamicBoneDistance")]
        public float DynamicBoneDistance { get; set; }
        [JsonProperty("mDiseaseSyncroUpRate")]
        public float DiseaseSyncroUpRate { get; set; }
        [JsonProperty("mDiseaseDamageCutRate")]
        public float DiseaseDamageCutRate { get; set; }
        [JsonProperty("mLevel")]
        public int Level { get; set; }
        [JsonProperty("mResultCp")]
        public uint ResultCp { get; set; }

        public enum Name : int
        {
            Bear = 100,
            Bear1 = 101,
            Bear2 = 102,
            Bear_tutorial1w2d = 103,
            Bear_silver = 190,
            Bear_silver1 = 191,
            Bear_shiiba = 192,
            Crow = 200,
            Crow1 = 201,
            Crow2 = 202,
            Crow_sskc = 203,
            Crow_shiiba = 204,
            Frog = 300,
            Frog1 = 301,
            Frog2 = 302,
            Frog3 = 303,
            Frog_silver = 390,
            Frog_silver3w1d = 391,
            Frog_sskc = 392,
            Wolf = 400,
            Wolf1 = 401,
            Wolf2 = 402,
            Wolf_silver = 490,
            Wolf_silver1 = 491,
            Wolf_shiiba = 492,
            JellyFish = 600,
            JellyFish00_Child = 601,
            JellyFish1 = 610,
            JellyFish01_Child = 611,
            JellyFish2 = 620,
            JellyFish02_Child = 621,
            JellyFish3 = 630,
            JellyFish3_Child = 631,
            JellyFish_silver = 690,
            JellyFish_silver3w4d = 691,
            Rhino = 700,
            Rhino1 = 701,
            Rhino2 = 702,
            Shark = 800,
            Shark1 = 801,
            Shark2 = 802,
            Elephant = 900,
            Elephant1 = 901,
            Elephant2 = 902,
            Elephant2w4d = 910,
            Elephant_silver = 990,
            Elephant_silver3w5d = 991,
            Gorilla = 10100,
            FTAGorilla = 610100,
            Porcupinefish = 1400,
            Porcupinefish01 = 1401,
            Porcupinefish02 = 1402,
            Porcupinefish03 = 1403,
            Porcupinefish1w4d = 1410,
            Porcupinefish_Asskc = 1420,
            Scorpion00 = 1500,
            Scorpion01 = 1501,
            Scorpion02 = 1502,
            Scorpion021w1d = 1510,
            Scorpion_silver = 1590,
            Scorpion_silver3w3d = 1591,
            Scorpion_silver1 = 1592,
            Penguin = 1000,
            Penguin1 = 1001,
            Penguin2 = 1002,
            Tyranno00 = 1800,
            Tyranno1 = 1801,
            Tyranno2 = 1802,
            Tyranno2w5d = 1810,
            Chameleon00 = 1600,
            Chameleon01 = 1601,
            Chameleon02 = 1602,
            Chameleon012w1d = 1610,
            Fuuya = 10200,
            FTAFuuya = 610200,
            PsychicerA00 = 20000,
            PsychicerA01 = 20001,
            PsychicerA02 = 20002,
            PsychicerA03 = 20003,
            PsychicerA04 = 20004,
            PsychicerA05 = 20005,
            PsychicerA100 = 20010,
            PsychicerA101 = 20011,
            PsychicerA102 = 20012,
            PsychicerA103 = 20013,
            PsychicerA104 = 20014,
            PsychicerA105 = 20015,
            FTAPsychicerA00 = 620000,
            FTAPsychicerA01 = 620001,
            FTAPsychicerA02 = 620002,
            FTAPsychicerA03 = 620003,
            FTAPsychicerA04 = 620004,
            FTAPsychicerA05 = 620005,
            Motoi = 100000,
            FTAMotoi = 6100000,
            PsychicerB00_A = 21000,
            PsychicerB01_A = 21001,
            PsychicerB02_A = 21002,
            PsychicerB03_A = 21003,
            PsychicerB04_A = 21004,
            PsychicerB05_A = 21005,
            FTAPsychicerB00_A = 621000,
            FTAPsychicerB01_A = 621001,
            FTAPsychicerB02_A = 621002,
            FTAPsychicerB03_A = 621003,
            FTAPsychicerB04_A = 621004,
            FTAPsychicerB05_A = 621005,
            PsychicerB100 = 21100,
            PsychicerB101 = 21101,
            PsychicerB102 = 21102,
            PsychicerB103 = 21103,
            PsychicerB104 = 21104,
            PsychicerB105 = 21105,
            PsychicerC00 = 22000,
            PsychicerC01 = 22001,
            PsychicerC02 = 22002,
            PsychicerC03 = 22003,
            PsychicerC04 = 22004,
            PsychicerC05 = 22005,
            PsychicerC100 = 22100,
            PsychicerC101 = 22101,
            PsychicerC102 = 22102,
            PsychicerC103 = 22103,
            PsychicerC104 = 22104,
            PsychicerC105 = 22105,
            Susukichi = 10300,
            Susukichi02 = 10301,
            FTASusukichi = 610301,
            NyanTan = 10400,
            NyanTanBig = 10401,
            NyanTanHuge = 10500,
            NyanTan_2 = 10450,
            NyanTanBig_2 = 10451,
            NyanTanHuge_2 = 10550,
            FTANyanTan = 610400,
            FTANyanTanBig = 610401,
            FTANyanTanHuge = 610402,
            Tsugumi = 10600,
            TsugumiTrailer = 10601,
            TsugumiAnother = 510600,
            TsugumiAnotherTrailer = 510601,
            FTATsugumi = 610600,
            FTATsugumiTrailer = 610601,
            Ayame = 10700,
            AyameCrucifixionTable = 10701,
            AyameAnother = 510700,
            AyameAnotherCrucifixionTable = 510701,
            FTAAyame = 610700,
            FTAAyameCrucifixionTable = 610701,
            Minamimoto = 10800,
            MinamimotoAnother = 510800,
            FTAMinamimoto = 610800,
            SusukichiNoise = 10900,
            SusukichiNoiseBig = 10901,
            SusukichiNoiseObstacle01 = 10910,
            SusukichiNoiseObstacle02 = 10911,
            SusukichiNoiseObstacle03 = 10912,
            SusukichiNoiseObstacle04 = 10913,
            SusukichiNoiseAnother = 510900,
            FTASusukichiNoise = 610900,
            FTASusukichiNoiseBig = 610901,
            Shiiba = 11100,
            Shiiba_S = 11101,
            Shiiba_C = 11102,
            Shiiba_S_C = 11103,
            ShiibaBullet = 11105,
            Shiiba_F_C_00 = 11110,
            Shiiba_F_C_01 = 11111,
            Shiiba_F_C_02 = 11112,
            Shiiba_F_C_03 = 11113,
            Shiiba_F_C_04 = 11114,
            Shiiba_F_C_05 = 11115,
            Shiiba_F_C_06 = 11116,
            ShiibaAnother_S = 511101,
            ShiibaAnother_S_C = 511103,
            ShiibaAnother_F_C_00 = 511104,
            ShiibaAnotherBullet = 511105,
            ShiibaAnother_F_C_01 = 511106,
            ShiibaAnother_F_C_02 = 511107,
            ShiibaAnother_F_C_03 = 511108,
            ShiibaAnother_F_C_04 = 511109,
            ShiibaAnother_F_C_05 = 511110,
            ShiibaAnother_F_C_06 = 511111,
            FTAShiiba = 611100,
            FTAShiiba_S = 611101,
            FTAShiiba_C = 611102,
            FTAShiiba_S_C = 611103,
            FTAShiiba_F_C_00 = 611104,
            FTAShiibaBullet = 611105,
            FTAShiiba_F_C_01 = 611106,
            FTAShiiba_F_C_02 = 611107,
            FTAShiiba_F_C_03 = 611108,
            FTAShiiba_F_C_04 = 611109,
            FTAShiiba_F_C_05 = 611110,
            FTAShiiba_F_C_06 = 611111,
            ReplayNoise = 11200,
            Phoenix = 11300,
            PhoenixTail = 11400,
            PhoenixGateTail = 11500,
            FTAPhoenix = 611300,
            FTAPhoenixTail = 611400,
            FTAPhoenixGateTail = 611500,
            PigPink00ED = 200000,
            PigKing00ED = 200001,
            PigArrow00ED = 200002,
            PigRed00ED = 200003,
            PigBlue00ED = 200004,
            PigYellow00ED = 200005,
            PigHornBlack00ED = 200006,
            PigHornWhite00ED = 200007,
            PigSizeBig00ED = 200008,
            PigSizeNormal00ED = 200009,
            PigSizeSmall00ED = 200010,
            PigGoldFake00ED = 200011,
            PigGold00ED = 200012,
            PigGoldFuuya00ED = 200013,
            Invalid = -1,
        }
    }
}
