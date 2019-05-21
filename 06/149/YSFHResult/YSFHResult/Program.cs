using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSFHResult
{
    class Program
    {
        #region 約瑟夫環問題算法
        /// <summary>
        /// 約瑟夫環問題算法
        /// </summary>
        /// <param name="total">總人數</param>
        /// <param name="start">開始報數的人</param>
        /// <param name="alter">要出列的人</param>
        /// <returns>返回一個int類型的一維陣列</returns>
        static int[] Jose(int total, int start, int alter)
        {
            int j, k = 0;
            //intCounts陣列存儲按出列順序的資料，以當結果返回 
            int[] intCounts = new int[total + 1];
            //intPers陣列存儲初始資料 
            int[] intPers = new int[total + 1];
            //對陣列intPers賦初值,第一個人序號為0,第二人為1，依此下去
            for (int i = 0; i < total; i++)
            {
                intPers[i] = i;
            }
            //按出列次序依次存於陣列intCounts中 
            for (int i = total; i >= 2; i--)
            {
                start = (start + alter - 1) % i;
                if (start == 0)
                    start = i;
                intCounts[k] = intPers[start];
                k++;
                for (j = start + 1; j <= i; j++)
                    intPers[j - 1] = intPers[j];
            }
            intCounts[k] = intPers[1];
            //結果返回 
            return intCounts;
        }
        #endregion

        static void Main(string[] args)
        {
            int[] intPers = Jose(12, 3, 4);         //呼叫自定義方法解決約瑟夫環問題
            Console.WriteLine("出列順序：");
            for (int i = 0; i < intPers.Length; i++)
            {
                Console.Write(intPers[i] + " ");//輸出出列順序
            }
            Console.ReadLine();
        }
    }
}
