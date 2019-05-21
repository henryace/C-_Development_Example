using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetFont
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowDialog();//彈出字體選擇對話框
            this.textBox1.Font = //設定文字字體
                this.fontDialog1.Font;
        }
    }
}