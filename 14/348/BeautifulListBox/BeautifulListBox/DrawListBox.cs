using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BeautifulListBox
{
    public partial class DrawListBox : ListBox
    {
        public DrawListBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
        }

        #region 變數
        private static Brush[] listBoxBrushes;//該陣列用來存儲繪製listBox1背景的Brush物件
        private static int place = -1;//顏色位置的取值
        private static bool naught = true;//判斷是否重繪
        #endregion

        #region 屬性

        private bool TGradualC = false;
        [Browsable(true), Category("控制元件的重繪設定"), Description("判斷是否進行漸變色的設定")] //在「屬性」視窗中顯示DataStyle屬性
        public bool GradualC
        {
            get { return TGradualC; }
            set
            {
                TGradualC = value;
                this.Invalidate();
            }
        }

        private Color TColorSelect = Color.Gainsboro;
        [Browsable(true), Category("控制元件的重繪設定"), Description("項被選中後的高亮度顏色")] //在「屬性」視窗中顯示DataStyle屬性
        public Color ColorSelect
        {
            get { return TColorSelect; }
            set
            {
                TColorSelect = value;
                this.Invalidate();
            }
        }

        private Color TColor1 = Color.CornflowerBlue;
        [Browsable(true), Category("控制元件的重繪設定"), Description("第一個顏色的設定")] //在「屬性」視窗中顯示DataStyle屬性
        public Color Color1
        {
            get { return TColor1; }
            set
            {
                TColor1 = value;
                this.Invalidate();
            }
        }

        private Color TColor1Gradual = Color.Thistle;
        [Browsable(true), Category("控制元件的重繪設定"), Description("第一個顏色的漸變色設定")] //在「屬性」視窗中顯示DataStyle屬性
        public Color Color1Gradual
        {
            get { return TColor1Gradual; }
            set
            {
                TColor1Gradual = value;
                this.Invalidate();
            }
        }

        private Color TColor2 = Color.PaleGreen;
        [Browsable(true), Category("控制元件的重繪設定"), Description("第二個顏色的設定")] //在「屬性」視窗中顯示DataStyle屬性
        public Color Color2
        {
            get { return TColor2; }
            set
            {
                TColor2 = value;
                this.Invalidate();
            }
        }

        private Color TColor2Gradual = Color.DarkKhaki;
        [Browsable(true), Category("控制元件的重繪設定"), Description("第二個顏色的漸變色設定")] //在「屬性」視窗中顯示DataStyle屬性
        public Color Color2Gradual
        {
            get { return TColor2Gradual; }
            set
            {
                TColor2Gradual = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 鼠標移出控制元件的可見區域時觸發
        /// </summary>
        protected virtual void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);//設定重繪的區域
            SolidBrush SolidB1 = new SolidBrush(this.Color1);//設定上一行顏色
            SolidBrush SolidB2 = new SolidBrush(this.Color2);//設定下一行顏色
            //設定上一行的漸變色
            LinearGradientBrush LinearG1 = new LinearGradientBrush(r, this.Color1, this.Color1Gradual, LinearGradientMode.BackwardDiagonal);
            //設定下一行的漸變色
            LinearGradientBrush LinearG2 = new LinearGradientBrush(r, this.Color2, this.Color2Gradual, LinearGradientMode.BackwardDiagonal);
            //將單色與漸變色存入Brush陣列中
            listBoxBrushes = new Brush[] { SolidB1, LinearG1, SolidB2, LinearG2 };
            e.DrawBackground();
            if (this.Items.Count <= 0)//如果目前控制元件為空
                return;
            if (e.Index == (this.Items.Count - 1))//如果繪製的是最後一個項
            {
                bool tem_bool = true;
                if (e.Index == 0 && tem_bool)//如果目前繪製的是第一個或最後一個項
                    naught = false;//不進行重繪
            }
            if (naught)//對控制元件進行重繪
            {
                //取得目前繪製的顏色值
                Brush brush = listBoxBrushes[place = (GradualC) ? (((e.Index % 2) == 0) ? 1 : 3) : (((e.Index % 2) == 0) ? 0 : 2)];
                e.Graphics.FillRectangle(brush, e.Bounds);//用指定的畫刷填充列表項範圍所形成的矩形
                bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? true : false;//判斷目前項是否被選取中
                if (selected)//如果目前項被選中
                {
                    e.Graphics.FillRectangle(new SolidBrush(ColorSelect), e.Bounds);//繪製目前項
                }
                e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, Brushes.Black, e.Bounds);//繪製目前項中的文字
            }
            e.DrawFocusRectangle();//繪製聚焦框
        }

        #endregion
    }
}
