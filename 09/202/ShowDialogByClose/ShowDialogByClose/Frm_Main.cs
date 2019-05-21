using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShowDialogByClose
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)//觸發視窗關閉事件
        {
            if (MessageBox.Show("將要關閉視窗，是否繼續？", "詢問", MessageBoxButtons.YesNo) == DialogResult.Yes)//判斷是否單擊了「是」按鈕
            {
                e.Cancel = false;//關閉視窗
            }
            else
            {
                e.Cancel = true;//取消事件的執行
            }
        }
    }
}