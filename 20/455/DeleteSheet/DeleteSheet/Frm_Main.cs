using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;

namespace DeleteSheet
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            object missing = Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[cbox_SheetName.Text]).Delete();//刪除選擇的工作表
            MessageBox.Show("工作表刪除成功！");
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            workbook.Save();//儲存工作表
            CBoxBind();//對下拉列表進行資料繫結
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
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
                cbox_SheetName.Items.Add(DTReader["Table_Name"].ToString().Replace('$',' ').Trim());//將工作表名新增到下拉列表中
            }
            DTable = null;//清空表對像
            DTReader = null;//清空表讀取對像
            olecon.Close();//關閉資料庫連接
            cbox_SheetName.SelectedIndex = 0;//設定下拉列表預設選項為第一項
        }
    }
}
