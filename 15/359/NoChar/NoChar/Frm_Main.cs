using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NoChar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            foreach (char c in Path.GetInvalidFileNameChars())//得到不允許使用的字符陣列
            {
                txt_Str.Text += c + "\r\n";//輸出字符陣列內容
            }
        }
    }
}
