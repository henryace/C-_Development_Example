using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Transform
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_transform_Click(object sender, EventArgs e)
        {
            int P_int_temp;//定義整型變數
            if (int.TryParse(txt_lower.Text, out P_int_temp))
            {
                txt_upper.Text = //取得轉換為大寫金額的字串
                    new Upper().NumToChinese(txt_lower.Text);
            }
            else
            {
                MessageBox.Show(//錯誤提示訊息
                    "請輸入正確整數數值", "提示！");
            }
        }
    }
}
