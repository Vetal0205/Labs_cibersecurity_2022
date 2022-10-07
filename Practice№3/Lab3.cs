using System;
using System.Text;
using System.Security.Cryptography;


class Crypto
{
    public static byte[] generate_sec_random_number(int length)
    {
        var randomNumberGenerator = new RNGCryptoServiceProvider();
        var randomNumber = new byte[length];
        randomNumberGenerator.GetBytes(randomNumber);
        return randomNumber;
    }
    public static byte[] ComputeHashMd5(byte[] dataForHash)
    {
        using (var md5 = MD5.Create())
        {
            return md5.ComputeHash(dataForHash);
        }
    }
    public static byte[] ComputeHashSha1(byte[] toBeHashed)
    {
        using (var sha1 = SHA1.Create())
        {
            return sha1.ComputeHash(toBeHashed);
        }
    }
    public static byte[] ComputeHashSha256(byte[] toBeHashed)
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(toBeHashed);
        }
    }
    public static byte[] ComputeHashSha384(byte[] toBeHashed)
    {
        using (var sHA384 = SHA384.Create())
        {
            return sHA384.ComputeHash(toBeHashed);
        }
    }
    public static byte[] ComputeHashSha512(byte[] toBeHashed)
    {
        using (var sha512 = SHA512.Create())
        {
            return sha512.ComputeHash(toBeHashed);
        }
    }
}
class Console_Gui
{
    public static void MENU()
    {
        Console.Clear();
        Console.WriteLine("   [*] Choose option [*]");
        Console.WriteLine("[=========================]");
        Console.WriteLine(" |       1. MD5          |");
        Console.WriteLine(" |       2. SHA1         |");
        Console.WriteLine(" |       3. SHA256       |");
        Console.WriteLine(" |       4. SHA384       |");
        Console.WriteLine(" |       5. SHA512       |");
        Console.WriteLine("[=========================]");
    }
}

class Program
{
    static void Main(string[] args)
    {
        byte[] message = Crypto.generate_sec_random_number(32);
        do
        {
            Console_Gui.MENU();
            string? answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    byte[] b = BitConverter.GetBytes(99999949);
                    byte[] c = Encoding.UTF8.GetBytes("99999949");
//Ot16/xh/wfxYujI55WR+zg==
// qlYkT8zvbAwcPUxVNAjTyQ==
                    byte[] resultmd5 = Crypto.ComputeHashMd5(c);
                    Console.WriteLine(Convert.ToBase64String(resultmd5));
                    Console.ReadKey();
                    break;
                case "2":
                    byte[] resultsha1 = Crypto.ComputeHashSha1(message);
                    Console.WriteLine(Convert.ToBase64String(resultsha1));
                    Console.ReadKey();
                    break;
                case "3":
                    byte[] resultsha256 = Crypto.ComputeHashSha256(message);
                    Console.WriteLine(Convert.ToBase64String(resultsha256));
                    Console.ReadKey();
                    break;
                case "4":
                    byte[] resultsha384 = Crypto.ComputeHashSha384(message);
                    Console.WriteLine(Convert.ToBase64String(resultsha384));
                    Console.ReadKey();
                    break;
                case "5":
                    byte[] resultsha512 = Crypto.ComputeHashSha512(message);
                    Console.WriteLine(Convert.ToBase64String(resultsha512));
                    Console.ReadKey();
                    break;
                case "6":
                    for (var i = 20192000 ; i <= 30000000; i++)
                    {
                        byte[] a = Encoding.Unicode.GetBytes(i.ToString());
                        byte[] res = Crypto.ComputeHashMd5(a);
                        Console.WriteLine("[#] Current key: {0} [#]", i);
                        if (Convert.ToBase64String(res) == "po1MVkAE7IjUUwu61XxgNg==" || Convert.ToBase64String(res) == "{564c8da6-0440-88ec-d453-0bbad57c6036}")
                        {                                   
                            Console.WriteLine("[#] DECRYPTED [#]");
                            Console.WriteLine("[#] Key: '{0}' [#]", i);
                            Console.ReadKey();
                            break;
                        }
                    }
                    break;
                case "7":
                    var x = 5;
                    var y = x.ToString();
                    Console.WriteLine(x);
                    Console.WriteLine(y);
                    Console.WriteLine(y.GetType());
                    Console.ReadKey();
                    break;
            }
        } while (true);

    }
}

// {564c8da6-0440-88ec-d453-0bbad57c6036}
// po1MVkAE7IjUUwu61XxgNg==

