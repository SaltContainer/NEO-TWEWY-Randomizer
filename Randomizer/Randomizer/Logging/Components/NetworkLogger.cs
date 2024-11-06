using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEO_TWEWY_Randomizer
{
    public class NetworkLogger
    {
        private StringBuilder log;

        public NetworkLogger()
        {
            log = new StringBuilder();
        }

        public void AddToLog(string logString)
        {
            log.Append(logString);
        }

        public string LogSkillChanges(List<Skill> original, List<Skill> randomized)
        {
            log.Clear();
            AddToLog("Skills\n========================================\n\n");

            List<NameAssociation> itemNames = FileConstants.IDNames.LimitedPins
                .Union(FileConstants.IDNames.Threads)
                .ToList();

            for (int i=0; i<original.Count; i++)
            {
                Skill skillOriginal = original[i];
                Skill skillRandomized = randomized[i];
                AddToLog(string.Format("{0}\n", FileConstants.IDNames.Skills.Where(n => (Skill.Label)n.Id == skillOriginal.Id).First().Name));
                AddToLog(string.Format("{0,-6}: {1,-2}FP                     -> {2,-2}FP\n", "Cost", skillOriginal.Point, skillRandomized.Point));
                if (skillOriginal.ShopReward != AllItemsLabel.Invalid && skillRandomized.ShopReward != AllItemsLabel.Invalid)
                    AddToLog(string.Format("{0,-6}: {1,-24} -> {2,-24}\n", "Reward", itemNames.Where(n => (AllItemsLabel)n.Id == skillOriginal.ShopReward).First().Name, itemNames.Where(n => (AllItemsLabel)n.Id == skillRandomized.ShopReward).First().Name));
                AddToLog("\n");
            }
            AddToLog("\n");

            return log.ToString();
        }

        public string LogSkillTreeChanges(List<SkillTree> original, List<SkillTree> randomized)
        {
            log.Clear();
            AddToLog("Social Network\n========================================\n\n");

            for (int i=0; i<original.Count; i++)
            {
                SkillTree treeOriginal = original[i];
                SkillTree treeRandomized = randomized[i];

                if (FileConstants.IDNames.SkillSlots.Where(n => (SkillTree.Label)n.Id == treeOriginal.Id).Any())
                {
                    string slotName = FileConstants.IDNames.SkillSlots.Where(n => (SkillTree.Label)n.Id == treeOriginal.Id).First().Name;
                    AddToLog(string.Format("{0,-25}: {1,-45} -> {2,-45}\n", slotName, FileConstants.IDNames.Skills.Where(n => (Skill.Label)n.Id == treeOriginal.Skill).First().Name, FileConstants.IDNames.Skills.Where(n => (Skill.Label)n.Id == treeRandomized.Skill).First().Name));
                }
            }
            AddToLog("\n");

            return log.ToString();
        }

        public string LogSettings(RandomizationSettings settings)
        {
            log.Clear();

            AddToLog("SOCIAL NETWORK\n");
            string skillCostChoice = "";
            switch (settings.Network.CostChoice)
            {
                case SkillCost.Unchanged: skillCostChoice = "Unchanged"; break;
                case SkillCost.Shuffle: skillCostChoice = "Shuffle"; break;
                case SkillCost.RandomFixedTotal: skillCostChoice = "Random (Fixed Total)"; break;
            }
            AddToLog(string.Format("Skill Costs: {0}\n", skillCostChoice));
            string skillItemRewards = "";
            switch (settings.Network.RewardsChoice)
            {
                case SkillRewards.Unchanged: skillItemRewards = "Unchanged"; break;
                case SkillRewards.Shuffle: skillItemRewards = "Shuffle"; break;
                case SkillRewards.RandomSameType: skillItemRewards = "Random (Same Type)"; break;
                case SkillRewards.RandomCompletely: skillItemRewards = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Skill Item Rewards: {0}\n", skillItemRewards));
            string storyGemChoice = "";
            switch (settings.Network.ShuffleChoice)
            {
                case SkillShuffle.Unchanged: storyGemChoice = "Unchanged"; break;
                case SkillShuffle.Shuffle: storyGemChoice = "Shuffle"; break;
            }
            AddToLog(string.Format("Skill Location Shuffling: {0}\n", storyGemChoice));
            AddToLog("\n");

            return log.ToString();
        }
    }
}
