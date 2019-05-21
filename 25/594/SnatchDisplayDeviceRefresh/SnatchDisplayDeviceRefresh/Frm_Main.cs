using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchDisplayDeviceRefresh
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher RefreshSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");//宣告一個用於檢索設備管理訊息的對象
            foreach (ManagementObject RefreshObject in RefreshSearcher.Get())//循環深度搜尋WMI實例中的每一個對像
            {
                maxRefresh.Text = RefreshObject["MaxRefreshRate"].ToString() + "赫茲"; //顯示最大更新率
                minRefresh.Text = RefreshObject["MinRefreshRate"].ToString() + "赫茲"; //顯示最小更新率
                nowRefresh.Text = RefreshObject["CurrentRefreshRate"].ToString() + "赫茲"; //在框中顯示目前更新率
            }
            snatch.Enabled = false;//設定「取得」按鈕為不可用狀態
        }
    }
}
