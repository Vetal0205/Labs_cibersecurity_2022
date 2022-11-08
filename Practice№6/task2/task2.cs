using System;
using System.Text;
using Practice6_2;
using System.Diagnostics;

namespace Practice6_2
{
    class Console_Gui
    {
        public static void MENU()
        {
            Console.Clear();
            Console.WriteLine("   [*] Choose option [*]");
            Console.WriteLine("[=========================]");
            Console.WriteLine(" | 1. Generate message   |");
            Console.WriteLine(" | 2. Decrypt message    |");
            Console.WriteLine(" | 3. Delete private key |");
            Console.WriteLine(" | 4. Generate new pair  |");
            Console.WriteLine(" | 5.      Exit          |");
            Console.WriteLine("[=========================]");
        }
    }
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console_Gui.MENU();
                string? answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        // Генерація повідомлення для одногрупників по відкритому ключу
                        byte[] origin = Encoding.Unicode.GetBytes("Vitalii Besliubniak Mit-21 student");
                        RSA.GetKey("./Vitalii_Besliubniak.xml", null);
                        byte[] encr = RSA.EncryptData(origin);
                        File.WriteAllBytes("./Vitalii_Unicode.txt", encr);
                        Console.WriteLine($"Origin: {Encoding.Unicode.GetString(origin)}");
                        Console.WriteLine($"Encrypted: `{Encoding.Unicode.GetString(encr)}`");
                        Console.ReadKey();
                        break;
                    case "2":
                        // Розшифрування повідомлення від одногрупників
                        byte[] encr_message = File.ReadAllBytes("./Vitalii_Unicode.txt");
                        byte[] decr = RSA.DecryptData(encr_message);
                        Console.WriteLine($"Decrypted: {Encoding.Unicode.GetString(decr)}");
                        Console.ReadKey();
                        break;
                    case "3":
                        RSA.DeleteKeyInCsp();
                        break;
                    case "4":
                        RSA.DeleteKeyInCsp();
                        RSA.AssignNewKey("./Vitalii_Besliubniak.xml");
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}