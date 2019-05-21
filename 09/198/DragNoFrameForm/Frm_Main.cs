using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DragNoFrameForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 本程式中用到的API函數
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();//用來釋放被目前線程中某個視窗擷取的光標
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn, int wMsg, int mParam, int lParam);//向指定的視窗發送Windows消息
        #endregion

        #region 本程式中需要宣告的變數
        public const int WM_SYSCOMMAND = 0x0112;//該變數表示將向Windows發送的消息類型
        public const int SC_MOVE = 0xF010;//該變數表示發送消息的附加消息
        public const int HTCAPTION = 0x0002;//該變數表示發送消息的附加消息
        #endregion

        private void ExitContext_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出本程式
        }

        private void Frm_Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();//用來釋放被目前線程中某個視窗擷取的光標
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//向Windows發送拖動視窗的消息
        }
    }
}
