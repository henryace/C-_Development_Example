using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace ColumnByControl
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("server=(local);uid=sa;pwd=123456;database=db_TomeOne"))	//實例化一個SqlConnection對像
            {
                int XValse = 20;
                DataSet ds = new DataSet();									//建立DataSet對像
                //建立SqlCommand對像
                SqlCommand cmd = new SqlCommand("select * from tb_Rectangle select Sum(t_Num) from tb_Rectangle", con);
                SqlDataAdapter da = new SqlDataAdapter();						//建立SqlDataAdapter對像
                da.SelectCommand = cmd;
                da.Fill(ds);												//Fill方法填充DataSet
                Panel[] p = new Panel[ds.Tables[0].Rows.Count];					//實例化一個Panel陣列
                int Values = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());			//商品總數
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i][0].ToString();
                    float f = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());		//取得每個商品的數量
                    Size s = new Size();										//建立Size對像
                    s.Width = 30;											//設定柱形圖寬度
                    s.Height = Convert.ToInt32(f / Values * 200);					//計算柱形圖高度
                    Point pint = new Point();									//建立Point對像
                    pint.X = XValse;										//x坐標
                    pint.Y = this.Height - 50 - s.Height;							//y坐標
                    p[i] = new Panel();										//實例化一個Panel對像
                    p[i].Location = pint;										//設定位置
                    p[i].BackColor = Color.Red;								//設定背景顏色
                    p[i].Size = s;											//設定大小
                    XValse += 40;											//設定Xvalse變數的值
                    Label lbl = new Label();									//建立Label對像
                    lbl.Text = ds.Tables[0].Rows[i][0].ToString();					//設定Label顯示的文字
                    lbl.Font = new Font("細明體", 9, FontStyle.Regular);				//設定Label的Font屬性
                    lbl.ForeColor = Color.White;								//設定Label的ForeColor屬性
                    p[i].Controls.Add(lbl);									//新增控制元件
                    this.Controls.Add(p[i]);									//將控制元件陣列新增到目前容器中
                }
            }
        }
    }
}