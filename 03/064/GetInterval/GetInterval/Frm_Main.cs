using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetInterval
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private DateTime G_DateTime_First,//定義兩個時間欄位
            G_DateTime_Second;
        private void btn_First_Click(object sender, EventArgs e)
        {
            G_DateTime_First = DateTime.Now;//為時間欄位賦值
            lab_first.Text = "系統時間：" +//顯示時間
                G_DateTime_First.ToString(
                "yyyy年M月d日 H時m分s秒 fff毫秒");
        }
        private void btn_Second_Click(object sender, EventArgs e)
        {
            G_DateTime_Second = DateTime.Now;//為時間欄位賦值
            lab_second.Text = "系統時間：" +//顯示時間
                G_DateTime_Second.ToString(
                "yyyy年M月d日 H時m分s秒 fff毫秒");
        }
        private void btn_Result_Click(object sender, EventArgs e)
        {
            TimeSpan P_timespan_temp =//計算兩個時間的時間間隔
                G_DateTime_First > G_DateTime_Second ?
                G_DateTime_First - G_DateTime_Second :
                G_DateTime_Second - G_DateTime_First;
            lab_result.Text = string.Format(//顯示時間間隔
                "間隔時間：{0}天{1}時{2}分{3}秒 {4}毫秒",
                P_timespan_temp.Days, P_timespan_temp.Hours,
                P_timespan_temp.Minutes, P_timespan_temp.Seconds,
                P_timespan_temp.Milliseconds);
        }
    }
}
