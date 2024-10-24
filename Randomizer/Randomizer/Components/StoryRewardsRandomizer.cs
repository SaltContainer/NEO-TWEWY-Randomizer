using Newtonsoft.Json;
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
            List<(int, int)> newIds = rewards.OrderBy(pin => engine.RandNext()).Select(p => (p.FirstReward, p.FirstRewardCount)).ToList();

            for (int i = 0; i < rewards.Count(); i++)
            {
                rewards[i].FirstReward = newIds[i].Item1;
                rewards[i].FirstRewardCount = newIds[i].Item2;
            }
        }

        private void RandomizeListOfStoryRewards(List<ScenarioRewards> rewards, List<(int, int)> possibleIds)
        {
            foreach (var pin in rewards)
            {
                int newId = engine.RandNext(possibleIds.Count);
                pin.FirstReward = possibleIds[newId].Item1;
                pin.FirstRewardCount = possibleIds[newId].Item2;
            }
        }

        public Dictionary<string, string> RandomizeStoryRewards(RandomizationSettings settings)
        {
            string scenarioRewardsScript = engine.GetScript(FileConstants.ScenarioRewardsClassName);

            ScenarioRewardsList storyDataOriginal = JsonConvert.DeserializeObject<ScenarioRewardsList>(scenarioRewardsScript);
            ScenarioRewardsList storyData = JsonConvert.DeserializeObject<ScenarioRewardsList>(scenarioRewardsScript);

            List<NameAssociation> storyNames = FileConstants.ItemNames.StoryPins
                .Union(FileConstants.ItemNames.StoryLimitedPins)
                .Union(FileConstants.ItemNames.StoryYen)
                .Union(FileConstants.ItemNames.StoryGems)
                .Union(FileConstants.ItemNames.StoryFP)
                .Union(FileConstants.ItemNames.StoryReports).ToList();

            List<ScenarioRewards> fullListToEditOriginal = storyDataOriginal.Items.Where(data => storyNames.Select(n => n.Id).Contains(data.Id)).ToList();
            List<ScenarioRewards> fullListToEdit = storyData.Items.Where(data => storyNames.Select(p => p.Id).Contains(data.Id)).ToList();

            switch (settings.StoryRewards.PinChoice)
            {
                case StoryPin.Shuffle:
                    List<ScenarioRewards> pinsToShuffle = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryPins.Select(p => p.Id).Contains(reward.Id)).ToList();
                    if (settings.StoryRewards.IncludeLimitedPins)
                    {
                        pinsToShuffle.AddRange(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryLimitedPins.Select(p => p.Id).Contains(reward.Id)));
                    }

                    ShuffleListOfStoryRewards(pinsToShuffle);
                    break;

                case StoryPin.Random:
                    List<ScenarioRewards> pinsToRando = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryPins.Select(p => p.Id).Contains(reward.Id)).ToList();
                    List<(int, int)> randomIds = FileConstants.ItemNames.PinItems.Select(p => (p.Id, 1)).ToList();
                    if (settings.StoryRewards.IncludeLimitedPins)
                    {
                        pinsToRando.AddRange(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryLimitedPins.Select(p => p.Id).Contains(reward.Id)));
                        randomIds.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => (p.Id, 1)));
                    }

                    RandomizeListOfStoryRewards(pinsToRando, randomIds);
                    break;
            }

            switch (settings.StoryRewards.YenChoice)
            {
                case StoryYen.Shuffle:
                    List<(int, ScenarioRewards)> pinsToShuffle = fullListToEdit
                        .Where(reward => FileConstants.ItemNames.StoryYen.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p)).ToList();
                    List<int> newIds = pinsToShuffle.Select(p => p.Item2.FirstReward).ToList();

                    List<(int, ScenarioRewards)> pinsToShuffle2nd = fullListToEdit
                        .Where(reward => FileConstants.ItemNames.StoryYen2nd.Select(p => p.Id).Contains(reward.Id)).Select(p => (2, p)).ToList();
                    List<int> newIds2nd = pinsToShuffle2nd.Select(p => p.Item2.SecondReward).ToList();

                    pinsToShuffle.AddRange(pinsToShuffle2nd);
                    newIds.AddRange(newIds2nd);

                    newIds = newIds.OrderBy(pin => engine.RandNext()).ToList();

                    for (int i = 0; i < pinsToShuffle.Count(); i++)
                    {
                        var pin = pinsToShuffle[i];
                        if (pin.Item1 == 1) pin.Item2.FirstReward = newIds[i];
                        else if (pin.Item1 == 2) pin.Item2.SecondReward = newIds[i];
                    }
                    break;

                case StoryYen.Random:
                    List<(int, ScenarioRewards)> pinsToRando = fullListToEdit
                        .Where(reward => FileConstants.ItemNames.StoryYen.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p)).ToList();
                    pinsToRando.AddRange(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryYen2nd.Select(p => p.Id).Contains(reward.Id)).Select(p => (2, p)));

                    List<int> randomIds = FileConstants.ItemNames.YenPins.Select(p => p.Id).ToList();

                    foreach (var pin in pinsToRando)
                    {
                        if (pin.Item1 == 1) pin.Item2.FirstReward = randomIds[engine.RandNext(randomIds.Count)];
                        else if (pin.Item1 == 2) pin.Item2.SecondReward = randomIds[engine.RandNext(randomIds.Count)];
                    }
                    break;
            }

            switch (settings.StoryRewards.GemChoice)
            {
                case StoryGem.Shuffle:
                    List<ScenarioRewards> pinsToShuffle = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryGems.Select(p => p.Id).Contains(reward.Id)).ToList();
                    ShuffleListOfStoryRewards(pinsToShuffle);
                    break;

                case StoryGem.Random:
                    List<ScenarioRewards> pinsToRando = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryGems.Select(p => p.Id).Contains(reward.Id)).ToList();
                    List<(int, int)> randomIds = FileConstants.ItemNames.GemPins.Select(p => (p.Id, engine.RandNext(1, 4))).ToList();
                    RandomizeListOfStoryRewards(pinsToRando, randomIds);
                    break;
            }

            switch (settings.StoryRewards.FPChoice)
            {
                case StoryFP.Shuffle:
                    List<ScenarioRewards> fpToShuffle = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => p.Id).Contains(reward.Id)).ToList();
                    List<int> newCountsShuffle = fpToShuffle.OrderBy(pin => engine.RandNext()).Select(p => p.FirstRewardCount).ToList();

                    for (int i = 0; i < fpToShuffle.Count(); i++)
                    {
                        fpToShuffle[i].FirstRewardCount = newCountsShuffle[i];
                    }
                    break;

                case StoryFP.RandomFixedTotal:
                    int maxFp = 159;
                    List<ScenarioRewards> fpToRando = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => p.Id).Contains(reward.Id)).ToList();
                    List<int> newCountsRando = engine.RandGenerateListOfSum(fpToRando.Count(), maxFp);

                    for (int i = 0; i < fpToRando.Count(); i++)
                    {
                        fpToRando[i].FirstRewardCount = newCountsRando[i];
                    }
                    break;
            }

            if (settings.StoryRewards.ReportChoice == StoryReport.Shuffle)
            {
                List<ScenarioRewards> reportsToShuffle = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryReports.Select(p => p.Id).Contains(reward.Id)).ToList();
                ShuffleListOfStoryRewards(reportsToShuffle);
            }

            if (settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle)
            {
                List<(int, ScenarioRewards)> rewardsToShuffle = new List<(int, ScenarioRewards)>();
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Pins))
                {
                    rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryPins.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                    if (settings.StoryRewards.IncludeLimitedPins) rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryLimitedPins.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                }
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Yen))
                {
                    rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryYen.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                    rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryYen2nd.Select(p => p.Id).Contains(reward.Id)).Select(p => (2, p))).ToList();
                }
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Gems)) rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryGems.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.FP)) rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Reports)) rewardsToShuffle = rewardsToShuffle
                        .Union(fullListToEdit.Where(reward => FileConstants.ItemNames.StoryReports.Select(p => p.Id).Contains(reward.Id)).Select(p => (1, p))).ToList();

                List<(int, int)> newRewards = rewardsToShuffle.Where(r => r.Item1 == 1).Select(r => (r.Item2.FirstReward, r.Item2.FirstRewardCount)).ToList();
                newRewards.AddRange(rewardsToShuffle.Where(r => r.Item1 == 2).Select(r => (r.Item2.SecondReward, r.Item2.SecondRewardCount)));

                newRewards = newRewards.OrderBy(reward => engine.RandNext()).ToList();
                for (int i = 0; i < rewardsToShuffle.Count(); i++)
                {
                    var reward = rewardsToShuffle[i];
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

            engine.Logger.LogStoryRewardChanges(fullListToEditOriginal, fullListToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { FileConstants.ScenarioRewardsClassName, JsonConvert.SerializeObject(storyData, Formatting.Indented, new FloatFormatConverter(1)) }
            };
            return editedScripts;
        }
    }
}
