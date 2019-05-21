using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditFormSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.Text = "";//設定標題欄文字為空
            ControlBox = false;//不在視窗標題欄中顯示控制元件
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();//關閉目前視窗
        }
    }
}
