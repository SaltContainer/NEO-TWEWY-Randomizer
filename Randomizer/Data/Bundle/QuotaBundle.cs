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
    class QuotaBundle : Bundle
    {
        public QuotaBundle(AssetsManager assetsManager, BundleFileInstance bundle, string bundleKey) : base(assetsManager, bundle, bundleKey) { }

        public override string GetScriptFile(string fileName)
        {
            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(fileName);
            AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

            return QuotaAssetConverter.ConvertFromBaseField(baseField, FileConstants.Bundles[bundleKey].Files[fileName].SubType);
        }

        public override void SetScriptFiles(Dictionary<string, string> scripts)
        {
            List<AssetsReplacer> replacers = new List<AssetsReplacer>();
            foreach (var script in scripts)
            {
                AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(script.Key);
                AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

                SetQuotaAssetScriptFile(baseField, script.Value);

                replacers.Add(new AssetsReplacerFromMemory(0, fileInfo.index, (int)fileInfo.curFileType, 0xffff, baseField.WriteToByteArray()));
            }

            using (var stream = new MemoryStream())
            using (var writer = new AssetsFileWriter(stream))
            {
                assetsFile.file.Write(writer, 0, replacers, 0);
                newData = stream.ToArray();
            }
        }

        private void SetQuotaAssetScriptFile(AssetTypeValueField baseField, string newValue)
        {
            QuotaAssetConverter.InsertInBaseField(baseField, newValue);
        }
    }
}
