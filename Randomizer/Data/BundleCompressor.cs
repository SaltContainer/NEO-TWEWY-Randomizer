using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class BundleCompressor
    {
        private AssetsManager assetsManager;

        public BundleCompressor(AssetsManager assetsManager)
        {
            this.assetsManager = assetsManager;
        }

        public BundleFileInstance LoadAndDecompressFile(string fileName)
        {
            BundleFileInstance bundle = assetsManager.LoadBundleFile(fileName);
            bundle.file.reader.Position = 0;

            MemoryStream bundleStream = new MemoryStream();
            bundle.file.Unpack(bundle.file.reader, new AssetsFileWriter(bundleStream));

            bundleStream.Position = 0;

            AssetBundleFile newBundle = new AssetBundleFile();
            newBundle.Read(new AssetsFileReader(bundleStream));

            bundle.file.reader.Close();
            bundle.file = newBundle;

            return bundle;
        }
    }
}
