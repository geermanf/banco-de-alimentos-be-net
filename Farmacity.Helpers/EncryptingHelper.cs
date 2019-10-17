using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Farmacity.Helpers
{
    public static class EncryptingHelper
    {
        //length of key is 23 chars estrict
        private const string SecretKey = "C0ntr@s3ñ4-3ncr1pt4c10.";

        /// <summary>
        /// Method for Encription string
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            keyArray = _createMD5CryptoServiceProvider();

            var tdes = _createTripleDESCryptoServiceProvider(keyArray);

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            tdes.Dispose();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string HashPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Encoding.ASCII.GetBytes(salt),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

            return hashed;
        }


        /// <summary>
        /// method for unencrypt string
        /// </summary>
        /// <param name="cipherString"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherString)
        {
            try
            {
                if (String.IsNullOrEmpty(cipherString))
                    return "";
                byte[] keyArray;
                byte[] toEncryptArray;

                try
                {
                    toEncryptArray = Convert.FromBase64String(cipherString);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                keyArray = _createMD5CryptoServiceProvider();

                var tdes = _createTripleDESCryptoServiceProvider(keyArray);

                var cTransform = tdes.CreateDecryptor();
                var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                tdes.Dispose();
                return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static byte[] _createMD5CryptoServiceProvider()
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(SecretKey));
            hashmd5.Clear();
            hashmd5.Dispose();

            return keyArray;
        }

        private static TripleDESCryptoServiceProvider _createTripleDESCryptoServiceProvider(byte[] keyArray)
        {
            return new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
        }
    }
}
