using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LikesXP
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private static Panel Var_Panel = new Panel();//建立靜態欄位
        private static PictureBox Var_Pict = //建立靜態欄位
            new PictureBox();
        private static int Var_i = 0;//建立靜態欄位
        private Font Var_Font = new Font("細明體", 9); //建立字體欄位

        private void pictureBox_1_Click(object sender, EventArgs e)
        {
            Var_i = Convert.ToInt16((//得到控制元件中的資料
                (PictureBox)sender).Tag.ToString());
            switch (Var_i)
            {
                case 1:
                    {
                        Var_Panel = panel_Gut_1;//得到面板物件參考
                        Var_Pict = pictureBox_1;//得到PictureBox物件參考
                        break;
                    }
                case 2:
                    {
                        Var_Panel = panel_Gut_2;//得到面板物件參考
                        Var_Pict = pictureBox_2;//得到PictureBox物件參考
                        break;
                    }
                case 3:
                    {
                        Var_Panel = panel_Gut_3;//得到面板物件參考
                        Var_Pict = pictureBox_3;//得到PictureBox物件參考
                        break;
                    }
            }
            if (Convert.ToInt16(Var_Panel.Tag.ToString()) == 0 || Convert.ToInt16(Var_Panel.Tag.ToString()) == 2)
            {
                Var_Panel.Tag = 1;//設定為隱藏標識
                Var_Pict.Image = Properties.Resources.朝下按鈕;//設定圖像屬性
                Var_Panel.Visible = false;//隱藏面板
            }
            else
            {
                if (Convert.ToInt16(Var_Panel.Tag.ToString()) == 1)
                {
                    Var_Panel.Tag = 2;//設定為顯示標識
                    Var_Pict.Image = Properties.Resources.朝上按鈕;//設定圖像屬性
                    Var_Panel.Visible = true;//顯示面板
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_1.Image = Properties.Resources.朝上按鈕;//設定圖像訊息
            pictureBox_2.Image = Properties.Resources.朝上按鈕;//設定圖像訊息
            pictureBox_3.Image = Properties.Resources.朝上按鈕;//設定圖像訊息
            Var_Font = label_1.Font;//得到字體物件
        }

        private void label_1_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Gray;//設定控制元件文字字顏色
            ((Label)sender).Font = //設定控制元件字體
                new Font(Var_Font, Var_Font.Style | FontStyle.Underline);
        }

        private void label_1_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;//設定控制元件文字顏色
            ((Label)sender).Font = //設定控制元件字體
                new Font(Var_Font, Var_Font.Style);
        }
    }
}
