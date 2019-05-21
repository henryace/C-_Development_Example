using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetEventLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (eventLog1.Entries.Count > 0)
            {
                foreach (System.Diagnostics.EventLogEntry entry
                   in eventLog1.Entries)
                {
                    listBox1.Items.Add(entry.Message);
                }
            }
            else
            {
                MessageBox.Show("日誌中沒有記錄.");
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.EventLog.SourceExists("ZhyScoure"))//判斷是否存在事件源
            {
                System.Diagnostics.EventLog.DeleteEventSource("ZhyScoure");//刪除事件源註冊
            }
            System.Diagnostics.EventLog.//建立日誌訊息
                CreateEventSource("ZhyScoure", "NewLog1");
            eventLog1.Log = "NewLog1";//設定日誌名稱
            eventLog1.Source = "ZhyScoure";//事件源名稱
            this.eventLog1.MachineName = ".";//表示本機
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.EventLog.Exists("NewLog1"))//判斷日誌是否存在
            {
                if (textBox1.Text != "")//如果文字框為空
                {
                    eventLog1.WriteEntry(textBox1.Text.ToString());//寫入日誌
                    MessageBox.Show("日誌寫成功");//彈出消息對話框
                    textBox1.Text = "";//清空文字框訊息
                }
                else
                {
                    MessageBox.Show("日誌內容不能為空");//彈出消息對話框
                }
            }
            else
            {
                MessageBox.Show("日誌不存在");//彈出消息對話框
            }
        }
    }
}