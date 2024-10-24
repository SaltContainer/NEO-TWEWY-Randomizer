using AssetsTools.NET.Extra;
using AssetsTools.NET;
using System.Collections.Generic;
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

        public Bundle LoadBundle(string path, string key)
        {
            return new Bundle(manager, LoadBundleFile(path, out bool encrypted), key, encrypted);
        }

        public BundleFileInstance LoadBundleFile(string path, out bool encrypted)
        {
            return decryptor.LoadAndDecryptBundle(path, out encrypted);
        }

        public AssetsFileInstance LoadAssetsFileFromBundle(BundleFileInstance bundle)
        {
            return manager.LoadAssetsFileFromBundle(bundle, 0);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path, bool encrypted)
        {
            decryptor.SaveAndEncryptBundle(bundle, path, encrypted);
        }

        public void SaveBundleToFile(Bundle bundle, string path)
        {
            decryptor.SaveAndEncryptBundle(bundle.BundleInstance, Path.Combine(path, bundle.FileName), bundle.Encrypted);
        }

        private void SetAssetsFileInBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }

        private int FindObjectOfName(List<AssetTypeValueField> objBaseFields, string name)
        {
            return objBaseFields.FindIndex(s => s["m_Name"].AsString == name);
        }
    }
}
