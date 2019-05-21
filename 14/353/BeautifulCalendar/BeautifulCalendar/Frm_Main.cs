using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulCalendar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Point CPoint;
        private void dateTimeControl1_MouseDown(object sender, MouseEventArgs e)
        {
            CPoint = new Point(-e.X, -e.Y);//記錄坐標位置
        }

        private void dateTimeControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//取得目前鼠標的屏幕坐標
                myPosittion.Offset(CPoint.X, CPoint.Y);//重載目前鼠標的位置
                this.DesktopLocation = myPosittion;//設定目前視窗在屏幕上的位置
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();//關閉目前視窗
        }
    }
}
