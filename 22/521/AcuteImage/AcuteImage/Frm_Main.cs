﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AcuteImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image AcuteEffect(PictureBox Pict)
        {
            int Var_W = Pict.Width;										//取得圖片的寬度
            int Var_H = Pict.Height;										//取得圖片的高度
            Bitmap Var_bmp = new Bitmap(Var_W, Var_H);					//根據圖片的大小實例化Bitmap類
            Bitmap Var_SaveBmp = (Bitmap)Pict.Image;						//根據圖片實例化Bitmap類
            int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };					//拉普拉斯模板
            //深度搜尋圖像中的各象素
            for (int i = 1; i < Var_W - 1; i++)
                for (int j = 1; j < Var_H - 1; j++)
                {
                    int tem_r = 0, tem_g = 0, tem_b = 0, tem_index = 0;				//定義變數
                    for (int c = -1; c <= 1; c++)
                        for (int r = -1; r <= 1; r++)
                        {
                            Color tem_color = Var_SaveBmp.GetPixel(i + r, j + c);		//取得指定象素的顏色值
                            tem_r += tem_color.R * Laplacian[tem_index];			//設定R色值
                            tem_g += tem_color.G * Laplacian[tem_index];			//設定G色值
                            tem_b += tem_color.B * Laplacian[tem_index];			//設定B色值
                            tem_index++;
                        }
                    tem_r = tem_r > 255 ? 255 : tem_r;	//如果R色值大於255，將R色值設為255，否則不變
                    tem_r = tem_r < 0 ? 0 : tem_r;		//如果R色值小於0，將R色值設為0，否則不變
                    tem_g = tem_g > 255 ? 255 : tem_g;	//如果G色值大於255，將R色值設為255，否則不變
                    tem_g = tem_g < 0 ? 0 : tem_g;		//如果G色值小於0，將R色值設為0，否則不變
                    tem_b = tem_b > 255 ? 255 : tem_b;	//如果B色值大於255，將R色值設為255，否則不變
                    tem_b = tem_b < 0 ? 0 : tem_b;		//如果B色值小於0，將R色值設為0，否則不變
                    Var_bmp.SetPixel(i - 1, j - 1, Color.FromArgb(tem_r, tem_g, tem_b));	//設定指定象素的顏色
                }
            return Var_bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = AcuteEffect(pictureBox1);
        }
    }
}
