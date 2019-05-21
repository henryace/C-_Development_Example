using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            System.Threading.Thread P_thread = //建立線程
                new System.Threading.Thread(
                () =>//使用lambda表達式
                {
                    while (true)//無限循環
                    {
                        this.Invoke(//操作視窗線程
                              (MethodInvoker)delegate()//使用匿名方法
                              {
                                  this.Refresh();//刷新視窗
                                  Graphics P_Graphics = //建立繪圖物件
                                      CreateGraphics();
                                  P_Graphics.DrawString("系統時間：" +//在視窗中繪出系統時間
                                      DateTime.Now.ToString(
                                      "yyyy年MM月dd日 HH時mm分ss秒"),
                                      new Font("細明體", 15),
                                      Brushes.Blue,
                                      new Point(10, 10));
                              });
                        System.Threading.Thread.Sleep(1000);//線程掛起1秒鐘
                    }
                });
            P_thread.IsBackground = true;//將線程設定為後台線程
            P_thread.Start();//線程開始執行
        }
    }
}
