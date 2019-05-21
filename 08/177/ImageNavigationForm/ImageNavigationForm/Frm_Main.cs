using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageNavigationForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = true;//設定button5控制元件可見
            button6.Visible = true;//設定button6控制元件可見
            button7.Visible = true;//設定button7控制元件可見
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button8.Visible = true;//設定button8控制元件可見
            button9.Visible = true;//設定button9控制元件可見
            button10.Visible = true;//設定button10控制元件可見
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button11.Visible = true;//設定button1控制元件可見
            button12.Visible = true;//設定button2控制元件可見
            button13.Visible = true;//設定button3控制元件可見
        }
    }
}