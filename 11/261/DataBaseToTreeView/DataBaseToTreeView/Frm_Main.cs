using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace DataBaseToTreeView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.ShowLines = true;//設定繪製連線
            treeView1.ImageList = imageList1;//設定ImageList屬性
            string P_Connection = string.Format(//建立資料庫連接字串
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //建立連接物件
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//連接到資料庫
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令物件
                "select * from [Ware]",
                P_OLEDBConnection);
            OleDbDataReader P_Reader = //得到資料讀取器
                P_OLEDBCommand.ExecuteReader();
            TreeNode newNode1 = treeView1.Nodes.Add("A", "商品訊息", 1, 2);//一級節點
            while (P_Reader.Read())
            {
                TreeNode newNode12 = new TreeNode(//二級節點
                    "商品編號" + P_Reader[1].ToString(), 3, 4);
                newNode12.Nodes.Add("A", "商品名稱：" + P_Reader[0].ToString(), 5, 6);
                newNode12.Nodes.Add("A", "商品數量：" + P_Reader[3].ToString(), 7, 8);
                newNode12.Nodes.Add("A", "商品價格：" + P_Reader[2].ToString(), 9, 10);
                newNode1.Nodes.Add(newNode12);//新增節點

            }
            P_OLEDBConnection.Close();//關閉資料庫連接
            treeView1.ExpandAll();//展開所有節點
        }
    }
}