using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace DOCMA_Decripter {
    public class CryptoUtil {
        public static void EncryptFile(string filePathIn, string key, string filePathOut) {
            byte[] plainContent = File.ReadAllBytes(filePathIn);
            using (var DES = new TripleDESCryptoServiceProvider()) {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream()) {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePathOut, memStream.ToArray());
                }
            }
        }

        public static void DencryptFile(string filePathIn, string key, string filePathOut) {
            byte[] plainContent = File.ReadAllBytes(filePathIn);
            using (var DES = new TripleDESCryptoServiceProvider()) {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream()) {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(), CryptoStreamMode.Read);
                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePathOut, memStream.ToArray());
                }
            }
        }
    }
}
