using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StopCloseButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;//定義將要截獲的消息類型
            const int SC_CLOSE = 0xF060;//定義關閉按鈕對應的消息值
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_CLOSE))//當鼠標單擊關閉按鈕時
            {
                return;//直接返回，不進行處理
            }
            base.WndProc(ref m);//傳遞下一條消息
        }

        private void ExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出應用程式
        }
    }
}
