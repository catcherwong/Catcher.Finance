using System.Text;
using System.Security.Cryptography;

namespace Catcher.Finance.Common
{
    public static class HMACMD5Encrypt
    {
        const string encryptKey = "c1a2t3c4h5e6r.";

        /// <summary>
        /// HMACMD5 encrypt
        /// </summary>
        /// <param name="data">the date to encrypt</param>
        /// <param name="key">the key used in HMACMD5</param>
        /// <returns></returns>
        public static string GetEncryptResult(string data,string key = encryptKey)
        {
            HMACMD5 source = new HMACMD5(Encoding.UTF8.GetBytes(key));
            byte[] buff = source.ComputeHash(Encoding.UTF8.GetBytes(data));
            string result = string.Empty;
            for (int i = 0; i < buff.Length; i++)
            {
                result += buff[i].ToString("X2"); // hex format
            }
            return result;
        }
    }
}
