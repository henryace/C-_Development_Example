using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Format
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            double P_dbl_temp;//定義double類型變數
            if (double.TryParse(txt_str.Text, out P_dbl_temp))//驗證輸入是否正確並賦值
            {
                System.Globalization.NumberFormatInfo GN =//實例化NumberFormatInfo物件
                    new System.Globalization.
                        CultureInfo("zh-CN", false).NumberFormat;
                GN.CurrencyGroupSeparator = ",";//設定貨幣值中用來分組的字串
                txt_result.Text = P_dbl_temp.ToString("C", GN);//格式化為貨幣格式並顯示
            }
            else
            {
                MessageBox.Show("請輸入正確的貨幣值！", "提示！");//輸出錯誤訊息
            }
        }
    }
}
