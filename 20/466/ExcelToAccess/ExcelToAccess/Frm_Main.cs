using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ExcelToAccess
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
            openFileDialog1.Multiselect = false;//設定打開對話框中只能單選
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文字框中顯示Excel文件名
                CBoxBind();//對下拉列表進行資料繫結
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

        private void btn_Export_Click(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//聲明object預設值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//聲明工作表
            Microsoft.Office.Interop.Access.Application access = new Microsoft.Office.Interop.Access.Application();//實例化Access對像
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[cbox_SheetName.Text]);//取得選擇的工作表
            worksheet.Move(workbook.Sheets[1], missing);//將選擇的工作表作為第一個工作表
            object P_obj_Name = (object)worksheet.Name;//取得工作表名稱
            excel.DisplayAlerts = false;//設定Excel儲存時不顯示對話框
            workbook.Save();//儲存工作簿
            CloseProcess("EXCEL");//關閉所有Excel進程
            object P_obj_Excel = (object)txt_Path.Text;//記錄Excel文件路徑
            try
            {
                access.OpenCurrentDatabase(txt_Access.Text, true, "");//打開Access資料庫
                //將Excel指定工作表中的資料導入到Access中
                access.DoCmd.TransferSpreadsheet(Microsoft.Office.Interop.Access.AcDataTransferType.acImport, Microsoft.Office.Interop.Access.AcSpreadSheetType.acSpreadsheetTypeExcel97, P_obj_Name, P_obj_Excel, true, missing, missing);
                access.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveAll);//關閉並儲存Access資料庫文件
                CloseProcess("MSACCESS");//關閉所有Access資料庫進程
                MessageBox.Show("已經將Excel的" + cbox_SheetName.Text + "工作表中的資料導入到Access資料庫中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Access資料庫中已經存在該表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Access.Text);//打開導出後的Access文件
        }

        private void CBoxBind()//對下拉列表進行資料繫結
        {
            cbox_SheetName.Items.Clear();//清空下拉列表項
            //連接Excel資料庫
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=Excel 8.0");
            olecon.Open();//打開資料庫連接
            System.Data.DataTable DTable = olecon.GetSchema("Tables");//實例化表對像
            DataTableReader DTReader = new DataTableReader(DTable);//實例化表讀取對像
            while (DTReader.Read())//循環讀取
            {
                string P_str_Name = DTReader["Table_Name"].ToString().Replace('$', ' ').Trim();//記錄工作表名稱
                if (!cbox_SheetName.Items.Contains(P_str_Name))//判斷下拉列表中是否已經存在該工作表名稱
                    cbox_SheetName.Items.Add(P_str_Name);//將工作表名新增到下拉列表中
            }
            DTable = null;//清空表對像
            DTReader = null;//清空表讀取對像
            olecon.Close();//關閉資料庫連接
            cbox_SheetName.SelectedIndex = 0;//設定下拉列表預設選項為第一項
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
