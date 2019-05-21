using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FontForm
{
    public partial class Frm_Main : Form
    {
        Bitmap bit;//宣告點鎮圖物件
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bit = new Bitmap("font.bmp");//從指定的圖像初始化Bitmap類物件
            bit.MakeTransparent(Color.Blue);//使用默認的透明顏色對Bitmap位圖透明
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage((Image)bit, new Point(0, 0));//在指定位置按指定大小繪製圖片的指定部分
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();//關閉目前視窗
        }
    }
}