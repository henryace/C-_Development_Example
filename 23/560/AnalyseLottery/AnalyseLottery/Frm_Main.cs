using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace AnalyseLottery
{
    public partial class Frm_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select * from tb_lottery where t_year between '" + Convert.ToDateTime(this.dateTimePicker1.Text).ToShortDateString() + "' and '" + Convert.ToDateTime(this.dateTimePicker2.Text).ToShortDateString() + "' order by t_year";
            DrowInfo(str);

        }

        private void DrowInfo(string SQL)
        {
            try
            {
                System.Drawing.Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);	//定義畫布
                Graphics g = Graphics.FromImage(bmp);								//建立Graphics物件
                g.Clear(Color.White);											//設定畫布背景顏色
                Brush bru = new SolidBrush(Color.Blue);								//建立Brush物件
                Pen p = new Pen(bru);											//定義畫筆
                Font font = new Font("Arial", 9, FontStyle.Bold);						//定義字體
                Conn();													//連接資料庫
                cmd = new SqlCommand(SQL, con);								//實例化SqlCommand
                SqlDataReader dr = cmd.ExecuteReader();								//建立SqlDataReader物件
                int i = 0;
                Pen pLine = new Pen(Color.Orange, 4.0f);									//定義畫筆
                string str = null;
                float f = 0.0f;
                while (dr.Read())													//開始讀取資料庫中的資料
                {
                    i++;
                    g.DrawString(dr[0].ToString().Substring(0, 7) + "月---", font, bru, 10, 15.0f * i);		//繪製月份
                    g.DrawString(dr[1].ToString(), font, bru, this.panel1.Width - 50, 15.0f * i);			//繪製每個月份的中獎情況
                    str += dr[1].ToString() + "#";
                    f += Convert.ToSingle(dr[1].ToString());
                }
                dr.Close();														//關閉SqlDataReader物件
                this.panel1.BackgroundImage = bmp;									//顯示繪製的圖像
                Bitmap bmpP = new Bitmap(this.panel3.Width, this.panel3.Height);				//定義畫布
                Graphics gP = Graphics.FromImage(bmpP);								//建立Graphics物件
                gP.Clear(Color.White);												//設定背景顏色
                Brush bruImg = new SolidBrush(Color.Orange);								//定義筆刷
                Pen Pg = new Pen(bruImg, 1.0f);										//定義畫筆
                string[] strCount = str.Split('#');
                int[] ICount = new int[strCount.Length];
                for (int l = 0; l < strCount.Length - 1; l++)
                {
                    ICount[l] = Convert.ToInt32(strCount[l]);
                }
                Point[] P = new Point[ICount.Length - 1];									//用於存儲直線的坐標
                for (int j = 0; j < ICount.Length - 1; j++)
                {
                    P[j].X = 35 + 28 * j;												//設定X坐標
                    P[j].Y = this.panel3.Height - 20 - Convert.ToInt32(ICount[j] / f * (this.panel3.Height + 20));//設定Y坐標
                }
                f = 0.0f;
                str = null;
                gP.DrawLines(new Pen(new SolidBrush(Color.Red)), P);						//繪製走勢圖
                gP.DrawString("分析結果走勢圖", new Font("細明體", 16), bru, this.panel3.Width / 2 - 80, 10);	//繪製標題
                this.panel3.BackgroundImage = bmpP;									//顯示繪製的圖像
            }
            catch
            {
                MessageBox.Show("此範圍內沒有任何訊息！！！");
                return;
            }
        }
    }
}