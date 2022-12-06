using System.Security.Cryptography;
namespace Practice9
{
    public class PBKDF2
    {
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] Hash_Password_With_Salt_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds, string Hashalg)
        {
            var algorithm = new HashAlgorithmName(Hashalg);
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }
        

    }
}