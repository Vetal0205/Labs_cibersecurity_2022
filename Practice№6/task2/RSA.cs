using System.Security.Cryptography;
using System.IO;
namespace Practice6_2
{
    public class RSA
    {
        private readonly static string CspContainerName = "RsaContainer";
        // In-Memory Keys
        private static RSAParameters _publicKey, _privateKey;
        public static void AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
            }
        }
        public static void GetKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {

                if (publicKeyPath != null)
                {
                    string pb = File.ReadAllText(publicKeyPath);
                    rsa.FromXmlString(pb);
                    _publicKey = rsa.ExportParameters(false);

                }
                if (privateKeyPath != null)
                {
                    string pr = File.ReadAllText(privateKeyPath);
                    rsa.FromXmlString(pr);
                    _privateKey = rsa.ExportParameters(true);
                }
            }
        }
        public static byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cypherBytes;
            var cspParams = new CspParameters
            {
                KeyContainerName = CspContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                // rsa.PersistKeyInCsp = true;
                rsa.ImportParameters(_publicKey);
                cypherBytes = rsa.Encrypt(dataToEncrypt, true);
            }
            return cypherBytes;
        }
        public static byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plainBytes;
            var cspParams = new CspParameters
            {
                KeyContainerName = CspContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                // rsa.PersistKeyInCsp = true;
                rsa.ImportParameters(_privateKey);
                plainBytes = rsa.Decrypt(dataToDecrypt, true);
            }
            return plainBytes;
        }
    }
}