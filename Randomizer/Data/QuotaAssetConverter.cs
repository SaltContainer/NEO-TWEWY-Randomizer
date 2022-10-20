using AssetsTools.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class QuotaAssetConverter
    {
        public static string ConvertFromBaseField(AssetTypeValueField baseField, string subtype)
        {
            List<string> fields = new List<string>();
            fields.Add(string.Format("\"{0}\":\"{1}\"", "type", subtype));
            foreach (var child in baseField.GetChildrenList())
            {
                fields.Add(MonoBehaviorConverter.CreateField(child));
            }
            return string.Format("{{{0}}}", string.Join(",", fields));
        }

        public static void InsertInBaseField(AssetTypeValueField baseField, string newValue)
        {
            Quota quota = JsonConvert.DeserializeObject<Quota>(newValue);
        }
    }
}
