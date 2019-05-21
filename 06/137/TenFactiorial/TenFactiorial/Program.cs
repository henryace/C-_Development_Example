using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenFactiorial
{
    class Program
    {
        public double factorial(int num)//計算指定數的階乘
        {
            switch (num)//判斷輸入的數
            {
                case 1://如果是1
                    return 1;//返回1
                default:
                    return num * factorial(num - 1);//計算階乘結果
            }
        }
        static void Main(string[] args)
        {
            while (true)//定義一個循環，以便循環輸入資料
            {
                Console.WriteLine("輸入一個整數：");
                int num = Convert.ToInt32(Console.ReadLine());//記錄輸入的數字
                Program program = new Program();//建立Program物件
                Console.WriteLine("{0}!的值為{1}", num, program.factorial(num));//輸出階乘結果
            }
        }
    }
}
