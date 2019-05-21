using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectMonkeyKing
{
    class Program
    {
        public int King(int M, int N)//總人數 M ，數到第 N 個排除
        {
            int k = 0;//定義一個變數，用來存儲號碼
            for (int i = 2; i <= M; i++)//深度搜尋猴子個數
                k = (k + N) % i;//計算號碼值
            return ++k;//返回猴子號碼
        }
        static void Main(string[] args)
        {
            Program program = new Program();//建立Program物件
            Console.WriteLine("第" + program.King(10, 3) + "號猴子被選為大王。");//輸入被選為大王的號碼
            Console.ReadLine();
        }
    }
}
