using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class NoiseDropSettings
    {
        public NoiseDropType DropTypeChoice { get; set; }
        public bool IncludeLimitedPins { get; set; }
        public List<Difficulties> DropTypeDifficulties { get; set; }
        public NoiseDropRate DropRateChoice { get; set; }
        public decimal MinimumDropRate { get; set; }
        public decimal MaximumDropRate { get; set; }
        public List<Difficulties> DropRateDifficulties { get; set; }
        public List<uint> DropRateWeights { get; set; }

        public NoiseDropSettings()
        {
            InitializeDataStructures();
            CorrectSettingValues();
        }

        private void InitializeDataStructures()
        {
            DropTypeDifficulties = new List<Difficulties>();
            DropRateDifficulties = new List<Difficulties>();
            DropRateWeights = new List<uint> { 0, 0, 0, 0 };
        }

        public void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(NoiseDropType), DropTypeChoice)) DropTypeChoice = NoiseDropType.Unchanged;
            if (!Enum.IsDefined(typeof(NoiseDropRate), DropRateChoice)) DropRateChoice = NoiseDropRate.Unchanged;
            MinimumDropRate = Math.Max(Math.Min(MinimumDropRate, 100M), 0.01M);
            MaximumDropRate = Math.Max(Math.Min(MaximumDropRate, 100M), 0.01M);
            if (MinimumDropRate > MaximumDropRate) MaximumDropRate = MinimumDropRate;
            DropRateWeights = DropRateWeights.Select(weight => Math.Max(Math.Min(weight, 100), 1)).ToList();
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            DropTypeChoice = (NoiseDropType)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_category");
            IncludeLimitedPins = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_limited") == 1;

            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_easy") == 1) DropTypeDifficulties.Add(Difficulties.Easy);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_normal") == 1) DropTypeDifficulties.Add(Difficulties.Normal);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_hard") == 1) DropTypeDifficulties.Add(Difficulties.Hard);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_ultimate") == 1) DropTypeDifficulties.Add(Difficulties.Ultimate);

            DropRateChoice = (NoiseDropRate)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_category");
            uint minDropRate = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_minimum");
            MinimumDropRate = minDropRate / 100M;
            uint maxDropRate = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_maximum");
            MaximumDropRate = maxDropRate / 100M;

            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_easy") == 1) DropRateDifficulties.Add(Difficulties.Easy);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_normal") == 1) DropRateDifficulties.Add(Difficulties.Normal);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_hard") == 1) DropRateDifficulties.Add(Difficulties.Hard);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_ultimate") == 1) DropRateDifficulties.Add(Difficulties.Ultimate);

            DropRateWeights[0] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_easy_weight");
            DropRateWeights[1] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_normal_weight");
            DropRateWeights[2] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_hard_weight");
            DropRateWeights[3] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_ultimate_weight");
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_category", (uint)DropTypeChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_limited", IncludeLimitedPins ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_easy", DropTypeDifficulties.Contains(Difficulties.Easy) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_normal", DropTypeDifficulties.Contains(Difficulties.Normal) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_hard", DropTypeDifficulties.Contains(Difficulties.Hard) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_ultimate", DropTypeDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_category", (uint)DropRateChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_minimum", (uint)(MinimumDropRate * 100));
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_maximum", (uint)(MaximumDropRate * 100));

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_easy", DropRateDifficulties.Contains(Difficulties.Easy) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_normal", DropRateDifficulties.Contains(Difficulties.Normal) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_hard", DropRateDifficulties.Contains(Difficulties.Hard) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_ultimate", DropRateDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_easy_weight", DropRateWeights[0]);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_normal_weight", DropRateWeights[1]);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_hard_weight", DropRateWeights[2]);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_ultimate_weight", DropRateWeights[3]);

            return currentString;
        }
    }
}
