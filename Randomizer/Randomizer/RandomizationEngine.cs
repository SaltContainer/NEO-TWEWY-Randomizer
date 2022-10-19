using AssetsTools.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class RandomizationEngine
    {
        private Random rand;
        private DataManipulator dataManipulator;
        private RandomizationLogger logger;
        private Dictionary<string, string> scripts;

        public RandomizationEngine()
        {
            dataManipulator = new DataManipulator();
            scripts = new Dictionary<string, string>();
        }

        public bool LoadFiles(Dictionary<string, string> fileNames)
        {
            return dataManipulator.LoadBundles(fileNames);
        }

        public bool AreFilesLoaded()
        {
            return dataManipulator.AreFilesLoaded();
        }

        // TODO: REMOVE TESTING
        public void TestMethod()
        {
            logger = new RandomizationLogger();

            string file1 = dataManipulator.GetScriptFileFromBundle("w1d2-scenario", ScenarioFileNames.W1D2_104Dogenzaka_Progress);
            Scenario scenario1 = JsonConvert.DeserializeObject<Scenario>(file1);
            scenario1.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList.Clear();
            scenario1.Ready.List[0].Kind.Name = "MissionId";
            scenario1.Ready.List[0].Kind.SerializedValue = 4;
            scenario1.Ready.List[0].Index.Name = "WinSeriesBattle02";
            scenario1.Ready.List[0].Index.SerializedValue = 120010;
            scenario1.Ready.List[0].ScenarioKindExtension.IndexKind = 4;

            string file2 = dataManipulator.GetScriptFileFromBundle("w1d2-scenario", ScenarioFileNames.W1D2_104Dogenzaka_Complete);
            Scenario scenario2 = JsonConvert.DeserializeObject<Scenario>(file2);
            scenario2.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList.Clear();
            scenario2.Ready.List[0].Kind.Name = "MissionId";
            scenario2.Ready.List[0].Kind.SerializedValue = 4;
            scenario2.Ready.List[0].Index.Name = "WinSeriesBattle02";
            scenario2.Ready.List[0].Index.SerializedValue = 120010;
            scenario2.Ready.List[0].ScenarioKindExtension.IndexKind = 4;

            string file3 = dataManipulator.GetScriptFileFromBundle("w1d2-scenario", ScenarioFileNames.W1D2_104Dogenzaka_Intro);
            Scenario scenario3 = JsonConvert.DeserializeObject<Scenario>(file3);
            scenario3.Result.Add(scenario2.Ready.List[0]);

            Dictionary<string, string> dict = new Dictionary<string, string>() {
                { ScenarioFileNames.W1D2_104Dogenzaka_Progress, JsonConvert.SerializeObject(scenario1) },
                { ScenarioFileNames.W1D2_104Dogenzaka_Complete, JsonConvert.SerializeObject(scenario2) },
                { ScenarioFileNames.W1D2_104Dogenzaka_Intro, JsonConvert.SerializeObject(scenario3) }
            };
            dataManipulator.SetScriptFilesToBundle("w1d2-scenario", dict);
        }

        public void Randomize(RandomizationSettings settings)
        {
            if (rand == null) rand = new Random();

            logger = new RandomizationLogger();
            logger.LogSettings(settings);

            scripts.AddRange(GetBaseScripts());
            scripts.AddRange(RandomizeDroppedPins(settings));
            scripts.AddRange(RandomizeDropRate(settings));
            scripts.AddRange(RandomizePinStats(settings));
            scripts.AddRange(RandomizeStoryRewards(settings));

            dataManipulator.SetScriptFilesToBundle(TextDataFileNames.TextDataBundleKey, scripts);
        }

        public void Randomize(RandomizationSettings settings, int seed)
        {
            rand = new Random(seed);
            Randomize(settings);
        }

        public bool Save(string filePath, int seed)
        {
            bool result = dataManipulator.SaveBundles(filePath);
            result = result && logger.SaveLogToFile(string.Format("{0}\\Randomization-Log-{1}.log", filePath, seed.ToString()));
            return result;
        }

        private Dictionary<string, string> GetBaseScripts()
        {
            Dictionary<string, string> obtainedScripts = new Dictionary<string, string>();
            obtainedScripts.Add(TextDataFileNames.EnemyDataFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.EnemyDataFileName));
            obtainedScripts.Add(TextDataFileNames.PigDataFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.PigDataFileName));
            obtainedScripts.Add(TextDataFileNames.BadgeFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.BadgeFileName));
            obtainedScripts.Add(TextDataFileNames.PsychicFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.PsychicFileName));
            obtainedScripts.Add(TextDataFileNames.AttackComboSetFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.AttackComboSetFileName));
            obtainedScripts.Add(TextDataFileNames.AttackFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.AttackFileName));
            obtainedScripts.Add(TextDataFileNames.AttackHitFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.AttackHitFileName));
            obtainedScripts.Add(TextDataFileNames.ScenarioRewardsFileName, dataManipulator.GetScriptFileFromBundle(TextDataFileNames.TextDataBundleKey, TextDataFileNames.ScenarioRewardsFileName));
            return obtainedScripts;
        }

        private double NextDoubleRange(double min, double max)
        {
            double range = max - min;
            return (range * rand.NextDouble()) + min;
        }

        private float NextRoundedFloatRange(double min, double max, int decimals)
        {
            return (float) Math.Round(NextDoubleRange(min, max), decimals);
        }

        private List<int> GenerateListOfSum(int count, int sum)
        {
            List<int> points = Enumerable.Range(0, count - 1).Select(n => rand.Next(sum - count + 1)).OrderBy(n => n).ToList();
            List<int> values = new List<int>();
            values.Add(points[0] + 1);
            for (int i=0; i<points.Count()-1; i++)
            {
                values.Add(points[i + 1] - points[i] + 1);
            }
            values.Add(sum - count - points[points.Count() - 1] + 1);

            return values;
        }

        #region Noise Drops
        private void AdjustEnemyDataDroppedPins(EnemyDataList enemyData)
        {
            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.Duplicates)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<int>(original.Drop));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.ForcedNormalDrops)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<int>(original.Drop));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.NoDrops)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<int>(original.Drop));
            }
        }

        private void AdjustEnemyDataDropRate(EnemyDataList enemyData)
        {
            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.Duplicates)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.DropRate = new List<float>(original.DropRate));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.ForcedNormalDrops)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy =>
                {
                    enemy.DropRate = new List<float>(original.DropRate);
                    enemy.DropRate[1] = 1;
                });
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.NoDrops)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.DropRate = new List<float> { 0, 0, 0, 0 });
            }
        }

        private Dictionary<string, string> RandomizeDroppedPins(RandomizationSettings settings)
        {
            string enemyDataScript = scripts[TextDataFileNames.EnemyDataFileName];
            string pigsScript = scripts[TextDataFileNames.PigDataFileName];

            EnemyDataList enemyDataOriginal = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyDataList enemyData = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            PigDataList pigDataOriginal = JsonConvert.DeserializeObject<PigDataList>(pigsScript);
            PigDataList pigData = JsonConvert.DeserializeObject<PigDataList>(pigsScript);

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<PigData> pigsToEditOriginal = pigDataOriginal.Items.Where(pig => FileConstants.ItemNames.Pigs.Select(p => p.Id).Contains(pig.Id)).ToList();
            List<PigData> pigsToEdit = pigData.Items.Where(pig => FileConstants.ItemNames.Pigs.Select(p => p.Id).Contains(pig.Id)).ToList();

            bool dropEasy = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Ultimate);

            bool limited = settings.NoiseDrops.IncludeLimitedPins;

            switch (settings.NoiseDrops.DropTypeChoice)
            {
                case NoiseDropType.ShuffleCompletely:
                    List<int> scPins = new List<int>();
                    if (dropEasy) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[0]));
                    if (dropNormal) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[1]));
                    if (dropHard) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[2]));
                    if (dropUltimate) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[3]));

                    scPins = scPins.OrderBy(pin => rand.Next()).ToList();

                    int pinId = 0;
                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.Drop[0] = scPins[pinId++];
                        if (dropNormal) data.Drop[1] = scPins[pinId++];
                        if (dropHard) data.Drop[2] = scPins[pinId++];
                        if (dropUltimate) data.Drop[3] = scPins[pinId++];
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    break;

                case NoiseDropType.ShuffleSets:
                    List<IList<int>> ssPins = listToEditOriginal.Select(data => data.Drop).ToList();
                    ssPins = ssPins.OrderBy(pin => rand.Next()).ToList();

                    for (int i=0; i<listToEdit.Count; i++)
                    {
                        listToEdit[i].Drop = ssPins[i];
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    break;

                case NoiseDropType.RandomCompletely:
                    List<int> rcPins = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
                    rcPins.AddRange(FileConstants.ItemNames.YenPins.Select(p => p.Id));
                    rcPins.AddRange(FileConstants.ItemNames.GemPins.Select(p => p.Id));
                    if (limited) rcPins.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => p.Id));

                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.Drop[0] = rcPins[rand.Next(rcPins.Count)];
                        if (dropNormal) data.Drop[1] = rcPins[rand.Next(rcPins.Count)];
                        if (dropHard) data.Drop[2] = rcPins[rand.Next(rcPins.Count)];
                        if (dropUltimate) data.Drop[3] = rcPins[rand.Next(rcPins.Count)];
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    break;

                case NoiseDropType.RandomAllPins:
                    List<int> raPins = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
                    raPins.AddRange(FileConstants.ItemNames.YenPins.Select(p => p.Id));
                    raPins.AddRange(FileConstants.ItemNames.GemPins.Select(p => p.Id));
                    if (limited) raPins.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => p.Id));

                    int raEnemyCount = listToEdit.Count;

                    List<(int, int)> raEnemies = Enumerable.Range(0, raEnemyCount).SelectMany(e => Enumerable.Range(0, 4).Select(d => (e, d))).ToList();
                    raEnemies.AddRange(Enumerable.Range(raEnemyCount, pigsToEdit.Count).Select(p => (p, 0)).ToList());
                    raEnemies = raEnemies.OrderBy(enemy => rand.Next()).ToList();

                    for (int i=0; i<raPins.Count; i++)
                    {
                        var (e, d) = raEnemies[i];
                        if (e < raEnemyCount)
                        {
                            listToEdit[e].Drop[d] = raPins[i];
                        }
                        else
                        {
                            pigsToEdit[e - raEnemyCount].Drop = raPins[i];
                        }
                    }
                    for (int i=raPins.Count; i<raEnemies.Count; i++)
                    {
                        var (e, d) = raEnemies[i];
                        if (e < raEnemyCount)
                        {
                            listToEdit[e].Drop[d] = raPins[rand.Next(raPins.Count)];
                        }
                        else
                        {
                            pigsToEdit[e - raEnemyCount].Drop = raPins[rand.Next(raPins.Count)];
                        }
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    break;
            }

            logger.LogDropTypeChanges(listToEditOriginal, listToEdit);
            if (settings.NoiseDrops.DropTypeChoice == NoiseDropType.RandomAllPins) logger.LogPigDropChanges(pigsToEditOriginal, pigsToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { TextDataFileNames.EnemyDataFileName, JsonConvert.SerializeObject(enemyData, Formatting.Indented) },
                { TextDataFileNames.PigDataFileName, JsonConvert.SerializeObject(pigData, Formatting.Indented) }
            };
            return editedScripts;
        }

        private Dictionary<string, string> RandomizeDropRate(RandomizationSettings settings)
        {
            string enemyDataScript = scripts[TextDataFileNames.EnemyDataFileName];

            EnemyDataList enemyDataOriginal = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyDataList enemyData = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();

            bool dropEasy = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Ultimate);

            double min = (double) (settings.NoiseDrops.MinimumDropRate / 100M);
            double max = (double) (settings.NoiseDrops.MaximumDropRate / 100M);

            switch (settings.NoiseDrops.DropRateChoice)
            {
                case NoiseDropRate.RandomCompletely:
                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.DropRate[0] = (float) Math.Round((rand.NextDouble() * (max-min)) + min, 4);
                        if (dropNormal) data.DropRate[1] = (float) Math.Round((rand.NextDouble() * (max - min)) + min, 4);
                        if (dropHard) data.DropRate[2] = (float) Math.Round((rand.NextDouble() * (max - min)) + min, 4);
                        if (dropUltimate) data.DropRate[3] = (float) Math.Round((rand.NextDouble() * (max - min)) + min, 4);
                    }
                    AdjustEnemyDataDropRate(enemyData);
                    break;

                case NoiseDropRate.RandomWeighted:
                    List<uint> weightsOn = new List<uint>();
                    if (dropEasy) weightsOn.Add(settings.NoiseDrops.DropRateWeights[0]);
                    if (dropNormal) weightsOn.Add(settings.NoiseDrops.DropRateWeights[1]);
                    if (dropHard) weightsOn.Add(settings.NoiseDrops.DropRateWeights[2]);
                    if (dropUltimate) weightsOn.Add(settings.NoiseDrops.DropRateWeights[3]);

                    uint wMin = weightsOn.Min();
                    uint wMax = weightsOn.Max();
                    uint wRange = wMax - wMin;

                    double range = max - min;
                    double unit = range / (wRange + 1);

                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.DropRate[0] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[0]) * unit)) - (min+((settings.NoiseDrops.DropRateWeights[0] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[0] - 1) * unit)), 4);
                        if (dropNormal) data.DropRate[1] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[1]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[1] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[1] - 1) * unit)), 4);
                        if (dropHard) data.DropRate[2] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[2]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[2] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[2] - 1) * unit)), 4);
                        if (dropUltimate) data.DropRate[3] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[3]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[3] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[3] - 1) * unit)), 4);
                    }
                    
                    AdjustEnemyDataDropRate(enemyData);
                    break;
            }

            logger.LogDropRateChanges(listToEditOriginal, listToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { TextDataFileNames.EnemyDataFileName, JsonConvert.SerializeObject(enemyData, Formatting.Indented, new FloatFormatConverter(4)) }
            };
            return editedScripts;
        }
        #endregion

        #region Pin Stats
        private Dictionary<int, List<AttackHit>> FindAttackHitsToModify(List<Badge> pins, AttackHitList dataToSearch)
        {
            string psychicDataScript = scripts[TextDataFileNames.PsychicFileName];
            string attackComboSetDataScript = scripts[TextDataFileNames.AttackComboSetFileName];
            string attackDataScript = scripts[TextDataFileNames.AttackFileName];

            PsychicList psychicDataOriginal = JsonConvert.DeserializeObject<PsychicList>(psychicDataScript);
            AttackComboSetList attackComboSetDataOriginal = JsonConvert.DeserializeObject<AttackComboSetList>(attackComboSetDataScript);
            AttackList attackDataOriginal = JsonConvert.DeserializeObject<AttackList>(attackDataScript);

            Dictionary<int, Psychic> psDict = pins.ToDictionary(p => p.Id, p => psychicDataOriginal.Items.Where(ps => ps.Id == p.Psychic).First());
            Dictionary<int, AttackComboSet> acsDict = psDict.ToDictionary(ps => ps.Key, ps => attackComboSetDataOriginal.Items.Where(acs => acs.Id == ps.Value.AttackComboSet).First());
            Dictionary<int, List<Attack>> atkDict = acsDict.ToDictionary(acs => acs.Key, acs => attackDataOriginal.Items.Where(atk => acs.Value.AttackList.Contains(atk.Id)).ToList());
            Dictionary<int, List<AttackHit>> hitDict = atkDict.ToDictionary(atk => atk.Key, atk => dataToSearch.Items.Where(hit => atk.Value.SelectMany(a => a.HitList).Contains(hit.Id)).ToList());

            return hitDict;
        }

        private Dictionary<string, string> RandomizePinStats(RandomizationSettings settings)
        {
            string pinDataScript = scripts[TextDataFileNames.BadgeFileName];
            string attackHitScript = scripts[TextDataFileNames.AttackHitFileName];

            BadgeList pinDataOriginal = JsonConvert.DeserializeObject<BadgeList>(pinDataScript);
            BadgeList pinData = JsonConvert.DeserializeObject<BadgeList>(pinDataScript);

            AttackHitList attackHitDataOriginal = JsonConvert.DeserializeObject<AttackHitList>(attackHitScript);
            AttackHitList attackHitData = JsonConvert.DeserializeObject<AttackHitList>(attackHitScript);

            List<Badge> listToEditOriginal = pinDataOriginal.Items.Where(data => FileConstants.ItemNames.Pins.Select(p => p.Id).Contains(data.Id)).ToList();
            List<Badge> listToEdit = pinData.Items.Where(data => FileConstants.ItemNames.Pins.Select(p => p.Id).Contains(data.Id)).ToList();

            Dictionary<int, List<AttackHit>> attackHitToEdit = FindAttackHitsToModify(listToEdit, attackHitData);

            if (settings.PinStats.MaxLevel) listToEdit.ForEach(p => p.MaxLevel = rand.Next(2, 11));

            if (settings.PinStats.Power) listToEdit.ForEach(p => p.Power = rand.Next(50, 1401));
            if (settings.PinStats.PowerScaling) listToEdit.ForEach(p => p.PowerScaling = rand.Next(0, 101));

            if (settings.PinStats.Limit) listToEdit.ForEach(p => p.Limit = rand.Next(3, 11));
            if (settings.PinStats.LimitScaling) listToEdit.ForEach(p => p.LimitScaling = rand.Next(0, 3));

            if (settings.PinStats.Reboot) listToEdit.ForEach(p => p.Reboot = NextRoundedFloatRange(5, 20, 1));
            if (settings.PinStats.RebootScaling) listToEdit.ForEach(p => p.RebootScaling = NextRoundedFloatRange(0, Math.Max(0, (p.Reboot - 1) / (p.MaxLevel - 1) - 0.1), 1));

            if (settings.PinStats.Boot) listToEdit.ForEach(p => p.Boot = Math.Max(0, NextRoundedFloatRange(-6, 6, 1)));
            if (settings.PinStats.BootScaling) listToEdit.ForEach(p => p.BootScaling = NextRoundedFloatRange(0, Math.Max(0, (p.Boot) / (p.MaxLevel - 1) - 0.1), 1));

            if (settings.PinStats.Recover) listToEdit.ForEach(p => p.Recover = p.Reboot + NextRoundedFloatRange(0, 6, 1));
            if (settings.PinStats.RecoverScaling) listToEdit.ForEach(p => p.RecoverScaling = NextRoundedFloatRange(0, Math.Max(0, (p.Recover - 1) / (p.MaxLevel - 1) - 0.1), 1));

            if (settings.PinStats.Charge) listToEdit.ForEach(p => p.Charge = NextRoundedFloatRange(0, 2, 1));

            if (settings.PinStats.Sell) listToEdit.ForEach(p => p.SellPrice = rand.Next(500, 10001));
            if (settings.PinStats.SellScaling) listToEdit.ForEach(p => p.SellPriceScaling = rand.Next(500, 2001));

            if (settings.PinStats.Affinity)
            {
                listToEdit.ForEach(p => {
                    p.MashUpAffinity = FileConstants.ItemNames.Affinities[rand.Next(FileConstants.ItemNames.Affinities.Count)].Id;
                    attackHitToEdit[p.Id].ForEach(hit => hit.Affinity[0] = p.MashUpAffinity);
                });
            }

            switch (settings.PinStats.BrandChoice)
            {
                case PinBrand.Shuffle:
                    List<int> sbrands = new List<int>();
                    sbrands.AddRange(listToEdit.Select(p => p.Brand));

                    sbrands = sbrands.OrderBy(b => rand.Next()).ToList();

                    for (int i=0; i<listToEdit.Count(); i++)
                    {
                        listToEdit[i].Brand = sbrands[i];
                    }
                    break;

                case PinBrand.RandomCompletely:
                    listToEdit.ForEach(p => p.Brand = rand.Next(0, 16));
                    break;

                case PinBrand.RandomUniform:
                    List<int> rbrands = new List<int>();
                    rbrands.AddRange(FileConstants.ItemNames.Brands.Select(b => b.Id));

                    rbrands = rbrands.OrderBy(b => rand.Next()).ToList();

                    List<int> rPins = Enumerable.Range(0, listToEdit.Count()).ToList();
                    rPins = rPins.OrderBy(pin => rand.Next()).ToList();

                    int brandId = 0;
                    foreach (int i in rPins)
                    {
                        listToEdit[i].Brand = rbrands[brandId % rbrands.Count()];
                        brandId++;
                    }
                    break;
            }

            if (settings.PinStats.Uber)
            {
                List<int> pins = Enumerable.Range(0, listToEdit.Count()).ToList();
                pins = pins.OrderBy(pin => rand.Next()).ToList();

                float percentage = settings.PinStats.UberPercentage / 100f;
                int count = (int) (pins.Count * percentage);

                for (int i=0; i<listToEdit.Count; i++)
                {
                    listToEdit[pins[i]].Uber = i < count ? 1 : 0;
                    listToEdit[pins[i]].PinClass = i < count ? 5 : 0;
                }
            }

            switch (settings.PinStats.AbilityChoice)
            {
                case PinAbility.Shuffle:
                    List<IList<int>> sAbilities = new List<IList<int>>();
                    sAbilities.AddRange(listToEdit.Select(p => p.Abilities));

                    sAbilities = sAbilities.OrderBy(b => rand.Next()).ToList();

                    for (int i = 0; i < listToEdit.Count(); i++)
                    {
                        listToEdit[i].Abilities = sAbilities[i];
                    }
                    break;

                case PinAbility.RandomCompletely:
                    List<int> rAbilities = Enumerable.Range(0, listToEdit.Count()).ToList();
                    rAbilities = rAbilities.OrderBy(pin => rand.Next()).ToList();

                    float percentage = settings.PinStats.AbilityPercentage / 100f;
                    int count = (int)(rAbilities.Count * percentage);

                    for (int i = 0; i < listToEdit.Count; i++)
                    {
                        listToEdit[rAbilities[i]].Abilities.Clear();
                        if (i < count) listToEdit[rAbilities[i]].Abilities = new List<int>() { FileConstants.ItemNames.PinAbilities[rand.Next(FileConstants.ItemNames.PinAbilities.Count)].Id };
                    }
                    break;
            }

            switch (settings.PinStats.GrowthChoice)
            {
                case PinGrowthRandomization.RandomCompletely:
                    listToEdit.ForEach(p => p.Growth = FileConstants.ItemNames.GrowthRates[rand.Next(FileConstants.ItemNames.GrowthRates.Count)].Id);
                    break;

                case PinGrowthRandomization.RandomUniform:
                    List<int> growths = new List<int>();
                    growths.AddRange(FileConstants.ItemNames.GrowthRates.Select(r => r.Id));

                    List<int> pins = Enumerable.Range(0, listToEdit.Count()).ToList();
                    pins = pins.OrderBy(pin => rand.Next()).ToList();

                    int growthId = 0;
                    foreach (int i in pins)
                    {
                        listToEdit[i].Growth = growths[growthId % growths.Count()];
                        growthId++;
                    }
                    break;

                case PinGrowthRandomization.Specific:
                    listToEdit.ForEach(p => p.Growth = (int) settings.PinStats.GrowthSpecific);
                    break;
            }

            switch (settings.PinStats.EvolutionChoice)
            {
                case PinEvolution.RandomExisting:
                    foreach (Badge data in listToEdit)
                    {
                        List<int> possibleEvos;
                        if (settings.PinStats.EvoForceBrand) possibleEvos = listToEdit.Where(p => p.Brand == data.Brand).Select(p => p.Id).ToList();
                        else possibleEvos = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();

                        if (data.EvolutionSingle != -1)
                        {
                            data.EvolutionSingle = possibleEvos[rand.Next(possibleEvos.Count)];
                            data.EvolutionLevel = data.MaxLevel;
                        }
                        for (int i=0; i<data.EvolutionList.Count; i++)
                        {
                            if (data.EvolutionList[i] != -1)
                            {
                                data.EvolutionList[i] = possibleEvos[rand.Next(possibleEvos.Count)];
                                data.EvolutionLevel = data.MaxLevel;
                            }
                        }
                    }
                    break;

                case PinEvolution.RandomCompletely:
                    List<int> pins = Enumerable.Range(0, listToEdit.Count()).ToList();
                    pins = pins.OrderBy(pin => rand.Next()).ToList();

                    float percentage = settings.PinStats.EvoPercentage / 100f;
                    int count = (int)(pins.Count * percentage);

                    for (int i = 0; i < listToEdit.Count; i++)
                    {
                        if (i < count)
                        {
                            List<int> possibleEvos;
                            if (settings.PinStats.EvoForceBrand) possibleEvos = listToEdit.Where(p => p.Brand == listToEdit[pins[i]].Brand).Select(p => p.Id).ToList();
                            else possibleEvos = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();

                            bool single = rand.Next(3) < 2;
                            if (single)
                            {
                                listToEdit[pins[i]].EvolutionSingle = possibleEvos[rand.Next(possibleEvos.Count)];
                                listToEdit[pins[i]].EvolutionList.Clear();
                            }
                            else
                            {
                                int chara = rand.Next(7);
                                listToEdit[pins[i]].EvolutionSingle = -1;
                                listToEdit[pins[i]].EvolutionList = Enumerable.Repeat(-1, 7).ToList();
                                listToEdit[pins[i]].EvolutionList[chara] = possibleEvos[rand.Next(possibleEvos.Count)];
                            }
                            listToEdit[pins[i]].EvolutionLevel = listToEdit[pins[i]].MaxLevel;
                        }
                        else
                        {
                            listToEdit[pins[i]].EvolutionSingle = -1;
                            listToEdit[pins[i]].EvolutionList.Clear();
                            listToEdit[pins[i]].EvolutionLevel = 0;
                        }
                    }
                    break;
            }

            if (settings.PinStats.RemoveCharaEvos)
            {
                foreach (Badge data in listToEdit)
                {
                    if (data.EvolutionList.Count > 0)
                    {
                        data.EvolutionSingle = data.EvolutionList.Where(i => i != -1).First();
                        data.EvolutionList.Clear();
                    }
                }
            }

            logger.LogPinStatsChanges(listToEditOriginal, listToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { TextDataFileNames.BadgeFileName, JsonConvert.SerializeObject(pinData, Formatting.Indented, new FloatFormatConverter(1)) },
                { TextDataFileNames.AttackHitFileName, JsonConvert.SerializeObject(attackHitData, Formatting.Indented) }
            };
            return editedScripts;
        }
        #endregion

        #region Story Rewards
        private void ShuffleListOfStoryRewards(List<ScenarioRewards> rewards)
        {
            List<(int, int)> newIds = rewards.OrderBy(pin => rand.Next()).Select(p => (p.FirstReward, p.FirstRewardCount)).ToList();

            for (int i=0; i<rewards.Count(); i++)
            {
                rewards[i].FirstReward = newIds[i].Item1;
                rewards[i].FirstRewardCount = newIds[i].Item2;
            }
        }

        private void RandomizeListOfStoryRewards(List<ScenarioRewards> rewards, List<(int, int)> possibleIds)
        {
            foreach (var pin in rewards)
            {
                int newId = rand.Next(possibleIds.Count);
                pin.FirstReward = possibleIds[newId].Item1;
                pin.FirstRewardCount = possibleIds[newId].Item2;
            }
        }

        private Dictionary<string, string> RandomizeStoryRewards(RandomizationSettings settings)
        {
            string scenarioRewardsScript = scripts[TextDataFileNames.ScenarioRewardsFileName];

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

                    newIds = newIds.OrderBy(pin => rand.Next()).ToList();

                    for (int i=0; i<pinsToShuffle.Count(); i++)
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
                        if (pin.Item1 == 1) pin.Item2.FirstReward = randomIds[rand.Next(randomIds.Count)];
                        else if (pin.Item1 == 2) pin.Item2.SecondReward = randomIds[rand.Next(randomIds.Count)];
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
                    List<(int, int)> randomIds = FileConstants.ItemNames.GemPins.Select(p => (p.Id, rand.Next(1,4))).ToList();
                    RandomizeListOfStoryRewards(pinsToRando, randomIds);
                    break;
            }

            switch (settings.StoryRewards.FPChoice)
            {
                case StoryFP.Shuffle:
                    List<ScenarioRewards> fpToShuffle = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => p.Id).Contains(reward.Id)).ToList();
                    List<int> newCountsShuffle = fpToShuffle.OrderBy(pin => rand.Next()).Select(p => p.FirstRewardCount).ToList();

                    for (int i = 0; i < fpToShuffle.Count(); i++)
                    {
                        fpToShuffle[i].FirstRewardCount = newCountsShuffle[i];
                    }
                    break;

                case StoryFP.RandomFixedTotal:
                    int maxFp = 159;
                    List<ScenarioRewards> fpToRando = fullListToEdit.Where(reward => FileConstants.ItemNames.StoryFP.Select(p => p.Id).Contains(reward.Id)).ToList();
                    List<int> newCountsRando = GenerateListOfSum(fpToRando.Count(), maxFp);

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

                newRewards = newRewards.OrderBy(reward => rand.Next()).ToList();
                for (int i=0; i<rewardsToShuffle.Count(); i++)
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

            logger.LogStoryRewardChanges(fullListToEditOriginal, fullListToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { TextDataFileNames.ScenarioRewardsFileName, JsonConvert.SerializeObject(storyData, Formatting.Indented, new FloatFormatConverter(1)) }
            };
            return editedScripts;
        }
        #endregion
    }
}
