using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDBezier
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//實例化一個GDI+繪圖圖面類對像
            Pen myPen = new Pen(Color.Blue, 3);//實例化一個用於繪製直線和曲線的對象
            float startX = 50.0F;//實例化起始點的x坐標
            float startY = 80.0F;//實例化起始點的y坐標
            float controlX1 = 200.0F;//實例化第一個控制點的x坐標
            float controlY1 = 20.0F;//實例化第一個控制點的y坐標
            float controlX2 = 100.0F;//實例化第二個控制點的x坐標
            float controlY2 = 10.0F;//實例化第二個控制點的y坐標
            float endX = 190.0F;//實例化結束點的x坐標
            float endY = 40.0F;//實例化結束點的y坐標
            graphics.DrawBezier(myPen, startX, startY, controlX1, controlY1, controlX2, controlY2, endX, endY);//繪製由4個表示點的有序坐標對定義的貝塞爾樣條
        }
    }
}