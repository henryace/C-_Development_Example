﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ZoomCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();							//創健控制元件的Graphics類
            g.Clear(Color.White);										//以指定的顏色清除控制元件背景
            Brush Var_Back = Brushes.Black;								//設定畫刷
            FontFamily Var_FontFamily = new FontFamily("細明體");				//設定字體樣式
            string Var_Str = "縮放文字";									//設定字串
            GraphicsPath Var_Path = new GraphicsPath();						//實例化GraphicsPath物件
            //在路徑中新增文字
            Var_Path.AddString(Var_Str, Var_FontFamily, (int)FontStyle.Regular, 50, new Point(0, 0), new StringFormat());
            PointF[] Var_PointS = Var_Path.PathPoints;						//取得路徑中的點
            Byte[] Car_Types = Var_Path.PathTypes;							//取得相應點的類型
            Matrix Var_Matrix = new Matrix(Convert.ToSingle(textBox1.Text), 0.0F, 0.0F, Convert.ToSingle(textBox1.Text), 0.0F,
        0.0F);													//設定仿射矩陣
            Var_Matrix.TransformPoints(Var_PointS);						//設定幾何變換
            GraphicsPath Var_New_Path = new GraphicsPath(Var_PointS, Car_Types);	//對GraphicsPath類進行初始化
            g.FillPath(Var_Back, Var_New_Path);							//繪製縮放的文字
        }
    }
}
