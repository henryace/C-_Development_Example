using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UseSleep
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(//建立線程物件
                () =>//使用Lambda表達式
                {
                    while (true)//無限循環
                    {
                        Invoke(//在視窗線程中執行
                            (MethodInvoker)(() =>//使用Lambda表達式
                            {
                                txt_Time.Text =//顯示系統時間
                                    DateTime.Now.ToString("F");
                            }));
                        Thread.Sleep(1000);//線程掛起1000毫秒
                    }
                });
            th.IsBackground = true;//設定線程為後台線程
            th.Start();//開始執行線程
        }
    }
}
