using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class NetworkRandomizer
    {
        private RandomizationEngine engine;

        public NetworkRandomizer(RandomizationEngine engine)
        {
            this.engine = engine;
        }

        private void ShuffleListOfCosts(List<Skill> skills)
        {
            List<int> newCosts = skills.OrderBy(s => engine.RandNext()).Select(s => s.Point).ToList();

            for (int i=0; i<skills.Count; i++)
                skills[i].Point = newCosts[i];
        }

        private void ShuffleListOfRewards(List<Skill> skills)
        {
            List<AllItemsLabel> newRewards = skills.OrderBy(s => engine.RandNext()).Select(s => s.ShopReward).ToList();

            for (int i=0; i<skills.Count; i++)
                skills[i].ShopReward = newRewards[i];
        }

        private void ShuffleListOfTrees(List<SkillTree> trees)
        {
            List<Skill.Label> newTrees = trees.OrderBy(t => engine.RandNext()).Select(t => t.Skill).ToList();

            for (int i=0; i<trees.Count; i++)
                trees[i].Skill = newTrees[i];
        }

        public void RandomizeNetworkData(RandomizationSettings settings)
        {
            SkillList skillDataOriginal = engine.Bundles.TextData.ParseSkill();
            SkillList skillData = engine.Bundles.TextData.GetSkill();
            SkillTreeList skillTreeDataOriginal = engine.Bundles.TextData.ParseSkillTree();
            SkillTreeList skillTreeData = engine.Bundles.TextData.GetSkillTree();

            List<Skill> fullSkillListToEditOriginal = skillDataOriginal.Items.ToList();
            List<Skill> fullSkillListToEdit = skillData.Items.ToList();
            List<SkillTree> fullSkillTreeListToEditOriginal = skillTreeDataOriginal.Items.Where(t => t.Skill != Skill.Label.Invalid).ToList();
            List<SkillTree> fullSkillTreeListToEdit = skillTreeData.Items.Where(t => t.Skill != Skill.Label.Invalid).ToList();

            switch (settings.Network.CostChoice)
            {
                case SkillCost.Shuffle:
                {
                    ShuffleListOfCosts(fullSkillListToEdit.ToList());
                }
                break;

                case SkillCost.RandomFixedTotal:
                {
                    // Hardcoded to vanilla max for now
                    int maxFp = 159;
                    List<Skill> skill = fullSkillListToEdit.ToList();
                    List<int> newCounts = engine.RandGenerateListOfSum(skill.Count, maxFp);

                    for (int i=0; i<skill.Count; i++)
                        skill[i].Point = newCounts[i];
                }
                break;
            }

            switch (settings.Network.RewardsChoice)
            {
                case SkillRewards.Shuffle:
                {
                    ShuffleListOfRewards(fullSkillListToEdit.Where(s => s.ShopReward != AllItemsLabel.Invalid).ToList());
                }
                break;

                case SkillRewards.RandomSameType:
                {
                    List<NameAssociation> pinNames = FileConstants.IDNames.LimitedPins.ToList();
                    var pinRewards = fullSkillListToEdit.Where(s => pinNames.Select(p => (AllItemsLabel)p.Id).Contains(s.ShopReward));

                    foreach (var pinReward in pinRewards)
                        pinReward.ShopReward = (AllItemsLabel)pinNames[engine.RandNext(pinNames.Count)].Id;

                    List<NameAssociation> threadNames = FileConstants.IDNames.Threads.ToList();
                    var threadRewards = fullSkillListToEdit.Where(s => threadNames.Select(p => (AllItemsLabel)p.Id).Contains(s.ShopReward));

                    foreach (var threadReward in threadRewards)
                        threadReward.ShopReward = (AllItemsLabel)threadNames[engine.RandNext(threadNames.Count)].Id;
                }
                break;

                case SkillRewards.RandomCompletely:
                {
                    List<NameAssociation> allNames = FileConstants.IDNames.LimitedPins
                        .Union(FileConstants.IDNames.Threads).ToList();
                    var allRewards = fullSkillListToEdit.Where(s => allNames.Select(p => (AllItemsLabel)p.Id).Contains(s.ShopReward));

                    foreach (var allReward in allRewards)
                        allReward.ShopReward = (AllItemsLabel)allNames[engine.RandNext(allNames.Count)].Id;
                }
                break;
            }

            switch (settings.Network.ShuffleChoice)
            {
                case SkillShuffle.Shuffle:
                {
                    ShuffleListOfTrees(fullSkillTreeListToEdit.Where(t => t.Skill != Skill.Label.Invalid).ToList());
                }
                break;
            }

            engine.Logger.LogSkillChanges(fullSkillListToEditOriginal, fullSkillListToEdit);
            engine.Logger.LogSkillTreeChanges(fullSkillTreeListToEditOriginal, fullSkillTreeListToEdit);
        }
    }
}
