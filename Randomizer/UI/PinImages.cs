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
            ResourceSet resourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            var pins = resourceSet.Cast<DictionaryEntry>().Where(x => x.Value.GetType() == typeof(Bitmap));
            Bitmap selectedPin = (Bitmap)pins.ElementAt(rand.Next(pins.Count())).Value;
            return selectedPin;
        }
    }
}
