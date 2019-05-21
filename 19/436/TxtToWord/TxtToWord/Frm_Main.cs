using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace TxtToWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Word.Application G_wa;//定義Word應用程式欄位
        private object G_missing = //定義missing欄位並賦值
            System.Reflection.Missing.Value;
        private object G_str_path;//定義檔案儲存路徑欄位
        private FolderBrowserDialog G_FolderBrowserDialog;//定義資料夾瀏覽對話框欄位
        private OpenFileDialog G_OpenFileDialog;

        private void btn_Select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog =//建立瀏覽資料夾對像
              new FolderBrowserDialog();
            DialogResult P_DialogResult = //瀏覽資料夾
                G_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇資料夾
            {
                btn_New.Enabled = true;//啟用新建按鈕
                txt_path.Text = //顯示選擇路徑
                    G_FolderBrowserDialog.SelectedPath;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按鈕
            ThreadPool.QueueUserWorkItem(//使用線程池
                (P_temp) =>//使用lambda表達式
                {
                    G_wa = new Word.Application();//建立Word應用程式對像
                    Word.Document P_wd = G_wa.Documents.Add(//建立新檔案檔
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;
                    using (StreamReader P_StreamReader =//建立流讀取器對像
                        new StreamReader(G_OpenFileDialog.FileName, Encoding.Default))
                    {
                        P_Range.Text = P_StreamReader.ReadToEnd();
                    }
                    G_str_path = string.Format(//計算檔案儲存路徑
                        @"{0}\{1}", G_FolderBrowserDialog.SelectedPath,
                        DateTime.Now.ToString("yyyy年M月d日h時s分m秒fff毫秒") + ".doc");
                    P_wd.SaveAs(//儲存Word檔案
                        ref G_str_path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//開始執行視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            btn_Display.Enabled = true;//啟用顯示按鈕
                            MessageBox.Show("成功建立Word檔案檔！", "提示！");//彈出消息對話框
                        }));
                });
        }

        private void btn_Display_Click(object sender, EventArgs e)
        {
            G_wa = //建立應用程式對像
                 new Microsoft.Office.Interop.Word.Application();
            G_wa.Visible = true;//將檔案檔設定為可見
            Word.Document P_Document = G_wa.Documents.Open(//打開Word檔案檔
                ref G_str_path, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing);
        }

        private void btn_txt_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog = new OpenFileDialog();//建立檔案對話框對像
            G_OpenFileDialog.Filter = "*.txt|*.txt";//篩選檔案
            DialogResult P_DialogResult = //顯示檔案對話框
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇檔案
            {
                txt_TxtPath.Text = //顯示打開檔案路徑
                    G_OpenFileDialog.FileName;
                btn_Select.Enabled = true;//啟用瀏覽按鈕
            }
        }
    }
}
