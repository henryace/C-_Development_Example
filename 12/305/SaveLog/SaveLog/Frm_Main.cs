using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace SaveLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.EventLog.SourceExists("ErrEventLog"))//判斷是否存在事件源
            {
                System.Diagnostics.EventLog.DeleteEventSource("ErrEventLog");//刪除事件源註冊
            }
            System.Diagnostics.EventLog.//建立日誌訊息
                CreateEventSource("ErrEventLog", "Application");
            eventLog2.Log = "Application";//設定日誌名稱
            eventLog2.Source = "ErrEventLog";//事件來源名稱
            this.eventLog1.MachineName = ".";//表示本機
        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            if (eventLog1.Entries.Count > 0)//判斷是否存在系統日誌
            {
                foreach (System.Diagnostics.EventLogEntry//深度搜尋日誌訊息
                    entry in eventLog1.Entries)
                {
                    if (entry.EntryType ==//判斷是否為錯誤日誌
                        System.Diagnostics.EventLogEntryType.Error)
                    {
                        listBox1.Items.Add(entry.Message);//向控制元件中新增資料項
                        eventLog2.WriteEntry(entry.Message,//寫入日誌訊息
                            System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("系統沒有錯誤日誌.");//彈出消息對話框
            }
        }
    }
}