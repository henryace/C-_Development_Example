using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeleteDirByDG
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
            if (FBDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了資料夾
                textBox1.Text = FBDialog.SelectedPath;//顯示選擇的資料夾
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text);//建立DirectoryInfo物件
            FileSystemInfo[] FSInfo = DInfo.GetFileSystemInfos();//取得所有檔案
            for (int i = 0; i < FSInfo.Length; i++)//深度搜尋取得到的檔案
            {
                FileInfo FInfo = new FileInfo(textBox1.Text + "\\" + FSInfo[i].ToString());//建立FileInfo物件
                FInfo.Delete();//刪除檔案
            }
            MessageBox.Show("刪除成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}