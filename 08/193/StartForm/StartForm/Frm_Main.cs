using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Frm_Start frm = new Frm_Start();//實例化Form2視窗物件
            frm.StartPosition = FormStartPosition.CenterScreen;//設定視窗居中顯示
            frm.ShowDialog();//顯示Form2視窗
        }
    }
}
