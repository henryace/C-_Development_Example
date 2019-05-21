using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Using
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_true_Click(object sender, EventArgs e)
        {
            using (new test())//在using語句中建立test物件
            {
            }//using語句區塊執行完成後會自動呼叫test物件的Dispose方法
        }
        class test : IDisposable//定義test類別實現IDisposable介面
        {
            public void Dispose()//實現介面方法
            {
                MessageBox.Show(//彈出消息對話框
                    "已經執行test物件的Dispose方法", "提示");
            }
        }
    }
}
