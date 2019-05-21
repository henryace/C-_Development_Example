using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDPolygon
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();//實例化Graphics類
            Pen myPen = new Pen(Color.Black, 3);//實例化Pen類
            Point point1 = new Point(80, 20);//實例化Point類，表示第1個點
            Point point2 = new Point(40, 50);//實例化Point類，表示第2個點
            Point point3 = new Point(80, 80);//實例化Point類，表示第3個點
            Point point4 = new Point(160, 80);//實例化Point類，表示第4個點
            Point point5 = new Point(200, 50);//實例化Point類，表示第5個點
            Point point6 = new Point(160, 20);//實例化Point類，表示第6個點
            Point[] myPoints = { point1, point2, point3, point4, point5, point6 };//建立Point結構陣列
            ghs.DrawPolygon(myPen, myPoints);//呼叫Graphics對象的DrawPolygon方法繪製一個多邊形
        }
    }
}