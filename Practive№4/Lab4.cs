using System;
using System.Text;
using Lab4;
using System.Diagnostics;

delegate byte[] Hash_func(byte[] toBeHashed, byte[] salt, int numberOfRounds);

class Globals
{
    public static bool found;
    public static bool exists;
    public static byte[]? salt;
}
struct User
{
    public string login;
    public string Hmac_seq;
    public byte[] salt;
    public int id;
    public User(string login, string Hmac_seq, int id, byte[] salt)
    {
        this.login = login;
        this.Hmac_seq = Hmac_seq;
        this.id = id;
        this.salt = new byte[salt.Length];
        Array.Copy(salt, this.salt, salt.Length);
    }
}
struct Users
{
    public User[] users;
    public int amount;
    public Users()
    {
        this.users = new User[10];
        this.amount = -1;
    }

}
class Console_Gui
{
    public static void MENU()
    {
        Console.Clear();
        Console.WriteLine("   [*] Choose option [*]");
        Console.WriteLine("[=========================]");
        Console.WriteLine(" |    1. SaltedHash      |");
        Console.WriteLine(" |    2. PBKDF2          |");
        Console.WriteLine(" |    3. Register        |");
        Console.WriteLine(" |    4. Exit            |");
        Console.WriteLine("[=========================]");
    }
    public static void MENU_REGISTER()
    {
        Console.Clear();
        Console.WriteLine("   [*] Choose option [*]");
        Console.WriteLine("[=========================]");
        Console.WriteLine(" |       1. Register     |");
        Console.WriteLine(" |       2. Login        |");
        Console.WriteLine(" |       3. Print        |");
        Console.WriteLine(" |       4. Back         |");
        Console.WriteLine("[=========================]");
    }
    public static void MENU_HASH()
    {
        Console.Clear();
        Console.WriteLine("   [*] Choose option [*]");
        Console.WriteLine("[=========================]");
        Console.WriteLine(" |       1. MD5          |");
        Console.WriteLine(" |       2. SHA1         |");
        Console.WriteLine(" |       3. SHA256       |");
        Console.WriteLine(" |       4. SHA384       |");
        Console.WriteLine(" |       5. SHA512       |");
        Console.WriteLine(" |       6. Back         |");
        Console.WriteLine("[=========================]");
    }
}
class Program
{
    static void Main()
    {
        Users listofusers = new Users();
        do
        {
            Console.Clear();
            Console_Gui.MENU();
            string? answer_menu = Console.ReadLine();
            switch (answer_menu)
            {
                case "1":
                    Console.WriteLine("[*] Enter pass to hash with SH1 [*]");
                    string? answer_salted_pass = Console.ReadLine();
                    byte[] salt = SaltedHash.GenerateSalt();
                    var hashedPassword1 = SaltedHash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(answer_salted_pass), salt);

                    Console.WriteLine("Password : " + answer_salted_pass);
                    Console.WriteLine("Salt = " + Convert.ToBase64String(salt));
                    Console.WriteLine("Hashed Password = " + Convert.ToBase64String(hashedPassword1));
                    Console.ReadLine();

                    break;
                case "2":
                    Console.Clear();
                    Console_Gui.MENU_HASH();
                    string? answer_PBKDF2 = Console.ReadLine();
                    switch (answer_PBKDF2)
                    {
                        // MD5
                        case "1":
                            Console.WriteLine("[*] Enter pass to hash with MD5 [*]");
                            string? answer_PBKDF2_MD5 = Console.ReadLine();
                            Hash_func func_MD5 = PBKDF2.Hash_Password_With_Salt_Md5_Iteration;
                            HashPassword(answer_PBKDF2_MD5, 30000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 80000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 130000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 180000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 230000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 280000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 330000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 380000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 430000, func_MD5);
                            HashPassword(answer_PBKDF2_MD5, 480000, func_MD5);
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("[*] Enter pass to hash with SH1 [*]");
                            string? answer_PBKDF2_SH1 = Console.ReadLine();
                            Hash_func func_SH1 = PBKDF2.Hash_Password_With_Salt_sh1_Iteration;
                            HashPassword(answer_PBKDF2_SH1, 30000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 80000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 130000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 180000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 230000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 280000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 330000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 380000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 430000, func_SH1);
                            HashPassword(answer_PBKDF2_SH1, 480000, func_SH1);
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.WriteLine("[*] Enter pass to hash with SH256 [*]");
                            string? answer_PBKDF2_Sha256 = Console.ReadLine();
                            Hash_func func_SHA256 = PBKDF2.Hash_Password_With_Salt_Sha256_Iteration;
                            HashPassword(answer_PBKDF2_Sha256, 30000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 80000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 130000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 180000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 230000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 280000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 330000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 380000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 430000, func_SHA256);
                            HashPassword(answer_PBKDF2_Sha256, 480000, func_SHA256);
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.WriteLine("[*] Enter pass to hash with SH384 [*]");
                            string? answer_PBKDF2_SHA384 = Console.ReadLine();
                            Hash_func func_SHA384 = PBKDF2.Hash_Password_With_Salt_Sha384_Iteration;
                            HashPassword(answer_PBKDF2_SHA384, 30000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 80000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 130000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 180000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 230000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 280000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 330000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 380000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 430000, func_SHA384);
                            HashPassword(answer_PBKDF2_SHA384, 480000, func_SHA384);
                            Console.ReadKey();
                            break;
                        case "5":
                            Console.WriteLine("[*] Enter pass to hash with SH512 [*]");
                            string? answer_PBKDF2_SHA512 = Console.ReadLine();
                            Hash_func func_SHA512 = PBKDF2.Hash_Password_With_Salt_Sha512_Iteration;
                            HashPassword(answer_PBKDF2_SHA512, 30000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 80000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 130000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 180000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 230000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 280000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 330000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 380000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 430000, func_SHA512);
                            HashPassword(answer_PBKDF2_SHA512, 480000, func_SHA512);
                            Console.ReadKey();
                            break;
                        case "6":
                            break;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console_Gui.MENU_REGISTER();
                    string? answer_register = Console.ReadLine();
                    switch (answer_register)
                    {
                        case "1":
                            if (listofusers.amount != 9)
                            {
                                Console.WriteLine("[*] Enter new login [*]");
                                string? login_reg = Console.ReadLine();
                                Console.WriteLine("[*] Enter new password [*]");
                                string password_reg_str = Console.ReadLine();

                                byte[] salt_reg = SaltedHash.GenerateSalt();
                                byte[] password_reg = PBKDF2.Hash_Password_With_Salt_Sha256_Iteration(Encoding.Unicode.GetBytes(password_reg_str), salt_reg, 30000);

                                string PotentialUser = Convert.ToBase64String(Hmac.ComputeHmacsha256(Encoding.UTF8.GetBytes(login_reg), password_reg));

                                for (int i = 0; i < 10; i++)
                                {
                                    if (listofusers.users[i].Hmac_seq == PotentialUser)
                                    {
                                        Console.WriteLine("[!] This login is already exists [!]");
                                        Globals.exists = true;
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                if (Globals.exists == true)
                                {
                                    Globals.exists = false;
                                    break;
                                }

                                listofusers.amount++;
                                User newUser = new User(login_reg, PotentialUser, listofusers.amount, salt_reg);
                                listofusers.users[listofusers.amount] = newUser;

                                Console.WriteLine("[#] You have successfully registered! [#]");
                                Console.WriteLine($"[#] Your Login: {login_reg} [#]\n[#] Password: {password_reg_str} [#]\n[#] HMAC sequence {PotentialUser} [#]\n[#] Salt: {Convert.ToBase64String(salt_reg)} [#]");
                                Console.ReadKey();

                                login_reg = "";
                                password_reg_str = "";
                                Array.Clear(password_reg);
                                Array.Clear(salt_reg);

                                break;
                            }
                            else
                            {
                                Console.WriteLine("[!] DB is overfulled [!]");
                                Console.ReadKey();
                                break;
                            }

                        case "2":
                            Console.WriteLine("[*] Enter login [*]");
                            string login_log = Console.ReadLine();
                            Console.WriteLine("[*] Enter new password [*]");
                            string password_log_str = Console.ReadLine();
                            for (int i = 0; i < 10; i++)
                            {
                                if (listofusers.users[i].login == login_log)
                                {
                                    Globals.salt = new byte[listofusers.users[i].salt.Length];
                                    Array.Copy(listofusers.users[i].salt, Globals.salt, listofusers.users[i].salt.Length);
                                }
                            }
                            byte[] password_log = PBKDF2.Hash_Password_With_Salt_Sha256_Iteration(Encoding.Unicode.GetBytes(password_log_str), Globals.salt, 30000);

                            string User = Convert.ToBase64String(Hmac.ComputeHmacsha256(Encoding.UTF8.GetBytes(login_log), password_log));

                            for (int i = 0; i < 10; i++)
                            {
                                if (listofusers.users[i].Hmac_seq == User)
                                {
                                    Console.WriteLine("[#] You have successfully signed in! [#]");
                                    Console.WriteLine($"\n[#] Your Login: {login_log} [#]\n[#] Password: {password_log_str} [#]\n[#] HMAC sequence {User} [#]\n[#] Salt: {Convert.ToBase64String(listofusers.users[i].salt)} [#]");
                                    Globals.found = true;
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            if (Globals.found == false)
                            {
                                Console.WriteLine("[!] Incorrect user data. Nothing found [!]");
                                Console.ReadKey();
                            }

                            Globals.found = false;

                            login_log = "";
                            password_log_str = "";
                            Array.Clear(password_log);
                            Array.Clear(Globals.salt);
                            break;
                        // IHBdgSOow8Fzuvi/DsU8EkbwljvHpp47eI+oToIQVtM=
                        case "3":
                            if (listofusers.amount == -1)
                            {
                                Console.WriteLine("[!] DB is Empty [!]");
                                Console.ReadKey();
                            }
                            else
                            {
                                for (int i = 0; i <= listofusers.amount; i++)
                                {
                                    Console.WriteLine($"[#] Id: {listofusers.users[i].id}\nLogin: {listofusers.users[i].login} \nHmac: \'{listofusers.users[i].Hmac_seq}\' \nSalt: {listofusers.users[i].salt}[#]\n\n");
                                }
                                Console.ReadKey();
                            }
                            break;
                        case "4":
                            break;
                    }
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
    private static void HashPassword(string passwordToHash, int numberOfRounds, Hash_func func)
    {
        var sw = new Stopwatch();
        sw.Start();
        var hashedPassword = func(Encoding.UTF8.GetBytes(passwordToHash), PBKDF2.GenerateSalt(), numberOfRounds);
        sw.Stop();

        Console.WriteLine();
        Console.WriteLine("Password to hash : " + passwordToHash); Console.WriteLine("Hashed Password : " + Convert.ToBase64String(hashedPassword));
        Console.WriteLine("Iterations <" + numberOfRounds + "> Elapsed Time: " + sw.ElapsedMilliseconds + "ms");
    }
}

