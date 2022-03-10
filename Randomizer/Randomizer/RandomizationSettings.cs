using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class RandomizationSettings
    {
        public NoiseDropType NoiseDropTypeChoice { get; set; }
        public bool NoiseIncludeLimitedPins { get; set; }
        public List<Difficulties> NoiseDropTypeDifficulties { get; set; }
        public NoiseDropRate NoiseDropRateChoice { get; set; }
        public decimal NoiseMinimumDropRate { get; set; }
        public decimal NoiseMaximumDropRate { get; set; }
        public List<Difficulties> NoiseDropRateDifficulties { get; set; }
        public List<uint> NoiseDropRateWeights { get; set; }

        public bool PinPower { get; set; }
        public bool PinPowerScaling { get; set; }
        public bool PinLimit { get; set; }
        public bool PinLimitScaling { get; set; }
        public bool PinReboot { get; set; }
        public bool PinRebootScaling { get; set; }
        public bool PinBoot { get; set; }
        public bool PinBootScaling { get; set; }
        public bool PinRecover { get; set; }
        public bool PinRecoverScaling { get; set; }
        public bool PinCharge { get; set; }
        public bool PinSell { get; set; }
        public bool PinSellScaling { get; set; }
        public bool PinAffinity { get; set; }
        public bool PinMaxLevel { get; set; }
        public PinBrand PinBrandChoice { get; set; }
        public bool PinUber { get; set; }
        public uint PinUberPercentage { get; set; }
        public PinAbility PinAbilityChoice { get; set; }
        public uint PinAbilityPercentage { get; set; }
        public PinGrowthRandomization PinGrowthChoice { get; set; }
        public PinGrowth PinGrowthSpecific { get; set; }
        public PinEvolution PinEvolutionChoice { get; set; }
        public bool PinEvoForceBrand { get; set; }
        public bool PinRemoveCharaEvos { get; set; }
        public uint PinEvoPercentage { get; set; }

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
            if (!Enum.IsDefined(typeof(NoiseDropType), NoiseDropTypeChoice)) NoiseDropTypeChoice = NoiseDropType.Unchanged;
            if (!Enum.IsDefined(typeof(NoiseDropRate), NoiseDropRateChoice)) NoiseDropRateChoice = NoiseDropRate.Unchanged;
            NoiseMinimumDropRate = Math.Max(Math.Min(NoiseMinimumDropRate, 100M), 0.01M);
            NoiseMaximumDropRate = Math.Max(Math.Min(NoiseMaximumDropRate, 100M), 0.01M);
            if (NoiseMinimumDropRate > NoiseMaximumDropRate) NoiseMaximumDropRate = NoiseMinimumDropRate;
            NoiseDropRateWeights = NoiseDropRateWeights.Select(weight => Math.Max(Math.Min(weight, 100), 1)).ToList();

            if (!Enum.IsDefined(typeof(PinBrand), PinBrandChoice)) PinBrandChoice = PinBrand.Unchanged;
            PinUberPercentage = Math.Max(Math.Min(PinUberPercentage, 100), 1);
            if (!Enum.IsDefined(typeof(PinAbility), PinAbilityChoice)) PinAbilityChoice = PinAbility.Unchanged;
            PinAbilityPercentage = Math.Max(Math.Min(PinAbilityPercentage, 100), 1);
            if (!Enum.IsDefined(typeof(PinGrowthRandomization), PinGrowthChoice)) PinGrowthChoice = PinGrowthRandomization.Unchanged;
            if (!Enum.IsDefined(typeof(PinGrowth), PinGrowthSpecific) || PinGrowthSpecific == PinGrowth.Other) PinGrowthSpecific = PinGrowth.Normal;
            PinEvoPercentage = Math.Max(Math.Min(PinEvoPercentage, 100), 1);
        }

        public RandomizationSettings(string settingsString)
        {
            InitializeDataStructures();

            if (Validator.ValidateSettingsString(settingsString) == Validator.SettingsStringValidationResult.Valid)
            {
                settingsString = settingsString.PadLeft(Validator.SettingsStringMinimumLength, '0');

                NoiseDropTypeChoice = (NoiseDropType) GetBitsFromSettingsString(settingsString, 4, 3);
                NoiseIncludeLimitedPins = GetBitsFromSettingsString(settingsString, 7, 1) == 1;

                if (GetBitsFromSettingsString(settingsString, 8, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Easy);
                if (GetBitsFromSettingsString(settingsString, 9, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Normal);
                if (GetBitsFromSettingsString(settingsString, 10, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Hard);
                if (GetBitsFromSettingsString(settingsString, 11, 1) == 1) NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

                NoiseDropRateChoice = (NoiseDropRate) GetBitsFromSettingsString(settingsString, 12, 2);
                uint minDropRate = GetBitsFromSettingsString(settingsString, 14, 14);
                NoiseMinimumDropRate = minDropRate / 100M;
                uint maxDropRate = GetBitsFromSettingsString(settingsString, 28, 14);
                NoiseMaximumDropRate = maxDropRate / 100M;

                if (GetBitsFromSettingsString(settingsString, 42, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Easy);
                if (GetBitsFromSettingsString(settingsString, 43, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Normal);
                if (GetBitsFromSettingsString(settingsString, 44, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Hard);
                if (GetBitsFromSettingsString(settingsString, 45, 1) == 1) NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

                NoiseDropRateWeights[0] = GetBitsFromSettingsString(settingsString, 46, 7);
                NoiseDropRateWeights[1] = GetBitsFromSettingsString(settingsString, 53, 7);
                NoiseDropRateWeights[2] = GetBitsFromSettingsString(settingsString, 60, 7);
                NoiseDropRateWeights[3] = GetBitsFromSettingsString(settingsString, 67, 7);

                PinPower = GetBitsFromSettingsString(settingsString, 74, 1) == 1;
                PinPowerScaling = GetBitsFromSettingsString(settingsString, 75, 1) == 1;
                PinLimit = GetBitsFromSettingsString(settingsString, 76, 1) == 1;
                PinLimitScaling = GetBitsFromSettingsString(settingsString, 77, 1) == 1;
                PinReboot = GetBitsFromSettingsString(settingsString, 78, 1) == 1;
                PinRebootScaling = GetBitsFromSettingsString(settingsString, 79, 1) == 1;
                PinBoot = GetBitsFromSettingsString(settingsString, 80, 1) == 1;
                PinBootScaling = GetBitsFromSettingsString(settingsString, 81, 1) == 1;
                PinRecover = GetBitsFromSettingsString(settingsString, 82, 1) == 1;
                PinRecoverScaling = GetBitsFromSettingsString(settingsString, 83, 1) == 1;
                PinCharge = GetBitsFromSettingsString(settingsString, 84, 1) == 1;
                PinSell = GetBitsFromSettingsString(settingsString, 85, 1) == 1;
                PinSellScaling = GetBitsFromSettingsString(settingsString, 86, 1) == 1;
                PinAffinity = GetBitsFromSettingsString(settingsString, 87, 1) == 1;
                PinMaxLevel = GetBitsFromSettingsString(settingsString, 88, 1) == 1;

                PinBrandChoice = (PinBrand) GetBitsFromSettingsString(settingsString, 89, 2);

                PinUber = GetBitsFromSettingsString(settingsString, 91, 1) == 1;
                PinUberPercentage = GetBitsFromSettingsString(settingsString, 92, 7);

                PinAbilityChoice = (PinAbility) GetBitsFromSettingsString(settingsString, 99, 2);
                PinAbilityPercentage = GetBitsFromSettingsString(settingsString, 101, 7);

                PinGrowthChoice = (PinGrowthRandomization) GetBitsFromSettingsString(settingsString, 108, 2);
                PinGrowthSpecific = (PinGrowth) GetBitsFromSettingsString(settingsString, 110, 3);

                PinEvolutionChoice = (PinEvolution) GetBitsFromSettingsString(settingsString, 113, 2);
                PinEvoForceBrand = GetBitsFromSettingsString(settingsString, 115, 1) == 1;
                PinRemoveCharaEvos = GetBitsFromSettingsString(settingsString, 116, 1) == 1;
                PinEvoPercentage = GetBitsFromSettingsString(settingsString, 117, 7);

                CorrectSettingValues();
            }
        }

        public string GenerateSettingsString()
        {
            string settingsString = "";

            settingsString = AppendToSettingsString(settingsString, (uint)Validator.SettingsStringVersion, 4, 0);

            settingsString = AppendToSettingsString(settingsString, (uint)NoiseDropTypeChoice, 3, 4);
            settingsString = AppendToSettingsString(settingsString, NoiseIncludeLimitedPins ? 1u : 0u, 1, 7);

            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Easy) ? 1u : 0u, 1, 8);
            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Normal) ? 1u : 0u, 1, 9);
            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Hard) ? 1u : 0u, 1, 10);
            settingsString = AppendToSettingsString(settingsString, NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u, 1, 11);

            settingsString = AppendToSettingsString(settingsString, (uint)NoiseDropRateChoice, 2, 12);
            settingsString = AppendToSettingsString(settingsString, (uint)(NoiseMinimumDropRate * 100), 14, 14);
            settingsString = AppendToSettingsString(settingsString, (uint)(NoiseMaximumDropRate * 100), 14, 28);

            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Easy) ? 1u : 0u, 1, 42);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Normal) ? 1u : 0u, 1, 43);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Hard) ? 1u : 0u, 1, 44);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u, 1, 45);

            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[0], 7, 46);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[1], 7, 53);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[2], 7, 60);
            settingsString = AppendToSettingsString(settingsString, NoiseDropRateWeights[3], 7, 67);

            settingsString = AppendToSettingsString(settingsString, PinPower ? 1u : 0u, 1, 74);
            settingsString = AppendToSettingsString(settingsString, PinPowerScaling ? 1u : 0u, 1, 75);
            settingsString = AppendToSettingsString(settingsString, PinLimit ? 1u : 0u, 1, 76);
            settingsString = AppendToSettingsString(settingsString, PinLimitScaling ? 1u : 0u, 1, 77);
            settingsString = AppendToSettingsString(settingsString, PinReboot ? 1u : 0u, 1, 78);
            settingsString = AppendToSettingsString(settingsString, PinRebootScaling ? 1u : 0u, 1, 79);
            settingsString = AppendToSettingsString(settingsString, PinBoot ? 1u : 0u, 1, 80);
            settingsString = AppendToSettingsString(settingsString, PinBootScaling ? 1u : 0u, 1, 81);
            settingsString = AppendToSettingsString(settingsString, PinRecover ? 1u : 0u, 1, 82);
            settingsString = AppendToSettingsString(settingsString, PinRecoverScaling ? 1u : 0u, 1, 83);
            settingsString = AppendToSettingsString(settingsString, PinCharge ? 1u : 0u, 1, 84);
            settingsString = AppendToSettingsString(settingsString, PinSell ? 1u : 0u, 1, 85);
            settingsString = AppendToSettingsString(settingsString, PinSellScaling ? 1u : 0u, 1, 86);
            settingsString = AppendToSettingsString(settingsString, PinAffinity ? 1u : 0u, 1, 87);
            settingsString = AppendToSettingsString(settingsString, PinMaxLevel ? 1u : 0u, 1, 88);

            settingsString = AppendToSettingsString(settingsString, (uint)PinBrandChoice, 2, 89);

            settingsString = AppendToSettingsString(settingsString, PinUber ? 1u : 0u, 1, 91);
            settingsString = AppendToSettingsString(settingsString, PinUberPercentage, 7, 92);

            settingsString = AppendToSettingsString(settingsString, (uint)PinAbilityChoice, 2, 99);
            settingsString = AppendToSettingsString(settingsString, PinAbilityPercentage, 7, 101);

            settingsString = AppendToSettingsString(settingsString, (uint)PinGrowthChoice, 2, 108);
            settingsString = AppendToSettingsString(settingsString, (uint)PinGrowthSpecific, 3, 110);

            settingsString = AppendToSettingsString(settingsString, (uint)PinEvolutionChoice, 2, 113);
            settingsString = AppendToSettingsString(settingsString, PinEvoForceBrand ? 1u : 0u, 1, 115);
            settingsString = AppendToSettingsString(settingsString, PinRemoveCharaEvos ? 1u : 0u, 1, 116);
            settingsString = AppendToSettingsString(settingsString, PinEvoPercentage, 7, 117);

            return settingsString;
        }
    }
}
