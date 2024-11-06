using System;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class NetworkSettings
    {
        public SkillCost CostChoice { get; set; }
        public SkillRewards RewardsChoice { get; set; }
        public SkillShuffle ShuffleChoice { get; set; }

        public NetworkSettings()
        {
            InitializeDataStructures();
            CorrectSettingValues();
        }

        private void InitializeDataStructures()
        {
            
        }

        public void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(SkillCost), CostChoice)) CostChoice = SkillCost.Unchanged;
            if (!Enum.IsDefined(typeof(SkillRewards), RewardsChoice)) RewardsChoice = SkillRewards.Unchanged;
            if (!Enum.IsDefined(typeof(SkillShuffle), ShuffleChoice)) ShuffleChoice = SkillShuffle.Unchanged;
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            CostChoice = (SkillCost)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "skill_cost_category");
            RewardsChoice = (SkillRewards)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "skill_rewards_category");
            ShuffleChoice = (SkillShuffle)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "skill_shuffle_category");
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "skill_cost_category", (uint)CostChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "skill_rewards_category", (uint)RewardsChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "skill_shuffle_category", (uint)ShuffleChoice);

            return currentString;
        }
    }
}
