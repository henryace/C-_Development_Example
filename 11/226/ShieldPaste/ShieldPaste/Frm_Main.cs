using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShieldPaste
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private void Frm_Main_Load(object sender, EventArgs e)
        {
            TextBoxx tb = new TextBoxx();//建立文字框物件
            tb.Width = Width;//設定文字框寬度
            tb.Height = Height;//設定文字框高度
            tb.Location = new Point(0, 0);//設定文字框起始位置
            tb.Multiline = true;//設定文字框為多行
            Controls.Add(tb);//將文字框新增到控制元件集合
        }
    }
    class TextBoxx : TextBox
    {
        public const int WM_PASTE = 0x0302;//貼上消息訊息
        protected override void WndProc(ref Message m)//重寫處理消息方法
        {
            if (m.Msg != WM_PASTE)//遮蔽貼上消息訊息
            {
                base.WndProc(ref m);//呼叫基底類別消息處理方法
            }
        }
    }
}
