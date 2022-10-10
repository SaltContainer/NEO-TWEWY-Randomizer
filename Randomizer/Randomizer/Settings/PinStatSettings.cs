using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer.Randomizer.Settings
{
    class PinStatSettings
    {
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

        public PinStatSettings()
        {
            CorrectSettingValues();
        }

        public void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(PinBrand), PinBrandChoice)) PinBrandChoice = PinBrand.Unchanged;
            PinUberPercentage = Math.Max(Math.Min(PinUberPercentage, 100), 1);
            if (!Enum.IsDefined(typeof(PinAbility), PinAbilityChoice)) PinAbilityChoice = PinAbility.Unchanged;
            PinAbilityPercentage = Math.Max(Math.Min(PinAbilityPercentage, 100), 1);
            if (!Enum.IsDefined(typeof(PinGrowthRandomization), PinGrowthChoice)) PinGrowthChoice = PinGrowthRandomization.Unchanged;
            if (!Enum.IsDefined(typeof(PinGrowth), PinGrowthSpecific) || PinGrowthSpecific == PinGrowth.Other) PinGrowthSpecific = PinGrowth.Normal;
            PinEvoPercentage = Math.Max(Math.Min(PinEvoPercentage, 100), 1);
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            PinPower = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_power") == 1;
            PinPowerScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_power_scaling") == 1;
            PinLimit = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_limit") == 1;
            PinLimitScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_limit_scaling") == 1;
            PinReboot = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_reboot") == 1;
            PinRebootScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_reboot_scaling") == 1;
            PinBoot = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_boot") == 1;
            PinBootScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_boot_scaling") == 1;
            PinRecover = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_recover") == 1;
            PinRecoverScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_recover_scaling") == 1;
            PinCharge = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_charge") == 1;
            PinSell = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_sell") == 1;
            PinSellScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_sell_scaling") == 1;
            PinAffinity = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_affinity") == 1;
            PinMaxLevel = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_level") == 1;

            PinBrandChoice = (PinBrand)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_brand_category");

            PinUber = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_uber") == 1;
            PinUberPercentage = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_uber_percent");

            PinAbilityChoice = (PinAbility)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_ability_category");
            PinAbilityPercentage = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_ability_percent");

            PinGrowthChoice = (PinGrowthRandomization)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_growth_category");
            PinGrowthSpecific = (PinGrowth)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_growth_specific");

            PinEvolutionChoice = (PinEvolution)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_category");
            PinEvoForceBrand = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_force") == 1;
            PinRemoveCharaEvos = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_chara") == 1;
            PinEvoPercentage = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_percent");
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_power", PinPower ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_power_scaling", PinPowerScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_limit", PinLimit ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_limit_scaling", PinLimitScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_reboot", PinReboot ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_reboot_scaling", PinRebootScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_boot", PinBoot ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_boot_scaling", PinBootScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_recover", PinRecover ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_recover_scaling", PinRecoverScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_charge", PinCharge ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_sell", PinSell ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_sell_scaling", PinSellScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_affinity", PinAffinity ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_level", PinMaxLevel ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_brand_category", (uint)PinBrandChoice);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_uber", PinUber ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_uber_percent", PinUberPercentage);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_ability_category", (uint)PinAbilityChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_ability_percent", PinAbilityPercentage);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_growth_category", (uint)PinGrowthChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_growth_specific", (uint)PinGrowthSpecific);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_category", (uint)PinEvolutionChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_force", PinEvoForceBrand ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_chara", PinRemoveCharaEvos ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_percent", PinEvoPercentage);

            return currentString;
        }
    }
}
