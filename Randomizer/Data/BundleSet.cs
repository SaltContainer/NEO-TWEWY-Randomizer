namespace NEO_TWEWY_Randomizer
{
    public class BundleSet
    {
        public TextBundle TextData { get; set; } = null;
        public ScenarioBundle W1D2Scenario { get; set; } = null;
        public ScenarioBundle W2D5Scenario { get; set; } = null;

        public bool AreAllBundlesLoaded()
        {
            return TextData != null &&
                W1D2Scenario != null &&
                W2D5Scenario != null;
        }
    }
}
