using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HelpDesk.Common
{
    public static class SimpleEncryption
    {        
        private static string password = "MyHelpDeskApp2025!";

        public static string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
                        
            byte[] key = Encoding.UTF8.GetBytes(password.PadRight(32).Substring(0, 32));
            byte[] iv = Encoding.UTF8.GetBytes(password.PadRight(16).Substring(0, 16));

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(text);
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return encryptedText;

            try
            {                
                byte[] key = Encoding.UTF8.GetBytes(password.PadRight(32).Substring(0, 32));
                byte[] iv = Encoding.UTF8.GetBytes(password.PadRight(16).Substring(0, 16));

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    byte[] encryptedData = Convert.FromBase64String(encryptedText);

                    using (MemoryStream ms = new MemoryStream(encryptedData))
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {                
                return encryptedText;
            }
        }
    }
}