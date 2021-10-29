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

        private void AdjustEnemyDataDropRate(EnemyDataList enemyData)
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
                    AdjustEnemyDataDropRate(enemyData);
                    break;

                case NoiseDropType.ShuffleSets:
                    List<IList<int>> ssPins = listToEditOriginal.Select(data => data.Drop).ToList();
                    ssPins = ssPins.OrderBy(pin => rand.Next()).ToList();

                    for (int i=0; i<listToEdit.Count; i++)
                    {
                        listToEdit[i].Drop = ssPins[i];
                    }
                    AdjustEnemyDataDropRate(enemyData);
                    break;

                case NoiseDropType.RandomCompletely:
                    List<int> rcPins = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
                    if (limited) rcPins.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => p.Id));

                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.Drop[0] = rcPins[rand.Next(rcPins.Count)];
                        if (dropNormal) data.Drop[1] = rcPins[rand.Next(rcPins.Count)];
                        if (dropHard) data.Drop[2] = rcPins[rand.Next(rcPins.Count)];
                        if (dropUltimate) data.Drop[3] = rcPins[rand.Next(rcPins.Count)];
                    }
                    AdjustEnemyDataDropRate(enemyData);
                    break;

                case NoiseDropType.RandomAllPins:
                    List<int> raPins = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
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
                    AdjustEnemyDataDropRate(enemyData);
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
    }
}
