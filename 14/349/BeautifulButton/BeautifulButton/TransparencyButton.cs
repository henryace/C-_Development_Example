using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BeautifulButton
{
    public partial class TransparencyButton : UserControl
    {
        public TransparencyButton()
        {
            InitializeComponent();
        }

        #region 公共變數
        public static SmoothingMode sm;
        public static bool pub_ButtonClick = true;//判斷按鈕是否按下（false為按下）
        public static int pub_Degree = 0;//記錄四角弧度的大小範圍
        public static int pub_RGB_r0 = 0x130;//按鈕背景的R色值
        public static int pub_RGB_r1 = 0x99;//按鈕其它顏色的R色值
        #endregion

        #region 新增屬性
        private string BNText = "";
        [Browsable(true), Category("透明按鈕的屬性設定"), Description("設定顯示的文字")]   //在「屬性」視窗中顯示NText屬性
        public string NText
        {
            get { return BNText; }
            set
            {
                BNText = value;
                if (BNText.Length > 0)
                    Invalidate();
            }
        }

        private int BDegree = 1;
        [Browsable(true), Category("透明按鈕的屬性設定"), Description("設定按鈕四個角的弧度")]   //在「屬性」視窗中顯示Degree屬性
        public int Degree
        {
            get { return BDegree; }
            set
            {
                BDegree = value;
                if (this.Width >= this.Height)
                    pub_Degree = (int)(this.Height / 2);
                else
                    pub_Degree = (int)(this.Width / 2);
                if (BDegree <= 0)
                    BDegree = 1;
                if (BDegree > pub_Degree)
                    BDegree = pub_Degree;
                if (BDegree > 0)
                    Invalidate();
            }
        }

        private Color DShineColor = Color.Black;
        [Browsable(true), Category("透明按鈕的屬性設定"), Description("設定按鈕的光澤度顏色")]   //在「屬性」視窗中顯示ShineColor屬性
        public Color ShineColor
        {
            get { return DShineColor; }
            set
            {
                DShineColor = value;
                Invalidate();
            }
        }

        private Color DUndersideShine = Color.LightGray;
        [Browsable(true), Category("透明按鈕的屬性設定"), Description("設定按鈕的下部的光澤度")]   //在「屬性」視窗中顯示UndersideShine屬性
        public Color UndersideShine
        {
            get { return DUndersideShine; }
            set
            {
                DUndersideShine = value;
                Invalidate();
            }
        }

        private int DCTransparence = 0;
        [Browsable(true), Category("透明按鈕的屬性設定"), Description("設定按鈕的透明度數")]   //在「屬性」視窗中顯示CTransparence屬性
        public int CTransparence
        {
            get { return DCTransparence; }
            set
            {
                DCTransparence = value;
                if (DCTransparence > 20)
                    DCTransparence = 20;
                if (DCTransparence < 0)
                    DCTransparence = 0;
                if (DCTransparence >= 0)
                    Invalidate();
            }
        }

        private int DCFontDeepness = 1;
        [Browsable(true), Category("透明按鈕的屬性設定"), Description("設定按鈕文字的深度")]   //在「屬性」視窗中顯示CFontDeepness屬性
        public int CFontDeepness
        {
            get { return DCFontDeepness; }
            set
            {
                DCFontDeepness = value;
                if (DCFontDeepness > 20)
                    DCFontDeepness = 20;
                if (DCFontDeepness < 0)
                    DCFontDeepness = 0;
                if (DCFontDeepness >= 0)
                    Invalidate();
            }
        }

        #endregion

        #region 事件
        private void TransparencyButton_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Transparent;//使目前控制元件透明
            sm = e.Graphics.SmoothingMode;//設定呈現質量
            Color shineColor = Color.Black;
            Rectangle rect2 = new Rectangle(0, 0, this.Width, this.Height);//設定繪製按鈕的矩形區域
            Rectangle rect1 = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2);//設定繪製按鈕下半部的矩形區域
            if (this.CTransparence == 0)//如果按鈕的透明度為0
            {
                CobOblongDown(rect2, e.Graphics);//繪製按扭的背景
                CobOblong(rect2, e.Graphics, this.ShineColor);//繪製按扭的背景
            }
            else
            {
                if (this.CTransparence > 0)//如果按鈕的透明度不為0
                {
                    CobOblongDown(rect2, e.Graphics);//繪製按扭的背景
                    for (int i = 0; i < CTransparence; i++)
                    {
                        CobOblong(rect2, e.Graphics, this.ShineColor);//繪製按扭的背景顏色
                    }
                }
            }

            int tem_n = (int)(this.CTransparence / 3);//取得一個值，用於設定下半部按鈕的顏色深度
            if (tem_n == 0)//如果為0
                CobAjar(rect1, e.Graphics, this.ShineColor);//繪製按扭的下半部背景
            else
            {
                if (tem_n > 0)//如果不為0
                {
                    for (int i = 0; i < tem_n; i++)//加深下部按鈕的顏色
                    {
                        CobAjar(rect1, e.Graphics, this.ShineColor);//繪製按扭的下半部背景顏色
                    }
                }
            }
            CobOblong(rect2, e.Graphics, this.UndersideShine);//設定下半部按鈕的光澤度
            if (pub_ButtonClick == false)//判斷按鈕是否按下（false為按下）
            {
                CobOblongDown(rect2, e.Graphics);//繪製按扭的背景
            }
            if (this.NText.Length > 0)//如果Text屬性中有值
                ProtractText(e.Graphics);//繪製透明按鈕的文字訊息
        }

        private void TransparencyButton_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();//對控制元件進行重繪
        }

        private void TransparencyButton_MouseDown(object sender, MouseEventArgs e)
        {
            pub_ButtonClick = false;//按下按鈕
            Invalidate();//對控制元件進行重繪
        }

        private void TransparencyButton_MouseUp(object sender, MouseEventArgs e)
        {
            pub_ButtonClick = true;//鬆開按鈕
            Invalidate();//對控制元件進行重繪
        }
        #endregion

        #region 自定義方法
        /// <summary>
        /// 繪製透明按扭的文字
        /// </summary>
        /// <param g="Graphics">封裝一個繪圖的類物件</param>
        private void ProtractText(Graphics g)
        {
            Graphics TitG = this.CreateGraphics();//建立Graphics類物件
            string TitS = this.NText;//取得圖表標題的名稱
            SizeF TitSize = TitG.MeasureString(TitS, this.Font);//將繪製的字串進行格式化
            float TitWidth = TitSize.Width;//取得字串的寬度
            float TitHeight = TitSize.Height;//取得字串的高度
            float TitX = 0;//標題的橫向坐標
            float TitY = 0;//標題的縱向坐標
            if (this.Height > TitHeight)//如果按鈕的高度大於文字的高度
                TitY = (this.Height - TitHeight) / 2;//使文字水平方向局中
            else
                TitY = this.BDegree;//文字置頂
            if (this.Width > TitWidth)//如果按鈕的寬度大於文字的寬度
                TitX = (this.Width - TitWidth) / 2;//使文字水平局中
            else
                TitX = this.BDegree;//文字置左
            //設定文字的繪製區域
            Rectangle rect = new Rectangle((int)Math.Floor(TitX), (int)Math.Floor(TitY), (int)Math.Ceiling(TitWidth), (int)Math.Ceiling(TitHeight));
            int opacity = pub_RGB_r1;//設定R色值
            opacity = (int)(.4f * opacity + .5f);//設定漸變值
            for (int i = 0; i < DCFontDeepness; i++)//設定文字的深度
            {
                //設定文字的漸變顏色
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity, this.ForeColor), Color.FromArgb(opacity, this.ForeColor), LinearGradientMode.Vertical))
                {
                    g.DrawString(TitS, this.Font, br, new PointF(TitX, TitY));//繪製帶有漸變效果的文字
                }
            }
        }

        /// <summary>
        /// 繪製透明按扭的背景色
        /// </summary>
        /// <param rect="Rectangle">繪製按鈕的區域</param>
        /// <param g="Graphics">封裝一個繪圖的類物件</param>
        /// <param fillColor="Color">填充的顏色</param>
        private void CobOblong(Rectangle rect, Graphics g, Color fillColor)
        {
            using (GraphicsPath bh = CreateCobOblong(rect, this.BDegree))//繪製一個圓角矩形
            {
                int opacity = pub_RGB_r0;//設定按鈕的R色值
                opacity = (int)(.4f * opacity + .5f);//設定漸變的變化值
                //設定按鈕的漸變顏色
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 5, fillColor), Color.FromArgb(opacity, fillColor), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, bh);//填充按鈕背景
                }
                g.SmoothingMode = sm;//設定呈現的質量
            }
        }

        /// <summary>
        /// 繪製透明按扭的下半部背景色
        /// </summary>
        /// <param rect="Rectangle">繪製按鈕的下半部區域</param>
        /// <param g="Graphics">封裝一個繪圖的類物件</param>
        /// <param fillColor="Color">填充的顏色</param>
        private void CobAjar(Rectangle rect, Graphics g, Color fillColor)
        {
            using (GraphicsPath bh = CreateCobAjar(rect, this.BDegree))
            {
                int opacity = pub_RGB_r1;
                opacity = (int)(.4f * opacity + .5f);
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity, fillColor), Color.FromArgb(pub_RGB_r1 / 5, fillColor), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, bh);//填充按鈕背景
                }
                g.SmoothingMode = sm;//設定呈現的質量
            }
        }

        /// <summary>
        /// 繪製透明按扭按下時的效果
        /// </summary>
        /// <param rect="Rectangle">繪製按鈕的區域</param>
        /// <param g="Graphics">封裝一個繪圖的類物件</param>
        private void CobOblongDown(Rectangle rect, Graphics g)
        {
            using (GraphicsPath bh = CreateCobOblong(rect, this.BDegree))//按鈕的圓角繪製
            {
                int opacity = pub_RGB_r1;//設定按鈕的R色值
                Color tem_Color = Color.Black;//設定按鈕的背景顏色為黑色
                if (pub_ButtonClick == true)//如果按鈕沒有按下
                {
                    opacity = pub_RGB_r0;//設定按鈕的R色值
                    tem_Color = Color.White;//設定按鈕的背景顏色為白色
                }
                opacity = (int)(.4f * opacity + .5f);//設定漸變的變化值
                //設定按鈕的漸變顏色
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity + 20, tem_Color), Color.FromArgb(opacity, tem_Color), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, bh);//填充按鈕背景
                }
                g.SmoothingMode = sm;//設定呈現的質量
            }
        }

        /// <summary>
        /// 按鈕的圓角繪製
        /// </summary>
        /// <param rect="Rectangle">繪製按鈕的區域</param>
        /// <param radius="int">圓角的度數</param>
        private static GraphicsPath CreateCobOblong(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();//實例化GraphicsPath類
            int l = rectangle.Left;//取得矩形左上角的X坐標
            int t = rectangle.Top;//取得矩形左上角的Y坐標
            int w = rectangle.Width;//取得矩形的寬度
            int h = rectangle.Height;//取得矩形的高度
            path.AddArc(l, t, 2 * radius, 2 * radius, 180, 90);//在矩形的左上角繪製圓角
            path.AddLine(l + radius, t, l + w - radius, t);//繪製左上角圓角與右上角之間的線段
            path.AddArc(l + w - 2 * radius, t, 2 * radius, 2 * radius, 270, 90);//繪製右上角的圓角
            path.AddLine(l + w, t + radius, l + w, t + h - radius);//繪製左上角、右上角和右下角所形成的三角形
            path.AddArc(l + w - 2 * radius, t + h - 2 * radius, 2 * radius, 2 * radius, 0, 90);//繪製右下角圓角
            path.AddLine(l + radius, t + h, l + w - radius, t + h);//繪製右下角圓角與左上角圓之間的線段
            path.AddArc(l, t + h - 2 * radius, 2 * radius, 2 * radius, 90, 90);//繪製左下角的圓角
            path.AddLine(l, t + radius, l, t + h - radius);//繪製左上角、左下角和右下角之間的三角形
            return path;
        }

        /// <summary>
        /// 按鈕的下半個圓角繪製
        /// </summary>
        /// <param rect="Rectangle">繪製下半部按鈕的區域</param>
        /// <param radius="int">圓角的度數</param>
        private static GraphicsPath CreateCobAjar(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int l = rectangle.Left;//取得矩形左上角的X坐標
            int t = rectangle.Top;//取得矩形左上角的Y坐標
            int w = rectangle.Width;//取得矩形的寬度
            int h = rectangle.Height;//取得矩形的高度
            path.AddArc(l, t, 2 * radius, 2 * radius, 0, 0);//繪製左上角的點
            path.AddLine(l, t, l + w, t);//繪製左上角與右上角之間的線段
            path.AddArc(l + w, t, 2 * radius, 2 * radius, 0, 0);//繪製右上角的點
            path.AddLine(l + w, t + radius, l + w, t + h - radius);//繪製左上角、右上角和右下角所形成的三角形
            path.AddArc(l + w - 2 * radius, t + h - 2 * radius, 2 * radius, 2 * radius, 0, 90);//繪製右下角圓角
            path.AddLine(l + radius, t + h, l + w - radius, t + h);//繪製右下角圓角與左上角圓之間的線段
            path.AddArc(l, t + h - 2 * radius, 2 * radius, 2 * radius, 90, 90);//繪製左下角的圓角
            path.AddLine(l, t + radius, l, t + h - radius);//繪製左上角、左下角和右下角之間的三角形
            return path;
        }
        #endregion
    }
}
