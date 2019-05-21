using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace AutoMultiExcelToOneExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 為INI文件中指定的節點取得字串
        /// <summary>
        /// 為INI文件中指定的節點取得字串
        /// </summary>
        /// <param name="lpAppName">欲在其中搜尋關鍵字的節點名稱</param>
        /// <param name="lpKeyName">欲取得的項名</param>
        /// <param name="lpDefault">指定的項沒有找到時返回的預設值</param>
        /// <param name="lpReturnedString">指定一個字串緩衝區，長度至少為nSize</param>
        /// <param name="nSize">指定裝載到lpReturnedString緩衝區的最大字符數量</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>複製到lpReturnedString緩衝區的字節數量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        #endregion

        #region 修改INI文件中內容
        /// <summary>
        /// 修改INI文件中內容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中寫入的節點名稱</param>
        /// <param name="lpKeyName">欲設定的項名</param>
        /// <param name="lpString">要寫入的新字串</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>非零表示成功，零表示失敗</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        #endregion

        #region 從INI文件中讀取指定節點的內容
        /// <summary>
        /// 從INI文件中讀取指定節點的內容
        /// </summary>
        /// <param name="section">INI節點</param>
        /// <param name="key">節點下的項</param>
        /// <param name="def">沒有找到內容時返回的預設值</param>
        /// <param name="def">要讀取的INI文件</param>
        /// <returns>讀取的節點內容</returns>
        public string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        #endregion

        string M_str_Name = Application.StartupPath + "\\Set.ini";//定義要讀取的INI文件

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            txt_MultiExcel.Text = ReadString("Set", "MultiExcel", "", M_str_Name);//讀取預設的多個Excel文件
            txt_Excel.Text = ReadString("Set", "Excel", "", M_str_Name);//讀取目標Excel文件
            nudown_Hour.Value = Convert.ToInt32(ReadString("Set", "Hour", "", M_str_Name));//讀取小時
            nudown_Min.Value = Convert.ToInt32(ReadString("Set", "Min", "", M_str_Name));//讀取分鐘
            timer1.Start();//啟動計時器
        }

        private void btn_SelectMultiExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMultiExcel = new OpenFileDialog();//實例化打開對話框對像
            openMultiExcel.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openMultiExcel.Multiselect = true;//設定打開對話框中可以多選
            if (openMultiExcel.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                for (int i = 0; i < openMultiExcel.FileNames.Length; i++)//深度搜尋選擇的多個文件
                    txt_MultiExcel.Text += openMultiExcel.FileNames[i] + ",";//顯示選擇的多個Excel文件
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

        private void btn_Set_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Set", "MultiExcel", txt_MultiExcel.Text, M_str_Name);//設定多個Excel文件路徑
            WritePrivateProfileString("Set", "Excel", txt_Excel.Text, M_str_Name);//設定目標Excel文件路徑
            WritePrivateProfileString("Set", "Hour", nudown_Hour.Value.ToString(), M_str_Name);//設定小時
            WritePrivateProfileString("Set", "Min", nudown_Min.Value.ToString(), M_str_Name);//設定分鐘
            MessageBox.Show("設定文件設定成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();//啟動計時器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//定義object預設值
            string[] P_str_Names = txt_MultiExcel.Text.Split(',');//存儲所有選擇的Excel文件名
            string P_str_Name = "";//存儲深度搜尋到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//實例化泛型集合對象，用來存儲工作表名稱
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//建立新工作表
            if (DateTime.Now.Hour == nudown_Hour.Value && DateTime.Now.Minute == nudown_Min.Value)
            {
                for (int i = 0; i < P_str_Names.Length - 1; i++)//深度搜尋所有選擇的Excel文件名
                {
                    P_str_Name = P_str_Names[i];//記錄深度搜尋到的Excel文件名
                    //指定要複製的工作簿
                    Microsoft.Office.Interop.Excel.Workbook Tempworkbook = excel.Application.Workbooks.Open(P_str_Name, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                    P_list_SheetNames = GetSheetName(P_str_Name);//取得Excel文件中的所有工作表名
                    for (int j = 0; j < P_list_SheetNames.Count; j++)//深度搜尋所有工作表
                    {
                        //指定要複製的工作表
                        Microsoft.Office.Interop.Excel.Worksheet TempWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)Tempworkbook.Sheets[P_list_SheetNames[j]];//建立新工作表
                        TempWorksheet.Copy(missing, newWorksheet);//將工作表內容複製到目標工作表中
                    }
                    Tempworkbook.Close(false, missing, missing);//關閉臨時工作簿
                }
            }
            workbook.Save();//儲存目標工作簿
            workbook.Close(false, missing, missing);//關閉目標工作簿
            MessageBox.Show("程式在" + DateTime.Now.ToShortTimeString() + "分時自動匯總了多個Excel文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CloseProcess("EXCEL");//關閉所有Excel進程
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打開選擇的Excel文件
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();//停止計時器
        }

        private List<string> GetSheetName(string P_str_Excel)//取得所有工作表名稱
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
                    P_list_SheetName.Add(P_str_Name);//將工作表名新增到泛型集合中
            }
            DTable = null;//清空表對像
            DTReader = null;//清空表讀取對像
            olecon.Close();//關閉資料庫連接
            return P_list_SheetName;//返回得到的泛型集合
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
