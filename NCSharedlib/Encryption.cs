using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NCSharedlib
{
    class Encryption
    {
        
        public byte[] encrypting(byte[]data, string inputtext) {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
            MemoryStream memstream = new MemoryStream();
            //byte[] iv = new byte[32];

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(inputtext);
            //cryptic.IV = iv;

            CryptoStream crStream = new CryptoStream(memstream,cryptic.CreateEncryptor(), CryptoStreamMode.Write);
            crStream.Write(data);
            crStream.Close();

            return memstream.ToArray();

        }
    }
}
