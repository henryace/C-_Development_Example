using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;

namespace CreateDirectory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public void getFilter(string strPath, string strName)
        {
            string virtualDirName = strName;//虛擬目錄名稱
            string physicalPath = strPath;//虛擬目實際路徑
            this.directoryEntry1.Path = "IIS://localhost/W3SVC/1/ROOT";//取得設定文件的路徑
            this.directoryEntry1.Children.Add(virtualDirName, directoryEntry1.SchemaClassName);
            //對新建立的節點進行操作了
            //設定虛擬目錄指向的物理路徑
            directoryEntry1.Properties["Path"][0] = physicalPath;
            directoryEntry1.Invoke("AppCreate", true);//設定讀取權限
            directoryEntry1.Properties["AccessRead"][0] = false;//設定讀取權限
            directoryEntry1.Properties["ContentIndexed"][0] = true; ;
            directoryEntry1.Properties["DefaultDoc"][0] = "index.asp,Default.aspx"; //設定預設文檔,多值情況下中間用逗號分割
            directoryEntry1.Properties["AppFriendlyName"][0] = virtualDirName;//應用程式名稱
            directoryEntry1.Properties["AccessScript"][0] = true;//執行權限
            directoryEntry1.Properties["DontLog"][0] = true;
            directoryEntry1.Properties["AuthFlags"][0] = 0;//設定目錄的安全性，0表示不允許匿名訪問，1為允許，3為基本身份驗證，7為windows繼承身份驗證
            directoryEntry1.Properties["AuthFlags"][0] = 1;
            directoryEntry1.CommitChanges();//將目錄儲存到IIS中
        }
        //打開文件路徑
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        //設定
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath.ToString() != "" && textBox2.Text != "")
            {
                getFilter(folderBrowserDialog1.SelectedPath, textBox2.Text.TrimEnd());
                MessageBox.Show("設定成功");
            }
            else
            {
                MessageBox.Show("請選擇虛擬目錄的物理路徑或輸入虛擬目錄名稱", "訊息提示");
            }
        }
    }
}