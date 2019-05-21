using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SortOrStatistics
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getScoure("select * from [tb_ware]");
        }
        public void getScoure(string strName)
        {
            try
            {
                string P_Connection = string.Format(//建立資料庫連接字串
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
                OleDbConnection P_OLEDBConnection = //建立連接物件
                    new OleDbConnection(P_Connection);
                P_OLEDBConnection.Open();//連接到資料庫
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令物件
                    strName,
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到資料讀取器
                    P_OLEDBCommand.ExecuteReader();
                listView1.View = View.Details;//設定控制元件顯示方式
                listView1.GridLines = true;//顯示網絡線
                listView1.FullRowSelect = true;//被選中時是否連帶選中子項
                listView1.Items.Clear();//清空元素
                while (P_Reader.Read())//讀取資料
                {
                    ListViewItem lv = //建立項
                        new ListViewItem(P_Reader[0].ToString());
                    lv.SubItems.Add(P_Reader[1].ToString());//建立項
                    lv.SubItems.Add(P_Reader[2].ToString());//建立項
                    listView1.Items.Add(lv);//向ListView控制元件中新增項
                }
                P_OLEDBConnection.Close();//關閉連接
            }
            catch (Exception ex)
            {
                MessageBox.Show(//彈出消息對話框
                    "資料讀取失敗！\r\n" + ex.Message, "錯誤！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getScoure(//呼叫方法重新向控制元件新增資料
                "select * from [tb_ware]  order by [銷售數量] asc");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getScoure(//呼叫方法重新向控制元件新增資料
                "select * from [tb_ware] order by [銷售數量] Desc");
        }
    }
}