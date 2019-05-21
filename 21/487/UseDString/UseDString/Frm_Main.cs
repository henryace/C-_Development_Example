using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "明日科技 C#編程詞典";//定義繪製的字串
            Font myFont = new Font("新細明體", 20);//實例化Font對像
            SolidBrush myBrush = new SolidBrush(Color.DarkOrange);//實例化畫刷對像
            Graphics myGraphics = this.CreateGraphics();//建立Graphics對像
            myGraphics.DrawString(str, myFont, myBrush, 10, 20);//繪製文字
        }
    }
}
