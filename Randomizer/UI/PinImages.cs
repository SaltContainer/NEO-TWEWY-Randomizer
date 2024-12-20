﻿using NEO_TWEWY_Randomizer.Properties;
using System;
using System.Drawing;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class PinImages
    {
        private Random rand;

        public PinImages()
        {
            rand = new Random();
        }

        public Image GetRandomImage()
        {
            int index = rand.Next(FileConstants.IDNames.RandoPinImages.Count());
            Bitmap pin = (Bitmap) Resources.ResourceManager.GetObject(FileConstants.IDNames.RandoPinImages[index].Name);
            return pin;
        }
    }
}
