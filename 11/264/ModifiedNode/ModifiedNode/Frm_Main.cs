using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;//聲明與資料庫操作有關的命名空間

namespace ModifiedNode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        OleDbCommand NexusCommand;//聲明一個執行SQL語句的對象
        OleDbConnection NexusConnection;//聲明一個資料庫連接物件
        private static string ConnectString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin";//定義一個資料庫連接字串

        private void ModifiedNode_Load(object sender, EventArgs e)
        {
            treeView1.LabelEdit = true;//設定treeView1的可編輯屬性為true
            NexusConnection = new OleDbConnection(ConnectString);//初始化一個資料庫連接物件
            NexusConnection.Open();//打開資料庫連接
            string SelectString = "select 產品編號,產品名稱 from Ware";//定義一個資料庫查詢字串
            NexusCommand = new OleDbCommand(SelectString, NexusConnection);//初始化執行SQL語句物件
            OleDbDataReader NexusReader = NexusCommand.ExecuteReader();//定義一個資料讀取器
            treeView1.Nodes.Clear();//清空treeView1原有的資料內容
            TreeNode root = treeView1.Nodes.Add("產品名稱");//為treeView1控制元件新增根節點
            while (NexusReader.Read())//開始讀取資料中的內容
            {
                TreeNode tempNode = //將資料庫中的資料欄位變換為treeView控制元件的節點
                    new TreeNode(NexusReader[1].ToString());
                root.Nodes.Add(tempNode);//向根節點上新增資料庫欄位
            }
            NexusReader.Close();//關閉資料讀取器
            root.ExpandAll();//展開treeView1中的所有節點
            NexusConnection.Close();//關閉資料庫連接
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null && e.Label != "")//當選定項的內容存在且不為空時
            {
                NexusConnection.Open();//打開資料庫連接
                string RefreshString = "update Ware set 產品名稱='" + //定義一個資料庫連接欄位
                    e.Label + "' where 產品編號=" + (e.Node.Index + 1).ToString();
                NexusCommand = new OleDbCommand(RefreshString, NexusConnection);//定義一個執行SQL語句的對象
                NexusCommand.ExecuteNonQuery();//執行SQL語句
                NexusConnection.Close();//關閉資料庫連接
                MessageBox.Show("修改成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出修改成功的提示訊息
            }
        }
    }
}
