﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            btn_One.AutoSize = true;//設定按鈕基於內容自動調整大小
            btn_One.Text = txt_Name.Text;//設定按鈕文字內容
        }
    }
}
