using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PopupForm
{
    public partial class Frm_Info : System.Windows.Forms.Form
    {
        #region 宣告的變數
        private System.Drawing.Rectangle Rect;//定義一個存儲矩形框的陣列
        private FormState InfoStyle = FormState.Hide;//定義變數為隱藏
        static private Frm_Info dropDownForm = new Frm_Info();//實例化目前視窗
        private static int AW_HIDE = 0x00010000; //該變數表示動畫隱藏視窗
        private static int AW_SLIDE = 0x00040000;//該變數表示出現滑行效果的視窗
        private static int AW_VER_NEGATIVE = 0x00000008;//該變數表示從下向上開屏
        private static int AW_VER_POSITIVE = 0x00000004;//該變數表示從上向下開屏
        #endregion

        #region 該視窗的構造方法
        public Frm_Info()
        {
            InitializeComponent();
            //初始化工作區大小
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.GetWorkingArea(this);//實例化一個目前視窗的對象
            this.Rect = new System.Drawing.Rectangle(rect.Right - this.Width - 1, rect.Bottom - this.Height - 1, this.Width, this.Height);//為實例化的對象建立工作區域
        }
        #endregion

        #region 呼叫API函數顯示視窗
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

        #region 鼠標控制圖片的變化
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[1];//設定當鼠標進入PictureBox控制元件時PictureBox控制元件的圖片
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0]; //設定當鼠標離開PictureBox控制元件時PictureBox控制元件的圖片
        }
        #endregion

        #region 定義標識視窗移動狀態的枚舉值
        protected enum FormState
        {

            Hide = 0,//隱藏視窗
            Display = 1,//顯示視窗
            Displaying = 2,//顯示視窗中
            Hiding = 3 //隱藏視窗中
        }
        #endregion

        #region 用屬性標識目前狀態
        protected FormState FormNowState
        {
            get { return this.InfoStyle; }   //返回視窗的目前狀態
            set { this.InfoStyle = value; }  //設定視窗目前狀態的值
        }
        #endregion

        #region 顯示視窗
        public void ShowForm()
        {
            switch (this.FormNowState)
            {
                case FormState.Hide:
                    if (this.Height <= this.Rect.Height - 192)//當視窗沒有完全顯示時
                        this.SetBounds(Rect.X, this.Top - 192, Rect.Width, this.Height + 192);//使視窗不斷上移
                    else
                    {
                        this.SetBounds(Rect.X, Rect.Y, Rect.Width, Rect.Height);//設定目前視窗的邊界
                    }
                    AnimateWindow(this.Handle, 800, AW_SLIDE + AW_VER_NEGATIVE);//動態顯示本視窗
                    break;
            }
        }
        #endregion

        #region 關閉視窗
        public void CloseForm()
        {
            AnimateWindow(this.Handle, 800, AW_SLIDE + AW_VER_POSITIVE + AW_HIDE);//動畫隱藏視窗
            this.FormNowState = FormState.Hide;//設定目前視窗的狀態為隱藏
        }
        #endregion

        #region 返回目前視窗的實例化物件
        static public Frm_Info Instance()
        {
            return dropDownForm; //返回目前視窗的實例化物件
        }
        #endregion
    }
}
