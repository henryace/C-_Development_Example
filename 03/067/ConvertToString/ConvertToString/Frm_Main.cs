using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConvertToString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            #region 針對Windows 7系統
            string s = string.Format("{0}/{1}/{2}",//得到日期字串
                txt_Year.Text, txt_Month.Text, txt_Day.Text);
            DateTime P_dt = DateTime.ParseExact(//將字串轉換為日期格式
                s, "yyyy/MM/dd", null);
            #endregion
            //#region 針對Windows XP或者2003系統
            //string s = string.Format("{0}{1}{2}",//得到日期字串
            //    txt_Year.Text, txt_Month.Text, txt_Day.Text);
            //DateTime P_dt = DateTime.ParseExact(//將字串轉換為日期格式
            //    s, "yyyyMMdd", null);
            //#endregion
            MessageBox.Show("輸入的日期為： "//彈出消息對話框
                + P_dt.ToLongDateString(), "提示！");
        }
    }
}
