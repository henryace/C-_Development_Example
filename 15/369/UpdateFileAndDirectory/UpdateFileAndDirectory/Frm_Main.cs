using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace UpdateFileAndDirectory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();							//清空
            folderBrowserDialog1.ShowDialog();				//打開文件夾對話框
            textBox1.Text = folderBrowserDialog1.SelectedPath;	//顯示選擇的文件夾路徑
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);	//實例化DirectoryInfo類
            FileSystemInfo[] f = dir.GetFileSystemInfos();
            //FileInfo[] f = dir.GetFiles();  						//將指定文件夾下的所有文件和文件夾存入到FileInfo[]中
            for (int i = 0; i < f.Length; i++)					//深度搜尋FileInfo[]
            {
                listBox1.Items.Add(f[i]);						//向listBox1控制元件中新增文件和文件夾的名稱
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(listBox1.SelectedItem.ToString()))
                Directory.Move(textBox1.Text + "\\" + listBox1.SelectedItem.ToString(), textBox1.Text + "\\" + textBox2.Text);//移動目錄
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Move(textBox1.Text + "\\" + listBox1.SelectedItem.ToString(), textBox1.Text + "\\" + textBox2.Text);//移動文件
        }
    }
}