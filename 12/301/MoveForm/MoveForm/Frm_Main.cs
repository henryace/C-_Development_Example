using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoveForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Screen.GetWorkingArea(this);//取得屏幕大小
            if (this.Left != (rect.Width - this.Width))
            {
                this.Left++;//視窗向右移動
                this.Top += 1;//視窗向下移動
            }
            else
            {
                timer1.Enabled = false;//停用Timer組件
                timer2.Enabled = true;//啟用Timer組件
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Screen.GetWorkingArea(this);//取得屏幕大小
            if (this.Left == 0)
            {
                timer2.Enabled = false;//停用Timer組件
                timer1.Enabled = true;//啟用Timer組件
            }
            else
            {
                this.Left--;//視窗向左移動
                this.Top -= 1;//視窗向上移動
            }
        }
    }
}