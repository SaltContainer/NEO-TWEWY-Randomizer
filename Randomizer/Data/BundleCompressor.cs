using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.IO;
using System.Reflection;

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
                var decryptedPath = Path.Combine(GetTempFolder(), Path.GetFileName(fileName) + "_decrypted");

                using (FileStream stream = new FileStream(decryptedPath, FileMode.OpenOrCreate, FileAccess.Write))
                    stream.Write(decryptedData, 0, decryptedData.Length);

                using (FileStream stream = new FileStream(decryptedPath, FileMode.Open, FileAccess.Read))
                    bundle = assetsManager.LoadBundleFile(stream);

                File.Delete(decryptedPath);

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

        private string GetTempFolder()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Temp");
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
