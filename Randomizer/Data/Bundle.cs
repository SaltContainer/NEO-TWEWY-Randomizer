using AssetsTools.NET.Extra;

namespace NEO_TWEWY_Randomizer
{
    public abstract class Bundle
    {
        protected AssetsManager manager;
        protected string bundleKey;
        protected BundleFileInstance bundle;
        protected AssetsFileInstance assetsFile;
        protected bool encrypted;

        public AssetsManager Manager { get => manager; }
        public string BundleKey { get => bundleKey; }
        public BundleFileInstance BundleInstance { get => bundle; }
        public AssetsFileInstance AssetsFile { get => assetsFile; }
        public bool Encrypted { get => encrypted; }

        public string FileName { get => FileConstants.Bundles[bundleKey].FileName; }

        public Bundle(AssetsManager manager, BundleFileInstance bundle, string bundleKey, bool encrypted)
        {
            this.manager = manager;
            this.bundle = bundle;
            this.bundleKey = bundleKey;
            this.assetsFile = manager.LoadAssetsFileFromBundle(bundle, 0);
            this.encrypted = encrypted;
        }

        protected void SetAssetsFileInBundle()
        {
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }
    }
}
