using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

namespace TimeTask
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMessage();//顯示任務訊息
            BeginTask();//開始監視任務
        }

        private List<task> G_Task = new List<task>();//任務集合

        /// <summary>
        /// 開始監視任務
        /// </summary>
        private void BeginTask()
        {
            Thread th = new Thread(//建立線程
                (() =>//使用Lambda表達式
                {
                    while (true)//無限循環
                    {
                        for (int i = 0; i < G_Task.Count; i++)//循環任務集合
                        {
                            if (DateTime.Now.ToShortDateString() == //判斷是否執行任務
                                G_Task[i].Date.ToShortDateString())
                            {
                                this.Invoke(//呼叫視窗線程
                                    ((MethodInvoker)(() =>//使用Lambda表達式
                                    {
                                        Form P_Form = new Form();//建立視窗對像
                                        Label lb_txt = new Label();//建立Label標籤
                                        lb_txt.Text = G_Task[i].Task;//設定標籤文字
                                        lb_txt.Font = new Font("隸書", 30);//設定標籤字體
                                        lb_txt.AutoSize = true;//設定標籤自動調整大小
                                        lb_txt.ForeColor = Color.Blue;//設定文字顏色
                                        P_Form.Controls.Add(lb_txt);//將標籤加入視窗控制元件集合
                                        P_Form.Width = 500;//設定視窗寬度
                                        P_Form.Height = 100;//設定視窗高度
                                        P_Form.StartPosition = //設定視窗開始位置
                                            FormStartPosition.CenterScreen;
                                        P_Form.Text = "任務提示！";//設定視窗標題文字
                                        P_Form.Show();//顯示視窗
                                    })));
                                new DataTier().Delete(//從資料庫中刪除資料
                                    G_Task[i].Date.ToShortDateString(),
                                    G_Task[i].Task);
                                Thread.Sleep(2000);//線程掛起2秒
                                G_Task.RemoveAt(i);//刪除任務集合中的任務
                                this.Invoke(//呼叫視窗線程
                                    ((MethodInvoker)(() =>//使用Lambda表達式
                                    {
                                        GetMessage();//顯示任務訊息
                                    })));
                                break;//退出循環
                            }
                        }
                        Thread.Sleep(5000);//線程掛起5秒
                    }
                }));
            th.IsBackground = true;//設定線程為後台線程
            th.Start();//開始執行線程
        }

        /// <summary>
        /// 顯示任務訊息
        /// </summary>
        private void GetMessage()
        {
            lv_Task.Items.Clear();//清空控制元件項
            G_Task = new DataTier().Select();//得到任務集合
            foreach (task t in G_Task)//深度搜尋任務集合
            {
                lv_Task.Items.Add(//向控制元件中加入任務項
                    new ListViewItem(new string[] 
                { 
                    t.Date.ToShortDateString(),t.Task
                }));
            }

        }

        private void Moth_Display_MouseUp(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show(//彈出消息對話框並判斷是否新增任務
                "是否新增任務", "提示！", MessageBoxButtons.OKCancel
                ) == DialogResult.OK)
            {
                if (txt_Task.Text != string.Empty)//如果任務內容不為空
                {
                    try
                    {
                        new DataTier().Add(//向資料庫中新增任務
                            Moth_Display.SelectionStart.ToShortDateString(),
                            txt_Task.Text);
                        MessageBox.Show(//彈出消息對話框
                            "新增任務成功！", "提示！");
                        GetMessage();
                    }
                    catch (Exception ex)//擷取異常
                    {
                        MessageBox.Show(//彈出消息對話框
                            "新增資料失敗！\r\n" + ex.Message, "錯誤！");
                    }
                }
                else
                {
                    MessageBox.Show(//彈出消息對話框
                        "請填寫任務訊息！", "提示！");
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lv_Task.SelectedIndices.Count != 0)//如果選中任務
            {
                foreach (ListViewItem lvi//深度搜尋選中控制元件中任務集合
                    in lv_Task.SelectedItems)
                {
                    new DataTier().Delete(//刪除任務
                        lvi.SubItems[0].Text,
                        lvi.SubItems[1].Text);
                    for (int i = 0; i < G_Task.Count; i++)
                    {
                        if (G_Task[i].Date.ToShortDateString() //深度搜尋任務集合
                            == lvi.SubItems[0].Text &&
                            G_Task[i].Task == lvi.SubItems[1].Text)
                        {
                            G_Task.RemoveAt(i);//刪除任務
                            break;//退出循環
                        }
                    }
                }

                MessageBox.Show(//彈出消息對話框
                    "成功刪除任務!", "提示！");
                GetMessage();//顯示任務訊息
            }
        }
    }
}
