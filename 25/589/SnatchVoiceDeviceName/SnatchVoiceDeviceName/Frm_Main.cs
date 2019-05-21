using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchVoiceDeviceName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_SoundDevice");//宣告一個用於檢索設備管理訊息的對象
            foreach (ManagementObject VoiceDeviceObject in VoiceDeviceSearcher.Get())//循環深度搜尋WMI實例中的每一個對像
            {
                VoiceDeviceName.Text = VoiceDeviceObject["ProductName"].ToString(); //在目前文字框中顯示聲音設備的名稱
                aristotle.Text = VoiceDeviceObject["PNPDeviceID"].ToString();//在目前文字框中顯示聲音設備的PNPDeviceID
            }
            snatch.Enabled = false;//設定「取得」按鈕為不可用狀態
        }
    }
}
