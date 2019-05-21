using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcRAreaByAbstractClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcArea calcArea = new CalcArea();//實例化衍生類
            Roll roll = calcArea;//使用衍生類物件實例化抽像類
            string strNum = textBox1.Text.Trim();//記錄TextBox文字框中的內容
            if (strNum != "")//判斷是否輸入了圓半徑
            {
                try
                {
                    roll.R = int.Parse(strNum);//使用抽像類物件訪問抽像類中的半徑屬性
                    textBox2.Text = roll.Area().ToString();//呼叫自定義方法進行求圓面積
                }
                catch
                {
                    MessageBox.Show("請輸入正確的圓半徑！");
                }
            }
        }
    }
    public abstract class Roll
    {
        private int r = 0;
        /// <summary>
        /// 圓半徑
        /// </summary>
        public int R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }
        /// <summary>
        /// 抽像方法，用來計算圓面積
        /// </summary>
        public abstract double Area();
    }
    public class CalcArea : Roll//繼承抽像類
    {
        /// <summary>
        /// 重寫抽像類中計算圓面積的方法
        /// </summary>
        public override double Area()
        {
            return Math.PI * R * R;
        }
    }
}
