using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClearFormBack
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("test.jpg");//設定視窗的背景圖片
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//建立繪圖物件
            graphics.Clear(Color.White);//清空背景
            graphics.Dispose();//釋放繪圖資源
        }
    }
}
