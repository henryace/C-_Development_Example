﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BeautifulRadioButton
{
    public partial class GlorifyRadioButton : RadioButton
    {
        public GlorifyRadioButton()
        {
            InitializeComponent();
            FontAspect = getAspect();//取得目前控制元件文字的讀取方向
        }

        #region 變數
        private bool FontAspect = false;//判斷字體的方向
        private int Measurement = 255;//設定漸變的預設值
        LinearGradientBrush Periphery_br;//外圓的顏色
        LinearGradientBrush Central_br;//移入控制元件時中圓的顏色
        LinearGradientBrush NoCentral_br;//無操作時中圓的顏色
        LinearGradientBrush Stipple_br;//內圓選中的顏色
        LinearGradientBrush NoStipple_br;//內圓無選中的顏色
        #endregion

        #region 新增屬性
        public enum StyleSort
        {
            Null = 0,//無
            Integer = 1,//整數
            Decimal = 2,//小數
        }

        private Color TPeripheryColor = Color.DarkBlue;
        [Browsable(true), Category("設定填充顏色"), Description("外圓的顏色")] //在「屬性」視窗中顯示DataStyle屬性
        public Color PeripheryColor
        {
            get { return TPeripheryColor; }
            set
            {
                TPeripheryColor = value;
                this.Invalidate();
            }
        }

        private Color TCentralColor = Color.CornflowerBlue;
        [Browsable(true), Category("設定填充顏色"), Description("移入控制元件時中圓的顏色")] //在「屬性」視窗中顯示DataStyle屬性
        public Color CentralColor
        {
            get { return TCentralColor; }
            set
            {
                TCentralColor = value;
                this.Invalidate();
            }
        }

        private Color TNoCentralColor = Color.PowderBlue;
        [Browsable(true), Category("設定填充顏色"), Description("無操作時中圓的顏色")] //在「屬性」視窗中顯示DataStyle屬性
        public Color NoCentralColor
        {
            get { return TNoCentralColor; }
            set
            {
                TNoCentralColor = value;
                this.Invalidate();
            }
        }

        private Color TStippleColor = Color.DarkBlue;
        [Browsable(true), Category("設定填充顏色"), Description("選中後內圓的顏色")] //在「屬性」視窗中顯示DataStyle屬性
        public Color StippleColor
        {
            get { return TStippleColor; }
            set
            {
                TStippleColor = value;
                this.Invalidate();
            }
        }

        private Color TNoStippleColor = Color.Azure;
        [Browsable(true), Category("設定填充顏色"), Description("無操作時內圓的顏色")] //在「屬性」視窗中顯示DataStyle屬性
        public Color NoStippleColor
        {
            get { return TNoStippleColor; }
            set
            {
                TNoStippleColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 控制元件在需要重繪時觸發
        /// </summary>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.Control, e.ClipRectangle);//填充矩形
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//清除鋸齒
            //取得左面圖標的區域
            Rectangle boxrect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, SystemInformation.SmallIconSize.Width, e.ClipRectangle.Height);
            //取得繪製的文字的區域
            Rectangle strrect = new Rectangle(e.ClipRectangle.X + SystemInformation.SmallIconSize.Width, e.ClipRectangle.Y, e.ClipRectangle.Width + 2 - SystemInformation.SmallIconSize.Width, e.ClipRectangle.Height);
            if (FontAspect)//判斷字體的讀取方式
            {
                boxrect.X = e.ClipRectangle.X + e.ClipRectangle.Width - SystemInformation.SmallIconSize.Width;//設定橢圓的位置
                strrect.X = e.ClipRectangle.X;//設定字體位置
            }
            Point MousePos = this.PointToClient(Control.MousePosition);//取得鼠標的位置
            bool Above = e.ClipRectangle.Contains(MousePos);//取得鼠標是否在目前控制元件上

            DrawBox(e.Graphics, boxrect, Above);//繪製單選圖案
            DrawText(e.Graphics, strrect);//繪製文字
            if (!Enabled)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(127, SystemColors.Control)), e.ClipRectangle);
        }

        /// <summary>
        /// 鼠標移入控制元件的可見區域時觸發
        /// </summary>
        protected override void OnMouseEnter(System.EventArgs e)
        {
            //base.OnMouseEnter(e);
            this.Invalidate();
        }

        /// <summary>
        /// 鼠標移出控制元件的可見區域時觸發
        /// </summary>
        protected override void OnMouseLeave(System.EventArgs e)
        {
            //base.OnMouseLeave(e);
            this.Invalidate();
        }

        /// <summary>
        /// RightToLeft屬性值更改時發生
        /// </summary>
        protected override void OnRightToLeftChanged(System.EventArgs e)
        {
            //base.OnRightToLeftChanged(e);
            FontAspect = getAspect();//取得文字的讀取方向
            this.Invalidate();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 繪製單選控制元件的圖案
        /// </summary>
        /// <param g="Graphics">封裝一個繪圖的類物件</param>
        /// <param rect="Rectangle">單選圖案的繪製區域</param> 
        /// <param Above="bool">斷判鼠標是否在控制元件上方</param> 
        private void DrawBox(Graphics g, Rectangle rect, bool Above)
        {
            //設定外橢圓的漸變色
            int opacity = Measurement;
            Periphery_br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 2, PeripheryColor), Color.FromArgb(opacity, PeripheryColor), LinearGradientMode.ForwardDiagonal);
            //設定中間橢圓形選中時的漸變色
            opacity = (int)(.4f * opacity + .5f);
            Central_br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 10, CentralColor), Color.FromArgb(opacity, CentralColor), LinearGradientMode.ForwardDiagonal);
            //設定中間橢圓形無操作時的漸變色
            opacity = (int)(.4f * opacity + .5f);
            NoCentral_br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 10, NoCentralColor), Color.FromArgb(opacity, NoCentralColor), LinearGradientMode.ForwardDiagonal);
            //設定內圓形選中時的漸變色
            opacity = Measurement;
            Stipple_br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 5, StippleColor), Color.FromArgb(opacity, StippleColor), LinearGradientMode.BackwardDiagonal);
            //設定內圓形無操作時的漸變色
            opacity = (int)(.4f * opacity + .5f);
            NoStipple_br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 10, NoStippleColor), Color.FromArgb(opacity, NoStippleColor), LinearGradientMode.BackwardDiagonal);
            int size = this.Font.Height;//取得字體的高度
            //取得外橢圓的區域
            Rectangle box = new Rectangle(rect.X + ((rect.Width - size) / 2), rect.Y + ((rect.Height - size) / 2), size - 2, size - 2);
            Rectangle glyph = new Rectangle(box.X + 3, box.Y + 3, box.Width - 6, box.Height - 6);//設定內圓的繪製區域
            g.FillEllipse(new SolidBrush(SystemColors.Window), box);//以白色填充單選圖案           
            if (Above && this.Enabled)//如果鼠標移入該控制元件
            {
                g.DrawEllipse(new Pen(Central_br, (float)(3)), new Rectangle(box.X + 2, box.Y + 2, box.Width - 4, box.Height - 4));//繪製中心橢圓
            }
            else
            {
                g.DrawEllipse(new Pen(NoCentral_br, (float)(3)), new Rectangle(box.X + 2, box.Y + 2, box.Width - 4, box.Height - 4));//繪製中心橢圓
            }
            g.DrawEllipse(new Pen(Periphery_br, (float)(1.5)), box);//繪製外橢圓
            g.FillEllipse(new SolidBrush(SystemColors.Window), glyph);//以白色填充內圓  
            if (this.Checked)//如果選中目前控制元件
                g.FillEllipse(Stipple_br, glyph);//填充內圓
            else
                g.FillEllipse(NoStipple_br, glyph);//填充內圓
        }

        /// <summary>
        /// 繪製文字
        /// </summary>
        /// <param g="Graphics">封裝一個繪圖的類物件</param>
        /// <param rect="Rectangle">繪製文字的區域</param>
        private void DrawText(Graphics g, Rectangle rect)
        {
            StringFormat tem_StringF = new StringFormat();//實例化StringFormat類
            tem_StringF.Alignment = StringAlignment.Near;//指定文字靠近佈局對齊
            tem_StringF.LineAlignment = StringAlignment.Center;//文字居中對齊
            if (FontAspect)//如果控制元件是原始方向顯示
                tem_StringF.FormatFlags = StringFormatFlags.DirectionRightToLeft;//按從右到左的順序顯示文字
            if (!FontAspect)//如果控制元件是反方向顯示
                g.DrawString(this.Text, this.Font, SystemBrushes.ControlText, rect, tem_StringF);//繪製文字（從左端開始繪製）
            else
            {
                rect.X = rect.X - SystemInformation.SmallIconSize.Width / 2 + 2;//設定文字的起始位置（在小圖標後）
                g.DrawString(this.Text, this.Font, SystemBrushes.ControlText, rect, tem_StringF);//繪製文字
            }
        }

        /// <summary>
        /// 取得文字的讀取方向
        /// </summary>
        /// <return>布爾型</return>
        private bool getAspect()
        {
            bool tem_Aspect = false;
            if (this.RightToLeft == RightToLeft.Yes)//從右到左進行讀取
                tem_Aspect = true;
            if (this.RightToLeft == RightToLeft.No)//從左到右進行讀取
                tem_Aspect = false;
            return tem_Aspect;
        }
        #endregion
    }
}
