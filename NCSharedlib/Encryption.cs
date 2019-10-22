using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NCSharedlib
{
    public class Encryption
    {

        static void Main()
        {
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
                byte[] encryptedData;
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Encryption failed.");

            }
        }

        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

    }
}
