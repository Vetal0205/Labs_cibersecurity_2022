namespace Practice8
{
    public class User
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public string[] Roles { get; set; }

        public User(string login,string passwordHash,byte[] salt,string[] roles){
            Login = login;
            PasswordHash = passwordHash;

            Salt = new byte[salt.Length];
            Array.Copy(salt, Salt, salt.Length);

            Roles = roles;
            // new byte[roles.Length];
            // Array.Copy(roles, Roles, roles.Length);
        }
    }
}