using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GetFileLength
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
                MessageBox.Show("檔案長度：" +//彈出消息對話框
                    File.Open(P_OpenFileDialog.FileName, FileMode.Open).
                    Length.ToString() + "字節", "提示！");
            }
        }
    }
}
