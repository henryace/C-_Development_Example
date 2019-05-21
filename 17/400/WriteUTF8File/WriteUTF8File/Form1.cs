using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UTF8File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))//若檔案路徑為空
            {
                MessageBox.Show("請設定檔案路徑！");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text.Trim()))//若文字內容為空
            {
                MessageBox.Show("請輸入檔案內容！");
                return;
            }

            if (!File.Exists(textBox1.Text))
            {
                using (StreamWriter sw = File.CreateText(textBox1.Text))//建立或打開一個檔案用於寫入 UTF-8 編碼的文字。
                {
                    sw.WriteLine(textBox2.Text);//把字串寫入文字流
                    MessageBox.Show("檔案建立成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("該檔案已經存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
