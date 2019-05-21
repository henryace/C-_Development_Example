using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SetDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public class SetSystemDateTime//設定系統日期類
        {
            [DllImportAttribute("Kernel32.dll")]
            public static extern void GetLocalTime(SystemTime st);
            [DllImportAttribute("Kernel32.dll")]
            public static extern void SetLocalTime(SystemTime st);
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class SystemTime//系統時間類
        {
            public ushort vYear;//年
            public ushort vMonth;//月
            public ushort vDayOfWeek;//星期
            public ushort vDay;//日
            public ushort vHour;//小時
            public ushort vMinute;//分
            public ushort vSecond;//秒
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = DateTime.Now.ToString("F") +//得到系統時間
                "  " + DateTime.Now.ToString("dddd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您真的確定更改系統目前日期嗎？",//設定系統目前日期時間
                "訊息提示", MessageBoxButtons.OK) == DialogResult.OK)
            {
                DateTime Year = this.dateTimePicker1.Value;//得到時間訊息
                SystemTime MySystemTime = new SystemTime();//建立系統時間類的對象
                SetSystemDateTime.GetLocalTime(MySystemTime);//得到系統時間
                MySystemTime.vYear = (ushort)this.dateTimePicker1.Value.Year;//設定年
                MySystemTime.vMonth = (ushort)this.dateTimePicker1.Value.Month;//設定月
                MySystemTime.vDay = (ushort)this.dateTimePicker1.Value.Day;//設定日
                MySystemTime.vHour = (ushort)this.dateTimePicker2.Value.Hour;//設定小時
                MySystemTime.vMinute = (ushort)this.dateTimePicker2.Value.Minute;//設定分
                MySystemTime.vSecond = (ushort)this.dateTimePicker2.Value.Second;//設定秒
                SetSystemDateTime.SetLocalTime(MySystemTime);//設定系統時間
                button1_Click(null, null);//執行按鈕點擊事件
            }
        }
    }
}