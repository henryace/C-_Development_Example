using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MoveDir
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        FolderBrowserDialog FBDialog = new FolderBrowserDialog();//建立FolderBrowserDialog物件
        private void button1_Click(object sender, EventArgs e)
        {
            if (FBDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了原資料夾
                textBox1.Text = FBDialog.SelectedPath;//顯示原資料夾
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FBDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了目標資料夾
                textBox2.Text = FBDialog.SelectedPath;//顯示目標資料夾
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text);//建立DirectoryInfo物件
                //設定移動路徑
                string strPath = textBox2.Text + textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1, textBox1.Text.Length - textBox1.Text.LastIndexOf("\\") - 1);
                DInfo.MoveTo(strPath);//移動資料夾
            }
            catch { MessageBox.Show("移動的檔案必須在同一磁碟機內！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}