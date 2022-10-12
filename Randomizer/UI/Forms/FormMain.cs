using NEO_TWEWY_Randomizer.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        }
        #endregion

        #region Create Settings from Form
        private RandomizationSettings GenerateRandomizationSettings()
        {
            RandomizationSettings settings = new RandomizationSettings();

            #region Noise Drops
            if (radioItemsUnchanged.Checked) settings.NoiseDrops.NoiseDropTypeChoice = NoiseDropType.Unchanged;
            else if (radioItemsShuffleC.Checked) settings.NoiseDrops.NoiseDropTypeChoice = NoiseDropType.ShuffleCompletely;
            else if (radioItemsShuffleS.Checked) settings.NoiseDrops.NoiseDropTypeChoice = NoiseDropType.ShuffleSets;
            else if (radioItemsRandomC.Checked) settings.NoiseDrops.NoiseDropTypeChoice = NoiseDropType.RandomCompletely;
            else if (radioItemsRandomA.Checked) settings.NoiseDrops.NoiseDropTypeChoice = NoiseDropType.RandomAllPins;

            settings.NoiseDrops.NoiseIncludeLimitedPins = checkItemsLimited.Checked;

            if (checkItemsEasy.Checked) settings.NoiseDrops.NoiseDropTypeDifficulties.Add(Difficulties.Easy);
            if (checkItemsNormal.Checked) settings.NoiseDrops.NoiseDropTypeDifficulties.Add(Difficulties.Normal);
            if (checkItemsHard.Checked) settings.NoiseDrops.NoiseDropTypeDifficulties.Add(Difficulties.Hard);
            if (checkItemsUltimate.Checked) settings.NoiseDrops.NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

            if (radioChanceUnchanged.Checked) settings.NoiseDrops.NoiseDropRateChoice = NoiseDropRate.Unchanged;
            else if (radioChanceRandomC.Checked) settings.NoiseDrops.NoiseDropRateChoice = NoiseDropRate.RandomCompletely;
            else if (radioChanceRandomW.Checked) settings.NoiseDrops.NoiseDropRateChoice = NoiseDropRate.RandomWeighted;

            settings.NoiseDrops.NoiseMinimumDropRate = numChanceMin.Value;
            settings.NoiseDrops.NoiseMaximumDropRate = numChanceMax.Value;

            if (checkChanceEasy.Checked) settings.NoiseDrops.NoiseDropRateDifficulties.Add(Difficulties.Easy);
            if (checkChanceNormal.Checked) settings.NoiseDrops.NoiseDropRateDifficulties.Add(Difficulties.Normal);
            if (checkChanceHard.Checked) settings.NoiseDrops.NoiseDropRateDifficulties.Add(Difficulties.Hard);
            if (checkChanceUltimate.Checked) settings.NoiseDrops.NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

            settings.NoiseDrops.NoiseDropRateWeights[0] = (uint) numChanceWeightEasy.Value;
            settings.NoiseDrops.NoiseDropRateWeights[1] = (uint) numChanceWeightNormal.Value;
            settings.NoiseDrops.NoiseDropRateWeights[2] = (uint) numChanceWeightHard.Value;
            settings.NoiseDrops.NoiseDropRateWeights[3] = (uint) numChanceWeightUltimate.Value;
            #endregion

            #region Pin Stats
            settings.PinStats.PinPower = checkPinPower.Checked;
            settings.PinStats.PinPowerScaling = checkPinPowerScaling.Checked;
            settings.PinStats.PinLimit = checkPinLimit.Checked;
            settings.PinStats.PinLimitScaling = checkPinLimitScaling.Checked;
            settings.PinStats.PinReboot = checkPinReboot.Checked;
            settings.PinStats.PinRebootScaling = checkPinRebootScaling.Checked;
            settings.PinStats.PinBoot = checkPinBoot.Checked;
            settings.PinStats.PinBootScaling = checkPinBootScaling.Checked;
            settings.PinStats.PinRecover = checkPinRecover.Checked;
            settings.PinStats.PinRecoverScaling = checkPinRecoverScaling.Checked;
            settings.PinStats.PinCharge = checkPinCharge.Checked;
            settings.PinStats.PinSell = checkPinSell.Checked;
            settings.PinStats.PinSellScaling = checkPinSellScaling.Checked;
            settings.PinStats.PinAffinity = checkPinAffinity.Checked;
            settings.PinStats.PinMaxLevel = checkPinMaxLevel.Checked;

            if (radioPinBrandUnchanged.Checked) settings.PinStats.PinBrandChoice = PinBrand.Unchanged;
            else if (radioPinBrandShuffle.Checked) settings.PinStats.PinBrandChoice = PinBrand.Shuffle;
            else if (radioPinBrandRandomC.Checked) settings.PinStats.PinBrandChoice = PinBrand.RandomCompletely;
            else if (radioPinBrandRandomU.Checked) settings.PinStats.PinBrandChoice = PinBrand.RandomUniform;

            settings.PinStats.PinUber = checkPinUber.Checked;
            settings.PinStats.PinUberPercentage = (uint) numPinUber.Value;

            if (radioPinAbilityUnchanged.Checked) settings.PinStats.PinAbilityChoice = PinAbility.Unchanged;
            else if (radioPinAbilityShuffle.Checked) settings.PinStats.PinAbilityChoice = PinAbility.Shuffle;
            else if (radioPinAbilityRandom.Checked) settings.PinStats.PinAbilityChoice = PinAbility.RandomCompletely;
            settings.PinStats.PinAbilityPercentage = (uint) numPinAbility.Value;

            if (radioPinGrowthUnchanged.Checked) settings.PinStats.PinGrowthChoice = PinGrowthRandomization.Unchanged;
            else if (radioPinGrowthRandomC.Checked) settings.PinStats.PinGrowthChoice = PinGrowthRandomization.RandomCompletely;
            else if (radioPinGrowthRandomU.Checked) settings.PinStats.PinGrowthChoice = PinGrowthRandomization.RandomUniform;
            else if (radioPinGrowthSpecific.Checked) settings.PinStats.PinGrowthChoice = PinGrowthRandomization.Specific;
            settings.PinStats.PinGrowthSpecific = (PinGrowth) ((NameAssociation)comboPinGrowth.SelectedItem).Id;

            if (radioPinEvoUnchanged.Checked) settings.PinStats.PinEvolutionChoice = PinEvolution.Unchanged;
            else if (radioPinEvoRandomE.Checked) settings.PinStats.PinEvolutionChoice = PinEvolution.RandomExisting;
            else if (radioPinEvoRandomC.Checked) settings.PinStats.PinEvolutionChoice = PinEvolution.RandomCompletely;
            settings.PinStats.PinEvoForceBrand = checkPinEvoBrand.Checked;
            settings.PinStats.PinRemoveCharaEvos = checkPinEvoChara.Checked;
            settings.PinStats.PinEvoPercentage = (uint)numPinEvo.Value;
            #endregion

            #region Story Rewards
            if (radioStoryPinsUnchanged.Checked) settings.StoryRewards.StoryPinChoice = StoryPin.Unchanged;
            else if (radioStoryPinsShuffle.Checked) settings.StoryRewards.StoryPinChoice = StoryPin.Shuffle;
            else if (radioStoryPinsRandom.Checked) settings.StoryRewards.StoryPinChoice = StoryPin.Random;

            settings.StoryRewards.IncludeLimitedPins = checkStoryPinsLimited.Checked;

            if (radioStoryYenUnchanged.Checked) settings.StoryRewards.StoryYenChoice = StoryYen.Unchanged;
            else if (radioStoryYenShuffle.Checked) settings.StoryRewards.StoryYenChoice = StoryYen.Shuffle;
            else if (radioStoryYenRandom.Checked) settings.StoryRewards.StoryYenChoice = StoryYen.Random;

            if (radioStoryGemsUnchanged.Checked) settings.StoryRewards.StoryGemChoice = StoryGem.Unchanged;
            else if (radioStoryGemsShuffle.Checked) settings.StoryRewards.StoryGemChoice = StoryGem.Shuffle;
            else if (radioStoryGemsRandom.Checked) settings.StoryRewards.StoryGemChoice = StoryGem.Random;

            if (radioStoryFPUnchanged.Checked) settings.StoryRewards.StoryFPChoice = StoryFP.Unchanged;
            else if (radioStoryFPShuffle.Checked) settings.StoryRewards.StoryFPChoice = StoryFP.Shuffle;
            else if (radioStoryFPRandom.Checked) settings.StoryRewards.StoryFPChoice = StoryFP.RandomFixedTotal;

            if (radioStoryReportUnchanged.Checked) settings.StoryRewards.StoryReportChoice = StoryReport.Unchanged;
            else if (radioStoryReportShuffle.Checked) settings.StoryRewards.StoryReportChoice = StoryReport.Shuffle;

            if (radioStoryGlobalUnchanged.Checked) settings.StoryRewards.StoryGlobalShuffleChoice = StoryGlobalShuffle.Unchanged;
            else if (radioStoryGlobalShuffle.Checked) settings.StoryRewards.StoryGlobalShuffleChoice = StoryGlobalShuffle.Shuffle;

            if (checkStoryGlobalPins.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Pins);
            if (checkStoryGlobalYen.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Yen);
            if (checkStoryGlobalGems.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Gems);
            if (checkStoryGlobalFP.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.FP);
            if (checkStoryGlobalReport.Checked) settings.StoryRewards.ShuffledStoryRewards.Add(StoryRewards.Reports);
            #endregion

            return settings;
        }
        #endregion

        #region Adjust Form from Settings
        private void ReadSettings(RandomizationSettings settings)
        {
            #region Noise Drops
            switch (settings.NoiseDrops.NoiseDropTypeChoice)
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

            checkItemsLimited.Checked = settings.NoiseDrops.NoiseIncludeLimitedPins;

            checkItemsEasy.Checked = settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Easy);
            checkItemsNormal.Checked = settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Normal);
            checkItemsHard.Checked = settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Hard);
            checkItemsUltimate.Checked = settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate);

            switch (settings.NoiseDrops.NoiseDropRateChoice)
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

            numChanceMin.Value = settings.NoiseDrops.NoiseMinimumDropRate;
            numChanceMax.Value = settings.NoiseDrops.NoiseMaximumDropRate;

            checkChanceEasy.Checked = settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Easy);
            checkChanceNormal.Checked = settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Normal);
            checkChanceHard.Checked = settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Hard);
            checkChanceUltimate.Checked = settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Ultimate);

            numChanceWeightEasy.Value = settings.NoiseDrops.NoiseDropRateWeights[0];
            numChanceWeightNormal.Value = settings.NoiseDrops.NoiseDropRateWeights[1];
            numChanceWeightHard.Value = settings.NoiseDrops.NoiseDropRateWeights[2];
            numChanceWeightUltimate.Value = settings.NoiseDrops.NoiseDropRateWeights[3];
            #endregion

            #region Pin Stats
            checkPinPower.Checked = settings.PinStats.PinPower;
            checkPinPowerScaling.Checked = settings.PinStats.PinPowerScaling;
            checkPinLimit.Checked = settings.PinStats.PinLimit;
            checkPinLimitScaling.Checked = settings.PinStats.PinLimitScaling;
            checkPinReboot.Checked = settings.PinStats.PinReboot;
            checkPinRebootScaling.Checked = settings.PinStats.PinRebootScaling;
            checkPinBoot.Checked = settings.PinStats.PinBoot;
            checkPinBootScaling.Checked = settings.PinStats.PinBootScaling;
            checkPinRecover.Checked = settings.PinStats.PinRecover;
            checkPinRecoverScaling.Checked = settings.PinStats.PinRecoverScaling;
            checkPinCharge.Checked = settings.PinStats.PinCharge;
            checkPinSell.Checked = settings.PinStats.PinSell;
            checkPinSellScaling.Checked = settings.PinStats.PinSellScaling;
            checkPinAffinity.Checked = settings.PinStats.PinAffinity;
            checkPinMaxLevel.Checked = settings.PinStats.PinMaxLevel;

            switch (settings.PinStats.PinBrandChoice)
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

            checkPinUber.Checked = settings.PinStats.PinUber;
            numPinUber.Value = settings.PinStats.PinUberPercentage;

            switch (settings.PinStats.PinAbilityChoice)
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
            numPinAbility.Value = settings.PinStats.PinAbilityPercentage;

            switch (settings.PinStats.PinGrowthChoice)
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
            comboPinGrowth.SelectedItem = FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int)settings.PinStats.PinGrowthSpecific).First();

            switch (settings.PinStats.PinEvolutionChoice)
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
            checkPinEvoBrand.Checked = settings.PinStats.PinEvoForceBrand;
            checkPinEvoChara.Checked = settings.PinStats.PinRemoveCharaEvos;
            numPinEvo.Value = settings.PinStats.PinEvoPercentage;
            #endregion

            #region Story Rewards
            switch (settings.StoryRewards.StoryPinChoice)
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

            switch (settings.StoryRewards.StoryYenChoice)
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

            switch (settings.StoryRewards.StoryGemChoice)
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

            switch (settings.StoryRewards.StoryFPChoice)
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

            switch (settings.StoryRewards.StoryReportChoice)
            {
                case StoryReport.Unchanged:
                    radioStoryReportUnchanged.Checked = true;
                    break;
                case StoryReport.Shuffle:
                    radioStoryReportShuffle.Checked = true;
                    break;
            }

            switch (settings.StoryRewards.StoryGlobalShuffleChoice)
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
            Dictionary<string, string> files = new Dictionary<string, string>();
            foreach (var bundleNeeded in FileConstants.Bundles.Values)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "unity3d files (*.unity3d)|*.unity3d|All files (*.*)|*.*";
                fileDialog.FilterIndex = 0;
                fileDialog.RestoreDirectory = true;
                fileDialog.Title = string.Format("Select the {0} bundle file...", bundleNeeded.FileName);

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    files.Add(bundleNeeded.Key, fileDialog.FileName);
            }
            bool result = randomizationEngine.LoadFiles(files);
            if (result)
            {
                if (randomizationEngine.AreFilesLoaded())
                    UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Loaded"));
                btnSave.Enabled = randomizationEngine.AreFilesLoaded();
                btnOpen.Enabled = !randomizationEngine.AreFilesLoaded();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateSeed(textSeedSeed.Text))
            {
                FolderBrowserDialog fileDialog = new FolderBrowserDialog();
                fileDialog.RootFolder = Environment.SpecialFolder.Desktop;
                fileDialog.ShowNewFolderButton = true;
                fileDialog.Description = "Select a folder to save your randomized bundles to...";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    int seed = int.Parse(textSeedSeed.Text);
                    randomizationEngine.Randomize(GenerateRandomizationSettings(), seed);
                    UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Randomized"));
                    bool result = randomizationEngine.Save(fileDialog.SelectedPath, seed);
                    if (result)
                    {
                        UpdateLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Saved"));
                        MessageBox.Show("Files saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("An error occured while trying to select a folder. Please retry.", "Folder error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
