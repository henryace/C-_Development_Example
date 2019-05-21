using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDEllipse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//建立Graphics對像
            Pen myPen = new Pen(Color.DarkOrange, 3);//建立Pen對像
            graphics.DrawEllipse(myPen, 55, 20, 100, 50);//繪製橢圓
        }
    }
}