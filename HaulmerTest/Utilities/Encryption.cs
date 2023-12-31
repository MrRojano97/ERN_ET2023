using System.Security.Cryptography;
using System.Text;

namespace HaulmerTest.Utilities {
    public static class CryptoHelper {
        private static readonly byte[] key = Encoding.UTF8.GetBytes("Password16Bytes!"); // Debe ir una clave de 16 bytes (16 caracteres)
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("16BytesPassword!");  // Debe ir una clave de 16 bytes (16 caracteres)

        public static string EncryptString(string plainText) {
            using (var aes = Aes.Create()) {
                aes.Key = key;
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream()) {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))

                    sw.Write(plainText);

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string DecryptString(string encryptedText) {
            using (var aes = Aes.Create()) {
                aes.Key = key;
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                
                return sr.ReadToEnd();
            }
        }
    }
}
