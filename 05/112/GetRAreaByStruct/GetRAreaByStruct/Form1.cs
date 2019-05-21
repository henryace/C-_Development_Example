using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetRAreaByStruct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Rect//定義一個矩形結構
        {
            public double width;//矩形的寬
            public double height;//矩形的高
            /// <summary>
            /// 構造函數，初始化矩形的寬和高
            /// </summary>
            /// <param name="x">矩形的寬</param>
            /// <param name="y">矩形的高</param>
            public Rect(double x, double y)
            {
                width = x;
                height = y;
            }
            /// <summary>
            /// 計算矩形面積
            /// </summary>
            /// <returns>矩形面積</returns>
            public double Area()
            {
                return width * height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //使用自定義構造函數實例化矩形結構
            Rect myRect = new Rect(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            textBox3.Text = myRect.Area().ToString();//計算矩形的面積
        }
    }
}
