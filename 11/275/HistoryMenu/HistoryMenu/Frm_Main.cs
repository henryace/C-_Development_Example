using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace HistoryMenu
{
    public partial class Frm_Main : Form
    {
        string address;
        public Frm_Main()
        {
            InitializeComponent();
            address = //得到應用程式路徑
                Environment.CurrentDirectory;
        }

        private void 打開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";//設定預設打開文件名稱
            openFileDialog1.ShowDialog();//彈出打開文件對話框
            StreamWriter s = //建立流寫入器物件
                new StreamWriter(address + "\\History.ini", true);
            s.WriteLine(openFileDialog1.FileName);//向文件中寫入歷史訊息
            s.Flush();//將訊息壓入流
            s.Close();//關閉流
            ShowWindows(openFileDialog1.FileName);//打開新視窗
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = //建立流讀取器物件
                new StreamReader(address + "\\History.ini");
            int i = //得到功能表項索引
                文件ToolStripMenuItem.DropDownItems.Count - 2;
            while (sr.Peek() >= 0)//循環讀取流中文字
            {
                ToolStripMenuItem menuitem = //建立功能表項物件
                    new ToolStripMenuItem(sr.ReadLine());
                this.文件ToolStripMenuItem.//向功能表中新增新項
                    DropDownItems.Insert(i, menuitem);
                i++;//向功能表中插入索引的位置
                menuitem.Click += //新增點擊事件
                    new EventHandler(menuitem_Click);
            }
            sr.Close();
        }

        private void menuitem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = //得到功能表項
                (ToolStripMenuItem)sender;
            ShowWindows(menu.Text);//打開新視窗
        }
        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);//得到圖像物件
            Form f = new Form();//建立視窗物件
            f.MdiParent = this;//設定父視窗
            f.BackgroundImage = p;//設定背景圖片
            f.Show();//顯示視窗
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出應用程式
        }
    }
}