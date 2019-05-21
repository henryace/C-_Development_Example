using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace WordInForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {

        }

        private void 打開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_GetFile = new OpenFileDialog();//建立打開檔案對話框物件
            DialogResult P_dr = P_GetFile.ShowDialog();//顯示打開檔案對話框
            if (P_dr == DialogResult.OK)//是否點擊確定
            {
                WebBrowser.Navigate(P_GetFile.FileName);//打開Word文檔並顯示
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//關閉目前視窗
        }
    }
}
