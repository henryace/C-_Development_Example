using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GetCount
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetCount_Click(object sender, EventArgs e)
        {
            int P_scalar = 0;//定義值類型變數並賦值為0
            Regex P_regex = //建立正則表達式對象，用於判斷字符是否為中文字
                new Regex("^[\u4E00-\u9FA5]{0,}$");
            for (int i = 0; i < txt_str.Text.Length; i++)//深度搜尋字串中每一個字符
            {
                P_scalar = //如果檢查的字符是中文字則計數器加1
                    P_regex.IsMatch(txt_str.Text[i].
                    ToString()) ? ++P_scalar : P_scalar;
            }
            txt_count.Text = P_scalar.ToString();//顯示中文字數量
        }
    }
}
