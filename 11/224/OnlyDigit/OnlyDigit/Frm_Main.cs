﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlyDigit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void txt_Str_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))//判斷是否為數字
            {
                MessageBox.Show("請輸入數字！", "提示！",//彈出消息對話框
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;//取消在控制元件中顯示該字符
            }
        }
    }
}
