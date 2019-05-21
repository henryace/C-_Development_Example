using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class SmoothProgressBar : UserControl
    {
        public SmoothProgressBar()
        {
            InitializeComponent();
        }

        int min = 0; // 設定ProgressBar控制元件變化的最小值
        int max = 100; //設定ProgressBar控制元件變化的最大值
        int val = 0; //設定ProgressBar控制元件的目前值
        Color BarColor = Color.Blue; //初始化一種ARGB顏色

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();//使目前頁面無效從而導致重繪
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;//初始化一個GDI+繪圖圖面物件
            SolidBrush brush = new SolidBrush(BarColor);//初始化一個單色畫筆類
            float percent = (float)(val - min) / (float)(max - min);//儲存目前滾動條中的值所佔總長度的百分比
            Rectangle rect = this.ClientRectangle;//設定目前的工作區
            rect.Width = (int)((float)rect.Width * percent);//計算進度列的寬度
            g.FillRectangle(brush, rect);//用指定的對象填充工作區
            Draw3DBorder(g);//使控制元件實現3D效果
            brush.Dispose();//釋放畫刷所佔用的資源
            g.Dispose();//釋放GDI+繪圖圖面物件所佔用的資源
        }

        public int Minimum
        {
            get
            {
                return min;//返回最小值
            }

            set
            {
                if (value < 0)//當該值小於0時
                {
                    min = 0;//設定最小值為0
                }

                if (value > max)//當該值大於最大值時
                {
                    min = value;//設定最小值為該值
                }

                if (val < min)//當目前值小於最小值時
                {
                    val = min;//設定目前值為最小值
                }

                this.Invalidate();//使目前操作區域無效從而導致重繪事件
            }
        }

        public int Maximum
        {
            get
            {
                return max;//返回最大值
            }

            set
            {
                if (value < min)//當目前值小於最小值時
                {
                    min = value;//設定最小值為目前值
                }

                max = value;//設定最大值為目前值

                if (val > max)//當目前值大於最大值時
                {
                    val = max;//設定目前值為最大值
                }

                this.Invalidate();//使目前操作區域無效並導致重繪事件
            }
        }

        public int Value
        {
            get
            {
                return val;//返回該值
            }

            set
            {
                int oldValue = val;//儲存目前值

                if (value < min)//當該值小於最小值時
                {
                    val = min;//設定該值為最小值
                }
                else if (value > max)//當該值大於最大值時
                {
                    val = max;//設定該值為最大值
                }
                else//當該值介於最小值和最大值之間時
                {
                    val = value;//設定目前值為該值
                }

                float percent;//該變數用來儲存進度列中的值所佔總長度的百分比

                Rectangle newValueRect = this.ClientRectangle;//初始化一個新的工作區域物件
                Rectangle oldValueRect = this.ClientRectangle;//初始化一個舊的工作區域物件

                percent = (float)(val - min) / (float)(max - min);//用進度列的目前值初始化變數percent
                newValueRect.Width = (int)((float)newValueRect.Width * percent);//設定新工作區域對象的寬度

                percent = (float)(oldValue - min) / (float)(max - min);//用進度列的舊值初始化變數percent
                oldValueRect.Width = (int)((float)oldValueRect.Width * percent);//設定就工作區域對象的寬度

                Rectangle updateRect = new Rectangle();//初始化一個更新區域的對象

                if (newValueRect.Width > oldValueRect.Width)//當新工作區域大於舊工作區域時
                {
                    updateRect.X = oldValueRect.Size.Width;//設定更新區域左上角的X坐標
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;//設定更新區域的寬度
                }
                else//當新工作區域小於或等於就工作區域時
                {
                    updateRect.X = newValueRect.Size.Width;//設定更新區域左上角的X坐標
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;//設定更新區域的寬度
                }

                updateRect.Height = this.Height;//設定更新區域的高度

                this.Invalidate(updateRect);//使目前操作區域無效並導致重繪事件
            }
        }

        public Color ProgressBarColor
        {
            get
            {
                return BarColor;//返回進度列的顏色
            }

            set
            {
                BarColor = value;//設定進度列的顏色等於目前值
            }
        }

        private void Draw3DBorder(Graphics g)
        {
            int PenWidth = (int)Pens.White.Width;//儲存鋼筆類的寬度

            g.DrawLine(Pens.DarkGray, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
           new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));//繪製該控制元件的上邊緣
            g.DrawLine(Pens.DarkGray, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));//繪製控制元件的左邊緣
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
           new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));//繪製控制元件的下邊緣
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
            new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));//繪製控制元件的右邊緣
        }

    }
}
