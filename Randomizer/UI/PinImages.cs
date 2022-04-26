using NEO_TWEWY_Randomizer.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    class PinImages
    {
        private Random rand;

        public PinImages()
        {
            rand = new Random();
        }

        public Image GetRandomImage()
        {
            int index = rand.Next(FileConstants.ItemNames.RandoPinImages.Count());
            Bitmap pin = (Bitmap) Resources.ResourceManager.GetObject(FileConstants.ItemNames.RandoPinImages[index].Name);
            return pin;
        }
    }
}
