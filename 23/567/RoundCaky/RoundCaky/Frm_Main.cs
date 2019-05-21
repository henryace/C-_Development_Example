using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RoundCaky
{
    public partial class Frm_Main : Form
    {
        public class PyPanel : Panel
        {
            public PyPanel()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }
        public Frm_Main()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }

        Bitmap bt;
        Bitmap bt1;
        int flag = 0;
        PyPanel panel1 = new PyPanel();
        private void ShowPic(string SexCode, float f)							// ShowPic方法繪製餅圖
        {
            this.Controls.Add(panel1);									//將Panel控制元件新增到視窗中
            panel1.Width = 230;										//設定Panel控制元件的寬度
            panel1.Height = 230;										//設定Panel控制元件的高度
            bt = new Bitmap(panel1.Width, panel1.Height);						//建立畫布
            Graphics g = Graphics.FromImage(bt);							//建立Graphics對像
            Pen p = new Pen(new SolidBrush(Color.Blue));						//建立畫筆
            Point p1 = new Point(0, 0);									//建立一個Point對像
            Size s = new Size(this.panel1.Width, this.panel1.Height);				//建立Size對像
            Rectangle trct = new Rectangle(p1, s);							//建立Rectangle對像
            g.FillEllipse(new SolidBrush(Color.Red), trct);						//繪製橢圓
            g.FillPie(new SolidBrush(Color.Blue), trct, flag, f * 360);				//繪製扇形
            bt1 = new Bitmap(panel2.Width, panel2.Height);						//建立畫布
            Graphics ginfo = Graphics.FromImage(bt1);						//建立Graphics對像
            Font font = new Font("細明體", 10, FontStyle.Regular);				//設定字體
            ginfo.DrawString(SexCode + " " + f.ToString().Substring(0, 4), font, new SolidBrush(Color.Blue), 0, 5);
            ginfo.DrawString("女" + " " + (1.0 - Convert.ToDouble(f.ToString().Substring(0, 4))).ToString().Substring(0, 4), font, new SolidBrush(Color.Red), 0, 25);											//繪製性別及比率
            panel1.BackgroundImage = bt;								//顯示餅圖
            panel2.BackgroundImage = bt1;								//顯示性別及比率
        }

        private void button1_Click(object sender, EventArgs e)					//單擊「顯示」按鈕顯示餅圖
        {
            Conn();												//連接資料庫
            using (cmd = new SqlCommand("SELECT sex,COUNT(sex) num FROM tb_sex group by sex", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();						//建立SqlDataReader對像
                string[] str = new string[2];
                int i = 0;
                while (dr.Read())										//讀取記錄
                {
                    str[i] = dr[0].ToString() + "," + dr[1].ToString();			//取得資料庫中存儲的性別及比例
                    i++;
                }
                float N = Convert.ToInt16(str[0].Substring(2)) + Convert.ToInt16(str[1].Substring(2));//男女性別比例之和
                float f = Convert.ToInt16(str[0].Substring(2)) / N;				//男性的比例
                flag = 180;											//開始繪製的起始角度
                ShowPic(str[0].Substring(0, 1), f);							//呼叫ShowPic方法繪製餅圖
            }
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)						//當單擊「旋轉」按鈕時開始旋轉餅圖
        {
            flag += 1;												//每次轉動一度
            Conn();												//連接資料庫
            using (cmd = new SqlCommand("SELECT sex,COUNT(sex) num FROM tb_sex group by sex", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();						//建立SqlDataReader對像
                string[] str = new string[2];								//宣告陣列存儲性別及比例
                int i = 0;
                while (dr.Read())
                {
                    str[i] = dr[0].ToString() + "," + dr[1].ToString();			//取得資料庫中存儲的性別及比例
                    i++;
                }
                float N = Convert.ToInt16(str[0].Substring(2)) + Convert.ToInt16(str[1].Substring(2)); //男女性別比例之和
                float f = Convert.ToInt16(str[0].Substring(2)) / N;				//男性的比例
                ShowPic(str[0].Substring(0, 1), f);							//呼叫ShowPic方法繪製餅圖
            }
            con.Close();												//關閉連接
        }

        private void button2_Click(object sender, EventArgs e)					//「旋轉」按鈕
        {
            if (button2.Text == "旋轉")									//如果按鈕顯示「旋轉」文字
            {
                timer1.Start();										//開始Timer控制元件
                button2.Text = "停止";									//將按鈕的文字設為「停止」
            }
            else													//如果按鈕的文字為「停止」
            {
                timer1.Stop();										//停止Timer控制元件
                button2.Text = "旋轉";									//將按鈕的文字設為「旋轉」
            }
        }
    }
}
