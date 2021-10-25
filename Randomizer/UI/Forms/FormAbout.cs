using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            lbVersion.Text += SourceLinks.GetVersion();
        }

        private void linkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(SourceLinks.GetGitHubLink());
        }
    }
}
