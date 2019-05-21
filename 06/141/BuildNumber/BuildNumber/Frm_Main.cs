using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace BuildNumber
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Return)						//如果按下Enter鍵
            {
                if (textBox1.Text.Length > 8)							//如果位數大於8
                {
                    textBox1.Text = textBox1.Text.Substring(0, 8);			//取得前8位數
                }
                else
                {
                    int j = 8 - textBox1.Text.Length;						//確定增加的位數
                    for (int i = 0; i < j; i++)
                    {
                        textBox1.Text = "0" + textBox1.Text;
                    }
                }
            }
        }
    }
}