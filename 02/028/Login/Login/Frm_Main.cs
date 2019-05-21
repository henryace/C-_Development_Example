using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (cbox_select.SelectedItem.//判斷用戶登陸訊息
                ToString() == "admin")
            {
                MessageBox.Show(//如果是admin登陸則提示管理員登陸
                    "管理員登入", "提示！");
            }
            else
            {
                MessageBox.Show(//如果是user登陸則提示普通用戶登陸
                    "普通用戶登入", "提示！");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//默認選擇combobox中的第一項
        }
    }
}
