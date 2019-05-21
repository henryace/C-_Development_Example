using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReplaceStr
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strResult = System.Text.RegularExpressions.Regex.//使用正規化運算式替換字串
                Replace(textBox1.Text, @"[A-Za-z]\*?", textBox2.Text);
            MessageBox.Show("替換前字符:" + "\n" + textBox1.Text +//彈出消息對話框
                "\n" + "替換的字符:" + "\n" + textBox2.Text + "\n" +
                "替換後的字符:" + "\n" + strResult, "替換");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();//關閉視窗
        }
    }
}