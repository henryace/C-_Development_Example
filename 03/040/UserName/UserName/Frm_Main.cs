using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "Admin")//判斷是否輸入正確用戶名
            {
                MessageBox.Show("登入成功！", "提示！");//提示登入成功
            }
            else
            {
                MessageBox.Show("用戶名錯誤", "錯誤！");//提示登入不成功
            }
        }
    }
}
