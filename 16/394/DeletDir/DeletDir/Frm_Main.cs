using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeletDir
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
            DInfo.Delete(true);//刪除資料夾所有內容
            MessageBox.Show("刪除資料夾成功！");
        }
    }
}