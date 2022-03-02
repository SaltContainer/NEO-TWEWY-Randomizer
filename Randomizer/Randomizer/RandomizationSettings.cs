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

        private void InitializeDataStructures()
        {
            NoiseDropTypeDifficulties = new List<Difficulties>();
            NoiseDropRateDifficulties = new List<Difficulties>();
            NoiseDropRateWeights = new List<uint> { 0,0,0,0 };
        }

        private uint MakeBitMask(int left, int right)
        {
            return (uint)((1 << left) - 1 - ((1 << right) - 1));
        }

        private string AppendToSettingsString(string hexString, uint bitsToAppend, int amountOfBits, int position)
        {
            int stringPos = position / 4;
            int bitOfPos = position % 4;
            int actualPos = hexString.Length - 1 - stringPos;

            uint bitsLeft = bitsToAppend;

            string editedString = hexString;

            int lastNum = 0;
            if (actualPos > -1)
            {
                lastNum = int.Parse(hexString.Substring(actualPos, 1), System.Globalization.NumberStyles.HexNumber);
                editedString = hexString.Substring(actualPos + 1);
            }
            lastNum &= (int)MakeBitMask(bitOfPos, 0);
            lastNum += (int)(MakeBitMask(4, bitOfPos) & (bitsToAppend << bitOfPos));

            editedString = lastNum.ToString("X") + editedString;

            int amountLeft = amountOfBits - (4 - bitOfPos);
            if (amountLeft > 0) bitsLeft = bitsToAppend >> (4 - bitOfPos);

            for (int i = amountLeft; i > 0; i -= 4)
            {
                uint newNum = 0b1111 & bitsLeft;
                bitsLeft >>= 4;
                editedString = newNum.ToString("X") + editedString;
            }

            return editedString;
        }

        private uint GetBitsFromSettingsString(string hexString, int position, int amount)
        {
            int leftPos = (position + amount) / 4;
            int bitOfLeftPos = (position + amount) % 4;
            int rightPos = position / 4;
            int bitOfRightPos = position % 4;

            int actualLeftPos = hexString.Length - 1 - leftPos;
            int actualRightPos = hexString.Length - 1 - rightPos;
            int lengthNeeded = actualRightPos - actualLeftPos + 1;

            uint baseNumber = uint.Parse(hexString.Substring(actualLeftPos, lengthNeeded), System.Globalization.NumberStyles.HexNumber);

            uint mask = MakeBitMask((lengthNeeded-1)*4 + bitOfLeftPos, bitOfRightPos);

            return (baseNumber & mask) >> bitOfRightPos;
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

                DropType = (NoiseDropType) GetBitsFromSettingsString(settingsString, 4, 3);
                IncludeLimitedPins = GetBitsFromSettingsString(settingsString, 7, 1) == 1;

                if (GetBitsFromSettingsString(settingsString, 8, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Easy);
                if (GetBitsFromSettingsString(settingsString, 9, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Normal);
                if (GetBitsFromSettingsString(settingsString, 10, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Hard);
                if (GetBitsFromSettingsString(settingsString, 11, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

                DropRate = (NoiseDropRate) GetBitsFromSettingsString(settingsString, 12, 2);

                uint minDropRate = GetBitsFromSettingsString(settingsString, 14, 14);
                MinimumDropRate = minDropRate / 100M;

                uint maxDropRate = GetBitsFromSettingsString(settingsString, 28, 14);
                MaximumDropRate = maxDropRate / 100M;

                if (GetBitsFromSettingsString(settingsString, 42, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Easy);
                if (GetBitsFromSettingsString(settingsString, 43, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Normal);
                if (GetBitsFromSettingsString(settingsString, 44, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Hard);
                if (GetBitsFromSettingsString(settingsString, 45, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

                NoiseDropRateWeights[0] = GetBitsFromSettingsString(settingsString, 46, 7);
                NoiseDropRateWeights[1] = GetBitsFromSettingsString(settingsString, 53, 7);
                NoiseDropRateWeights[2] = GetBitsFromSettingsString(settingsString, 60, 7);
                NoiseDropRateWeights[3] = GetBitsFromSettingsString(settingsString, 67, 7);

                CorrectSettingValues();
            }
        }

        public string GenerateSettingsString()
        {
            string settingsString = "";

            settingsString = AppendToSettingsString(settingsString, (uint)Validator.SettingsStringVersion, 4, 0);

            settingsString = AppendToSettingsString(settingsString, (uint)DropType, 3, 4);
            settingsString = AppendToSettingsString(settingsString, IncludeLimitedPins ? 1u : 0u, 1, 7);

            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Easy) ? 1u : 0u, 1, 8);
            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Normal) ? 1u : 0u, 1, 9);
            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Hard) ? 1u : 0u, 1, 10);
            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u, 1, 11);

            settingsString = AppendToSettingsString(settingsString, (uint)DropRate, 2, 12);
            settingsString = AppendToSettingsString(settingsString, (uint)(MinimumDropRate * 100), 14, 14);
            settingsString = AppendToSettingsString(settingsString, (uint)(MaximumDropRate * 100), 14, 28);

            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Easy) ? 1u : 0u, 1, 42);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Normal) ? 1u : 0u, 1, 43);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Hard) ? 1u : 0u, 1, 44);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u, 1, 45);

            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[0], 7, 46);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[1], 7, 53);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[2], 7, 60);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[3], 7, 67);

            return settingsString;
        }
    }
}
