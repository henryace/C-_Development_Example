using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace TimeReportResultToExcel
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
            txt_Floder.Text = ReadString("Set", "Floder", "", M_str_Name);//讀取預設資料夾
            txt_Path.Text = ReadString("Set", "Excel", "", M_str_Name);//讀取預設Excel文件
            nudown_Hour.Value = Convert.ToInt32(ReadString("Set", "Hour", "", M_str_Name));//讀取小時
            nudown_Min.Value = Convert.ToInt32(ReadString("Set", "Min", "", M_str_Name));//讀取分鐘
            timer1.Start();//啟動計時器
        }

        private void btn_SelectFlod_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FDialog = new FolderBrowserDialog();//實例化瀏覽資料夾對話框對像
            FDialog.RootFolder = Environment.SpecialFolder.Desktop;//設定瀏覽資料夾對話框的初始路徑
            openFileDialog1.Multiselect = false;//設定瀏覽資料夾對話框中只能單選
            if (FDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了資料夾
            {
                txt_Floder.Text = FDialog.SelectedPath;//在文字框中顯示選擇的資料夾
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openFileDialog1.Title = "選擇Excel文件";//設定打開對話框標題
            openFileDialog1.Multiselect = false;//設定打開對話框中只能單選
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文字框中顯示Excel文件名
            }
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Set", "Floder", txt_Floder.Text, M_str_Name);//設定預設資料夾路徑
            WritePrivateProfileString("Set", "Excel", txt_Path.Text, M_str_Name);//設定Excel文件路徑
            WritePrivateProfileString("Set", "Hour", nudown_Hour.Value.ToString(), M_str_Name);//設定小時
            WritePrivateProfileString("Set", "Min", nudown_Min.Value.ToString(), M_str_Name);//設定分鐘
            MessageBox.Show("設定文件設定成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();//啟動計時器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == nudown_Hour.Value && DateTime.Now.Minute == nudown_Min.Value)
            {
                string P_str_Floder = txt_Floder.Text;//記錄資料夾路徑
                string P_str_Excel = txt_Path.Text;//記錄Excel文件路徑
                List<string> P_list_FileNames = new List<string>();//實例化泛型集合對象，用來存儲所有上報的文件
                P_list_FileNames = GetAllFile(P_str_Floder);//取得所有指定類型的文件
                for (int j = 0; j < P_list_FileNames.Count; j++)//深度搜尋所有上報的文件
                {
                    ReadDataToExcel(P_list_FileNames[j], P_str_Excel);//將上報的文件資料處理到Excel
                }
                CloseProcess("EXCEL");//關閉所有Excel進程
                MessageBox.Show("程式在" + DateTime.Now.ToShortTimeString() + "分時自動將各地上報的結果處理到了Excel中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();//停止計時器
        }

        private List<string> GetAllFile(string P_str_Floder)//取得指定資料夾中的所有txt文件
        {
            List<string> P_list_FileNames = new List<string>();//實例化泛型集合對象，用來存儲所有深度搜尋的文件
            string[] P_str_Files = Directory.GetFiles(P_str_Floder);//取得指定資料夾中的所有文件
            for (int i = 0; i < P_str_Files.Length; i++)//深度搜尋取得到的文件
            {
                FileInfo FInfo = new FileInfo(P_str_Files[i]);//實例化FileInfo對像
                if (FInfo.Extension.ToLower() == ".txt")//判斷文件是否是txt文件
                {
                    P_list_FileNames.Add(FInfo.FullName);//將文件新增到泛型集合中
                }
            }
            return P_list_FileNames;//返回泛型集合對像
        }

        private void ReadDataToExcel(string P_str_File, string P_str_Excel)
        {
            int P_int_Count = 0;//記錄正在讀取的行數
            string P_str_Line;//記錄讀取行的內容
            List<string> P_str_List = new List<string>();//存儲讀取的所有內容
            StreamReader SReader = new StreamReader(P_str_File, Encoding.Default);//實例化流讀取對像
            while ((P_str_Line = SReader.ReadLine()) != null)//循環讀取文字文件中的每一行
            {
                P_str_List.Add(P_str_Line);//將讀取到的行內容新增到泛型集合中
                P_int_Count++;//使目前讀取行數加1
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            object missing = System.Reflection.Missing.Value;//取得缺少的object類型值
            //打開指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //新增一個新的工作表
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
            newWorksheet.Name = DateTime.Now.ToString("yyyyMMddhhmmss") + DateTime.Now.Millisecond;//以目前時間作為工作表名稱
            excel.Application.DisplayAlerts = false;//不顯示提示對話框
            for (int i = 0; i < P_str_List.Count; i++)//深度搜尋泛型集合
            {
                newWorksheet.Cells[i + 1, 1] = P_str_List[i];//直接將深度搜尋到的內容新增到工作表中
            }
            workbook.Save();//儲存工作表
            workbook.Close(false, missing, missing);//關閉工作表
        }

        private void CloseProcess(string P_str_Process)//關閉進程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//實例化進程對像
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
        }
    }
}