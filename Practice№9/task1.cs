using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace Practice9
{
    public class Runner
    {
        private readonly ILogger<Runner> _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }
    }
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
            var Logger = LogManager.GetCurrentClassLogger();
            char role;
            string? pass;
            string? username;
            string[] choice;
            string[] user = new string[1] { "Users" };
            string[] admin = new string[1] { "Admins" };
            Logger.Trace("Init program");
            do
            {
                Logger.Trace("Enteted do/while loop");
                Console_Gui.MENU();

                string? switch_on = Console.ReadLine();
                switch (switch_on)
                {
                    case "1":
                        Logger.Trace("Login procces start");

                        Console.WriteLine("[*] Enter username to log in [*]");
                        username = Console.ReadLine();
                        Logger.Debug("Username is set to {0}", username);
                        Console.WriteLine("[*] Enter pass to log in [*]");
                        pass = Console.ReadLine();
                        Logger.Debug("Password is set to {0}", pass);

                        try
                        {
                            Logger.Trace("User authentication process start");
                            Protector.LogIn(username, pass);
                            Logger.Trace("User authentication process end");
                            Logger.Info("User {0} has logged in", username);
                            Console.ReadKey();

                        }
                        catch (WrongPassword ex)
                        {
                            Logger.Info("Wrong Credentials");
                            Logger.Warn(ex, "Wrong password");
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("User authentication process failed see more info in logs");
                            Logger.Error(ex, "User authentication process failed");
                            Console.ReadKey();
                        }
                        Logger.Trace("Login procces end");
                        break;

                    case "2":
                        Logger.Trace("Registration process start");

                        Console.WriteLine("[*] Enter username to sign in [*]");
                        username = Console.ReadLine();
                        Logger.Debug("Username is set to {0}", username);

                        Console.WriteLine("[*] Enter pass to sign in [*]");
                        pass = Console.ReadLine();
                        Logger.Debug("Password is set to {0}", pass);

                        Console.WriteLine("[#] Which Group is required? [#]");
                        Console.WriteLine("[*] Admins or Users? [ A | U ] [*]");
                        role = (char)(Console.Read());
                        Logger.Debug("Role is set to {0}", role);

                        if (Char.ToLower(role) == 'a') { choice = admin; }
                        else { choice = user; }

                        try
                        {
                            Logger.Trace("User registration process start");
                            Protector.Register(username, pass, choice);
                            Logger.Trace("User registration process end");
                            Logger.Info("User {0} has signed in", username);
                            Console.ReadKey();
                        }
                        catch (WrongPassword ex)
                        {
                            Logger.Info("Wrong Credentials");
                            Logger.Warn(ex, "Wrong password");
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("User registration process failed see more info in logs");
                            Logger.Error(ex, "User registration process failed");
                            Console.ReadKey();
                        }
                        Logger.Trace("Registration process end");
                        break;

                    case "3":
                        Logger.Trace("Admin verification process start");

                        try
                        {
                            Logger.Trace("Admin authorization process start");
                            Protector.OnlyForAdminsFeature();
                            Logger.Trace("Admin authorization process end");
                            Logger.Info("OnlyForAdminsFeature usage");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("Admin authorization process failed see more info in logs");
                            Logger.Error(ex, "Admin authorization process failed");
                            Console.ReadKey();
                        }
                        Logger.Trace("Admin verification process end");
                        break;

                    case "4":
                        Logger.Trace("Stop program");
                        LogManager.Shutdown();
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}