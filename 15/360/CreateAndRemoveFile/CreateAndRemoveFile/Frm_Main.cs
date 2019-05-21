using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateAndRemoveFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            SaveFileDialog P_SaveFileDialog = new SaveFileDialog();//建立儲存文件對話框物件
            if (P_SaveFileDialog.ShowDialog() == DialogResult.OK)//判斷是否確定儲存檔案
            {
                File.Create(P_SaveFileDialog.FileName);//建立文件
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = new OpenFileDialog();//建立打開文件對話框物件
            if (P_OpenFileDialog.ShowDialog() == DialogResult.OK)//判斷是否確定刪除檔案
            {
                File.Delete(P_OpenFileDialog.FileName);//刪除文件
            }
        }
    }
}
