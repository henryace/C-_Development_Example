using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace CreateExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了路徑
            {
                txt_Path.Text = folderBrowserDialog1.SelectedPath;//顯示選擇的路徑
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string P_str_path = txt_Path.Text;//記錄路徑
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            Microsoft.Office.Interop.Excel.Workbook newWorkBook = excel.Application.Workbooks.Add(true);//新增新工作簿
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            newWorkBook.Worksheets.Add(missing, missing, missing, missing);//向Excel文件中增加工作表
            if (P_str_path.EndsWith("\\"))//判斷路徑是否\結尾
                newWorkBook.SaveCopyAs(P_str_path + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");//儲存Excel文件
            else
                newWorkBook.SaveCopyAs(P_str_path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");//儲存Excel文件
            MessageBox.Show("Excel文件建立成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//彈出提示訊息
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
        }
    }
}
