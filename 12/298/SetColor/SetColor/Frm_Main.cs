using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();//彈出顏色選擇對話框
            textBox1.ForeColor = colorDialog1.Color;//設定文字顏色
        }
    }
}