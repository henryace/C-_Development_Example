using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BatchExcelToDatabase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openFileDialog1.Title = "選擇Excel文件";//設定打開對話框標題
            openFileDialog1.Multiselect = true;//設定打開對話框中可以多選
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)//深度搜尋所有選擇的文件
                    txt_Path.Text += openFileDialog1.FileNames[i] + ",";//在文字框中顯示Excel文件名
            }
        }

        private void rbtn_Access_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Access.Checked)//判斷Access資料庫連接設定單選按鈕選中
            {
                rbtn_Sql.Checked = false;//設定Sql Server資料庫連接設定單選按鈕取消選中
                btn_Access.Enabled = true;//將選擇Access文件按鈕設定為可用
                //將與Sql Server資料庫連接相關的文字框、複選框及按鈕設定為不可用
                txt_Server.Enabled = ckbox_Windows.Enabled = ckbox_SQL.Enabled = txt_Name.Enabled = txt_Pwd.Enabled = cbox_Server.Enabled = btn_Refresh.Enabled = false;
            }
        }

        private void rbtn_Sql_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Sql.Checked)//判斷Sql Server資料庫連接設定單選按鈕選中
            {
                rbtn_Access.Checked = false;//設定Access資料庫連接設定單選按鈕取消選中
                btn_Access.Enabled = false;//將選擇Access文件按鈕設定為不可用
                //將與Sql Server資料庫連接相關的文字框、複選框及按鈕設定為可用
                txt_Server.Enabled = ckbox_Windows.Enabled = ckbox_SQL.Enabled = cbox_Server.Enabled = btn_Refresh.Enabled = true;
                ckbox_Windows.Checked = true;//設定Windows身份驗證複選框選中
                ckbox_SQL.Checked = false;//設定Sql Server身份驗證複選框取消選中
            }
        }

        private void btn_Access_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Access文件|*.mdb";//設定打開文件篩選器
            openFileDialog1.Title = "選擇Access文件";//設定打開對話框標題
            openFileDialog1.Multiselect = false;//設定打開對話框中只能單選
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Access.Text = openFileDialog1.FileName;//在文字框中顯示Access文件名
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
                txt_Pwd.Enabled = txt_Name.Enabled = true;//設定用戶名和密碼文字框不可用
                txt_Name.Focus();//使用戶名文字框取得鼠標腳墊
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

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string[] P_str_Names = txt_Path.Text.Split(',');//存儲所有選擇的Excel文件名
            string P_str_Name = "";//存儲深度搜尋到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//實例化泛型集合對象，用來存儲工作表名稱
            for (int i = 0; i < P_str_Names.Length - 1; i++)//深度搜尋所有選擇的Excel文件名
            {
                P_str_Name = P_str_Names[i];//記錄深度搜尋到的Excel文件名
                P_list_SheetNames = GetSheetName(P_str_Name);//取得Excel文件中的所有工作表名
                for (int j = 0; j < P_list_SheetNames.Count; j++)//深度搜尋所有工作表
                {
                    if (rbtn_Access.Checked)//判斷Access資料庫連接設定單選按鈕選中
                    {
                        ImportDataToAccess(P_str_Name, P_list_SheetNames[j]);//將將工作表內容導出到Access
                    }
                    else if (rbtn_Sql.Checked)//判斷Sql Server資料庫連接設定單選按鈕選中
                    {
                        if (ckbox_Windows.Checked)//如果用Windows身份驗證登入Sql Server
                            ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Initial Catalog =" + cbox_Server.Text + ";Integrated Security=SSPI;");//將工作表內容導出到Sql Server
                        else if (ckbox_SQL.Checked)//如果用Sql Server身份驗證登入Sql Server
                            ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Database=" + cbox_Server.Text + ";Uid=" + txt_Name.Text + ";Pwd=" + txt_Pwd.Text + ";");//將工作表內容導出到Sql Server
                    }
                }
            }
            MessageBox.Show("已經將所有選擇的Excel工作表導入到了指定的資料庫中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DataTable GetTable(string P_str_Sql)//取得指定伺服器中的所有資料庫
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(P_str_Sql);//實例化資料庫連接對像
                SqlDataAdapter sqlda = new SqlDataAdapter("select name from sysdatabases ", sqlcon);//實例化資料橋接器對像
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

        private void ImportDataToAccess(string P_str_Excel, string P_str_SheetName)
        {
            object missing = System.Reflection.Missing.Value;//聲明object預設值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//聲明工作表
            Microsoft.Office.Interop.Access.Application access = new Microsoft.Office.Interop.Access.Application();//實例化Access對像
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[P_str_SheetName]);//取得選擇的工作表
            worksheet.Move(workbook.Sheets[1], missing);//將選擇的工作表作為第一個工作表
            object P_obj_Name = (object)worksheet.Name;//取得工作表名稱
            excel.DisplayAlerts = false;//設定Excel儲存時不顯示對話框
            workbook.Save();//儲存工作簿
            CloseProcess("EXCEL");//關閉所有Excel進程
            try
            {
                access.OpenCurrentDatabase(txt_Access.Text, true, "");//打開Access資料庫
                //將Excel指定工作表中的資料導入到Access中
                access.DoCmd.TransferSpreadsheet(Microsoft.Office.Interop.Access.AcDataTransferType.acImport, Microsoft.Office.Interop.Access.AcSpreadSheetType.acSpreadsheetTypeExcel97, P_obj_Name, P_str_Excel, true, missing, missing);
                access.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveAll);//關閉並儲存Access資料庫文件
                CloseProcess("MSACCESS");//關閉所有Access資料庫進程
            }
            catch
            {
                MessageBox.Show("Access資料庫中已經存在" + P_str_SheetName + "表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CloseProcess("MSACCESS");//關閉所有Access資料庫進程
            }
        }

        private void ImportDataToSql(string P_str_Excel, string P_str_SheetName, string P_str_SqlCon)//將工作表內容導出到Sql Server
        {
            DataSet myds = new DataSet();//實例化資料集對像
            try
            {
                CloseProcess("EXCEL");//關閉所有Excel進程
                //取得全部資料    
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
            catch
            {
                MessageBox.Show("Sql Server資料庫中已經存在" + P_str_SheetName + "表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CloseProcess(string P_str_Process)//關閉進程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
        }
    }
}
