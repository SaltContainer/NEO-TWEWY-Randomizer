using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class StoryRewardSettings
    {
        public StoryPin StoryPinChoice { get; set; }
        public bool IncludeLimitedPins { get; set; }
        public StoryYen StoryYenChoice { get; set; }
        public StoryGem StoryGemChoice { get; set; }
        public StoryFP StoryFPChoice { get; set; }
        public StoryReport StoryReportChoice { get; set; }
        public StoryGlobalShuffle StoryGlobalShuffleChoice { get; set; }
        public List<StoryRewards> ShuffledStoryRewards { get; set; }

        public StoryRewardSettings()
        {
            InitializeDataStructures();
            CorrectSettingValues();
        }

        private void InitializeDataStructures()
        {
            ShuffledStoryRewards = new List<StoryRewards>();
        }

        public void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(StoryPin), StoryPinChoice)) StoryPinChoice = StoryPin.Unchanged;
            if (!Enum.IsDefined(typeof(StoryYen), StoryYenChoice)) StoryYenChoice = StoryYen.Unchanged;
            if (!Enum.IsDefined(typeof(StoryGem), StoryGemChoice)) StoryGemChoice = StoryGem.Unchanged;
            if (!Enum.IsDefined(typeof(StoryFP), StoryFPChoice)) StoryFPChoice = StoryFP.Unchanged;
            if (!Enum.IsDefined(typeof(StoryReport), StoryReportChoice)) StoryReportChoice = StoryReport.Unchanged;
            if (!Enum.IsDefined(typeof(StoryGlobalShuffle), StoryGlobalShuffleChoice)) StoryGlobalShuffleChoice = StoryGlobalShuffle.Unchanged;
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            StoryPinChoice = (StoryPin)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_pins_category");
            IncludeLimitedPins = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_pins_limited") == 1;
            StoryYenChoice = (StoryYen)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_yen_category");
            StoryGemChoice = (StoryGem)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_gems_category");
            StoryFPChoice = (StoryFP)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_fp_category");
            StoryReportChoice = (StoryReport)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_reports_category");
            StoryGlobalShuffleChoice = (StoryGlobalShuffle)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_category");

            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_pins") == 1) ShuffledStoryRewards.Add(StoryRewards.Pins);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_yen") == 1) ShuffledStoryRewards.Add(StoryRewards.Yen);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_gems") == 1) ShuffledStoryRewards.Add(StoryRewards.Gems);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_fp") == 1) ShuffledStoryRewards.Add(StoryRewards.FP);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_reports") == 1) ShuffledStoryRewards.Add(StoryRewards.Reports);
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_pins_category", (uint)StoryPinChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_pins_limited", IncludeLimitedPins ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_yen_category", (uint)StoryYenChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_gems_category", (uint)StoryGemChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_fp_category", (uint)StoryFPChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_reports_category", (uint)StoryReportChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_category", (uint)StoryGlobalShuffleChoice);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_pins", ShuffledStoryRewards.Contains(StoryRewards.Pins) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_yen", ShuffledStoryRewards.Contains(StoryRewards.Yen) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_gems", ShuffledStoryRewards.Contains(StoryRewards.Gems) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_fp", ShuffledStoryRewards.Contains(StoryRewards.FP) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_reports", ShuffledStoryRewards.Contains(StoryRewards.Reports) ? 1u : 0u);

            return currentString;
        }
    }
}
