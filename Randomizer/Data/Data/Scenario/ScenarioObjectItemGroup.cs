using AssetsTools.NET;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioObjectItemGroup
    {
        public UnityFile GameObject { get; set; }
        public bool Enabled { get; set; }
        public UnityFile Script { get; set; }
        public string Name { get; set; }
        public IList<ScenarioObjectItem> List { get; set; }
        public EnumItem BootTiming { get; set; }
        public ScenarioConditionGroup Generation { get; set; }
        public IList<ScenarioCondition> Preparation { get; set; }
        public ScenarioConditionGroup Ready { get; set; }
        public ScenarioConditionGroup Done { get; set; }
        public IList<ScenarioCondition> Result { get; set; }
        public IList<UnityFile> NextList { get; set; }
        public IList<UnityFile> ReplayBootList { get; set; }
        public ScenarioConditionGroup ReplayDone { get; set; }
        public IList<UnityFile> StruggleList { get; set; }
        public bool Permanent { get; set; }
        public int DoneNextStatus { get; set; }
        public ScenarioConditionGroup DisablePermanentConditions { get; set; }
        public bool IsDoneNextImmediate { get; set; }
        public bool IsBootTimingCheckField { get; set; }
        public IList<UnityFile> MarkerList { get; set; }
        public bool DayEndScenario { get; set; }
        public int EventID { get; set; }

        public static ScenarioObjectItemGroup CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioObjectItemGroup()
            {
                GameObject = UnityFile.CreateFromMono(baseField["m_GameObject"]),
                Enabled = baseField["m_Enabled"].AsBool,
                Script = UnityFile.CreateFromMono(baseField["m_Script"]),
                Name = baseField["m_Name"].AsString,
                List = baseField["m_List"]["Array"].Select(ScenarioObjectItem.CreateFromMono).ToList(),
                BootTiming = EnumItem.CreateFromMono(baseField["m_BootTiming"]),
                Generation = ScenarioConditionGroup.CreateFromMono(baseField["m_Generation"]),
                Preparation = baseField["m_Preparation"]["Array"].Select(ScenarioCondition.CreateFromMono).ToList(),
                Ready = ScenarioConditionGroup.CreateFromMono(baseField["m_Ready"]),
                Done = ScenarioConditionGroup.CreateFromMono(baseField["m_Done"]),
                Result = baseField["m_Result"]["Array"].Select(ScenarioCondition.CreateFromMono).ToList(),
                NextList = baseField["m_NextList"]["Array"].Select(UnityFile.CreateFromMono).ToList(),
                ReplayBootList = baseField["m_ReplayBootList"]["Array"].Select(UnityFile.CreateFromMono).ToList(),
                ReplayDone = ScenarioConditionGroup.CreateFromMono(baseField["m_ReplayDone"]),
                StruggleList = baseField["m_StruggleList"]["Array"].Select(UnityFile.CreateFromMono).ToList(),
                Permanent = baseField["m_Permanent"].AsBool,
                DoneNextStatus = baseField["m_DoneNextStatus"].AsInt,
                DisablePermanentConditions = ScenarioConditionGroup.CreateFromMono(baseField["m_DisablePermanentConditions"]),
                IsDoneNextImmediate = baseField["m_IsDoneNextImmediate"].AsBool,
                IsBootTimingCheckField = baseField["m_IsBootTimingCheckField"].AsBool,
                MarkerList = baseField["m_MarkerList"]["Array"].Select(UnityFile.CreateFromMono).ToList(),
                DayEndScenario = baseField["m_DayEndScenario"].AsBool,
                EventID = baseField["m_EventID"].AsInt,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            GameObject.ExportToMono(baseField["m_GameObject"]);
            baseField["m_Enabled"].AsBool = Enabled;
            Script.ExportToMono(baseField["m_Script"]);
            baseField["m_Name"].AsString = Name;
            baseField["m_List"]["Array"].ReplaceArray(List, (x, baseField) => x.ExportToMono(baseField));
            BootTiming.ExportToMono(baseField["m_BootTiming"]);
            Generation.ExportToMono(baseField["m_Generation"]);
            baseField["m_Preparation"]["Array"].ReplaceArray(Preparation, (x, baseField) => x.ExportToMono(baseField));
            Ready.ExportToMono(baseField["m_Ready"]);
            Done.ExportToMono(baseField["m_Done"]);
            baseField["m_Result"]["Array"].ReplaceArray(Result, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_NextList"]["Array"].ReplaceArray(NextList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_ReplayBootList"]["Array"].ReplaceArray(ReplayBootList, (x, baseField) => x.ExportToMono(baseField));
            ReplayDone.ExportToMono(baseField["m_ReplayDone"]);
            baseField["m_StruggleList"]["Array"].ReplaceArray(StruggleList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_Permanent"].AsBool = Permanent;
            baseField["m_DoneNextStatus"].AsInt = DoneNextStatus;
            DisablePermanentConditions.ExportToMono(baseField["m_DisablePermanentConditions"]);
            baseField["m_IsDoneNextImmediate"].AsBool = IsDoneNextImmediate;
            baseField["m_IsBootTimingCheckField"].AsBool = IsBootTimingCheckField;
            baseField["m_MarkerList"]["Array"].ReplaceArray(MarkerList, (x, baseField) => x.ExportToMono(baseField));
            baseField["m_DayEndScenario"].AsBool = DayEndScenario;
            baseField["m_EventID"].AsInt = EventID;
        }
    }
}
