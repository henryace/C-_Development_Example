using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Wallpaper
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.
StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + @"\Image\";			//取得圖片的所在路徑
            DirectoryInfo DInfo = new DirectoryInfo(strPath);					//實例化DirectoryInfo類
            FileInfo[] FInfo = DInfo.GetFiles();								//取得目前資料夾下的所有文件
            Random rand = new Random();								//實例化Random類
            int i = rand.Next(FInfo.Length);								//取得隨機數
            RegistryKey myRKey = Registry.CurrentUser; 						//取得冊注表中的基表
            myRKey = myRKey.OpenSubKey("Control Panel\\Desktop", true);		//檢索指定的子項
            //透過呼叫RegistryKey對象的SetValue方法隨機設定桌面壁紙
            myRKey.SetValue("WallPaper", strPath + FInfo[i].Name);
            myRKey.SetValue("TitleWallPaper", "2");
            myRKey.Close();
            MessageBox.Show("桌面壁紙已經更改！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}