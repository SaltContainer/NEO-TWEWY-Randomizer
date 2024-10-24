using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEO_TWEWY_Randomizer
{
    public class StoryRewardsLogger
    {
        private StringBuilder log;

        public StoryRewardsLogger()
        {
            log = new StringBuilder();
        }

        public void AddToLog(string logString)
        {
            log.Append(logString);
        }

        public string LogStoryRewardChanges(List<ScenarioRewards> original, List<ScenarioRewards> randomized)
        {
            log.Clear();
            AddToLog("Story Rewards\n========================================\n\n");

            List<NameAssociation> itemNames = FileConstants.ItemNames.PinItems
                .Union(FileConstants.ItemNames.LimitedPins)
                .Union(FileConstants.ItemNames.YenPins)
                .Union(FileConstants.ItemNames.GemPins)
                .Union(FileConstants.ItemNames.FP)
                .Union(FileConstants.ItemNames.SecretReports)
                .ToList();
            List<NameAssociation> storyRewardNames = FileConstants.ItemNames.StoryPins
                .Union(FileConstants.ItemNames.StoryLimitedPins)
                .Union(FileConstants.ItemNames.StoryYen)
                .Union(FileConstants.ItemNames.StoryGems)
                .Union(FileConstants.ItemNames.StoryFP)
                .Union(FileConstants.ItemNames.StoryReports)
                .ToList();
            List<NameAssociation> storyRewardNames2nd = FileConstants.ItemNames.StoryYen2nd.ToList();

            for (int i = 0; i < original.Count; i++)
            {
                ScenarioRewards rewardsOriginal = original[i];
                ScenarioRewards rewardsRandomized = randomized[i];
                if (storyRewardNames.Where(n => n.Id == rewardsOriginal.Id).Any())
                {
                    string rewardName = storyRewardNames.Where(n => n.Id == rewardsOriginal.Id).First().Name;
                    AddToLog(string.Format("{0,-35}: {1,-25} x{2,-3} -> {3,-25} x{4,-3}\n", rewardName, itemNames.Where(n => n.Id == rewardsOriginal.FirstReward).First().Name, rewardsOriginal.FirstRewardCount, itemNames.Where(n => n.Id == rewardsRandomized.FirstReward).First().Name, rewardsRandomized.FirstRewardCount));
                    if (storyRewardNames2nd.Where(n => n.Id == rewardsOriginal.Id).Any())
                    {
                        string rewardName2nd = storyRewardNames2nd.Where(n => n.Id == rewardsOriginal.Id).First().Name;
                        AddToLog(string.Format("{0,-35}: {1,-25} x{2,-3} -> {3,-25} x{4,-3}\n", rewardName2nd, itemNames.Where(n => n.Id == rewardsOriginal.SecondReward).First().Name, rewardsOriginal.SecondRewardCount, itemNames.Where(n => n.Id == rewardsRandomized.SecondReward).First().Name, rewardsRandomized.SecondRewardCount));
                    }
                }
            }
            AddToLog("\n");

            return log.ToString();
        }

        public string LogSettings(RandomizationSettings settings)
        {
            log.Clear();

            AddToLog("STORY REWARDS\n");
            string storyPinChoice = "";
            switch (settings.StoryRewards.PinChoice)
            {
                case StoryPin.Unchanged: storyPinChoice = "Unchanged"; break;
                case StoryPin.Shuffle: storyPinChoice = "Shuffle"; break;
                case StoryPin.Random: storyPinChoice = "Random"; break;
            }
            AddToLog(string.Format("Pin Rewards: {0}\n", storyPinChoice));
            if (settings.StoryRewards.PinChoice != StoryPin.Unchanged) AddToLog(string.Format("\tInclude Limited Pins: {0}\n", settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle ? "Yes" : "No"));
            string storyYenChoice = "";
            switch (settings.StoryRewards.YenChoice)
            {
                case StoryYen.Unchanged: storyYenChoice = "Unchanged"; break;
                case StoryYen.Shuffle: storyYenChoice = "Shuffle"; break;
                case StoryYen.Random: storyYenChoice = "Random"; break;
            }
            AddToLog(string.Format("Yen Pin Rewards: {0}\n", storyYenChoice));
            string storyGemChoice = "";
            switch (settings.StoryRewards.GemChoice)
            {
                case StoryGem.Unchanged: storyGemChoice = "Unchanged"; break;
                case StoryGem.Shuffle: storyGemChoice = "Shuffle"; break;
                case StoryGem.Random: storyGemChoice = "Random"; break;
            }
            AddToLog(string.Format("Gem Pin Rewards: {0}\n", storyGemChoice));
            string storyFPChoice = "";
            switch (settings.StoryRewards.FPChoice)
            {
                case StoryFP.Unchanged: storyFPChoice = "Unchanged"; break;
                case StoryFP.Shuffle: storyFPChoice = "Shuffle"; break;
                case StoryFP.RandomFixedTotal: storyFPChoice = "Random (Fixed Total)"; break;
            }
            AddToLog(string.Format("Friendship Point Rewards: {0}\n", storyFPChoice));
            string storyReportChoice = "";
            switch (settings.StoryRewards.ReportChoice)
            {
                case StoryReport.Unchanged: storyReportChoice = "Unchanged"; break;
                case StoryReport.Shuffle: storyReportChoice = "Shuffle"; break;
            }
            AddToLog(string.Format("Secret Report Rewards: {0}\n", storyReportChoice));
            AddToLog(string.Format("Shuffle Reward Locations: {0}\n", settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle ? "Yes" : "No"));
            if (settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle)
            {
                List<string> shuffledStoryRewards = new List<string>();
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Pins)) shuffledStoryRewards.Add("Pins");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Yen)) shuffledStoryRewards.Add("Yen Pins");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Gems)) shuffledStoryRewards.Add("Gem Pins");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.FP)) shuffledStoryRewards.Add("Friendship Points");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Reports)) shuffledStoryRewards.Add("Secret Reports");
                AddToLog(string.Format("\tShuffled Rewards: {0}", shuffledStoryRewards.Count() > 0 ? string.Join(", ", shuffledStoryRewards) : "None"));
                AddToLog("\n");
            }
            AddToLog("\n");

            return log.ToString();
        }
    }
}
