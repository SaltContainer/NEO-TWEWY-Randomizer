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
            logger = new RandomizationLogger();
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

        public void Randomize(RandomizationSettings settings)
        {
            if (rand == null) rand = new Random();

            scripts.AddRange(GetBaseScripts());
            scripts.AddRange(RandomizeDroppedPins(settings));
            scripts.AddRange(RandomizeDropRate(settings));

            dataManipulator.SetScriptFilesToBundle(FileConstants.TextDataBundleKey, scripts);
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
            obtainedScripts.Add(FileConstants.EnemyDataClassName, dataManipulator.GetScriptFileFromBundle(FileConstants.TextDataBundleKey, FileConstants.EnemyDataClassName));
            obtainedScripts.Add(FileConstants.PigDataClassName, dataManipulator.GetScriptFileFromBundle(FileConstants.TextDataBundleKey, FileConstants.PigDataClassName));
            return obtainedScripts;
        }

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
            string enemyDataScript = scripts[FileConstants.EnemyDataClassName];
            string pigsScript = scripts[FileConstants.PigDataClassName];

            EnemyDataList enemyDataOriginal = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyDataList enemyData = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            PigDataList pigDataOriginal = JsonConvert.DeserializeObject<PigDataList>(pigsScript);
            PigDataList pigData = JsonConvert.DeserializeObject<PigDataList>(pigsScript);

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<PigData> pigsToEditOriginal = pigDataOriginal.Items.Where(pig => FileConstants.ItemNames.Pigs.Select(p => p.Id).Contains(pig.Id)).ToList();
            List<PigData> pigsToEdit = pigData.Items.Where(pig => FileConstants.ItemNames.Pigs.Select(p => p.Id).Contains(pig.Id)).ToList();

            bool dropEasy = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate);

            bool limited = settings.IncludeLimitedPins;

            switch (settings.DropType)
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
            if (settings.DropType == NoiseDropType.RandomAllPins) logger.LogPigDropChanges(pigsToEditOriginal, pigsToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { FileConstants.EnemyDataClassName, JsonConvert.SerializeObject(enemyData, Formatting.Indented) },
                { FileConstants.PigDataClassName, JsonConvert.SerializeObject(pigData, Formatting.Indented) }
            };
            return editedScripts;
        }

        private Dictionary<string, string> RandomizeDropRate(RandomizationSettings settings)
        {
            string enemyDataScript = scripts[FileConstants.EnemyDataClassName];

            EnemyDataList enemyDataOriginal = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyDataList enemyData = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();

            bool dropEasy = settings.NoiseDropRateDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDropRateDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDropRateDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDropRateDifficulties.Contains(Difficulties.Ultimate);

            double min = (double) (settings.MinimumDropRate / 100M);
            double max = (double) (settings.MaximumDropRate / 100M);

            switch (settings.DropRate)
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
                    if (dropEasy) weightsOn.Add(settings.NoiseDropRateWeights[0]);
                    if (dropNormal) weightsOn.Add(settings.NoiseDropRateWeights[1]);
                    if (dropHard) weightsOn.Add(settings.NoiseDropRateWeights[2]);
                    if (dropUltimate) weightsOn.Add(settings.NoiseDropRateWeights[3]);

                    uint wMin = weightsOn.Min();
                    uint wMax = weightsOn.Max();
                    uint wRange = wMax - wMin;

                    double range = max - min;
                    double unit = range / (wRange + 1);

                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.DropRate[0] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDropRateWeights[0]) * unit)) - (min+((settings.NoiseDropRateWeights[0] - 1) * unit)))) + (min + ((settings.NoiseDropRateWeights[0] - 1) * unit)), 4);
                        if (dropNormal) data.DropRate[1] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDropRateWeights[1]) * unit)) - (min + ((settings.NoiseDropRateWeights[1] - 1) * unit)))) + (min + ((settings.NoiseDropRateWeights[1] - 1) * unit)), 4);
                        if (dropHard) data.DropRate[2] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDropRateWeights[2]) * unit)) - (min + ((settings.NoiseDropRateWeights[2] - 1) * unit)))) + (min + ((settings.NoiseDropRateWeights[2] - 1) * unit)), 4);
                        if (dropUltimate) data.DropRate[3] = (float) Math.Round((rand.NextDouble() * ((min + ((settings.NoiseDropRateWeights[3]) * unit)) - (min + ((settings.NoiseDropRateWeights[3] - 1) * unit)))) + (min + ((settings.NoiseDropRateWeights[3] - 1) * unit)), 4);
                    }
                    
                    AdjustEnemyDataDropRate(enemyData);
                    break;
            }

            logger.LogDropRateChanges(listToEditOriginal, listToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { FileConstants.EnemyDataClassName, JsonConvert.SerializeObject(enemyData, Formatting.Indented) }
            };
            return editedScripts;
        }
    }
}
