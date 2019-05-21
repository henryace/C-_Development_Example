using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReverseStr
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void txt_input_TextChanged(object sender, EventArgs e)
        {
            char[] P_chr = txt_input.Text.ToCharArray();//從字串中得到字節陣列
            Array.Reverse(P_chr, 0, txt_input.Text.Length);//反轉字節陣列
            txt_output.Text = //將字節陣列轉換為字串並輸出
                new StringBuilder().Append(P_chr).ToString();
        }
    }
}
