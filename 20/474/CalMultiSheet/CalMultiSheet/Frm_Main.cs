using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CalMultiSheet
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
            openFile.Title = "打開Excel模板";//設定打開對話框標題
            openFile.InitialDirectory = Application.StartupPath;//設定初始路徑
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

        private void tsbtn_Calc_Click(object sender, EventArgs e)
        {
            int P_int_Start = 0;//定義開始計算的行
            int P_int_End = 0;//定義結束計算的行
            P_int_Start = Convert.ToInt32(tstxt_Start.Text);//記錄開始計算行
            P_int_End = Convert.ToInt32(tstxt_End.Text);//記錄結束計算行
            for (int i = P_int_Start; i <= P_int_End; i++)//深度搜尋所有要計算的行
            {
                CalcData(i, tstxt_Column.Text);//多表計算，並將計算結果寫入Excel中
            }
            MessageBox.Show("多表計算完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CalcData(int P_int_Row, string P_str_Column)
        {
            CloseProcess("EXCEL");//關閉所有Excel進程
            string P_str_workBook1 = Application.StartupPath + "\\Excel1.xls";//記錄第一個要計算的工作簿路徑
            string P_str_workBook2 = Application.StartupPath + "\\Excel2.xls";//記錄第二個要計算的工作簿路徑
            string P_str_workBook3 = Application.StartupPath + "\\Excel3.xls";//記錄第三個要計算的工作簿路徑
            string P_str_workBook4 = Application.StartupPath + "\\Sum.xls";//記錄存儲計算結果的工作簿路徑
            object missing = System.Reflection.Missing.Value;//定義object預設值
            Microsoft.Office.Interop.Excel.ApplicationClass excel1 = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            excel1.Visible = false;//設定Excel文件隱藏
            //打開第一個計算的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook1 = excel1.Workbooks.Open(P_str_workBook1, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //記錄要計算的第一個工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet1 = (Microsoft.Office.Interop.Excel._Worksheet)workbook1.Worksheets.get_Item(tscbox_Sheet.Text);
            Microsoft.Office.Interop.Excel.ApplicationClass excel2 = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            excel2.Visible = false;//設定Excel文件隱藏
            //打開第二個計算的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook2 = excel2.Workbooks.Open(P_str_workBook2, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //記錄要計算的第二個工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet2 = (Microsoft.Office.Interop.Excel._Worksheet)workbook2.Worksheets.get_Item(tscbox_Sheet.Text);
            Microsoft.Office.Interop.Excel.ApplicationClass excel3 = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            excel3.Visible = false;//設定Excel文件隱藏
            //打開第三個計算的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook3 = excel3.Workbooks.Open(P_str_workBook3, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //記錄要計算的第三個工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet3 = (Microsoft.Office.Interop.Excel._Worksheet)workbook3.Worksheets.get_Item(tscbox_Sheet.Text);
            Microsoft.Office.Interop.Excel.ApplicationClass excel4 = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            excel4.Visible = false;//設定Excel文件隱藏
            //打開存儲計算結果的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook4 = excel4.Workbooks.Open(P_str_workBook4, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //記錄要存儲結算結果的工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet4 = (Microsoft.Office.Interop.Excel._Worksheet)workbook4.Worksheets.get_Item(tscbox_Sheet.Text);
            excel4.DisplayAlerts = false;//設定儲存Excel時不顯示對話框
            worksheet4.Activate();//激活工作表
            Decimal P_dml_NumOne = 0;//取得第一個工作表的值
            Decimal P_dml_NumTwo = 0;//取得第二個工作表的值
            Decimal P_dml_NumThree = 0;//取得第三個工作表的值
            //判斷指定儲存格內容是否為空
            if (((Microsoft.Office.Interop.Excel.Range)worksheet1.Cells[P_int_Row, P_str_Column]).Text.ToString() == "" || ((Microsoft.Office.Interop.Excel.Range)worksheet1.Cells[P_int_Row, P_str_Column]).Text == null)
            {
                P_dml_NumOne = 0;//將第一個值設定為0
            }
            else
            {
                P_dml_NumOne = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)worksheet1.Cells[P_int_Row, P_str_Column]).Text);//記錄第一個值
            }
            //判斷指定儲存格內容是否為空
            if (((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[P_int_Row, P_str_Column]).Text.ToString() == "" || ((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[P_int_Row, P_str_Column]).Text == null)
            {
                P_dml_NumTwo = 0;//將第二個值設定為0
            }
            else
            {
                P_dml_NumTwo = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[P_int_Row, P_str_Column]).Text);//記錄第二個值
            }
            //判斷指定儲存格內容是否為空
            if (((Microsoft.Office.Interop.Excel.Range)worksheet3.Cells[P_int_Row, P_str_Column]).Text.ToString() == "" || ((Microsoft.Office.Interop.Excel.Range)worksheet3.Cells[P_int_Row, P_str_Column]).Text == null)
            {
                P_dml_NumThree = 0;//將第三個值設定為0
            }
            else
            {
                P_dml_NumThree = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)worksheet3.Cells[P_int_Row, P_str_Column]).Text);//記錄第三個值
            }
            Decimal P_dml_Sum = P_dml_NumOne + P_dml_NumTwo + P_dml_NumThree;//計算總和
            try
            {
                worksheet4.Cells[P_int_Row, P_str_Column] = P_dml_Sum.ToString();//向工作簿的指定儲存格中寫入計算後的資料
                workbook4.Save();//儲存Excel文件
            }
            catch
            {
                MessageBox.Show("寫入第" + P_int_Row.ToString() + "行，第" + P_str_Column + "列時出錯！");
            }
            finally
            {
                workbook4.Save();//儲存Excel文件
                //退出打開的4個Excel文件
                excel1.Quit();
                excel2.Quit();
                excel3.Quit();
                excel4.Quit();
            }
            WBrowser_Excel.Navigate(P_str_workBook4);//在視窗中顯示多表計算後的Excel文件
        }

        private void CloseProcess(string P_str_Process)//關閉進程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
        }
    }
}