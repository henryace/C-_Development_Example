using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SetValue
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            double P_dbl_value;//定義double類型變數
            if (double.TryParse(txt_input.Text, out P_dbl_value))//判斷輸入是否正確
            {
                NumberFormatInfo GN = //實例化NumberFormatInfo物件
                    new CultureInfo("zh-CN", false).NumberFormat;
                GN.CurrencyDecimalDigits = Convert.ToInt32(cbox_select.Text);//設定保留位數
                txt_output.Text = P_dbl_value.ToString("C", GN);//將輸入的小數轉換為貨幣形式
            }
            else
            {
                MessageBox.Show("請輸入正確的數值！", "提示！");//用戶提示訊息
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//設定cbox_select默認選項
        }
    }
}
