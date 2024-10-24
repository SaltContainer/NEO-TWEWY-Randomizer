using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEO_TWEWY_Randomizer
{
    public class PinStatsLogger
    {
        private StringBuilder log;

        public PinStatsLogger()
        {
            log = new StringBuilder();
        }

        public void AddToLog(string logString)
        {
            log.Append(logString);
        }

        public string LogPinStatsChanges(List<Badge> original, List<Badge> randomized)
        {
            log.Clear();
            AddToLog("Pin Stats\n========================================\n\n");

            for (int i = 0; i < original.Count; i++)
            {
                Badge pinOriginal = original[i];
                Badge pinRandomized = randomized[i];
                AddToLog(string.Format("{0}\n", FileConstants.ItemNames.Pins.Where(p => p.Id == original[i].Id).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-4} (+{2,-3})               -> {3,-4} (+{4,-3})\n", "Power", pinOriginal.Power, pinOriginal.PowerScaling, pinRandomized.Power, pinRandomized.PowerScaling));
                AddToLog(string.Format("{0,-14}: {1,-4:F1} uses/secs (+{2,-3:F1})     -> {3,-4:F1} uses/secs (+{4,-3:F1})\n", "Limit", pinOriginal.Limit, pinOriginal.LimitScaling, pinRandomized.Limit, pinRandomized.LimitScaling));
                AddToLog(string.Format("{0,-14}: {1,-4:F1} secs (-{2,-3:F1})          -> {3,-4:F1} secs (-{4,-3:F1})\n", "Reboot", pinOriginal.Reboot, pinOriginal.RebootScaling, pinRandomized.Reboot, pinRandomized.RebootScaling));
                AddToLog(string.Format("{0,-14}: {1,-3:F1} secs (-{2,-3:F1})           -> {3,-3:F1} secs (-{4,-3:F1})\n", "Boot", pinOriginal.Boot, pinOriginal.BootScaling, pinRandomized.Boot, pinRandomized.BootScaling));
                AddToLog(string.Format("{0,-14}: {1,-4:F1} secs (-{2,-3:F1})          -> {3,-4:F1} secs (-{4,-3:F1})\n", "Recover", pinOriginal.Recover, pinOriginal.RecoverScaling, pinRandomized.Recover, pinRandomized.RecoverScaling));
                AddToLog(string.Format("{0,-14}: {1,-3:F1} secs                  -> {2,-3:F1} secs\n", "Charge", pinOriginal.Charge, pinRandomized.Charge));
                AddToLog(string.Format("{0,-14}: {1,-5} ¥ (+{2,-4})           -> {3,-5} ¥ (+{4,-4})\n", "Sell Price", pinOriginal.SellPrice, pinOriginal.SellPriceScaling, pinRandomized.SellPrice, pinRandomized.SellPriceScaling));
                AddToLog(string.Format("{0,-14}: {1,-8}                  -> {2,-8}\n", "Affinity", FileConstants.ItemNames.Affinities.Where(a => a.Id == pinOriginal.MashUpAffinity).First().Name, FileConstants.ItemNames.Affinities.Where(a => a.Id == pinRandomized.MashUpAffinity).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-2}                        -> {2,-2}\n", "Max Level", pinOriginal.MaxLevel, pinRandomized.MaxLevel));
                AddToLog(string.Format("{0,-14}: {1,-24}  -> {2,-24}\n", "Brand", FileConstants.ItemNames.Brands.Where(b => b.Id == pinOriginal.Brand).First().Name, FileConstants.ItemNames.Brands.Where(b => b.Id == pinRandomized.Brand).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-3}                       -> {2,-3}\n", "Uber", pinOriginal.Uber == 1 ? "Yes" : "No", pinRandomized.Uber == 1 ? "Yes" : "No"));
                AddToLog(string.Format("{0,-14}: {1,-18}        -> {2,-18}\n", "Ability", pinOriginal.Abilities.Count > 0 ? FileConstants.ItemNames.PinAbilities.Where(a => a.Id == pinOriginal.Abilities[0]).First().Name : "None", pinRandomized.Abilities.Count > 0 ? FileConstants.ItemNames.PinAbilities.Where(a => a.Id == pinRandomized.Abilities[0]).First().Name : "None"));
                AddToLog(string.Format("{0,-14}: {1,-13}             -> {2,-13}\n", "Growth", FileConstants.ItemNames.GrowthRates.Where(g => g.Id == pinOriginal.Growth).First().Name, FileConstants.ItemNames.GrowthRates.Where(g => g.Id == pinRandomized.Growth).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-25} -> {2,-25}\n", "Global Evo", pinOriginal.EvolutionSingle != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinOriginal.EvolutionSingle).First().Name : "None", pinRandomized.EvolutionSingle != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinRandomized.EvolutionSingle).First().Name : "None"));

                List<int> charaEvoPinsOriginal = new List<int>(pinOriginal.EvolutionList);
                List<int> charaEvoPinsRandomized = new List<int>(pinRandomized.EvolutionList);
                if (charaEvoPinsOriginal.Count == 0) charaEvoPinsOriginal.AddRange(Enumerable.Repeat(-1, 7));
                if (charaEvoPinsRandomized.Count == 0) charaEvoPinsRandomized.AddRange(Enumerable.Repeat(-1, 7));

                for (int j = 0; j < charaEvoPinsOriginal.Count; j++)
                {
                    if (charaEvoPinsOriginal[j] != -1 || charaEvoPinsRandomized[j] != -1)
                    {
                        string character = FileConstants.ItemNames.Characters.Where(c => c.Id == j + 1).First().Name;
                        string pinNameOriginal = charaEvoPinsOriginal[j] != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinOriginal.EvolutionList[j]).First().Name : "None";
                        string pinNameRandomized = charaEvoPinsRandomized[j] != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinRandomized.EvolutionList[j]).First().Name : "None";
                        AddToLog(string.Format("{0,-14}: {1,-25} -> {2,-25}\n", character + " Evo", pinNameOriginal, pinNameRandomized));
                    }
                }

                AddToLog("\n");
            }

            return log.ToString();
        }

        public string LogSettings(RandomizationSettings settings)
        {
            log.Clear();

            AddToLog("PIN STATS\n");
            AddToLog("Randomized General Stats: ");
            List<string> generalPinStats = new List<string>();
            if (settings.PinStats.Power) generalPinStats.Add("Power");
            if (settings.PinStats.PowerScaling) generalPinStats.Add("Power Scaling");
            if (settings.PinStats.Limit) generalPinStats.Add("Limit");
            if (settings.PinStats.LimitScaling) generalPinStats.Add("Limit Scaling");
            if (settings.PinStats.Reboot) generalPinStats.Add("Reboot");
            if (settings.PinStats.RebootScaling) generalPinStats.Add("Reboot Scaling");
            if (settings.PinStats.Boot) generalPinStats.Add("Boot");
            if (settings.PinStats.BootScaling) generalPinStats.Add("Boot Scaling");
            if (settings.PinStats.Recover) generalPinStats.Add("Recover");
            if (settings.PinStats.RecoverScaling) generalPinStats.Add("Recover Scaling");
            if (settings.PinStats.Charge) generalPinStats.Add("Charge");
            if (settings.PinStats.Sell) generalPinStats.Add("Sell Price");
            if (settings.PinStats.SellScaling) generalPinStats.Add("Sell Price Scaling");
            if (settings.PinStats.Affinity) generalPinStats.Add("Affinity");
            if (settings.PinStats.MaxLevel) generalPinStats.Add("Max Level");
            AddToLog(generalPinStats.Count > 0 ? string.Join(", ", generalPinStats) : "None");
            AddToLog("\n");
            string brandChoice = "";
            switch (settings.PinStats.BrandChoice)
            {
                case PinBrand.Unchanged: brandChoice = "Unchanged"; break;
                case PinBrand.Shuffle: brandChoice = "Shuffle"; break;
                case PinBrand.RandomCompletely: brandChoice = "Random (Completely)"; break;
                case PinBrand.RandomUniform: brandChoice = "Random (Uniform)"; break;
            }
            AddToLog(string.Format("Brand: {0}\n", brandChoice));
            AddToLog(string.Format("Uber Pins: {0}\n", settings.PinStats.Uber ? string.Format("Random ({0}%)", settings.PinStats.UberPercentage) : "Unchanged"));
            string abilityChoice = "";
            switch (settings.PinStats.AbilityChoice)
            {
                case PinAbility.Unchanged: abilityChoice = "Unchanged"; break;
                case PinAbility.Shuffle: abilityChoice = "Shuffle"; break;
                case PinAbility.RandomCompletely: abilityChoice = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Pin Abilities: {0}\n", abilityChoice + (settings.PinStats.AbilityChoice == PinAbility.RandomCompletely ? string.Format(" ({0}%)", settings.PinStats.UberPercentage) : "")));
            string growthChoice = "";
            switch (settings.PinStats.GrowthChoice)
            {
                case PinGrowthRandomization.Unchanged: growthChoice = "Unchanged"; break;
                case PinGrowthRandomization.RandomCompletely: growthChoice = "Random (Completely)"; break;
                case PinGrowthRandomization.RandomUniform: growthChoice = "Random (Uniform)"; break;
                case PinGrowthRandomization.Specific: growthChoice = "Specific Growth Speed"; break;
            }
            AddToLog(string.Format("Growth Speed: {0}\n", growthChoice + (settings.PinStats.GrowthChoice == PinGrowthRandomization.Specific ? string.Format(" ({0})", FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int)settings.PinStats.GrowthSpecific).First().Name) : "")));
            string evoChoice = "";
            switch (settings.PinStats.EvolutionChoice)
            {
                case PinEvolution.Unchanged: evoChoice = "Unchanged"; break;
                case PinEvolution.RandomExisting: evoChoice = "Random (Existing)"; break;
                case PinEvolution.RandomCompletely: evoChoice = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Evolution: {0}\n", evoChoice + (settings.PinStats.EvolutionChoice == PinEvolution.RandomCompletely ? string.Format(" ({0}%)", settings.PinStats.EvoPercentage) : "")));
            if (settings.PinStats.EvolutionChoice != PinEvolution.Unchanged) AddToLog(string.Format("Force Same-Brand Evolutions: {0}\n", settings.PinStats.EvoForceBrand ? "Yes" : "No"));
            AddToLog(string.Format("Remove Character-Specific Evolutions: {0}\n", settings.PinStats.RemoveCharaEvos ? "Yes" : "No"));
            AddToLog("\n");

            return log.ToString();
        }
    }
}
