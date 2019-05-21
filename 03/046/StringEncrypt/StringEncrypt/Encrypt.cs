using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace StringEncrypt
{
    public class Encrypt
    {

        internal string ToEncrypt(string encryptKey, string str)
        {
            try
            {
                byte[] P_byte_key = //將密鑰字串轉換為字節序列
                    Encoding.Unicode.GetBytes(encryptKey);
                byte[] P_byte_data = //將字串轉換為字節序列
                    Encoding.Unicode.GetBytes(str);
                MemoryStream P_Stream_MS = //建立記憶體流對像
                    new MemoryStream();
                CryptoStream P_CryptStream_Stream = //建立加密流對像
                    new CryptoStream(P_Stream_MS, new DESCryptoServiceProvider().
                   CreateEncryptor(P_byte_key, P_byte_key), CryptoStreamMode.Write);
                P_CryptStream_Stream.Write(//向加密流中寫入字節序列
                    P_byte_data, 0, P_byte_data.Length);
                P_CryptStream_Stream.FlushFinalBlock();//將資料壓入基礎流
                byte[] P_bt_temp =//從記憶體流中取得字節序列
                    P_Stream_MS.ToArray();
                P_CryptStream_Stream.Close();//關閉加密流
                P_Stream_MS.Close();//關閉記憶體流
                return //方法返回加密後的字串
                    Convert.ToBase64String(P_bt_temp);
            }
            catch (CryptographicException ce)
            {
                throw new Exception(ce.Message);
            }
        }

        internal string ToDecrypt(string encryptKey, string str)
        {
            try
            {
                byte[] P_byte_key = //將密鑰字串轉換為字節序列
                    Encoding.Unicode.GetBytes(encryptKey);
                byte[] P_byte_data = //將加密後的字串轉換為字節序列
                    Convert.FromBase64String(str);
                MemoryStream P_Stream_MS =//建立記憶體流對象並寫入資料
                    new MemoryStream(P_byte_data);
                CryptoStream P_CryptStream_Stream = //建立加密流對像
                    new CryptoStream(P_Stream_MS, new DESCryptoServiceProvider().
                    CreateDecryptor(P_byte_key, P_byte_key), CryptoStreamMode.Read);
                byte[] P_bt_temp = new byte[200];//建立字節序列對像
                MemoryStream P_MemoryStream_temp =//建立記憶體流對像
                    new MemoryStream();
                int i = 0;//建立記數器
                while ((i = P_CryptStream_Stream.Read(//使用while循環得到解密資料
                    P_bt_temp, 0, P_bt_temp.Length)) > 0)
                {
                    P_MemoryStream_temp.Write(//將解密後的資料放入記憶體流
                        P_bt_temp, 0, i);
                }
                return //方法返回解密後的字串
                    Encoding.Unicode.GetString(P_MemoryStream_temp.ToArray());
            }
            catch (CryptographicException ce)
            {
                throw new Exception(ce.Message);
            }
        }
    }
}
