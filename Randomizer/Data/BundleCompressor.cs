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

        public BundleFileInstance LoadAndDecompressFile(string fileName, out bool encrypted)
        {
            BundleFileInstance bundle;

            if (!Unity3dCrypto.TryDecryptFile(fileName, out byte[] decryptedData))
            {
                // Not encrypted
                bundle = assetsManager.LoadBundleFile(fileName);
                encrypted = false;
            }
            else
            {
                // Encrypted
                using (FileStream stream = new FileStream(fileName + "_decrypted", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    stream.Write(decryptedData, 0, decryptedData.Length);

                    stream.Position = 0;
                    bundle = assetsManager.LoadBundleFile(stream);
                }

                encrypted = true;
            } 

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
