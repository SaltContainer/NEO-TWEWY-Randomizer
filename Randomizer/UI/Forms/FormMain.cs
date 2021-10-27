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
            InitializeTooltips();
            lbVersion.Text += SourceLinks.GetVersion();
            SetLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Not Loaded"));
            GenerateNewSeed();

            pinImages = new PinImages();
            picPin.Image = pinImages.GetRandomImage();
            randomizationEngine = new RandomizationEngine();
        }

        private void InitializeTooltips()
        {
            ttradioItemsUnchanged.SetToolTip(radioItemsUnchanged, Resources.ttradioItemsUnchanged);
            ttradioItemsShuffleC.SetToolTip(radioItemsShuffleC, Resources.ttradioItemsShuffleC);
            ttradioItemsShuffleS.SetToolTip(radioItemsShuffleS, Resources.ttradioItemsShuffleS);
            ttradioItemsRandomC.SetToolTip(radioItemsRandomC, Resources.ttradioItemsRandomC);
            ttradioItemsRandomA.SetToolTip(radioItemsRandomA, Resources.ttradioItemsRandomA);
            ttcheckItemsLimited.SetToolTip(checkItemsLimited, Resources.ttcheckItemsLimited);
            ttgrpItemsDifficulty.SetToolTip(grpItemsDifficulty, Resources.ttgrpItemsDifficulty);
            ttgrpItemsDifficulty.SetToolTip(checkItemsEasy, Resources.ttgrpItemsDifficulty);
            ttgrpItemsDifficulty.SetToolTip(checkItemsNormal, Resources.ttgrpItemsDifficulty);
            ttgrpItemsDifficulty.SetToolTip(checkItemsHard, Resources.ttgrpItemsDifficulty);
            ttgrpItemsDifficulty.SetToolTip(checkItemsUltimate, Resources.ttgrpItemsDifficulty);

            ttradioChanceUnchanged.SetToolTip(radioChanceUnchanged, Resources.ttradioChanceUnchanged);
            ttradioChanceRandomC.SetToolTip(radioChanceRandomC, Resources.ttradioChanceRandomC);
            ttradioChanceRandomW.SetToolTip(radioChanceRandomW, Resources.ttradioChanceRandomW);
            ttgrpChanceDifficulty.SetToolTip(grpChanceDifficulty, Resources.ttgrpChanceDifficulty);
            ttgrpChanceDifficulty.SetToolTip(checkChanceEasy, Resources.ttgrpChanceDifficulty);
            ttgrpChanceDifficulty.SetToolTip(checkChanceNormal, Resources.ttgrpChanceDifficulty);
            ttgrpChanceDifficulty.SetToolTip(checkChanceHard, Resources.ttgrpChanceDifficulty);
            ttgrpChanceDifficulty.SetToolTip(checkChanceUltimate, Resources.ttgrpChanceDifficulty);
            ttnumChanceMin.SetToolTip(numChanceMin, Resources.ttnumChanceMin);
            ttnumChanceMax.SetToolTip(numChanceMax, Resources.ttnumChanceMax);
            ttnumChanceWeight.SetToolTip(numChanceWeightEasy, Resources.ttnumChanceWeight);
            ttnumChanceWeight.SetToolTip(numChanceWeightNormal, Resources.ttnumChanceWeight);
            ttnumChanceWeight.SetToolTip(numChanceWeightHard, Resources.ttnumChanceWeight);
            ttnumChanceWeight.SetToolTip(numChanceWeightUltimate, Resources.ttnumChanceWeight);
        }

        private void SetLoadedFilesLabel(Dictionary<string, string> files)
        {
            lbInfoFilesLabel.Text = "";
            lbInfoFiles.Text = "";
            foreach (var file in files)
            {
                lbInfoFilesLabel.Text += string.Format("{0}:\n", FileConstants.Bundles[file.Key].FileName);
                lbInfoFiles.Text += string.Format("{0}\n", file.Value);
            }
        }

        private void GenerateNewSeed()
        {
            Random rand = new Random();
            textSeedSeed.Text = rand.Next().ToString();
        }

        private RandomizationSettings GenerateRandomizationSettings()
        {
            RandomizationSettings settings = new RandomizationSettings();

            if (radioItemsUnchanged.Checked) settings.DropType = NoiseDropType.Unchanged;
            else if (radioItemsShuffleC.Checked) settings.DropType = NoiseDropType.ShuffleCompletely;
            else if (radioItemsShuffleS.Checked) settings.DropType = NoiseDropType.ShuffleSets;
            else if (radioItemsRandomC.Checked) settings.DropType = NoiseDropType.RandomCompletely;
            else if (radioItemsRandomA.Checked) settings.DropType = NoiseDropType.RandomAllPins;

            settings.IncludeLimitedPins = checkItemsLimited.Checked;

            if (checkItemsEasy.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Easy);
            if (checkItemsNormal.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Normal);
            if (checkItemsHard.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Hard);
            if (checkItemsUltimate.Checked) settings.NoiseDropTypeDifficulties.Add(Difficulties.Ultimate);

            if (radioChanceUnchanged.Checked) settings.DropRate = NoiseDropRate.Unchanged;
            else if (radioChanceRandomC.Checked) settings.DropRate = NoiseDropRate.RandomCompletely;
            else if (radioChanceRandomW.Checked) settings.DropRate = NoiseDropRate.RandomWeighted;

            settings.MinimumDropRate = numChanceMin.Value;
            settings.MaximumDropRate = numChanceMax.Value;

            if (checkChanceEasy.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Easy);
            if (checkChanceNormal.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Normal);
            if (checkChanceHard.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Hard);
            if (checkChanceUltimate.Checked) settings.NoiseDropRateDifficulties.Add(Difficulties.Ultimate);

            settings.NoiseDropRateWeights[0] = (uint) numChanceWeightEasy.Value;
            settings.NoiseDropRateWeights[1] = (uint) numChanceWeightNormal.Value;
            settings.NoiseDropRateWeights[2] = (uint) numChanceWeightHard.Value;
            settings.NoiseDropRateWeights[3] = (uint) numChanceWeightUltimate.Value;

            return settings;
        }

        private void ReadSettings(RandomizationSettings settings)
        {
            switch (settings.DropType)
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

            checkItemsLimited.Checked = settings.IncludeLimitedPins;

            checkItemsEasy.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Easy);
            checkItemsNormal.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Normal);
            checkItemsHard.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Hard);
            checkItemsUltimate.Checked = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate);

            switch (settings.DropRate)
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

            numChanceMin.Value = settings.MinimumDropRate;
            numChanceMax.Value = settings.MaximumDropRate;

            checkChanceEasy.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Easy);
            checkChanceNormal.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Normal);
            checkChanceHard.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Hard);
            checkChanceUltimate.Checked = settings.NoiseDropRateDifficulties.Contains(Difficulties.Ultimate);

            numChanceWeightEasy.Value = settings.NoiseDropRateWeights[0];
            numChanceWeightNormal.Value = settings.NoiseDropRateWeights[1];
            numChanceWeightHard.Value = settings.NoiseDropRateWeights[2];
            numChanceWeightUltimate.Value = settings.NoiseDropRateWeights[3];
        }

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

        private void linkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(SourceLinks.GetGitHubLink());
        }

        private void radioItemsUnchanged_CheckedChanged(object sender, EventArgs e)
        {
            SetItemsLimitedEnabled(!radioItemsUnchanged.Checked);
            SetItemsAffectedDifficultiesEnabled(!radioItemsUnchanged.Checked);
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> files = new Dictionary<string, string>();
            foreach (var bundleNeeded in FileConstants.Bundles.Values)
            {
                string fileName = "../4017d8fc-orig.unity3d"; //TODO: Change to openfile dialog
                files.Add(bundleNeeded.Key, fileName);
            }
            bool result = randomizationEngine.LoadFiles(files);
            if (result)
            {
                SetLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Loaded"));
                btnSave.Enabled = randomizationEngine.AreFilesLoaded();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateSeed(textSeedSeed.Text))
            {
                int seed = int.Parse(textSeedSeed.Text);
                randomizationEngine.Randomize(null, seed);
                string path = ".."; //TODO: Change to openfile dialog
                bool result = randomizationEngine.Save(path);
                if (result)
                {
                    SetLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Saved"));
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

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
                    RandomizationSettings settings = new RandomizationSettings(textSettingStringString.Text);
                    ReadSettings(settings);
                    MessageBox.Show("Your settings have been imported successfully.", "Settings Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Validator.SettingsStringValidationResult.Empty:
                    MessageBox.Show("The Settings String is empty.", "Settings String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Validator.SettingsStringValidationResult.NotHex:
                    MessageBox.Show("There was an error parsing the settings string. It must be a hexadecimal number.", "Settings String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Validator.SettingsStringValidationResult.WrongVersion:
                    MessageBox.Show("This settings string is for a different version of the randomizer. Please manually select your settings and generate a new one.", "Settings String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
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
    }
}
