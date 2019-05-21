using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Data.SqlClient;
namespace GatherDataAnalyse
{
    public partial class Frm_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPic();
        }
        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }
        private void ShowPic()
        {
            Conn();														//打開資料庫連接
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num desc", con)) ;//實例化SqlCommand對像
            {
                SqlDataReader dr = cmd.ExecuteReader();								//建立SqlDataReader對像
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);			//實例化一個新畫布
                Graphics g = Graphics.FromImage(bitM);								//建立Graphics對像
                g.Clear(Color.White);											//設定畫布背景
                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(new Pen(new SolidBrush(Color.Red), 2.0f), 50, this.panel1.Height - 20 - i * 20, this.panel1.Width - 40, this.panel1.Height - 20 - i * 20);												//繪製水平直線
                    g.DrawString(Convert.ToString(i * 100), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 20, this.panel1.Height - 27 - i * 20);							//繪製文字
                }
                for (int j = 0; j < 4; j++)
                {
                    //繪製垂直直線
                    g.DrawLine(new Pen(new SolidBrush(Color.Red), 1.0f), 50 + 40 * j, this.panel1.Height - 20, 50 + 40 * j, 20);
                    if (dr.Read())
                    {
                        int x, y, w, h;											//聲明變數存儲坐標和寬高
                        g.DrawString(dr[0].ToString(), new Font("細明體", 8, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);													//繪製說明文字
                        x = 78 + 40 * j;											//X軸
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));																//Y軸
                        w = 24;												//寬
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100); 	//高
                        g.FillRectangle(new SolidBrush(Color.FromArgb(56, 129, 78)), x, y, w, h);	//繪製柱形圖
                    }
                }
                this.panel1.BackgroundImage = bitM; //將畫布設為panel1控制元件的背景圖
            }
        }
    }
}