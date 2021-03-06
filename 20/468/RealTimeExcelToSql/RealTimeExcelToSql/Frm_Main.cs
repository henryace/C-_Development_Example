﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace RealTimeExcelToSql
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        #region 為INI文件中指定的節點取得字串
        /// <summary>
        /// 為INI文件中指定的節點取得字串
        /// </summary>
        /// <param name="lpAppName">欲在其中搜尋關鍵字的節點名稱</param>
        /// <param name="lpKeyName">欲取得的項名</param>
        /// <param name="lpDefault">指定的項沒有找到時返回的預設值</param>
        /// <param name="lpReturnedString">指定一個字串緩衝區，長度至少為nSize</param>
        /// <param name="nSize">指定裝載到lpReturnedString緩衝區的最大字符數量</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>複製到lpReturnedString緩衝區的字節數量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        #endregion

        #region 修改INI文件中內容
        /// <summary>
        /// 修改INI文件中內容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中寫入的節點名稱</param>
        /// <param name="lpKeyName">欲設定的項名</param>
        /// <param name="lpString">要寫入的新字串</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>非零表示成功，零表示失敗</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        #endregion

        #region 從INI文件中讀取指定節點的內容
        /// <summary>
        /// 從INI文件中讀取指定節點的內容
        /// </summary>
        /// <param name="section">INI節點</param>
        /// <param name="key">節點下的項</param>
        /// <param name="def">沒有找到內容時返回的預設值</param>
        /// <param name="def">要讀取的INI文件</param>
        /// <returns>讀取的節點內容</returns>
        public string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        #endregion

        string M_str_Name = Application.StartupPath + "\\Set.ini";//定義要讀取的INI文件

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            txt_Path.Text = ReadString("Set", "Excel", "", M_str_Name);//讀取預設的Excel文件
            txt_Server.Text = ReadString("Set", "Server", "", M_str_Name);//讀取SQL伺服器
            if (ReadString("Set", "Login", "", M_str_Name) == "0")//判斷SQL登入模式的值是否為0
            {
                ckbox_Windows.Checked = true;//設定Windows身份驗證複選框選中
                ckbox_SQL.Checked = false;//讀取SQL伺服器
                txt_Name.Text = txt_Pwd.Text = "";//清空用戶名和文字框中的文字
            }
            else if (ReadString("Set", "Login", "", M_str_Name) == "1")//判斷SQL登入模式的值是否為1
            {
                ckbox_Windows.Checked = false;//設定Windows身份驗證複選框取消選中
                ckbox_SQL.Checked = true;//設定Sql Server身份驗證複選框選中
                txt_Name.Text = ReadString("Set", "Uid", "", M_str_Name);//讀取SQL登入名
                txt_Pwd.Text = ReadString("Set", "Pwd", "", M_str_Name);//讀取SQL登入密碼
            }
            cbox_Server.Text = ReadString("Set", "Database", "", M_str_Name);//讀取資料庫名
            if (ReadString("Set", "Auto", "", M_str_Name) == "0")//判斷是否自動執行的值是否為0
            {
                ckbox_Auto.Checked = true;//設定是否自動執行複選框選中
                timer1.Enabled = true;//設定計時器可用
            }
            else if (ReadString("Set", "Auto", "", M_str_Name) == "1")//判斷是否自動執行的值是否為1
            {
                ckbox_Auto.Checked = false;//設定是否自動執行複選框取消選中
                timer1.Enabled = false;//設定計時器不可用
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openFileDialog1.Title = "選擇Excel文件";//設定打開對話框標題
            openFileDialog1.Multiselect = false;//設定打開對話框中可以多選
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文字框中顯示Excel文件名
            }
        }

        private void ckbox_Winfows_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbox_Windows.Checked)//如果Windows身份驗證複選框選中
            {
                ckbox_SQL.Checked = false;//設定SQL Server身份驗證複選框取消選中
                txt_Pwd.Enabled = txt_Name.Enabled = false;//設定用戶名和密碼文字框不可用
                //定義SQL語句
                string P_str_Con = "Data Source=" + txt_Server.Text + ";Database=master;Integrated Security=SSPI;";
                cbox_Server.DataSource = GetTable(P_str_Con);//為下拉列表指定資料源
                cbox_Server.DisplayMember = "name";//設定下拉列表中顯示的欄位名稱
                cbox_Server.ValueMember = "name";//設定下拉列表中顯示的值名稱
                if (cbox_Server.Items.Count > 0)//如果下拉列表中有項
                    cbox_Server.SelectedIndex = 0;//設定預設選擇第一項
            }
        }

        private void ckbox_SQL_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbox_SQL.Checked)//如果Windows身份驗證複選框選中
            {
                ckbox_Windows.Checked = false;//設定Windows身份驗證複選框取消選中
                txt_Pwd.Enabled = txt_Name.Enabled = true;//設定用戶名和密碼文字框可用
                txt_Name.Focus();//使用戶名文字框取得鼠標焦點
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //定義SQL語句
            string P_str_Con = "Data Source=" + txt_Server.Text + ";Database=master;Uid=" + txt_Name.Text + ";Pwd=" + txt_Pwd.Text + ";";
            cbox_Server.DataSource = GetTable(P_str_Con);//為下拉列表指定資料源
            cbox_Server.DisplayMember = "name";//設定下拉列表中顯示的欄位名稱
            cbox_Server.ValueMember = "name";//設定下拉列表中顯示的值名稱
            if (cbox_Server.Items.Count > 0)//如果下拉列表中有項
                cbox_Server.SelectedIndex = 0;//設定預設選擇第一項
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Set", "Excel", txt_Path.Text, M_str_Name);//設定Excel文件路徑
            WritePrivateProfileString("Set", "Server", txt_Server.Text, M_str_Name);//設定SQL伺服器名
            if (ckbox_Windows.Checked)//判斷Windows身份驗證複選框是否選中
            {
                WritePrivateProfileString("Set", "Login", "0", M_str_Name);//設定SQL登入模式的值為0
                WritePrivateProfileString("Set", "Uid", "", M_str_Name);//設定SQL登入用戶名為空
                WritePrivateProfileString("Set", "Pwd", "", M_str_Name);//設定SQL登入密碼為空
            }
            else if (ckbox_SQL.Checked)//判斷Sql Server身份驗證複選框是否選中
            {
                WritePrivateProfileString("Set", "Login", "1", M_str_Name);//設定SQL登入模式的值為1
                WritePrivateProfileString("Set", "Uid", txt_Name.Text, M_str_Name);//設定SQL登入用戶名
                WritePrivateProfileString("Set", "Pwd", txt_Pwd.Text, M_str_Name);//設定SQL登入密碼
            }
            WritePrivateProfileString("Set", "Database", cbox_Server.Text, M_str_Name);//設定資料庫名
            if (ckbox_Auto.Checked)//判斷是否自動執行複選框是否選中
            {
                WritePrivateProfileString("Set", "Auto", "0", M_str_Name);//設定自動執行
            }
            else
            {
                WritePrivateProfileString("Set", "Auto", "1", M_str_Name);//設定不自動執行
            }
            MessageBox.Show("設定文件設定成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();//啟動計時器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string P_str_Name = "";//存儲深度搜尋到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//實例化泛型集合對象，用來存儲工作表名稱
            P_str_Name = txt_Path.Text;//記錄深度搜尋到的Excel文件名
            P_list_SheetNames = GetSheetName(P_str_Name);//取得Excel文件中的所有工作表名
            for (int j = 0; j < P_list_SheetNames.Count; j++)//深度搜尋所有工作表
            {
                if (ckbox_Windows.Checked)//如果用Windows身份驗證登入Sql Server
                    ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Initial Catalog =" + cbox_Server.Text + ";Integrated Security=SSPI;");//將工作表內容導出到Sql Server
                else if (ckbox_SQL.Checked)//如果用Sql Server身份驗證登入Sql Server
                    ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Database=" + cbox_Server.Text + ";Uid=" + txt_Name.Text + ";Pwd=" + txt_Pwd.Text + ";");//將工作表內容導出到Sql Server
            }
            System.Threading.Thread.Sleep(60000);//使線程休眠1分鐘
        }

        private DataTable GetTable(string P_str_Sql)//取得指定伺服器中的所有資料庫
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(P_str_Sql);//實例化資料庫連接對像
                SqlDataAdapter sqlda = new SqlDataAdapter("select name from sysdatabases", sqlcon);//實例化資料橋接器對像
                DataTable DTable = new DataTable("sysdatabases");//實例化DataTable對像
                sqlda.Fill(DTable);//填充DataTable資料表
                return DTable;//返回DataTable資料表
            }
            catch
            {
                return null;//返回null
            }
        }

        private List<string> GetSheetName(string P_str_Excel)//取得所有工作表名稱
        {
            List<string> P_list_SheetName = new List<string>();//實例化泛型集合對像
            CloseProcess("EXCEL");//關閉所有Excel進程
            //連接Excel資料庫
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0");
            olecon.Open();//打開資料庫連接
            System.Data.DataTable DTable = olecon.GetSchema("Tables");//實例化表對像
            DataTableReader DTReader = new DataTableReader(DTable);//實例化表讀取對像
            while (DTReader.Read())//循環讀取
            {
                string P_str_Name = DTReader["Table_Name"].ToString().Replace('$', ' ').Trim();//記錄工作表名稱
                if (!P_list_SheetName.Contains(P_str_Name))//判斷泛型集合中是否已經存在該工作表名稱
                    P_list_SheetName.Add(P_str_Name);//將工作表名新增到泛型集合中
            }
            DTable = null;//清空表對像
            DTReader = null;//清空表讀取對像
            olecon.Close();//關閉資料庫連接
            return P_list_SheetName;//返回得到的泛型集合
        }

        public void ImportDataToSql(string P_str_Excel, string P_str_SheetName, string P_str_SqlCon)//將工作表內容導出到Sql Server
        {
            DataSet myds = new DataSet();//實例化資料集對像
            CloseProcess("EXCEL");//關閉所有Excel進程
            //定義連接Excel的字串   
            string P_str_OledbCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0;";
            OleDbConnection oledbcon = new OleDbConnection(P_str_OledbCon);//實例化Oledb資料庫連接對像
            string P_str_ExcelSql = "";//定義變數，用來記錄要執行的Excel查詢語句
            OleDbDataAdapter oledbda = null;//實例化Oledb資料橋接器對像
            P_str_ExcelSql = string.Format("select * from [{0}$]", P_str_SheetName);//記錄要執行的Excel查詢語句
            oledbda = new OleDbDataAdapter(P_str_ExcelSql, P_str_OledbCon);//使用資料橋接器執行Excel查詢
            oledbda.Fill(myds, P_str_SheetName);//填充資料
            string P_str_CreateSql = string.Format("use " + cbox_Server.Text + " if object_Id('" + P_str_SheetName + "') is not null drop table " + P_str_SheetName + " create table {0}(", P_str_SheetName);//定義變數，用來記錄建立表的SQL語句
            foreach (DataColumn c in myds.Tables[0].Columns)//深度搜尋資料集中的所有行
            {
                P_str_CreateSql += string.Format("[{0}] text,", c.ColumnName);//在表中建立欄位
            }
            P_str_CreateSql = P_str_CreateSql + ")";//完善建立表的SQL語句
            using (SqlConnection sqlcon = new SqlConnection(P_str_SqlCon))//實例化SQL資料庫連接對像
            {
                sqlcon.Open();//打開資料庫連接
                SqlCommand sqlcmd = sqlcon.CreateCommand();//實例化SqlCommand執行命令對像
                sqlcmd.CommandText = P_str_CreateSql;//指定要執行的SQL語句
                sqlcmd.ExecuteNonQuery();//執行操作
                sqlcon.Close();//關閉資料連接
            }
            using (SqlBulkCopy bcp = new SqlBulkCopy(P_str_SqlCon))//用bcp導入資料 
            {
                bcp.BatchSize = 100;//每次傳輸的行數    
                bcp.DestinationTableName = P_str_SheetName;//定義目標表    
                bcp.WriteToServer(myds.Tables[0]);//將資料寫入Sql Server資料表
            }
        }

        private void CloseProcess(string P_str_Process)//關閉進程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
            System.Threading.Thread.Sleep(10);//使線程休眠10毫秒
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();//停止計時器
        }
    }
}
