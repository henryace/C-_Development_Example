using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace Calculagraph
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public int intHour, intMouit, intSecon;//定義整型欄位
        private void Form1_Load(object sender, EventArgs e)
        {
            string strHour = DateTime.Now.TimeOfDay.Hours.ToString();//得到小時數
            string strMouit = DateTime.Now.TimeOfDay.Minutes.ToString();//得到分鐘數
            string strSecon = DateTime.Now.TimeOfDay.Seconds.ToString();//得到秒數
            if (Convert.ToInt32(strHour) < 10)
            {
                strHour = "0" + strHour;//如果小於10則補0
            }
            if (Convert.ToInt32(strMouit) < 10)
            {
                strMouit = "0" + strMouit;//如果小於10則補0
            }
            if (Convert.ToInt32(strSecon) < 10)
            {
                strSecon = "0" + strSecon;//如果小於10則補0
            }
            textBox2.Text = strHour + ":" + strMouit + ":" + strSecon;//顯時間訊息
            intHour = Convert.ToInt32(strHour);//將小時數轉換為整型
            intMouit = Convert.ToInt32(strMouit);//將分鐘數轉換為整型
            intSecon = Convert.ToInt32(strSecon);//將秒數轉換為整型
            numericUpDown3.Value = Convert.ToInt32(strHour);//顯示小時數
            numericUpDown2.Value = Convert.ToInt32(strMouit);//顯示分鐘數
            numericUpDown1.Value = Convert.ToInt32(strSecon);//顯示秒數
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strHour = DateTime.Now.TimeOfDay.Hours.ToString();//得到系統時間小時數
            string strMouit = DateTime.Now.TimeOfDay.Minutes.ToString();//得到系統時間分種數
            string strSecon = DateTime.Now.TimeOfDay.Seconds.ToString();//得到系統時間秒數
            if (Convert.ToInt32(strHour) < 10)
            {
                strHour = "0" + strHour;//如果小於10則補0
            }
            if (Convert.ToInt32(strMouit) < 10)
            {
                strMouit = "0" + strMouit;//如果小於10則補0
            }
            if (Convert.ToInt32(strSecon) < 10)
            {
                strSecon = "0" + strSecon;//如果小於10則補0
            }
            textBox1.Text = //顯示系統目前時間
                strHour + ":" + strMouit + ":" + strSecon;
        }

        //設定小時
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string Hour, Minute, second;//字串變數
            if (numericUpDown1.Value == 60)
            {
                numericUpDown1.Value = 0;
                numericUpDown2.Value = Convert.ToInt32(numericUpDown2.Value) + 1;
                intMouit = Convert.ToInt32(numericUpDown2.Value);
                intSecon = Convert.ToInt32(numericUpDown1.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;
            }
            else
            {

                intSecon = Convert.ToInt32(numericUpDown1.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;


            }
        }/////////
        //設定分
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            string Hour, Minute, second;
            if (numericUpDown2.Value == 60)
            {
                numericUpDown2.Value = 0;
                numericUpDown3.Value = Convert.ToInt32(numericUpDown2.Value) + 1;
                intMouit = Convert.ToInt32(numericUpDown2.Value);
                intHour = Convert.ToInt32(numericUpDown3.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;
            }
            else
            {
                intMouit = Convert.ToInt32(numericUpDown2.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;

            }
        }///
        //設定秒
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            string Hour, Minute, second;
            if (numericUpDown3.Value == 24)
            {
                numericUpDown3.Value = 0;
                intHour = Convert.ToInt32(numericUpDown3.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;
            }
            else
            {
                intHour = Convert.ToInt32(numericUpDown3.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime get_time1 = DateTime.Now;//得到系統目前時間
            DateTime sta_ontime1 = Convert.ToDateTime(//取得定時訊息
                Convert.ToDateTime(textBox2.Text.Trim().ToString()));
            long dat = DateAndTime.DateDiff(//計算兩個時間間隔的秒數
                "s", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays);
            if (dat > 0)//如果時間間隔大於0秒
            {
                if (timer2.Enabled != true)
                {
                    timer2.Enabled = true;//開始計時
                    label4.Text = "鬧鐘已啟動";//顯示操作訊息
                    label1.Text = "剩餘" + dat.ToString() + "秒";//顯示剩餘時間
                }
                else
                {
                    MessageBox.Show(//彈出消息對話框
                        "時鐘已經啟動，請取消後，在啟動");
                }
            }
            else
            {
                long hour = 24 * 3600 + dat;//計算到下一天的這個時間的秒數
                timer2.Enabled = true;//開始計時
                label4.Text = "鬧鐘已啟動";//顯示操作訊息
                label1.Text = "乘余" + hour.ToString() + "秒";//顯示剩餘時間
            }
        }
        //計時
        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime get_time1 = Convert.ToDateTime(//取得系統時間
                DateTime.Now.ToString());
            DateTime sta_ontime1 = Convert.ToDateTime(//取得定時訊息
                Convert.ToDateTime(textBox2.Text.Trim().
                ToString()));
            long dat = DateAndTime.DateDiff("s", //得到時間間隔
                get_time1, sta_ontime1, FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays);
            if (dat == 0)//如果時間間隔為0
            {
                Console.Beep(200, 500);//揚聲器發聲
                label4.Text = "時間已到";//顯示提示訊息
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;//取消計時器
            label4.Text = "鬧鐘已取消";//顯示提示訊息
            label1.Text = "";//取消顯示剩餘時間
        }
    }
}