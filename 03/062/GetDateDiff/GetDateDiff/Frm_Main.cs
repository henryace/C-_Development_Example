using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GetDateDiff
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            MessageBox.Show("間隔 " +
                DateAndTime.DateDiff(//使用DateDiff方法取得日期間隔
                DateInterval.Day, dtpicker_first.Value, dtpicker_second.Value,
                FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString() + " 天", "間隔時間");
        }
    }
}
