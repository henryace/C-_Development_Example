using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace DisDataToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_SelectTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTxt = new OpenFileDialog();//實例化打開對話框對像
            openTxt.Filter = "文字文件|*.txt";//設定打開文件篩選器
            openTxt.Multiselect = false;//設定打開對話框中不能多選
            if (openTxt.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Txt.Text = openTxt.FileName;//顯示選擇的文字文件
            }
        }

        private void btn_SelectWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog openWord = new OpenFileDialog();//實例化打開對話框對像
            openWord.Filter = "Word文件|*.doc;*.docx";//設定打開文件篩選器
            openWord.Multiselect = true;//設定打開對話框中可以多選
            if (openWord.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Word.Text = openWord.FileName;//顯示選擇的Word文件
            }
        }

        private void btn_SelectAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog openAccess = new OpenFileDialog();//實例化打開對話框對像
            openAccess.Filter = "Access資料庫文件|*.mdb";//設定打開文件篩選器
            openAccess.Multiselect = false;//設定打開對話框中不能多選
            if (openAccess.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Access.Text = openAccess.FileName;//顯示選擇的Access文件
            }
        }

        private void btn_SelectExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();//實例化打開對話框對像
            openExcel.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openExcel.Multiselect = false;//設定打開對話框中不能多選
            if (openExcel.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Excel.Text = openExcel.FileName;//顯示選擇的Excel文件
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            timer1.Start();//開始計時器
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();//停止計時器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_Excel.Text != "")//判斷是否選擇了Excel文件
            {
                if (txt_Txt.Text != "")//判斷是否選擇了文字文件
                    TxtToExcel(txt_Txt.Text, txt_Excel.Text);//將文字文件資料導入Excel
                if (txt_Word.Text != "")//判斷是否選擇了Word文件
                    WordToExcel(txt_Word.Text, txt_Excel.Text);//將Word文件資料導入Excel
                if (txt_Access.Text != "")//判斷是否選擇了Access文件
                {
                    List<string> P_list_Tables = GetTable(txt_Access.Text);//取得Access中的所有表
                    for (int i = 0; i < P_list_Tables.Count; i++)//深度搜尋所有表
                    {
                        AccessToExcel(txt_Access.Text, P_list_Tables[i], txt_Excel.Text);//將表中的資料導入Excel
                    }
                }
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打開選擇的Excel文件
        }

        private void TxtToExcel(string P_str_Txt, string P_str_Excel)
        {
            int P_int_Count = 0;//記錄正在讀取的行數
            string P_str_Line;//記錄讀取行的內容
            List<string> P_str_List = new List<string>();//存儲讀取的所有內容
            StreamReader SReader = new StreamReader(P_str_Txt, Encoding.Default);//實例化流讀取對像
            while ((P_str_Line = SReader.ReadLine()) != null)//循環讀取文字文件中的每一行
            {
                P_str_List.Add(P_str_Line);//將讀取到的行內容新增到泛型集合中
                P_int_Count++;//使目前讀取行數加1
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            for (int i = 0; i < P_str_List.Count; i++)//深度搜尋泛型集合
            {
                newWorksheet.Cells[i + 1, 1] = P_str_List[i];//直接將深度搜尋到的內容新增到工作表中
            }
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
        }

        private void WordToExcel(string P_str_Word, string P_str_Excel)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();//實例化Word對像
            Microsoft.Office.Interop.Word.Table table;//聲明Word表格對像
            int P_int_TableCount = 0, P_int_Row = 0, P_int_Column = 0;//定義3個變數，分別用來存儲表格數量、表格中的行數、列數
            string P_str_Content;//存儲Word表格的儲存格內容
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            object P_obj_Name;//存儲深度搜尋到的Word文件名
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//建立新工作表
            P_obj_Name = (object)P_str_Word;//記錄深度搜尋到的Word文件名
            //打開Word文檔
            Microsoft.Office.Interop.Word.Document document = word.Documents.Open(ref P_obj_Name, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            word.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone; ;//設定操作Word時不顯示任何對話框
            P_int_TableCount = document.Tables.Count;//取得Word文檔中表格的數量
            if (P_int_TableCount > 0)//判斷表格數量是否大於0
            {
                for (int j = 1; j <= P_int_TableCount; j++)//深度搜尋所有表格
                {
                    table = document.Tables[j];//記錄深度搜尋到的表格
                    P_int_Row = table.Rows.Count;//取得表格行數
                    P_int_Column = table.Columns.Count;//取得表格列數
                    for (int row = 1; row <= P_int_Row; row++)//深度搜尋表格中的行
                    {
                        for (int column = 1; column <= P_int_Column; column++)//深度搜尋表格中的列
                        {
                            P_str_Content = table.Cell(row, column).Range.Text;//取得深度搜尋到的儲存格內容
                            newWorksheet.Cells[row, column] = P_str_Content.Substring(0, P_str_Content.Length - 2);//將深度搜尋到的儲存格內容新增到Excel儲存格中
                        }
                    }
                }
            }
            else
            {
                if (P_int_Row == 0)//判斷前面是否已經填充過表格
                    newWorksheet.Cells[P_int_Row + 1, 1] = document.Content.Text;//直接將Word文檔內容新增到工作表中
                else
                    newWorksheet.Cells[P_int_Row, 1] = document.Content.Text;//直接將Word文檔內容新增到工作表中
            }
            document.Close(ref missing, ref missing, ref missing);//關閉Word文檔
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
            word.Quit(ref missing, ref missing, ref missing);//退出Word應用程式
        }

        private List<string> GetTable(string P_str_Access)
        {
            string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Access + ";Persist Security Info=True";//記錄連接Access的語句
            OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//實例化OLEDB連接對像
            oledbcon.Open();//打開資料庫連接
            DataTable DTable = oledbcon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });//取得所有資料表訊息
            oledbcon.Close();//關閉資料庫連接
            List<string> P_list_Tables = new List<string>();
            for (int i = 0; i < DTable.Rows.Count; i++)//深度搜尋資料表訊息
            {
                P_list_Tables.Add(DTable.Rows[i][2].ToString());//將資料表名稱新增到泛型集合中
            }
            return P_list_Tables;
        }

        private void AccessToExcel(string P_str_Access, string P_str_Table, string P_str_Excel)
        {
            string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Access + ";Persist Security Info=True";//記錄連接Access的語句
            string P_str_Sql = "";//存儲要執行的SQL語句
            OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//實例化OLEDB連接對像
            OleDbCommand oledbcom;//定義OleDbCommand對像
            oledbcon.Open();//打開資料庫連接
            //向Excel工作表中導入資料
            P_str_Sql = @"select * into [Excel 8.0;database=" + P_str_Excel + "]." + "[" + P_str_Table + "] from " + P_str_Table + "";//記錄連接Excel的語句
            oledbcom = new System.Data.OleDb.OleDbCommand(P_str_Sql, oledbcon);//實例化OleDbCommand對像
            oledbcom.ExecuteNonQuery();//執行SQL語句，將資料表的內容導入到Excel中
            oledbcon.Close();//關閉資料庫連接
            oledbcon.Dispose();//釋放資源
        }
    }
}
