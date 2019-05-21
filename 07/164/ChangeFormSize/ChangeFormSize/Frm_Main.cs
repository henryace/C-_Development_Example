using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChangeFormSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public static int Example_X = 0;
        public static int Example_Y = 0;
        public static int Example_W = 0;
        public static Point CPoint;

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

        #region  取得鼠標的目前位置
        /// <summary>
        /// 取得鼠標的目前位置
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param e="MouseEventArgs">視窗上有關鼠標的一些訊息</param>
        public void FrmScreen_SizeInfo(Form Frm, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Example_X = e.X;
                Example_Y = e.Y;
                Example_W = Frm.Width;
            }
        }
        #endregion

        #region  改變視窗的大小(用於鼠標的移動事件)
        /// <summary>
        /// 改變視窗的大小(用於鼠標的移動事件)
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param Pan="Panel">設定視窗邊框的控制元件</param>
        /// <param e="MouseEventArgs">視窗上有關鼠標的一些訊息</param>
        public void FrmScreen_EnlargeSize(Form Frm, Panel Pan, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (Pan.Name)
                {
                    case "panel_Right":						//如果移動的是視窗的右邊框
                        {
                            if (this.Width <= 70)				//如果視窗的寬度小於等於70
                            {
                                Frm.Width = 70;				//設定視窗的寬度為70
                                //如果用鼠標向右移動視窗的右邊框
                                if (Cursor.Position.X - Frm.Left + (Pan.Width - Example_X) > Frm.Width)
                                {
                                    //根據鼠標的移動值，增加視窗的寬度
                                    Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                                }
                                break;
                            }
                            //根據鼠標的移動值，增加視窗的寬度
                            Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                            break;
                        }
                    case "panel_BR":						//如果移動的是視窗的右下角
                        {
                            //如果視窗的大小不為視窗大小的最小值
                            if (this.Width > 70 && this.Height > (panel_Title.Height + panel_Bn.Height + 1))
                            {
                                //根據鼠標的移動改變視窗的大小
                                Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);
                                Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                            }
                            else
                            {
                                if (this.Width <= 70)			//如果視窗的寬度小於等於最小值
                                {
                                    Frm.Width = 70;			//設定視窗的寬度為70
                                    if (this.Height <= (panel_Title.Height + panel_Bn.Height + 1))//如果視窗的高小於最小值
                                    {
                                        Frm.Height = panel_Title.Height + panel_Bn.Height + 1;//設定視窗的最小高度
                                        //如果用鼠標向下移動視窗的底邊框
                                        if (Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y) > Frm.Height)
                                        {
                                            //根據鼠標的移動值，增加視窗的高度
                                            Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);
                                        }
                                        break;
                                    }
                                    //如果用鼠標向右移動視窗
                                    if (Cursor.Position.X - Frm.Left + (Pan.Width - Example_X) > Frm.Width)
                                    {
                                        //增加視窗的寬度
                                        Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                                    }
                                    break;
                                }
                                if (this.Height <= (panel_Title.Height + panel_Bn.Height + 1))//如果視窗的高度小於等於最小值
                                {
                                    Frm.Height = panel_Title.Height + panel_Bn.Height + 1;//設定視窗的高度為最小值
                                    Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);//改變視窗的寬度
                                    //如果用鼠標向下移動視窗的邊框
                                    if (Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y) > Frm.Height)
                                    {
                                        Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);//增加視窗的高度
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    case "panel_Bn"://如果移動的是視窗的底邊框
                        {
                            if (this.Height <= (panel_Title.Height + panel_Bn.Height + 1))//如果視窗的高度小於等於最小值
                            {
                                Frm.Height = panel_Title.Height + panel_Bn.Height + 1;//設定視窗的高度為最小值
                                //如果用鼠標向下移動視窗的下邊框
                                if (Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y) > Frm.Height)
                                {
                                    Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);	//增加視窗的高度
                                }
                                break;
                            }
                            Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);			//增加視窗的高度
                            break;
                        }
                }
            }
        }
        #endregion

        private void panel_Right_MouseDown(object sender, MouseEventArgs e)
        {
            FrmScreen_SizeInfo(this, e);//取得鼠標的目前位置
        }

        private void panel_Right_MouseMove(object sender, MouseEventArgs e)
        {
            FrmScreen_EnlargeSize(this, (Panel)sender, e);//改變視窗的大小
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_TitL_MouseDown(object sender, MouseEventArgs e)
        {
            int Tem_X = -e.X;
            if (Convert.ToInt16(((Panel)sender).Tag.ToString()) == 2)//如果移動的是標題欄的中間部分
                Tem_X = -e.X - panel_TitL.Width;
            if (Convert.ToInt16(((Panel)sender).Tag.ToString()) == 3)//如果移動的是標題欄的尾端
                Tem_X = -(this.Width - ((Panel)sender).Width) - e.X;
            CPoint = new Point(Tem_X, -e.Y);
        }

        private void panel_TitL_MouseMove(object sender, MouseEventArgs e)
        {
            FrmMove(this, e);
        }

    }
}
