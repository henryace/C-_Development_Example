using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DisplayRunTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private DateTime G_DateTime;//聲明時間欄位

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_DateTime = DateTime.Now;//得到系統目前時間
            Thread P_th = new Thread(//建立線程
                () =>//使用Lambda表達式
                {
                    while (true)//無限循環
                    {
                        TimeSpan P_TimeSpan =//得到時間差
                            DateTime.Now - G_DateTime;
                        Invoke(//呼叫視窗線程
                            (MethodInvoker)(() =>//使用Lambda表達式
                            {
                                tssLabel_Time.Text =//顯示程式啟動時間
                                    string.Format(
                                    "系統已經執行： {0}天{1}小時{2}分{3}秒",
                                    P_TimeSpan.Days, P_TimeSpan.Hours,
                                    P_TimeSpan.Minutes, P_TimeSpan.Seconds);
                            }));
                        Thread.Sleep(1000);//線程掛起1秒鐘
                    }
                });
            P_th.IsBackground = true;//設定為後台線程
            P_th.Start();//開始執行線程
        }
    }
}
