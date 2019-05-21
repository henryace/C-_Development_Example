using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace SQLToWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private Word.Application G_wa;//定義Word應用程式欄位
        private object G_missing = //定義G_missing欄位並新增參考
            System.Reflection.Missing.Value;
        private FolderBrowserDialog G_FolderBrowserDialog;//定義瀏覽資料夾欄位
        private object G_str_path;//定義文件儲存路徑欄位

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
                    
                    Word.Document P_wd = G_wa.Documents.Add();
                    Word.Range P_Range = P_wd.Range(//得到文件檔範圍
                        ref G_missing, ref G_missing);
                    string P_Server = string.Empty;//定義字串變數用於存放伺服器訊息
                    string P_DataBase = string.Empty;//定義字串變數用於存放資料庫名稱
                    string P_UserName = string.Empty;//定義字串變數用於存放用戶名
                    string P_PassWord = string.Empty;//定義字串變數用於存放密碼
                    this.Invoke(
                        (MethodInvoker)(() =>
                        {
                            P_Server = txt_Server.Text;//得到資料庫伺服器訊息
                            P_DataBase = txt_DataBase.Text;//得到資料庫名稱
                            P_UserName = txt_UserName.Text;//得到資料庫用戶名
                            P_PassWord = txt_PassWord.Text;//得到資料庫密碼
                        }));
                    DataTier P_DataTier = new DataTier(//建立資料層對像
                        P_Server, P_DataBase, P_UserName, P_PassWord);
                    List<string> P_List_Str = P_DataTier.GetMessage();//得到資料集合
                    foreach (string P_str in P_List_Str)//深度搜尋資料集合
                    {
                        P_Range.Text += P_str;//向文件檔中新增資料
                    }
                    G_str_path = string.Format(//計算文件儲存路徑
                        @"{0}\{1}", G_FolderBrowserDialog.SelectedPath,
                        DateTime.Now.ToString("yyyy年M月d日h時s分m秒fff毫秒") + ".doc");
                    P_wd.SaveAs(//儲存Word文件
                        ref G_str_path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            MessageBox.Show(//提示已經建立Word
                                "成功建立Word文件檔！", "提示！");
                            btn_display.Enabled = true;//啟用顯示按鈕
                        }));
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog = //建立瀏覽資料夾對像
                new FolderBrowserDialog();
            DialogResult P_DialogResult =//瀏覽資料夾
                G_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇資料夾
            {
                btn_New.Enabled = true;//啟用新建按鈕
                txt_path.Text = //顯示選擇路徑
                    G_FolderBrowserDialog.SelectedPath;
            }
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            G_wa = //建立應用程式對像
                new Microsoft.Office.Interop.Word.Application();
            G_wa.Visible = true;//將文件檔設定為可見
            Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                ref G_str_path, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing);
        }
    }
}
