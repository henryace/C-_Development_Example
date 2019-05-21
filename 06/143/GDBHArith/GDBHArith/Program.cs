using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDBHArith
{
    class Program
    {
        #region  判斷一個數是否是素數
        /// <summary>
        /// 判斷一個數是否是素數
        /// </summary>
        /// <param name="intNum">要判斷的數</param>
        /// <returns>如果是，返回true,否則，返回false</returns>
        static bool IsPrimeNumber(int intNum)
        {
            bool blFlag = true;                 //標識是否是素數
            if (intNum == 1 || intNum == 2)     //判斷輸入的數字是否是1或者2
                blFlag = true;                  //為bool類型變數賦值
            else
            {
                int sqr = Convert.ToInt32(Math.Sqrt(intNum));   //對要判斷的數字進行開方運算
                for (int i = sqr; i >= 2; i--)  //從開方後的數進行循環
                {
                    if (intNum % i == 0)        //對要判斷的數字和指定數字進行求余運算
                    {
                        blFlag = false;         //如果餘數為0，說明不是素數
                    }
                }
            }
            return blFlag;                      //返回bool型變數
        }
        #endregion

        #region 判斷一個數是否符合哥德巴赫猜想
        /// <summary>
        /// 判斷一個數是否符合哥德巴赫猜想
        /// </summary>
        /// <param name="intNum">要判斷的數</param>
        /// <returns>如果符合，返回true，否則，返回false</returns>
        static bool ISGDBHArith(int intNum)
        {
            bool blFlag = false;                //標識是否符合哥德巴赫猜想
            if (intNum % 2 == 0 && intNum > 6)  //對要判斷的數字進行判斷
            {
                for (int i = 1; i <= intNum / 2; i++)
                {
                    bool bl1 = IsPrimeNumber(i);             //判斷i是否為素數
                    bool bl2 = IsPrimeNumber(intNum - i);    //判斷intNum-i是否為素數
                    if (bl1 & bl2)
                    {
                        //輸出等式
                        Console.WriteLine("{0}={1}+{2}", intNum, i, intNum - i);
                        blFlag = true;          //符合哥德巴赫猜想
                    }
                }
            }
            return blFlag;                      //返回bool型變數
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("輸入一個大於6的偶數:");          //提示輸入訊息
            int intNum = Convert.ToInt32(Console.ReadLine());   //記錄輸入的數字
            bool blFlag = ISGDBHArith(intNum);                  //判斷是否符合哥德巴赫猜想
            if (blFlag)                                         //如果為true，說明符合，並輸出訊息
            {
                Console.WriteLine("{0}能寫成兩個素數的和,所以其符合哥德巴赫猜想。", intNum);
            }
            else
            {
                Console.WriteLine("猜想錯誤。");
            }
            Console.ReadLine();
        }
    }
}
