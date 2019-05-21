using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定義全局變數及對像
        string M_str_Con = "Data Source=(local);Database=db_TomeOne;Uid=sa;Pwd=123456;";//定義資料庫連接字串
        SqlConnection sqlcon;//聲明資料庫連接對像
        SqlCommand sqlcmd;//聲明執行命令對像
        SqlDataAdapter sqlda;//聲明資料橋接器對像
        DataSet myds;//聲明資料集對像
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_Condition.SelectedIndex = 0;//預設選擇條件為第一項
            dgv_Info.DataSource = SelectEInfo("", "").Tables[0];//將資料庫中的資料全部顯示在資料表格控制元件中
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            dgv_Info.DataSource = SelectEInfo(cbox_Condition.Text, txt_KeyWord.Text).Tables[0];//按條件查詢資料
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgv_Info.Rows.Count == 0)//判斷是否有資料
                return;//返回
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            excel.Application.Workbooks.Add(true);//在Excel中新增一個工作簿
            excel.Visible = true;//設定Excel顯示
            //產生欄位名稱
            for (int i = 0; i < dgv_Info.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dgv_Info.Columns[i].HeaderText;//將資料表格控制元件中的列表頭填充到Excel中
            }
            //填充資料
            for (int i = 0; i < dgv_Info.RowCount - 1; i++)//深度搜尋資料表格控制元件的所有行
            {
                for (int j = 0; j < dgv_Info.ColumnCount; j++)//深度搜尋資料表格控制元件的所有列
                {
                    if (dgv_Info[j, i].ValueType == typeof(string))//判斷深度搜尋到的資料是否是字串類型
                    {
                        excel.Cells[i + 2, j + 1] = "'" + dgv_Info[j, i].Value.ToString();//填充Excel表格
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = dgv_Info[j, i].Value.ToString();//填充Excel表格
                    }
                }
            }
        }

        #region 取得資料庫連接
        /// <summary>
        /// 取得資料庫連接
        /// </summary>
        /// <returns>返回SqlConnection對像</returns>
        private SqlConnection getCon()
        {
            sqlcon = new SqlConnection(M_str_Con);//實例化資料庫連接對像
            sqlcon.Open();//打開資料庫連接
            return sqlcon;//返回資料庫連接對像
        }
        #endregion

        #region 查詢訊息
        /// <summary>
        /// 查詢訊息
        /// </summary>
        /// <param name="str">查詢條件</param>
        /// <param name="str">查詢關鍵字</param>
        /// <returns>DataSet資料集對像</returns>
        private DataSet SelectEInfo(string P_str_Condition, string P_str_KeyWord)
        {
            sqlcon = getCon();//打開資料庫連接
            sqlda = new SqlDataAdapter();//實例化資料橋接器對像
            sqlcmd = new SqlCommand("proc_SelectEInfo", sqlcon);//呼叫存儲過程
            sqlcmd.CommandType = CommandType.StoredProcedure;//指定要執行的命令為存儲過程
            switch (P_str_Condition)//以查詢條件為條件
            {
                case "職工編號":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = P_str_KeyWord;//為存儲過程新增ID參數
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";//為存儲過程新增Name參數
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";//為存儲過程新增Sex參數
                    break;
                case "職工姓名":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = P_str_KeyWord;
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
                case "性別":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = P_str_KeyWord;
                    break;
                default:
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
            }
            sqlda.SelectCommand = sqlcmd;//指定要執行的SelectCommand命令
            myds = new DataSet();//實例化資料集對像
            sqlda.Fill(myds);//填充DataSet資料集
            sqlcon.Close();//關閉資料庫連接
            return myds;//返回資料集
        }
        #endregion
    }
}
