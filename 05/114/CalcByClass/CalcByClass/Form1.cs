using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcByClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;//記錄第一個數
        int j = 0;//記錄第二個數
        string type = "";//記錄運算類型
        //數字1
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)//判斷是否已經輸入了數字
                textBox1.Text += "1";//如果已經輸入，並且不是0，則加1
            else
                textBox1.Text = "1";
        }
        //數字2
        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "2";
            else
                textBox1.Text = "2";
        }
        //數字3
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "3";
            else
                textBox1.Text = "3";
        }
        //數字4
        private void button5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "4";
            else
                textBox1.Text = "4";
        }
        //數字5
        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "5";
            else
                textBox1.Text = "5";
        }
        //數字6
        private void button6_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "6";
            else
                textBox1.Text = "6";
        }
        //數字7
        private void button7_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "7";
            else
                textBox1.Text = "7";
        }
        //數字8
        private void button8_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "8";
            else
                textBox1.Text = "8";
        }
        //數字9
        private void button9_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "9";
            else
                textBox1.Text = "9";
        }
        //數字0
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        //加法運算
        private void button12_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);//記錄第一個數
            type = "+";//記錄運算類型
            textBox1.Text = "0";//清空文字框
        }
        //減法運算
        private void button13_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            type = "-";
            textBox1.Text = "0";
        }
        //乘法運算
        private void button14_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            type = "*";
            textBox1.Text = "0";
        }
        //除法運算
        private void button15_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            type = "/";
            textBox1.Text = "0";
        }
        //等號
        private void button11_Click(object sender, EventArgs e)
        {
            j = Convert.ToInt32(textBox1.Text);//記錄第二個數
            CCount myCount = new CCount();//實例化類物件
            if (type == "/" && j == 0)//判斷運算類型是不是除法
            {
                MessageBox.Show("被除數不能為0");
            }
            else
            {
                textBox1.Text = myCount.Sum(i, j, type).ToString();//計算結果
            }
        }
        //清空文字框
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";//清空文字框
        }
    }
    public class CCount
    {
        public int Sum(int a, int b, string type)//定義一個方法，用來計算兩個數的和、差、積、商
        {
            switch (type)//判斷運算符類型
            {
                case "+":
                    return a + b; break;//計算兩個數的和
                case "-":
                    return a - b; break;//計算兩個數的差
                case "*":
                    return a * b; break;//計算兩個數的積
                case "/":
                    return a / b; break;//計算兩個數的商
                default:
                    return 0; break;
            }
        }
    }
}
