using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISDirExist
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(textBox1.Text);//建立DirectoryInfo物件
                if (dirInfo.Exists)//如果資料夾存在
                {
                    MessageBox.Show("資料夾存在");
                }
                else
                {
                    MessageBox.Show("資料夾不存在");
                }
            }
            catch { }
        }
    }
}
