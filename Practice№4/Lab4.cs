using System;
using System.Text;
using Lab4;
using System.Diagnostics;

delegate byte[] Hash_func(byte[] toBeHashed, byte[] salt, int numberOfRounds, string Hashalg);

class Globals
{
    public static bool found;
    public static bool exists;
    public static byte[]? salt;
}
struct User
{
    public string login;
    public byte[] salt;
    public string password;
    public int id;
    public User(int id, string login, string pass, byte[] salt)
    {
        this.login = login;
        this.password = pass;
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
        Users filter = new Users();

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
                            Hash_func func_MD5 = PBKDF2.Hash_Password_With_Salt_Iteration;
                            for (int i = 30000; i <= 480000; i = i + 50000)
                            {
                                HashPassword(answer_PBKDF2_MD5, i, func_MD5, "MD5");
                            }
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("[*] Enter pass to hash with SH1 [*]");
                            string? answer_PBKDF2_SH1 = Console.ReadLine();
                            Hash_func func_SH1 = PBKDF2.Hash_Password_With_Salt_Iteration;
                            for (int i = 30000; i <= 480000; i = i + 50000)
                            {
                                HashPassword(answer_PBKDF2_SH1, i, func_SH1, "SHA1");
                            }
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.WriteLine("[*] Enter pass to hash with SH256 [*]");
                            string? answer_PBKDF2_Sha256 = Console.ReadLine();
                            Hash_func func_SHA256 = PBKDF2.Hash_Password_With_Salt_Iteration;
                            for (int i = 30000; i <= 480000; i = i + 50000)
                            {
                                HashPassword(answer_PBKDF2_Sha256, i, func_SHA256, "SHA256");
                            }
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.WriteLine("[*] Enter pass to hash with SH384 [*]");
                            string? answer_PBKDF2_SHA384 = Console.ReadLine();
                            Hash_func func_SHA384 = PBKDF2.Hash_Password_With_Salt_Iteration;
                            for (int i = 30000; i <= 480000; i = i + 50000)
                            {
                                HashPassword(answer_PBKDF2_SHA384, i, func_SHA384, "SHA384");
                            }
                            Console.ReadKey();
                            break;
                        case "5":
                            Console.WriteLine("[*] Enter pass to hash with SH512 [*]");
                            string? answer_PBKDF2_SHA512 = Console.ReadLine();
                            Hash_func func_SHA512 = PBKDF2.Hash_Password_With_Salt_Iteration;
                            for (int i = 30000; i <= 480000; i = i + 50000)
                            {
                                HashPassword(answer_PBKDF2_SHA512, i, func_SHA512, "SHA512");
                            }
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
                                string login_reg_str = Console.ReadLine();
                                Console.WriteLine("[*] Enter new password [*]");
                                string password_reg_str = Console.ReadLine();

                                byte[] salt_reg = SaltedHash.GenerateSalt();
                                byte[] password_reg = PBKDF2.Hash_Password_With_Salt_Iteration(Encoding.Unicode.GetBytes(password_reg_str), salt_reg, 30000, "SHA256");


                                for (int i = 0; i < 10; i++)
                                {
                                    if (listofusers.users[i].login == login_reg_str && listofusers.users[i].password == Convert.ToBase64String(password_reg))
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
                                User newUser = new User(listofusers.amount, login_reg_str, Convert.ToBase64String(password_reg), salt_reg);
                                listofusers.users[listofusers.amount] = newUser;

                                Console.WriteLine("[#] You have successfully registered! [#]");
                                Console.WriteLine($"[#] Your Login: {login_reg_str} [#]\n[#] Password: {password_reg_str} {Convert.ToBase64String(password_reg)} [#]\n[#] Salt: {Convert.ToBase64String(salt_reg)} [#]");
                                Console.ReadKey();

                                login_reg_str = "";
                                password_reg_str = "";
                                Array.Clear(password_reg);
                                // Array.Clear(login_reg);
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
                            string login_log_str = Console.ReadLine();
                            Console.WriteLine("[*] Enter new password [*]");
                            string password_log_str = Console.ReadLine();


                            for (int i = 0; i < 10; i++)
                            {
                                if (listofusers.users[i].login == login_log_str)
                                {
                                    filter.amount++;
                                    filter.users[filter.amount] = listofusers.users[i];
                                }
                            }
                            for (int i = 0; i < filter.amount + 1; i++)
                            {

                                Globals.salt = new byte[filter.users[i].salt.Length];
                                Array.Copy(filter.users[i].salt, Globals.salt, filter.users[i].salt.Length);

                                byte[] password_log = PBKDF2.Hash_Password_With_Salt_Iteration(Encoding.Unicode.GetBytes(password_log_str), Globals.salt, 30000,  "SHA256");

                                if (filter.users[i].login == login_log_str && filter.users[i].password == Convert.ToBase64String(password_log))
                                {
                                    Console.WriteLine("[#] You have successfully signed in! [#]");
                                    Console.WriteLine($"[#] Your Login: {login_log_str} [#]\n[#] Password: {password_log_str} {Convert.ToBase64String(password_log)} [#]\n[#] Salt: {Convert.ToBase64String(Globals.salt)} [#]");
                                    Globals.found = true;
                                    Console.ReadKey();

                                    login_log_str = "";
                                    password_log_str = "";
                                    Array.Clear(password_log);
                                    Array.Clear(Globals.salt);
                                    Array.Clear(filter.users);
                                    filter.amount = -1;
                                    break;
                                }
                            }
                            if (Globals.found == false)
                            {
                                Console.WriteLine("[!] Incorrect user data. Nothing found [!]");
                                Console.ReadKey();
                            }

                            Globals.found = false;


                            break;
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
                                    Console.WriteLine($"[#] Id: {listofusers.users[i].id} Login: {listofusers.users[i].login} Password: {listofusers.users[i].password} Salt: {Convert.ToBase64String(listofusers.users[i].salt)}[#]\n");
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
    private static void HashPassword(string passwordToHash, int numberOfRounds, Hash_func func, string Hashalg)
    {
        var sw = new Stopwatch();
        sw.Start();
        var hashedPassword = func(Encoding.UTF8.GetBytes(passwordToHash), PBKDF2.GenerateSalt(), numberOfRounds, Hashalg);
        sw.Stop();

        Console.WriteLine();
        Console.WriteLine("Password to hash : " + passwordToHash); Console.WriteLine("Hashed Password : " + Convert.ToBase64String(hashedPassword));
        Console.WriteLine("Iterations <" + numberOfRounds + "> Elapsed Time: " + sw.ElapsedMilliseconds + "ms");
    }
}

