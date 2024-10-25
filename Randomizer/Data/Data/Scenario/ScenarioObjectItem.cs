using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioObjectItem
    {
        public string GUID { get; set; }
        public string AssetPath { get; set; }
        public string AssetBundleFilePath { get; set; }
        public string AssetBundleName { get; set; }
        public string ObjectName { get; set; }
        public string TransformPath { get; set; }
        public bool IsImmediateRelease { get; set; }

        public static ScenarioObjectItem CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioObjectItem()
            {
                GUID = baseField["m_GUID"].AsString,
                AssetPath = baseField["m_AssetPath"].AsString,
                AssetBundleFilePath = baseField["m_AssetBundleFilePath"].AsString,
                AssetBundleName = baseField["m_AssetBundleName"].AsString,
                ObjectName = baseField["m_ObjectName"].AsString,
                TransformPath = baseField["m_TransformPath"].AsString,
                IsImmediateRelease = baseField["m_IsImmediateRelease"].AsBool,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            baseField["m_GUID"].AsString = GUID;
            baseField["m_AssetPath"].AsString = AssetPath;
            baseField["m_AssetBundleFilePath"].AsString = AssetBundleFilePath;
            baseField["m_AssetBundleName"].AsString = AssetBundleName;
            baseField["m_ObjectName"].AsString = ObjectName;
            baseField["m_TransformPath"].AsString = TransformPath;
            baseField["m_IsImmediateRelease"].AsBool = IsImmediateRelease;
        }
    }
}
