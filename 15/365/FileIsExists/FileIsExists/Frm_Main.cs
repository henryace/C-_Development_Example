using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileIsExists
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "所有檔案(*.*)|*.*";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))//判斷檔案是否存在
                MessageBox.Show("該檔案已經存在");
            else
                MessageBox.Show("該檔案不存在");
        }

    }
}
