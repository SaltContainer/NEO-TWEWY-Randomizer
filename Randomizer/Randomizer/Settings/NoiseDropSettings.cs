using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class NoiseDropSettings
    {
        public NoiseDropType NoiseDropTypeChoice { get; set; }
        public bool NoiseIncludeLimitedPins { get; set; }
        public List<Difficulties> NoiseDropTypeDifficulties { get; set; }
        public NoiseDropRate NoiseDropRateChoice { get; set; }
        public decimal NoiseMinimumDropRate { get; set; }
        public decimal NoiseMaximumDropRate { get; set; }
        public List<Difficulties> NoiseDropRateDifficulties { get; set; }
        public List<uint> NoiseDropRateWeights { get; set; }

        public NoiseDropSettings()
        {
            InitializeDataStructures();
            CorrectSettingValues();
        }

        private void InitializeDataStructures()
        {
            NoiseDropTypeDifficulties = new List<Difficulties>();
            NoiseDropRateDifficulties = new List<Difficulties>();
            NoiseDropRateWeights = new List<uint> { 0, 0, 0, 0 };
        }

        public void CorrectSettingValues()
        {
            if (!Enum.IsDefined(typeof(NoiseDropType), NoiseDropTypeChoice)) NoiseDropTypeChoice = NoiseDropType.Unchanged;
            if (!Enum.IsDefined(typeof(NoiseDropRate), NoiseDropRateChoice)) NoiseDropRateChoice = NoiseDropRate.Unchanged;
            NoiseMinimumDropRate = Math.Max(Math.Min(NoiseMinimumDropRate, 100M), 0.01M);
            NoiseMaximumDropRate = Math.Max(Math.Min(NoiseMaximumDropRate, 100M), 0.01M);
            if (NoiseMinimumDropRate > NoiseMaximumDropRate) NoiseMaximumDropRate = NoiseMinimumDropRate;
            NoiseDropRateWeights = NoiseDropRateWeights.Select(weight => Math.Max(Math.Min(weight, 100), 1)).ToList();
        }

        public void ExtractSettingsFromBits(string settingsString, SettingsStringVersion version)
        {
            NoiseDropTypeChoice = (NoiseDropType)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_category");
            NoiseIncludeLimitedPins = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_limited") == 1;

            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_easy") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Easy);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_normal") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Normal);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_hard") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Hard);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "dropped_pin_ultimate") == 1) NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

            NoiseDropRateChoice = (NoiseDropRate)SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_category");
            uint minDropRate = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_minimum");
            NoiseMinimumDropRate = minDropRate / 100M;
            uint maxDropRate = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_maximum");
            NoiseMaximumDropRate = maxDropRate / 100M;

            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_easy") == 1) NoiseDropRateDifficulties.Add(Difficulties.Easy);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_normal") == 1) NoiseDropRateDifficulties.Add(Difficulties.Normal);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_hard") == 1) NoiseDropRateDifficulties.Add(Difficulties.Hard);
            if (SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_ultimate") == 1) NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

            NoiseDropRateWeights[0] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_easy_weight");
            NoiseDropRateWeights[1] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_normal_weight");
            NoiseDropRateWeights[2] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_hard_weight");
            NoiseDropRateWeights[3] = SettingsUtils.GetBitsFromSettingsString(settingsString, version, "drop_rate_ultimate_weight");
        }

        public string GenerateSettingsString(string currentString, SettingsStringVersion version)
        {
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_category", (uint)NoiseDropTypeChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_limited", NoiseIncludeLimitedPins ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_easy", NoiseDropTypeDifficulties.Contains(Difficulties.Easy) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_normal", NoiseDropTypeDifficulties.Contains(Difficulties.Normal) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_hard", NoiseDropTypeDifficulties.Contains(Difficulties.Hard) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "dropped_pin_ultimate", NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_category", (uint)NoiseDropRateChoice);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_minimum", (uint)(NoiseMinimumDropRate * 100));
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_maximum", (uint)(NoiseMaximumDropRate * 100));

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_easy", NoiseDropRateDifficulties.Contains(Difficulties.Easy) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_normal", NoiseDropRateDifficulties.Contains(Difficulties.Normal) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_hard", NoiseDropRateDifficulties.Contains(Difficulties.Hard) ? 1u : 0u);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_ultimate", NoiseDropRateDifficulties.Contains(Difficulties.Ultimate) ? 1u : 0u);

            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_easy_weight", NoiseDropRateWeights[0]);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_normal_weight", NoiseDropRateWeights[1]);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_hard_weight", NoiseDropRateWeights[2]);
            currentString = SettingsUtils.AppendToSettingsString(currentString, version, "drop_rate_ultimate_weight", NoiseDropRateWeights[3]);

            return currentString;
        }
    }
}
