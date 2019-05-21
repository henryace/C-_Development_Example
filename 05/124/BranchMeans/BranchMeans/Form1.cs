using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BranchMeans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Value_1 = "";//記錄計算之前的數
        public string Value_2 = "";//記錄計算之後的數
        public string Kind = "";//記錄算法
        string tem_Value = "";//記錄目前輸入的鍵值
        bool isnum = false;//判斷輸入的是計算的那個值
        bool isdian = false;//是否有小數點
        Account Acc = new Account();//實例化計算類

        //根據鍵值觸發相應的功能
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            tem_Value = ((PictureBox)sender).Tag.ToString();//取得目前按鈕的標識
            switch (tem_Value)
            {
                //輸入數字鍵
                case "0": num(tem_Value); break;
                case "1": num(tem_Value); break;
                case "2": num(tem_Value); break;
                case "3": num(tem_Value); break;
                case "4": num(tem_Value); break;
                case "5": num(tem_Value); break;
                case "6": num(tem_Value); break;
                case "7": num(tem_Value); break;
                case "8": num(tem_Value); break;
                case "9": num(tem_Value); break;
                //輸入計算鍵
                case "+":
                case "-":
                case "*":
                case "/": Kind = tem_Value; isnum = true; textBox1.Text = "0"; break;
                case "%":
                case "1/X":
                case "+-":
                case "Sqrt": fu(tem_Value); break;
                case ".": dian(); break;
                //計算結果
                case "=": js(tem_Value); break;
                //清除鍵
                case "C":
                    {
                        Value_1 = "";
                        Value_2 = "";
                        Kind = "";
                        textBox1.Text = "0";
                        break;
                    }
                case "CE": textBox1.Text = "0"; Value_1 = ""; break;
                case "Back": backspace(); break;
            }
        }

        /// <summary>
        /// 記錄目前輸入的數字鍵的值
        /// </summary>
        /// <param name="n">鍵值</param>
        public void num(string n)
        {
            if (isdian)
            {
                if (textBox1.Text == "0")
                    textBox1.Text = "0.";
                else
                    textBox1.Text += ".";
                isdian = false;
            }
            if (textBox1.Text == "0")
                textBox1.Text = "";
            if (isnum)//如果是計算之前的值
            {
                textBox1.Text += n;//累加輸入值
                Value_2 = textBox1.Text;//顯示在文字框中
            }
            else//計算之後的值
            {
                textBox1.Text += n;//累加輸入值
                Value_1 = textBox1.Text;//顯示在文字框中
            }
        }
        /// <summary>
        /// 計算
        /// </summary>
        /// <param name="n"></param>
        public void js(string n)
        {
            double tem_v = 0;//記錄計算後的結果
            if (Value_1.Length <= 0 || Value_2.Length <= 0)//判斷是否有計算的兩個值
                return;
            if (Kind.Length > 0)//如果可以計算
            {
                switch (Kind)
                {
                    case "+": tem_v = Acc.Addition(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                    case "-": tem_v = Acc.Subtration(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                    case "*": tem_v = Acc.Multiplication(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                    case "/": tem_v = Acc.Division(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                }
            }
            if (tem_v == Math.Ceiling(tem_v))//如果計算結果為整數
            {
                textBox1.Text = Convert.ToInt64(tem_v).ToString();//對結果進行取整
            }
            else
            {
                textBox1.Text = tem_v.ToString();//以雙精度進行顯示
            }
            Value_1 = textBox1.Text;//顯示計算結果
            Value_2 = "";

        }

        /// <summary>
        /// 輔助計算
        /// </summary>
        /// <param name="n"></param>
        public void fu(string n)
        {
            double tem_v = 0;//記錄計算結果
            switch (n)
            {
                case "%": tem_v = Acc.Par(Convert.ToDouble(textBox1.Text)); break;
                case "1/X": tem_v = Acc.Molecule(Convert.ToDouble(textBox1.Text)); break;
                case "+-": tem_v = Acc.Opposition(Convert.ToDouble(textBox1.Text)); break;
                case "Sqrt": tem_v = Acc.Evolution(Convert.ToDouble(textBox1.Text)); break;
            }
            if (tem_v == Math.Ceiling(tem_v))//如果計算結果為整數
            {
                textBox1.Text = Convert.ToInt64(tem_v).ToString();//對結果進行取整
            }
            else
            {
                textBox1.Text = tem_v.ToString();//以雙精度進行顯示
            }
            Value_1 = textBox1.Text;//顯示計算結果
            Value_2 = "";
        }

        /// <summary>
        /// 刪除輸入的值
        /// </summary>
        public void backspace()
        {
            var bstr = textBox1.Text;//記錄目前文字框中的值
            if (bstr != "0")//如果值不為零
            {
                string isabs = (Math.Abs(Convert.ToDouble(bstr)).ToString());//取得該值的絕對值
                if ((bstr.Length == 1) || (isabs.Length == 1))//如果目前文字框中只有一個數值
                {
                    textBox1.Text = "0";//將文字框清零
                }
                else { textBox1.Text = bstr.Substring(0, bstr.Length - 1); }//刪除指定的值
                Value_1 = textBox1.Text;//顯示刪除後的結果
            }
        }

        public void dian()
        {
            if (textBox1.Text.IndexOf(".") == -1)
                isdian = true;
            else
                isdian = false;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
