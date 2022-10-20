using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class UnityFile
    {
        [JsonProperty("m_FileID")]
        public long FileID { get; set; }
        [JsonProperty("m_PathID")]
        public long PathID { get; set; }
    }
}
