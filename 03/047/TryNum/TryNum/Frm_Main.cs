using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TryNum
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_true_Click(object sender, EventArgs e)
        {
            double P_dbl_value;//定義變數
            if (double.TryParse(//判斷輸入訊息是否正確
                txt_value.Text, out P_dbl_value))
            {
                //txt_value.Clear();//清空TextBox
                MessageBox.Show("輸入的數值正確！");//提示正確訊息
            }
            else
            {
                MessageBox.Show(//提示錯誤訊息
                    "輸入的數值有誤，請重新輸入！", "提示！");
            }
        }
    }
}
