using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MD5Arithmetic
{
    class Program
    {
        public string Encrypt(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();//建立MD5物件
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);//將字符編碼為一個字節序列
            byte[] md5data = md5.ComputeHash(data);//計算data字節陣列的哈希值
            md5.Clear();//清空MD5物件
            string str = "";//定義一個變數，用來記錄加密後的密碼
            for (int i = 0; i < md5data.Length - 1; i++)//深度搜尋字節陣列
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');//對深度搜尋到的字節進行加密
            }
            return str;//返回得到的加密字串
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入密碼：");
                string P_str_Code = Console.ReadLine();//記錄要加密的密碼
                Program program = new Program();//建立Program物件
                Console.WriteLine("使用MD5加密後的結果為：" + program.Encrypt(P_str_Code));//輸出加密後的字串
            }
        }
    }
}
