using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;//該命名空間提供各種各樣支持 COM interop 及平台呼叫服務的成員

namespace DisplayNumber
{
    class RichTextBoxEx : RichTextBox
    {
        #region
        public RichTextBoxEx()
        {
            this.Top = 13;//設定自定義控制元件與其容器工作區上邊緣之間的距離
            this.Left = 5;//設定自定義控制元件與其容器工作區左邊緣之間的距離
            this.Height = 186;//設定自定義控制元件的高度
            this.Width = 371;//設定自定義控制元件的寬度
        }

        [StructLayout(LayoutKind.Sequential)]
        private class PARAFORMAT2
        {
            public int cbSize;//用來儲存該類型的大小
            public int dwMask;  //標識操作文字的方式
            public short wNumbering; //標識項目編號
            public int dxStartIndent;//標識文字的起始縮進量
            public int dxRightIndent;//標識文字的右縮進
            public int dxOffset; //標識項目編號的偏移量
            public short wAlignment;//標識文字的對齊方式
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
            public int[] rgxTabs;//定義一個整型陣列

            public int dySpaceBefore;//用來表示編號前的縱向間隔
            public int dySpaceAfter;//用來表示編號後的縱向間隔
            public int dyLineSpacing;//按指定的規則編號後的行間隔
            public short sStyle;//樣式句柄
            public byte bLineSpacingRule;//行間隔的規則
            public short wShadingWeight;//設定偏移量
            public short wShadingStyle;//設定偏移後的樣式
            public short wNumberingStart;//設定項目編號的其實質
            public short wNumberingStyle;//設定項目編號的樣式
            public short wNumberingTab;//設定按Tab鍵的偏移量
            public short wBorderSpace;//設定邊框佔據的空間
            public short wBorderWidth;//設定邊框佔據的寬度

            public PARAFORMAT2()
            {
                this.cbSize = Marshal.SizeOf(typeof(PARAFORMAT2));//
            }
        }

        #region PARAFORMAT MASK VALUES
        private const uint PFM_OFFSET = 0x00000004;//設定項目符號的偏移量
        private const uint PFM_NUMBERING = 0x00000020;//設定編號方式

        private const uint PFM_NUMBERINGSTYLE = 0x00002000;//設定項目編號的樣式
        private const uint PFM_NUMBERINGTAB = 0x00004000;//設定項目編號按下Tab鍵的訊息
        private const uint PFM_NUMBERINGSTART = 0x00008000;//設定項目編號的開始標識

        public enum AdvRichTextBulletType
        {
            Normal = 1,//設定項目符號的標識為1
            Number = 2, //設定項目編號的標識為2
            LowerCaseLetter = 3,//設定小寫英文編號的標識為3
            UpperCaseLetter = 4,//設定大寫英文編號的表示為4
            LowerCaseRoman = 5,//設定小寫羅馬數字的標識為5
            UpperCaseRoman = 6 //設定大寫羅馬數字的標識為6
        }

        public enum AdvRichTextBulletStyle
        {
            RightParenthesis = 0x000,//在文字的右邊加圓括號
            DoubleParenthesis = 0x100,//在文字的右邊加雙括號
            Period = 0x200,//在文字的旁邊加點
            Plain = 0x300,//設定文字為無格式
            NoNumber = 0x400//設定樣式為無數字
        }
        #endregion

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam,
           [In, Out, MarshalAs(UnmanagedType.LPStruct)] PARAFORMAT2 lParam);//定義一個向視窗進程發送消息的API函數

        private AdvRichTextBulletType _BulletType = AdvRichTextBulletType.Number;//設定項目編號的起始類型
        private AdvRichTextBulletStyle _BulletStyle = AdvRichTextBulletStyle.Period;//設定項目編號的起始樣式
        private short _BulletNumberStart = 1;//設定項目編號的起始數字為1


        public AdvRichTextBulletType BulletType
        {
            get { return _BulletType; }//返回項目符號的類型
            set
            {
                _BulletType = value;//為項目符號的類型賦值
                NumberedBullet(true);//設定新實例的各個屬性
            }
        }
        public AdvRichTextBulletStyle BulletStyle
        {
            get { return _BulletStyle; }//返回項目符號的樣式
            set
            {
                _BulletStyle = value;//為項目符號樣式設定值
                NumberedBullet(true);//設定新實例的各個屬性
            }
        }
        public void NumberedBullet(bool TurnOn)
        {
            PARAFORMAT2 paraformat1 = new PARAFORMAT2();//初始化類PARAFORMAT2的一個新實例
            paraformat1.dwMask = (int)(PFM_NUMBERING | PFM_OFFSET | PFM_NUMBERINGSTART |
                PFM_NUMBERINGSTYLE | PFM_NUMBERINGTAB);//設定實例的dwMask屬性
            if (!TurnOn)//當和TurnOn的預設值相反時
            {
                paraformat1.wNumbering = 0;//設定wNumbering屬性為0
                paraformat1.dxOffset = 0;//設定dxOffset屬性為0
            }
            else//當和TurnOn的預設值相同時
            {
                paraformat1.wNumbering = (short)_BulletType;//設定wNumbering的值
                paraformat1.dxOffset = this.BulletIndent;//設定dxOffset的值
                paraformat1.wNumberingStyle = (short)_BulletStyle;//設定項目編號的樣式
                paraformat1.wNumberingStart = _BulletNumberStart;//設定項目編號的起始位置
                paraformat1.wNumberingTab = 500;//設定按Tab鍵文字移動的距離
            }
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, this.Handle),
                0x447, 0, paraformat1);//發送指定的消息
        }
        #endregion
    }
}
