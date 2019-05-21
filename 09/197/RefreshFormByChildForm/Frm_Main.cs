using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RefreshFormByChildForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 本實例應該設定主視窗的IsMdiContainer屬性為true、MainMenuStrip屬性為所新增的功能表欄、WindowState屬性為Maximized、視窗名稱為FrmMain、設定AllowUserToAddRows屬性為false
        /// </summary>

        #region 宣告的變數
        public static bool flag = false;//標識是否建立新的子視窗
        Frm_Child BabyWindow = new Frm_Child();//實例化一個子視窗
        DataSet PubsSet = new DataSet(); //定義一個資料集物件
        public static string[] IDArray; //宣告一個一維字串陣列
        public DataTable IDTable;       //宣告一個資料表物件
        SqlDataAdapter IDAdapter;        //宣告一個資料讀取器物件
        SqlDataAdapter PubsAdapter;       //宣告一個資料讀取器物件
        SqlConnection ConnPubs;           //宣告一個資料庫連接物件
        SqlCommand PersonalInformation;    //宣告一個執行SQL語句的對象
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string ConnString = "Data Source=WRET-MOSY688YVW\\MRGLL;DataBase=db_TomeOne;UID=sa;Pwd=;";//資料庫連接字串
            string AdapterString = "select userID as 編號,userName as 姓名 ,phone as 電話,address as 住址 from tb_User";//用於查詢的字串
            string IDString = "select userID from tb_User";//讀取資料庫中用戶的ID編號字串
            ConnPubs = new SqlConnection(ConnString);//建立資料庫連接
            PubsAdapter = new SqlDataAdapter(AdapterString, ConnPubs);//建立PubsAdapter資料讀取器
            IDAdapter = new SqlDataAdapter(IDString, ConnPubs);//用於讀取用戶編號的讀取器
            PubsAdapter.Fill(PubsSet, "tb_User");//填充PubsSet資料集
            IDAdapter.Fill(PubsSet, "ID");//填充PubsSet資料集
            DataTable PubsTable = PubsSet.Tables["tb_User"];//將資料寫入PubsTable表
            IDTable = PubsSet.Tables["ID"];//將資料寫入ID表
            IDArray = new string[IDTable.Rows.Count];//為陣列定義最大長度
            dataGridView1.DataSource = PubsTable.DefaultView;//設定dataGridView1的資料源
            for (int i = 0; i < IDTable.Rows.Count; i++)   //循環深度搜尋資料表中的每一行資料
            {
                for (int j = 0; j < IDTable.Columns.Count; j++)//循環深度搜尋資料表中的每一列資料
                {
                    IDArray[i] = IDTable.Rows[i][j].ToString(); //將資料表中的資料新增至一個一維陣列
                }
            }
        }

        #region 增加單一的FrmChild視窗
        private void AddandDelete_Click(object sender, EventArgs e)
        {
            if (flag == false)//判斷標識的值決定是否建立視窗
            {
                CreateFrmChild();//建立子視窗
            }
            for (int i = 0; i < this.dataGridView1.Controls.Count; i++)//循環深度搜尋DataGridView控制元件上的控制元件集
            {
                if (this.dataGridView1.Controls[i].Name.Equals(BabyWindow.Name))//當存在子視窗時
                {
                    flag = true;//改變標識Flag的值
                    break;//退出循環體
                }
            }
        }
        #endregion

        private void ExitProject_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出本程式
        }

        #region 建立子視窗的CreateFrmChild方法
        public void CreateFrmChild()
        {
            Frm_Child BabyWindow = new Frm_Child();//實例化一個子視窗
            BabyWindow.MdiParent = this;//設定子視窗的父視窗為目前視窗
            this.dataGridView1.Controls.Add(BabyWindow);//在DataGridView控制元件中新增子視窗
            BabyWindow.UpdateDataGridView += new EventHandler(BabyWindow_UpdateDataGridView);
            BabyWindow.Show();//顯示子視窗
        }

        void BabyWindow_UpdateDataGridView(object sender, EventArgs e)
        {
            if (Frm_Child.GlobalFlag == false)    //當單擊刪除按鈕時
            {
                if (ConnPubs.State == ConnectionState.Closed) //當資料庫處於斷開狀態時
                {
                    ConnPubs.Open();                //打開資料庫的連接
                }
                string AfreshString = "delete tb_User where userID=" + Frm_Child.DeleteID.Trim();//定義一個刪除資料的字串
                PersonalInformation = new SqlCommand(AfreshString, ConnPubs); //執行刪除資料庫欄位
                PersonalInformation.ExecuteNonQuery(); //執行SQL語句並返回受影響的行數
                ConnPubs.Close();                     //關閉資料庫
                DisplayData();                          //顯示資料庫更新後的內容
                MessageBox.Show("資料刪除成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出刪除資料成功的提示
            }
            else
            {
                if (ConnPubs.State == ConnectionState.Closed) //當資料庫處於關閉狀態時
                {
                    ConnPubs.Open();                        //打開資料庫
                }
                string InsertString = "insert into tb_User values('" + Frm_Child.idContent + "','" + Frm_Child.nameContent + "','" + Frm_Child.phoneContent + "','" + Frm_Child.addressContent + "')";//定義一個插入資料的字串變數
                PersonalInformation = new SqlCommand(InsertString, ConnPubs);//執行插入資料庫欄位
                PersonalInformation.ExecuteNonQuery();//執行SQL語句並返回受影響的行數
                ConnPubs.Close();                    //關閉資料庫
                DisplayData();                         //顯示更新後的資料
                MessageBox.Show("資料新增成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出新增成功的提示訊息
            }
        }
        #endregion

        #region 用於讀取資料庫的DisplayData方法
        public void DisplayData()
        {
            PubsSet.Clear();
            string ConnString = "Data Source=WRET-MOSY688YVW\\MRGLL;DataBase=db_TomeOne;UID=sa;Pwd=;";//資料庫連接字串
            ConnPubs = new SqlConnection(ConnString);//建立資料庫連接
            string DisplayString = "select userId as 編號,userName as 姓名 ,phone as 電話,address as 住址 from tb_User";//定義讀取資料庫的欄位
            SqlDataAdapter PersonalAdapter = new SqlDataAdapter(DisplayString, ConnPubs); //定義一個讀取資料庫資料的讀取器
            PersonalAdapter.Fill(PubsSet, "tb_User"); //向表DisplayTable中填充資料
            dataGridView1.DataSource = PubsSet.Tables["tb_User"].DefaultView;//設定DataGridView控制元件的資料源
        }
        #endregion
    }
}
