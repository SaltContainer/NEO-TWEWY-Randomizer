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

        public void RandomizeDroppedPins(RandomizationSettings settings)
        {
            EnemyDataList enemyDataOriginal = engine.Bundles.TextData.ParseEnemyData();
            EnemyDataList enemyData = engine.Bundles.TextData.GetEnemyData();
            PigDataList pigDataOriginal = engine.Bundles.TextData.ParsePigData();
            PigDataList pigData = engine.Bundles.TextData.GetPigData();

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => (EnemyData.Name)e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => (EnemyData.Name)e.Id).Contains(data.Id)).ToList();
            List<PigData> pigsToEditOriginal = pigDataOriginal.Items.Where(pig => FileConstants.ItemNames.Pigs.Select(p => (PigData.Label)p.Id).Contains(pig.Id)).ToList();
            List<PigData> pigsToEdit = pigData.Items.Where(pig => FileConstants.ItemNames.Pigs.Select(p => (PigData.Label)p.Id).Contains(pig.Id)).ToList();

            bool dropEasy = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Ultimate);

            bool limited = settings.NoiseDrops.IncludeLimitedPins;

            switch (settings.NoiseDrops.DropTypeChoice)
            {
                case NoiseDropType.ShuffleCompletely:
                {
                    List<Badge.Label> pins = [];
                    if (dropEasy) pins.AddRange(listToEditOriginal.Select(data => data.Drop[0]));
                    if (dropNormal) pins.AddRange(listToEditOriginal.Select(data => data.Drop[1]));
                    if (dropHard) pins.AddRange(listToEditOriginal.Select(data => data.Drop[2]));
                    if (dropUltimate) pins.AddRange(listToEditOriginal.Select(data => data.Drop[3]));

                    pins = pins.OrderBy(pin => engine.RandNext()).ToList();

                    int pinId = 0;
                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.Drop[0] = pins[pinId++];
                        if (dropNormal) data.Drop[1] = pins[pinId++];
                        if (dropHard) data.Drop[2] = pins[pinId++];
                        if (dropUltimate) data.Drop[3] = pins[pinId++];
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    RemovePinSpecificMissions();
                }
                break;

                case NoiseDropType.ShuffleSets:
                {
                    List<IList<Badge.Label>> pins = listToEditOriginal.Select(data => data.Drop).ToList();
                    pins = pins.OrderBy(pin => engine.RandNext()).ToList();

                    for (int i=0; i<listToEdit.Count; i++)
                        listToEdit[i].Drop = pins[i];

                    AdjustEnemyDataDroppedPins(enemyData);
                    RemovePinSpecificMissions();
                }
                break;

                case NoiseDropType.RandomCompletely:
                {
                    List<Badge.Label> pins = FileConstants.ItemNames.Pins.Select(p => (Badge.Label)p.Id).ToList();
                    pins.AddRange(FileConstants.ItemNames.YenPins.Select(p => (Badge.Label)p.Id));
                    pins.AddRange(FileConstants.ItemNames.GemPins.Select(p => (Badge.Label)p.Id));
                    if (limited) pins.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => (Badge.Label)p.Id));

                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.Drop[0] = pins[engine.RandNext(pins.Count)];
                        if (dropNormal) data.Drop[1] = pins[engine.RandNext(pins.Count)];
                        if (dropHard) data.Drop[2] = pins[engine.RandNext(pins.Count)];
                        if (dropUltimate) data.Drop[3] = pins[engine.RandNext(pins.Count)];
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    RemovePinSpecificMissions();
                }
                break;

                case NoiseDropType.RandomAllPins:
                {
                    List<Badge.Label> pins = FileConstants.ItemNames.Pins.Select(p => (Badge.Label)p.Id).ToList();
                    pins.AddRange(FileConstants.ItemNames.YenPins.Select(p => (Badge.Label)p.Id));
                    pins.AddRange(FileConstants.ItemNames.GemPins.Select(p => (Badge.Label)p.Id));
                    if (limited) pins.AddRange(FileConstants.ItemNames.LimitedPins.Select(p => (Badge.Label)p.Id));

                    int enemyCount = listToEdit.Count;

                    List<(int, int)> enemies = Enumerable.Range(0, enemyCount).SelectMany(e => Enumerable.Range(0, 4).Select(d => (e, d))).ToList();
                    enemies.AddRange(Enumerable.Range(enemyCount, pigsToEdit.Count).Select(p => (p, 0)).ToList());
                    enemies = enemies.OrderBy(enemy => engine.RandNext()).ToList();

                    for (int i=0; i<pins.Count; i++)
                    {
                        var (e, d) = enemies[i];
                        if (e < enemyCount)
                        {
                            listToEdit[e].Drop[d] = pins[i];
                        }
                        else
                        {
                            pigsToEdit[e - enemyCount].Drop = pins[i];
                        }
                    }
                    for (int i=pins.Count; i<enemies.Count; i++)
                    {
                        var (e, d) = enemies[i];
                        if (e < enemyCount)
                        {
                            listToEdit[e].Drop[d] = pins[engine.RandNext(pins.Count)];
                        }
                        else
                        {
                            pigsToEdit[e - enemyCount].Drop = pins[engine.RandNext(pins.Count)];
                        }
                    }
                    AdjustEnemyDataDroppedPins(enemyData);
                    RemovePinSpecificMissions();
                }
                break;
            }

            engine.Logger.LogDropTypeChanges(listToEditOriginal, listToEdit);
            if (settings.NoiseDrops.DropTypeChoice == NoiseDropType.RandomAllPins)
                engine.Logger.LogPigDropChanges(pigsToEditOriginal, pigsToEdit);
        }

        public void RandomizeDropRate(RandomizationSettings settings)
        {
            EnemyDataList enemyDataOriginal = engine.Bundles.TextData.ParseEnemyData();
            EnemyDataList enemyData = engine.Bundles.TextData.GetEnemyData();

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => (EnemyData.Name)e.Id).Contains(data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Items.Where(data => FileConstants.ItemNames.Enemies.Select(e => (EnemyData.Name)e.Id).Contains(data.Id)).ToList();

            bool dropEasy = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Ultimate);

            double min = (double)(settings.NoiseDrops.MinimumDropRate / 100M);
            double max = (double)(settings.NoiseDrops.MaximumDropRate / 100M);

            switch (settings.NoiseDrops.DropRateChoice)
            {
                case NoiseDropRate.RandomCompletely:
                {
                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.DropRate[0] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                        if (dropNormal) data.DropRate[1] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                        if (dropHard) data.DropRate[2] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                        if (dropUltimate) data.DropRate[3] = (float)Math.Round((engine.RandNextDouble() * (max - min)) + min, 4);
                    }
                    AdjustEnemyDataDropRate(enemyData);
                }
                break;

                case NoiseDropRate.RandomWeighted:
                {
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
                }
                break;
            }

            engine.Logger.LogDropRateChanges(listToEditOriginal, listToEdit);
        }

        private void AdjustEnemyDataDroppedPins(EnemyDataList enemyData)
        {
            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.Duplicates)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<Badge.Label>(original.Drop));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.ForcedNormalDrops)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<Badge.Label>(original.Drop));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.NoDrops)
            {
                EnemyData original = enemyData.Items.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Items.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<Badge.Label>(original.Drop));
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

        private void RemovePinSpecificMissions()
        {
            var w1d2 = engine.Bundles.W1D2Scenario.GetScenarioFile(FileConstants.W1D2PinMissionAssetName);
            w1d2.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.Name = "OrMore";
            w1d2.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.SerializedValue = 5;

            var w2d5 = engine.Bundles.W2D5Scenario.GetScenarioFile(FileConstants.W2D5PinMissionAssetName);
            w2d5.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.Name = "OrMore";
            w2d5.Ready.List[0].ScenarioKindExtension.ScenarioBadgeList[0].CalcOperator.SerializedValue = 5;
        }
    }
}
