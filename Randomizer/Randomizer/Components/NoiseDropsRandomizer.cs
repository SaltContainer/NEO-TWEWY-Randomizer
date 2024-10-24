using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class NoiseDropsRandomizer
    {
        private RandomizationEngine engine;

        public NoiseDropsRandomizer(RandomizationEngine engine)
        {
            this.engine = engine;
        }

        public Dictionary<string, string> RandomizeDroppedPins(RandomizationSettings settings)
        {
            string enemyDataScript = engine.GetScript(FileConstants.EnemyDataClassName);
            string pigsScript = engine.GetScript(FileConstants.PigDataClassName);

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

                    scPins = scPins.OrderBy(pin => engine.RandNext()).ToList();

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
                    ssPins = ssPins.OrderBy(pin => engine.RandNext()).ToList();

                    for (int i = 0; i < listToEdit.Count; i++)
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
                        if (dropEasy) data.Drop[0] = rcPins[engine.RandNext(rcPins.Count)];
                        if (dropNormal) data.Drop[1] = rcPins[engine.RandNext(rcPins.Count)];
                        if (dropHard) data.Drop[2] = rcPins[engine.RandNext(rcPins.Count)];
                        if (dropUltimate) data.Drop[3] = rcPins[engine.RandNext(rcPins.Count)];
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
                    raEnemies = raEnemies.OrderBy(enemy => engine.RandNext()).ToList();

                    for (int i = 0; i < raPins.Count; i++)
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
                    for (int i = raPins.Count; i < raEnemies.Count; i++)
                    {
                        var (e, d) = raEnemies[i];
                        if (e < raEnemyCount)
                        {
                            listToEdit[e].Drop[d] = raPins[engine.RandNext(raPins.Count)];
                        }
                        else
                        {
                            pigsToEdit[e - raEnemyCount].Drop = raPins[engine.RandNext(raPins.Count)];
                        }
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    break;
            }

            engine.Logger.LogDropTypeChanges(listToEditOriginal, listToEdit);
            if (settings.NoiseDrops.DropTypeChoice == NoiseDropType.RandomAllPins) engine.Logger.LogPigDropChanges(pigsToEditOriginal, pigsToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { FileConstants.EnemyDataClassName, JsonConvert.SerializeObject(enemyData, Formatting.Indented) },
                { FileConstants.PigDataClassName, JsonConvert.SerializeObject(pigData, Formatting.Indented) }
            };
            return editedScripts;
        }

        public Dictionary<string, string> RandomizeDropRate(RandomizationSettings settings)
        {
            string enemyDataScript = engine.GetScript(FileConstants.EnemyDataClassName);

            EnemyDataList enemyDataOriginal = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyDataList enemyData = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => e.Id).Contains(data.Id)).ToList();

            bool dropEasy = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Ultimate);

            double min = (double)(settings.NoiseDrops.MinimumDropRate / 100M);
            double max = (double)(settings.NoiseDrops.MaximumDropRate / 100M);

            switch (settings.NoiseDrops.DropRateChoice)
            {
                case NoiseDropRate.RandomCompletely:
                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.DropRate[0] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                        if (dropNormal) data.DropRate[1] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                        if (dropHard) data.DropRate[2] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                        if (dropUltimate) data.DropRate[3] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
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
                        if (dropEasy) data.DropRate[0] = (float)Math.Round((engine.RandNextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[0]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[0] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[0] - 1) * unit)), 4);
                        if (dropNormal) data.DropRate[1] = (float)Math.Round((engine.RandNextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[1]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[1] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[1] - 1) * unit)), 4);
                        if (dropHard) data.DropRate[2] = (float)Math.Round((engine.RandNextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[2]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[2] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[2] - 1) * unit)), 4);
                        if (dropUltimate) data.DropRate[3] = (float)Math.Round((engine.RandNextDouble() * ((min + ((settings.NoiseDrops.DropRateWeights[3]) * unit)) - (min + ((settings.NoiseDrops.DropRateWeights[3] - 1) * unit)))) + (min + ((settings.NoiseDrops.DropRateWeights[3] - 1) * unit)), 4);
                    }

                    AdjustEnemyDataDropRate(enemyData);
                    break;
            }

            engine.Logger.LogDropRateChanges(listToEditOriginal, listToEdit);

            Dictionary<string, string> editedScripts = new Dictionary<string, string>
            {
                { FileConstants.EnemyDataClassName, JsonConvert.SerializeObject(enemyData, Formatting.Indented, new FloatFormatConverter(4)) }
            };
            return editedScripts;
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
    }
}
