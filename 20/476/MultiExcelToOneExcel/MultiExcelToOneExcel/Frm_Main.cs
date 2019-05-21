using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MultiExcelToOneExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_SelectMultiExcel_Click(object sender, EventArgs e)
        {
            txt_MultiExcel.Text = "";//清空文字框
            OpenFileDialog openMultiExcel = new OpenFileDialog();//實例化打開對話框對像
            openMultiExcel.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openMultiExcel.Multiselect = true;//設定打開對話框中可以多選
            if (openMultiExcel.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                for (int i = 0; i < openMultiExcel.FileNames.Length; i++)//深度搜尋選擇的多個文件
                    txt_MultiExcel.Text += openMultiExcel.FileNames[i] + ",";//顯示選擇的多個Excel文件
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

        private void btn_Gather_Click(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//定義object預設值
            string[] P_str_Names = txt_MultiExcel.Text.Split(',');//存儲所有選擇的Excel文件名
            string P_str_Name = "";//存儲深度搜尋到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//實例化泛型集合對象，用來存儲工作表名稱
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//建立新工作表
            for (int i = 0; i < P_str_Names.Length - 1; i++)//深度搜尋所有選擇的Excel文件名
            {
                P_str_Name = P_str_Names[i];//記錄深度搜尋到的Excel文件名
                //指定要複製的工作簿
                Microsoft.Office.Interop.Excel.Workbook Tempworkbook = excel.Application.Workbooks.Open(P_str_Name, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                P_list_SheetNames = GetSheetName(P_str_Name);//取得Excel文件中的所有工作表名
                for (int j = 0; j < P_list_SheetNames.Count; j++)//深度搜尋所有工作表
                {
                    //指定要複製的工作表
                    Microsoft.Office.Interop.Excel.Worksheet TempWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)Tempworkbook.Sheets[P_list_SheetNames[j]];//建立新工作表
                    TempWorksheet.Copy(missing, newWorksheet);//將工作表內容複製到目標工作表中
                }
                Tempworkbook.Close(false, missing, missing);//關閉臨時工作簿
            }
            workbook.Save();//儲存目標工作簿
            workbook.Close(false, missing, missing);//關閉目標工作簿
            MessageBox.Show("已經將所有選擇的Excel工作表匯總到了一個Excel工作表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CloseProcess("EXCEL");//關閉所有Excel進程
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打開選擇的Excel文件
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
            System.Threading.Thread.Sleep(10);//使線程休眠10毫秒
        }
    }
}
