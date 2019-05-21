using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlFormStatus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.Width = Properties.Resources.登入界面標題.Width;//設定體的寬度
            this.Height = Properties.Resources.登入界面標題.Height + Properties.Resources.登入界面下面.Height;//設定視窗的高度
            panel_Title.BackgroundImage = Properties.Resources.登入界面標題;//顯示視窗標題欄的圖片
            panel_ALL.BackgroundImage = Properties.Resources.登入界面下面;//顯示視窗標題欄下同的圖片
            pictureBox_Min.Image = null;//清空PictuteBox控制元件
            pictureBox_Min.Image = Properties.Resources.最小化按鈕;//顯示最小化按鈕的圖片
            pictureBox_Max.Image = null; //清空PictuteBox控制元件
            pictureBox_Max.Image = Properties.Resources.最大化按鈕;//顯示最大化按鈕的圖片
            pictureBox_Close.Image = null;//清空PictuteBox控制元件
            pictureBox_Close.Image = Properties.Resources.關閉按鈕;//顯示關閉按鈕的圖片
        }

        #region  設定視窗的最大化、最小化和關閉按鈕的單擊事件
        /// <summary>
        /// 設定視窗的最大化、最小化和關閉按鈕的單擊事件
        /// </summary>
        /// <param Frm_Tem="Form">視窗</param>
        /// <param n="int">標識</param>
        public void FrmClickMeans(Form Frm_Tem, int n)
        {
            switch (n)//視窗的操作樣式
            {
                case 0://視窗最小化
                    Frm_Tem.WindowState = FormWindowState.Minimized;//視窗最小化
                    break;
                case 1://視窗最大化和還原的切換
                    {
                        if (Frm_Tem.WindowState == FormWindowState.Maximized)//如果視窗目前是最大化
                            Frm_Tem.WindowState = FormWindowState.Normal;//還原視窗大小
                        else
                            Frm_Tem.WindowState = FormWindowState.Maximized;//視窗最大化
                        break;
                    }
                case 2:	//關閉視窗
                    Frm_Tem.Close();
                    break;
            }
        }
        #endregion

        #region  控制圖片的切換狀態
        /// <summary>
        /// 控制圖片的切換狀態
        /// </summary>
        /// <param sender =" object ">要改變圖片的對象</param>
        /// <param n="int">標識</param>
        /// <param ns="int">移出移入標識</param>
        public static PictureBox Tem_PictB = new PictureBox();//實例化PictureBox控制元件
        public void ImageSwitch(object sender, int n, int ns)
        {
            Tem_PictB = (PictureBox)sender;
            switch (n)//取得標識
            {
                case 0://目前為最小化按鈕
                    {
                        Tem_PictB.Image = null;//清空圖片
                        if (ns == 0)//鼠標移入
                            Tem_PictB.Image = Properties.Resources.最小化變色;
                        if (ns == 1)//鼠標移出
                            Tem_PictB.Image = Properties.Resources.最小化按鈕;
                        break;
                    }
                case 1://最大化按鈕
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.最大化變色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.最大化按鈕;
                        break;
                    }
                case 2://關閉按鈕
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.關閉變色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.關閉按鈕;
                        break;
                    }
            }
        }
        #endregion

        private void pictureBox_Close_Click(object sender, EventArgs e)//單擊事件
        {
            FrmClickMeans(this, Convert.ToInt16(((PictureBox)sender).Tag.ToString()));//設定鼠標單擊時按鈕的圖片
        }
        private void pictureBox_Close_MouseEnter(object sender, EventArgs e)//鼠標移入事件
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 0);//設定鼠標移入後按鈕的圖片
        }
        private void pictureBox_Close_MouseLeave(object sender, EventArgs e)//鼠標移出事件
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 1);//設定鼠標移出後按鈕的圖片
        }
    }
}
