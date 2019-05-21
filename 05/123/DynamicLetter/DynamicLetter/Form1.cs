using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace DynamicLetter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics Car_Paint = panel1.CreateGraphics();//實例化繪圖物件
            string Car_Str = "編程詞典網";//定義要繪製的動態文字
            Character character = new Character();//實例化自定義類物件
            character.CartoonEffect(panel1, Car_Str);//在視窗上顯示動態文字
        }
    }
    class Character
    {
        System.Drawing.Graphics g;//定義Graphics物件
        static int[] FSize = new int[3] { 20, 25, 30 };//設定字體的大小
        int Str_block = 5;//字體間的間隔
        Font Str_Font = new Font("細明體", FSize[0], FontStyle.Bold);//定義字體樣式
        Color Str_Color = Color.Orange;//定義字體顏色
        float Str_Width = 0;//取得字串的位置
        float Str_Height = 0;
        float Panel_W = 0;//取得控制元件的寬度
        float Panel_H = 0;//取得控制元件的高度
        Color Panel_C;//記錄控制元件的背景顏色
        float Str_Odd_Width = 0;//取得單個文字的寬度
        Thread th;//定義線程

        /// <summary>
        /// 在Panel控制元件中繪製動畫文字
        /// </summary>
        /// <param Panel="C_Panel">顯示文字的容器控制元件</param>
        /// <param string="C_Str">文字字串</param>
        public void CartoonEffect(Panel C_Panel, string C_Str)
        {
            g = C_Panel.CreateGraphics();//為控制元件建立Graphics物件
            Panel_H = C_Panel.Height;//取得控制元件的高度
            Panel_W = C_Panel.Width;//取得控制元件的寬度
            Panel_C = C_Panel.BackColor;//取得控制元件背景顏色
            GetTextInfo(C_Str);//取得文字的大小及位置
            g.FillRectangle(new SolidBrush(Panel_C), 0, 0, Panel_W, Panel_H);//用控制元件背景填充控制元件
            ProtractText(C_Str, 0);//繪製文字
            //實例化ParameterizedThreadStart委託線程
            th = new Thread(new ParameterizedThreadStart(DynamicText));
            th.Start(C_Str);//傳遞一個字串的參數
        }

        /// <summary>
        /// 取得文字的大小及繪製位置
        /// </summary>
        /// <param string="C_Str">文字字串</param>
        public void GetTextInfo(string C_Str)
        {
            SizeF TitSize = g.MeasureString(C_Str, Str_Font);//將繪製的字串進行格式化
            Str_Width = TitSize.Width;//取得字串的寬度
            Str_Height = TitSize.Height;//取得字串的高度
            Str_Odd_Width = Str_Width / (float)C_Str.Length;//取得單個文字的寬度
            Str_Width = (float)((Str_Odd_Width + Str_block) * C_Str.Length);//取得文字的寬度
            Str_Width = (Panel_W - Str_Width) / 2F;//使文字居中
            Str_Height = Panel_H - Str_Height;//使文字顯示在控制元件底端
        }

        /// <summary>
        /// 繪製全部文字
        /// </summary>
        /// <param string="C_Str">繪製的文字字串</param>
        public void ProtractText(string C_Str, int n)
        {
            float Str_Place = Str_Width;//單個字符的位置
            for (int i = 0; i < C_Str.Length; i++)//深度搜尋字串中的文字
            {
                if (i != n)
                    ProtractOddText(C_Str[i].ToString(), Str_Font, Str_Place, Str_Height);//繪製單個文字
                Str_Place += Str_Odd_Width + Str_block;//取得下一個文字的位置
            }
        }

        /// <summary>
        /// 繪製單個文字
        /// </summary>
        /// <param name="C_Odd_Str">單個文字字串</param>
        /// <param name="S_Font">文字樣式</param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void ProtractOddText(string C_Odd_Str, Font S_Font, float left, float top)
        {
            g.DrawString(C_Odd_Str, S_Font, new SolidBrush(Str_Color), new PointF(left, top));//繪製字串中單個文字
        }

        /// <summary>
        /// 透過反覆運算器實現字串的深度搜尋
        /// </summary>
        /// <param string="n">文字字串</param>
        /// <returns>返回單個文字</returns>
        public static IEnumerable<object> Transpose(string n)
        {
            if (n.Length > 0)//如果泛型不為空
            {
                foreach (object i in n)//對字串進行深度搜尋
                    yield return i;
            }
        }

        /// <summary>
        /// 繪製動態文字
        /// </summary>
        /// <param string="C_Str">繪製的文字字串</param>
        public void DynamicText(Object C_Str)
        {
            float tem_left = 0;//取得目前文字的左端位置
            float tem_top = 0;//取得目前文字的頂端位置
            float tem_w = 0;//取得文字的寬度
            float tem_h = 0;//取得文字的高度
            float tem_place = Str_Width;//取得起始文字的位置
            Font Tem_Font = new Font("黑體", FSize[0], FontStyle.Bold);//定義字體樣式
            int p = 0;//記錄字串中文字的索引號
            int Str_Index = 0;
            try
            {
                foreach (object s in Transpose(C_Str.ToString()))//深度搜尋字串
                {
                    for (int i = 1; i < 5; i++)//
                    {
                        if (i >= 3)
                            p = Convert.ToInt16(Math.Floor(i / 2F));
                        else
                            p = i;
                        ProtractText(C_Str.ToString(), Str_Index);
                        Tem_Font = new Font("黑體", FSize[p], FontStyle.Bold);//定義字體樣式
                        SizeF TitSize = g.MeasureString(s.ToString(), Str_Font);//將繪製的單個文字進行格式化
                        tem_w = TitSize.Width;//取得文字的寬度
                        tem_h = TitSize.Height;//取得文字串的高度
                        tem_left = tem_place - (tem_w - Str_Odd_Width) / 2F;//取得文字改變大小後的左端位置
                        tem_top = Str_Height - (Str_Height - tem_h) / 2F;//取得文字改變大小後的頂端位置
                        ProtractOddText(s.ToString(), Tem_Font, tem_left, tem_top);//繪製單個文字
                        Thread.Sleep(200);//待待0.2秒
                        g.FillRectangle(new SolidBrush(Panel_C), 0, 0, Panel_W, Panel_H);//清空繪製的文字
                    }
                    tem_place += Str_Odd_Width + Str_block;//計算下一個文字的左端位置
                    Str_Index += 1;//將索引號定位到下一個文字
                }
                ProtractText(C_Str.ToString(), -1);//恢復文字的原始繪製樣式
                //實例化ParameterizedThreadStart委託線程
                th = new Thread(new ParameterizedThreadStart(DynamicText));
                th.Start(C_Str);//傳遞一個字串的參數
            }
            catch//這裡之所以用異常語句，是在關閉視窗時關閉線程
            {
                th.Abort();//關閉線程
            }
        }
    }
}
