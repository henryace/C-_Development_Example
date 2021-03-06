﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaysInMonth
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            int P_Count = DateTime.DaysInMonth(//取得本月的天數
                DateTime.Now.Year, DateTime.Now.Month);
            MessageBox.Show("本月有" +//顯示本月的天數
                P_Count.ToString() + "天", "提示！");
        }
    }
}
