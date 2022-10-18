using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ScenarioKindExtension
    {
        [JsonProperty("m_SerializeScenarioIndexKind")]
        public int IndexKind { get; set; }
        [JsonProperty("m_ScenarioCounterList")]
        public IList<ScenarioCounter> ScenarioCounterList { get; set; }
        [JsonProperty("m_ScenarioDoneList")]
        public IList<ScenarioDone> ScenarioDoneList { get; set; }
        [JsonProperty("m_ScenarioMapList")]
        public IList<ScenarioMap> ScenarioMapList { get; set; }
        [JsonProperty("m_ScenarioBadgeList")]
        public IList<ScenarioCounter> ScenarioBadgeList { get; set; }
        [JsonProperty("m_AreaChangeList")]
        public IList<AreaChange> AreaChangeList { get; set; }
        [JsonProperty("m_ShopList")]
        public IList<ScenarioShop> ShopList { get; set; }
        [JsonProperty("m_StrugglePointList")]
        public IList<ScenarioCounter> StrugglePointList { get; set; }
        [JsonProperty("m_StruggleBossList")]
        public IList<StruggleBoss> StruggleBossList { get; set; }
        [JsonProperty("m_StruggleTeamMemberList")]
        public IList<StruggleTeamMember> StruggleTeamMemberList { get; set; }
        [JsonProperty("m_StruggleTeamAreaList")]
        public IList<ScenarioCounter> StruggleTeamAreaList { get; set; }
        [JsonProperty("m_StruggleAreaControllList")]
        public IList<StruggleBoss> StruggleAreaControllList { get; set; }
        [JsonProperty("m_GroupAreaChangeList")]
        public IList<AreaChange> GroupAreaChangeList { get; set; }
        [JsonProperty("m_ReminderExtensionList")]
        public IList<ReminderExtension> ReminderExtensionList { get; set; }
        [JsonProperty("m_ImprintResultExtensionList")]
        public IList<ImprintResultExtension> ImprintResultExtensionList { get; set; }
        [JsonProperty("m_AddCharacterList")]
        public IList<AddCharacter> AddCharacterList { get; set; }
        [JsonProperty("m_ScenarioResetList")]
        public IList<ScenarioReset> ScenarioResetList { get; set; }
    }
}
