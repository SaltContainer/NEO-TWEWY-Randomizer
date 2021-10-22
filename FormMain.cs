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
    public partial class FormMain : Form
    {
        private PinImages pinImages;

        public FormMain()
        {
            InitializeComponent();
            pinImages = new PinImages();
            picPin.Image = pinImages.getRandomImage();
        }

        private void linkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(SourceLinks.getGitHubLink());
        }
    }
}
