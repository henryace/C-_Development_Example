using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ExcelChart
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

        private void tsbtn_Build_Click(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//關閉所有Excel進程
            object missing = System.Reflection.Missing.Value;//定義object預設值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(tstxt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//聲明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[tscbox_Sheet.Text]);//取得選擇的工作表
            Microsoft.Office.Interop.Excel.Range searchRange = worksheet.get_Range("A1", "E1");//定義標題範圍
            object[] P_obj_Items = { "編程詞典", "VC編程詞典", "JAVA編程詞典", "ASP.NET編程詞典", "C#編程詞典" };
            searchRange.set_Value(missing, P_obj_Items);//繪製標題
            searchRange.Font.Bold = true;//設定字體加粗
            searchRange.Font.Name = "細明體";//設定字體樣式
            searchRange.Font.Size = 10;//設定字體大小
            searchRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//設定標題對齊方式
            //取得要產生圖表的資料
            for (int i = 0; i < 13; i++)
            {
                worksheet.Cells[2 + i, 1] = i;
                worksheet.Cells[2 + i, 2] = i + 1;
                worksheet.Cells[2 + i, 3] = i + 2;
                worksheet.Cells[2 + i, 4] = i + 3;
                worksheet.Cells[2 + i, 5] = i + 4;
            }
            //實例化Excel繪圖對像
            Microsoft.Office.Interop.Excel.Chart chart = (Microsoft.Office.Interop.Excel.Chart)workbook.Charts.Add(missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Range chartRange = worksheet.get_Range("A1:A14", "B1:E14");//定義繪製圖表範圍
            //在指定範圍繪製圖表
            chart.ChartWizard(chartRange, Microsoft.Office.Interop.Excel.XlChartType.xl3DColumn, missing, Microsoft.Office.Interop.Excel.XlRowCol.xlColumns, 1, 1, true, "編程詞典銷量分析", "月份", "銷量", missing);
            excel.DisplayAlerts = false;//設定儲存Excel時不顯示對話框
            workbook.Save();//儲存工作簿
            workbook.Close(false, missing, missing);//關閉工作簿
            CloseProcess("EXCEL");//關閉所有Excel進程
            WBrowser_Excel.Navigate(tstxt_Excel.Text);//在視窗中重新顯示Excel文件內容
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