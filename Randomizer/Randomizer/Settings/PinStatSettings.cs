using System;

namespace NEO_TWEWY_Randomizer
{
    public class PinStatSettings
    {
        public bool Power { get; set; }
        public bool PowerScaling { get; set; }
        public bool Limit { get; set; }
        public bool LimitScaling { get; set; }
        public bool Reboot { get; set; }
        public bool RebootScaling { get; set; }
        public bool Boot { get; set; }
        public bool BootScaling { get; set; }
        public bool Recover { get; set; }
        public bool RecoverScaling { get; set; }
        public bool Charge { get; set; }
        public bool Sell { get; set; }
        public bool SellScaling { get; set; }
        public bool Affinity { get; set; }
        public bool MaxLevel { get; set; }
        public PinBrand BrandChoice { get; set; }
        public bool Uber { get; set; }
        public uint UberPercentage { get; set; }
        public PinAbility AbilityChoice { get; set; }
        public uint AbilityPercentage { get; set; }
        public PinGrowthRandomization GrowthChoice { get; set; }
        public PinGrowth GrowthSpecific { get; set; }
        public PinEvolution EvolutionChoice { get; set; }
        public bool EvoForceBrand { get; set; }
        public bool RemoveCharaEvos { get; set; }
        public uint EvoPercentage { get; set; }

        public PinStatSettings()
        {
            CorrectSettingValues();
        }

        public void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(PinBrand), BrandChoice)) BrandChoice = PinBrand.Unchanged;
            UberPercentage = Math.Max(Math.Min(UberPercentage, 100), 1);
            if (!Enum.IsDefined(typeof(PinAbility), AbilityChoice)) AbilityChoice = PinAbility.Unchanged;
            AbilityPercentage = Math.Max(Math.Min(AbilityPercentage, 100), 1);
            if (!Enum.IsDefined(typeof(PinGrowthRandomization), GrowthChoice)) GrowthChoice = PinGrowthRandomization.Unchanged;
            if (!Enum.IsDefined(typeof(PinGrowth), GrowthSpecific) || GrowthSpecific == PinGrowth.Other) GrowthSpecific = PinGrowth.Normal;
            EvoPercentage = Math.Max(Math.Min(EvoPercentage, 100), 1);
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            Power = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_power") == 1;
            PowerScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_power_scaling") == 1;
            Limit = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_limit") == 1;
            LimitScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_limit_scaling") == 1;
            Reboot = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_reboot") == 1;
            RebootScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_reboot_scaling") == 1;
            Boot = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_boot") == 1;
            BootScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_boot_scaling") == 1;
            Recover = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_recover") == 1;
            RecoverScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_recover_scaling") == 1;
            Charge = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_charge") == 1;
            Sell = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_sell") == 1;
            SellScaling = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_sell_scaling") == 1;
            Affinity = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_affinity") == 1;
            MaxLevel = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_level") == 1;

            BrandChoice = (PinBrand)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_brand_category");

            Uber = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_uber") == 1;
            UberPercentage = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_uber_percent");

            AbilityChoice = (PinAbility)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_ability_category");
            AbilityPercentage = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_ability_percent");

            GrowthChoice = (PinGrowthRandomization)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_growth_category");
            GrowthSpecific = (PinGrowth)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_growth_specific");

            EvolutionChoice = (PinEvolution)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_category");
            EvoForceBrand = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_force") == 1;
            RemoveCharaEvos = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_chara") == 1;
            EvoPercentage = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "pin_evo_percent");
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_power", Power ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_power_scaling", PowerScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_limit", Limit ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_limit_scaling", LimitScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_reboot", Reboot ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_reboot_scaling", RebootScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_boot", Boot ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_boot_scaling", BootScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_recover", Recover ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_recover_scaling", RecoverScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_charge", Charge ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_sell", Sell ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_sell_scaling", SellScaling ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_affinity", Affinity ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_level", MaxLevel ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_brand_category", (uint)BrandChoice);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_uber", Uber ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_uber_percent", UberPercentage);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_ability_category", (uint)AbilityChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_ability_percent", AbilityPercentage);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_growth_category", (uint)GrowthChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_growth_specific", (uint)GrowthSpecific);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_category", (uint)EvolutionChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_force", EvoForceBrand ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_chara", RemoveCharaEvos ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "pin_evo_percent", EvoPercentage);

            return currentString;
        }
    }
}
