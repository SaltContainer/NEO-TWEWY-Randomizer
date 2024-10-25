using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    public class RandomizationEngine
    {
        private Random rand;
        private RandomizationLogger logger;

        private BundleEngine bundleEngine;
        private Dictionary<string, string> scripts;
        private BundleSet bundles;

        private NoiseDropsRandomizer noiseDropsRandomizer;
        private PinStatsRandomizer pinStatsRandomizer;
        private StoryRewardsRandomizer storyRewardsRandomizer;

        public Random Rand { get => rand; }
        public RandomizationLogger Logger { get => logger; }

        public RandomizationEngine()
        {
            logger = new RandomizationLogger();

            bundleEngine = new BundleEngine();
            scripts = new Dictionary<string, string>();
            bundles = new BundleSet();

            noiseDropsRandomizer = new NoiseDropsRandomizer(this);
            pinStatsRandomizer = new PinStatsRandomizer(this);
            storyRewardsRandomizer = new StoryRewardsRandomizer(this);
        }

        public bool LoadBundles(Dictionary<string, string> fileNames)
        {
            try
            {
                foreach (var entry in fileNames)
                {
                    switch (entry.Key)
                    {
                        case FileConstants.TextDataBundleKey:
                            bundles.TextData = bundleEngine.LoadTextBundle(entry.Value, entry.Key);
                            break;

                        case FileConstants.W1D2ScenarioBundleKey:
                            bundles.W1D2Scenario = bundleEngine.LoadScenarioBundle(entry.Value, entry.Key);
                            break;

                        case FileConstants.W2D5ScenarioBundleKey:
                            bundles.W2D5Scenario = bundleEngine.LoadScenarioBundle(entry.Value, entry.Key);
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading or decrypting one of the asset bundles. Full Exception: " + ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool AreBundlesLoaded()
        {
            return bundles.AreAllBundlesLoaded();
        }

        public void Randomize(RandomizationSettings settings)
        {
            if (rand == null) rand = new Random();

            logger.LogSettings(settings);

            scripts.AddRange(GetBaseScripts());
            scripts.AddRange(noiseDropsRandomizer.RandomizeDroppedPins(settings));
            scripts.AddRange(noiseDropsRandomizer.RandomizeDropRate(settings));
            scripts.AddRange(pinStatsRandomizer.RandomizePinStats(settings));
            scripts.AddRange(storyRewardsRandomizer.RandomizeStoryRewards(settings));

            bundles.TextData.SetScriptFiles(scripts);

            // TODO: Move to randomizer logic
            var w1d2 = bundles.W1D2Scenario.GetScenarioFile("story_w1d2_01_050_mission");
            w1d2.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.Name = "OrMore";
            w1d2.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.SerializedValue = 5;
            bundles.W1D2Scenario.SetScenarioFiles(new Dictionary<string, ScenarioObjectItemGroup>(){ { "story_w1d2_01_050_mission", w1d2 } });

            var w2d5 = bundles.W2D5Scenario.GetScenarioFile("story_w2d5_01_066_mission");
            w2d5.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.Name = "OrMore";
            w2d5.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.SerializedValue = 5;
            bundles.W2D5Scenario.SetScenarioFiles(new Dictionary<string, ScenarioObjectItemGroup>() { { "story_w2d5_01_066_mission", w2d5 } });
        }

        public void Randomize(RandomizationSettings settings, int seed)
        {
            rand = new Random(seed);
            Randomize(settings);
        }

        public bool Save(string filePath, int seed)
        {
            bool result = SaveBundles(filePath);
            result = result && logger.SaveLogToFile(Path.Combine(filePath, string.Format("Randomization-Log-{0}.log", seed.ToString())));
            return result;
        }

        public string GetScript(string scriptName)
        {
            return scripts[scriptName];
        }

        public int RandNext()
        {
            return rand.Next();
        }

        public int RandNext(int max)
        {
            return rand.Next(max);
        }

        public int RandNext(int min, int max)
        {
            return rand.Next(min, max);
        }

        public double RandNextDouble()
        {
            return rand.NextDouble();
        }

        public double RandNextDoubleRange(double min, double max)
        {
            double range = max - min;
            return (range * rand.NextDouble()) + min;
        }

        public float RandNextRoundedFloatRange(double min, double max, int decimals)
        {
            return (float)Math.Round(RandNextDoubleRange(min, max), decimals);
        }

        public List<int> RandGenerateListOfSum(int count, int sum)
        {
            List<int> points = Enumerable.Range(0, count - 1).Select(n => rand.Next(sum - count + 1)).OrderBy(n => n).ToList();
            List<int> values = new List<int>();
            values.Add(points[0] + 1);
            for (int i = 0; i < points.Count() - 1; i++)
            {
                values.Add(points[i + 1] - points[i] + 1);
            }
            values.Add(sum - count - points[points.Count() - 1] + 1);

            return values;
        }

        private bool SaveBundles(string filePath)
        {
            try
            {
                bundleEngine.SaveBundleToFile(bundles.TextData, filePath);
                bundleEngine.SaveBundleToFile(bundles.W1D2Scenario, filePath);
                bundleEngine.SaveBundleToFile(bundles.W2D5Scenario, filePath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing one of the data files. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private Dictionary<string, string> GetBaseScripts()
        {
            return new Dictionary<string, string>
            {
                { FileConstants.EnemyDataClassName, bundles.TextData.GetScriptFile(FileConstants.EnemyDataClassName) },
                { FileConstants.PigDataClassName, bundles.TextData.GetScriptFile(FileConstants.PigDataClassName) },
                { FileConstants.BadgeClassName, bundles.TextData.GetScriptFile(FileConstants.BadgeClassName) },
                { FileConstants.PsychicClassName, bundles.TextData.GetScriptFile(FileConstants.PsychicClassName) },
                { FileConstants.AttackComboSetClassName, bundles.TextData.GetScriptFile(FileConstants.AttackComboSetClassName) },
                { FileConstants.AttackClassName, bundles.TextData.GetScriptFile(FileConstants.AttackClassName) },
                { FileConstants.AttackHitClassName, bundles.TextData.GetScriptFile(FileConstants.AttackHitClassName) },
                { FileConstants.ScenarioRewardsClassName, bundles.TextData.GetScriptFile(FileConstants.ScenarioRewardsClassName) }
            };
        }
    }
}
