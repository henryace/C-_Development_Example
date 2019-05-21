using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GetFoldCTime
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
                textBox1.Text = strPath;//顯示選擇的資料夾
                DirectoryInfo DInfo = new DirectoryInfo(strPath);//建立DirectoryInfo物件
                label2.Text = "建立時間：" + DInfo.CreationTime.ToString();//顯示資料夾建立時間
            }
        }
    }
}
