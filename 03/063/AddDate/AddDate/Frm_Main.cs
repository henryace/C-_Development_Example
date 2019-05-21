using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace AddDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private DateTime G_datetime;//定義時間欄位
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_datetime = DateTime.Now;//得到系統目前時間
            lab_time.Text = G_datetime.ToString(//顯示時間訊息
                "時間：  yyyy年M月d日 H時m分s秒");
        }
        private void btn_AddM_Click(object sender, EventArgs e)
        {
            G_datetime = DateAndTime.DateAdd(//向時間欄位中新增一分鐘
                DateInterval.Minute, 1, G_datetime);
            lab_time.Text = G_datetime.ToString(//顯示時間訊息
                "時間：  yyyy年M月d日 H時m分s秒");
        }
        private void btn_AddH_Click(object sender, EventArgs e)
        {
            G_datetime = DateAndTime.DateAdd(//向時間欄位中新增一小時
                DateInterval.Hour, 1, G_datetime);
            lab_time.Text = G_datetime.ToString(//顯示時間訊息
                "時間：  yyyy年M月d日 H時m分s秒");
        }
        private void btn_addD_Click(object sender, EventArgs e)
        {
            G_datetime = DateAndTime.DateAdd(//向時間欄位中新增一天
              DateInterval.Day, 1, G_datetime);
            lab_time.Text = G_datetime.ToString(//顯示時間訊息
                "時間：  yyyy年M月d日 H時m分s秒");
        }
    }
}
