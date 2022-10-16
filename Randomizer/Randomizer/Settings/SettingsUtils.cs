using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class SettingsUtils
    {
        private static uint MakeBitMask(int left, int right)
        {
            return (uint)((1 << left) - 1 - ((1 << right) - 1));
        }

        public static string AppendToSettingsString(string hexString, uint bitsToAppend, int position, int amountOfBits)
        {
            int stringPos = position / 4;
            int bitOfPos = position % 4;
            int actualPos = hexString.Length - 1 - stringPos;

            uint bitsLeft = bitsToAppend;

            string editedString = hexString;

            int lastNum = 0;
            if (actualPos > -1)
            {
                lastNum = int.Parse(hexString.Substring(actualPos, 1), System.Globalization.NumberStyles.HexNumber);
                editedString = hexString.Substring(actualPos + 1);
            }
            lastNum &= (int)MakeBitMask(bitOfPos, 0);
            lastNum += (int)(MakeBitMask(4, bitOfPos) & (bitsToAppend << bitOfPos));

            editedString = lastNum.ToString("X") + editedString;

            int amountLeft = amountOfBits - (4 - bitOfPos);
            if (amountLeft > 0) bitsLeft = bitsToAppend >> (4 - bitOfPos);

            for (int i = amountLeft; i > 0; i -= 4)
            {
                uint newNum = 0b1111 & bitsLeft;
                bitsLeft >>= 4;
                editedString = newNum.ToString("X") + editedString;
            }

            return editedString;
        }

        public static string AppendToSettingsString(string hexString, SettingsStringVersion versionInfo, string setting, uint value)
        {
            int position = versionInfo.Values[setting].Offset;
            int amount = versionInfo.Values[setting].Size;

            return AppendToSettingsString(hexString, value, position, amount);
        }

        public static uint GetBitsFromSettingsString(string hexString, int position, int amount)
        {
            int leftPos = (position + amount) / 4;
            int bitOfLeftPos = (position + amount) % 4;
            int rightPos = position / 4;
            int bitOfRightPos = position % 4;

            int actualLeftPos = hexString.Length - 1 - leftPos;
            int actualRightPos = hexString.Length - 1 - rightPos;
            int lengthNeeded = actualRightPos - actualLeftPos + 1;

            uint baseNumber = uint.Parse(hexString.Substring(actualLeftPos, lengthNeeded), System.Globalization.NumberStyles.HexNumber);

            uint mask = MakeBitMask((lengthNeeded - 1) * 4 + bitOfLeftPos, bitOfRightPos);

            return (baseNumber & mask) >> bitOfRightPos;
        }

        public static uint GetBitsFromSettingsString(string hexString, SettingsStringVersion versionInfo, string setting)
        {
            int position = versionInfo.Values[setting].Offset;
            int amount = versionInfo.Values[setting].Size;

            return GetBitsFromSettingsString(hexString, position, amount);
        }
    }
}
