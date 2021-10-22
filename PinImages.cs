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
        private ImageList imageList;

        public PinImages()
        {
            rand = new Random();
            imageList = new ImageList();
            imageList.ImageSize = new Size(128, 128);
            imageList.TransparentColor = SystemColors.Control;
            readImages();
        }

        public void readImages()
        {
            ResourceSet images = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            foreach (DictionaryEntry image in images)
            {
                if (image.Value.GetType() == typeof(Bitmap))
                {
                    imageList.Images.Add((string)image.Key, (Bitmap)image.Value);
                }
            }
        }

        public Image getRandomImage()
        {
            return imageList.Images[rand.Next(imageList.Images.Count)];
        }
    }
}
