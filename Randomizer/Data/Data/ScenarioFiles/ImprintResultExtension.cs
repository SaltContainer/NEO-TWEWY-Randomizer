using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ImprintResultExtension
    {
        [JsonProperty("m_ImprintResultOperator")]
        public SerializedString ImprintResultOperator { get; set; }
        [JsonProperty("m_ImprintResult")]
        public SerializedString ImprintResult { get; set; }
    }
}
