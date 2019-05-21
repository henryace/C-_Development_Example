using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraduallyBackColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            int intLocation, intHeight;//定義兩個int型的變數intLocation、intHeight 
            intLocation = this.ClientRectangle.Location.Y;//為變數intLocation賦值
            intHeight = this.ClientRectangle.Height / 200;//為變數intHeight賦值
            for (int i = 255; i >= 0; i--)
            {
                Color color = new Color();//定義一個Color類型的實例color
                //為實例color賦值
                color = Color.FromArgb(1, i, 100);
                SolidBrush SBrush = new SolidBrush(color);//實例化一個單色畫筆類物件SBrush
                Pen pen = new Pen(SBrush, 1);//實例化一個用於繪製直線和曲線的對象pen
                e.Graphics.DrawRectangle(pen, this.ClientRectangle.X, intLocation, this.Width, intLocation + intHeight);//繪製圖形
                intLocation = intLocation + intHeight;//重新為變數intLocation賦值
            }
        }
    }
}