using System;
using System.Text;
using Practice7;
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
            Console.WriteLine(" | 1. Create Signature   |");
            Console.WriteLine(" | 2. Verify Signature   |");
            Console.WriteLine(" | 3. Delete key pair    |");
            Console.WriteLine(" | 4.      Exit          |");
            Console.WriteLine("[=========================]");
        }
    }
    class Program
    {
        static void Main()
        {
            do
            {
                byte[] signature;
                byte[] origin; 
                Console.Clear();
                Console_Gui.MENU();
                string? answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        origin = Encoding.Unicode.GetBytes("Vitalii Besliubniak is a Mit-21 student");
                        // RSA.GetKey("./Vitalii_Besliubniak.xml", null);
                        signature = EDS.CreateSignature(origin);
                        Console.WriteLine($"Origin: {Encoding.Unicode.GetString(origin)}");
                        Console.WriteLine($"Signature Created: `{Encoding.Unicode.GetString(signature)}`");
                        Console.ReadKey();
                        break;
                    case "2":
                        origin = Encoding.Unicode.GetBytes("Vitalii Besliubniak is a Mit-21 student");
                        byte[] fakeOrigin = Encoding.Unicode.GetBytes("Vitalii Besliubniak is not a Mit-21 student");
                        signature = EDS.CreateSignature(origin);// буде замінено на вхідну сигнатуру
                        EDS.GetKey("./public.xml", null);
                        bool verified = EDS.VerifySignature(fakeOrigin, signature);
                        Console.WriteLine($"Origin: {Encoding.Unicode.GetString(origin)}");
                        Console.WriteLine($"Fake origin: {Encoding.Unicode.GetString(fakeOrigin)}");
                        Console.WriteLine($"Signature Verified?: {verified}");
                        Console.ReadKey();
                        break;
                    case "3":
                        EDS.DeleteKeyInCsp();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                } 
            }while (true) ;
        }
    }
}