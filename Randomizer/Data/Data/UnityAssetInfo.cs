using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class UnityAssetInfo
    {
        [JsonProperty("m_GUID")]
        public string GUID { get; set; }
        [JsonProperty("m_AssetPath")]
        public string AssetPath { get; set; }
        [JsonProperty("m_AssetBundleFilePath")]
        public string AssetBundleFilePath { get; set; }
        [JsonProperty("m_AssetBundleName")]
        public string AssetBundleName { get; set; }
        [JsonProperty("m_ObjectName")]
        public string ObjectName { get; set; }
        [JsonProperty("m_TransformPath")]
        public string TransformPath { get; set; }
        [JsonProperty("m_IsImmediateRelease")]
        public int IsImmediateRelease { get; set; }
    }
}
