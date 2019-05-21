using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AddToListBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string P_Connection = string.Format(//建立資料庫連接字串
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
                OleDbConnection P_OLEDBConnection = //建立連接物件
                    new OleDbConnection(P_Connection);
                P_OLEDBConnection.Open();//連接到資料庫
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令物件
                    "select * from [message]",
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到資料讀取器
                    P_OLEDBCommand.ExecuteReader();
                while (P_Reader.Read())//讀取資料
                {
                    lb_Str.Items.Add(P_Reader[0]);//將資料放入集合
                }
                MessageBox.Show("成功讀取資料！", "提示！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料讀取失敗！\r\n" + ex.Message, "錯誤！");
            }
        }
    }
}
