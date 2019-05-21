using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TxtToExcel
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
            int P_int_Count = 0;//記錄正在讀取的行數
            string P_str_Line, P_str_Content = "";//記錄讀取行的內容及深度搜尋到的內容
            List<string> P_str_List = new List<string>();//存儲讀取的所有內容
            StreamReader SReader = new StreamReader(txt_Txt.Text, Encoding.Default);//實例化流讀取對像
            while ((P_str_Line = SReader.ReadLine()) != null)//循環讀取文字文件中的每一行
            {
                P_str_List.Add(P_str_Line);//將讀取到的行內容新增到泛型集合中
                P_int_Count++;//使目前讀取行數加1
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            for (int i = 0; i < P_str_List.Count; i++)//深度搜尋泛型集合
            {
                P_str_Content = P_str_List[i];//記錄深度搜尋到的值
                if (Regex.IsMatch(P_str_Content, "^[0-9]*[1-9][0-9]*$"))//判斷是否是數字
                    newWorksheet.Cells[i + 1, 1] = Convert.ToDecimal(P_str_Content).ToString("￥00.00");//格式化為貨幣格式，再新增到工作表中
                else
                    newWorksheet.Cells[i + 1, 1] = P_str_Content;//直接將深度搜尋到的內容新增到工作表中
            }
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
            MessageBox.Show("已經將文字文件內容成功導入Excel工作表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打開選擇的Excel文件
        }
    }
}
