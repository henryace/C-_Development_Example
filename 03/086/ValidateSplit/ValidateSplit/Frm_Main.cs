using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateSplit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Split_Click(object sender, EventArgs e)
        {
            string[] P_Str = System.Text.RegularExpressions.//使用正規化運算式根據數字進行拆分
                Regex.Split(txt_Split.Text, "[1-9]");
            foreach (string s in P_Str)//深度搜尋拆分後的字串集合
            {
                txt_Result.Text += s;//顯示字串
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出應用程式
        }
    }
}