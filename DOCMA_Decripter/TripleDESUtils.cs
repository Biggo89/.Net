using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DOCMA_Decripter {
    internal class TripleDESUtils {
        private const string Password = "9D4533A4C35749C9AB40BDF107144C80";
        private TripleDES tdes;

        public TripleDESUtils() {
            this.tdes = TripleDES.Create();
            this.tdes.Mode = CipherMode.CBC;
            this.tdes.IV = new byte[8]
            {
        (byte) 27,
        (byte) 9,
        (byte) 45,
        (byte) 27,
        (byte) 0,
        (byte) 72,
        (byte) 171,
        (byte) 54
            };
            this.tdes.Key = new Rfc2898DeriveBytes("9D4533A4C35749C9AB40BDF107144C80", new byte[8]
            {
        (byte) 45,
        (byte) 32,
        (byte) 89,
        (byte) 0,
        (byte) 64,
        (byte) 134,
        (byte) 26,
        (byte) 51
            }, 1000).GetBytes(24);
        }

        public byte[] Encrypt(string plainText) {
            byte[] buffer = (byte[])null;
            try {
                using (MemoryStream memoryStream = new MemoryStream()) {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, this.tdes.CreateEncryptor(this.tdes.Key, this.tdes.IV), CryptoStreamMode.Write)) {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream)) {
                            streamWriter.Write(plainText);
                            streamWriter.Flush();
                            cryptoStream.FlushFinalBlock();
                            buffer = new byte[memoryStream.Length];
                            memoryStream.Position = 0L;
                            memoryStream.Read(buffer, 0, (int)memoryStream.Length);
                        }
                    }
                }
            } catch (Exception ex) {
            }
            return buffer;
        }

        internal string Decrypt(byte[] enc) {
            string str = string.Empty;
            try {
                using (MemoryStream memoryStream = new MemoryStream(enc)) {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, this.tdes.CreateDecryptor(this.tdes.Key, this.tdes.IV), CryptoStreamMode.Read)) {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            str = streamReader.ReadToEnd();
                    }
                }
            } catch (Exception ex) {
            }
            return str;
        }
    }
}
