using NEO_TWEWY_Randomizer.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    public partial class FormMain : Form
    {
        private PinImages pinImages;
        private RandomizationEngine randomizationEngine;

        public FormMain()
        {
            InitializeComponent();
            InitializeComponentValues();
            InitializeTooltips();

            GenerateNewSeed();
            randomizationEngine = new RandomizationEngine();
        }

        #region Component Values
        private void InitializeComponentValues()
        {
            lbVersion.Text = string.Format("NEO: The World Ends With You Randomizer - Version {0}", SourceLinks.GetSmallVersion());
            UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Not Loaded"));

            comboPinGrowth.DataSource = FileConstants.ItemNames.GrowthRates;
            comboPinGrowth.SelectedItem = FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int)PinGrowth.Normal).First();

            pinImages = new PinImages();
            picPin.Image = pinImages.GetRandomImage();
        }
        #endregion

        #region Tooltips
        private void InitializeTooltips()
        {
            ttFormMain.SetToolTip(radioItemsUnchanged, Resources.ttradioItemsUnchanged);
            ttFormMain.SetToolTip(radioItemsShuffleC, Resources.ttradioItemsShuffleC);
            ttFormMain.SetToolTip(radioItemsShuffleS, Resources.ttradioItemsShuffleS);
            ttFormMain.SetToolTip(radioItemsRandomC, Resources.ttradioItemsRandomC);
            ttFormMain.SetToolTip(radioItemsRandomA, Resources.ttradioItemsRandomA);
            ttFormMain.SetToolTip(checkItemsLimited, Resources.ttcheckItemsLimited);
            ttFormMain.SetToolTip(grpItemsDifficulty, Resources.ttgrpItemsDifficulty);
            ttFormMain.SetToolTip(checkItemsEasy, Resources.ttgrpItemsDifficulty);
            ttFormMain.SetToolTip(checkItemsNormal, Resources.ttgrpItemsDifficulty);
            ttFormMain.SetToolTip(checkItemsHard, Resources.ttgrpItemsDifficulty);
            ttFormMain.SetToolTip(checkItemsUltimate, Resources.ttgrpItemsDifficulty);

            ttFormMain.SetToolTip(radioChanceUnchanged, Resources.ttradioChanceUnchanged);
            ttFormMain.SetToolTip(radioChanceRandomC, Resources.ttradioChanceRandomC);
            ttFormMain.SetToolTip(radioChanceRandomW, Resources.ttradioChanceRandomW);
            ttFormMain.SetToolTip(grpChanceDifficulty, Resources.ttgrpChanceDifficulty);
            ttFormMain.SetToolTip(checkChanceEasy, Resources.ttgrpChanceDifficulty);
            ttFormMain.SetToolTip(checkChanceNormal, Resources.ttgrpChanceDifficulty);
            ttFormMain.SetToolTip(checkChanceHard, Resources.ttgrpChanceDifficulty);
            ttFormMain.SetToolTip(checkChanceUltimate, Resources.ttgrpChanceDifficulty);
            ttFormMain.SetToolTip(numChanceMin, Resources.ttnumChanceMin);
            ttFormMain.SetToolTip(numChanceMax, Resources.ttnumChanceMax);
            ttFormMain.SetToolTip(numChanceWeightEasy, Resources.ttnumChanceWeight);
            ttFormMain.SetToolTip(numChanceWeightNormal, Resources.ttnumChanceWeight);
            ttFormMain.SetToolTip(numChanceWeightHard, Resources.ttnumChanceWeight);
            ttFormMain.SetToolTip(numChanceWeightUltimate, Resources.ttnumChanceWeight);

            ttFormMain.SetToolTip(radioStoryPinsUnchanged, Resources.ttradioStoryPinsUnchanged);
            ttFormMain.SetToolTip(radioStoryPinsShuffle, Resources.ttradioStoryPinsShuffle);
            ttFormMain.SetToolTip(radioStoryPinsRandom, Resources.ttradioStoryPinsRandom);
            ttFormMain.SetToolTip(checkStoryPinsLimited, Resources.ttcheckStoryPinsLimited);
            ttFormMain.SetToolTip(radioStoryYenUnchanged, Resources.ttradioStoryYenUnchanged);
            ttFormMain.SetToolTip(radioStoryYenShuffle, Resources.ttradioStoryYenShuffle);
            ttFormMain.SetToolTip(radioStoryYenRandom, Resources.ttradioStoryYenRandom);
            ttFormMain.SetToolTip(radioStoryGemsUnchanged, Resources.ttradioStoryGemsUnchanged);
            ttFormMain.SetToolTip(radioStoryGemsShuffle, Resources.ttradioStoryGemsShuffle);
            ttFormMain.SetToolTip(radioStoryGemsRandom, Resources.ttradioStoryGemsRandom);
            ttFormMain.SetToolTip(radioStoryFPUnchanged, Resources.ttradioStoryFPUnchanged);
            ttFormMain.SetToolTip(radioStoryFPShuffle, Resources.ttradioStoryFPShuffle);
            ttFormMain.SetToolTip(radioStoryFPRandom, Resources.ttradioStoryFPRandom);
            ttFormMain.SetToolTip(radioStoryReportUnchanged, Resources.ttradioStoryReportUnchanged);
            ttFormMain.SetToolTip(radioStoryReportShuffle, Resources.ttradioStoryReportShuffle);
            ttFormMain.SetToolTip(radioStoryGlobalUnchanged, Resources.ttradioStoryGlobalUnchanged);
            ttFormMain.SetToolTip(radioStoryGlobalShuffle, Resources.ttradioStoryGlobalShuffle);
            ttFormMain.SetToolTip(grpStoryGlobalIncluded, Resources.ttgrpStoryGlobalIncluded);
            ttFormMain.SetToolTip(checkStoryGlobalPins, Resources.ttcheckStoryGlobalPins);
            ttFormMain.SetToolTip(checkStoryGlobalYen, Resources.ttcheckStoryGlobalYen);
            ttFormMain.SetToolTip(checkStoryGlobalGems, Resources.ttcheckStoryGlobalGems);
            ttFormMain.SetToolTip(checkStoryGlobalFP, Resources.ttcheckStoryGlobalFP);
            ttFormMain.SetToolTip(checkStoryGlobalReport, Resources.ttcheckStoryGlobalReport);

            ttFormMain.SetToolTip(checkPinPower, Resources.ttcheckPinPower);
            ttFormMain.SetToolTip(checkPinPowerScaling, Resources.ttcheckPinPowerScaling);
            ttFormMain.SetToolTip(checkPinLimit, Resources.ttcheckPinLimit);
            ttFormMain.SetToolTip(checkPinLimitScaling, Resources.ttcheckPinLimitScaling);
            ttFormMain.SetToolTip(checkPinReboot, Resources.ttcheckPinReboot);
            ttFormMain.SetToolTip(checkPinRebootScaling, Resources.ttcheckPinRebootScaling);
            ttFormMain.SetToolTip(checkPinBoot, Resources.ttcheckPinBoot);
            ttFormMain.SetToolTip(checkPinBootScaling, Resources.ttcheckPinBootScaling);
            ttFormMain.SetToolTip(checkPinRecover, Resources.ttcheckPinRecover);
            ttFormMain.SetToolTip(checkPinRecoverScaling, Resources.ttcheckPinRecoverScaling);
            ttFormMain.SetToolTip(checkPinCharge, Resources.ttcheckPinCharge);
            ttFormMain.SetToolTip(checkPinSell, Resources.ttcheckPinSell);
            ttFormMain.SetToolTip(checkPinSellScaling, Resources.ttcheckPinSellScaling);
            ttFormMain.SetToolTip(checkPinAffinity, Resources.ttcheckPinAffinity);
            ttFormMain.SetToolTip(checkPinMaxLevel, Resources.ttcheckPinMaxLevel);

            ttFormMain.SetToolTip(radioPinBrandUnchanged, Resources.ttradioPinBrandUnchanged);
            ttFormMain.SetToolTip(radioPinBrandShuffle, Resources.ttradioPinBrandShuffle);
            ttFormMain.SetToolTip(radioPinBrandRandomC, Resources.ttradioPinBrandRandomC);
            ttFormMain.SetToolTip(radioPinBrandRandomU, Resources.ttradioPinBrandRandomU);
            ttFormMain.SetToolTip(checkPinUber, Resources.ttcheckPinUber);
            ttFormMain.SetToolTip(numPinUber, Resources.ttnumPinUber);
            ttFormMain.SetToolTip(radioPinAbilityUnchanged, Resources.ttradioPinAbilityUnchanged);
            ttFormMain.SetToolTip(radioPinAbilityShuffle, Resources.ttradioPinAbilityShuffle);
            ttFormMain.SetToolTip(radioPinAbilityRandom, Resources.ttradioPinAbilityRandom);
            ttFormMain.SetToolTip(numPinAbility, Resources.ttnumPinAbility);
            ttFormMain.SetToolTip(radioPinGrowthUnchanged, Resources.ttradioPinGrowthUnchanged);
            ttFormMain.SetToolTip(radioPinGrowthRandomC, Resources.ttradioPinGrowthRandomC);
            ttFormMain.SetToolTip(radioPinGrowthRandomU, Resources.ttradioPinGrowthRandomU);
            ttFormMain.SetToolTip(radioPinGrowthSpecific, Resources.ttradioPinGrowthSpecific);
            ttFormMain.SetToolTip(comboPinGrowth, Resources.ttcomboPinGrowth);
            ttFormMain.SetToolTip(radioPinEvoUnchanged, Resources.ttradioPinEvoUnchanged);
            ttFormMain.SetToolTip(radioPinEvoRandomE, Resources.ttradioPinEvoRandomE);
            ttFormMain.SetToolTip(radioPinEvoRandomC, Resources.ttradioPinEvoRandomC);
            ttFormMain.SetToolTip(checkPinEvoBrand, Resources.ttcheckPinEvoBrand);
            ttFormMain.SetToolTip(checkPinEvoChara, Resources.ttcheckPinEvoChara);
            ttFormMain.SetToolTip(numPinEvo, Resources.ttnumPinEvo);

            ttFormMain.SetToolTip(radioSkillCostUnchanged, Resources.ttradioSkillCostUnchanged);
            ttFormMain.SetToolTip(radioSkillCostShuffle, Resources.ttradioSkillCostShuffle);
            ttFormMain.SetToolTip(radioSkillCostRandom, Resources.ttradioSkillCostRandom);
            ttFormMain.SetToolTip(radioSkillRewardUnchanged, Resources.ttradioSkillRewardUnchanged);
            ttFormMain.SetToolTip(radioSkillRewardShuffle, Resources.ttradioSkillRewardShuffle);
            ttFormMain.SetToolTip(radioSkillRewardRandomS, Resources.ttradioSkillRewardRandomS);
            ttFormMain.SetToolTip(radioSkillRewardRandomC, Resources.ttradioSkillRewardRandomC);
            ttFormMain.SetToolTip(radioSkillShuffleUnchanged, Resources.ttradioSkillShuffleUnchanged);
            ttFormMain.SetToolTip(radioSkillShuffleShuffle, Resources.ttradioSkillShuffleShuffle);
        }
        #endregion

        #region Create Settings from Form
        private RandomizationSettings GenerateRandomizationSettings()
        {
            RandomizationSettings settings = new RandomizationSettings();

            #region Noise Drops
            if (radioItemsUnchanged.Checked) settings.NoiseDrops.DropTypeChoice = NoiseDropType.Unchanged;
            else if (radioItemsShuffleC.Checked) settings.NoiseDrops.DropTypeChoice = NoiseDropType.ShuffleCompletely;
            else if (radioItemsShuffleS.Checked) settings.NoiseDrops.DropTypeChoice = NoiseDropType.ShuffleSets;
            else if (radioItemsRandomC.Checked) settings.NoiseDrops.DropTypeChoice = NoiseDropType.RandomCompletely;
            else if (radioItemsRandomA.Checked) settings.NoiseDrops.DropTypeChoice = NoiseDropType.RandomAllPins;

            settings.NoiseDrops.IncludeLimitedPins = checkItemsLimited.Checked;

            if (checkItemsEasy.Checked) settings.NoiseDrops.DropTypeDifficulties.Add(Difficulties.Easy);
            if (checkItemsNormal.Checked) settings.NoiseDrops.DropTypeDifficulties.Add(Difficulties.Normal);
            if (checkItemsHard.Checked) settings.NoiseDrops.DropTypeDifficulties.Add(Difficulties.Hard);
            if (checkItemsUltimate.Checked) settings.NoiseDrops.DropTypeDifficulties.Add(Difficulties.Ultimate);

            if (radioChanceUnchanged.Checked) settings.NoiseDrops.DropRateChoice = NoiseDropRate.Unchanged;
            else if (radioChanceRandomC.Checked) settings.NoiseDrops.DropRateChoice = NoiseDropRate.RandomCompletely;
            else if (radioChanceRandomW.Checked) settings.NoiseDrops.DropRateChoice = NoiseDropRate.RandomWeighted;

            settings.NoiseDrops.MinimumDropRate = numChanceMin.Value;
            settings.NoiseDrops.MaximumDropRate = numChanceMax.Value;

            if (checkChanceEasy.Checked) settings.NoiseDrops.DropRateDifficulties.Add(Difficulties.Easy);
            if (checkChanceNormal.Checked) settings.NoiseDrops.DropRateDifficulties.Add(Difficulties.Normal);
            if (checkChanceHard.Checked) settings.NoiseDrops.DropRateDifficulties.Add(Difficulties.Hard);
            if (checkChanceUltimate.Checked) settings.NoiseDrops.DropRateDifficulties.Add(Difficulties.Ultimate);

            settings.NoiseDrops.DropRateWeights[0] = (uint) numChanceWeightEasy.Value;
            settings.NoiseDrops.DropRateWeights[1] = (uint) numChanceWeightNormal.Value;
            settings.NoiseDrops.DropRateWeights[2] = (uint) numChanceWeightHard.Value;
            settings.NoiseDrops.DropRateWeights[3] = (uint) numChanceWeightUltimate.Value;
            #endregion

            #region Pin Stats
            settings.PinStats.Power = checkPinPower.Checked;
            settings.PinStats.PowerScaling = checkPinPowerScaling.Checked;
            settings.PinStats.Limit = checkPinLimit.Checked;
            settings.PinStats.LimitScaling = checkPinLimitScaling.Checked;
            settings.PinStats.Reboot = checkPinReboot.Checked;
            settings.PinStats.RebootScaling = checkPinRebootScaling.Checked;
            settings.PinStats.Boot = checkPinBoot.Checked;
            settings.PinStats.BootScaling = checkPinBootScaling.Checked;
            settings.PinStats.Recover = checkPinRecover.Checked;
            settings.PinStats.RecoverScaling = checkPinRecoverScaling.Checked;
            settings.PinStats.Charge = checkPinCharge.Checked;
            settings.PinStats.Sell = checkPinSell.Checked;
            settings.PinStats.SellScaling = checkPinSellScaling.Checked;
            settings.PinStats.Affinity = checkPinAffinity.Checked;
            settings.PinStats.MaxLevel = checkPinMaxLevel.Checked;

            if (radioPinBrandUnchanged.Checked) settings.PinStats.BrandChoice = PinBrand.Unchanged;
            else if (radioPinBrandShuffle.Checked) settings.PinStats.BrandChoice = PinBrand.Shuffle;
            else if (radioPinBrandRandomC.Checked) settings.PinStats.BrandChoice = PinBrand.RandomCompletely;
            else if (radioPinBrandRandomU.Checked) settings.PinStats.BrandChoice = PinBrand.RandomUniform;

            settings.PinStats.Uber = checkPinUber.Checked;
            settings.PinStats.UberPercentage = (uint) numPinUber.Value;

            if (radioPinAbilityUnchanged.Checked) settings.PinStats.AbilityChoice = PinAbility.Unchanged;
            else if (radioPinAbilityShuffle.Checked) settings.PinStats.AbilityChoice = PinAbility.Shuffle;
            else if (radioPinAbilityRandom.Checked) settings.PinStats.AbilityChoice = PinAbility.RandomCompletely;
            settings.PinStats.AbilityPercentage = (uint) numPinAbility.Value;

            if (radioPinGrowthUnchanged.Checked) settings.PinStats.GrowthChoice = PinGrowthRandomization.Unchanged;
            else if (radioPinGrowthRandomC.Checked) settings.PinStats.GrowthChoice = PinGrowthRandomization.RandomCompletely;
            else if (radioPinGrowthRandomU.Checked) settings.PinStats.GrowthChoice = PinGrowthRandomization.RandomUniform;
            else if (radioPinGrowthSpecific.Checked) settings.PinStats.GrowthChoice = PinGrowthRandomization.Specific;
            settings.PinStats.GrowthSpecific = (PinGrowth) ((NameAssociation)comboPinGrowth.SelectedItem).Id;

            if (radioPinEvoUnchanged.Checked) settings.PinStats.EvolutionChoice = PinEvolution.Unchanged;
            else if (radioPinEvoRandomE.Checked) settings.PinStats.EvolutionChoice = PinEvolution.RandomExisting;
            else if (radioPinEvoRandomC.Checked) settings.PinStats.EvolutionChoice = PinEvolution.RandomCompletely;
            settings.PinStats.EvoForceBrand = checkPinEvoBrand.Checked;
            settings.PinStats.RemoveCharaEvos = checkPinEvoChara.Checked;
            settings.PinStats.EvoPercentage = (uint)numPinEvo.Value;
            #endregion

            #region Story Rewards
            if (radioStoryPinsUnchanged.Checked) settings.StoryRewards.PinChoice = StoryPin.Unchanged;
            else if (radioStoryPinsShuffle.Checked) settings.StoryRewards.PinChoice = StoryPin.Shuffle;
            else if (radioStoryPinsRandom.Checked) settings.StoryRewards.PinChoice = StoryPin.Random;

            settings.StoryRewards.IncludeLimitedPins = checkStoryPinsLimited.Checked;

            if (radioStoryYenUnchanged.Checked) settings.StoryRewards.YenChoice = StoryYen.Unchanged;
            else if (radioStoryYenShuffle.Checked) settings.StoryRewards.YenChoice = StoryYen.Shuffle;
            else if (radioStoryYenRandom.Checked) settings.StoryRewards.YenChoice = StoryYen.Random;

            if (radioStoryGemsUnchanged.Checked) settings.StoryRewards.GemChoice = StoryGem.Unchanged;
            else if (radioStoryGemsShuffle.Checked) settings.StoryRewards.GemChoice = StoryGem.Shuffle;
            else if (radioStoryGemsRandom.Checked) settings.StoryRewards.GemChoice = StoryGem.Random;

            if (radioStoryFPUnchanged.Checked) settings.StoryRewards.FPChoice = StoryFP.Unchanged;
            else if (radioStoryFPShuffle.Checked) settings.StoryRewards.FPChoice = StoryFP.Shuffle;
            else if (radioStoryFPRandom.Checked) settings.StoryRewards.FPChoice = StoryFP.RandomFixedTotal;

            if (radioStoryReportUnchanged.Checked) settings.StoryRewards.ReportChoice = StoryReport.Unchanged;
            else if (radioStoryReportShuffle.Checked) settings.StoryRewards.ReportChoice = StoryReport.Shuffle;

            if (radioStoryGlobalUnchanged.Checked) settings.StoryRewards.GlobalShuffleChoice = StoryGlobalShuffle.Unchanged;
            else if (radioStoryGlobalShuffle.Checked) settings.StoryRewards.GlobalShuffleChoice = StoryGlobalShuffle.Shuffle;

            if (checkStoryGlobalPins.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Pins);
            if (checkStoryGlobalYen.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Yen);
            if (checkStoryGlobalGems.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Gems);
            if (checkStoryGlobalFP.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.FP);
            if (checkStoryGlobalReport.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Reports);
            #endregion

            #region Social Network
            if (radioSkillCostUnchanged.Checked) settings.Network.CostChoice = SkillCost.Unchanged;
            else if (radioSkillCostShuffle.Checked) settings.Network.CostChoice = SkillCost.Shuffle;
            else if (radioSkillCostRandom.Checked) settings.Network.CostChoice = SkillCost.RandomFixedTotal;

            if (radioSkillRewardUnchanged.Checked) settings.Network.RewardsChoice = SkillRewards.Unchanged;
            else if (radioSkillRewardShuffle.Checked) settings.Network.RewardsChoice = SkillRewards.Shuffle;
            else if (radioSkillRewardRandomS.Checked) settings.Network.RewardsChoice = SkillRewards.RandomSameType;
            else if (radioSkillRewardRandomC.Checked) settings.Network.RewardsChoice = SkillRewards.RandomCompletely;

            if (radioSkillShuffleUnchanged.Checked) settings.Network.ShuffleChoice = SkillShuffle.Unchanged;
            else if (radioSkillShuffleShuffle.Checked) settings.Network.ShuffleChoice = SkillShuffle.Shuffle;
            #endregion

            return settings;
        }
        #endregion

        #region Adjust Form from Settings
        private void ReadSettings(RandomizationSettings settings)
        {
            #region Noise Drops
            switch (settings.NoiseDrops.DropTypeChoice)
            {
                case NoiseDropType.Unchanged:
                    radioItemsUnchanged.Checked = true;
                    break;
                case NoiseDropType.ShuffleCompletely:
                    radioItemsShuffleC.Checked = true;
                    break;
                case NoiseDropType.ShuffleSets:
                    radioItemsShuffleS.Checked = true;
                    break;
                case NoiseDropType.RandomCompletely:
                    radioItemsRandomC.Checked = true;
                    break;
                case NoiseDropType.RandomAllPins:
                    radioItemsRandomA.Checked = true;
                    break;
            }

            checkItemsLimited.Checked = settings.NoiseDrops.IncludeLimitedPins;

            checkItemsEasy.Checked = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Easy);
            checkItemsNormal.Checked = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Normal);
            checkItemsHard.Checked = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Hard);
            checkItemsUltimate.Checked = settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Ultimate);

            switch (settings.NoiseDrops.DropRateChoice)
            {
                case NoiseDropRate.Unchanged:
                    radioChanceUnchanged.Checked = true;
                    break;
                case NoiseDropRate.RandomCompletely:
                    radioChanceRandomC.Checked = true;
                    break;
                case NoiseDropRate.RandomWeighted:
                    radioChanceRandomW.Checked = true;
                    break;
            }

            numChanceMin.Value = settings.NoiseDrops.MinimumDropRate;
            numChanceMax.Value = settings.NoiseDrops.MaximumDropRate;

            checkChanceEasy.Checked = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Easy);
            checkChanceNormal.Checked = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Normal);
            checkChanceHard.Checked = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Hard);
            checkChanceUltimate.Checked = settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Ultimate);

            numChanceWeightEasy.Value = settings.NoiseDrops.DropRateWeights[0];
            numChanceWeightNormal.Value = settings.NoiseDrops.DropRateWeights[1];
            numChanceWeightHard.Value = settings.NoiseDrops.DropRateWeights[2];
            numChanceWeightUltimate.Value = settings.NoiseDrops.DropRateWeights[3];
            #endregion

            #region Pin Stats
            checkPinPower.Checked = settings.PinStats.Power;
            checkPinPowerScaling.Checked = settings.PinStats.PowerScaling;
            checkPinLimit.Checked = settings.PinStats.Limit;
            checkPinLimitScaling.Checked = settings.PinStats.LimitScaling;
            checkPinReboot.Checked = settings.PinStats.Reboot;
            checkPinRebootScaling.Checked = settings.PinStats.RebootScaling;
            checkPinBoot.Checked = settings.PinStats.Boot;
            checkPinBootScaling.Checked = settings.PinStats.BootScaling;
            checkPinRecover.Checked = settings.PinStats.Recover;
            checkPinRecoverScaling.Checked = settings.PinStats.RecoverScaling;
            checkPinCharge.Checked = settings.PinStats.Charge;
            checkPinSell.Checked = settings.PinStats.Sell;
            checkPinSellScaling.Checked = settings.PinStats.SellScaling;
            checkPinAffinity.Checked = settings.PinStats.Affinity;
            checkPinMaxLevel.Checked = settings.PinStats.MaxLevel;

            switch (settings.PinStats.BrandChoice)
            {
                case PinBrand.Unchanged:
                    radioPinBrandUnchanged.Checked = true;
                    break;
                case PinBrand.Shuffle:
                    radioPinBrandShuffle.Checked = true;
                    break;
                case PinBrand.RandomCompletely:
                    radioPinBrandRandomC.Checked = true;
                    break;
                case PinBrand.RandomUniform:
                    radioPinBrandRandomU.Checked = true;
                    break;
            }

            checkPinUber.Checked = settings.PinStats.Uber;
            numPinUber.Value = settings.PinStats.UberPercentage;

            switch (settings.PinStats.AbilityChoice)
            {
                case PinAbility.Unchanged:
                    radioPinAbilityUnchanged.Checked = true;
                    break;
                case PinAbility.Shuffle:
                    radioPinAbilityShuffle.Checked = true;
                    break;
                case PinAbility.RandomCompletely:
                    radioPinAbilityRandom.Checked = true;
                    break;
            }
            numPinAbility.Value = settings.PinStats.AbilityPercentage;

            switch (settings.PinStats.GrowthChoice)
            {
                case PinGrowthRandomization.Unchanged:
                    radioPinGrowthUnchanged.Checked = true;
                    break;
                case PinGrowthRandomization.RandomCompletely:
                    radioPinGrowthRandomC.Checked = true;
                    break;
                case PinGrowthRandomization.RandomUniform:
                    radioPinGrowthRandomU.Checked = true;
                    break;
                case PinGrowthRandomization.Specific:
                    radioPinGrowthSpecific.Checked = true;
                    break;
            }
            comboPinGrowth.SelectedItem = FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int)settings.PinStats.GrowthSpecific).First();

            switch (settings.PinStats.EvolutionChoice)
            {
                case PinEvolution.Unchanged:
                    radioPinEvoUnchanged.Checked = true;
                    break;
                case PinEvolution.RandomExisting:
                    radioPinEvoRandomE.Checked = true;
                    break;
                case PinEvolution.RandomCompletely:
                    radioPinEvoRandomC.Checked = true;
                    break;
            }
            checkPinEvoBrand.Checked = settings.PinStats.EvoForceBrand;
            checkPinEvoChara.Checked = settings.PinStats.RemoveCharaEvos;
            numPinEvo.Value = settings.PinStats.EvoPercentage;
            #endregion

            #region Story Rewards
            switch (settings.StoryRewards.PinChoice)
            {
                case StoryPin.Unchanged:
                    radioStoryPinsUnchanged.Checked = true;
                    break;
                case StoryPin.Shuffle:
                    radioStoryPinsShuffle.Checked = true;
                    break;
                case StoryPin.Random:
                    radioStoryPinsRandom.Checked = true;
                    break;
            }

            checkStoryPinsLimited.Checked = settings.StoryRewards.IncludeLimitedPins;

            switch (settings.StoryRewards.YenChoice)
            {
                case StoryYen.Unchanged:
                    radioStoryYenUnchanged.Checked = true;
                    break;
                case StoryYen.Shuffle:
                    radioStoryYenShuffle.Checked = true;
                    break;
                case StoryYen.Random:
                    radioStoryYenRandom.Checked = true;
                    break;
            }

            switch (settings.StoryRewards.GemChoice)
            {
                case StoryGem.Unchanged:
                    radioStoryGemsUnchanged.Checked = true;
                    break;
                case StoryGem.Shuffle:
                    radioStoryGemsShuffle.Checked = true;
                    break;
                case StoryGem.Random:
                    radioStoryGemsRandom.Checked = true;
                    break;
            }

            switch (settings.StoryRewards.FPChoice)
            {
                case StoryFP.Unchanged:
                    radioStoryFPUnchanged.Checked = true;
                    break;
                case StoryFP.Shuffle:
                    radioStoryFPShuffle.Checked = true;
                    break;
                case StoryFP.RandomFixedTotal:
                    radioStoryFPRandom.Checked = true;
                    break;
            }

            switch (settings.StoryRewards.ReportChoice)
            {
                case StoryReport.Unchanged:
                    radioStoryReportUnchanged.Checked = true;
                    break;
                case StoryReport.Shuffle:
                    radioStoryReportShuffle.Checked = true;
                    break;
            }

            switch (settings.StoryRewards.GlobalShuffleChoice)
            {
                case StoryGlobalShuffle.Unchanged:
                    radioStoryGlobalUnchanged.Checked = true;
                    break;
                case StoryGlobalShuffle.Shuffle:
                    radioStoryGlobalShuffle.Checked = true;
                    break;
            }

            checkStoryGlobalPins.Checked = settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Pins);
            checkStoryGlobalYen.Checked = settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Yen);
            checkStoryGlobalGems.Checked = settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Gems);
            checkStoryGlobalFP.Checked = settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.FP);
            checkStoryGlobalReport.Checked = settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Reports);
            #endregion

            #region Social Network
            switch (settings.Network.CostChoice)
            {
                case SkillCost.Unchanged:
                    radioSkillCostUnchanged.Checked = true;
                    break;
                case SkillCost.Shuffle:
                    radioSkillCostShuffle.Checked = true;
                    break;
                case SkillCost.RandomFixedTotal:
                    radioSkillCostRandom.Checked = true;
                    break;
            }

            switch (settings.Network.RewardsChoice)
            {
                case SkillRewards.Unchanged:
                    radioSkillRewardUnchanged.Checked = true;
                    break;
                case SkillRewards.Shuffle:
                    radioSkillRewardShuffle.Checked = true;
                    break;
                case SkillRewards.RandomSameType:
                    radioSkillRewardRandomS.Checked = true;
                    break;
                case SkillRewards.RandomCompletely:
                    radioSkillRewardRandomC.Checked = true;
                    break;
            }

            switch (settings.Network.ShuffleChoice)
            {
                case SkillShuffle.Unchanged:
                    radioSkillShuffleUnchanged.Checked = true;
                    break;
                case SkillShuffle.Shuffle:
                    radioSkillShuffleShuffle.Checked = true;
                    break;
            }
            #endregion
        }
        #endregion

        #region Form Enabling/Disabling Interactions
        private void SetItemsAffectedDifficultiesEnabled(bool value)
        {
            checkItemsEasy.Enabled = value;
            checkItemsNormal.Enabled = value;
            checkItemsHard.Enabled = value;
            checkItemsUltimate.Enabled = value;
        }

        private void SetItemsLimitedEnabled(bool value)
        {
            checkItemsLimited.Enabled = value;
        }

        private void SetChanceAffectedDifficultiesEnabled(bool value)
        {
            checkChanceEasy.Enabled = value;
            checkChanceNormal.Enabled = value;
            checkChanceHard.Enabled = value;
            checkChanceUltimate.Enabled = value;
        }

        private void SetChanceDifficultyWeightsEnabled(bool value)
        {
            numChanceWeightEasy.Enabled = value;
            numChanceWeightNormal.Enabled = value;
            numChanceWeightHard.Enabled = value;
            numChanceWeightUltimate.Enabled = value;
        }

        private void SetChanceMinMaxEnabled(bool value)
        {
            numChanceMin.Enabled = value;
            numChanceMax.Enabled = value;
        }

        private void SetPinAbilityPercentageEnabled(bool value)
        {
            numPinAbility.Enabled = value;
        }

        private void SetPinUberPercentageEnabled(bool value)
        {
            numPinUber.Enabled = value;
        }

        private void SetPinGrowthSpecificEnabled(bool value)
        {
            comboPinGrowth.Enabled = value;
        }

        private void SetPinEvoForceBrandEnabled(bool value)
        {
            checkPinEvoBrand.Enabled = value;
        }

        private void SetPinEvoPercentageEnabled(bool value)
        {
            numPinEvo.Enabled = value;
        }

        private void SetStoryRewardLimitedPinEnabled(bool value)
        {
            checkStoryPinsLimited.Enabled = value;
        }

        private void SetStoryRewardTypesEnabled(bool value)
        {
            checkStoryGlobalPins.Enabled = value;
            checkStoryGlobalYen.Enabled = value;
            checkStoryGlobalGems.Enabled = value;
            checkStoryGlobalFP.Enabled = value;
            checkStoryGlobalReport.Enabled = value;
        }

        private void radioItemsUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetItemsLimitedEnabled(!radioItemsUnchanged.Checked);
            SetItemsAffectedDifficultiesEnabled(!radioItemsUnchanged.Checked);
        }

        private void radioItemsShuffleC_CheckedChanged(object sender, EventArgs e)
        {
            SetItemsLimitedEnabled(!radioItemsShuffleC.Checked);
        }

        private void radioItemsShuffleS_CheckedChanged(object sender, EventArgs e)
        {
            SetItemsLimitedEnabled(!radioItemsShuffleS.Checked);
            SetItemsAffectedDifficultiesEnabled(!radioItemsShuffleS.Checked);
        }

        private void radioItemsRandomA_CheckedChanged(object sender, EventArgs e)
        {
            SetItemsAffectedDifficultiesEnabled(!radioItemsRandomA.Checked);
        }

        private void radioChanceUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetChanceMinMaxEnabled(!radioChanceUnchanged.Checked);
            SetChanceAffectedDifficultiesEnabled(!radioChanceUnchanged.Checked);
            SetChanceDifficultyWeightsEnabled(!radioChanceUnchanged.Checked);
        }

        private void radioChanceRandomC_CheckedChanged(object sender, EventArgs e)
        {
            SetChanceDifficultyWeightsEnabled(!radioChanceRandomC.Checked);
        }

        private void checkChanceEasy_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightEasy.Enabled = checkChanceEasy.Checked && radioChanceRandomW.Checked;
        }

        private void checkChanceNormal_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightNormal.Enabled = checkChanceNormal.Checked && radioChanceRandomW.Checked;
        }

        private void checkChanceHard_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightHard.Enabled = checkChanceHard.Checked && radioChanceRandomW.Checked;
        }

        private void checkChanceUltimate_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightUltimate.Enabled = checkChanceUltimate.Checked && radioChanceRandomW.Checked;
        }

        private void numChance_ValueChanged(object sender, EventArgs e)
        {
            if (numChanceMin.Value > numChanceMax.Value)
            {
                if (sender == numChanceMin) numChanceMin.Value = numChanceMax.Value;
                else if (sender == numChanceMax) numChanceMax.Value = numChanceMin.Value;
            }
        }

        private void radioPinAbilityUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetPinAbilityPercentageEnabled(false);
        }

        private void radioPinAbilityShuffle_CheckedChanged(object sender, EventArgs e)
        {
            SetPinAbilityPercentageEnabled(false);
        }

        private void radioPinAbilityRandom_CheckedChanged(object sender, EventArgs e)
        {
            SetPinAbilityPercentageEnabled(true);
        }

        private void checkPinUber_CheckedChanged(object sender, EventArgs e)
        {
            SetPinUberPercentageEnabled(checkPinUber.Checked);
        }

        private void radioPinGrowthUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetPinGrowthSpecificEnabled(false);
        }

        private void radioPinGrowthRandomC_CheckedChanged(object sender, EventArgs e)
        {
            SetPinGrowthSpecificEnabled(false);
        }

        private void radioPinGrowthRandomU_CheckedChanged(object sender, EventArgs e)
        {
            SetPinGrowthSpecificEnabled(false);
        }

        private void radioPinGrowthSpecific_CheckedChanged(object sender, EventArgs e)
        {
            SetPinGrowthSpecificEnabled(true);
        }

        private void radioPinEvoUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetPinEvoForceBrandEnabled(false);
            SetPinEvoPercentageEnabled(false);
        }

        private void radioPinEvoRandomE_CheckedChanged(object sender, EventArgs e)
        {
            SetPinEvoForceBrandEnabled(true);
            SetPinEvoPercentageEnabled(false);
        }

        private void radioPinEvoRandomC_CheckedChanged(object sender, EventArgs e)
        {
            SetPinEvoForceBrandEnabled(true);
            SetPinEvoPercentageEnabled(true);
        }

        private void radioStoryPinsUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetStoryRewardLimitedPinEnabled(false);
        }

        private void radioStoryPinsShuffle_CheckedChanged(object sender, EventArgs e)
        {
            SetStoryRewardLimitedPinEnabled(true);
        }

        private void radioStoryPinsRandom_CheckedChanged(object sender, EventArgs e)
        {
            SetStoryRewardLimitedPinEnabled(true);
        }

        private void radioStoryGlobalUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetStoryRewardTypesEnabled(false);
        }

        private void radioStoryGlobalShuffle_CheckedChanged(object sender, EventArgs e)
        {
            SetStoryRewardTypesEnabled(true);
        }
        #endregion

        #region File Handling
        private void UpdateLoadedFilesLabel(Dictionary<string, string> files)
        {
            lbInfoFilesLabel.Text = "";
            lbInfoFiles.Text = "";
            foreach (var file in files)
            {
                lbInfoFilesLabel.Text += string.Format("{0}:\n", FileConstants.Bundles[file.Key].FileName);
                lbInfoFiles.Text += string.Format("{0}\n", file.Value);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            fileDialog.RootFolder = Environment.SpecialFolder.Desktop;
            fileDialog.ShowNewFolderButton = true;
            fileDialog.Description = "Select the folder containing all your bundles...";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> files = new Dictionary<string, string>();
                foreach (var bundleNeeded in FileConstants.Bundles.Values)
                    files.Add(bundleNeeded.Key, Path.Combine(fileDialog.SelectedPath, bundleNeeded.FileName));

                if (randomizationEngine.LoadBundles(files))
                {
                    if (randomizationEngine.AreBundlesLoaded())
                        UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Loaded"));

                    btnSave.Enabled = randomizationEngine.AreBundlesLoaded();
                    btnOpen.Enabled = !randomizationEngine.AreBundlesLoaded();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateSeed(textSeedSeed.Text))
            {
                using FolderBrowserDialog fileDialog = new FolderBrowserDialog();
                fileDialog.RootFolder = Environment.SpecialFolder.Desktop;
                fileDialog.ShowNewFolderButton = true;
                fileDialog.Description = "Select a folder to save your randomized bundles to...";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    int seed = int.Parse(textSeedSeed.Text);
                    randomizationEngine.Randomize(GenerateRandomizationSettings(), seed);
                    UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Randomized"));

                    if (randomizationEngine.Save(fileDialog.SelectedPath, seed))
                    {
                        UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Saved"));
                        MessageBox.Show("Files saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion File Handling

        #region About/Link
        private void linkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(SourceLinks.GetGitHubLink());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }
        #endregion

        #region Settings String and Seed Control
        private void btnSettingStringGenerate_Click(object sender, EventArgs e)
        {
            RandomizationSettings settings = GenerateRandomizationSettings();
            textSettingStringString.Text = settings.GenerateSettingsString();
        }

        private void btnSettingStringImport_Click(object sender, EventArgs e)
        {
            Validator.SettingsStringValidationResult validationResult = Validator.ValidateSettingsString(textSettingStringString.Text);
            switch (validationResult)
            {
                case Validator.SettingsStringValidationResult.Valid:
                    ImportSettings();
                    break;
                case Validator.SettingsStringValidationResult.Empty:
                    MessageBox.Show("The Settings String is empty.", "Settings String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Validator.SettingsStringValidationResult.NotHex:
                    MessageBox.Show("There was an error parsing the settings string. It must be a hexadecimal number.", "Settings String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Validator.SettingsStringValidationResult.InvalidVersion:
                    MessageBox.Show("This settings string is either for a newer version of the randomizer, or for an invalid version. Please use a different settings string.", "Settings String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Validator.SettingsStringValidationResult.WrongVersion:
                    string incorrectSettings = string.Join(", ", GetIncompatibleSettings());
                    if (MessageBox.Show(string.Format("This settings string is for an older version of the randomizer. The values for these settings might be incorrect: {0}. Are you sure you want to import these settings?", incorrectSettings), "Settings String Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ImportSettings();
                    }
                    break;
            }
        }

        private void ImportSettings()
        {
            RandomizationSettings settings = new RandomizationSettings(textSettingStringString.Text);
            try
            {
                ReadSettings(settings);
                MessageBox.Show("Your settings have been imported successfully.", "Settings Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was an error while importing these settings. Please use a different settings string.\nFull Error:\n{0}", ex.Message), "Error in Settings Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetIncompatibleSettings()
        {
            return Validator.GetIncompatibleSettings(textSettingStringString.Text);
        }

        private void GenerateNewSeed()
        {
            Random rand = new Random();
            textSeedSeed.Text = rand.Next().ToString();
        }

        private void textSeedSeed_Click(object sender, EventArgs e)
        {
            GenerateNewSeed();
        }

        private void textSeedSeed_Leave(object sender, EventArgs e)
        {
            if (!Validator.ValidateSeed(textSeedSeed.Text))
            {
                MessageBox.Show(string.Format("There was an error parsing the seed. The seed must be a number between {0} and {1}.", int.MinValue, int.MaxValue), "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSeedSeed.Text = "0";
            }
        }
        #endregion
    }
}
