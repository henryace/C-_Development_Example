using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IfThenElse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtn_true.Checked)//判斷報銷是否為業務花銷
            {
                MessageBox.Show("正常報銷！");//正常報銷
            }
            else
            {
                MessageBox.Show("不符合規定報銷！");//不符合規定報銷
            }
        }
    }
}
