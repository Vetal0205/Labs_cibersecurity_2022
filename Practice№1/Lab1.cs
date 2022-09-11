using System;
using System.Security.Cryptography;
public class Deterministic_rnd_num
{
    public static System.Random generate_det_random_number(int seed)
    {
        Random rnd = new Random(seed);
        return rnd;
    }
}
public class Secure_rnd_num
{
    public static byte[] generate_sec_random_number(int length)
    {
        var randomNumberGenerator = new RNGCryptoServiceProvider();
        var randomNumber = new byte[length];
        randomNumberGenerator.GetBytes(randomNumber);
        //     Fills the specified byte array with a cryptographically strong random sequence
        //     of values starting at a specified index for a specified number of bytes.
        return randomNumber;
    }
}
class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("   [*] Choose option [*]");
            Console.WriteLine("[=========================]");
            Console.WriteLine(" | 1. Deterministic Num   |");
            Console.WriteLine(" | 2. Secure random Num   |");
            Console.WriteLine(" | 3. Exit                |");
            Console.WriteLine("[=========================]");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.Write("\n");

                    Console.WriteLine("[*] Enter seed [*]");
                    string? answer_seed = Console.ReadLine(); // ? means, it can contain null parametr
                    int seed = Convert.ToInt32(answer_seed);

                    System.Random RandomNum = Deterministic_rnd_num.generate_det_random_number(seed);
                    Console.Write("\n");

                    Console.WriteLine("[*] Enter amount of numbers [*]");
                    string? answer_det_num_amount = Console.ReadLine();
                    int det_num_amount = Convert.ToInt32(answer_det_num_amount);

                    for (int ctr = 0; ctr < det_num_amount; ctr++)
                    {
                        Console.Write("{0}  ", RandomNum.Next(-10, 11));
                    }
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("\n");

                    Console.WriteLine("[*] Enter amount of byte [*]");
                    string? answer_bytes = Console.ReadLine(); // ? means, it can contain null parametr
                    int bytes = Convert.ToInt32(answer_bytes);

                    Console.WriteLine("[*] Enter amount of lines [*]");
                    string? answer_sec_num_amount = Console.ReadLine();
                    int sec_num_amount = Convert.ToInt32(answer_sec_num_amount);


                    for (int i = 0; i < sec_num_amount; i++)
                    {
                        string randomNumber = Convert.ToBase64String(Secure_rnd_num.generate_sec_random_number(bytes));
                        Console.WriteLine(randomNumber);
                    }
                    Console.ReadKey();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        } while (true);

    }
}
