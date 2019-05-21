using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SearchTextInRange
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void tsbtn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();//實例化打開對話框對像
            openFile.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openFile.Title = "打開Excel文件";//設定打開對話框標題
            if (openFile.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                tstxt_Excel.Text = openFile.FileName;
                WBrowser_Excel.Navigate(openFile.FileName);//在視窗中顯示Excel文件內容
                List<string> P_list_SheetNames = GetSheetName(tstxt_Excel.Text);//取得選中Excel中的所有工作表
                tscbox_Sheet.Items.Clear();//清空工具欄中的下拉列表
                foreach (string P_str_SheetName in P_list_SheetNames)//深度搜尋工作表集合
                {
                    tscbox_Sheet.Items.Add(P_str_SheetName);//將工作表名稱顯示在下拉列表中
                }
                if (tscbox_Sheet.Items.Count > 0)//判斷下拉列表中是否有項
                    tscbox_Sheet.SelectedIndex = 0;//設定預設選擇第一項
            }
        }

        private void tscbox_Sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//關閉所有Excel進程
            object missing = System.Reflection.Missing.Value;//定義object預設值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(tstxt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//聲明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[tscbox_Sheet.Text]);//取得選擇的工作表
            worksheet.Activate();//激活工作表
            excel.DisplayAlerts = false;//設定儲存Excel時不顯示對話框
            workbook.Save();//儲存工作表
            CloseProcess("EXCEL");//關閉所有Excel進程
            WBrowser_Excel.Navigate(tstxt_Excel.Text);//在視窗中重新顯示Excel文件內容
        }

        private void tsbtn_Query_Click(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//關閉所有Excel進程
            string P_str_Excel = tstxt_Excel.Text;//記錄Excel文件路徑
            string P_str_SheetName = tscbox_Sheet.Text;//記錄選擇的工作表名稱
            object P_obj_Start = tstxt_Start.Text;//記錄開始儲存格
            object P_obj_End = tstxt_End.Text;//記錄結束儲存格
            object missing = System.Reflection.Missing.Value;//定義object預設值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//聲明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[P_str_SheetName]);//取得選擇的工作表
            Microsoft.Office.Interop.Excel.Range searchRange = worksheet.get_Range(P_obj_Start, P_obj_End);//定義搜尋範圍
            Microsoft.Office.Interop.Excel.Range currentRange = null;//定義目前找到的範圍
            Microsoft.Office.Interop.Excel.Range firstRange = null;//定義找到的第一個範圍
            object P_obj_Text = tstxt_Text.Text;//記錄要搜索的文字
            //搜索第一個匹配項，指定從其後開始搜索的儲存格以外的所有參數
            currentRange = searchRange.Find(P_obj_Text, missing, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false, missing, missing);
            //一直搜索，直到沒有匹配項
            while (currentRange != null)
            {
                if (firstRange == null)//如果第一個範圍不包含任何值
                {
                    firstRange = currentRange;//記錄目前範圍
                }
                //如果搜尋範圍的地址與第一個搜尋範圍的地址匹配
                else if (currentRange.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing) == firstRange.get_Address(missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, missing, missing))
                {
                    break;//退出
                }
                //為儲存格加邊框
                currentRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black.ToArgb());
                currentRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);//設定搜索到的文字顏色
                currentRange.Font.Bold = true;//設定搜索到的文字為粗體
                currentRange = searchRange.FindNext(currentRange);//搜尋下一處
            }
            MessageBox.Show("搜索完畢！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excel.DisplayAlerts = false;//設定儲存Excel時不顯示對話框
            workbook.Save();//儲存工作表
            CloseProcess("EXCEL");//關閉所有Excel進程
            WBrowser_Excel.Navigate(P_str_Excel);//在視窗中重新顯示Excel文件內容
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseProcess("EXCEL");//關閉所有Excel進程
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

        private void CloseProcess(string P_str_Process)//關閉進程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
        }
    }
}