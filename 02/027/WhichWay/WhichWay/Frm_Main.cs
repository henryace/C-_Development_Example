using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhichWay
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (rbtn_school.Checked)//判斷小明去學校還是去醫院
            {
                MessageBox.Show("向左走", "提示！");//如果去學校則向左走
            }
            else
            {
                MessageBox.Show("向右走", "提示！");//如果去醫院則向右走
            }
        }
    }
}
