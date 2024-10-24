using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class Badge
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mItemId")]
        public int ItemId { get; set; }
        [JsonProperty("mBrand")]
        public int Brand { get; set; }
        [JsonProperty("mNameChance")]
        public string BeatdropName { get; set; }
        [JsonProperty("mInfoChance")]
        public string BeatdropDescription { get; set; }
        [JsonProperty("mPsychic")]
        public int Psychic { get; set; }
        [JsonProperty("mPsychicKey")]
        public int Button { get; set; }
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
        public int Growth { get; set; }
        [JsonProperty("mLevelUpRate")]
        public float GrowthRate { get; set; }
        [JsonProperty("mAbility")]
        public IList<int> Abilities { get; set; }
        [JsonProperty("mPairAbility")]
        public int EnsembleAbility { get; set; }
        [JsonProperty("mComboDamage")]
        public int ComboDamage { get; set; }
        [JsonProperty("mAddSellPrice")]
        public int SellPriceScaling { get; set; }
        [JsonProperty("mSellPrice")]
        public int SellPrice { get; set; }
        [JsonProperty("mRarity")]
        public int Uber { get; set; }
        [JsonProperty("mSortIndex")]
        public int SortIndex { get; set; }
        [JsonProperty("mSortPsychic")]
        public int SortPsychic { get; set; }
        [JsonProperty("mBadgeSpriteName")]
        public string SpriteName { get; set; }
        [JsonProperty("mBadgeSpriteAtlas")]
        public string SpriteAtlas { get; set; }
        [JsonProperty("mBadgeClass")]
        public int PinClass { get; set; }
        [JsonProperty("mBadgeCategory")]
        public int PinCategory { get; set; }
        [JsonProperty("mPsychicType")]
        public int PsychicType { get; set; }
        [JsonProperty("mEvolutionLevel")]
        public int EvolutionLevel { get; set; }
        [JsonProperty("mEcolutionCommon")]
        public int EvolutionSingle { get; set; }
        [JsonProperty("mEvolutionBadge")]
        public IList<int> EvolutionList { get; set; }
        [JsonProperty("mChancetimeType")]
        public int BeatdropType { get; set; }
        [JsonProperty("mMashupElement")]
        public int MashUpAffinity { get; set; }
        [JsonProperty("mInfoMovie")]
        public int MovieId { get; set; }
    }
}
