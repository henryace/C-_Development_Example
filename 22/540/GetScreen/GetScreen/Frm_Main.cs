﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
namespace GetScreen
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int _X, _Y;
        [StructLayout(LayoutKind.Sequential)]
        private struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public Point ptScreenPos;
        }
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        [DllImport("user32.dll", EntryPoint = "GetCursorInfo")]
        private static extern bool GetCursorInfo(ref CURSORINFO cInfo);
        [DllImport("user32.dll", EntryPoint = "CopyIcon")]
        private static extern IntPtr CopyIcon(IntPtr hIcon);
        [DllImport("user32.dll", EntryPoint = "GetIconInfo")]
        private static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO iInfo);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

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

        public string path;
        public void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        public string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }

        private Bitmap CaptureNoCursor()//抓取沒有鼠標的桌面
        {
            Bitmap _Source = new Bitmap(GetSystemMetrics(0), GetSystemMetrics(1));
            using (Graphics g = Graphics.FromImage(_Source))
            {
                g.CopyFromScreen(0, 0, 0, 0, _Source.Size);
                g.Dispose();
            }
            return _Source;
        }


        private Bitmap CaptureDesktop()//抓取帶鼠標的桌面
        {
            try
            {
                int _CX = 0, _CY = 0;
                Bitmap _Source = new Bitmap(GetSystemMetrics(0), GetSystemMetrics(1));
                using (Graphics g = Graphics.FromImage(_Source))
                {

                    g.CopyFromScreen(0, 0, 0, 0, _Source.Size);
                    g.DrawImage(CaptureCursor(ref _CX, ref _CY), _CX, _CY);
                    g.Dispose();
                }
                _X = (800 - _Source.Width) / 2;
                _Y = (600 - _Source.Height) / 2;
                return _Source;
            }
            catch
            {
                return null;
            }
        }

        private Bitmap CaptureCursor(ref int _CX, ref int _CY)
        {
            IntPtr _Icon;
            CURSORINFO _CursorInfo = new CURSORINFO();
            ICONINFO _IconInfo;
            _CursorInfo.cbSize = Marshal.SizeOf(_CursorInfo);
            if (GetCursorInfo(ref _CursorInfo))
            {
                if (_CursorInfo.flags == 0x00000001)
                {
                    _Icon = CopyIcon(_CursorInfo.hCursor);

                    if (GetIconInfo(_Icon, out _IconInfo))
                    {
                        _CX = _CursorInfo.ptScreenPos.X - _IconInfo.xHotspot;
                        _CY = _CursorInfo.ptScreenPos.Y - _IconInfo.yHotspot;
                        return Icon.FromHandle(_Icon).ToBitmap();
                    }
                }
            }
            return null;
        }

        string Cursor;
        string PicPath;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                path = Application.StartupPath.ToString();
                path = path.Substring(0, path.LastIndexOf("\\"));
                path = path.Substring(0, path.LastIndexOf("\\"));
                path += @"\Setup.ini";
                if (checkBox1.Checked == true)
                {
                    Cursor = "1";
                }
                else
                {
                    Cursor = "0";
                }
                if (txtSavaPath.Text == "")
                {
                    PicPath = @"D:\";
                }
                else
                {
                    PicPath = txtSavaPath.Text.Trim();
                }
                IniWriteValue("Setup", "CapMouse", Cursor);
                IniWriteValue("Setup", "Dir", PicPath);
                MessageBox.Show("儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSavaPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_StyleChanged(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, 81, KeyModifiers.Shift, Keys.F);
        }
        public bool flag = true;
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //註銷Id號為81的熱鍵設定    
            UnregisterHotKey(Handle, 81);
            timer1.Stop();
            flag = false;
            Application.Exit();
        }

        string MyCursor;
        string MyPicPath;
        private void Form1_Activated(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, 81, KeyModifiers.Shift, Keys.F);
            path = Application.StartupPath.ToString();
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path += @"\Setup.ini";
            MyCursor = IniReadValue("Setup", "CapMouse");
            MyPicPath = IniReadValue("Setup", "Dir");
            if (MyCursor == "" || MyPicPath == "")
            {
                checkBox1.Checked = true;
                txtSavaPath.Text = @"D:\";
            }
            else
            {
                if (MyCursor == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                txtSavaPath.Text = MyPicPath;
            }
        }

        private void getImg()
        {
            DirectoryInfo di = new DirectoryInfo(MyPicPath);
            if (!di.Exists)
            {
                Directory.CreateDirectory(MyPicPath);
            }
            if (MyPicPath.Length == 3)
                MyPicPath = MyPicPath.Remove(MyPicPath.LastIndexOf(":") + 1);
            string PicPath = MyPicPath + "\\IMG_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".bmp";
            Bitmap bt;
            if (MyCursor == "0")
            {
                bt = CaptureNoCursor();
                bt.Save(PicPath);
            }
            else
            {
                bt = CaptureDesktop();
                bt.Save(PicPath);
            }
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
                        case 81:    //按下的是Shift+Q                   
                            getImg();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)//雙擊顯示設定視窗
        {
            this.Show();
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)//單擊設定打開設定視窗
        {
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, 81, KeyModifiers.Shift, Keys.F);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            if (flag == true)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
