using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetMaxCommonDivisor
{
    class Program
    {
        public float maxGongYueShu(int n1, int n2)
        {
            int temp = Math.Max(n1, n2);//求兩個數的最大值
            n2 = Math.Min(n1, n2);//求兩個數中的最小值
            n1 = temp;//記錄臨時值
            while (n2 != 0)
            {
                n1 = n1 > n2 ? n1 : n2;//使n1中的數大於n2中的數
                int m = n1 % n2;//記錄n1求余n2的結果
                n1 = n2;//交換兩個數
                n2 = m;//記錄求餘結果
            }
            return n1;//得到最大公倍數
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入第一個數：");
                int n1 = Convert.ToInt32(Console.ReadLine());//記錄第一個數
                Console.Write("請輸入第二個數：");
                int n2 = Convert.ToInt32(Console.ReadLine());//記錄第二個數
                if (n1 * n2 != 0)//判斷兩個數中的一個是否為0
                {
                    Program program = new Program();//建立Program物件
                    Console.WriteLine("最大公倍數:" + program.maxGongYueShu(n1, n2));//輸出最大公倍數
                }
                else
                {
                    Console.WriteLine("這兩個數不能為0。");
                }
            }
        }
    }
}
