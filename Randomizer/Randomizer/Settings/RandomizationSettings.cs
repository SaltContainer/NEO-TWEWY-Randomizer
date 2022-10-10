using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer.Randomizer.Settings
{
    class RandomizationSettings
    {
        public NoiseDropSettings NoiseDrops { get; set; }
        public StoryRewardSettings StoryRewards { get; set; }
        public PinStatSettings PinStats { get; set; }

        public RandomizationSettings()
        {
            InitializeDataStructures();
        }

        private void InitializeDataStructures()
        {
            NoiseDrops = new NoiseDropSettings();
            StoryRewards = new StoryRewardSettings();
            PinStats = new PinStatSettings();
        }

        private void CorrectSettingValues()
        {
            NoiseDrops.CorrectSettingValues();
            PinStats.CorrectSettingValues();
        }

        public RandomizationSettings(string settingsString)
        {
            InitializeDataStructures();

            Validator.SettingsStringValidationResult validationResult = Validator.ValidateSettingsString(settingsString);

            if (validationResult == Validator.SettingsStringValidationResult.Valid || validationResult == Validator.SettingsStringValidationResult.WrongVersion)
            {
                settingsString = settingsString.PadLeft(Validator.SettingsStringMinimumLength, '0');

                uint version = SettingsUtils.GetBitsFromSettingsString(settingsString, 0, 4);
                SettingsStringVersion versionInfo = FileConstants.SettingsStringVersions.Items[(int)version];

                NoiseDrops.ExtractSettingsFromBits(settingsString, versionInfo);
                PinStats.ExtractSettingsFromBits(settingsString, versionInfo);
            }

            CorrectSettingValues();
        }

        public string GenerateSettingsString()
        {
            string settingsString = "";

            settingsString = SettingsUtils.AppendToSettingsString(settingsString, (uint)Validator.SettingsStringVersion, 0, 4);
            SettingsStringVersion versionInfo = FileConstants.SettingsStringVersions.Items[Validator.SettingsStringVersion];

            settingsString = NoiseDrops.GenerateSettingsString(settingsString, versionInfo);
            settingsString = PinStats.GenerateSettingsString(settingsString, versionInfo);

            return settingsString;
        }
    }
}
