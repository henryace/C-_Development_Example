using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SerchFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("請輸入要搜尋的檔案");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("請輸入要搜尋的目錄");
                return;
            }

            listView1.Items.Clear();
            SearchFile(textBox2.Text);
            MessageBox.Show("搜尋完畢");
        }
        //自定義方法，用於在指定的文件夾下搜索文件
        public void SearchFile(string fileDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(fileDirectory);			//實例化DirectoryInfo類
            FileSystemInfo[] f = dir.GetFileSystemInfos();					//取得文件夾下文件
            foreach (FileSystemInfo i in f)								//對指定的文件夾進行深度搜尋
            {
                if (i is DirectoryInfo)								//如果是文件夾
                {
                    SearchFile(i.FullName);							//遞迴呼叫
                }
                else
                {
                    if (i.Name == textBox1.Text)						//如果等於指定的文件名
                    {
                        FileInfo fin = new FileInfo(i.FullName);			//實例化FileInfo類
                        listView1.Items.Add(fin.Name);					//為ListView新增文件的名稱
                        //為ListView新增文件的路徑
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fin.FullName);
                        //為ListView新增文件大小
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fin.Length.ToString());
                        //為ListView新增文件的建立時間
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fin.CreationTime.ToString());
                    }
                }
            }
        }
    }
}