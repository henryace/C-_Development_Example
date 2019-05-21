using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetYear
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetMessage_Click(object sender, EventArgs e)
        {
            ushort P_usint_temp;//定義局部變數
            if (ushort.TryParse(//將輸入字符串轉換為數值
                txt_year.Text, out P_usint_temp))
            {
                MessageBox.Show(//輸出計算結果
                    (P_usint_temp % 4 == 0 && P_usint_temp % 100 != 0)//判斷是否為閏年
                    || P_usint_temp % 400 == 0 ? "輸入的是閏年！" : "輸入的不是閏年！",
                    "提示！");
            }
            else
            {
                MessageBox.Show(//提示輸入數值不正確
                    "請輸入正確數值！", "提示！");
            }
        }
    }
}
