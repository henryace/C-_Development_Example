using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YHSJ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] Array_int = new int[10][];//定義一個10行的二維陣列
            //向陣列中記錄楊輝三角形的值
            for (int i = 0; i < Array_int.Length; i++)//深度搜尋行數
            {
                Array_int[i] = new int[i + 1];//定義二維陣列的列數
                for (int j = 0; j < Array_int[i].Length; j++)//深度搜尋二維陣列的列數
                {
                    if (i <= 1)//如果是陣列的前兩行
                    {
                        Array_int[i][j] = 1;//將其設定為1
                        continue;
                    }
                    else
                    {
                        if (j == 0 || j == Array_int[i].Length - 1)//如果是行首或行尾
                            Array_int[i][j] = 1;//將其設定為1
                        else
                            Array_int[i][j] = Array_int[i - 1][j - 1] + Array_int[i - 1][j];//根據楊輝算法進行計算
                    }
                }
            }
            for (int i = 0; i < Array_int.Length; i++)//輸出楊輝三角形
            {
                for (int j = 0; j < Array_int[i].Length; j++)
                    Console.Write("{0}\t", Array_int[i][j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
