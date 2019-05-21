using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace MultiCurve
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("server=(local);pwd=123456;uid=sa;database=db_TomeOne"))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Years from tb_curve", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.comboBox1.DataSource = dt.DefaultView;
                this.comboBox1.DisplayMember = "Years";
                this.comboBox1.ValueMember = "Years";
            }
        }
        private void CreateImage(int ID)
        {
            int height = 440, width = 600;									//設定畫布寬和高
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(width, height);//建立畫布
            Graphics g = Graphics.FromImage(image);						//建立Graphics對像
            try
            {
                g.Clear(Color.White);									//清空圖片背景色
                Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);	//設定字體
                Font font1 = new System.Drawing.Font("細明體", 12, FontStyle.Regular);	//設定字體
                Font font2 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);	//設定字體
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);		//建立LinearGradientBrush對像
                g.FillRectangle(Brushes.AliceBlue, 0, 0, width, height);			//繪製矩形框
                Brush brush1 = new SolidBrush(Color.Blue);					//建立筆刷
                Brush brush2 = new SolidBrush(Color.SaddleBrown);			//建立筆刷
                string str = "SELECT * FROM tb_curve WHERE Years=" + ID + "";		//聲明SQL語句
                SqlConnection Con = new SqlConnection("server=(local);pwd=123456;uid=sa;database=db_TomeOne");//建立資料庫連接
                Con.Open();											//打開資料庫連接
                SqlCommand Com = new SqlCommand(str, Con);				//建立SqlCommand對像
                SqlDataReader dr = Com.ExecuteReader();						//建立SqlDataReader對像
                dr.Read();											//開始讀取記錄
                if (dr.HasRows)										//如果有記錄
                {
                    //繪製標題
                    g.DrawString("" + ID + "年公司內部人員統計表", font1, brush1, new PointF(160, 30));
                }
                dr.Close();											//關閉SqlDataReader對像
                //畫圖片的邊框線
                g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);
                Pen mypen = new Pen(brush, 1);							//建立畫筆
                Pen mypen2 = new Pen(Color.Red, 2);						//建立畫筆 
                int x = 60;
                for (int i = 0; i < 12; i++)
                {
                    g.DrawLine(mypen, x, 80, x, 340);						//繪製縱向線條
                    x = x + 40;
                }
                Pen mypen1 = new Pen(Color.Blue, 2);						//建立畫筆
                g.DrawLine(mypen1, x - 480, 80, x - 480, 340);				//繪製線條
                int y = 106;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawLine(mypen, 60, y, 540, y);						//繪製橫向線條
                    y = y + 26;
                }
                g.DrawLine(mypen1, 60, y, 540, y);
                //x軸
                String[] n = {"  一月", "  二月", "  三月", "  四月", "  五月", "  六月", "  七月",
                     "  八月", "  九月", "  十月", "十一月", "十二月"};	//繪製月份
                x = 35;
                for (int i = 0; i < 12; i++)
                {
                    g.DrawString(n[i].ToString(), font, Brushes.Red, x, 348);		//設定文字內容及輸出位置
                    x = x + 40;
                }
                //y軸
                String[] m = {"900人", " 800人", " 700人", "600人", " 500人", " 400人", " 300人", " 200人",
                     " 100人"};								//繪製人數
                y = 100;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawString(m[i].ToString(), font, Brushes.Red, 10, y); 		//設定文字內容及輸出位置
                    y = y + 26;
                }
                int[] Count1 = new int[12];
                int[] Count2 = new int[12];
                string[] NumChr = new string[12];
                string cmdtxt2 = "SELECT * FROM tb_curve WHERE Years=" + ID + "";	//聲明SQL語句
                SqlCommand Com1 = new SqlCommand(cmdtxt2, Con);			//建立SqlCommand對像
                SqlDataAdapter da = new SqlDataAdapter();					//建立SqlDataAdapter對像
                da.SelectCommand = Com1;
                DataSet ds = new DataSet();								//建立DataSet對像
                da.Fill(ds);											//Fill方法填充DataSet
                int j = 0;
                for (int i = 0; i < 12; i++)
                {
                    NumChr[i] = ds.Tables[0].Rows[0][i + 1].ToString();
                }
                for (j = 0; j < 12; j++)
                {
                    Count1[j] = Convert.ToInt32(NumChr[j].Split('|')[0].ToString()) * 26 / 100;
                }
                for (int k = 0; k < 12; k++)
                {
                    Count2[k] = Convert.ToInt32(NumChr[k].Split('|')[1].ToString()) * 26 / 100;
                }
                //顯示折線效果
                SolidBrush mybrush = new SolidBrush(Color.Red);					//建立SolidBrush對像
                Point[] points1 = new Point[12];
                points1[0].X = 60; points1[0].Y = 340 - Count1[0];
                points1[1].X = 100; points1[1].Y = 340 - Count1[1];
                points1[2].X = 140; points1[2].Y = 340 - Count1[2];
                points1[3].X = 180; points1[3].Y = 340 - Count1[3];
                points1[4].X = 220; points1[4].Y = 340 - Count1[4];
                points1[5].X = 260; points1[5].Y = 340 - Count1[5];
                points1[6].X = 300; points1[6].Y = 340 - Count1[6];
                points1[7].X = 340; points1[7].Y = 340 - Count1[7];
                points1[8].X = 380; points1[8].Y = 340 - Count1[8];
                points1[9].X = 420; points1[9].Y = 340 - Count1[9];
                points1[10].X = 460; points1[10].Y = 340 - Count1[10];
                points1[11].X = 500; points1[11].Y = 340 - Count1[11];
                g.DrawLines(mypen2, points1);								//繪製折線
                Pen mypen3 = new Pen(Color.Black, 2);							//建立畫筆
                Point[] points2 = new Point[12];
                points2[0].X = 60; points2[0].Y = 340 - Count2[0];
                points2[1].X = 100; points2[1].Y = 340 - Count2[1];
                points2[2].X = 140; points2[2].Y = 340 - Count2[2];
                points2[3].X = 180; points2[3].Y = 340 - Count2[3];
                points2[4].X = 220; points2[4].Y = 340 - Count2[4];
                points2[5].X = 260; points2[5].Y = 340 - Count2[5];
                points2[6].X = 300; points2[6].Y = 340 - Count2[6];
                points2[7].X = 340; points2[7].Y = 340 - Count2[7];
                points2[8].X = 380; points2[8].Y = 340 - Count2[8];
                points2[9].X = 420; points2[9].Y = 340 - Count2[9];
                points2[10].X = 460; points2[10].Y = 340 - Count2[10];
                points2[11].X = 500; points2[11].Y = 340 - Count2[11];
                g.DrawLines(mypen3, points2);								//繪製折線
                //繪製標識
                g.DrawRectangle(new Pen(Brushes.Red), 150, 370, 250, 50);			//繪製範圍框
                g.FillRectangle(Brushes.Red, 250, 380, 20, 10);					//繪製小矩形
                g.DrawString("試用員工人數", font2, Brushes.Red, 270, 380);			//繪製試用員工人數
                g.FillRectangle(Brushes.Black, 250, 400, 20, 10);					//繪製小矩形
                g.DrawString("正式員工人數", font2, Brushes.Black, 270, 400);			//繪製正式員工人數
                this.panel1.BackgroundImage = image;							//顯示繪製的圖像
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CreateImage(Convert.ToInt32(this.comboBox1.Text));
        }
    }
}