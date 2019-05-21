using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace CreateMultiSheet
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string M_str_Name = "";
        private void 打開Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            OpenFileDialog.Title = "打開Excel文件";//設定打開對話框標題
            OpenFileDialog.Multiselect = false;//設定打開對話框中不能多選
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                M_str_Name = OpenFileDialog.FileName;//記錄選擇的Excel文件
                WBrowser_Excel.Navigate(M_str_Name);//在視窗中顯示Excel文件內容
            }
        }

        private void 建立工作表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseProcess();//關閉Excel進程
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            object missing = Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(M_str_Name, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, 1, missing);
            MessageBox.Show("新增工作表成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
            WBrowser_Excel.Navigate(M_str_Name);//在視窗中顯示Excel文件內容
        }

        private void CloseProcess()
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
            System.Threading.Thread.Sleep(10);//使線程休眠10毫秒
        }
    }
}
