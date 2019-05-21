using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GetWindowsText
{
    public partial class Frm_Main : Form
    {
        const int GW_HWNDNEXT = 2;//API參數：取得下一個同級視窗句柄
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();									//清空richTextBox1控制元件
            StringBuilder text = new StringBuilder(2560);					//實例化StringBuilder類
            IntPtr currentHandle;									//定義變數
            currentHandle = GetWindow(this.Handle, GW_HWNDNEXT);		//取得視窗事件
            int v = GetWindowText(currentHandle, text, 2560);			//取得視窗文字
            richTextBox1.Text = text.ToString();						//顯示視窗文字
        }
        [DllImportAttribute("user32.dll")]
        private static extern int GetWindowText(IntPtr handle, StringBuilder Text, int MaxCount);
        [DllImportAttribute("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr handle, int ucmd);

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}