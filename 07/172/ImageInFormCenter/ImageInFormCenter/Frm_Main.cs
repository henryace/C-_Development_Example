﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageInFormCenter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("test.jpg");//設定視窗的背景圖片
            this.BackgroundImageLayout = ImageLayout.Center;//使圖片居中顯示
        }
    }
}
