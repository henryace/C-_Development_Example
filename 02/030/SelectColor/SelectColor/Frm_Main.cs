using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void cbox_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_select.SelectedIndex)//使用switch判斷視窗使用哪種顏色
            {
                case 0:
                    this.BackColor = Color.Red;//視窗設定為紅色
                    break;
                case 1:
                    this.BackColor = Color.Green;//視窗設定為綠色
                    break;
                case 2:
                    this.BackColor = Color.Blue;//視窗設定為藍色
                    break;
            }
        }
    }
}
