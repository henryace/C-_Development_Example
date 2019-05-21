using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace WinRARFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "所有檔案(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("請選擇源檔案!", "訊息提示");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("請輸入壓縮檔案名!", "訊息提示");
                return;
            }

            String myRar;//表示WinRAR.exe檔案所在的路徑
            RegistryKey myReg;//宣告RegistryKey類的參考
            Object myObj;
            String myInfo;//表示壓縮命令的字串
            ProcessStartInfo myStartInfo;//宣告ProcessStartInfo類的參考
            Process myProcess;//宣告Process類的參考
            string strRar;//表示壓縮檔案名
            string strFile;//表示源檔案名
            try
            {
                //檢索註冊表HKEY_CLASSES_ROOT基項下的指定子項
                myReg = Registry.ClassesRoot.OpenSubKey(@"Applications\WinRAR.exe\Shell\Open\Command");
                myObj = myReg.GetValue("");//檢索子項中與指定名稱關聯的值
                myRar = myObj.ToString();//取得包含WinRAR.exe檔案所在路徑的字串
                myReg.Close();//關閉指定的註冊表項
                myRar = myRar.Substring(1, myRar.Length - 7);//取得WinRAR.exe檔案所在的完整路徑
                strRar = textBox2.Text.Trim() + ".rar";//設定壓縮檔案的名稱
                strFile = textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1);//取得源檔案的名稱
                myInfo = " a " + strRar + " " + strFile + "";//設定壓縮命令
                myStartInfo = new ProcessStartInfo();//實例化ProcessStartInfo類
                myStartInfo.FileName = myRar;//設定要啟動的應用程式
                myStartInfo.Arguments = myInfo;//設定啟動應用程式時要使用的命令參數
                myStartInfo.WindowStyle = ProcessWindowStyle.Hidden;//隱藏進程視窗
                myStartInfo.WorkingDirectory = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf("\\"));//設定要啟動的進程的初始目錄
                myProcess = new Process();//新建進程
                myProcess.StartInfo = myStartInfo;//設定要傳遞給進程的Start方法的屬性
                myProcess.Start();//啟動進程
                myProcess.WaitForExit();//等待關閉進程
                myProcess.Close();//釋放進程資源
                MessageBox.Show("壓縮檔案成功！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
