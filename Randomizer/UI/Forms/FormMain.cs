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
            randomizationEngine.LoadFiles(files);
            SetLoadedFilesLabel(FileConstants.Bundles.ToDictionary(kvp => kvp.Key, kvp => "Loaded"));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            randomizationEngine.Randomize(null);

            foreach (var bundleNeeded in FileConstants.Bundles.Values)
            {
                string path = ".."; //TODO: Change to openfile dialog
                randomizationEngine.Save(path + "/" + bundleNeeded.FileName);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

        private void btnSettingStringGenerate_Click(object sender, EventArgs e)
        {

        }

        private void btnSettingStringImport_Click(object sender, EventArgs e)
        {

        }

        private void textSeedSeed_Click(object sender, EventArgs e)
        {
            GenerateNewSeed();
        }
    }
}
