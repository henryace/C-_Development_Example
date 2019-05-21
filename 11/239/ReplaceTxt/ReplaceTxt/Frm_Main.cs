using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex09_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText.ToString() == "")
            {
                MessageBox.Show(//彈出提示訊息
                    "請選重要替換的文字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.richTextBox1.SelectedText = txt_Content.Text;//替換選中的文字
            }
        }
    }
}