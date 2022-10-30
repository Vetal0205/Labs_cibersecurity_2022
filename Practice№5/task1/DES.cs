using System.Security.Cryptography;
using System;
using System.Text;
using System.IO;

namespace Practice5
{
    public class DESclass
    {
        public static byte[] EncryptTextToMemory(string plainText, byte[] key, byte[] iv, byte[]? text = null)
        {
            try
            {
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (iv == null || iv.Length <= 0)
                    throw new ArgumentNullException("IV");
                using (MemoryStream mStream = new MemoryStream())
                {
                    // Create a new DES object.
                    using (DES des = DES.Create())
                    // Create a DES encryptor from the key and IV
                    using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))
                    // Create a CryptoStream using the MemoryStream and encryptor
                    using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                    {
                        // Convert the provided string to a byte array.
                        if (text != null)
                        {
                            cStream.Write(text, 0, text.Length);
                        }
                        else
                        {
                            byte[] toEncrypt = Encoding.UTF8.GetBytes(plainText);
                            cStream.Write(toEncrypt, 0, toEncrypt.Length);

                        }

                        // Write the byte array to the crypto stream and flush it.


                        // Ending the using statement for the CryptoStream completes the encryption.
                    }

                    // Get an array of bytes from the MemoryStream that holds the encrypted data.
                    byte[] ret = mStream.ToArray();

                    // Return the encrypted buffer.
                    return ret;
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }

        }

        public static string DecryptTextFromMemory(byte[] encrypted, byte[] key, byte[] iv)
        {
            try
            {
                // Create a buffer to hold the decrypted data.
                // DES-encrypted data will always be slightly bigger than the decrypted data.
                byte[] decrypted = new byte[encrypted.Length];
                int offset = 0;

                // Create a new MemoryStream using the provided array of encrypted data.
                using (MemoryStream mStream = new MemoryStream(encrypted))
                {
                    // Create a new DES object.
                    using (DES des = DES.Create())
                    // Create a DES decryptor from the key and IV
                    using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))
                    // Create a CryptoStream using the MemoryStream and decryptor
                    using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                    {
                        // Keep reading from the CryptoStream until it finishes (returns 0).
                        int read = 1;

                        while (read > 0)
                        {
                            read = cStream.Read(decrypted, offset, decrypted.Length - offset);
                            offset += read;
                        }
                    }
                }

                // Convert the buffer into a string and return it.
                return Encoding.UTF8.GetString(decrypted, 0, offset);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
    }
}