using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateDirByDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();//建立FolderBrowserDialog物件
            if (FBDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇資料夾
            {
                string strPath = FBDialog.SelectedPath;//記錄選擇的資料夾
                if (strPath.EndsWith("\\"))
                    textBox1.Text = strPath;//顯示選擇的資料夾
                else
                    textBox1.Text = strPath + "\\";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strName = DateTime.Now.ToString("yyyyMMddhhmmss");//對目前日期進行格式化
            DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text + strName);//建立DirectoryInfo物件
            DInfo.Create();//建立資料夾
            MessageBox.Show("資料夾建立成功，名稱為" + strName + "");
        }
    }
}