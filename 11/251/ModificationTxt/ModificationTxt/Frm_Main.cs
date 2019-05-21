using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;//聲明與資料庫有關的命名空間

namespace ModificationTxt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        OleDbDataAdapter WidgetAdapter;//聲明一個資料讀取器
        DataSet WidgetSet;//聲明一個資料集
        OleDbConnection WidgetConnection;//聲明一個資料庫連接物件
        private string ConnectString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin";//定義一個資料庫連接字串



        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            WidgetConnection = new OleDbConnection(ConnectString);//初始化一個資料庫連接
            if (WidgetConnection.State == ConnectionState.Closed)//當資料庫連接處於關閉狀態時
            {
                WidgetConnection.Open();//打開資料庫連接
            }
            if (e.Label != null && e.Label != "")//當選定項的文字內容存在且不為空時
            {
                string RefreshString = "update tb_WidgetApply set 產品名稱='" //定義更新資料庫字串
                    + e.Label + "' where 產品編號=" +
                    (e.Item + 1).ToString();
                OleDbCommand WidgetCommand = new OleDbCommand(//聲明一個執行SQL語句的對象
                    RefreshString, WidgetConnection);
                WidgetCommand.ExecuteNonQuery();//執行SQL語句
                WidgetConnection.Close();//關閉資料庫連接
                MessageBox.Show("資料修改成功！", "提示訊息",//彈出訊息提示
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.Fill;//設定listView1與其父容器的停靠模式
            listView1.Columns.Add("產品名稱", 100, HorizontalAlignment.Left);//向listView1控制元件中新增「產品名稱」列
            listView1.Columns.Add("產品說明", 200, HorizontalAlignment.Center);//向listView1控制元件中新增「產品說明」列
            WidgetConnection = new OleDbConnection(ConnectString);//初始化一個資料庫連接
            string SelectString = "select [產品名稱],[產品說明] from [tb_WidgetApply]";//定義一個資料庫查詢字串
            WidgetAdapter = new OleDbDataAdapter(SelectString, WidgetConnection);//初始化資料讀取器物件
            WidgetSet = new DataSet();//初始化資料集
            WidgetAdapter.Fill(WidgetSet, "WidgetApply");//填充資料集
            for (int i = 0; i < WidgetSet.Tables["WidgetApply"].Rows.Count; i++)//循環深度搜尋資料集中的每一行資料
            {
                listView1.Items.Add(WidgetSet.Tables["WidgetApply"].Rows[i][0].ToString()).
                    SubItems.Add(WidgetSet.Tables["WidgetApply"].
                    Rows[i][1].ToString());//向listView1控制元件中新增資料
            }
            listView1.LabelEdit = true;//設定listView1的可編輯屬性為真
        }
    }
}
