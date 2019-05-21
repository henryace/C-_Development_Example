using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace RGBValue
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //設定文件的類型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog(); 									//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根據文件的路徑實例化Image類
            pictureBox1.Image = myImage; 									//顯示打開的圖片
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;//實例化Bitmap類
            try
            {
                Color pointColor = bmp.GetPixel(e.X, e.Y);						//取得目前象素的顏色值
                //分別透過呼叫Color對象的R、G、B屬性取得指定點的R、G、B值
                textBox1.Text = pointColor.R.ToString();
                textBox2.Text = pointColor.G.ToString();
                textBox3.Text = pointColor.B.ToString();
            }
            catch { }
        }
    }
}