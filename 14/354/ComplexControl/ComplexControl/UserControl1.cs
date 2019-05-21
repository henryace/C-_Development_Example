using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ComplexControl
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            BindData();
        }

        public void BindData()
        {
            SqlConnection con = new SqlConnection("server=DANTE-PC;uid=sa;pwd=sa;database=db_TomeOne;");//建立資料庫連接物件 DANTE-PC 請修改為SQL SERVER 名稱
            con.Open();//打開資料庫連接
            SqlDataAdapter sda = new SqlDataAdapter("Select * From tb_Student", con);//建立橋接器物件
            DataTable dt = new DataTable();//建立DataTable物件
            try
            {
                sda.Fill(dt);//填充DataTable
            }
            catch (Exception ex)
            {
                throw ex;//拋出異常
            }
            bindingSource1.DataSource = dt;//指定BindingSource資料源
            dataGridView1.DataSource = bindingSource1;//將BindingSource指定給DataGridView
        }
    }
}
