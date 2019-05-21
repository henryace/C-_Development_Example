using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HideToolBar
{
    public partial class Frm_Main : Form
    {
        #region 宣告本程式中用到的API函數
        //取得目前鼠標下可視化控制元件的函數
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        //取得指定句柄的父級函數
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        //取得屏幕的大小
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        #endregion

        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 執行本程式需要宣告的變數
        private IntPtr CurrentHandle;//記錄鼠標目前狀態下控制元件的句柄
        private int WindowFlag;//標記是否對視窗進行拉伸操作 
        private int intOriHeight;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            intOriHeight = this.Height;
            this.DesktopLocation = new Point(794, 0);   //為目前視窗定位
            JudgeWinMouPosition.Enabled = true;      //計時器JudgeWinMouPosition開始工作
            listView1.Clear();
            listView1.LargeImageList = imageList1;
            listView1.Items.Add("小豬", "小豬", 0);
            listView1.Items.Add("小狗", "小狗", 1);
            listView1.Items.Add("嬌嬌", "嬌嬌", 2);
        }


        public int OriHeight
        {
            get { return intOriHeight; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button1.Dock = DockStyle.Top;
            button2.Dock = DockStyle.Bottom;
            button3.Dock = DockStyle.Bottom;
            button3.SendToBack();
            listView1.BringToFront();
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("小豬", "小豬", 0);
            listView1.Items.Add("小狗", "小狗", 1);
            listView1.Items.Add("嬌嬌", "嬌嬌", 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;

            button2.Dock = DockStyle.Top;

            button1.Dock = DockStyle.Top;
            button1.SendToBack();

            button3.Dock = DockStyle.Bottom;
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("北風", "北風", 3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;

            button3.Dock = DockStyle.Top;//設定button3按鈕繫結到視窗的上邊緣

            button2.Dock = DockStyle.Top;//設定button2按鈕繫結到視窗的上邊緣
            button2.SendToBack();           //保證button2在button3的後面

            button1.Dock = DockStyle.Top;
            button1.SendToBack();//保證button1在button2的後面


            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("冰雨", "冰雨", 5);
        }

        private void JudgeWinMouPosition_Tick(object sender, EventArgs e)
        {
            if (this.Top < 3)                       //當本視窗距屏幕的上邊距小於3px時
            {
                if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))//當鼠標在該視窗上時
                {
                    WindowFlag = 1;                //設定目前的視窗狀態
                    HideWindow.Enabled = false;     //設定計時器HideWindow為不可用狀態
                    this.Top = 0;                 //設定視窗上邊緣與容器工作區上邊緣之間的距離
                }
                else                              //當鼠標沒在視窗上時
                {
                    WindowFlag = 1;                //設定目前的視窗狀態
                    HideWindow.Enabled = true;      //啟動計時器HideWindow

                }
            }                                     //當本視窗距屏幕的上邊距大於3px時
            else
            {
                //當本視窗在屏幕的最左端或者最右端、最下端時
                if (this.Left < 3 || (this.Left + this.Width) > (GetSystemMetrics(0) - 3) || (this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 3))
                {
                    if (this.Left < 3)              //當視窗處於屏幕左側時
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))    //當鼠標在該視窗上時
                        {
                            this.Height = Screen.AllScreens[0].Bounds.Height - 40;
                            this.Top = 3;
                            WindowFlag = 2;        //設定目前的視窗狀態
                            HideWindow.Enabled = false;//設定計時器HideWindow為不可用狀態
                            this.Left = 0;         //設定視窗的左邊緣與容器工作區的左邊緣之間的距離
                        }
                        else                      //當鼠標沒在該視窗上時
                        {
                            WindowFlag = 2;        //設定目前的視窗狀態
                            HideWindow.Enabled = true;//設定計時器HideWindow為可用狀態

                        }
                    }
                    if ((this.Left + this.Width) > (GetSystemMetrics(0) - 3)) //當視窗處於屏幕的最右側時
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))//當鼠標處於視窗上時
                        {
                            this.Height = Screen.AllScreens[0].Bounds.Height - 40;
                            this.Top = 3;
                            WindowFlag = 3;        //設定目前的視窗狀態
                            HideWindow.Enabled = false; //設定計時器HideWindow為不可用狀態
                            this.Left = GetSystemMetrics(0) - this.Width;//設定該視窗與容器工作區左邊緣之間的距離
                        }
                        else                          //當鼠標離開視窗時
                        {
                            WindowFlag = 3;            //設定目前的視窗狀態
                            HideWindow.Enabled = true;  //設定計時器HideWindow為可用狀態
                        }
                    }
                    //當視窗距屏幕最下端的距離小於3px時
                    if ((this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 3))
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y)) //當鼠標在該視窗上時
                        {
                            WindowFlag = 4;           //設定目前的視窗狀態
                            HideWindow.Enabled = false;//設定計時器HideWindow為不可用狀態
                            this.Top = Screen.AllScreens[0].Bounds.Height - this.Height;//設定該視窗與容器工作區上邊緣之間的距離
                        }
                        else
                        {
                            if ((this.Left > this.Width + 3) && (GetSystemMetrics(0) - this.Right) > 3)
                            {
                                WindowFlag = 4;           //設定目前的視窗狀態
                                HideWindow.Enabled = true; //設定計時器HideWindow為可用狀態
                            }
                        }
                    }
                }
            }
        }

        private void HideWindow_Tick(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(WindowFlag.ToString())) //判斷目前視窗處於那個狀態
            {
                case 1:             //當視窗處於最上端時   
                    if (this.Top < 3)   //當視窗與容器工作區的上邊緣的距離小於5px時
                        this.Top = -(this.Height - 2);  //設定目前視窗距容器工作區上邊緣的值
                    break;
                case 2:              //當視窗處於最左端時
                    if (this.Left < 3)//當視窗與容器工作區的左邊緣的距離小於5px時
                        this.Left = -(this.Width - 2); //設定目前視窗據容器工作區左邊緣的值
                    break;
                case 3:             //當視窗處於最右端時
                    if ((this.Left + this.Width) > (GetSystemMetrics(0) - 3))  //當視窗與容器工作區的右邊緣的距離小於5px時
                        this.Left = GetSystemMetrics(0) - 2;    //設定目前視窗距容器工作區左邊緣的值
                    break;
                case 4:             //當視窗處於最低端時
                    if (this.Bottom > Screen.AllScreens[0].Bounds.Height - 3)//當視窗與容器工作區的下邊緣的距離小於5px時
                        this.Top = Screen.AllScreens[0].Bounds.Height - 5;   //設定目前視窗距容器工作區上邊緣之間的距離
                    break;
            }
        }

        #region 取得鼠標目前狀態下控制元件的句柄
        /// <summary>
        /// 取得鼠標目前狀態下控制元件的句柄
        /// </summary>
        /// <param name="x">目前鼠標的X坐標</param>
        /// <param name="y">目前鼠標的Y坐標</param>
        /// <returns></returns>
        public IntPtr MouseNowPosition(int x, int y)
        {
            IntPtr OriginalHandle;//宣告儲存原始句柄的變數
            OriginalHandle = ((IntPtr)WindowFromPoint(x, y));//取得包含鼠標原始位置的視窗的句柄
            CurrentHandle = OriginalHandle;//設定目前句柄
            while (OriginalHandle != ((IntPtr)0))//循環判斷鼠標是否移動
            {
                CurrentHandle = OriginalHandle;//記錄目前的句柄
                OriginalHandle = GetParent(CurrentHandle);//更新原始句柄
            }
            return CurrentHandle;  //返回目前的句柄
        }
        #endregion

        //當視窗離開左右隱藏區域時，視窗回復原有高度
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (this.Left > 3 && this.Right < (GetSystemMetrics(0) - 3))
            {
                if (this.Height == Screen.AllScreens[0].Bounds.Height - 40)
                {
                    this.Height = OriHeight;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            listView1.Height = this.Height - button3.Height * 3 - 30;
        }
    }
}