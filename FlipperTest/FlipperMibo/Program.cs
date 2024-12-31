using System;
using System.IO;

namespace FlipperMibo
{
    internal class Program
    {

        public static string ConvertToHex(byte value)
        {
            string output = Convert.ToString(value, 16).ToUpper();
            return output.Length == 1 ? '0' + output : output;
        }

        private static void Main(string[] args)
        {
            string filePath = args[0];
            const int pageCount = 135; //540 / 4
            const string pageIndex = @"Filetype: Flipper NFC device
Version: 2
# Nfc device type can be UID, Mifare Ultralight, Bank card
Device type: NTAG215
# UID, ATQA and SAK are common for all formats
UID: $.$
ATQA: 44 00
SAK: 00
# Mifare Ultralight specific data
Signature: 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
Mifare version: 00 04 04 02 01 00 11 03
Counter 0: 0
Tearing 0: 00
Counter 1: 0
Tearing 1: 00
Counter 2: 0
Tearing 2: 00
Pages total: 135";

            byte[] amiiboBin = File.ReadAllBytes(filePath);
            string[] amiiboHex = new string[amiiboBin.Length];
            if (amiiboBin.Length != 540)
            {
                Console.WriteLine("Invalid Amiibo");
                Console.ReadKey();
                return;
            }
            string amiiboUID = $"{ConvertToHex(amiiboBin[0])} {ConvertToHex(amiiboBin[1])} {ConvertToHex(amiiboBin[2])} {ConvertToHex(amiiboBin[4])} {ConvertToHex(amiiboBin[5])} {ConvertToHex(amiiboBin[6])} {ConvertToHex(amiiboBin[7])}";

            Console.WriteLine($"Byte count: {amiiboBin.Length}\nPage count: {amiiboBin.Length / 4}\nAmiibo UID: {amiiboUID}\nAmiibo HEX Value:");
            for (int i = 0; i < amiiboBin.Length; i++)
            {
                amiiboHex[i] = ConvertToHex(amiiboBin[i]);
                Console.Write(amiiboHex[i] + ' ');
            }

            Console.WriteLine("All data valid.\nStarting to generate Flipper NTAG215 file template: ");
            using (StreamWriter amiiboWriter = new StreamWriter(filePath.Replace(".bin", ".nfc")))
            {
                string fileHeader = pageIndex.Replace("$.$", amiiboUID);
                amiiboWriter.WriteLine(fileHeader);
                Console.WriteLine(fileHeader + "\nWritten header to file");
                string outputBuffer;
                for (int i = 0, ai = 0; i < pageCount; i++, ai += 4)
                {
                    outputBuffer = $"Page {i}: {amiiboHex[ai]} {amiiboHex[ai + 1]} {amiiboHex[ai + 2]} {amiiboHex[ai + 3]}";
                    amiiboWriter.WriteLine(outputBuffer);
                    Console.WriteLine("[Writer] " + outputBuffer);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[Giordano] OLE");
        }
    }
}
