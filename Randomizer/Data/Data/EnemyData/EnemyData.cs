using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class EnemyData
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mClass")]
        public int Class { get; set; }
        [JsonProperty("mType")]
        public int Type { get; set; }
        [JsonProperty("mTypeVersion")]
        public int TypeVersion { get; set; }
        [JsonProperty("mSoFileName")]
        public string SoFileName { get; set; }
        [JsonProperty("mResourceData")]
        public int ResourceData { get; set; }
        [JsonProperty("mBaseParam")]
        public int BaseParam { get; set; }
        [JsonProperty("mAttack")]
        public IList<int> Attack { get; set; }
        [JsonProperty("mAttackWeightEasy")]
        public IList<float> AttackWeightEasy { get; set; }
        [JsonProperty("mAttackWeightNormal")]
        public IList<float> AttackWeightNormal { get; set; }
        [JsonProperty("mAttackWeightHard")]
        public IList<float> AttackWeightHard { get; set; }
        [JsonProperty("mAttackWeightUltimate")]
        public IList<float> AttackWeightUltimate { get; set; }
        [JsonProperty("mShacHateGaugeMax")]
        public int ShacHateGaugeMax { get; set; }
        [JsonProperty("mShacTriggerLine")]
        public int ShacTriggerLine { get; set; }
        [JsonProperty("mShacAttackIndex")]
        public int ShacAttackIndex { get; set; }
        [JsonProperty("mShacStateName")]
        public string ShacStateName { get; set; }
        [JsonProperty("mSightAngle")]
        public int SightAngle { get; set; }
        [JsonProperty("mScale")]
        public float Scale { get; set; }
        [JsonProperty("mExp")]
        public int Exp { get; set; }
        [JsonProperty("mBp")]
        public int Bp { get; set; }
        [JsonProperty("mBattleTime")]
        public float BattleTime { get; set; }
        [JsonProperty("mParam")]
        public IList<int> Param { get; set; }
        [JsonProperty("mBlowedColRadius")]
        public float BlowedColRadius { get; set; }
        [JsonProperty("mDesperateSe")]
        public int DesperateSe { get; set; }
        [JsonProperty("mEscapeSe")]
        public int EscapeSe { get; set; }
        [JsonProperty("mDesperateVoice")]
        public int DesperateVoice { get; set; }
        [JsonProperty("mDrop")]
        public IList<int> Drop { get; set; }
        [JsonProperty("mDropRate")]
        public IList<float> DropRate { get; set; }
        [JsonProperty("mDynamicBoneFps")]
        public int DynamicBoneFps { get; set; }
        [JsonProperty("mDynamicBoneDistance")]
        public int DynamicBoneDistance { get; set; }
        [JsonProperty("mDiseaseSyncroUpRate")]
        public int DiseaseSyncroUpRate { get; set; }
        [JsonProperty("mDiseaseDamageCutRate")]
        public int DiseaseDamageCutRate { get; set; }
        [JsonProperty("mLevel")]
        public int Level { get; set; }
        [JsonProperty("mResultCp")]
        public int ResultCp { get; set; }
    }
}
