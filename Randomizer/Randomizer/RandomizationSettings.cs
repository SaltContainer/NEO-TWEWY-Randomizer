using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class RandomizationSettings
    {
        public NoiseDropType NoiseDropType { get; set; }
        public bool IncludeLimitedPins { get; set; }
        public List<Difficulties> NoiseDropTypeDifficulties { get; set; }

        public RandomizationSettings()
        {
            InitializeDataStructures();
        }

        public RandomizationSettings(string settingsString) : this()
        {
            InitializeDataStructures();

            if (Validator.ValidateSettingsString(settingsString))
            {
                int l = settingsString.Length;

                int droppedPins = int.Parse(settingsString.Substring(l-1, 1), System.Globalization.NumberStyles.HexNumber);
                NoiseDropType = (NoiseDropType) (droppedPins & 0b0111);

                IncludeLimitedPins = IsBitSet(droppedPins, 3);

                int droppedPinsDifficulties = int.Parse(settingsString.Substring(l - 2, 1), System.Globalization.NumberStyles.HexNumber);
                if (IsBitSet(droppedPinsDifficulties, 0)) NoiseDropTypeDifficulties.Add(Difficulties.Easy);
                if (IsBitSet(droppedPinsDifficulties, 1)) NoiseDropTypeDifficulties.Add(Difficulties.Normal);
                if (IsBitSet(droppedPinsDifficulties, 2)) NoiseDropTypeDifficulties.Add(Difficulties.Hard);
                if (IsBitSet(droppedPinsDifficulties, 3)) NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);
            }
        }

        private bool IsBitSet(int num, int pos)
        {
            return (num & (1 << pos)) != 0;
        }

        private void InitializeDataStructures()
        {
            NoiseDropTypeDifficulties = new List<Difficulties>();
        }

        public string GenerateSettingsString()
        {
            string settingsString = "";

            int droppedPins = (int) NoiseDropType;
            if (IncludeLimitedPins) droppedPins += 0b1000;
            settingsString = droppedPins.ToString("X") + settingsString;

            int droppedPinsDifficulties = 0;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Easy)) droppedPinsDifficulties += 0b0001;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Normal)) droppedPinsDifficulties += 0b0010;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Hard)) droppedPinsDifficulties += 0b0100;
            if (NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate)) droppedPinsDifficulties += 0b1000;
            settingsString = droppedPinsDifficulties.ToString("X") + settingsString;

            return settingsString;
        }
    }
}
