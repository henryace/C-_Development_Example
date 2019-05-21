using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileExt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog =//建立打開文件對話框物件
              new OpenFileDialog();
            if (P_OpenFileDialog.ShowDialog() == DialogResult.OK)//判斷是選中文件
            {
                MessageBox.Show("檔案副檔名：" +//彈出消息對話框
                    P_OpenFileDialog.FileName.Substring(
                    P_OpenFileDialog.FileName.LastIndexOf(".") + 1,
                    P_OpenFileDialog.FileName.Length -
                P_OpenFileDialog.FileName.LastIndexOf(".") - 1), "提示！");
            }
        }
    }
}
