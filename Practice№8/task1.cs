using System;

namespace Practice8
{
    class Console_Gui
    {
        public static void MENU()
        {
            Console.Clear();
            Console.WriteLine("   [*] Choose option [*]");
            Console.WriteLine("[=========================]");
            Console.WriteLine(" |     1. Login          |");
            Console.WriteLine(" |     2. Register       |");
            Console.WriteLine(" |     3. Admins Only    |");
            Console.WriteLine(" |     4. Exit           |");
            Console.WriteLine("[=========================]");
        }
    }
    class Program
    {
        static void Main()
        {
            char role;
            string? pass;
            string? username;
            string[] choice;
            string[] user = new string[1] { "Users" };
            string[] admin = new string[1] { "Admins" };
            
            do
            {
                Console_Gui.MENU();
                string? switch_on = Console.ReadLine();
                switch (switch_on)
                {
                    case "1":

                        Console.WriteLine("[*] Enter username to log in [*]");
                        username = Console.ReadLine();

                        Console.WriteLine("[*] Enter pass to log in [*]");
                        pass = Console.ReadLine();

                        try
                        {
                            Protector.LogIn(username, pass);
                            Console.ReadKey();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                    
                        Console.WriteLine("[*] Enter username to sign in [*]");
                        username = Console.ReadLine();

                        Console.WriteLine("[*] Enter pass to sign in [*]");
                        pass = Console.ReadLine();

                        Console.WriteLine("[#] Which Group is required? [#]");
                        Console.WriteLine("[*] Admins or Users? [ A | U ] [*]");
                        role = (char)(Console.Read());

                        if (Char.ToLower(role) == 'a') { choice = admin; }
                        else { choice = user; }

                        try
                        {
                            Protector.Register(username, pass, choice);
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                            Console.ReadKey();
                        }
                        break;

                    case "3":

                        try
                        {
                            Protector.OnlyForAdminsFeature();
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                            Console.ReadKey();
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