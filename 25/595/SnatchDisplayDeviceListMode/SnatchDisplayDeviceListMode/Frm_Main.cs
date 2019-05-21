using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchDisplayDeviceListMode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher ListModeSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");//宣告一個用於檢索設備管理訊息的對象
            foreach (ManagementObject ListModeObject in ListModeSearcher.Get()) //循環深度搜尋WMI實例中的每一個對像
            {
                unhideMode.Text = ListModeObject["VideoModeDescription"].ToString(); //顯示設備的目前顯示模式
            }
            snatch.Enabled = false;//設定「取得」按鈕為不可用狀態
        }
    }
}
