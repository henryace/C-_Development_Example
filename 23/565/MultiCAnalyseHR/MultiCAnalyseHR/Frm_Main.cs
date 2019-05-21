using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace MultiCAnalyseHR
{
    public partial class Frm_Main : Form
    {
        SqlConnection con = new SqlConnection("server=(local);pwd=123456;uid=sa;database=db_TomeOne");
        SqlCommand cmd;
        static int ConutNum = 0;
        static float floatNum = 0.0f;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (cmd = new SqlCommand("select sum(t_Num) from tb_manpower ", con))
            {
                con.Open();
                int Sum = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                ShowPic(Sum);
            }
        }

        private void ShowPic(int Sum)//透過自定義ShowPic( )方法,繪製多餅圖分析企業人力資源情況
        {
            using (cmd = new SqlCommand("select t_Point,sum(t_Num) from tb_manpower group by t_Point order by sum(t_Num) desc", con))
            {
                Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);			//建立畫布
                Graphics g = Graphics.FromImage(bmp);							//建立Graphics對像
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();							//建立SqlDataReader對像
                while (dr.Read())											//開始讀取記錄
                {
                    float f = Convert.ToSingle(dr[1]) / Sum;
                    string str = dr[0].ToString();
                    drowPic(g, f, str);										//呼叫drowPic方法繪製餅圖
                }
                //繪製線條
                g.DrawLine(new Pen(Color.Black), 0, this.panel1.Height / 2, this.panel1.Width, this.panel1.Height / 2);
                g.DrawLine(new Pen(Color.Black), this.panel1.Width / 2, 0, this.panel1.Width / 2, this.panel1.Height);
                this.panel1.BackgroundImage = bmp;								//顯示繪製的圖形
                dr.Close();												//關閉SqlDataReader對像
                con.Close();												//關閉資料庫連接
            }
        }
        private void drowPic(Graphics g, float f, string str) 							//根據要求繪製餅圖
        {
            if (ConutNum == 0)											//如果ConutNum為0時執行
            {
                //繪製扇形
                g.FillPie(new SolidBrush(Color.Black), 0, 0, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, 0, 360 * f);
                //繪製文字
                g.DrawString(str, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Black), (this.panel1.Width) / 2 - 70, 10);
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Black), (this.panel1.Width) / 2 - 70, 25);							//繪製文字
                floatNum = 360 * f;										//計算角度
                ConutNum += 1;											//使ConutNum為1
            }
            else if (ConutNum == 1)										//如果ConutNum為1時執行
            {
                g.FillPie(new SolidBrush(Color.DarkOrange), (this.panel1.Width) / 2, 0, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, floatNum, 360 * f);												//繪製扇形
                g.DrawString(str, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.DarkOrange), (this.panel1.Width) / 2 + 10, 10);															//繪製文字
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.DarkOrange), (this.panel1.Width) / 2 + 10, 25);					//繪製文字
                floatNum += 360 * f;										//計算角度
                ConutNum += 1;										// ConutNum為2
            }
            else if (ConutNum == 2)										// ConutNum為2時執行
            {
                g.FillPie(new SolidBrush(Color.Red), 0, (this.panel1.Height - 10) / 2 + 10, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, floatNum, 360 * f);									//繪製扇形
                g.DrawString(str, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Red), 10, (this.panel1.Height - 10) / 2 + 20);															//繪製文字
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Red), 10, (this.panel1.Height - 10) / 2 + 35);						//繪製文字
                floatNum += 360 * f;										//計算角度
                ConutNum += 1;											// ConutNum為3
            }
            else if (ConutNum == 3)										// ConutNum為3時執行
            {
                g.FillPie(new SolidBrush(Color.Blue), (this.panel1.Width) / 2 - 10, (this.panel1.Height - 10) / 2 + 10, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, floatNum, 360 * f);				//繪製扇形
                g.DrawString(str, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Blue), (this.panel1.Width) / 2 + 10, (this.panel1.Height - 10) / 2 + 20);											//繪製文字
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Blue), (this.panel1.Width) / 2 + 10, (this.panel1.Height - 10) / 2 + 35);		//繪製文字
            }
        }
    }
}