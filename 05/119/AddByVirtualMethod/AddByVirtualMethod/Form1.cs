using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddByVirtualMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 建立的虛擬方法，可以在子類別中被重寫
        /// </summary>
        class Operation
        {
            public virtual double operation(int x, int y)
            {
                return x * y;
            }
        }
        /// <summary>
        /// 在子類別中重寫虛擬方法
        /// </summary>
        class Addition : Operation
        {
            public override double operation(int x, int y)
            {
                return (x + y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void txtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtNum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNum1.Text == "" || txtNum2.Text == "")
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Operation multiplication = new Operation();//原始虛擬方法進行乘法運算
                    txtResult.Text = multiplication.operation(Convert.ToInt32(txtNum1.Text.Trim()), Convert.ToInt32(txtNum2.Text.Trim())).ToString();
                }
                else
                {
                    Operation Addition = new Addition();
                    txtResult.Text = Addition.operation(Convert.ToInt32(txtNum1.Text.Trim()), Convert.ToInt32(txtNum2.Text.Trim())).ToString();
                }
            }
        }
    }
}
