using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FlashWindowBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //重寫API函數，用來實現視窗標題欄閃爍功能
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool FlashWindow(IntPtr handle, bool bInvert);

        private void timer1_Tick(object sender, EventArgs e)
        {
            FlashWindow(this.Handle, true);//啟用視窗閃爍函數
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//啟動計時器
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;//關閉計時器
        }
    }
}