using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace CheckedListBoxForSelect
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public void GetScoure(string strSql)
        {
            string Connection = string.Format(//定義資料庫連接字串
                @"Provider=Microsoft.Jet.OLEDB.4.0;
Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_Connection = //建立連接資料庫物件
                new OleDbConnection(Connection);
            P_Connection.Open();//打開資料庫連接
            OleDbCommand P_Command = //建立資料庫命令物件
                new OleDbCommand(strSql, P_Connection);
            dataGridView1.Rows.Clear();//清空DataGridView中的資料
            OleDbDataReader P_DataReader = //得到資料讀取器物件
                P_Command.ExecuteReader();
            while (P_DataReader.Read())//開始讀取資料
            {
                dataGridView1.Rows.Add(P_DataReader[0].ToString(),//向DataGridView中新增資料
                    P_DataReader[1].ToString(), P_DataReader[2].ToString(),
                    P_DataReader[3].ToString(), P_DataReader[4].ToString(),
                    P_DataReader[5].ToString());
            }
            P_Connection.Close();//關閉資料庫連接
        }

        private void bntEsce_Click(object sender, EventArgs e)
        {
            ckClass.Checked = false;//取消選中控制元件
            ckName.Checked = false;//取消選中控制元件
            ckId.Checked = false;//取消選中控制元件
            rdbMan.Checked = false;//取消選中控制元件
            rdbWoMan.Checked = false;//取消選中控制元件
        }

        private void ckId_CheckedChanged(object sender, EventArgs e)
        {
            if (ckId.Checked == true)//判斷是否輸入學號訊息
            {
                txtstuId.Enabled = true;//允許輸入學號訊息
                txtstuId.Focus();//得到焦點
            }
            else
            {
                txtstuId.Text = "";//清空學號訊息
                txtstuId.Enabled = false;//不允許輸入學號訊息
            }
        }

        private void ckClass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckClass.Checked == true)//判斷是否輸入班級訊息
            {
                txtClass.Enabled = true;//允許輸入班級訊息
                txtClass.Focus();//得到焦點
            }
            else
            {
                txtClass.Text = "";//清空學號訊息
                txtClass.Enabled = false;//不允許輸入班級訊息
            }
        }

        private void ckName_CheckedChanged(object sender, EventArgs e)
        {
            if (ckName.Checked == true)//判斷是否輸入姓名訊息
            {
                txtName.Enabled = true;//允許輸入姓名訊息
                txtName.Focus();//得到焦點
            }
            else
            {
                txtName.Text = "";//清空姓名訊息
                txtName.Enabled = false;//不允許輸入姓名訊息
            }
        }
        //
        public string strSql;//用於存儲SQL語句
        public string strId;//用於存學生編號
        public string strName;//用於存儲學生姓名
        public string strClass;//用於存儲學生班級
        public string strSex;//用於存儲學生姓別
        public static int intCount = 0;//控制資料組索引
        public string[] strScoure = new string[4];//定義查詢字串陣列
        public int intAdd;//用來判斷SQL語句陣列數量
        private void bntSearch_Click(object sender, EventArgs e)
        {
            intCount = 0;
            if (txtstuId.Text != "")//判斷輸入編號是否為空
            {
                strId = "學生編號  like '%" + //定義SQL字串
                    txtstuId.Text + "%'";
                strScoure[intCount] = strId;//向字串集合新增SQL字串
                intCount++;//開始記數

            }
            if (txtName.Text != "")
            {
                strName = "學生姓名 like '%" +//定義SQL字串 
                    txtName.Text + "%' ";
                strScoure[intCount] = strName;//向字串集合新增SQL字串
                intCount++;//開始記數
            }
            if (txtClass.Text != "")
            {
                strClass = "所在年級 like '%" + //定義SQL字串
                    txtClass.Text + "%'";
                strScoure[intCount] = strClass;//向字串集合新增SQL字串
                intCount++;//開始記數
            }
            if (rdbMan.Checked == true)
            {
                strSex = "學生性別 like '%" + //定義SQL字串
                    rdbMan.Text + "%'";
                strScoure[intCount] = strSex;//向字串集合新增SQL字串
                intCount++;//開始記數
            }
            if (rdbWoMan.Checked == true)
            {
                strSex = "學生性別 like '%" + //定義SQL字串
                rdbWoMan.Text + "%'";
                strScoure[intCount] = strSex;//向字串集合新增SQL字串
                intCount++;//開始記數
            }
            for (int i = 0; i < strScoure.Length; i++)//深度搜尋字串集合
            {
                if (strScoure[i] != null)//判斷字符是否為空
                {
                    strSql += strScoure[i];//組合查詢字串
                    intAdd++;//開始記數
                }
            }
            switch (intAdd)//使用多路選擇語句組合查詢語句
            {

                case 0:
                    strSql = "select * from tb_Student";
                    break;
                case 1:
                    strSql = "select * from tb_Student where " + strScoure[0];
                    break;
                case 2:
                    strSql = "select * from tb_Student where " + strScoure[0] +
                        " and " + strScoure[1];
                    break;
                case 3:

                    strSql = "select * from tb_Student where " + strScoure[0] +
                        " and " + strScoure[1] + " and " + strScoure[2];
                    break;
                case 4:
                    strSql = "select * from tb_Student where " + strScoure[0] +
                        " and " + strScoure[1] + " and " + strScoure[2] +
                        " and " + strScoure[3];
                    break;
            }
            GetScoure(strSql);//查詢資料庫中資料
            intAdd = 0;//記數器置0
            intCount = 0;//記靈器置0
            strSql = "";//重置SQL語句
            for (int i = 0; i < strScoure.Length; i++)
            {
                if (strScoure[i] != null)
                {
                    strScoure[i] = null;//清空字串陣列內容
                }
            }
        }
    }
}