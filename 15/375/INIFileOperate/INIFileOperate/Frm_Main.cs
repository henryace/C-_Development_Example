using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace INIFileOperate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        #region 變數宣告區
        public string str = "";//該變數儲存INI文件所在的具體物理位置
        public string strOne = "";
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);

        public string ContentReader(string area, string key, string def)
        {
            StringBuilder stringBuilder = new StringBuilder(1024); 				//定義一個最大長度為1024的可變字串
            GetPrivateProfileString(area, key, def, stringBuilder, 1024, str); 			//讀取INI文件
            return stringBuilder.ToString();								//返回INI文件的內容
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string mpAppName,
            string mpKeyName,
            string mpDefault,
            string mpFileName);

        #endregion

        #region 視窗載入部分
        private void Form1_Load(object sender, EventArgs e)
        {
            str = Application.StartupPath + "\\ConnectString.ini";						//INI文件的物理地址
            strOne = System.IO.Path.GetFileNameWithoutExtension(str); 				//取得INI文件的文件名
            if (File.Exists(str)) 											//判斷是否存在該INI文件
            {
                server.Text = ContentReader(strOne, "Data Source", "");				//讀取INI文件中伺服器節點的內容
                database.Text = ContentReader(strOne, "DataBase", "");				//讀取INI文件中資料庫節點的內容
                uid.Text = ContentReader(strOne, "Uid", "");						//讀取INI文件中用戶節點的內容
                pwd.Text = ContentReader(strOne, "Pwd", "");						//讀取INI文件中密碼節點的內容
            }
        }
        #endregion

        #region 進行修改操作
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(str))											//判斷是否存在INI文件
            {
                WritePrivateProfileString(strOne, "Data Source", server.Text, str); 		//修改INI文件中伺服器節點的內容
                WritePrivateProfileString(strOne, "DataBase", database.Text, str); 		//修改INI文件中資料庫節點的內容
                WritePrivateProfileString(strOne, "Uid", uid.Text, str); 			//修改INI文件中用戶節點的內容
                WritePrivateProfileString(strOne, "Pwd", pwd.Text, str); 			//修改INI文件中密碼節點的內容
                MessageBox.Show("恭喜你，修改成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("對不起，你所要修改的檔案不存在，請確認後再進行修改操作！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
