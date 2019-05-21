using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumGame
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        System.Threading.Thread G_th;//定義線程

        Random G_random = new Random();//定義隨機數對像

        int G_int_num;//定義變數用於存放存機數

        private void btn_begin_Click(object sender, EventArgs e)
        {
            RemoveControl();//清空所有無用對像
            int p_int_x = 10;//X坐標預設值為10
            int p_int_y = 60;//Y坐標預設值為60
            for (int i = 0; i < 100; i++)//新增100個按鈕
            {
                Button bt = new Button();//建立button按鈕
                bt.Text = (i + 1).ToString();//設定button按鈕的文字值
                bt.Name = (i + 1).ToString();//設定button按鈕的Name屬性
                bt.Width = 35;//設定button按鈕的寬
                bt.Height = 35;//設定button按鈕的高
                bt.Location = new Point(p_int_x, p_int_y);//設定button按鈕的位置
                bt.Click += new EventHandler(bt_Click);//定義button按鈕的事件
                p_int_x += 36;//設定下一個按鈕的位置
                if ((i + 1) % 10 == 0)//設定換行
                {
                    p_int_x = 10;//換行後重新設定X坐標
                    p_int_y += 36;//換行後重新設定Y坐標
                }
                Controls.Add(bt);//將button按鈕放入視窗控制元件集合中
            }
            G_th = new System.Threading.Thread(//新建一條線程
                delegate()//使用匿名方法
                {
                    int P_int_count = 0;//初始化計數器
                    while (true)//開始無限循環
                    {
                        P_int_count = //計數器累加
                            ++P_int_count > 100000000 ? 0 : P_int_count;
                        this.Invoke(//將程式碼交給主線程執行
                            (MethodInvoker)delegate//使用匿名方法
                            {
                                lb_time.Text = //視窗中顯示計數
                                    P_int_count.ToString();
                            });
                        System.Threading.Thread.Sleep(1000);//線程睡眠1秒
                    }
                });
            G_th.IsBackground = true;//設定線程為後台線程
            G_th.Start();//開始執行線程
            G_int_num = G_random.Next(1, 100);//產生隨機數
            btn_begin.Enabled = false;//停用開始按鈕
        }

        void bt_Click(object sender, EventArgs e)
        {
            Control P_control = sender as Control;//將sender轉換為control類型對像
            if (int.Parse(P_control.Name) > G_int_num)
            {
                P_control.BackColor = Color.Red;//設定按鈕背景為紅色
                P_control.Enabled = false;//設定按鈕停用
                P_control.Text = "大";//更改按鈕文字
            }
            if (int.Parse(P_control.Name) < G_int_num)
            {
                P_control.BackColor = Color.Red;//設定按鈕背景為紅色
                P_control.Enabled = false;//設定按鈕停用
                P_control.Text = "小";//更改按鈕文字
            }
            if (int.Parse(P_control.Name) == G_int_num)
            {
                G_th.Abort();//終止計數線程
                MessageBox.Show(string.Format(//顯示遊戲訊息
                    "恭喜你猜對了！共猜了{0}次 用時{1}秒",
                    GetCount(), lb_time.Text), "恭喜！");
                btn_begin.Enabled = true;//啟用開始按鈕
            }
        }

        /// <summary>
        /// 用於搜尋視窗中Enable屬性為False控制元件的數量
        /// 用於計算玩家有多少次沒有猜中
        /// </summary>
        /// <returns>返回沒有猜中數量</returns>
        string GetCount()
        {
            int P_int_temp = 0;//初始化計數器
            foreach (Control c in Controls)//深度搜尋控制元件集合
            {
                if (!c.Enabled) P_int_temp++;//計數器累加
            }
            return P_int_temp.ToString();//返回計數器訊息
        }

        /// <summary>
        /// 用於清空視窗中動態產生的按鈕
        /// </summary>
        void RemoveControl()
        {
            for (int i = 0; i < 100; i++)//開始深度搜尋100個按鈕
            {
                if (Controls.ContainsKey(//視窗中是否有此按鈕
                    (i + 1).ToString()))
                {
                    for (int j = 0; j < Controls.Count; j++)//深度搜尋視窗控制元件集合
                    {
                        if (Controls[j].Name == //是否搜尋到按鈕
                            (i + 1).ToString())
                        {
                            Controls.RemoveAt(j);//刪除指定按鈕
                            break;
                        }
                    }
                }
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);//強行關閉視窗
        }
    }
}
