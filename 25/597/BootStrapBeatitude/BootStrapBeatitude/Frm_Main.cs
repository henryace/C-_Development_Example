using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace BootStrapBeatitude
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath(); 	//初始化一個表示一系列相互連接的直線和曲線的類
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height)); 	//初始化一個矩形操作區域
            gp.AddEllipse(rect); 				//向目前指定的路徑下新增一個橢圓
            this.Region = new Region(gp); 		//設定與此控制元件關聯的視窗區域
            this.label3.Text = DateTime.Now.ToShortDateString();	//在label3控制元件中顯示目前的日期
            this.label5.Text = DateTime.Now.ToShortTimeString(); 	//在label5中顯示目前的時間
            GraphicsPath gpstirng = new GraphicsPath(); 			//初始化一個表示一系列相互連接的直線和曲線的類
            FontFamily family = new FontFamily("細明體");			//初始化一個字體樣式類
            int fontStyle = (int)FontStyle.Italic; 		//設定字體的樣式類型
            int emSize = 25; 					//初始化一個emSize變數
            Point origin = new Point(0, 0); 		//初始化一個有序實數對的實例
            StringFormat format = StringFormat.GenericDefault; 	//實例化一個包含文字佈局訊息的對象
            gpstirng.AddString("開開心心每一天", family, fontStyle, emSize, origin, format); 	//向指定的路徑新增字串
            this.button1.Region = new Region(gpstirng); 			//設定與button1控制元件關聯的視窗區域
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").SetValue("MyAngel", Application.StartupPath + "\\Ex05_13.exe", RegistryValueKind.String); 		//打開註冊表中的現有項並設定其中的鍵值類型
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}