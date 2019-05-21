using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                char chr = txt_chr.Text[0];//獲得一個中文字符
                byte[] big5_bt = //使用big5編碼方式獲得字節序列
                    Encoding.GetEncoding("big5").GetBytes(new Char[] { chr });
                int n = (int)big5_bt[0] << 8;//將字節序列的第一個字節向左移8位
                n += (int)big5_bt[1];//第一個字節移8位後與第二個字節相加得到中文編碼
                txt_Num.Text = n.ToString();//顯示漢字編碼
            }
            catch (Exception)
            {
                MessageBox.Show(//異常提示訊息
                    "請輸入中文字符！", "出現錯誤！");
            }
        }
    }
}
