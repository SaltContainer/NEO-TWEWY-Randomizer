using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class UnityFile
    {
        public int FileID { get; set; }
        public long PathID { get; set; }

        public static UnityFile CreateFromMono(AssetTypeValueField baseField)
        {
            return new UnityFile()
            {
                FileID = baseField["m_FileID"].AsInt,
                PathID = baseField["m_PathID"].AsLong,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            baseField["m_FileID"].AsInt = FileID;
            baseField["m_PathID"].AsLong = PathID;
        }
    }
}
