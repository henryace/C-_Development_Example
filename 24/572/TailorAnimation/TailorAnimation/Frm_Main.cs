using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TailorAnimation
{
    public partial class Frm_Main : Form
    {
        string strPath;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            strPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));			//截取圖片所在的文件路徑
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 		//設定圖片的顯示類型
            pictureBox1.Image = Image.FromFile(strPath + @"\image\1.jpg");	//為pictureBox1設定顯示的圖片
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random(); 								//宣告一個隨機類的對象
            pictureBox1.Image = Image.FromFile(strPath + @"\image\" + r.Next(1, 5) + ".jpg");	//為pictureBox1設定顯示的圖片
        }
    }
}