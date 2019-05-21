using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProductTumblingShown
{
    public partial class Frm_Main : Form
    {
        int left = 0;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            left = 10; 				//初始化變數left的值
            this.panel1.Left += left; 	//設定panel1控制元件距容器左邊緣之間的距離
            int width = this.Width - this.panel1.Width; 	//初始化變數width
            if (this.panel1.Left > width) 	//當panel1控制元件距容器左邊緣之間的距離大於width時
            {
                this.timer1.Enabled = false; 		//禁用計時器timer1
                this.timer2.Enabled = true; 		//啟用計時器timer2
                this.pictureBox1.Image = this.imageList1.Images[0];//設定pictureBox1控制元件中顯示的圖片
                this.pictureBox2.Image = this.imageList2.Images[0];//設定pictureBox2控制元件中顯示的圖片
                this.pictureBox3.Image = this.imageList3.Images[0];//設定pictureBox3控制元件中顯示的圖片
            }
        }
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.imageList1.Images[0]; 	//設定pictureBox1控制元件中顯示的圖片
            this.pictureBox2.Image = this.imageList2.Images[0]; 	//設定pictureBox2控制元件中顯示的圖片
            this.pictureBox3.Image = this.imageList3.Images[0]; 	//設定pictureBox3控制元件中顯示的圖片
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            left = -10; 	//初始化left的值
            this.panel1.Left += left; 	//設定panel1距容器左邊緣之間的距離
            if (this.panel1.Left < 0) 		//當panel1距容器左邊緣之間的距離小於0時
            {
                this.timer1.Enabled = true; 		//啟用計時器timer1
                this.timer2.Enabled = false; 		//禁用計時器timer2
                this.pictureBox1.Image = this.imageList1.Images[1]; //設定pictureBox1控制元件中顯示的圖片
                this.pictureBox2.Image = this.imageList2.Images[1]; //設定pictureBox2控制元件中顯示的圖片
                this.pictureBox3.Image = this.imageList3.Images[1]; //設定pictureBox3控制元件中顯示的圖片
            }
        }
    }
}