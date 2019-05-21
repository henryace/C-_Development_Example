using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace textNewLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            txt_Str.Text = string.Format(
                "C#編程詞典{0}C#編程寶典{0}C#範例寶典{0}C#視頻學",
                Environment.NewLine);
        }
    }
}
