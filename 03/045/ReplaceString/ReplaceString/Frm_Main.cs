using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReplaceString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_replace_Click(object sender, EventArgs e)
        {
            txt_str.Text = //使用字串對象的Reaplce方法替換所有滿足條件的字串
                txt_str.Text.Replace(txt_find.Text, txt_replace.Text);
        }
    }
}
