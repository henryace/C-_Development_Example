using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetLocation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Left = Convert.ToInt32(textBox1.Text);//設定視窗左邊緣與屏幕左邊緣之間的距離
            this.Top = Convert.ToInt32(textBox2.Text);//設定視窗上邊緣與屏幕上邊緣之間的距離
        }
    }
}