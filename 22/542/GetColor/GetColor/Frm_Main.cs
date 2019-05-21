using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace GetColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定義快捷鍵
        //如果函數執行成功，返回值不為0。       
        //如果函數執行失敗，返回值為0。要得到擴展錯誤訊息，呼叫GetLastError。        
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
        IntPtr hWnd,                //要定義熱鍵的視窗的句柄            
        int id,                     //定義熱鍵ID（不能與其它ID重複）                       
        KeyModifiers fsModifiers,   //標識熱鍵是否在按Alt、Ctrl、Shift、Windows等鍵時才會生效         
        Keys vk                     //定義熱鍵的內容            
    );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消熱鍵的視窗的句柄            
            int id                      //要取消熱鍵的ID            
        );
        //定義了輔助鍵的名稱（將數字轉變為字符以便於記憶，也可去除此枚舉而直接使用數值）        
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        #endregion



        [DllImport("gdi32.dll")]
        static public extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("gdi32.dll")]
        static public extern IntPtr CreateDC(string driverName, string deviceName, string output, IntPtr lpinitData);
        [DllImport("gdi32.dll")]
        static public extern bool DeleteDC(IntPtr DC);
        static public byte GetRValue(uint color)
        {
            return (byte)color;
        }
        static public byte GetGValue(uint color)
        {
            return ((byte)(((short)(color)) >> 8));
        }
        static public byte GetBValue(uint color)
        {
            return ((byte)((color) >> 16));
        }
        static public byte GetAValue(uint color)
        {
            return ((byte)((color) >> 24));
        }
        public Color GetColor(Point screenPoint)
        {
            IntPtr displayDC = CreateDC("DISPLAY", null, null, IntPtr.Zero);
            uint colorref = GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            DeleteDC(displayDC);
            byte Red = GetRValue(colorref);
            byte Green = GetGValue(colorref);
            byte Blue = GetBValue(colorref);
            return Color.FromArgb(Red, Green, Blue);
        }

        private void FrmGetColor_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtPoint.Text = Control.MousePosition.X.ToString() + "," + Control.MousePosition.Y.ToString();
            Point pt = new Point(Control.MousePosition.X, Control.MousePosition.Y);
            Color cl = GetColor(pt);
            panel1.BackColor = cl;
            txtRGB.Text = cl.R + "," + cl.G + "," + cl.B;
            txtColor.Text = ColorTranslator.ToHtml(cl).ToString();
            RegisterHotKey(Handle, 81, KeyModifiers.Ctrl, Keys.F);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mrbccd.com");
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷鍵     
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 81:    //按下的是CTRL+F     
                            Clipboard.SetText(txtColor.Text.Trim());
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void FrmGetColor_Leave(object sender, EventArgs e)
        {

        }

        private void FrmGetColor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //註銷Id號為81的熱鍵設定    
            UnregisterHotKey(Handle, 81);
        }
    }
}
