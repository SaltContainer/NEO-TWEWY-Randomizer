namespace NEO_TWEWY_Randomizer
{
    public class RandomizationSettings
    {
        public NoiseDropSettings NoiseDrops { get; set; }
        public PinStatSettings PinStats { get; set; }
        public StoryRewardSettings StoryRewards { get; set; }
        public NetworkSettings Network { get; set; }

        public RandomizationSettings()
        {
            InitializeDataStructures();
        }

        private void InitializeDataStructures()
        {
            NoiseDrops = new NoiseDropSettings();
            PinStats = new PinStatSettings();
            StoryRewards = new StoryRewardSettings();
            Network = new NetworkSettings();
        }

        private void CorrectSettingValues()
        {
            NoiseDrops.CorrectSettingValues();
            PinStats.CorrectSettingValues();
            StoryRewards.CorrectSettingValues();
            Network.CorrectSettingValues();
        }

        public RandomizationSettings(string settingsString)
        {
            InitializeDataStructures();

            Validator.SettingsStringValidationResult validationResult = Validator.ValidateSettingsString(settingsString);

            if (validationResult == Validator.SettingsStringValidationResult.Valid || validationResult == Validator.SettingsStringValidationResult.WrongVersion)
            {
                settingsString = settingsString.PadLeft((int)Validator.GetSettingsStringMinSize(), '0');

                uint version = SettingsUtils.GetBitsFromSettingsString(settingsString, 0, 4);
                SettingsStringVersion versionInfo = FileConstants.SettingsStringVersions.Items[(int)version];

                NoiseDrops.ExtractSettingsFromBits(settingsString, versionInfo);
                PinStats.ExtractSettingsFromBits(settingsString, versionInfo);
                StoryRewards.ExtractSettingsFromBits(settingsString, versionInfo);
                Network.ExtractSettingsFromBits(settingsString, versionInfo);
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
            settingsString = StoryRewards.GenerateSettingsString(settingsString, versionInfo);
            settingsString = Network.GenerateSettingsString(settingsString, versionInfo);

            return settingsString;
        }
    }
}
