using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormDisOperate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void FormOperate<T>()
        {
            Form2 Frm_2 = new Form2();//實例化Form2視窗物件
            Frm_2.ShowDialog();//以對話框形式顯示Form2視窗
        }

        public void FormOperate<T>(string strError)
        {
            MessageBoxIcon messIcon = MessageBoxIcon.Error;//實例化提示框中顯示圖標物件
            MessageBox.Show(strError, "提示", MessageBoxButtons.OK, messIcon);//顯示錯誤提示框
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOperate<object>();//呼叫FormOperate方法的第一種重載形式對視窗操作
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOperate<object>("資料庫連接失敗。");//呼叫FormOperate方法的第二種重載形式對視窗操作
        }

    }
}
