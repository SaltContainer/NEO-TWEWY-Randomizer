using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.IO;
using System.Reflection;

namespace NEO_TWEWY_Randomizer
{
    public class BundleDecryptor
    {
        private AssetsManager assetsManager;

        public BundleDecryptor(AssetsManager assetsManager)
        {
            this.assetsManager = assetsManager;
        }

        public BundleFileInstance LoadAndDecryptBundle(string fileName, out bool encrypted)
        {
            BundleFileInstance bundle;

            if (Unity3dCrypto.TryDecryptFile(fileName, out byte[] decryptedData))
            {
                // Encrypted
                bundle = assetsManager.LoadBundleFile(new MemoryStream(decryptedData), fileName);
                encrypted = true;
            }
            else
            {
                // Not encrypted
                bundle = assetsManager.LoadBundleFile(fileName);
                encrypted = false;
            }

            return bundle;
        }

        public void SaveAndEncryptBundle(BundleFileInstance bundle, string fileName, bool encrypted)
        {
            if (encrypted)
            {
                // Encrypted
                var memStream = new MemoryStream();
                using (AssetsFileWriter bundleWriter = new AssetsFileWriter(memStream))
                {
                    bundle.file.Write(bundleWriter);
                    bundleWriter.Flush();

                    Unity3dCrypto.TryEncryptFile(memStream.ToArray(), out byte[] result);
                    using (FileStream stream = File.OpenWrite(fileName))
                        stream.Write(result, 0, result.Length);
                }
            }
            else
            {
                // Not encrypted
                using (FileStream stream = File.OpenWrite(fileName))
                {
                    using (AssetsFileWriter bundleWriter = new AssetsFileWriter(stream))
                        bundle.file.Write(bundleWriter);
                }
            }
        }

        private string GetTempFolder()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Temp");
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
