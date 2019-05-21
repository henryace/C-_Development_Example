using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RandomFileName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_FolderBrowserDialog = new FolderBrowserDialog();//建立資料夾對話框物件
            if (P_FolderBrowserDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇資料夾
            {
                File.Create(P_FolderBrowserDialog.SelectedPath + "\\" +//根據GUID產生檔案名稱
                     Guid.NewGuid().ToString() + ".txt");
            }
        }

        private void btn_Drictory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_FolderBrowserDialog = new FolderBrowserDialog();//建立資料夾對話框物件
            if (P_FolderBrowserDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇資料夾
            {
                Directory.CreateDirectory(P_FolderBrowserDialog.SelectedPath +//根據GUID產生資料夾名稱
                    "\\" + Guid.NewGuid().ToString());
            }
        }
    }
}
