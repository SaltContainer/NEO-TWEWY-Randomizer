using AssetsTools.NET.Extra;
using System.IO;

namespace NEO_TWEWY_Randomizer
{
    public class BundleEngine
    {
        private AssetsManager manager;
        private BundleDecryptor decryptor;

        public BundleEngine()
        {
            manager = new AssetsManager();
            decryptor = new BundleDecryptor(manager);
        }

        public void UnloadBundles()
        {
            manager.UnloadAll();
        }

        public TextBundle LoadTextBundle(string path, string key)
        {
            return new TextBundle(manager, LoadBundleFile(path, out bool encrypted), key, encrypted);
        }

        public ScenarioBundle LoadScenarioBundle(string path, string key)
        {
            return new ScenarioBundle(manager, LoadBundleFile(path, out bool encrypted), key, encrypted);
        }

        public void SaveBundleToFile(Bundle bundle, string path)
        {
            decryptor.SaveAndEncryptBundle(bundle.BundleInstance, Path.Combine(path, bundle.FileName), bundle.Encrypted);
        }

        private BundleFileInstance LoadBundleFile(string path, out bool encrypted)
        {
            return decryptor.LoadAndDecryptBundle(path, out encrypted);
        }
    }
}
