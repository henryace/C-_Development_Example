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

namespace DrawColumn
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
            Conn();													//打開資料庫連接
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num desc", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();							//建立SqlDataReader對像
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);		//建立畫布
                Graphics g = Graphics.FromImage(bitM);							//建立Graphics對像
                g.Clear(Color.White);										//設定畫布背景
                for (int j = 0; j < 4; j++)										//開始讀取資料庫中的資料並繪圖
                {
                    if (dr.Read())											//讀取記錄集
                    {
                        int x, y, w, h;										//聲明變數存儲坐標和大小
                        g.DrawString(dr[0].ToString(), new Font("細明體", 8, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);											//繪製文字
                        x = 78 + 40 * j;										//x坐標
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));															//y坐標
                        w = 24;											//寬
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100);//高
                        g.FillRectangle(new SolidBrush(Color.FromArgb(56, 129, 78)), x, y, w, h);//開始繪製柱形圖
                    }
                }
                this.panel1.BackgroundImage = bitM;							//顯示繪製的柱形圖
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowPic();
        }
    }
}
