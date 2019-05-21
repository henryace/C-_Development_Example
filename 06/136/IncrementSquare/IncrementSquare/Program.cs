using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncrementSquare
{
    class Program
    {
        public string sum(int num)
        {
            string P_str_Expression = "";//定義一個字串，用來記錄表達式
            double sum = 0;//定義一個變數，用來記錄結果 
            for (int i = 1; i <= num; i++)//深度搜尋所有要計算的數
            {
                sum += Convert.ToDouble(Math.Pow(i, i));//計算結果並記錄
                P_str_Expression += i + "的" + i + "次冪" + " + ";//記錄表達式
            }
            return P_str_Expression.Remove(P_str_Expression.Length - 3) + " = " + sum;//返回表達式和結果
        }
        static void Main(string[] args)
        {
            while (true)//定義一個循環，以便循環輸入資料
            {
                Console.Write("請輸入一個整數:");
                int num = Convert.ToInt32(Console.ReadLine());//記錄要計算的數
                Program program = new Program();//建立Program物件
                Console.WriteLine(program.sum(num));//輸出結果
            }
        }
    }
}
