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
            CorrectSettingValues();
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

        private string AppendToSettingsString(string hexString, uint bitsToAppend, int position, int amountOfBits)
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

        private string AppendToSettingsString(string hexString, SettingsStringVersion versionInfo, string setting, uint value)
        {
            int position = versionInfo.Values[setting].Offset;
            int amount = versionInfo.Values[setting].Size;

            return AppendToSettingsString(hexString, value, position, amount);
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

            uint mask = MakeBitMask((lengthNeeded - 1) * 4 + bitOfLeftPos, bitOfRightPos);

            return (baseNumber & mask) >> bitOfRightPos;
        }

        private uint GetBitsFromSettingsString(string hexString, SettingsStringVersion versionInfo, string setting)
        {
            int position = versionInfo.Values[setting].Offset;
            int amount = versionInfo.Values[setting].Size;

            return GetBitsFromSettingsString(hexString, position, amount);
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

            Validator.SettingsStringValidationResult validationResult = Validator.ValidateSettingsString(settingsString);

            if (validationResult == Validator.SettingsStringValidationResult.Valid || validationResult == Validator.SettingsStringValidationResult.WrongVersion)
            {
                settingsString = settingsString.PadLeft(Validator.SettingsStringMinimumLength, '0');

                uint version = GetBitsFromSettingsString(settingsString, 0, 4);
                SettingsStringVersion versionInfo = FileConstants.SettingsStringVersions.Items[(int)version];

                NoiseDropTypeChoice = (NoiseDropType) GetBitsFromSettingsString(settingsString, versionInfo, "dropped_pin_category");
                NoiseIncludeLimitedPins = GetBitsFromSettingsString(settingsString, versionInfo, "dropped_pin_limited") == 1;

                if (GetBitsFromSettingsString(settingsString, versionInfo, "dropped_pin_easy") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Easy);
                if (GetBitsFromSettingsString(settingsString, versionInfo, "dropped_pin_normal") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Normal);
                if (GetBitsFromSettingsString(settingsString, versionInfo, "dropped_pin_hard") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Hard);
                if (GetBitsFromSettingsString(settingsString, versionInfo, "dropped_pin_ultimate") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

                NoiseDropRateChoice = (NoiseDropRate)GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_category");
                uint minDropRate = GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_minimum");
                NoiseMinimumDropRate = minDropRate / 100M;
                uint maxDropRate = GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_maximum");
                NoiseMaximumDropRate = maxDropRate / 100M;

                if (GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_easy") == 1) NoiseDropRateDifficulties.Add(Difficulties.Easy);
                if (GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_normal") == 1) NoiseDropRateDifficulties.Add(Difficulties.Normal);
                if (GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_hard") == 1) NoiseDropRateDifficulties.Add(Difficulties.Hard);
                if (GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_ultimate") == 1) NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

                NoiseDropRateWeights[0] = GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_easy_weight");
                NoiseDropRateWeights[1] = GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_normal_weight");
                NoiseDropRateWeights[2] = GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_hard_weight");
                NoiseDropRateWeights[3] = GetBitsFromSettingsString(settingsString, versionInfo, "drop_rate_ultimate_weight");

                PinPower = GetBitsFromSettingsString(settingsString, versionInfo, "pin_power") == 1;
                PinPowerScaling = GetBitsFromSettingsString(settingsString, versionInfo, "pin_power_scaling") == 1;
                PinLimit = GetBitsFromSettingsString(settingsString, versionInfo, "pin_limit") == 1;
                PinLimitScaling = GetBitsFromSettingsString(settingsString, versionInfo, "pin_limit_scaling") == 1;
                PinReboot = GetBitsFromSettingsString(settingsString, versionInfo, "pin_reboot") == 1;
                PinRebootScaling = GetBitsFromSettingsString(settingsString, versionInfo, "pin_reboot_scaling") == 1;
                PinBoot = GetBitsFromSettingsString(settingsString, versionInfo, "pin_boot") == 1;
                PinBootScaling = GetBitsFromSettingsString(settingsString, versionInfo, "pin_boot_scaling") == 1;
                PinRecover = GetBitsFromSettingsString(settingsString, versionInfo, "pin_recover") == 1;
                PinRecoverScaling = GetBitsFromSettingsString(settingsString, versionInfo, "pin_recover_scaling") == 1;
                PinCharge = GetBitsFromSettingsString(settingsString, versionInfo, "pin_charge") == 1;
                PinSell = GetBitsFromSettingsString(settingsString, versionInfo, "pin_sell") == 1;
                PinSellScaling = GetBitsFromSettingsString(settingsString, versionInfo, "pin_sell_scaling") == 1;
                PinAffinity = GetBitsFromSettingsString(settingsString, versionInfo, "pin_affinity") == 1;
                PinMaxLevel = GetBitsFromSettingsString(settingsString, versionInfo, "pin_level") == 1;

                PinBrandChoice = (PinBrand)GetBitsFromSettingsString(settingsString, versionInfo, "pin_brand_category");

                PinUber = GetBitsFromSettingsString(settingsString, versionInfo, "pin_uber") == 1;
                PinUberPercentage = GetBitsFromSettingsString(settingsString, versionInfo, "pin_uber_percent");

                PinAbilityChoice = (PinAbility)GetBitsFromSettingsString(settingsString, versionInfo, "pin_ability_category");
                PinAbilityPercentage = GetBitsFromSettingsString(settingsString, versionInfo, "pin_ability_percent");

                PinGrowthChoice = (PinGrowthRandomization)GetBitsFromSettingsString(settingsString, versionInfo, "pin_growth_category");
                PinGrowthSpecific = (PinGrowth)GetBitsFromSettingsString(settingsString, versionInfo, "pin_growth_specific");

                PinEvolutionChoice = (PinEvolution)GetBitsFromSettingsString(settingsString, versionInfo, "pin_evo_category");
                PinEvoForceBrand = GetBitsFromSettingsString(settingsString, versionInfo, "pin_evo_force") == 1;
                PinRemoveCharaEvos = GetBitsFromSettingsString(settingsString, versionInfo, "pin_evo_chara") == 1;
                PinEvoPercentage = GetBitsFromSettingsString(settingsString, versionInfo, "pin_evo_percent");
            }

            CorrectSettingValues();
        }

        public string GenerateSettingsString()
        {
            string settingsString = "";

            settingsString = AppendToSettingsString(settingsString, (uint)Validator.SettingsStringVersion, 0, 4);
            SettingsStringVersion versionInfo = FileConstants.SettingsStringVersions.Items[Validator.SettingsStringVersion];

            settingsString = AppendToSettingsString(settingsString, versionInfo, "dropped_pin_category", (uint)NoiseDropTypeChoice);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "dropped_pin_limited", NoiseIncludeLimitedPins ? 1u : 0u);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "dropped_pin_easy", NoiseDropTypeDifficulties.Contains(Difficulties.Easy) ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "dropped_pin_normal", NoiseDropTypeDifficulties.Contains(Difficulties.Normal) ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "dropped_pin_hard", NoiseDropTypeDifficulties.Contains(Difficulties.Hard) ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "dropped_pin_ultimate", NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_category", (uint)NoiseDropRateChoice);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_minimum", (uint)(NoiseMinimumDropRate * 100));
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_maximum", (uint)(NoiseMaximumDropRate * 100));

            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_easy", NoiseDropRateDifficulties.Contains(Difficulties.Easy) ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_normal", NoiseDropRateDifficulties.Contains(Difficulties.Normal) ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_hard", NoiseDropRateDifficulties.Contains(Difficulties.Hard) ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_ultimate", NoiseDropRateDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_easy_weight", NoiseDropRateWeights[0]);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_normal_weight", NoiseDropRateWeights[1]);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_hard_weight", NoiseDropRateWeights[2]);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "drop_rate_ultimate_weight", NoiseDropRateWeights[3]);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_power", PinPower ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_power_scaling", PinPowerScaling ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_limit", PinLimit ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_limit_scaling", PinLimitScaling ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_reboot", PinReboot ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_reboot_scaling", PinRebootScaling ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_boot", PinBoot ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_boot_scaling", PinBootScaling ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_recover", PinRecover ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_recover_scaling", PinRecoverScaling ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_charge", PinCharge ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_sell", PinSell ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_sell_scaling", PinSellScaling ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_affinity", PinAffinity ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_level", PinMaxLevel ? 1u : 0u);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_brand_category", (uint)PinBrandChoice);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_uber", PinUber ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_uber_percent", PinUberPercentage);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_ability_category", (uint)PinAbilityChoice);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_ability_percent", PinAbilityPercentage);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_growth_category", (uint)PinGrowthChoice);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_growth_specific", (uint)PinGrowthSpecific);

            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_evo_category", (uint)PinEvolutionChoice);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_evo_force", PinEvoForceBrand ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_evo_chara", PinRemoveCharaEvos ? 1u : 0u);
            settingsString = AppendToSettingsString(settingsString, versionInfo, "pin_evo_percent", PinEvoPercentage);

            return settingsString;
        }
    }
}
