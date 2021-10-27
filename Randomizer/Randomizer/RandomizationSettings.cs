using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class RandomizationSettings
    {
        public NoiseDropType DropType { get; set; }
        public bool IncludeLimitedPins { get; set; }
        public List<Difficulties> NoiseDropTypeDifficulties { get; set; }
        public NoiseDropRate DropRate { get; set; }
        public decimal MinimumDropRate { get; set; }
        public decimal MaximumDropRate { get; set; }
        public List<Difficulties> NoiseDropRateDifficulties { get; set; }
        public List<uint> NoiseDropRateWeights { get; set; }

        public RandomizationSettings()
        {
            InitializeDataStructures();
        }

        private bool IsBitSet(int num, int pos)
        {
            return (num & (1 << pos)) != 0;
        }

        private void InitializeDataStructures()
        {
            NoiseDropTypeDifficulties = new List<Difficulties>();
            NoiseDropRateDifficulties = new List<Difficulties>();
            NoiseDropRateWeights = new List<uint> { 0,0,0,0 };
        }

        private void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(NoiseDropType), DropType)) DropType = NoiseDropType.Unchanged;
            if (!Enum.IsDefined(typeof(NoiseDropRate), DropRate)) DropRate = NoiseDropRate.Unchanged;
            MinimumDropRate = Math.Max(Math.Min(MinimumDropRate, 100M), 0.01M);
            MaximumDropRate = Math.Max(Math.Min(MaximumDropRate, 100M), 0.01M);
            if (MinimumDropRate > MaximumDropRate) MaximumDropRate = MinimumDropRate;
            NoiseDropRateWeights.Select(weight => Math.Max(Math.Min(weight, 100), 1));
        }

        public RandomizationSettings(string settingsString)
        {
            InitializeDataStructures();

            if (Validator.ValidateSettingsString(settingsString) == Validator.SettingsStringValidationResult.Valid)
            {
                settingsString = settingsString.PadLeft(Validator.SettingsStringMinimumLength, '0');
                int l = settingsString.Length;

                int droppedPins = int.Parse(settingsString.Substring(l - 2, 1), System.Globalization.NumberStyles.HexNumber);
                DropType = (NoiseDropType)(droppedPins & 0b0111);

                IncludeLimitedPins = IsBitSet(droppedPins, 3);

                int droppedPinsDifficulties = int.Parse(settingsString.Substring(l - 3, 1), System.Globalization.NumberStyles.HexNumber);
                if (IsBitSet(droppedPinsDifficulties, 0)) NoiseDropTypeDifficulties.Add(Difficulties.Easy);
                if (IsBitSet(droppedPinsDifficulties, 1)) NoiseDropTypeDifficulties.Add(Difficulties.Normal);
                if (IsBitSet(droppedPinsDifficulties, 2)) NoiseDropTypeDifficulties.Add(Difficulties.Hard);
                if (IsBitSet(droppedPinsDifficulties, 3)) NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

                int dropRateCategory = int.Parse(settingsString.Substring(l - 4, 1), System.Globalization.NumberStyles.HexNumber);
                DropRate = (NoiseDropRate)(dropRateCategory & 0b0011);

                int minDropRatePartial = int.Parse(settingsString.Substring(l - 7, 3), System.Globalization.NumberStyles.HexNumber);
                int minDropRate = (minDropRatePartial << 2) + (dropRateCategory >> 2);
                MinimumDropRate = minDropRate / 100M;

                int maxDropRate = int.Parse(settingsString.Substring(l - 11, 4), System.Globalization.NumberStyles.HexNumber);
                MaximumDropRate = (maxDropRate & 0b0011_1111_1111_1111) / 100M;

                int dropRateDifficultiesPartial = int.Parse(settingsString.Substring(l - 12, 1), System.Globalization.NumberStyles.HexNumber);
                if (IsBitSet(maxDropRate, 14)) NoiseDropRateDifficulties.Add(Difficulties.Easy);
                if (IsBitSet(maxDropRate, 15)) NoiseDropRateDifficulties.Add(Difficulties.Normal);
                if (IsBitSet(dropRateDifficultiesPartial, 0)) NoiseDropRateDifficulties.Add(Difficulties.Hard);
                if (IsBitSet(dropRateDifficultiesPartial, 1)) NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

                uint dropRateWeights = uint.Parse(settingsString.Substring(l - 19, 7), System.Globalization.NumberStyles.HexNumber);
                NoiseDropRateWeights[0] = ((dropRateWeights & 0b0000_0000_0000_0000_0000_0001_1111) << 2) + ((((uint) dropRateDifficultiesPartial) & 0b1100) >> 2);
                NoiseDropRateWeights[1] = (dropRateWeights & 0b0000_0000_0000_0000_1111_1110_0000) >> 5;
                NoiseDropRateWeights[2] = (dropRateWeights & 0b0000_0000_0111_1111_0000_0000_0000) >> 12;
                NoiseDropRateWeights[3] = (dropRateWeights & 0b0011_1111_1000_0000_0000_0000_0000) >> 19;

                CorrectSettingValues();
            }
        }

        public string GenerateSettingsString()
        {
            string settingsString = "";

            settingsString = Validator.SettingsStringVersion.ToString("X") + settingsString;

            int droppedPins = (int) DropType;
            if (IncludeLimitedPins) droppedPins += 0b1000;
            settingsString = droppedPins.ToString("X") + settingsString;

            int droppedPinsDifficulties = 0;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Easy)) droppedPinsDifficulties += 0b0001;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Normal)) droppedPinsDifficulties += 0b0010;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Hard)) droppedPinsDifficulties += 0b0100;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate)) droppedPinsDifficulties += 0b1000;
            settingsString = droppedPinsDifficulties.ToString("X") + settingsString;

            uint dropRatePartialBytes = 0;
            uint dropRateType = (uint) DropRate;
            uint minimumDropRate = (uint) (MinimumDropRate * 100);
            uint maximumDropRate = (uint) (MaximumDropRate * 100);
            dropRatePartialBytes += dropRateType & 0b0000_0000_0000_0000_0000_0000_0000_0011;
            dropRatePartialBytes += (minimumDropRate << 2) & 0b0000_0000_0000_0000_1111_1111_1111_1100;
            dropRatePartialBytes += (maximumDropRate << 16) & 0b0011_1111_1111_1111_0000_0000_0000_0000;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Easy)) dropRatePartialBytes += 0b0100_0000_0000_0000_0000_0000_0000_0000;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Normal)) dropRatePartialBytes += 0b1000_0000_0000_0000_0000_0000_0000_0000;
            settingsString = dropRatePartialBytes.ToString("X") + settingsString;

            uint dropRatePartialBytes2 = 0;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Hard)) dropRatePartialBytes2 += 0b0000_0000_0000_0000_0000_0000_0000_0001;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate)) dropRatePartialBytes2 += 0b0000_0000_0000_0000_0000_0000_0000_0010;
            dropRatePartialBytes2 += (NoiseDropRateWeights[0] << 2) & 0b0000_0000_0000_0000_0000_0001_1111_1100;
            dropRatePartialBytes2 += (NoiseDropRateWeights[1] << 9) & 0b0000_0000_0000_0000_1111_1110_0000_0000;
            dropRatePartialBytes2 += (NoiseDropRateWeights[2] << 16) & 0b0000_0000_0111_1111_0000_0000_0000_0000;
            dropRatePartialBytes2 += (NoiseDropRateWeights[3] << 23) & 0b0011_1111_1000_0000_0000_0000_0000_0000;

            settingsString = dropRatePartialBytes2.ToString("X") + settingsString;

            return settingsString;
        }
    }
}
