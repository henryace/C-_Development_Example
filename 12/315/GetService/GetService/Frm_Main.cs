using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
namespace GetService
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //下面的範例使用 ServiceController 類檢查IIS服務是否已停止。如果該服務已停止，此範例將啟動該服務並等待服務狀態設定為 Running。
            //此範例使用 ServiceController 元件在本地計算機上繼續 IIS 管理服務
            //serviceController1.MachineName = ".";
            //serviceController1.ServiceName = "IISAdmin";//IIS 服務
        }
        //開啟IIS服務的狀態
        private void button1_Click(object sender, EventArgs e)
        {
            serviceController1.MachineName = ".";//設定此服務所在的計算機名稱
            serviceController1.ServiceName = "IISAdmin";//設定服務名稱
            if (serviceController1.Status == //判斷服務狀態
                ServiceControllerStatus.Running)
            {
                MessageBox.Show(//彈出消息對話框
                    serviceController1.DisplayName + "  服務正在執行");
                Application.Exit();//退出應用程式
            }
            else
            {
                serviceController1.Start();//啟動服務
                MessageBox.Show(//彈出消息對話框
                    serviceController1.DisplayName + "  服務已開啟");
                Application.Exit();//退出應用程式
            }

        }
        //判斷IIS服務的狀態
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serviceController1.MachineName = ".";//設定此服務所在的計算機名稱
                serviceController1.ServiceName = "IISAdmin";//設定服務名稱
                if (serviceController1.Status == //判斷服務狀態
                    ServiceControllerStatus.Running)
                {
                    MessageBox.Show(//彈出消息對話框
                        serviceController1.DisplayName + "  服務已開啟");
                    btn_Stop.Enabled = true;//啟用停止服務按鈕
                    btn_Status.Enabled = false;//停用狀態按鈕

                }
                else
                {
                    MessageBox.Show(//彈出消息對話框
                        serviceController1.DisplayName + "服務已停止");
                    btn_Status.Enabled = false;//停用狀態按鈕
                    btn_Start.Enabled = true;//啟用開始服務按鈕

                }
            }
            catch (Exception ee)//擷取異常
            { MessageBox.Show(ee.Message); }//彈出消息對話框

        }

        //停止IIS服務的狀態
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serviceController1.MachineName = ".";//設定此服務所在的計算機名稱
                serviceController1.ServiceName = "IISAdmin";//設定服務名稱
                if (serviceController1.CanStop)//判斷是否可以停止服務
                {
                    serviceController1.Stop();//停止服務
                    MessageBox.Show(//彈出消息對話框
                        serviceController1.DisplayName + "服務已停止");
                    Application.Exit();//退出應用程式
                }
                else
                {
                    MessageBox.Show(//彈出消息對話框
                        serviceController1.DisplayName + "不可以停止");
                    Application.Exit();//退出應用程式
                }
            }
            catch (Exception ee)//擷取異常
            { MessageBox.Show(ee.Message); }//彈出消息對話框
        }
    }
}