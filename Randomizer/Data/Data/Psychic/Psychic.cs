using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class Psychic
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mPsychicName")]
        public string Name { get; set; }
        [JsonProperty("mCategoryType")]
        public int CategoryType { get; set; }
        [JsonProperty("mDiffSoPath")]
        public string DiffSoPath { get; set; }
        [JsonProperty("mChargeMinTime")]
        public float Charge { get; set; }
        [JsonProperty("mDistance")]
        public float Distance { get; set; }
        [JsonProperty("mDistanceMin")]
        public float DistanceMin { get; set; }
        [JsonProperty("mCameraDistanceOffset")]
        public float CameraDistanceOffset { get; set; }
        [JsonProperty("mCameraRateOffset")]
        public float CameraRateOffset { get; set; }
        [JsonProperty("mCameraRotateAngle")]
        public float CameraRotateAngle { get; set; }
        [JsonProperty("mCameraRotateSpeed")]
        public float CameraRotateSpeed { get; set; }
        [JsonProperty("mAutoMoveSpeedMin")]
        public float AutoMoveSpeedMin { get; set; }
        [JsonProperty("mAutoMoveSpeedMax")]
        public float AutoMoveSpeedMax { get; set; }
        [JsonProperty("mAutoMoveSpeedRate")]
        public float AutoMoveSpeedRate { get; set; }
        [JsonProperty("mManualMoveSpeed")]
        public float ManualMoveSpeed { get; set; }
        [JsonProperty("mGaugeColor")]
        public Color GaugeColor { get; set; }
        [JsonProperty("mMotionVoiceId")]
        public IList<int> MotionVoiceList { get; set; }
        [JsonProperty("mAttackComboSet")]
        public int AttackComboSet { get; set; }
        [JsonProperty("mDisableMoveTime")]
        public float DisableMoveTime { get; set; }
        [JsonProperty("mMotion")]
        public IList<int> MotionList { get; set; }
        [JsonProperty("mBodyAuraEffect")]
        public int BodyAuraEffect { get; set; }
        [JsonProperty("mAuraEffect")]
        public IList<int> AuraEffectList { get; set; }
        [JsonProperty("mAuraAttachNodeName")]
        public IList<string> AuraAttachNodeNameList { get; set; }
        [JsonProperty("mAuraColor")]
        public int AuraColor { get; set; }
        [JsonProperty("mChanceTriggerHitCount")]
        public int ChanceTriggerHitCount { get; set; }
        [JsonProperty("mControllTypeName")]
        public string ControlTypeName { get; set; }
        [JsonProperty("mUseNumType")]
        public int UseNumType { get; set; }
    }
}
