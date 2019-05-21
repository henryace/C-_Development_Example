using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagnetismForm
{
    public partial class Frm_Play : Form
    {
        public Frm_Play()
        {
            InitializeComponent();
        }

        #region  公共變數
        FrmClass Cla_FrmClass = new FrmClass();
        public static Form F_List = new Form();
        public static Form F_Libretto = new Form();
        public static Form F_Screen = new Form();
        #endregion

        private void Frm_Play_Load(object sender, EventArgs e)
        {
            //視窗位置的初始化
            Cla_FrmClass.FrmInitialize(this);
        }

        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {

            int Tem_Y = 0;
            if (e.Button == MouseButtons.Left)//按下的是否為鼠標左鍵
            {
                Cla_FrmClass.FrmBackCheck();//檢測各視窗是否連在一起
                Tem_Y = e.Y;
                FrmClass.FrmPoint = new Point(e.X, Tem_Y);//取得鼠標在視窗上的位置，用於磁性視窗
                FrmClass.CPoint = new Point(-e.X, -Tem_Y);//取得鼠標在屏幕上的位置，用於視窗的移動
                if (FrmClass.Example_List_AdhereTo)//如果與frm_ListBox視窗相連接
                {
                    Cla_FrmClass.FrmDistanceJob(this, F_List);//計算視窗的距離差
                    if (FrmClass.Example_Assistant_AdhereTo)//兩個輔視窗是否連接在一起
                    {
                        Cla_FrmClass.FrmDistanceJob(this, F_Libretto);//計算視窗的距離差
                    }
                }
                if (FrmClass.Example_Libretto_AdhereTo)//如果與frm_Libretto視窗相連接
                {
                    Cla_FrmClass.FrmDistanceJob(this, F_Libretto);//計算視窗的距離差
                    if (FrmClass.Example_Assistant_AdhereTo)//兩個輔視窗是否連接在一起
                    {
                        Cla_FrmClass.FrmDistanceJob(this, F_List);//計算視窗的距離差
                    }
                }
            }

        }

        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是否為鼠標左鍵
            {

                Cla_FrmClass.FrmMove(this, e);//利用控制元件移動視窗
                if (FrmClass.Example_List_AdhereTo)//如果frm_ListBox視窗與主視窗連接
                {

                    Cla_FrmClass.ManyFrmMove(this, e, F_List);//磁性視窗的移動
                    Cla_FrmClass.FrmInitialize(F_List);//對frm_ListBox視窗的位置進行初始化
                    if (FrmClass.Example_Assistant_AdhereTo)//如果兩個子視窗連接在一起
                    {
                        Cla_FrmClass.ManyFrmMove(this, e, F_Libretto);
                        Cla_FrmClass.FrmInitialize(F_Libretto);
                    }
                }

                if (FrmClass.Example_Libretto_AdhereTo)//如果frm_Libretto視窗與主視窗連接
                {
                    Cla_FrmClass.ManyFrmMove(this, e, F_Libretto);
                    Cla_FrmClass.FrmInitialize(F_Libretto);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.ManyFrmMove(this, e, F_List);
                        Cla_FrmClass.FrmInitialize(F_List);
                    }
                }
                Cla_FrmClass.FrmInitialize(this);
            }
        }

        private void panel_Title_MouseUp(object sender, MouseEventArgs e)
        {
            Cla_FrmClass.FrmPlace(this);
        }

        private void Frm_Play_Shown(object sender, EventArgs e)
        {
            //顯示列表視窗
            F_List = new Frm_ListBox();
            F_List.ShowInTaskbar = false;
            FrmClass.Example_ListShow = true;
            F_List.Show();
            //顯示歌詞視窗
            F_Libretto = new Frm_Libretto();
            F_Libretto.ShowInTaskbar = false;
            FrmClass.Example_LibrettoShow = true;
            F_Libretto.Show();
            F_Libretto.Left = this.Left + this.Width;
            F_Libretto.Top = this.Top;
            //各視窗位置的初始化
            Cla_FrmClass.FrmInitialize(F_List);
            Cla_FrmClass.FrmInitialize(F_Libretto);
        }

        private void panel_Close_Click(object sender, EventArgs e)
        {
            F_List.Close();
            F_List.Dispose();
            F_Libretto.Close();
            F_Libretto.Dispose();
            F_Screen.Close();
            F_Screen.Dispose();
            this.Close();
        }

        private void panel_Title_Click(object sender, EventArgs e)
        {
            F_List.Focus();
            F_Libretto.Focus();
            this.Focus();

        }

    }
}
