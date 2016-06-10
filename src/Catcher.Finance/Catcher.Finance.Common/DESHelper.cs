using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Catcher.Finance.Common
{
    public class DESHelper
    {
        static string DES_Key = "cAtChEr8";

        /// <summary>
        /// DES Encrypt
        /// </summary>
        /// <param name="data">the data to encrypt</param>
        /// <returns></returns>
        public static string DESEncrypt(string data)
        {
            try
            {
                string timeStamp = DateTime.Now.ToString("fff");

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(data + timeStamp);

                des.Key = ASCIIEncoding.ASCII.GetBytes(DES_Key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(DES_Key);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                byte[] buffer = ms.ToArray();
                ms.Close();

                return Convert.ToBase64String(buffer);
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                return "";                
            }            
        }

        /// <summary>
        /// DES Decrypt
        /// </summary>
        /// <param name="data">the data to decrypt</param>
        /// <returns></returns>
        public static string DESDecrypt(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return data;
            }
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = Convert.FromBase64String(data);

                des.Key = ASCIIEncoding.ASCII.GetBytes(DES_Key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(DES_Key);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                string result = Encoding.UTF8.GetString(ms.ToArray());

                result = result.Remove(result.Length - 3, 3);

                return result;
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                return "";
            }            
        }
    }
}