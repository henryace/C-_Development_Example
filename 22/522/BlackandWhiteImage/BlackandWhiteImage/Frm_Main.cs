using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlackandWhiteImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image BlackandWhiteEffect(PictureBox Pict)
        {
            int Var_H = Pict.Image.Height;//取得圖像的高度
            int Var_W = Pict.Image.Width;//取得圖像的寬度
            Bitmap Var_bmp = new Bitmap(Var_W, Var_H);//根據圖像的大小實例化Bitmap類
            Bitmap Var_SaveBmp = (Bitmap)Pict.Image;//根據圖像實例化Bitmap類
            //深度搜尋圖像的象素
            for (int i = 0; i < Var_W; i++)
                for (int j = 0; j < Var_H; j++)
                {
                    Color tem_color = Var_SaveBmp.GetPixel(i, j);//取得目前象素的顏色值
                    int tem_r, tem_g, tem_b, tem_Value = 0;//定義變數
                    tem_r = tem_color.R;//取得R色值
                    tem_g = tem_color.G;//取得G色值
                    tem_b = tem_color.B;//取得B色值
                    tem_Value = ((tem_r + tem_g + tem_b) / 3);//用平均值法產生黑白圖像
                    Var_bmp.SetPixel(i, j, Color.FromArgb(tem_Value, tem_Value, tem_Value));//改變目前象素的顏色值
                }
            return Var_bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = BlackandWhiteEffect(pictureBox1);
        }
    }
}
