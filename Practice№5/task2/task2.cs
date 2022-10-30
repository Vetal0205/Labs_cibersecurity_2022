using System;
using System.Text;
using Practice5;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Practice5
{
    class Console_Gui
    {
        public static void MENU()
        {
            Console.Clear();
            Console.WriteLine("   [*] Choose option [*]");
            Console.WriteLine("[=========================]");
            Console.WriteLine(" |       1. AES          |");
            Console.WriteLine(" |       2. DES          |");
            Console.WriteLine(" |       3. TDES         |");
            Console.WriteLine(" |       4. Exit         |");
            Console.WriteLine("[=========================]");
        }
    }
    class Program
    {
        static void Main()
        {
            byte[] hashedpass;
            byte[] salt;
            do
            {
                Console.Clear();
                Console_Gui.MENU();
                string? answer_menu = Console.ReadLine();
                switch (answer_menu)
                {
                    case "1":
                        Console.WriteLine("[*] Enter text [*]");
                        string? answer_text_AES = Console.ReadLine();
                        Console.WriteLine("[*] Enter key [*]");
                        byte[] answer_key_AES = Encoding.Unicode.GetBytes(Console.ReadLine());
                        salt = PBKDF2.GenerateRandomNumber(32);
                        if (answer_key_AES != null)
                        {
                            hashedpass = PBKDF2.Hash_Password_With_Salt_Iteration(answer_key_AES, salt, 30000, "SHA256", 48);
                            // Grabs first 32 bytes of array
                            var key_aes = hashedpass.Take(32).ToArray();
                            // Skips first 32 bytes then takes next 16 
                            var iv_aes = hashedpass.Skip(32).Take(16).ToArray();

                            byte[] encryptedAES = AESclass.EncryptStringToBytes_Aes(answer_text_AES, key_aes, iv_aes);
                            string decryptedAES = AESclass.DecryptStringFromBytes_Aes(encryptedAES, key_aes, iv_aes);
                            Console.WriteLine($"Entered text: '{answer_text_AES}'");
                            Console.WriteLine($"Entered pass: '{Encoding.Unicode.GetString(answer_key_AES)}'");
                            Console.WriteLine($"Generated hashedpass: '{Encoding.Unicode.GetString(hashedpass)}'");
                            Console.WriteLine($"Generated key: '{Encoding.Unicode.GetString(key_aes)}'");
                            Console.WriteLine($"Generated iv: '{Encoding.Unicode.GetString(iv_aes)}'");
                            Console.WriteLine($"Encrypted with AES: '{Encoding.Unicode.GetString(encryptedAES)}'");
                            Console.WriteLine($"Decrypted with AES: '{decryptedAES}'");
                            Console.ReadKey();

                            Array.Clear(hashedpass);
                        }
                        break;
                    case "2":
                        Console.WriteLine("[*] Enter text [*]");
                        string? answer_text_DES = Console.ReadLine();
                        Console.WriteLine("[*] Enter key [*]");
                        byte[] answer_key_DES = Encoding.UTF8.GetBytes(Console.ReadLine());
                        salt = PBKDF2.GenerateRandomNumber(32);
                        if (answer_key_DES != null)
                        {
                            hashedpass = PBKDF2.Hash_Password_With_Salt_Iteration(answer_key_DES, salt, 30000, "SHA256", 16);
                            // Grabs first 8 bytes of array
                            var key_des = hashedpass.Take(8).ToArray();
                            // Skips first 8 bytes then takes next 8 
                            var iv_des = hashedpass.Skip(8).Take(8).ToArray();


                            byte[] encryptedAES = DESclass.EncryptTextToMemory(answer_text_DES, key_des, iv_des);
                            string decryptedAES = DESclass.DecryptTextFromMemory(encryptedAES, key_des, iv_des);
                            Console.WriteLine($"Entered text: '{answer_text_DES}'");
                            Console.WriteLine($"Entered pass: '{Encoding.Unicode.GetString(answer_key_DES)}'");
                            Console.WriteLine($"Generated hashedpass: '{Encoding.Unicode.GetString(hashedpass)}'");
                            Console.WriteLine($"Generated key: '{Encoding.Unicode.GetString(key_des)}'");
                            Console.WriteLine($"Generated iv: '{Encoding.Unicode.GetString(iv_des)}'");
                            Console.WriteLine($"Encrypted with DES: '{Encoding.Unicode.GetString(encryptedAES)}'");
                            Console.WriteLine($"Decrypted with DES: '{decryptedAES}'");
                            Console.ReadKey();
                            Array.Clear(hashedpass);
                        }
                        break;
                    case "3":
                        Console.WriteLine("[*] Enter text [*]");
                        string? answer_text_TDES = Console.ReadLine();
                        Console.WriteLine("[*] Enter key [*]");
                        byte[] answer_key_TDES = Encoding.UTF8.GetBytes(Console.ReadLine());
                        salt = PBKDF2.GenerateRandomNumber(32);
                        if (answer_key_TDES != null)
                        {
                            hashedpass = PBKDF2.Hash_Password_With_Salt_Iteration(answer_key_TDES, salt, 30000, "SHA256", 24);

                            // Grabs first 8 bytes of array
                            var key_tdes_1 = hashedpass.Take(8).ToArray();
                            // Skips first 8 bytes then takes next 8
                            var key_tdes_2 = hashedpass.Skip(8).Take(8).ToArray();
                            // Skips first 16 bytes then takes next 8 
                            var iv_tdes = hashedpass.Skip(16).Take(8).ToArray();

                            byte[] encryptedTDES1 = DESclass.EncryptTextToMemory(answer_text_TDES, key_tdes_1, iv_tdes);
                            byte[] encryptedTDES2 = DESclass.EncryptTextToMemory(answer_text_TDES, key_tdes_2, iv_tdes, encryptedTDES1);
                            byte[] encryptedTDES3 = DESclass.EncryptTextToMemory(answer_text_TDES, key_tdes_1, iv_tdes, encryptedTDES2);


                            string decryptedTDES1 = DESclass.DecryptTextFromMemory(encryptedTDES3, key_tdes_1, iv_tdes);
                            string decryptedTDES2 = DESclass.DecryptTextFromMemory(encryptedTDES2, key_tdes_2, iv_tdes);
                            string decryptedTDES3 = DESclass.DecryptTextFromMemory(encryptedTDES1, key_tdes_1, iv_tdes);

                            Console.WriteLine($"Entered text: '{answer_text_TDES}'");
                            Console.WriteLine($"Entered pass: '{Encoding.Unicode.GetString(answer_key_TDES)}'");
                            Console.WriteLine($"Generated hashedpass: '{Encoding.Unicode.GetString(hashedpass)}'");
                            Console.WriteLine($"Generated key 1: '{Convert.ToBase64String(key_tdes_1)}'");
                            Console.WriteLine($"Generated key 2: '{Encoding.Unicode.GetString(key_tdes_2)}'");
                            Console.WriteLine($"Generated iv: '{Encoding.Unicode.GetString(iv_tdes)}'");
                            Console.WriteLine($"Encrypted with DES: '{Encoding.Unicode.GetString(encryptedTDES3)}'");
                            Console.WriteLine($"Decrypted with DES: '{decryptedTDES3}'");
                            Console.ReadKey();
                            Array.Clear(hashedpass);
                        }
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}