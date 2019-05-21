using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiWordToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_SelectWord_Click(object sender, EventArgs e)
        {
            txt_Word.Text = "";//清空文字框
            OpenFileDialog openWord = new OpenFileDialog();//實例化打開對話框對像
            openWord.Filter = "Word文件|*.doc;*.docx";//設定打開文件篩選器
            openWord.Multiselect = true;//設定打開對話框中可以多選
            if (openWord.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                for (int i = 0; i < openWord.FileNames.Length; i++)//深度搜尋選擇的多個文件
                    txt_Word.Text += openWord.FileNames[i] + ",";//顯示選擇的Word文件
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

        private void btn_Read_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();//實例化Word對像
            Microsoft.Office.Interop.Word.Table table;//聲明Word表格對像
            int P_int_TableCount = 0, P_int_Row = 0, P_int_Column = 0;//定義3個變數，分別用來存儲表格數量、表格中的行數、列數
            string P_str_Content;//存儲Word表格的儲存格內容
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            string[] P_str_Names = txt_Word.Text.Split(',');//存儲所有選擇的Word文件名
            object P_obj_Name;//存儲深度搜尋到的Word文件名
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//建立新工作表
            for (int i = 0; i < P_str_Names.Length - 1; i++)//深度搜尋所有選擇Word文件名
            {
                P_obj_Name = P_str_Names[i];//記錄深度搜尋到的Word文件名
                //打開Word文檔
                Microsoft.Office.Interop.Word.Document document = word.Documents.Open(ref P_obj_Name, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
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
                                newWorksheet.Cells[i + row, column] = P_str_Content.Substring(0, P_str_Content.Length - 2);//將深度搜尋到的儲存格內容新增到Excel儲存格中
                            }
                        }
                    }
                }
                else
                {
                    if (P_int_Row == 0)//判斷前面是否已經填充過表格
                        newWorksheet.Cells[i + P_int_Row + 1, 1] = document.Content.Text;//直接將Word文檔內容新增到工作表中
                    else
                        newWorksheet.Cells[i + P_int_Row, 1] = document.Content.Text;//直接將Word文檔內容新增到工作表中
                }
                document.Close(ref missing, ref missing, ref missing);//關閉Word文檔
            }
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
            word.Quit(ref missing, ref missing, ref missing);//退出Word應用程式
            MessageBox.Show("已經成功將多個Word文檔的內容合併到了Excel的同一個資料表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打開選擇的Excel文件
        }
    }
}
