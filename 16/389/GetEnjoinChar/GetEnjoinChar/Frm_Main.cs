using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GetEnjoinChar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;//清空文字框
            char[] myChars = Path.GetInvalidPathChars();//建立字串陣列
            String myInfo = string.Empty;//定義空字串
            foreach (char myChar in myChars)//深度搜尋字符陣列
            {
                myInfo += myChar.ToString() + "\n";//取得字符陣列中的項
            }
            richTextBox1.Text = myInfo;//顯示禁用的所有字符
        }
    }
}