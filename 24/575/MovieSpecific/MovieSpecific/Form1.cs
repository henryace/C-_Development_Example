using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieSpecific
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//啟動計時器
            pictureBox1.Visible = false;//隱藏PictureBox控制元件
            label1.Visible = true;//顯示Label控制元件
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;//隱藏Label控制元件
            timer1.Enabled = true;//啟動計時器
            pictureBox1.Visible = true;//顯示PictureBox控制元件
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size + 1);//使字體逐步加一
            pictureBox1.Size = new Size(pictureBox1.Size.Width + 5, pictureBox1.Size.Height + 5);//使圖片逐漸增大
        }
    }
}