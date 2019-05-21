using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GetTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Thread P_th = new Thread(//建立線程物件
                () => //使用Lambda表達式
                {
                    while (true)//無限循環
                    {
                        Invoke(//呼叫視窗線程
                            (MethodInvoker)(() =>//使用Lambda表達式
                            {
                                toolStripStatusLabel1.Text =//設定狀態欄文字內容
                                   "目前系統時間： " + DateTime.Now.ToString("HH時mm分s秒");
                            }));
                        Thread.Sleep(1000);//線程掛起一秒
                    }
                });
            P_th.IsBackground = true;//設定線程為後台線程
            P_th.Start();//線程開始
        }
    }
}