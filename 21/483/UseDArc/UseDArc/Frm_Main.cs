﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDArc
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
            Pen myPen = new Pen(Color.DarkRed, 3);//實例化Pen類
            Rectangle myRectangle = new Rectangle(50, 20, 100, 60);//定義一個Rectangle結構
            ghs.DrawArc(myPen, myRectangle, 180, 180);//繪製圓弧
        }
    }
}