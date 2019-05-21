using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessToExcel
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
            openTxt.Filter = "Access資料庫文件|*.mdb";//設定打開文件篩選器
            openTxt.Multiselect = false;//設定打開對話框中不能多選
            if (openTxt.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Access.Text = openTxt.FileName;//顯示選擇的Access文件
                string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Access.Text + ";Persist Security Info=True";//記錄連接Access的語句
                OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//實例化OLEDB連接對像
                oledbcon.Open();//打開資料庫連接
                DataTable DTable = oledbcon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });//取得所有資料表訊息
                oledbcon.Close();//關閉資料庫連接
                cbox_Table.Items.Clear();//清空下拉列表
                for (int i = 0; i < DTable.Rows.Count; i++)//深度搜尋資料表訊息
                {
                    cbox_Table.Items.Add(DTable.Rows[i][2]);//將資料表名稱新增到下拉列表中
                }
                if (cbox_Table.Items.Count > 0)//判斷下拉列表中是否有項
                    cbox_Table.SelectedIndex = 0;//設定下拉列表預設選擇第一項
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
            try
            {
                string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Access.Text + ";Persist Security Info=True";//記錄連接Access的語句
                string P_str_Sql = "";//存儲要執行的SQL語句
                OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//實例化OLEDB連接對像
                OleDbCommand oledbcom;//定義OleDbCommand對像
                oledbcon.Open();//打開資料庫連接
                //向Excel工作表中導入資料
                P_str_Sql = @"select * into [Excel 8.0;database=" + txt_Excel.Text + "]." + "[" + cbox_Table.Text + "] from " + cbox_Table.Text + "";//記錄連接Excel的語句
                oledbcom = new System.Data.OleDb.OleDbCommand(P_str_Sql, oledbcon);//實例化OleDbCommand對像
                oledbcom.ExecuteNonQuery();//執行SQL語句，將資料表的內容導入到Excel中
                oledbcon.Close();//關閉資料庫連接
                oledbcon.Dispose();//釋放資源
                MessageBox.Show("導入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(cbox_Table.Text + "工作表已經存在，請選擇其他資料表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打開選擇的Excel文件
        }
    }
}
