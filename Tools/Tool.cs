﻿using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
    public static class Tool
    {
        /// <summary>
        /// kook解密方法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryptKey"></param>
        /// <returns></returns>
        public static string Decrypt(string data, string encryptKey)
        {
            // 在 encrypKey 右侧填充 \0 到 32 位
            encryptKey = encryptKey.PadRight(32, '\0');

            // 用 base64 解析原密文
            var originCipher = Encoding.UTF8.GetString(Convert.FromBase64String(data));
            // 取前 16 位为 iv，16 位后的文本为新密文
            var iv = originCipher.Substring(0, 16);
            var newCipher = originCipher.Substring(16);

            // 用 base64 解密新密文
            var newCipherByte = Convert.FromBase64String(newCipher);

            // 使用 aes-256-cbc 解密数据
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptKey);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(newCipherByte))
                using (var csDecrypt = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(csDecrypt))
                    return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 通过实体类拼装Get请求参数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetArgsInClass(object args)
        {
            string data = "";
            Type type = args.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                var objValue = prop.GetValue(args);
                if (objValue != null)
                {
                    data += "&" + prop.Name + "=" + objValue;
                }
            }
            return data.Remove(0, 1);
        }
    }
}
