using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaesarArithmetic
{
    class Program
    {
        //取得字符的ASCII碼
        public int AscII(string str)
        {
            byte[] array = new byte[1];//建立字節陣列
            array = System.Text.Encoding.ASCII.GetBytes(str);//為字節陣列賦值
            int asciicode = (short)(array[0]);//取得字節陣列的第一項
            return asciicode;//返回字節陣列的第一項
        }
        public string Caesar(string str)//凱撒加密算法的實現
        {
            char[] c = str.ToCharArray();//建立字符陣列
            string strCaesar = "";//定義一個變數，用來存儲加密後的字串
            for (int i = 0; i < str.Length; i++)//深度搜尋字串中的每一個字串
            {
                string ins = c[i].ToString();//記錄深度搜尋到的字符
                string outs = "";//定義一個變數，用來記錄加密後的字串
                bool isChar = "0123456789abcdefghijklmnopqrstuvwxyz".Contains(ins.ToLower());//判斷指定的字串中是否包含深度搜尋到的字符
                bool isToUpperChar = isChar && (ins.ToUpper() == ins);//判斷深度搜尋到的字符是否是大寫
                ins = ins.ToLower();//將深度搜尋到的字符轉換為小寫
                if (isChar)//判斷指定的字串中是否包含深度搜尋到的字符
                {
                    int offset = (AscII(ins) + 5 - AscII("a")) % (AscII("z") - AscII("a") + 1);//取得字符的ASCII碼
                    outs = Convert.ToChar(offset + AscII("a")).ToString();//轉換為字符並記錄
                    if (isToUpperChar)//判斷是否大寫
                    {
                        outs = outs.ToUpper();//全部轉換為大寫
                    }
                }
                else
                {
                    outs = ins;//記錄深度搜尋的字符
                }
                strCaesar += outs;//新增到加密字串中
            }
            return strCaesar;//返回加密後的字串
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入密碼：");
                string P_str_Code = Console.ReadLine();//記錄要加密的密碼
                Program program = new Program();//建立Program物件
                Console.WriteLine("使用凱撒演算法加密後的結果為：" + program.Caesar(P_str_Code));//輸出加密後的字串
            }
        }
    }
}
