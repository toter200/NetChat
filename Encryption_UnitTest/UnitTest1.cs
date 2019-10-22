using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using NCSharedlib;

namespace Encryption_UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
            }
            Assert.NotNull(encryptedData);
        }

        [Fact]
        public void Test2()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = new byte[15];
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
            }
            Assert.NotNull(encryptedData);
        }
        [Fact]
        public void Test3()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = null;
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
            }
            Assert.Null(encryptedData);
        }
        [Fact]
        public void Test4()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = ByteConverter.GetBytes("");
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
            }
            Assert.NotNull(encryptedData);
        }
        [Fact]
        public void Test5()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = ByteConverter.GetBytes("1 2 3 4");
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
            }
            Assert.NotNull(encryptedData);
        }

        ///////////////////////////////////
        ///////////////////////////////////
        ///D E C R Y P T I O N
        ///////////////////////////////////
        ///////////////////////////////////

        [Fact]
        public void Test6()
        {
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
                byte[] encryptedData;
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    decryptedData = Encryption.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
                Assert.NotNull(decryptedData);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Encryption failed.");
                
            }
        }
        [Fact]
        public void Test7()
        {
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConverter.GetBytes("");
                byte[] encryptedData;
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    decryptedData = Encryption.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
                Assert.NotNull(decryptedData);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Encryption failed.");

            }
        }
        [Fact]
        public void Test8()
        {
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = null;
                byte[] encryptedData;
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encryptedData = Encryption.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    decryptedData = Encryption.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
                Assert.Null(decryptedData);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Encryption failed.");

            }
        }
    }
}
