using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace AddLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (eventLog1.Entries.Count > 0)
            {
                foreach (System.Diagnostics.EventLogEntry//深度搜尋所有日誌
                    entry in eventLog1.Entries)
                {
                    if (comboBox1.Items.Count == 0)//判斷是否為第一個日誌
                    {
                        comboBox1.Items.Add(//新增日誌訊息
                            entry.Source.ToString());
                    }
                    else
                    {
                        if (!comboBox1.Items.Contains(//判斷產生日誌訊息的應用程式是否重複
                            entry.Source.ToString()))
                        {
                            comboBox1.Items.Add(//新增日誌訊息
                                entry.Source.ToString());
                        }
                    }
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)//如果沒有選擇應用程式
            {
                MessageBox.Show("請選擇日誌名稱");//彈出消息對話框
                return;
            }
            if (textBox1.Text == "")//如果沒有添寫日誌內容
            {
                MessageBox.Show("請填寫日誌內容");//彈出消息對話框
                textBox1.Focus();//控制元件得到焦點
                return;//退出方法
            }
            eventLog1.Log = "System";//設定讀寫日誌的名稱
            eventLog1.Source = comboBox1.//設定日誌源名稱
                SelectedItem.ToString();
            eventLog1.MachineName = ".";//設定寫入日誌的計算機名稱
            eventLog1.WriteEntry(textBox1.Text);
            MessageBox.Show("新增成功");//彈出提示訊息
            if (eventLog1.Entries.Count > 0)//如果日誌中有內容
            {
                foreach (System.Diagnostics.EventLogEntry//深度搜尋日誌內容
                    entry in eventLog1.Entries)
                {
                    listView1.Items.Add(entry.Message);//在控制元件中顯示日誌內容
                }
            }
        }
    }
}
