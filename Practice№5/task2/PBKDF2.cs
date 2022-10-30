using System.Security.Cryptography;
namespace Practice5
{
    public class PBKDF2
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] Hash_Password_With_Salt_Iteration(byte[] toBeHashed, byte[] salt, int numberOfRounds, string Hashalg, int length)
        {
            var algorithm = new HashAlgorithmName(Hashalg);
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, algorithm))
            {
                return rfc2898.GetBytes(length);
            }
        }


    }
}