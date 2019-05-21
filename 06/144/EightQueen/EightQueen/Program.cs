using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueen
{
    class Program
    {
        #region 解決八皇后問題
        /// <summary>
        /// 解決八皇后問題
        /// </summary>
        /// <param name="size">皇后數量</param>
        static void QueenArithmetic(int size)
        {
            int[] Queen = new int[size];//每行皇后的位置
            int y, x, i, j, d, t = 0;
            y = 0;
            Queen[0] = -1;
            while (true)
            {
                for (x = Queen[y] + 1; x < size; x++)
                {
                    for (i = 0; i < y; i++)
                    {
                        j = Queen[i];
                        d = y - i;
                        //檢查新皇后是否能與以前的皇后相互攻擊
                        if ((j == x) || (j == x - d) || (j == x + d))
                            break;
                    }
                    if (i >= y)
                        break;//不攻擊
                }
                if (x == size) //沒有合適的位置
                {
                    if (0 == y)
                    {
                        //回溯到了第一行
                        Console.WriteLine("Over");
                        break; //結束
                    }
                    //回溯
                    Queen[y] = -1;
                    y--;
                }
                else
                {
                    Queen[y] = x;//確定皇后的位置
                    y++;//下一個皇后
                    if (y < size)
                        Queen[y] = -1;
                    else
                    {
                        //所有的皇后都排完了，輸出
                        Console.WriteLine("\n" + ++t + ':');
                        for (i = 0; i < size; i++)
                        {
                            for (j = 0; j < size; j++)
                                Console.Write(Queen[i] == j ? 'Q' : '*');
                            Console.WriteLine();
                        }
                        y = size - 1;//回溯
                    }
                }
            }
            Console.ReadLine();
        }
        #endregion

        static void Main(string[] args)
        {
            int size = 8;//皇后數
            QueenArithmetic(size);
        }
    }
}
