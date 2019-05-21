using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SquareByMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double SquareNum(double num)
        {
            return num * num;//求一個數的平方
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string strNum = textBox1.Text.Trim();//記錄TextBox文字框中的內容
            if (strNum != "")//判斷是否輸入了資料
            {
                try
                {
                    textBox2.Text = SquareNum(double.Parse(strNum)).ToString();//呼叫自定義方法進行求平方運算
                }
                catch
                {
                    MessageBox.Show("請輸入正確的數字！");
                }
            }
        }
    }
}
