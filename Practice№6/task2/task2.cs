using System;
using System.Text;
using Practice6_2;
using System.Diagnostics;

namespace Practice6_2
{
    class Program
    {
        static void Main()
        {
            byte[] origin = Encoding.Unicode.GetBytes("Mit-21 student");
            RSA.AssignNewKey("./public.txt", "./private.txt");
            RSA.GetKey("./public.txt", "./private.txt");
            byte[] encr = RSA.EncryptData(origin);
            byte[] decr = RSA.DecryptData(encr);
            Console.WriteLine($"Origin: {Encoding.Unicode.GetString(origin)}");
            Console.WriteLine($"Encrypted: `{Encoding.Unicode.GetString(encr)}`");
            Console.WriteLine($"Decrypted: {Encoding.Unicode.GetString(decr)}");
        }
    }
}