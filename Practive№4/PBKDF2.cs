using System.Security.Cryptography;
namespace Lab4
{
    public class PBKDF2
    {
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator =
            new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] Hash_Password_With_Salt_sh1_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            var algorithm = new HashAlgorithmName("SHA1");
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }
        public static byte[] Hash_Password_With_Salt_Md5_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {   
            var algorithm = new HashAlgorithmName("MD5");
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }
        public static byte[] Hash_Password_With_Salt_Sha256_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            var algorithm = new HashAlgorithmName("SHA256");
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }
        public static byte[] Hash_Password_With_Salt_Sha384_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            var algorithm = new HashAlgorithmName("SHA384");
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }
        public static byte[] Hash_Password_With_Salt_Sha512_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            var algorithm = new HashAlgorithmName("SHA512");
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }

    }
}