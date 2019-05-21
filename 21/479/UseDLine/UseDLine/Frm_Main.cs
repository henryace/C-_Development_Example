using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);//實例化Pen類
            Point point1 = new Point(10, 50);//實例化一個Point類
            Point point2 = new Point(100, 50);//再實例化一個Point類
            Graphics g = this.CreateGraphics();//實例化一個Graphics類
            g.DrawLine(blackPen, point1, point2);//呼叫DrawLine方法繪製直線
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//實例化Graphics類
            Pen myPen = new Pen(Color.Black, 3);//實例化Pen類
            graphics.DrawLine(myPen, 150, 30, 150, 100);//呼叫DrawLine方法繪製直線
        }
    }
}