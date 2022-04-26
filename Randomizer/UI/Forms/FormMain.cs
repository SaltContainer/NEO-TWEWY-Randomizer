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

            if (radioItemsUnchanged.Checked) settings.NoiseDropTypeChoice = NoiseDropType.Unchanged;
            else if (radioItemsShuffleC.Checked) settings.NoiseDropTypeChoice = NoiseDropType.ShuffleCompletely;
            else if (radioItemsShuffleS.Checked) settings.NoiseDropTypeChoice = NoiseDropType.ShuffleSets;
            else if (radioItemsRandomC.Checked) settings.NoiseDropTypeChoice = NoiseDropType.RandomCompletely;
            else if (radioItemsRandomA.Checked) settings.NoiseDropTypeChoice = NoiseDropType.RandomAllPins;

            settings.NoiseIncludeLimitedPins = checkItemsLimited.Checked;

            if (checkItemsEasy.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Easy);
            if (checkItemsNormal.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Normal);
            if (checkItemsHard.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Hard);
            if (checkItemsUltimate.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

            if (radioChanceUnchanged.Checked) settings.NoiseDropRateChoice = NoiseDropRate.Unchanged;
            else if (radioChanceRandomC.Checked) settings.NoiseDropRateChoice = NoiseDropRate.RandomCompletely;
            else if (radioChanceRandomW.Checked) settings.NoiseDropRateChoice = NoiseDropRate.RandomWeighted;

            settings.NoiseMinimumDropRate = numChanceMin.Value;
            settings.NoiseMaximumDropRate = numChanceMax.Value;

            if (checkChanceEasy.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Easy);
            if (checkChanceNormal.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Normal);
            if (checkChanceHard.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Hard);
            if (checkChanceUltimate.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

            settings.NoiseDropRateWeights[0] = (uint) numChanceWeightEasy.Value;
            settings.NoiseDropRateWeights[1] = (uint) numChanceWeightNormal.Value;
            settings.NoiseDropRateWeights[2] = (uint) numChanceWeightHard.Value;
            settings.NoiseDropRateWeights[3] = (uint) numChanceWeightUltimate.Value;

            settings.PinPower = checkPinPower.Checked;
            settings.PinPowerScaling = checkPinPowerScaling.Checked;
            settings.PinLimit = checkPinLimit.Checked;
            settings.PinLimitScaling = checkPinLimitScaling.Checked;
            settings.PinReboot = checkPinReboot.Checked;
            settings.PinRebootScaling = checkPinRebootScaling.Checked;
            settings.PinBoot = checkPinBoot.Checked;
            settings.PinBootScaling = checkPinBootScaling.Checked;
            settings.PinRecover = checkPinRecover.Checked;
            settings.PinRecoverScaling = checkPinRecoverScaling.Checked;
            settings.PinCharge = checkPinCharge.Checked;
            settings.PinSell = checkPinSell.Checked;
            settings.PinSellScaling = checkPinSellScaling.Checked;
            settings.PinAffinity = checkPinAffinity.Checked;
            settings.PinMaxLevel = checkPinMaxLevel.Checked;

            if (radioPinBrandUnchanged.Checked) settings.PinBrandChoice = PinBrand.Unchanged;
            else if (radioPinBrandShuffle.Checked) settings.PinBrandChoice = PinBrand.Shuffle;
            else if (radioPinBrandRandomC.Checked) settings.PinBrandChoice = PinBrand.RandomCompletely;
            else if (radioPinBrandRandomU.Checked) settings.PinBrandChoice = PinBrand.RandomUniform;

            settings.PinUber = checkPinUber.Checked;
            settings.PinUberPercentage = (uint) numPinUber.Value;

            if (radioPinAbilityUnchanged.Checked) settings.PinAbilityChoice = PinAbility.Unchanged;
            else if (radioPinAbilityShuffle.Checked) settings.PinAbilityChoice = PinAbility.Shuffle;
            else if (radioPinAbilityRandom.Checked) settings.PinAbilityChoice = PinAbility.RandomCompletely;
            settings.PinAbilityPercentage = (uint) numPinAbility.Value;

            if (radioPinGrowthUnchanged.Checked) settings.PinGrowthChoice = PinGrowthRandomization.Unchanged;
            else if (radioPinGrowthRandomC.Checked) settings.PinGrowthChoice = PinGrowthRandomization.RandomCompletely;
            else if (radioPinGrowthRandomU.Checked) settings.PinGrowthChoice = PinGrowthRandomization.RandomUniform;
            else if (radioPinGrowthSpecific.Checked) settings.PinGrowthChoice = PinGrowthRandomization.Specific;
            settings.PinGrowthSpecific = (PinGrowth) ((NameAssociation)comboPinGrowth.SelectedItem).Id;

            if (radioPinEvoUnchanged.Checked) settings.PinEvolutionChoice = PinEvolution.Unchanged;
            else if (radioPinEvoRandomE.Checked) settings.PinEvolutionChoice = PinEvolution.RandomExisting;
            else if (radioPinEvoRandomC.Checked) settings.PinEvolutionChoice = PinEvolution.RandomCompletely;
            settings.PinEvoForceBrand = checkPinEvoBrand.Checked;
            settings.PinRemoveCharaEvos = checkPinEvoChara.Checked;
            settings.PinEvoPercentage = (uint)numPinEvo.Value;

            return settings;
        }
        #endregion

        #region Adjust Form from Settings
        private void ReadSettings(RandomizationSettings settings)
        {
            switch (settings.NoiseDropTypeChoice)
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

            checkItemsLimited.Checked = settings.NoiseIncludeLimitedPins;

            checkItemsEasy.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Easy);
            checkItemsNormal.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Normal);
            checkItemsHard.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Hard);
            checkItemsUltimate.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate);

            switch (settings.NoiseDropRateChoice)
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

            numChanceMin.Value = settings.NoiseMinimumDropRate;
            numChanceMax.Value = settings.NoiseMaximumDropRate;

            checkChanceEasy.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Easy);
            checkChanceNormal.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Normal);
            checkChanceHard.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Hard);
            checkChanceUltimate.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Ultimate);

            numChanceWeightEasy.Value = settings.NoiseDropRateWeights[0];
            numChanceWeightNormal.Value = settings.NoiseDropRateWeights[1];
            numChanceWeightHard.Value = settings.NoiseDropRateWeights[2];
            numChanceWeightUltimate.Value = settings.NoiseDropRateWeights[3];

            checkPinPower.Checked = settings.PinPower;
            checkPinPowerScaling.Checked = settings.PinPowerScaling;
            checkPinLimit.Checked = settings.PinLimit;
            checkPinLimitScaling.Checked = settings.PinLimitScaling;
            checkPinReboot.Checked = settings.PinReboot;
            checkPinRebootScaling.Checked = settings.PinRebootScaling;
            checkPinBoot.Checked = settings.PinBoot;
            checkPinBootScaling.Checked = settings.PinBootScaling;
            checkPinRecover.Checked = settings.PinRecover;
            checkPinRecoverScaling.Checked = settings.PinRecoverScaling;
            checkPinCharge.Checked = settings.PinCharge;
            checkPinSell.Checked = settings.PinSell;
            checkPinSellScaling.Checked = settings.PinSellScaling;
            checkPinAffinity.Checked = settings.PinAffinity;
            checkPinMaxLevel.Checked = settings.PinMaxLevel;

            switch (settings.PinBrandChoice)
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

            checkPinUber.Checked = settings.PinUber;
            numPinUber.Value = settings.PinUberPercentage;

            switch (settings.PinAbilityChoice)
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
            numPinAbility.Value = settings.PinAbilityPercentage;

            switch (settings.PinGrowthChoice)
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
            comboPinGrowth.SelectedItem = FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int)settings.PinGrowthSpecific).First();

            switch (settings.PinEvolutionChoice)
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
            checkPinEvoBrand.Checked = settings.PinEvoForceBrand;
            checkPinEvoChara.Checked = settings.PinRemoveCharaEvos;
            numPinEvo.Value = settings.PinEvoPercentage;
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
            numChanceWeightEasy.Enabled = checkChanceEasy.Checked;
        }

        private void checkChanceNormal_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightNormal.Enabled = checkChanceNormal.Checked;
        }

        private void checkChanceHard_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightHard.Enabled = checkChanceHard.Checked;
        }

        private void checkChanceUltimate_CheckedChanged(object sender, EventArgs e)
        {
            numChanceWeightUltimate.Enabled = checkChanceUltimate.Checked;
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
