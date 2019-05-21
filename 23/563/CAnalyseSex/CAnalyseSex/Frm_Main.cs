using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
namespace CAnalyseSex
{
    public partial class Frm_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Conn()
        {
            con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne");
            con.Open();
        }


        private void ShowPic(string SexCode, float f)
        {
            Graphics g = this.panel1.CreateGraphics();					//透過panel1控制元件建立一個Graphics對像
            Pen p = new Pen(new SolidBrush(Color.Blue));					//建立畫筆
            Point p1 = new Point(0, 0);								//建立Point對像
            Size s = new Size(this.panel1.Width, this.panel1.Height);			//建立Size對像
            Rectangle trct = new Rectangle(p1, s);						//建立Rectangle對像
            g.FillEllipse(new SolidBrush(Color.Red), trct);					//繪製橢圓
            g.FillPie(new SolidBrush(Color.Blue), trct, 180, f * 360);			//繪製扇形
            Graphics ginfo = this.panel2.CreateGraphics();					//透過panel2控制元件建立一個Graphics對像
            Font font = new Font("細明體", 10, FontStyle.Regular);			//設定字體
            //繪製性別
            ginfo.DrawString(SexCode + " " + f.ToString().Substring(0, 4), font, new SolidBrush(Color.Blue), 0, 5);
            ginfo.DrawString("女" + " " + (1.0 - Convert.ToDouble(f.ToString().Substring(0, 4))).ToString().Substring(0, 4), font, new SolidBrush(Color.Red), 0, 25);										//繪製比例
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Conn();
            using (cmd = new SqlCommand("SELECT sex,COUNT(sex) num FROM tb_sex group by sex", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                string[] str = new string[2];
                int i = 0;
                while (dr.Read())
                {
                    str[i] = dr[0].ToString() + "," + dr[1].ToString();
                    i++;
                }
                float N = Convert.ToInt16(str[0].Substring(2)) + Convert.ToInt16(str[1].Substring(2));
                float f = Convert.ToInt16(str[0].Substring(2)) / N;
                ShowPic(str[0].Substring(0, 1), f);
            }
        }
    }
}