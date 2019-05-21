using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace GetUpDir
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
            {
                textBox1.Text = FBDialog.SelectedPath;//顯示選擇的資料夾
                string str1 = textBox1.Text;//記錄選擇的資料夾
                string str2 = Directory.GetParent(str1).FullName;//取得上級目錄的全名
                string myInfo = "目前目錄是：" + str1;//顯示目前資料夾
                myInfo += "\n上層目錄是：" + str2;//顯示上層資料夾
                label2.Text = myInfo;
            }
        }
    }
}