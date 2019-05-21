using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MultiExcelToWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private object P_obj_WordName = "";//記錄Word文件路徑及名稱
        private void btn_SelectExcel_Click(object sender, EventArgs e)
        {
            txt_Excel.Text = "";//清空文字框
            OpenFileDialog openExcel = new OpenFileDialog();//實例化打開對話框對像
            openExcel.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openExcel.Multiselect = true;//設定打開對話框中不能多選
            if (openExcel.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                for (int i = 0; i < openExcel.FileNames.Length; i++)//深度搜尋選擇的多個文件
                    txt_Excel.Text += openExcel.FileNames[i] + ",";//顯示選擇的Excel文件
            }
        }

        private void btn_SelectTxt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();//實例化瀏覽資料夾對話框對像
            if (FBDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了資料夾
            {
                txt_Word.Text = FBDialog.SelectedPath;//顯示選擇的Word存放路徑
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            string[] P_str_Names = txt_Excel.Text.Split(',');//存儲所有選擇的Excel文件名
            object P_obj_Name;//存儲深度搜尋到的Excel文件名
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();//實例化Word對像
            if (txt_Word.Text.EndsWith("\\"))//判斷路徑是否以\結尾
                P_obj_WordName = txt_Word.Text + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc";//記錄Word文件路徑及名稱
            else
                P_obj_WordName = txt_Word.Text + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc";//記錄Word文件路徑及名稱
            Microsoft.Office.Interop.Word.Table table;//聲明Word表格對像
            Microsoft.Office.Interop.Word.Document document = new Microsoft.Office.Interop.Word.Document();//聲明Word文檔對像
            document = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);//新建Word文檔
            Microsoft.Office.Interop.Word.Range range;//聲明範圍對像
            int P_int_Rows = 0, P_int_Columns = 0;//存儲工作表中資料的行數和列數
            object P_obj_start = 0, P_obj_end = 0;//分別記錄建立表格的開始和結束範圍                   
            object P_obj_Range = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd;//定義要合併的範圍位置
            for (int i = 0; i < P_str_Names.Length - 1; i++)//深度搜尋所有選擇的Excel文件名
            {
                P_obj_Name = P_str_Names[i];//記錄深度搜尋到的Excel文件名
                List<string> P_list_SheetName = CBoxBind(P_obj_Name.ToString());//取得指定Excel中的所有工作表
                for (int j = 0; j < P_list_SheetName.Count; j++)//深度搜尋所有工作表
                {
                    range = document.Range(ref missing, ref missing);//取得Word範圍
                    range.InsertAfter(P_obj_Name + "——" + P_list_SheetName[j] + "工作表");//插入文字
                    range.Font.Name = "細明體";//設定字體
                    range.Font.Size = 10;//設定字體大小
                    DataSet myds = CBoxShowCount(P_obj_Name.ToString(), P_list_SheetName[j]);//取得工作表中的所有資料
                    P_int_Rows = myds.Tables[0].Rows.Count;//記錄工作表的行數
                    P_int_Columns = myds.Tables[0].Columns.Count;//記錄工作表的列數
                    range.Collapse(ref P_obj_Range);//合併範圍
                    if (P_int_Rows > 0 && P_int_Columns > 0)//判斷如果工作表中有記錄
                    {
                        //在指定範圍處新增一個指定行數和列數的表格
                        table = range.Tables.Add(range, P_int_Rows, P_int_Columns, ref missing, ref missing);
                        for (int r = 0; r < P_int_Rows; r++)//深度搜尋行
                        {
                            for (int c = 0; c < P_int_Columns; c++)//深度搜尋列
                            {
                                table.Cell(r + 1, c + 1).Range.InsertAfter(myds.Tables[0].Rows[r][c].ToString());//將深度搜尋到的資料新增到Word表格中
                            }
                        }
                    }
                    object P_obj_Format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;//定義Word文檔的儲存格式
                    word.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;//設定儲存時不顯示對話框
                    //儲存Word文檔
                    document.SaveAs(ref P_obj_WordName, ref P_obj_Format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                }
            }
            document.Close(ref missing, ref missing, ref missing);//關閉Word文檔
            word.Quit(ref missing, ref missing, ref missing);//退出Word應用程式
            MessageBox.Show("已經成功將多個Excel文件的內容讀取到了一個Word文檔中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(P_obj_WordName.ToString());//打開產生的Word文件
        }

        //取得指定Excel中的所有工作表
        private List<string> CBoxBind(string P_str_Excel)
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
                {
                    P_list_SheetName.Add(P_str_Name);//將工作表名新增到泛型集合中
                }
            }
            DTable = null;//清空表對像
            DTReader = null;//清空表讀取對像
            olecon.Close();//關閉資料庫連接
            return P_list_SheetName;//返回泛型集合
        }

        //取得Excel工作表中的資料
        private DataSet CBoxShowCount(string P_str_Excel, string P_str_Name)
        {
            //連接Excel資料庫
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0");
            OleDbDataAdapter oledbda = new OleDbDataAdapter("select * from [" + P_str_Name + "$]", olecon);//從工作表中查詢資料
            DataSet myds = new DataSet();//實例化資料集對像
            oledbda.Fill(myds);//填充資料集
            return myds;//返回資料集
        }
    }
}
