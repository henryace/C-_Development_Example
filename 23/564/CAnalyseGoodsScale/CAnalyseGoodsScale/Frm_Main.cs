using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;
namespace CAnalyseGoodsScale
{
    public partial class Frm_Main : Form
    {
        static int SumNum;
        static float TimeNum;
        SqlConnection con;
        SqlCommand cmd;
        Hashtable ht = new Hashtable();
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }

        private void showPic(float f, Brush B)
        {
            Graphics g = this.panel1.CreateGraphics();					//透過panel1控制元件建立一個Graphics對像
            if (TimeNum == 0.0f)
            {
                g.FillPie(B, 0, 0, this.panel1.Width, this.panel1.Height, 0, f * 360);//繪製扇形
            }
            else
            {
                g.FillPie(B, 0, 0, this.panel1.Width, this.panel1.Height, TimeNum, f * 360);
            }
            TimeNum += f * 360;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)			//在Paint事件中繪製視窗
        {
            ht.Clear();
            Conn();											//連接資料庫
            Random rnd = new Random();								//產生隨機數
            using (cmd = new SqlCommand("select t_Name,sum(t_Num) as Num  from tb_product group by t_Name", con))
            {
                Graphics g2 = this.panel2.CreateGraphics();				//透過panel2控制元件建立一個Graphics對像
                SqlDataReader dr = cmd.ExecuteReader();					//建立SqlDataReader對像
                while (dr.Read())									//讀取資料
                {
                    ht.Add(dr[0], Convert.ToInt32(dr[1]));					//將資料新增到Hashtable中
                }
                float[] flo = new float[ht.Count];
                int T = 0;
                foreach (DictionaryEntry de in ht)						//深度搜尋Hashtable
                {
                    flo[T] = Convert.ToSingle((Convert.ToDouble(de.Value) / SumNum).ToString().Substring(0, 6));
                    Brush Bru = new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    //繪製商品及百分比
                    g2.DrawString(de.Key + "  " + flo[T] * 100 + "%", new Font("Arial", 8, FontStyle.Regular), Bru, 7, 5 + T * 18);
                    showPic(flo[T], Bru);							//呼叫showPic方法繪製餅型圖
                    T++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conn();
            using (cmd = new SqlCommand("select Sum(t_Num)  from tb_product", con))
            {
                SumNum = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}