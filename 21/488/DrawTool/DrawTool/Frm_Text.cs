using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace DrawTool
{
    public partial class Frm_Text : Form
    {
        public Frm_Text()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //當輸入回車時，關閉模式對話視窗
            if (e.KeyChar == (char)13)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}