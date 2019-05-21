using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transform
{
    class Upper
    {
        public string NumToChinese(string x)
        {
            //數字轉換為中文後的陣列
            string[] P_array_num = new string[] { "零", "壹", "貳", "三", "肆", "伍", "陸", "柒", "捌", "玖" };
            //為數字位數建立一個位陣列
            string[] P_array_digit = new string[] { "", "拾", "佰", "仟" };
            //為數字單位建立一個單位陣列
            string[] P_array_units = new string[] { "", "萬", "億", "萬億" };
            string P_str_returnValue = ""; //返回值
            int finger = 0; //字符位置指針
            int P_int_m = x.Length % 4; //取模
            int P_int_k = 0;
            if (P_int_m > 0)
                P_int_k = x.Length / 4 + 1;
            else
                P_int_k = x.Length / 4;
            //外層循環,四位一組,每組最後加上單位: ",萬億,",",億,",",萬,"
            for (int i = P_int_k; i > 0; i--)
            {
                int P_int_L = 4;
                if (i == P_int_k && P_int_m != 0)
                    P_int_L = P_int_m;
                //得到一組四位數
                string four = x.Substring(finger, P_int_L);
                int P_int_l = four.Length;
                //內層循環在該組中的每一位數上循環
                for (int j = 0; j < P_int_l; j++)
                {
                    //處理組中的每一位數加上所在的位
                    int n = Convert.ToInt32(four.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < P_int_l - 1 && Convert.ToInt32(four.Substring(j + 1, 1)) > 0 && !P_str_returnValue.EndsWith(P_array_num[n]))
                            P_str_returnValue += P_array_num[n];
                    }
                    else
                    {
                        if (!(n == 1 && (P_str_returnValue.EndsWith(P_array_num[0]) | P_str_returnValue.Length == 0) && j == P_int_l - 2))
                            P_str_returnValue += P_array_num[n];
                        P_str_returnValue += P_array_digit[P_int_l - j - 1];
                    }
                }
                finger += P_int_L;
                //每組最後加上一個單位:",萬,",",億," 等
                if (i < P_int_k) //如果不是最高位的一組
                {
                    if (Convert.ToInt32(four) != 0)
                        //如果所有4位不全是0則加上單位",萬,",",億,"等
                        P_str_returnValue += P_array_units[i - 1];
                }
                else
                {
                    //處理最高位的一組,最後必須加上單位
                    P_str_returnValue += P_array_units[i - 1];
                }
            }
            return P_str_returnValue;
        }
    }
}

