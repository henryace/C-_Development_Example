using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilePathString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Openfile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了檔案
            {
                string P_str_all = openFileDialog1.FileName;//記錄選擇的檔案全路徑
                string P_str_path = //取得檔案路徑
                    P_str_all.Substring(0, P_str_all.LastIndexOf("\\") + 1);
                string P_str_filename = //取得檔案名
                    P_str_all.Substring(P_str_all.LastIndexOf("\\") + 1,
                    P_str_all.LastIndexOf(".") -
                    (P_str_all.LastIndexOf("\\") + 1));
                string P_str_fileexc = //取得檔案副檔名
                    P_str_all.Substring(P_str_all.LastIndexOf(".") + 1,
                    P_str_all.Length - P_str_all.LastIndexOf(".") - 1);
                lb_filepath.Text = "檔案路徑： " + P_str_path;//顯示檔案路徑
                lb_filename.Text = "檔案名稱： " + P_str_filename;//顯示檔案名
                lb_fileexc.Text = "檔案副檔名： " + P_str_fileexc;//顯示副檔名
            }
        }

    }
}
