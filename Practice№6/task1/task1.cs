using System;
using System.Text;
using Practice6_1;
using System.Diagnostics;

namespace Practice6_1
{
    class Program
    {
        static void Main()
        {
            byte[] origin = Encoding.Unicode.GetBytes("Mit-21 student");
            RSA.AssignNewKey();
            byte[] encr = RSA.EncryptData(origin);
            byte[] decr = RSA.DecryptData(encr);
        
            Console.WriteLine($"Origin: {Encoding.Unicode.GetString(origin)}");
            Console.WriteLine($"Encrypted: `{Encoding.Unicode.GetString(encr)}`");
            Console.WriteLine($"Decrypted: {Encoding.Unicode.GetString(decr)}");
        }
    }
}