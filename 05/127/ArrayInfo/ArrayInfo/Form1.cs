using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrayInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Finder
        {
            // 定義一個泛型方法，用來搜尋指定值在陣列中的索引
            public static int Find<T>(T[] items, T item)
            {
                for (int i = 0; i < items.Length; i++)//深度搜尋泛型陣列
                {
                    if (items[i].Equals(item))//判斷是否找到了指定值
                    {
                        return i;//返回指定值在陣列中的索引
                    }
                }
                return -1;//如果沒有找到，返回-1
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] Str = new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九" };//聲明一個字串類型的陣列
            MessageBox.Show(Finder.Find<string>(Str, "三").ToString());//搜尋字串「三」在陣列中的索引
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] IntArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };//聲明一個整數類型的陣列
            MessageBox.Show(Finder.Find<int>(IntArray, 5).ToString());//搜尋數字5在陣列中的索引
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool[] IntArray = new bool[] { true, false };//聲明一個布爾類型的陣列
            MessageBox.Show(Finder.Find<bool>(IntArray, false).ToString());//搜尋false在陣列中的索引
        }
    }
}
