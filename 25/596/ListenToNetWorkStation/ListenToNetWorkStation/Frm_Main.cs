using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ListenToNetWorkStation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender, EventArgs e)
        {
            try
            {
                this.axWindowsMediaPlayer1.URL = path.Text;//設定WindowsMediaPlayer的URL
            }
            catch (Exception ex)//擷取異常
            {
                MessageBox.Show(ex.Message);//顯示異常訊息
            }
        }
    }
}