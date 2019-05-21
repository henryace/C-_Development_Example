using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReverseOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 透過反覆運算器實現字串的倒序
        /// </summary>
        /// <param string="n">進行倒序的字串</param>
        /// <returns>以物件的方式倒序返回單個字元</returns>
        public static IEnumerable<object> Transpose(string n)
        {
            if (n.Length > 0)//如果泛用型不為空
            {
                for (int i = n.Length - 1; i >= 0; i--)//從末尾開始深度搜尋字串
                    yield return (object)n[i];//返回資料集合
            }
        }

        /// <summary>
        /// 取得倒序後的字串
        /// </summary>
        /// <param string="Str">進行倒序的字串</param>
        /// <returns>返回倒序後的字串</returns>
        public string GetValue(string Str)
        {
            if (Str.Length == 0)//判斷字串長度是否為0
                return "";//返回空
            string Tem_Str = "";//記錄倒序之後的字串
            foreach (object i in Transpose(Str))//深度搜尋反覆運算器
                Tem_Str += i.ToString();//取得反覆運算器中的每個字符
            return Tem_Str;//返回倒序之後的字串
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = GetValue(textBox1.Text);
        }
    }
}
