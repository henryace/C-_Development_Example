using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void transparencyButton1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(//彈出消息對話框
                "已經點擊了按鈕控制元件", "提示！");
        }
    }
}
