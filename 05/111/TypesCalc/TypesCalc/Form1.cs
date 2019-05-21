using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TypesCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int Add(int x, int y)//定義一個靜態方法Add，返回值為int類型，有兩個int類型的參數
        {
            return x + y;
        }
        public double Add(int x, double y)//重新定義方法Add，它與第一個方法的返回值類型及參數類型不同
        {
            return x + y;
        }
        public double Add(double x, double y)//重新定義方法Add，它與第一個方法的返回值類型及參數類型不同
        {
            return x + y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)//判斷int單選按鈕是否選中
                {
                    //計算兩個int類型資料的和
                    textBox3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).ToString();
                }
                else if (radioButton2.Checked)//判斷int+double單選按鈕是否選中
                {
                    //計算int類型資料和double類型資料的和
                    textBox3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
                }
                else if (radioButton3.Checked)//判斷double單選按鈕是否選中
                {
                    //計算兩個double類型資料的和
                    textBox3.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
                }
            }
            catch { }
        }
    }
}
