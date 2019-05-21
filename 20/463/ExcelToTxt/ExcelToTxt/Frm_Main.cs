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

namespace ExcelToTxt
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

        private void btn_Txt_Click(object sender, EventArgs e)
        {
            //連接Excel資料庫
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=Excel 8.0");
            olecon.Open();//打開資料庫連接
            OleDbDataAdapter oledbda = new OleDbDataAdapter("select * from [" + cbox_SheetName.Text + "$]", olecon);//從工作表中查詢資料
            DataSet myds = new DataSet();//實例化資料集對像
            oledbda.Fill(myds);//填充資料集
            StreamWriter SWriter = new StreamWriter(cbox_SheetName.Text + ".txt", false, Encoding.Default);//實例化寫入流對像
            string P_str_Content = "";//存儲讀取的內容
            for (int i = 0; i < myds.Tables[0].Rows.Count; i++)//深度搜尋資料集中表的行數
            {
                for (int j = 0; j < myds.Tables[0].Columns.Count; j++)//深度搜尋資料集中表的列數
                {
                    P_str_Content += myds.Tables[0].Rows[i][j].ToString() + "  ";//記錄目前深度搜尋到的內容
                }
                P_str_Content += Environment.NewLine;//字串換行
            }
            SWriter.Write(P_str_Content);//先文字文件中寫入內容
            SWriter.Close();//關閉寫入流對像
            SWriter.Dispose();//釋放寫入流所佔用的資源
            MessageBox.Show("已經將" + cbox_SheetName.Text + "工作表中的資料成功寫入到了文字文件中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
