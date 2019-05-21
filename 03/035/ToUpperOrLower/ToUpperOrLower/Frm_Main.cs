using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToUpperOrLower
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (rbtn_upper.Checked)//判斷字串轉換為大寫或小寫
            {
                txt_changed.Text = //將字串轉換為大寫
                    txt_string.Text.ToUpper();
            }
            else
            {
                txt_changed.Text = //將字串轉換為小寫
                    txt_string.Text.ToLower();
            }
        }

        private void txt_string_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_string.Text == "          請輸入字串")
            {
                txt_string.Text = //清空TextBox控制元件中的文字訊息
                    string.Empty;
            }
        }
    }
}
