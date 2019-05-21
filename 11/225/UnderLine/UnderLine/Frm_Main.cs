using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnderLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            txt_Str.Text = string.Format(//設定文字框中的文字
                "C#編程詞典{0}{0}C#編程寶典{0}{0}C#範例寶典{0}{0}C#實戰寶典",
                Environment.NewLine);
        }

        private void btn_DisplayUnderLine_Click(object sender, EventArgs e)
        {
            txt_Str.Font = //設定文字框中文字字體
                new Font(new Font("細明體", 15), FontStyle.Underline);
        }
    }
}
