using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SealedUserInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 透過sealed關鍵字聲明密封類別，防止類別被繼承，有效保護重要訊息
        /// </summary>
        public sealed class myClass
        {
            private string name = "";//string類型變數,用來記錄用戶名
            private string pwd = "";//string類型變數,用來記錄密碼
            /// <summary>
            /// 用戶名
            /// </summary>
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            /// <summary>
            /// 密碼
            /// </summary>
            public string Pwd
            {
                get
                {
                    return pwd;
                }
                set
                {
                    pwd = value;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出目前應用程式
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("用戶名和密碼不能為空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                myClass myclass = new myClass();	//實例化密封類別物件
                myclass.Name = txtUser.Text;				//為密封類別中的編號屬性賦值
                myclass.Pwd = txtPwd.Text;				//為密封類別中的名稱屬性賦值
                MessageBox.Show("登入成功，用戶名：" + myclass.Name + " 密碼：" + myclass.Pwd, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
