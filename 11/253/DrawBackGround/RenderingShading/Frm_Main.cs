using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace DrawBackGround
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                listView1.BackgroundImageTiled = true;//設定填滿背景圖像
                listView1.View = View.LargeIcon;//設定控制元件的顯示方式
                listView1.LargeImageList = imageList1;
                while (P_Reader.Read())//讀取資料
                {
                    ListViewItem lv = //建立項
                        new ListViewItem(P_Reader[0].ToString(), 0);
                    listView1.Items.Add(lv);//向控制元件中新增項
                }
                P_OLEDBConnection.Close();//關閉資料庫連接
            }
            catch (Exception ex)
            {
                MessageBox.Show(//彈出消息對話框
                    "資料讀取失敗！\r\n" + ex.Message, "錯誤！");
            }
        }
    }
}