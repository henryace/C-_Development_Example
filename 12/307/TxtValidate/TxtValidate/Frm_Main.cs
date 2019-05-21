using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TxtValidate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //身份證號碼18
            this.maskedTextBox1.Mask = "000000-00000000-000A";
            //身份證號碼15
            this.maskedTextBox2.Mask = "000000-000000-000";
            //郵政編碼
            this.maskedTextBox3.Mask = "000000";
            //出生日期
            this.maskedTextBox4.Mask = "0000年90月90日";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("請輸入18位身份證號",//彈出消息對話框 
                "訊息提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("請輸入15位身份證號", //彈出消息對話框
                "訊息提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("請輸入正確郵政編號", //彈出消息對話框
                "訊息提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("請輸入正確出生日期格式", //彈出消息對話框
                "訊息提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}