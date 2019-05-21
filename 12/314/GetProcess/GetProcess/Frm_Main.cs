using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GetProcess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            process1.StartInfo.FileName = "notepad.exe";//設定將要啟動的應用程式
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process1.Start();//啟動應用程式
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] myProcesses;//建立進程集合變數
            myProcesses = System.Diagnostics.Process.GetProcessesByName("Notepad");//得到進程集合
            foreach (System.Diagnostics.Process instance in myProcesses)//深度搜尋進程集合
            {
                instance.CloseMainWindow();//向進程主視窗發送關閉消息
                instance.WaitForExit(3000);//在指定時間內等待進程退出
                instance.Close();//釋放與此進程關聯的所有資源
            }
        }
    }
}