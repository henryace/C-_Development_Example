using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomBackGround
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //定義一個字串陣列，用來存儲背景圖片列表
            string[] strImages = new string[] { "01.jpg", "02.jpg", "03.jpg", "04.jpg", "05.jpg" };
            Random rdn = new Random();//定義一個偽隨機數產生器物件
            int intIndex = rdn.Next(0, strImages.Length - 1);//產生一個隨機數
            this.BackgroundImage = Image.FromFile(strImages[intIndex]);//設定視窗的背景圖片
            this.BackgroundImageLayout = ImageLayout.Stretch;//設定背景圖片拉伸顯示
        }
    }
}