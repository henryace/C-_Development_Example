using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartForm
{
    public partial class Frm_Start : Form
    {
        public Frm_Start()
        {
            InitializeComponent();
        }

        private void Frm_Start_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//設定啟動視窗為無標題欄視窗
            this.BackgroundImage = Image.FromFile("start.jpg");//設定啟動視窗的背景圖片
            this.BackgroundImageLayout = ImageLayout.Stretch;//設定圖片自動適應視窗大小
            this.timer1.Start();//啟動計時器
            this.timer1.Interval = 10000;//設定啟動視窗停留時間
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();//關閉啟動視窗
        }

        private void Frm_Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();//關閉計時器
        }
    }
}
