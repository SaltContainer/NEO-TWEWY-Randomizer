using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class Scenario
    {
        [JsonProperty("m_GameObject")]
        public UnityFile GameObject { get; set; }
        [JsonProperty("m_Enabled")]
        public int Enabled { get; set; }
        [JsonProperty("m_Script")]
        public UnityFile Script { get; set; }
        [JsonProperty("m_Name")]
        public string Name { get; set; }
        [JsonProperty("m_List")]
        public IList<UnityAssetInfo> AssetList { get; set; }
        [JsonProperty("m_BootTiming")]
        public SerializedString BootTiming { get; set; }
        [JsonProperty("m_Generation")]
        public LogicalScenarioEvent Generation { get; set; }
        [JsonProperty("m_Preparation")]
        public IList<ScenarioEvent> Preparation { get; set; }
        [JsonProperty("m_Ready")]
        public LogicalScenarioEvent Ready { get; set; }
        [JsonProperty("m_Done")]
        public LogicalScenarioEvent Done { get; set; }
        [JsonProperty("m_Result")]
        public IList<ScenarioEvent> Result { get; set; }
        [JsonProperty("m_NextList")]
        public IList<UnityFile> NextList { get; set; }
        [JsonProperty("m_ReplayBootList")]
        public IList<UnityFile> ReplayBootList { get; set; }
        [JsonProperty("m_ReplayDone")]
        public LogicalScenarioEvent ReplayDone { get; set; }
        [JsonProperty("m_StruggleList")]
        public IList<UnityFile> StruggleList { get; set; }
        [JsonProperty("m_Permanent")]
        public int Permanent { get; set; }
        [JsonProperty("m_DoneNextStatus")]
        public int DoneNextStatus { get; set; }
        [JsonProperty("m_DisablePermanentConditions")]
        public LogicalScenarioEvent DisablePermanentConditions { get; set; }
        [JsonProperty("m_IsDoneNextImmediate")]
        public int IsDoneNextImmediate { get; set; }
        [JsonProperty("m_IsBootTimingCheckField")]
        public int IsBootTimingCheckField { get; set; }
        [JsonProperty("m_MarkerList")]
        public IList<UnityFile> MarkerList { get; set; }
        [JsonProperty("m_DayEndScenario")]
        public int DayEndScenario { get; set; }
        [JsonProperty("m_EventID")]
        public long EventID { get; set; }
    }
}
