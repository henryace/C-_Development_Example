using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ButtonMagnifier
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Location = new Point(80, 10);//設定按鈕位置
            button1.Font = new Font("隸書", 18);//設定按鈕字體樣式
            button1.Width = 200;//設定按鈕寬度
            button1.Height = 80;//設定按鈕高度
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Location = new Point(130, 30);//設定按鈕位置
            button1.Font = new Font("細明體", 9);//設定按鈕字體樣式
            button1.Width = 100;//設定按鈕寬度
            button1.Height = 40;//設定按鈕高度
        }
    }
}
