using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public static class Unity3dCrypto
    {
        public static byte[] Unity3dMagic = new byte[] { 0xC4, 0x88, 0x6E, 0x25, 0xCB, 0xD4, 0x86, 0x1D, 0x2D, 0xE1, 0x04, 0x63, 0x18, 0xBE, 0x23, 0xCE, 0x7F, 0x29, 0x36, 0x18, 0xF5, 0x7A, 0x65, 0xA2, 0xB7, 0x87, 0x4F, 0x2A, 0x9D, 0xC6, 0xF4, 0xCD };
        public static byte[] UnityFs = new byte[] { 0x55, 0x6E, 0x69, 0x74, 0x79, 0x46, 0x53 };
        public static byte[] Unity3dKey = new byte[] { 0x6D, 0x6B, 0x3A, 0x39, 0x74, 0x7A, 0x78, 0x57, 0x52, 0x46, 0x7D, 0x4A, 0x70, 0x7A, 0x77, 0x32 };
        public static byte[] Unity3dIv = new byte[] { 0x4E, 0x46, 0x58, 0x6A, 0x65, 0x71, 0x28, 0x6E, 0x3A, 0x33, 0x67, 0x27, 0x38, 0x26, 0x3D, 0x3B };

        public static Dictionary<string, byte[]> ProcessFiles(string[] fileNames, out List<string> errorFiles)
        {
            errorFiles = new List<string>();
            Dictionary<string, byte[]> output = new Dictionary<string, byte[]>();

            foreach (string fileName in fileNames)
            {
                if (TryProcessFile(fileName, out byte[] result))
                    output.Add(fileName, result);
                else
                    errorFiles.Add(fileName);
            }

            return output;
        }

        public static bool TryProcessFile(string fileName, out byte[] result)
        {
            Rijndael crypto = new Rijndael(Unity3dKey, Unity3dIv);

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                using (BinaryReader stream = new BinaryReader(fileStream))
                {
                    byte[] header = stream.ReadBytes(7);
                    byte[] magic = stream.ReadBytes(25);

                    if (TryEncryptFile(stream, crypto, header, magic, out result))
                        return true;
                    else if (TryDecryptFile(stream, crypto, header, magic, out result))
                        return true;
                    else
                        return false;
                }
            }
        }

        public static bool TryEncryptFile(string fileName, out byte[] result)
        {
            Rijndael crypto = new Rijndael(Unity3dKey, Unity3dIv);

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                using (BinaryReader stream = new BinaryReader(fileStream))
                {
                    byte[] header = stream.ReadBytes(7);
                    byte[] magic = stream.ReadBytes(25);

                    return TryEncryptFile(stream, crypto, header, magic, out result);
                }
            }
        }

        public static bool TryEncryptFile(byte[] data, out byte[] result)
        {
            Rijndael crypto = new Rijndael(Unity3dKey, Unity3dIv);

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (BinaryReader stream = new BinaryReader(memoryStream, System.Text.Encoding.UTF8, true))
                {
                    byte[] header = stream.ReadBytes(7);
                    byte[] magic = stream.ReadBytes(25);

                    return TryEncryptFile(stream, crypto, header, magic, out result);
                }
            }
        }

        public static bool TryDecryptFile(string fileName, out byte[] result)
        {
            Rijndael crypto = new Rijndael(Unity3dKey, Unity3dIv);

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                using (BinaryReader stream = new BinaryReader(fileStream))
                {
                    byte[] header = stream.ReadBytes(7);
                    byte[] magic = stream.ReadBytes(25);

                    return TryDecryptFile(stream, crypto, header, magic, out result);
                }
            }
        }

        private static bool CompareHeader(byte[] fileHeader)
        {
            if (UnityFs.Length != fileHeader.Length)
            {
                return false;
            }

            for (int i = 0; i < UnityFs.Length; i++)
            {
                if (UnityFs[i] != fileHeader[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CompareMagic(byte[] fileMagic)
        {
            if (Unity3dMagic.Length != fileMagic.Length)
            {
                return false;
            }

            for (int i = 0; i < Unity3dMagic.Length; i++)
            {
                if (Unity3dMagic[i] != fileMagic[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static byte[] CombineByteArrays(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        private static bool TryEncryptFile(BinaryReader stream, Rijndael crypto, byte[] header, byte[] magic, out byte[] result)
        {
            if (CompareHeader(header))
            {
                long length = stream.BaseStream.Length - 32;
                byte[] decryptedData = CombineByteArrays(header, magic, stream.ReadBytes((int)length));
                byte[] encryptedData = crypto.Encrypt(decryptedData);

                result = encryptedData;
                return true;
            }
            else
            {
                result = Array.Empty<byte>();
                return false;
            }
        }

        private static bool TryDecryptFile(BinaryReader stream, Rijndael crypto, byte[] header, byte[] magic, out byte[] result)
        {
            if (CompareMagic(CombineByteArrays(header, magic)))
            {
                long length = stream.BaseStream.Length - 32;
                byte[] encryptedData = stream.ReadBytes((int)length);
                byte[] decryptedData = crypto.Decrypt(CombineByteArrays(header, magic, encryptedData));

                result = decryptedData;
                return true;
            }
            else
            {
                result = Array.Empty<byte>();
                return false;
            }
        }
    }
}
