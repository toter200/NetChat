using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NCSharedlib
{
    class Encryption
    {
        public void encrypting(FileStream stream) {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");

            CryptoStream crStream = new CryptoStream(stream,cryptic.CreateEncryptor(), CryptoStreamMode.Write);
        }
    }
}
