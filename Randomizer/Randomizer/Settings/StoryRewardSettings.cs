using System;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class StoryRewardSettings
    {
        public StoryPin PinChoice { get; set; }
        public bool IncludeLimitedPins { get; set; }
        public StoryYen YenChoice { get; set; }
        public StoryGem GemChoice { get; set; }
        public StoryFP FPChoice { get; set; }
        public StoryReport ReportChoice { get; set; }
        public StoryGlobalShuffle GlobalShuffleChoice { get; set; }
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
            if (!Enum.IsDefined(typeof(StoryPin), PinChoice)) PinChoice = StoryPin.Unchanged;
            if (!Enum.IsDefined(typeof(StoryYen), YenChoice)) YenChoice = StoryYen.Unchanged;
            if (!Enum.IsDefined(typeof(StoryGem), GemChoice)) GemChoice = StoryGem.Unchanged;
            if (!Enum.IsDefined(typeof(StoryFP), FPChoice)) FPChoice = StoryFP.Unchanged;
            if (!Enum.IsDefined(typeof(StoryReport), ReportChoice)) ReportChoice = StoryReport.Unchanged;
            if (!Enum.IsDefined(typeof(StoryGlobalShuffle), GlobalShuffleChoice)) GlobalShuffleChoice = StoryGlobalShuffle.Unchanged;
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            PinChoice = (StoryPin)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_pins_category");
            IncludeLimitedPins = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_pins_limited") == 1;
            YenChoice = (StoryYen)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_yen_category");
            GemChoice = (StoryGem)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_gems_category");
            FPChoice = (StoryFP)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_fp_category");
            ReportChoice = (StoryReport)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_reports_category");
            GlobalShuffleChoice = (StoryGlobalShuffle)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_category");

            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_pins") == 1) ShuffledStoryRewards.Add(StoryRewards.Pins);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_yen") == 1) ShuffledStoryRewards.Add(StoryRewards.Yen);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_gems") == 1) ShuffledStoryRewards.Add(StoryRewards.Gems);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_fp") == 1) ShuffledStoryRewards.Add(StoryRewards.FP);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "story_global_shuffle_reports") == 1) ShuffledStoryRewards.Add(StoryRewards.Reports);
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_pins_category", (uint)PinChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_pins_limited", IncludeLimitedPins ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_yen_category", (uint)YenChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_gems_category", (uint)GemChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_fp_category", (uint)FPChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_reports_category", (uint)ReportChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_category", (uint)GlobalShuffleChoice);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_pins", ShuffledStoryRewards.Contains(StoryRewards.Pins) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_yen", ShuffledStoryRewards.Contains(StoryRewards.Yen) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_gems", ShuffledStoryRewards.Contains(StoryRewards.Gems) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_fp", ShuffledStoryRewards.Contains(StoryRewards.FP) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "story_global_shuffle_reports", ShuffledStoryRewards.Contains(StoryRewards.Reports) ? 1u : 0u);

            return currentString;
        }
    }
}
