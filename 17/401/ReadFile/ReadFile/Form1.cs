using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "文字檔案(*.txt)|*.txt";//設定打開檔案的類型
                openFileDialog1.ShowDialog();
                textBox1.Text = openFileDialog1.FileName;//設定打開的檔案名稱
                FileStream fs = File.OpenRead(textBox1.Text);//打開現有檔案以進行讀取
                byte[] b = new byte[1024];//定義暫存
                while (fs.Read(b, 0, b.Length) > 0)//循環每次讀取1024個字節到暫存中
                {
                    textBox2.Text = Encoding.Default.GetString(b);//把字節陣列所有字節轉為一個字串
                }
            }
            catch { MessageBox.Show("請選擇檔案"); }
        }
    }
}
