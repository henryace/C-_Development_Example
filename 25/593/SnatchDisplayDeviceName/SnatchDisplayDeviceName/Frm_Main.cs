using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchDisplayDeviceName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher FlashDevice = new ManagementObjectSearcher("select * from win32_VideoController");//宣告一個用於檢索設備管理訊息的對象
            foreach (ManagementObject FlashDeviceObject in FlashDevice.Get())//循環深度搜尋WMI實例中的每一個對像
            {
                printName.Text = FlashDeviceObject["name"].ToString();//在文字框中顯示顯示設備的名稱
                aristotle.Text = FlashDeviceObject["PNPDeviceID"].ToString();//在文字框中顯示顯示設備的PNPDeviceID
            }
        }
    }
}
