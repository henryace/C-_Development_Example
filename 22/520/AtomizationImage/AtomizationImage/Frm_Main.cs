using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AtomizationImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image AtomizationEffect(PictureBox Pict, int effect)
        {
            int Var_W = Pict.Width;									//取得圖片的寬度
            int Var_H = Pict.Height;									//取得圖片的高度
            Bitmap Var_bmp = new Bitmap(Var_W, Var_H);				//根據圖片的大小實例化Bitmap類
            Bitmap Var_SaveBmp = (Bitmap)Pict.Image;					//根據圖片實例化Bitmap類
            for (int i = 0; i < Var_W; i++)								//深度搜尋圖片中的各象素
            {
                for (int j = 0; j < Var_H; j++)
                {
                    Random Var_random = new Random();				//實例化Random類
                    int k = Var_random.Next(200000);					//取得隨機數
                    //取得象素塊
                    int tem_w = i + k % effect;
                    int tem_h = j + k % effect;
                    //取得的象素不超出圖片的大小
                    if (tem_w >= Var_W)
                        tem_w = Var_W - 1;
                    if (tem_h >= Var_H)
                        tem_h = Var_H - 1;
                    Color tem_Color = Var_SaveBmp.GetPixel(tem_w, tem_h);	//取得目前象素的顏色
                    Var_bmp.SetPixel(i, j, tem_Color);					//設定目前象素的顏色
                }
            }
            return Var_bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = AtomizationEffect(pictureBox1, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
