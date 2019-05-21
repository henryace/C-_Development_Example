using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CheckBoxInStatusBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)//當復選框checkBox2處於選中狀態時
            {
                statusStrip1.Items[1].Text = "日期:" + DateTime.Now.ToString();	//在控制元件statusStrip1中顯示系統目前日期
            }
            else							//當復選框checkBox2處於未選中狀態時
            {
                statusStrip1.Items[1].Text = "";	//控制元件statusStrip1的內容設定為空
            }
        }
    }
}