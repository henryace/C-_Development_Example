using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayUser
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Frm_Main fm = (Frm_Main)this.Owner;//得到主視窗物件
            fm.user = txt_User.Text;//設定主視窗欄位
            this.Close();//關閉目前視窗
        }
    }
}
