using System.Security.Cryptography;
using System.IO;
namespace Practice7
{
    public class EDS
    {
        private readonly static string CspContainerName = "RsaContainer";
        private static RSAParameters _publicKey, _privateKey;
        public static void GetKey(string publicKeyPath, string? privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                string pb = File.ReadAllText(publicKeyPath);
                rsa.FromXmlString(pb);
                _publicKey = rsa.ExportParameters(false);
                if (privateKeyPath != null)
                {
                    string pr = File.ReadAllText(privateKeyPath);
                    rsa.FromXmlString(pr);
                    _privateKey = rsa.ExportParameters(true);
                }
            }
        }
        public static void DeleteKeyInCsp()
        {
            CspParameters cspParameters = new CspParameters
            {
                KeyContainerName = CspContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            var rsa = new RSACryptoServiceProvider(cspParameters)
            {
                PersistKeyInCsp = false
            };
            rsa.Clear();
        }
        public static byte[] CreateSignature(byte[] dataToSign)
        {
            var cspParams = new CspParameters
            {
                KeyContainerName = CspContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = true;
                File.WriteAllText("./public.xml", rsa.ToXmlString(false));
                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                byte[] hashOfData;
                rsaFormatter.SetHashAlgorithm(nameof(SHA512));
                using (var sha512 = SHA512.Create())
                {
                    hashOfData = sha512.ComputeHash(dataToSign);
                }
                return rsaFormatter.CreateSignature(hashOfData);
            }
        }
        public static bool VerifySignature(byte[] data, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);
                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                byte[] hashOfData;
                rsaDeformatter.SetHashAlgorithm(nameof(SHA512));
                using (var sha512 = SHA512.Create())
                {
                    hashOfData = sha512.ComputeHash(data);
                }
                return rsaDeformatter.VerifySignature(hashOfData, signature);
            }
        }
    }
}