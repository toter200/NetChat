using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NCSharedlib
{
    class Encryption
    {
        public string encrypting(FileStream stream, string inputtext) {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(inputtext);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(inputtext);

            CryptoStream crStream = new CryptoStream(stream,cryptic.CreateEncryptor(), CryptoStreamMode.Write);
            return crStream.ToString();
        }
    }
}
