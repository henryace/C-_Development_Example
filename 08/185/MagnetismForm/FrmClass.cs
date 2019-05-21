using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;//新增控制元件及視窗的命名空間
using System.Drawing;//新增Point的命名空間
using System.Collections;//為ArrayList新增命名空間

namespace MagnetismForm
{
    class FrmClass
    {
        #region  磁性視窗-公共變數
        //記錄視窗的隱藏與顯示
        public static bool Example_ListShow = false;
        public static bool Example_LibrettoShow = false;
        public static bool Example_ScreenShow = false;

        //記錄鼠標的目前位置
        public static Point CPoint;  //新增命名空間using System.Drawing;
        public static Point FrmPoint;
        public static int Example_FSpace = 10;//設定視窗間的距離

        //Frm_Play視窗的位置及大小
        public static int Example_Play_Top = 0;
        public static int Example_Play_Left = 0;
        public static int Example_Play_Width = 0;
        public static int Example_Play_Height = 0;
        public static bool Example_Assistant_AdhereTo = false;//輔助視窗是否磁性在一起

        //Frm_ListBos視窗的位置及大小
        public static int Example_List_Top = 0;
        public static int Example_List_Left = 0;
        public static int Example_List_Width = 0;
        public static int Example_List_Height = 0;
        public static bool Example_List_AdhereTo = false;//輔助視窗是否與主視窗磁性在一起

        //Frm_Libretto視窗的位置及大小
        public static int Example_Libretto_Top = 0;
        public static int Example_Libretto_Left = 0;
        public static int Example_Libretto_Width = 0;
        public static int Example_Libretto_Height = 0;
        public static bool Example_Libretto_AdhereTo = false;//輔助視窗是否與主視窗磁性在一起

        //視窗之間的距離差
        public static int Example_List_space_Top = 0;
        public static int Example_List_space_Left = 0;
        public static int Example_Libretto_space_Top = 0;
        public static int Example_Libretto_space_Left = 0;
        #endregion

        #region  檢測各視窗是否連接在一起
        /// <summary>
        /// 檢測各視窗是否連接在一起
        /// </summary>
        public void FrmBackCheck()
        {
            bool Tem_Magnetism = false;
            //Frm_ListBos與主視窗
            Tem_Magnetism = false;
            if ((Example_Play_Top - Example_List_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left - Example_List_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left + Example_List_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_List_Top - Example_List_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_List_Top + Example_List_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_List_AdhereTo = true;

            //Frm_Libretto與主視窗
            Tem_Magnetism = false;
            if ((Example_Play_Top - Example_Libretto_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left - Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left + Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_Libretto_Top - Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_Libretto_Top + Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_Libretto_AdhereTo = true;

            //兩個輔視窗
            Tem_Magnetism = false;
            if ((Example_List_Top - Example_Libretto_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left - Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left + Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Top - Example_Libretto_Top - Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Top - Example_Libretto_Top + Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_Assistant_AdhereTo = true;
        }
        #endregion

        #region  利用視窗上的控制元件移動視窗
        /// <summary>
        /// 利用控制元件移動視窗
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param e="MouseEventArgs">控制元件的移動事件</param>
        public void FrmMove(Form Frm, MouseEventArgs e)  //Form或MouseEventArgs新增命名空間using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//取得目前鼠標的屏幕坐標
                myPosittion.Offset(CPoint.X, CPoint.Y);//重載目前鼠標的位置
                Frm.DesktopLocation = myPosittion;//設定目前視窗在屏幕上的位置
            }
        }
        #endregion

        #region  計算視窗之間的距離差
        /// <summary>
        /// 計算視窗之間的距離差
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param Follow="Form">跟隨視窗</param>
        public void FrmDistanceJob(Form Frm, Form Follow)
        {
            switch (Follow.Name)
            {
                case "Frm_ListBox":
                    {
                        Example_List_space_Top = Follow.Top - Frm.Top;
                        Example_List_space_Left = Follow.Left - Frm.Left;
                        break;
                    }
                case "Frm_Libretto":
                    {
                        Example_Libretto_space_Top = Follow.Top - Frm.Top;
                        Example_Libretto_space_Left = Follow.Left - Frm.Left;
                        break;
                    }
            }
        }
        #endregion

        #region  磁性視窗的移動
        /// <summary>
        /// 磁性視窗的移動
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param e="MouseEventArgs">控制元件的移動事件</param>
        /// <param Follow="Form">跟隨視窗</param>
        public void ManyFrmMove(Form Frm, MouseEventArgs e, Form Follow)  //Form或MouseEventArgs新增命名空間using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                int Tem_Left = 0;
                int Tem_Top = 0;
                Point myPosittion = Control.MousePosition;//取得目前鼠標的屏幕坐標
                switch (Follow.Name)
                {
                    case "Frm_ListBox":
                        {
                            Tem_Top = Example_List_space_Top - FrmPoint.Y;
                            Tem_Left = Example_List_space_Left - FrmPoint.X;
                            break;
                        }
                    case "Frm_Libretto":
                        {
                            Tem_Top = Example_Libretto_space_Top - FrmPoint.Y;
                            Tem_Left = Example_Libretto_space_Left - FrmPoint.X;
                            break;
                        }
                }
                myPosittion.Offset(Tem_Left, Tem_Top);
                Follow.DesktopLocation = myPosittion;
            }
        }
        #endregion

        #region  對視窗的位置進行初始化
        /// <summary>
        /// 對視窗的位置進行初始化
        /// </summary>
        /// <param Frm="Form">視窗</param>
        public void FrmInitialize(Form Frm)
        {
            switch (Frm.Name)
            {
                case "Frm_Play":
                    {
                        Example_Play_Top = Frm.Top;
                        Example_Play_Left = Frm.Left;
                        Example_Play_Width = Frm.Width;
                        Example_Play_Height = Frm.Height;
                        break;
                    }
                case "Frm_ListBox":
                    {
                        Example_List_Top = Frm.Top;
                        Example_List_Left = Frm.Left;
                        Example_List_Width = Frm.Width;
                        Example_List_Height = Frm.Height;
                        break;
                    }
                case "Frm_Libretto":
                    {
                        Example_Libretto_Top = Frm.Top;
                        Example_Libretto_Left = Frm.Left;
                        Example_Libretto_Width = Frm.Width;
                        Example_Libretto_Height = Frm.Height;
                        break;
                    }
            }

        }
        #endregion

        #region  存儲各視窗的目前訊息
        /// <summary>
        /// 存儲各視窗的目前訊息
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param e="MouseEventArgs">控制元件的移動事件</param>
        public void FrmPlace(Form Frm)
        {
            FrmInitialize(Frm);
            FrmMagnetism(Frm);
        }
        #endregion

        #region  視窗的磁性設定
        /// <summary>
        /// 視窗的磁性設定
        /// </summary>
        /// <param Frm="Form">視窗</param>
        public void FrmMagnetism(Form Frm)
        {
            if (Frm.Name != "Frm_Play")
            {
                FrmMagnetismCount(Frm, Example_Play_Top, Example_Play_Left, Example_Play_Width, Example_Play_Height, "Frm_Play");
            }
            if (Frm.Name != "Frm_ListBos")
            {
                FrmMagnetismCount(Frm, Example_List_Top, Example_List_Left, Example_List_Width, Example_List_Height, "Frm_ListBos");
            }
            if (Frm.Name != "Frm_Libratto")
            {
                FrmMagnetismCount(Frm, Example_Libretto_Top, Example_Libretto_Left, Example_Libretto_Width, Example_Libretto_Height, "Frm_Libratto");
            }
            FrmInitialize(Frm);
        }
        #endregion

        #region  磁性視窗的計算
        /// <summary>
        /// 磁性視窗的計算
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param e="MouseEventArgs">控制元件的移動事件</param>
        public void FrmMagnetismCount(Form Frm, int top, int left, int width, int height, string Mforms)
        {
            bool Tem_Magnetism = false;//判斷是否有磁性發生
            string Tem_MainForm = "";//臨時記錄主視窗
            string Tem_AssistForm = "";//臨時記錄輔視窗

            //上面進行磁性視窗
            if ((Frm.Top + Frm.Height - top) <= Example_FSpace && (Frm.Top + Frm.Height - top) >= -Example_FSpace)
            {
                //當一個主視窗不包含輔視窗時
                if ((Frm.Left >= left && Frm.Left <= (left + width)) || ((Frm.Left + Frm.Width) >= left && (Frm.Left + Frm.Width) <= (left + width)))
                {
                    Frm.Top = top - Frm.Height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
                //當一個主視窗包含輔視窗時
                if (Frm.Left <= left && (Frm.Left + Frm.Width) >= (left + width))
                {
                    Frm.Top = top - Frm.Height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }

            }

            //下面進行磁性視窗
            if ((Frm.Top - (top + height)) <= Example_FSpace && (Frm.Top - (top + height)) >= -Example_FSpace)
            {
                //當一個主視窗不包含輔視窗時
                if ((Frm.Left >= left && Frm.Left <= (left + width)) || ((Frm.Left + Frm.Width) >= left && (Frm.Left + Frm.Width) <= (left + width)))
                {
                    Frm.Top = top + height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
                //當一個主視窗包含輔視窗時
                if (Frm.Left <= left && (Frm.Left + Frm.Width) >= (left + width))
                {
                    Frm.Top = top + height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
            }

            //左面進行磁性視窗
            if ((Frm.Left + Frm.Width - left) <= Example_FSpace && (Frm.Left + Frm.Width - left) >= -Example_FSpace)
            {
                //當一個主視窗不包含輔視窗時
                if ((Frm.Top > top && Frm.Top <= (top + height)) || ((Frm.Top + Frm.Height) >= top && (Frm.Top + Frm.Height) <= (top + height)))
                {
                    Frm.Left = left - Frm.Width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
                //當一個主視窗包含輔視窗時
                if (Frm.Top <= top && (Frm.Top + Frm.Height) >= (top + height))
                {
                    Frm.Left = left - Frm.Width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
            }

            //右面進行磁性視窗
            if ((Frm.Left - (left + width)) <= Example_FSpace && (Frm.Left - (left + width)) >= -Example_FSpace)
            {
                //當一個主視窗不包含輔視窗時
                if ((Frm.Top > top && Frm.Top <= (top + height)) || ((Frm.Top + Frm.Height) >= top && (Frm.Top + Frm.Height) <= (top + height)))
                {
                    Frm.Left = left + width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
                //當一個主視窗包含輔視窗時
                if (Frm.Top <= top && (Frm.Top + Frm.Height) >= (top + height))
                {
                    Frm.Left = left + width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
            }
            if (Frm.Name == "Frm_Play")
                Tem_MainForm = "Frm_Play";
            else
                Tem_AssistForm = Frm.Name;
            if (Mforms == "Frm_Play")
                Tem_MainForm = "Frm_Play";
            else
                Tem_AssistForm = Mforms;
            if (Tem_MainForm == "")
            {
                Example_Assistant_AdhereTo = Tem_Magnetism;
            }
            else
            {
                switch (Tem_AssistForm)
                {
                    case "Frm_ListBos":
                        Example_List_AdhereTo = Tem_Magnetism;
                        break;
                    case "Frm_Libratto":
                        Example_Libretto_AdhereTo = Tem_Magnetism;
                        break;
                }
            }
        }
        #endregion

        #region  恢復視窗的初始大小
        /// <summary>
        /// 恢復視窗的初始大小(當鬆開鼠標時，如果視窗的大小小於300*200,恢復初始狀態)
        /// </summary>
        /// <param Frm="Form">視窗</param>
        public void FrmScreen_FormerlySize(Form Frm, int PWidth, int PHeight)
        {
            if (Frm.Width < PWidth || Frm.Height < PHeight)
            {
                Frm.Width = PWidth;
                Frm.Height = PHeight;
                //Example_Size = false;
            }
        }
        #endregion

    }
}
