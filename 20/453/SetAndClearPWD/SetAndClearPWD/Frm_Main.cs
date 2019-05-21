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

namespace SetAndClearPWD
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
                txt_Path.Text = openFileDialog1.FileName;//在文字框中顯示Excel文件內容
            }
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            object missing = Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //記錄用戶輸入的密碼
            string P_str_password = excel.Application.InputBox("輸入密碼：", missing, missing, missing, missing, missing, missing, missing).ToString();
            //記錄用戶輸入的確認密碼
            string P_str_confirmPassword = excel.Application.InputBox("確認密碼：", missing, missing, missing, missing, missing, missing, missing).ToString();
            if (P_str_password != P_str_confirmPassword)//判斷密碼與確認密碼是否一致
            {
                MessageBox.Show("輸入的密碼不一致！");
            }
            else
            {
                workbook.Password = P_str_password;//設定Excel密碼
                MessageBox.Show("密碼設定成功！");
            }
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();//實例化Excel對像
            object missing = Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            workbook.Password = "";//設定Excel密碼為空
            MessageBox.Show("密碼清除成功！");
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
        }
    }
}
