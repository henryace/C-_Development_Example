using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace InsertToListView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string P_Connection = string.Format(//建立資料庫連接字串
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
                OleDbConnection P_OLEDBConnection = //建立連接物件
                    new OleDbConnection(P_Connection);
                P_OLEDBConnection.Open();//連接到資料庫
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令物件
                    "select * from [book]",
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到資料讀取器
                    P_OLEDBCommand.ExecuteReader();
                while (P_Reader.Read())//讀取資料
                {
                    ListViewItem lv = new ListViewItem(P_Reader[0].ToString());
                    lv.SubItems.Add(P_Reader[1].ToString());
                    lv.SubItems.Add(P_Reader[2].ToString());
                    listView1.Items.Add(lv);
                }
                P_OLEDBConnection.Close();//關閉資料庫連接
            }
            catch (Exception ex)
            {
                MessageBox.Show(//彈出消息對話框
                    "資料讀取失敗！\r\n" + ex.Message, "錯誤！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();//清空資料
        }
    }
}