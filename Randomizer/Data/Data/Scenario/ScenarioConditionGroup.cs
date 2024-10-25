using AssetsTools.NET;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioConditionGroup
    {
        public EnumItem Logic { get; set; }
        public bool Inverse { get; set; }
        public IList<ScenarioCondition> List { get; set; }

        public static ScenarioConditionGroup CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioConditionGroup()
            {
                Logic = EnumItem.CreateFromMono(baseField["m_Logic"]),
                Inverse = baseField["m_Inverse"].AsBool,
                List = baseField["m_List"]["Array"].Select(ScenarioCondition.CreateFromMono).ToList(),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            Logic.ExportToMono(baseField["m_Logic"]);
            baseField["m_Inverse"].AsBool = Inverse;
            baseField["m_List"]["Array"].ReplaceArray(List, (x, baseField) => x.ExportToMono(baseField));
        }
    }
}
