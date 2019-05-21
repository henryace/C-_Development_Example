using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlayGifAnimation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Bitmap bitmap = new Bitmap(Application.StartupPath + "\\1.gif");				//實例化一個GDI+繪圖圖面對像
        bool current = false;			//初始化一個bool型的變數current
        public void PlayImage()
        {
            if (!current) 			//當該值為true時
            {
                ImageAnimator.Animate(bitmap, new EventHandler(this.OnFrameChanged)); 	//將多幀圖片顯示為動畫圖像
                current = true; 		//設定current的值為true
            }
        }
        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate(); 			//使控制元件的整個圖片無效並導致重繪事件
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.bitmap, new Point(1, 1)); 	//從指定的位置繪製圖片
            ImageAnimator.UpdateFrames(); 					//使該幀在目前正被圖畫處理的所有圖像中前移
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PlayImage();			//播放
            ImageAnimator.Animate(bitmap, new EventHandler(this.OnFrameChanged)); 	//將多幀圖像顯示為動畫
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ImageAnimator.StopAnimate(bitmap, new EventHandler(this.OnFrameChanged)); 	//停止
        }
    }
}