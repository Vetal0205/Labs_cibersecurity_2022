using System.Security.Principal;
using System.Security;
using System.Collections.Generic;
namespace Practice8
{
    public class Protector
    {
        private static Dictionary<string, User> _users = new Dictionary<string, User>();
        public static void OnlyForAdminsFeature()
        {
            if (Thread.CurrentPrincipal == null)
            {
                throw new SecurityException("Thread.CurrentPrincipal cannot be null.");
            }
            if (!Thread.CurrentPrincipal.IsInRole("Admins"))
            {
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }
            Console.WriteLine("You have access to this secure feature.");
        }
        public static void LogIn(string userName, string password)
        {
            // Перевірка пароля
            if (CheckPassword(userName, password))
            {
                var identity = new GenericIdentity(userName, "OIBAuth");

                var principal = new GenericPrincipal(identity, _users[userName].Roles);
                System.Threading.Thread.CurrentPrincipal = principal;
                Console.WriteLine("You were successfuly logged in!");
            }
        }
        public static bool CheckPassword(string userName, string password)
        {
            if (_users.ContainsKey(userName))
            {
                User PotentialUser = _users[userName];
                var hashedPassword = PBKDF2.Hash_Password_With_Salt_Iteration(System.Text.Encoding.UTF8.GetBytes(password), PotentialUser.Salt, 300, "SHA256");
                string hashedPasswordString = System.Convert.ToBase64String(hashedPassword);
                if (hashedPasswordString == PotentialUser.PasswordHash)
                {
                    return true;
                }
                else
                {
                    throw new WrongPassword("Wrong login or password provided");
                }
            }
            else
            {
                throw new KeyNotFoundException($"An User with name \"{userName}\" not found");
            }
        }
        public static void Register(string userName, string password, string[] roles = null)
        {
            if (_users.ContainsKey(userName)) { throw new ArgumentException($"An User with name \"{userName}\" already exists."); }

            byte[] salt = PBKDF2.GenerateSalt();
            var hashedPassword = PBKDF2.Hash_Password_With_Salt_Iteration(System.Text.Encoding.UTF8.GetBytes(password), salt, 300, "SHA256");

            string hashedPasswordString = System.Convert.ToBase64String(hashedPassword);

            User PotentialUser = new User(userName, hashedPasswordString, salt, roles);
            _users.Add(userName, PotentialUser);
            Console.WriteLine("You were successfuly signed in!");
        }
    }
}