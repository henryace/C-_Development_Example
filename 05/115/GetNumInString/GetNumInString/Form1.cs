using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetNumInString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //搜尋數字方法
        public bool getNumeric(string str)
        {
            bool b = false;
            //將所有數字存儲到一個字串陣列中
            string[] ArrayInt = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string n in ArrayInt)//判斷字符是否包含陣列中指定的數字
            {
                if (n == str)//如果找到了數字
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "得到的數字：";
            string strs = textBox1.Text;//記錄要從中搜尋數字的字串
            for (int i = 0; i < strs.Length; i++)//循環深度搜尋這個字串
            {
                string str = strs.Substring(i, 1);//單一讀取每一個字符
                bool b = getNumeric(str);//判斷字符是否為數字
                if (b)
                {
                    label2.Text += str + "、";//如果是數字則顯示
                }
            }
        }
    }
}
