﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlockCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();//創健控制元件的Graphics類
            g.Clear(Color.White);//以指定的顏色清除控制元件背景
            Brush Var_Brush_Back = Brushes.Black;//設定前景色
            Brush Var_Brush_Fore = Brushes.Aquamarine;//設定背景色
            Font Var_Font = new Font("細明體", 40);//設定字體樣式
            string Var_Str = "印版效果的文字";//設定字串
            SizeF Var_Size = g.MeasureString(Var_Str, Var_Font);//取得字串的大小
            int Var_X = (panel1.Width - Convert.ToInt32(Var_Size.Width)) / 2;//設定平移的X坐標
            int Var_Y = (panel1.Height - Convert.ToInt32(Var_Size.Height)) / 2;////設定平移的Y坐標
            //實現印版文字
            for (int i = 0; i < 10; i++)
            {
                g.DrawString(Var_Str, Var_Font, Var_Brush_Back, Var_X - i, Var_Y + i);
            }
            g.DrawString(Var_Str, Var_Font, Var_Brush_Back, Var_X, Var_Y);//繪製文字
        }
    }
}
