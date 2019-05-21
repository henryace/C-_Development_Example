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
namespace TextInColumn
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }
        private void ShowPic()
        {
            Conn();												//打開資料庫
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num desc", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();						//建立SqlDataReader對像
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);	//建立畫布
                Graphics g = Graphics.FromImage(bitM);						//建立Graphics對像
                Pen p = new Pen(new SolidBrush(Color.SlateGray), 1.0f);			//建立Pen對像
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;		//設定虛線
                g.Clear(Color.White);									//設定畫布顏色
                for (int i = 0; i < 5; i++)
                {
                    //繪製水平線條
                    g.DrawLine(p, 50, this.panel1.Height - 20 - i * 20, this.panel1.Width - 40, this.panel1.Height - 20 - i * 20);
                    g.DrawString(Convert.ToString(i * 100), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 20, this.panel1.Height - 27 - i * 20);					//繪製商品的增長值
                }
                for (int j = 0; j < 4; j++)
                {
                    g.DrawLine(p, 50, this.panel1.Height - 20, 50, 20);			//繪製垂直線條
                    if (dr.Read())
                    {
                        int x, y, w, h;									//聲明變數存儲坐標和大小
                        g.DrawString(dr[0].ToString(), new Font("細明體", 9, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);										//繪製商品名稱
                        x = 78 + 40 * j;									//X坐標
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));														//Y坐標
                        w = 24;										//寬度
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100);//高度
                        g.FillRectangle(new SolidBrush(Color.SlateGray), x, y, w, h);	//繪製長條圖
                        g.DrawString((h * 100 / 20).ToString(), new Font("細明體", 8, FontStyle.Bold), new SolidBrush(Color.Tomato), new Point(x + 4, y - 10));												//在長條圖指定的位置繪製文字
                    }
                }
                this.panel1.BackgroundImage = bitM;						//顯示繪製的圖形
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowPic();
        }
    }
}
