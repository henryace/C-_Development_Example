using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulRichTextBox
{
    public partial class GuageRichTextBox : UserControl
    {
        public GuageRichTextBox()
        {
            InitializeComponent();
            richTextBox1.WordWrap = false;
            richTextBox1.Top = Distance_X;
            richTextBox1.Left = Distance_Y;
            richTextBox1.Width = this.Width - Distance_X - 2;
            richTextBox1.Height = this.Height - Distance_Y - 2;
        }



        #region 變數及常量
        const int Distance_X = 30;//設定RichTextBox控制元件的X位置
        const int Distance_Y = 30;//設定RichTextBox控制元件的Y位置
        const int SpaceBetween = 3;//設定標尺的間距
        public static float thisleft = 0;//設定控制元件的左邊距
        public static float StartBitH = 0;//記錄橫向滾動條的位置
        public static float StartBitV = 0;//記錄縱向滾動條的位置
        const int Scale1 = 3;//設定刻度最短的線長
        const int Scale5 = 6;//設定刻度為5時的線長
        const int Scale10 = 9;//設定刻度為10是垢線長
        public static float Degree = 0;//度數
        public static float CodeSize = 1;//程式碼編號的寬度
        #endregion

        #region 屬性

        [Browsable(true), Category("設定標尺控制元件"), Description("設定RichTextBox控制元件的相關屬性")] //在「屬性」視窗中顯示DataStyle屬性
        public RichTextBox NRichTextBox
        {
            get { return richTextBox1; }
        }

        public enum Ruler
        {
            Graduation = 0,//刻度
            Rule = 1,//尺子
        }

        private bool TCodeShow = false;
        [Browsable(true), Category("設定標尺控制元件"), Description("是否在RichTextBox控制元件的前面新增程式碼的行號")] //在「屬性」視窗中顯示DataStyle屬性
        public bool CodeShow
        {
            get { return TCodeShow; }
            set
            {
                TCodeShow = value;
                this.Invalidate();
            }
        }

        private Ruler TRulerStyle = Ruler.Graduation;
        [Browsable(true), Category("設定標尺控制元件"), Description("設定標尺樣式：\nGraduation為刻度\nRule為尺子")] //在「屬性」視窗中顯示DataStyle屬性
        public Ruler RulerStyle
        {
            get { return TRulerStyle; }
            set
            {
                TRulerStyle = value;
                this.Invalidate();
            }
        }

        public enum Unit
        {
            Cm = 0,//厘米
            Pels = 1,//像素
        }

        private Unit TUnitStyle = Unit.Cm;
        [Browsable(true), Category("設定標尺控制元件"), Description("設定標尺的單位：\nCm為厘米\nPels為像素")] //在「屬性」視窗中顯示DataStyle屬性
        public Unit UnitStyle
        {
            get { return TUnitStyle; }
            set
            {
                TUnitStyle = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 事件
        private void GuageRichTextBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), 0, 0, this.Width - 1, this.Height - 1);//繪製外邊框
            if (CodeShow)//如查在文字框左邊新增行號
            {
                //取得行號的寬度
                float tem_code = (float)StringSize((Convert.ToInt32(CodeSize + (float)(richTextBox1.Height / (StringSize(CodeSize.ToString(), richTextBox1.Font, false))))).ToString(), this.Font, true);
                richTextBox1.Top = Distance_X;//設定控制元件的頂端距離
                richTextBox1.Left = Distance_Y + (int)Math.Ceiling(tem_code);//設定控制元件的左端距離
                richTextBox1.Width = this.Width - Distance_X - 2 - (int)Math.Ceiling(tem_code);//設定控制元件的寬度
                richTextBox1.Height = this.Height - Distance_Y - 2;//設定控制元件高度
                thisleft = Distance_Y + tem_code;//設定標尺的左端位置
            }
            else
            {
                richTextBox1.Top = Distance_X;//設定控制元件的頂端距離
                richTextBox1.Left = Distance_Y;//設定控制元件的左端距離
                richTextBox1.Width = this.Width - Distance_X - 2;//設定控制元件的寬度
                richTextBox1.Height = this.Height - Distance_Y - 2;//設定控制元件高度
                thisleft = Distance_Y;//設定標尺的左端位置
            }
            //繪製文字框的邊框
            e.Graphics.DrawRectangle(new Pen(Color.LightSteelBlue), richTextBox1.Location.X - 1, thisleft - 1, richTextBox1.Width + 1, richTextBox1.Height + 1);
            e.Graphics.FillRectangle(new SolidBrush(Color.Silver), 1, 1, this.Width - 2, Distance_Y - 2);//文字框的上邊框
            e.Graphics.FillRectangle(new SolidBrush(Color.Silver), 1, 1, Distance_X - 2, this.Height - 2);//文字框的左邊框
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 3, 3, Distance_X - 7, Distance_Y - 8);//繪製左上角的方塊邊框
            e.Graphics.DrawRectangle(new Pen(SystemColors.Control), 3, 3, Distance_X - 8, Distance_Y - 8);//繪製左上角的方塊
            if (RulerStyle == Ruler.Rule)//標尺
            {
                //繪製上邊的標尺背景
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), thisleft - 3, 3, this.Width - (thisleft - 2), Distance_Y - 9);//繪製左上角的方塊邊框
                e.Graphics.DrawLine(new Pen(SystemColors.Control), thisleft - 3, 3, this.Width - 2, 3);//繪製方塊的上邊線
                e.Graphics.DrawLine(new Pen(SystemColors.Control), thisleft - 3, Distance_Y - 5, this.Width - 2, Distance_Y - 5);//繪製方塊的下邊線
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), thisleft - 2, 9, this.Width - (thisleft - 2) - 1, Distance_Y - 19);//繪製方塊的中間塊
                //繪製左邊的標尺背景
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 3, Distance_Y - 3, Distance_X - 7, this.Height - (Distance_Y - 3) - 2);//繪製左邊的方塊
                e.Graphics.DrawLine(new Pen(SystemColors.Control), 3, Distance_Y - 3, 3, this.Height - 2);//繪製方塊的左邊線
                e.Graphics.DrawLine(new Pen(SystemColors.Control), Distance_X - 5, Distance_Y - 3, Distance_X - 5, this.Height - 2);//繪製方塊的右邊線
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), 9, Distance_Y - 3, Distance_X - 19, this.Height - (Distance_Y - 3) - 2);//繪製方塊的中間塊
            }
            int tem_temHeight = 0;
            string tem_value = "";
            int tem_n = 0;
            int divide = 5;
            Pen tem_p = new Pen(new SolidBrush(Color.Black));
            //橫向刻度的設定
            if (UnitStyle == Unit.Cm)//如果刻度的單位是厘米
                Degree = e.Graphics.DpiX / 25.4F;//將像素轉換成毫米
            if (UnitStyle == Unit.Pels)//如果刻度的單位是像素
                Degree = 10;//設定10像素為一個刻度
            int tem_width = this.Width - 3;
            tem_n = (int)StartBitH;//記錄橫向滾動條的位置
            if (tem_n != StartBitH)//如果橫向滾動條的位置值為小數
                StartBitH = (int)StartBitH;//對橫向滾動條的位置進行取整
            for (float i = 0; i < tem_width; )//在文字框的項端繪製標尺
            {
                tem_temHeight = Scale1;//設定刻度線的最小長度
                float j = (i + (int)StartBitH) / Degree;//取得刻度值
                tem_value = "";
                j = (int)j;//對刻度值進行取整
                if (j % (divide * 2) == 0)//如果刻度值是10進位
                {
                    tem_temHeight = Scale10;//設定最長的刻度線
                    if (UnitStyle == Unit.Cm)//如果刻度的單位為厘米
                        tem_value = Convert.ToString(j / 10);//記錄刻度值
                    if (UnitStyle == Unit.Pels)//如果刻度的單位為像素
                        tem_value = Convert.ToString((int)j * 10);//記錄刻度值
                }
                else if (j % divide == 0)//如果刻度值的進位為5
                {
                    tem_temHeight = Scale5;//設定刻度線為中等
                }
                tem_p.Width = 1;
                if (RulerStyle == Ruler.Graduation)//如果是以刻度值進行測量
                {
                    //繪製刻度線
                    e.Graphics.DrawLine(tem_p, i + 1 + thisleft, SpaceBetween, i + 1 + thisleft, SpaceBetween + tem_temHeight);
                    if (tem_value.Length > 0)//如果有刻度值
                        //繪製刻度值
                        ProtractString(e.Graphics, tem_value.Trim(), i + 1 + thisleft, SpaceBetween, i + 1 + thisleft, SpaceBetween + tem_temHeight, 0);
                }
                if (RulerStyle == Ruler.Rule)//如果是以標尺進行測量
                {
                    if (tem_value.Length > 0)//如果有刻度值
                    {
                        e.Graphics.DrawLine(tem_p, i + 1 + thisleft, 4, i + 1 + thisleft, 7);//繪製頂端的刻度線
                        e.Graphics.DrawLine(tem_p, i + 1 + thisleft, Distance_Y - 9, i + 1 + thisleft, Distance_Y - 7);//繪製底端的刻度線
                        float tem_space = 3 + (Distance_X - 19F - 9F - StringSize(tem_value.Trim(), this.Font, false)) / 2F;//設定文字的橫向位置
                        //繪製文字
                        ProtractString(e.Graphics, tem_value.Trim(), i + 1 + thisleft, (float)Math.Ceiling(tem_space), i + 1 + thisleft, (float)Math.Ceiling(tem_space) + tem_temHeight, 0);
                    }
                }
                i += Degree;//累加刻度的寬度
            }
            //縱向刻度的設定
            if (UnitStyle == Unit.Cm)//如果刻度的單位是厘米
                Degree = e.Graphics.DpiX / 25.4F;//將像素轉換成毫米
            if (UnitStyle == Unit.Pels)//如果刻度的單位是像素
                Degree = 10;//刻度值設為10像素
            int tem_height = this.Height - 3;
            tem_n = (int)StartBitV;//記錄縱向滾動條的位置
            if (tem_n != StartBitV)//如果縱向滾動條的位置為小數
                StartBitV = (int)StartBitV;//對其進行取整
            for (float i = 0; i < tem_height; )//在文字框的左端繪製標尺
            {
                tem_temHeight = Scale1;//設定刻度線的最小值
                float j = (i + (int)StartBitV) / Degree;//取得目前的刻度值
                tem_value = "";
                j = (int)j;//對刻度值進行取整
                if (j % 10 == 0)//如果刻度值是10進位
                {
                    tem_temHeight = Scale10;//設定刻度線的長度為最長
                    if (UnitStyle == Unit.Cm)//如果刻度的單位是厘米
                        tem_value = Convert.ToString(j / 10);//取得厘米的刻度值
                    if (UnitStyle == Unit.Pels)//如果刻度的單位是像素
                        tem_value = Convert.ToString((int)j * 10);//取得像素的刻度值
                }
                else if (j % 5 == 0)//如果刻度值是5進位
                {
                    tem_temHeight = Scale5;//設定刻度線的長度為中等
                }
                tem_p.Width = 1;
                if (RulerStyle == Ruler.Graduation)//如果是以刻度值進行測量
                {
                    //繪製刻度線
                    e.Graphics.DrawLine(tem_p, SpaceBetween, i + 1 + Distance_Y, SpaceBetween + tem_temHeight, i + 1 + Distance_Y);
                    if (tem_value.Length > 0)//如果有刻度值
                        //繪製刻度值
                        ProtractString(e.Graphics, tem_value.Trim(), SpaceBetween, i + 1 + Distance_Y, SpaceBetween + tem_temHeight, i + 1 + Distance_Y, 1);
                }
                if (RulerStyle == Ruler.Rule)//如果是以標尺進行測量
                {
                    if (tem_value.Length > 0)//如果有刻度值
                    {
                        e.Graphics.DrawLine(tem_p, 4, i + 1 + Distance_Y, 7, i + 1 + Distance_Y);//繪製左端刻度線
                        e.Graphics.DrawLine(tem_p, Distance_Y - 9, i + 1 + Distance_Y, Distance_Y - 7, i + 1 + Distance_Y);//繪製右端刻度線
                        float tem_space = 3 + (Distance_X - 19F - 9F - StringSize(tem_value.Trim(), this.Font, false)) / 2F;//設定文字的縱向位置
                        //繪製文字
                        ProtractString(e.Graphics, tem_value.Trim(), (float)Math.Floor(tem_space), i + 1 + Distance_Y, (float)Math.Floor(tem_space) + tem_temHeight, i + 1 + Distance_Y, 1);
                    }
                }
                i += Degree;//累加刻度值
            }
            if (CodeShow)//如果顯示行號
            {
                //設定文字的高度
                float tem_FontHeight = (float)(richTextBox1.Height / (StringSize(CodeSize.ToString(), richTextBox1.Font, false)));
                float tem_tep = richTextBox1.Top;//取得文字框的頂端位置
                int tem_mark = 0;
                for (int i = 0; i < (int)tem_FontHeight; i++)//繪製行號
                {
                    tem_mark = i + (int)CodeSize;//設定程式碼編號的寬度
                    //繪製行號
                    e.Graphics.DrawString(tem_mark.ToString(), this.Font, new SolidBrush(Color.Red), new PointF(richTextBox1.Left - StringSize(tem_mark.ToString(), this.Font, true) - 2, tem_tep));
                    tem_tep = tem_tep + StringSize("懂", richTextBox1.Font, false);//設定下一個行號的X坐標值
                }
            }

        }

        private void GuageRichTextBox_Resize(object sender, EventArgs e)
        {
            richTextBox1.Top = Distance_X;//設定控制元件的頂端位置
            richTextBox1.Left = Distance_Y;//設定控制元件的左端位置
            richTextBox1.Width = this.Width - Distance_X - 2;//設定控制元件的寬度
            richTextBox1.Height = this.Height - Distance_Y - 2;//設定控制元件的高度
            this.Invalidate();
        }

        private void richTextBox1_HScroll(object sender, EventArgs e)
        {
            StartBitH = (int)(Math.Abs((float)richTextBox1.GetPositionFromCharIndex(0).X - 1));//檢索控制元件橫向內指定字符索引處的位置
            this.Invalidate();
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            StartBitV = (int)(Math.Abs((float)richTextBox1.GetPositionFromCharIndex(0).Y - 1));//檢索控制元件縱向內指定字符索引處的位置
            if (CodeShow)//如果顯示行號
                CodeSize = (int)Math.Abs((richTextBox1.GetPositionFromCharIndex(0).Y / StringSize("懂", richTextBox1.Font, false)));//設定行號的高度
            this.Invalidate();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 在指定的位置繪製文字訊息
        /// </summary>
        /// <param e="Graphics">封裝一個繪圖的類物件</param>
        /// <param str="string">文字訊息</param> 
        /// <param x1="float">左上角x坐標</param> 
        /// <param y1="float">左上角y坐標</param> 
        /// <param x2="float">右下角x坐標</param> 
        /// <param y2="float">右下角y坐標</param> 
        /// <param n="float">標識,判斷是在橫向標尺上繪製文字還是在縱向標尺上繪製文字</param> 
        public void ProtractString(Graphics e, string str, float x1, float y1, float x2, float y2, float n)
        {
            float TitWidth = StringSize(str, this.Font, true);//取得字串的寬度
            if (n == 0)//在橫向標尺上繪製文字
                e.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(x2 - TitWidth / 2, y2 + 1));
            else//在縱向標尺上繪製文字
            {
                StringFormat drawFormat = new StringFormat();//實例化StringFormat類
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;//設定文字為垂直對齊
                //繪製指定的文字
                e.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(x2 + 1, y2 - TitWidth / 2), drawFormat);
            }
        }

        /// <summary>
        /// 取得文字的高度或寬度
        /// </summary>
        /// <param str="string">文字訊息</param>
        /// <param font="Font">字體樣式</param> 
        /// <param n="bool">標識,判斷返回的是高度還是寬度</param> 
        public float StringSize(string str, Font font, bool n)//n==true為width
        {
            Graphics TitG = this.CreateGraphics();//建立Graphics類物件
            SizeF TitSize = TitG.MeasureString(str, font);//將繪製的字串進行格式化
            float TitWidth = TitSize.Width;//取得字串的寬度
            float TitHeight = TitSize.Height;//取得字串的高度
            if (n)
                return TitWidth;//返回文字訊息的寬度
            else
                return TitHeight;//返回文字訊息的高度
        }
        #endregion
    }
}
