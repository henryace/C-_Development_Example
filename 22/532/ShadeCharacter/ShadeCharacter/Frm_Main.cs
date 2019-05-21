using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ShadeCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();						//創健控制元件的Graphics類
            g.Clear(Color.White);									//以指定的顏色清除控制元件背景
            Color Var_Color_Up = Color.Red;							//設定前景色
            Color Var_Color_Down = Color.Yellow;						//設定背景色
            Font Var_Font = new Font("細明體", 40);						//設定字體樣式
            string Var_Str = "漸層效果的文字";						//設定字串
            SizeF Var_Size = g.MeasureString(Var_Str, Var_Font);			//取得字串的大小
            PointF Var_Point = new PointF(5, 5);						//設定文字的顯示位置
            RectangleF Var_Rect = new RectangleF(Var_Point, Var_Size);		//根據文字的大小及位置，實例化RectangleF類
            LinearGradientBrush Var_LinearBrush = new LinearGradientBrush(Var_Rect, Var_Color_Up, Var_Color_Down,
        LinearGradientMode.Horizontal);								//設定從左到右的線性漸層效果
            g.DrawString(Var_Str, Var_Font, Var_LinearBrush, Var_Point);	//繪製文字
        }
    }
}
