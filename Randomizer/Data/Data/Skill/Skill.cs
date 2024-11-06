using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class Skill
    {
        [JsonProperty("mId")]
        public Label Id { get; set; }
        [JsonProperty("mName")]
        public string Name { get; set; }
        [JsonProperty("mInfo")]
        public string Info { get; set; }
        [JsonProperty("mPoint")]
        public int Point { get; set; }
        [JsonProperty("mParameter")]
        public IList<float> Parameter { get; set; }
        [JsonProperty("mShopReward")]
        public AllItemsLabel ShopReward { get; set; }
        [JsonProperty("mDialogImage")]
        public string DialogImage { get; set; }
        [JsonProperty("mSaveIndex")]
        public int SaveIndex { get; set; }

        public enum Label : int
        {
            Difficulty_Easy = 0,
            Difficulty_Hard = 1,
            Difficulty_Ultimate = 2,
            BattleMenu_BadgeRetry = 3,
            Level_DropRate_00 = 4,
            Level_DropRate_01 = 5,
            Level_HPBonus_00 = 6,
            Level_HPBonus_01 = 7,
            Battle_HPGaugeDisp = 8,
            Battle_DodgeRoll = 9,
            Battle_BlowCancel = 10,
            Scan_ChainUp_00 = 11,
            Scan_ChainUp_01 = 12,
            Scan_ChainUp_02 = 13,
            Scan_RareUp = 14,
            Scan_RareMoveDown = 15,
            Scan_NoiseAttract_00 = 16,
            Scan_NoiseAttract_01 = 17,
            Synchro_JustCombo_NM = 18,
            Synchro_JustCombo_SN = 19,
            Synchro_JustCombo_RF = 20,
            Synchro_JustCombo_BN = 21,
            Synchro_JustCombo_RN = 22,
            Synchro_JustCombo_RS = 23,
            Synchro_JustCombo_FB = 24,
            Bland_BadgeUp = 25,
            Food_Favorite = 26,
            Money_Wallet_00 = 27,
            Money_Wallet_01 = 28,
            Sell_Bonus_00 = 29,
            Sell_Bonus_01 = 30,
            Badge_Evolution = 31,
            Badge_SameEquip_00 = 32,
            Badge_GodBadge_00 = 33,
            Badge_GodBadge_01 = 34,
            Badge_GodBadge_02 = 35,
            Badge_GodBadge_03 = 36,
            Badge_GodBadge_04 = 37,
            Badge_GodBadge_05 = 38,
            Dive_Timer_00 = 39,
            Dive_Timer_01 = 40,
            Enable_BossNoise = 41,
            Pig_ChapterDisp = 42,
            Pig_AreaDisp = 43,
            MusicSync_EffectUp = 44,
            Field_OneHandBold = 45,
            Money_AutoCharge = 46,
            Synchro_BonusArea = 47,
            Menu_LeaveCoordinate = 48,
            Menu_BadgeBulkSale = 49,
            Menu_BadgeDeck_00 = 50,
            Menu_BadgeDeck_01 = 51,
            Shop_ItemRelease_Shop01 = 52,
            Shop_ItemRelease_Shop02 = 53,
            Shop_ItemRelease_Shop03 = 54,
            Shop_ItemRelease_Shop07 = 55,
            Shop_ItemRelease_Shop08 = 56,
            Shop_ItemRelease_Shop10 = 57,
            Shop_ItemRelease_Shop11 = 58,
            Shop_ItemRelease_Shop12 = 59,
            Shop_ItemRelease_Shop13 = 60,
            Shop_ItemRelease_Shop14 = 61,
            Shop_ItemRelease_Shop15 = 62,
            Shop_ItemRelease_Shop19 = 63,
            Shop_ItemRelease_Shop20 = 64,
            Shop_ItemRelease_Shop21 = 65,
            Shop_ItemRelease_Shop22 = 66,
            Shop_ItemRelease_Shop23 = 67,
            Shop_ItemRelease_Shop24 = 68,
            Shop_ItemRelease_Shop04 = 69,
            Shop_ItemRelease_Shop05 = 70,
            Shop_ItemRelease_Shop06 = 71,
            Shop_ItemRelease_Shop16 = 72,
            Shop_ItemRelease_Shop17 = 73,
            Shop_ItemRelease_Shop18 = 74,
            Shop_ItemRelease_Shop25 = 75,
            Shop_ItemRelease_Shop26 = 76,
            Shop_ItemRelease_Shop27 = 77,
            Shop_ItemRelease_Shop28 = 78,
            Shop_ItemRelease_Shop29 = 79,
            Shop_ItemRelease_Shop35 = 80,
            Shop_ItemRelease_Shop36 = 81,
            Shop_ItemRelease_Shop37 = 82,
            Shop_ItemRelease_Shop40 = 83,
            Shop_ItemRelease_Shop41 = 84,
            Shop_ItemRelease_Shop42 = 85,
            Shop_ItemRelease_Shop43 = 86,
            Shop_ItemRelease_Shop44 = 87,
            Shop_ItemRelease_Shop45 = 88,
            Shop_ItemRelease_Shop46 = 89,
            Shop_ItemRelease_Shop30 = 90,
            Shop_ItemRelease_Shop31 = 91,
            Shop_ItemRelease_Shop32 = 92,
            Shop_ItemRelease_Shop33 = 93,
            Shop_ItemRelease_Shop47 = 94,
            Shop_ItemRelease_Shop38 = 95,
            Shop_ItemRelease_Shop39 = 96,
            Shop_ItemRelease_Shop34 = 97,
            Badge_SameEquip_01 = 98,
            Invalid = -1,
        }
    }
}
