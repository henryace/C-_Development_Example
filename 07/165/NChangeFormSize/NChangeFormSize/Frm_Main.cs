using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NChangeFormSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = false;//禁用最大化按鈕
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//設定視窗邊框樣式為對話框樣式
        }
    }
}