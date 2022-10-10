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
            if (!Enum.IsDefined(typeof(StoryFP), StoryFPChoice)) StoryFPChoice = StoryFP.Unchanged;
            if (!Enum.IsDefined(typeof(StoryReport), StoryReportChoice)) StoryReportChoice = StoryReport.Unchanged;
            if (!Enum.IsDefined(typeof(StoryGlobalShuffle), StoryGlobalShuffleChoice)) StoryGlobalShuffleChoice = StoryGlobalShuffle.Unchanged;
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            return "";
        }
    }
}
