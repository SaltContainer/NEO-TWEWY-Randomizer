using AssetsTools.NET.Extra;
using AssetsTools.NET;
using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class TextBundle : Bundle
    {
        private EnemyDataList enemyData = null;
        private PigDataList pigData = null;
        private PsychicList psychic = null;
        private AttackComboSetList attackComboSet = null;
        private AttackList attack = null;
        private BadgeList badge = null;
        private AttackHitList attackHit = null;
        private ScenarioRewardsList scenarioRewards = null;
        private SkillList skill = null;
        private SkillTreeList skillTree = null;

        public TextBundle(AssetsManager manager, BundleFileInstance bundle, string bundleKey, bool encrypted) :
            base (manager, bundle, bundleKey, encrypted) {}

        #region Get Data
        public EnemyDataList GetEnemyData()
        {
            if (enemyData != null)
                return enemyData;

            enemyData = ParseEnemyData();
            return enemyData;
        }

        public PigDataList GetPigData()
        {
            if (pigData != null)
                return pigData;

            pigData = ParsePigData();
            return pigData;
        }

        public PsychicList GetPsychic()
        {
            if (psychic != null)
                return psychic;

            psychic = ParsePsychic();
            return psychic;
        }

        public AttackComboSetList GetAttackComboSet()
        {
            if (attackComboSet != null)
                return attackComboSet;

            attackComboSet = ParseAttackComboSet();
            return attackComboSet;
        }

        public AttackList GetAttack()
        {
            if (attack != null)
                return attack;

            attack = ParseAttack();
            return attack;
        }

        public BadgeList GetBadge()
        {
            if (badge != null)
                return badge;

            badge = ParseBadge();
            return badge;
        }

        public AttackHitList GetAttackHit()
        {
            if (attackHit != null)
                return attackHit;

            attackHit = ParseAttackHit();
            return attackHit;
        }

        public ScenarioRewardsList GetScenarioRewards()
        {
            if (scenarioRewards != null)
                return scenarioRewards;

            scenarioRewards = ParseScenarioRewards();
            return scenarioRewards;
        }

        public SkillList GetSkill()
        {
            if (skill != null)
                return skill;

            skill = ParseSkill();
            return skill;
        }

        public SkillTreeList GetSkillTree()
        {
            if (skillTree != null)
                return skillTree;

            skillTree = ParseSkillTree();
            return skillTree;
        }
        #endregion

        #region Parsing
        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public EnemyDataList ParseEnemyData()
        {
            return JsonConvert.DeserializeObject<EnemyDataList>(GetBaseFieldOfAsset(FileConstants.EnemyDataAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public PigDataList ParsePigData()
        {
            return JsonConvert.DeserializeObject<PigDataList>(GetBaseFieldOfAsset(FileConstants.PigDataAssetName)["m_Script"].AsString);
        }
        
        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public PsychicList ParsePsychic()
        {
            return JsonConvert.DeserializeObject<PsychicList>(GetBaseFieldOfAsset(FileConstants.PsychicAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public AttackComboSetList ParseAttackComboSet()
        {
            return JsonConvert.DeserializeObject<AttackComboSetList>(GetBaseFieldOfAsset(FileConstants.AttackComboSetAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public AttackList ParseAttack()
        {
            return JsonConvert.DeserializeObject<AttackList>(GetBaseFieldOfAsset(FileConstants.AttackAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public BadgeList ParseBadge()
        {
            return JsonConvert.DeserializeObject<BadgeList>(GetBaseFieldOfAsset(FileConstants.BadgeAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public AttackHitList ParseAttackHit()
        {
            return JsonConvert.DeserializeObject<AttackHitList>(GetBaseFieldOfAsset(FileConstants.AttackHitAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public ScenarioRewardsList ParseScenarioRewards()
        {
            return JsonConvert.DeserializeObject<ScenarioRewardsList>(GetBaseFieldOfAsset(FileConstants.ScenarioRewardsAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public SkillList ParseSkill()
        {
            return JsonConvert.DeserializeObject<SkillList>(GetBaseFieldOfAsset(FileConstants.SkillAssetName)["m_Script"].AsString);
        }

        /// <summary>
        /// Call instead of Get to get a new object with the original data
        /// </summary>
        /// <returns></returns>
        public SkillTreeList ParseSkillTree()
        {
            return JsonConvert.DeserializeObject<SkillTreeList>(GetBaseFieldOfAsset(FileConstants.SkillTreeAssetName)["m_Script"].AsString);
        }
        #endregion

        public void SaveTextData()
        {
            SetTextInAsset(FileConstants.EnemyDataAssetName, enemyData, new FloatFormatConverter(4));
            SetTextInAsset(FileConstants.PigDataAssetName, pigData);
            SetTextInAsset(FileConstants.BadgeAssetName, badge, new FloatFormatConverter(1));
            SetTextInAsset(FileConstants.AttackHitAssetName, attackHit);
            SetTextInAsset(FileConstants.ScenarioRewardsAssetName, scenarioRewards, new FloatFormatConverter(1));
            SetTextInAsset(FileConstants.SkillAssetName, skill, new FloatFormatConverter(1));
            SetTextInAsset(FileConstants.SkillTreeAssetName, skillTree);

            SetAssetsFileInBundle();
        }

        private AssetFileInfo GetAssetInfoOfAsset(string assetName)
        {
            return assetsFile.file.GetAssetsOfType(AssetClassID.TextAsset)
                .Find(f => manager.GetBaseField(assetsFile, f)["m_Name"].AsString == assetName);
        }

        private AssetTypeValueField GetBaseFieldOfAsset(string assetName)
        {
            return manager.GetBaseField(assetsFile, GetAssetInfoOfAsset(assetName));
        }

        private void SetTextInAsset(string assetName, object value, params JsonConverter[] converters)
        {
            var assetInfo = GetAssetInfoOfAsset(assetName);
            var baseField = GetBaseFieldOfAsset(assetName);

            baseField["m_Script"].AsString = JsonConvert.SerializeObject(value, Formatting.Indented, converters);
            assetInfo.SetNewData(baseField);
        }
    }
}
