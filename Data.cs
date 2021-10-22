using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class Data
    {
        private byte[] data;

        public Data(string fileName)
        {
            data = File.ReadAllBytes(fileName);
        }

        public void SetByte(long address, byte value)
        {
            data[address] = value;
        }

        public void SetNumericalValue(long address, int value)
        {
            string sValue = value.ToString();
            for (int i = 0; i < sValue.Length; i++)
            {
                SetByte(address + i, (byte)sValue[i]);
            }
        }

        public byte[] GetData()
        {
            return data;
        }
    }
}
