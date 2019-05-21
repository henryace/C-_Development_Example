using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InclineCharacter
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
            Brush Var_Brush_Back = Brushes.Black;						//設定前景色
            Brush Var_Brush_Fore = Brushes.Aquamarine;					//設定背景色
            Font Var_Font = new Font("細明體", 40);						//設定字體樣式
            string Var_Str = "傾斜效果的文字";						//設定字串
            SizeF Var_Size = g.MeasureString(Var_Str, Var_Font);			//取得字串的大小
            int Var_X = (panel1.Width - Convert.ToInt32(Var_Size.Width)) / 2;	//設定平移的X坐標
            int Var_Y = (panel1.Height - Convert.ToInt32(Var_Size.Height)) / 2;	//設定平移的Y坐標
            g.TranslateTransform(Var_X, Var_Y);						//更改坐標系原點
            Matrix Var_Trans = g.Transform;							//取得幾何世界的變換復本
            Var_Trans.Shear(0.40F, 0.00F);							//透過預先計算切變變換
            g.Transform = Var_Trans;								//文字的左傾斜
            g.DrawString(Var_Str, Var_Font, Var_Brush_Back, 5, 5);		//繪製文字
        }
    }
}
