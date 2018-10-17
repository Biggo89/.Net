using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace DOCMA_Decripter {
    public class Program {
        static void Main(string[] args) {
            var certificate = LoadCertificate(@"C:\Users\Alessandro Grando\Documents\DOCMA_Service\aaaa.pfx", "Torino18");
            var fileName = "273590811.PDF";
            var f = LoadFile($@"C:\Users\Alessandro Grando\Documents\DOCMA_Service\{fileName}");
            //EnvelopedCms envelopedCms = new EnvelopedCms(new ContentInfo(f));
            EnvelopedCms envelopedCms = new EnvelopedCms();
            var certs = new X509Certificate2Collection();
            certs.Add(certificate);
            envelopedCms.Decode(f);
            envelopedCms.Decrypt(certs);
            SaveFile($@"C:\Users\Alessandro Grando\Documents\DOCMA_Service\{fileName}_decrypt_KOW.pdf", envelopedCms.ContentInfo.Content);
        }
        public static byte[] LoadFile(string path) {
            try {
                return System.IO.File.ReadAllBytes(path);
            } catch (Exception ex) {
                throw new Exception("[FileSystemManager.LoadFile] " + ex.Message);
            }
        }
        public static X509Certificate2 LoadCertificate(string path, string password) {
            var collection = new X509Certificate2Collection();
            collection.Import(path, password, X509KeyStorageFlags.PersistKeySet);
            return collection[2];
        }
        public static void SaveFile(string path, byte[] content) {
            try {

                System.IO.File.WriteAllBytes(path, content);

            } catch (Exception ex) {
                throw new Exception("[FileSystemManager.SaveFile] " + ex.Message);
            }
        }
        public static string EncryptContent(string content, X509Certificate2 certificate) {
            byte[] contentBytes = Encoding.ASCII.GetBytes(content);

            var envelopedCms = new EnvelopedCms(SubjectIdentifierType.IssuerAndSerialNumber, new ContentInfo(contentBytes));
            var recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, certificate);

            envelopedCms.Encrypt(recipient);
            var encodedData = envelopedCms.Encode();
            var encodedDataBase64 = Convert.ToBase64String(encodedData, Base64FormattingOptions.InsertLineBreaks);

            return encodedDataBase64;
        }

        public static X509Certificate2 GetX509Certificate(string serialNumber, bool otherPeople) {
            if (string.IsNullOrEmpty(serialNumber))
                return (X509Certificate2)null;
            X509Store x509Store = new X509Store(otherPeople ? StoreName.AddressBook : StoreName.My, StoreLocation.CurrentUser);
            if (x509Store != null) {
                x509Store.Open(OpenFlags.OpenExistingOnly | OpenFlags.IncludeArchived);
                try {
                    X509Certificate2Collection certificate2Collection = x509Store.Certificates.Find(X509FindType.FindByThumbprint, (object)serialNumber, false);
                    if (certificate2Collection != null) {
                        if (certificate2Collection.Count > 0)
                            return certificate2Collection[0];
                    }
                } finally {
                    x509Store.Close();
                }
            }
            return (X509Certificate2)null;
        }
    }


}
