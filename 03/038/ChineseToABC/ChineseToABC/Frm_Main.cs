using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ChineseToABC
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void txt_Chinese_TextChanged(object sender, EventArgs e)
        {
            txt_PinYIn.Text = //呼叫拼音類的GetABC方法得到拼音字串
                new PinYin().GetABC(txt_Chinese.Text);
        }
    }
}
