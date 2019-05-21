using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GetAge
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetAge_Click(object sender, EventArgs e)
        {
            long P_BirthDay = DateAndTime.DateDiff(DateInterval.Year,//計算年齡
                 dtpicker_BirthDay.Value, DateTime.Now,
                 FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            MessageBox.Show(string.Format("年齡為： {0}歲。",//輸出年齡訊息
                P_BirthDay.ToString()), "提示！");
        }
    }
}
