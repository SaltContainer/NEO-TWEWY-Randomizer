using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class AttackHit
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mBullet")]
        public int Bullet { get; set; }
        [JsonProperty("mPower")]
        public float Power { get; set; }
        [JsonProperty("mGainHate")]
        public int GainHate { get; set; }
        [JsonProperty("mHitTargetType")]
        public int HitTargetType { get; set; }
        [JsonProperty("mHitAirGroundType")]
        public int HitAirGroundType { get; set; }
        [JsonProperty("mHitCount")]
        public int HitCount { get; set; }
        [JsonProperty("mHitInterval")]
        public float HitInterval { get; set; }
        [JsonProperty("mColAttach")]
        public int ColAttach { get; set; }
        [JsonProperty("mColAttachTarget")]
        public string ColAttachTarget { get; set; }
        [JsonProperty("mColType")]
        public int ColType { get; set; }
        [JsonProperty("mColRadius")]
        public float ColRadius { get; set; }
        [JsonProperty("mColParam")]
        public IList<float> ColParam { get; set; }
        [JsonProperty("mHitStopDelay")]
        public float HitStopDelay { get; set; }
        [JsonProperty("mHitStopTime")]
        public float HitStopTime { get; set; }
        [JsonProperty("mHitStopTarget")]
        public int HitStopTarget { get; set; }
        [JsonProperty("mBlowDirectType")]
        public int BlowDirectType { get; set; }
        [JsonProperty("mBlowType")]
        public int BlowType { get; set; }
        [JsonProperty("mBlowSpeed")]
        public float BlowSpeed { get; set; }
        [JsonProperty("mBlowAngle")]
        public int BlowAngle { get; set; }
        [JsonProperty("mCameraShake")]
        public int CameraShake { get; set; }
        [JsonProperty("mHitVibration")]
        public int HitVibration { get; set; }
        [JsonProperty("mHitEffect")]
        public int HitEffect { get; set; }
        [JsonProperty("mCrackEffect")]
        public int CrackEffect { get; set; }
        [JsonProperty("mCrackEffectScale")]
        public float CrackEffectScale { get; set; }
        [JsonProperty("mHitSe")]
        public int HitSe { get; set; }
        [JsonProperty("mEnchant")]
        public IList<int> EnchantList { get; set; }
        [JsonProperty("mEnchantInfectionRate")]
        public IList<float> EnchantInfectionRateList { get; set; }
        [JsonProperty("mElement")]
        public IList<int> Affinity { get; set; }
        [JsonProperty("mChanceType")]
        public int ChanceType { get; set; }
        [JsonProperty("mDiseaseSyncroDamageRate")]
        public int DiseaseSyncroDamageRate { get; set; }
        [JsonProperty("mIsReleasedBySpecialAttack")]
        public bool IsReleasedBySpecialAttack { get; set; }
        [JsonProperty("mAttackIgnoreInvincibilityType")]
        public int AttackIgnoreInvincibilityType { get; set; }
        [JsonProperty("mPsychicShieldVaidityRate")]
        public int PsychicShieldVaidityRate { get; set; }
    }
}
