using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace TimeNow
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //變數用於存儲年、月、日、時、分、秒
        public long LogYear, logMonth, logDay, logHour, logMinte, logSencon;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime get_time1 = DateTime.Now;//得到目前系統時間
            DateTime sta_ontime1 = Convert.ToDateTime(//得到世界盃開幕時間
                Convert.ToDateTime("2014-10-13 00:00:00"));
            txtYear.Text = DateAndTime.DateDiff(//計算相隔年數
                "yyyy", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays).ToString();
            txtMonth.Text = DateAndTime.DateDiff(//計算相隔月數
                "m", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays).ToString();
            textday.Text = DateAndTime.DateDiff(//計算相隔天數
                "d", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays).ToString();
            txtHour.Text = DateAndTime.DateDiff(//計算相隔小時數
                "h", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays).ToString();
            txtmintue.Text = DateAndTime.DateDiff(//計算相隔分鐘數
                "n", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays).ToString();
            txtsecon.Text = DateAndTime.DateDiff(//計算相隔秒數
                "s", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays).ToString();
            textBox1.Text = DateTime.Now.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = //顯示世界盃時間
                "2014-10-13  00:00:00" + "　　星期五";
            timer1.Enabled = true;//開啟計時器
        }
    }
}