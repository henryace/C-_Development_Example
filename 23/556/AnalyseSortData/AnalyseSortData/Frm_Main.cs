using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Drawing.Imaging;
using System.Data.SqlClient;
namespace AnalyseSortData
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

        }
        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }
        private void ShowPic(string str)
        {
            Conn();												//打開資料庫連接
            //產生SqlCommand對像
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num " + str, con))
            {
                SqlDataReader dr = cmd.ExecuteReader();						//建立SqlDataReader對像
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);	//新建一張畫布
                Graphics g = Graphics.FromImage(bitM);						//建立Graphics對像用於繪圖
                g.Clear(Color.White);									//設定畫布背景
                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(new Pen(new SolidBrush(Color.Red), 2.0f), 50, this.panel1.Height - 20 - i * 20, this.panel1.Width - 40, this.panel1.Height - 20 - i * 20);										//繪製水平線條
                    g.DrawString(Convert.ToString(i * 100), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 20, this.panel1.Height - 27 - i * 20);					//繪製商品上升數量
                }
                for (int j = 0; j < 4; j++)
                {
                    //繪製垂直線條
                    g.DrawLine(new Pen(new SolidBrush(Color.Red), 1.0f), 50 + 40 * j, this.panel1.Height - 20, 50 + 40 * j, 50);
                    if (dr.Read())
                    {
                        int x, y, w, h;									//聲明變數存儲坐標與寬高
                        g.DrawString(dr[0].ToString(), new Font("細明體", 8, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);										//繪製商品名稱
                        x = 78 + 40 * j;									//X坐標
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));														//Y坐標
                        w = 24;										//寬度
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100);//高度
                        g.FillRectangle(new SolidBrush(Color.FromArgb(56, 129, 78)), x, y, w, h);//開始繪製柱形圖
                    }
                }
                if (str == "desc")										//如果按降序排列
                {
                    //繪製提示文字，提示商品是按降序排列的
                    g.DrawString("熱賣前三名", new Font("細明體", 9), new SolidBrush(Color.Red), this.panel1.Width / 2 - 26, 20);
                }
                else if (str == "asc")									//如果按升序排列
                {
                    //繪製提示文字，提示商品是按升序排列的
                    g.DrawString("熱賣後三名", new Font("細明體", 9), new SolidBrush(Color.Red), this.panel1.Width / 2 - 26, 20);
                }
                this.panel1.BackgroundImage = bitM;						//顯示繪製的圖形
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPic("asc");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowPic("desc");
        }

    }
}
