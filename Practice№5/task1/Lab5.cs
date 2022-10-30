using System;
using System.Text;
using Practice5;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Practice5
{

    class Program
    {
        static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        static void Main()
        {
            try
            {
                // DES ciphet
                byte[] keyDES;
                byte[] ivDES;
                string DES = "Here is some data to encrypt. DES";

                keyDES = GenerateRandomNumber(8);
                ivDES = GenerateRandomNumber(8);


                byte[] encryptedDES = DESclass.EncryptTextToMemory(DES, keyDES, ivDES);

                string decryptedDES = DESclass.DecryptTextFromMemory(encryptedDES, keyDES, ivDES);

                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine($"Encrypted with DES: '{Convert.ToBase64String(encryptedDES)}'");
                Console.WriteLine($"Decrypted with DES: '{decryptedDES}'");
                // TDES
                byte[] keyTDES1;
                byte[] keyTDES2;
                byte[] ivTDES;
                keyTDES1 = GenerateRandomNumber(8);
                keyTDES2 = GenerateRandomNumber(8);
                ivTDES = GenerateRandomNumber(8);
                string TDES = "Here is some data to encrypt. TDES";

                byte[] encryptedTDES1 = DESclass.EncryptTextToMemory(TDES, keyTDES1, ivTDES);
                byte[] encryptedTDES2 = DESclass.EncryptTextToMemory(TDES, keyTDES2, ivTDES, encryptedTDES1);
                byte[] encryptedTDES3 = DESclass.EncryptTextToMemory(TDES, keyTDES1, ivTDES, encryptedTDES2);

                string decryptedTDES1 = DESclass.DecryptTextFromMemory(encryptedTDES3, keyTDES1, ivTDES);
                string decryptedTDES2 = DESclass.DecryptTextFromMemory(encryptedTDES2, keyTDES2, ivTDES);
                string decryptedTDES3 = DESclass.DecryptTextFromMemory(encryptedTDES1, keyTDES1, ivTDES);
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine($"Encrypted with TDES1: '{Convert.ToBase64String(encryptedTDES1)}'");
                Console.WriteLine($"Encrypted with TDES2: '{Convert.ToBase64String(encryptedTDES2)}'");
                Console.WriteLine($"Encrypted with TDES3: '{Convert.ToBase64String(encryptedTDES3)}'");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine($"Decrypted with TDES1: '{decryptedTDES1}' ");
                Console.WriteLine($"Decrypted with TDES2: '{decryptedTDES2}' ");
                Console.WriteLine($"Decrypted with TDES3: '{decryptedTDES3}' ");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");


                // AES ciphet
                byte[] keyAES;
                byte[] ivAES;
                string AES = "Here is some data to encrypt! AES";
                keyAES = GenerateRandomNumber(32);
                ivAES = GenerateRandomNumber(16);

                byte[] encryptedAES = AESclass.EncryptStringToBytes_Aes(AES, keyAES, ivAES);

                string decryptedAES = AESclass.DecryptStringFromBytes_Aes(encryptedAES, keyAES, ivAES);

                Console.WriteLine($"Encrypted with AES: '{Convert.ToBase64String(encryptedAES)}'");
                Console.WriteLine($"Decrypted with AES: '{decryptedAES}'");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
