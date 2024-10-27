using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class StoryRewardsRandomizer
    {
        private RandomizationEngine engine;

        public StoryRewardsRandomizer(RandomizationEngine engine)
        {
            this.engine = engine;
        }

        private void ShuffleListOfStoryRewards(List<ScenarioRewards> rewards)
        {
            List<(AllItemsLabel, int)> newIds = rewards.OrderBy(pin => engine.RandNext()).Select(p => (p.FirstReward, p.FirstRewardCount)).ToList();

            for (int i=0; i<rewards.Count(); i++)
            {
                rewards[i].FirstReward = newIds[i].Item1;
                rewards[i].FirstRewardCount = newIds[i].Item2;
            }
        }

        private void RandomizeListOfStoryRewards(List<ScenarioRewards> rewards, List<(AllItemsLabel, int)> possibleIds)
        {
            foreach (var pin in rewards)
            {
                int newId = engine.RandNext(possibleIds.Count);
                pin.FirstReward = possibleIds[newId].Item1;
                pin.FirstRewardCount = possibleIds[newId].Item2;
            }
        }

        public void RandomizeStoryRewards(RandomizationSettings settings)
        {
            ScenarioRewardsList storyDataOriginal = engine.Bundles.TextData.ParseScenarioRewards();
            ScenarioRewardsList storyData = engine.Bundles.TextData.GetScenarioRewards();

            List<NameAssociation> storyNames = FileConstants.ItemNames.StoryPins
                .Union(FileConstants.ItemNames.StoryLimitedPins)
                .Union(FileConstants.ItemNames.StoryYen)
                .Union(FileConstants.ItemNames.StoryGems)
                .Union(FileConstants.ItemNames.StoryFP)
                .Union(FileConstants.ItemNames.StoryReports).ToList();

            List<ScenarioRewards> fullListToEditOriginal = storyDataOriginal.Items.Where(data => storyNames.Select(n => (ScenarioRewards.Label)n.Id).Contains(data.Id)).ToList();
            List<ScenarioRewards> fullListToEdit = storyData.Items.Where(data => storyNames.Select(n => (ScenarioRewards.Label)n.Id).Contains(data.Id)).ToList();

            switch (settings.StoryRewards.PinChoice)
            {
                case StoryPin.Shuffle:
                {
                    List<ScenarioRewards> pins = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryPins.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    if (settings.StoryRewards.IncludeLimitedPins)
                        pins.AddRange(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryLimitedPins.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)));

                    ShuffleListOfStoryRewards(pins);
                }
                break;

                case StoryPin.Random:
                {
                    List<ScenarioRewards> pins = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryPins.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    List<(AllItemsLabel, int)> randomIds = FileConstants.ItemNames.PinItems.Select(p => ((AllItemsLabel)p.Id, 1)).ToList();
                    if (settings.StoryRewards.IncludeLimitedPins)
                    {
                        pins.AddRange(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryLimitedPins.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)));
                        randomIds.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => ((AllItemsLabel)p.Id, 1)));
                    }

                    RandomizeListOfStoryRewards(pins, randomIds);
                }
                break;
            }

            switch (settings.StoryRewards.YenChoice)
            {
                case StoryYen.Shuffle:
                {
                    List<(int, ScenarioRewards)> pins = fullListToEdit
                        .Where(reward => FileConstants.ItemNames.StoryYen.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p)).ToList();
                    List<AllItemsLabel> newIds = pins.Select(p => p.Item2.FirstReward).ToList();

                    List<(int, ScenarioRewards)> pins2nd = fullListToEdit
                        .Where(reward => FileConstants.ItemNames.StoryYen2nd.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (2, p)).ToList();
                    List<AllItemsLabel> newIds2nd = pins2nd.Select(p => p.Item2.SecondReward).ToList();

                    pins.AddRange(pins2nd);
                    newIds.AddRange(newIds2nd);

                    newIds = newIds.OrderBy(pin => engine.RandNext()).ToList();

                    for (int i=0; i<pins.Count; i++)
                    {
                        var pin = pins[i];
                        if (pin.Item1 == 1) pin.Item2.FirstReward = newIds[i];
                        else if (pin.Item1 == 2) pin.Item2.SecondReward = newIds[i];
                    }
                }
                break;

                case StoryYen.Random:
                {
                    List<(int, ScenarioRewards)> pins = fullListToEdit
                        .Where(reward => FileConstants.ItemNames.StoryYen.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p)).ToList();
                    pins.AddRange(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryYen2nd.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (2, p)));

                    List<AllItemsLabel> randomIds = FileConstants.ItemNames.YenPins.Select(p => (AllItemsLabel)p.Id).ToList();

                    foreach (var pin in pins)
                    {
                        if (pin.Item1 == 1) pin.Item2.FirstReward = randomIds[engine.RandNext(randomIds.Count)];
                        else if (pin.Item1 == 2) pin.Item2.SecondReward = randomIds[engine.RandNext(randomIds.Count)];
                    }
                }
                break;
            }

            switch (settings.StoryRewards.GemChoice)
            {
                case StoryGem.Shuffle:
                {
                    List<ScenarioRewards> pins = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryGems.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    ShuffleListOfStoryRewards(pins);
                }
                break;

                case StoryGem.Random:
                {
                    List<ScenarioRewards> pins = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryGems.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    List<(AllItemsLabel, int)> randomIds = FileConstants.ItemNames.GemPins.Select(p => ((AllItemsLabel)p.Id, engine.RandNext(1, 4))).ToList();
                    RandomizeListOfStoryRewards(pins, randomIds);
                }
                break;
            }

            switch (settings.StoryRewards.FPChoice)
            {
                case StoryFP.Shuffle:
                {
                    List<ScenarioRewards> fp = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    List<int> newCounts = fp.OrderBy(pin => engine.RandNext()).Select(p => p.FirstRewardCount).ToList();

                    for (int i=0; i<fp.Count; i++)
                        fp[i].FirstRewardCount = newCounts[i];
                }
                break;

                case StoryFP.RandomFixedTotal:
                {
                    // Hardcoded to vanilla max for now
                    int maxFp = 159;
                    List<ScenarioRewards> fp = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    List<int> newCounts = engine.RandGenerateListOfSum(fp.Count(), maxFp);

                    for (int i=0; i<fp.Count; i++)
                        fp[i].FirstRewardCount = newCounts[i];
                }
                break;
            }

            switch (settings.StoryRewards.ReportChoice)
            {
                case StoryReport.Shuffle:
                {
                    List<ScenarioRewards> reports = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryReports.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).ToList();
                    ShuffleListOfStoryRewards(reports);
                }
                break;
            }

            switch (settings.StoryRewards.GlobalShuffleChoice)
            {
                case StoryGlobalShuffle.Shuffle:
                {
                    List<(int, ScenarioRewards)> rewards = [];
                    if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Pins))
                    {
                        rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryPins.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                        if (settings.StoryRewards.IncludeLimitedPins)
                            rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryLimitedPins.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                    }

                    if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Yen))
                    {
                        rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryYen.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                        rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryYen2nd.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (2, p))).ToList();
                    }

                    if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Gems))
                        rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryGems.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                    if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.FP))
                        rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                    if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Reports))
                        rewards = rewards.Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryReports.Select(p => (ScenarioRewards.Label)p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();

                    List<(AllItemsLabel, int)> newRewards = rewards.Where(r => r.Item1 == 1).Select(r => (r.Item2.FirstReward, r.Item2.FirstRewardCount)).ToList();
                    newRewards.AddRange(rewards.Where(r => r.Item1 == 2).Select(r => (r.Item2.SecondReward, r.Item2.SecondRewardCount)));

                    newRewards = newRewards.OrderBy(reward => engine.RandNext()).ToList();
                    for (int i=0; i<rewards.Count; i++)
                    {
                        var reward = rewards[i];
                        if (reward.Item1 == 1)
                        {
                            reward.Item2.FirstReward = newRewards[i].Item1;
                            reward.Item2.FirstRewardCount = newRewards[i].Item2;
                        }
                        if (reward.Item1 == 2)
                        {
                            reward.Item2.SecondReward = newRewards[i].Item1;
                            reward.Item2.SecondRewardCount = newRewards[i].Item2;
                        }
                    }
                }
                break;
            }

            engine.Logger.LogStoryRewardChanges(fullListToEditOriginal, fullListToEdit);
        }
    }
}
