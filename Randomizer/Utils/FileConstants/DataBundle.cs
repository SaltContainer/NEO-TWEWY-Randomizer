using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class DataBundle
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        [JsonProperty("cab_directory")]
        public string CabDirectory { get; set; }
        [JsonProperty("classes")]
        public Dictionary<string, DataClass> Classes { get; set; }
    }
}
