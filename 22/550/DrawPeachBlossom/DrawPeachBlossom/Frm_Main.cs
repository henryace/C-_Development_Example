using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawPeachBlossom
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        int flag = 0;//定義一個標記，用來標記畫桃花的哪個部分
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flag = 0;//標記繪製花骨朵
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            flag = 1;//標記繪製花蕾
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            flag = 2;//標記繪製開花效果
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point myPT = new Point(e.X, e.Y);//取得鼠標單擊位置
            PictureBox pbox = new PictureBox();//實例化PictureBox控制元件
            pbox.Location = myPT;//指定PictureBox控制元件的位置
            pbox.BackColor = Color.Transparent;//設定PictureBox控制元件的背景色
            pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;//設定PictureBox控制元件的圖片顯示方式
            switch (flag)//判斷標記
            {
                case 0:
                    pbox.Size = new System.Drawing.Size(20, 18);//設定PictureBox控制元件大小
                    pbox.Image = Properties.Resources._2;//設定PictureBox控制元件要顯示的圖像
                    break;
                case 1:
                    pbox.Size = new System.Drawing.Size(30, 31);//設定PictureBox控制元件大小
                    pbox.Image = Properties.Resources._3;//設定PictureBox控制元件要顯示的圖像
                    break;
                case 2:
                    pbox.Size = new System.Drawing.Size(34, 30);//設定PictureBox控制元件大小
                    pbox.Image = Properties.Resources._1;//設定PictureBox控制元件要顯示的圖像
                    break;
            }
            if (e.Button == MouseButtons.Left)//判斷是否單擊了鼠標左鍵
            {
                pictureBox1.Controls.Add(pbox);//將把圖片控制元件新增到桃樹上
            }
        }
    }
}
