using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace GetDirectry
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
        private object G_FilePath = string.Empty;//定義文件檔路徑並賦值
        private SaveFileDialog G_SaveFileDialog;//定義打開文件對話框欄位



        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = //建立打開文件對話框對像
                new OpenFileDialog();
            P_OpenFileDialog.Filter = "*.doc|*.doc";
            DialogResult P_DialogResult =//瀏覽資料夾
                P_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇資料夾
            {
                btn_Open.Enabled = false;//停用打開按鈕
                G_FilePath = P_OpenFileDialog.FileName;
                ThreadPool.QueueUserWorkItem(//開始線程池
                    (pp) =>//使用Lambda表達式
                    {
                        G_wa = //建立應用程式對像
                             new Microsoft.Office.Interop.Word.Application();
                        G_wa.Visible = true;//將文件檔設定為可見
                        Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                           ref G_FilePath, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing);
                        this.Invoke(//視窗線程
                            (MethodInvoker)(() =>//使用Lambda表達式
                            {
                                btn_Path.Enabled = true;//啟用瀏覽按鈕
                            }));
                    });
            }
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            btn_SaveAs.Enabled = false;//停用轉換按鈕
            try
            {
                G_wa.ActiveDocument.Save();//儲存文件檔
                ((Word._Application)G_wa.Application).Quit(//退出應用程式
                  ref G_missing, ref G_missing, ref G_missing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ThreadPool.QueueUserWorkItem(//開始線程澉
                (pp) =>//使用Lambda表達式
                {
                    G_wa = //建立應用程式對像
                      new Microsoft.Office.Interop.Word.Application();
                    G_wa.Visible = false;
                    Word.Document P_wd = G_wa.Documents.Open(//打開Word文件檔
                       ref G_FilePath, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                       ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                       ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                       ref G_missing);
                    Word.Document P_document = G_wa.Documents.Add(//新增新的Word文件檔
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    object P_start = 0;//定義範圍的開始位置
                    object p_end = 0;//定義範圍的結束位置
                    Word.Range rg = //得到文件檔的範圍
                        P_wd.Range(ref P_start, ref p_end);
                    WordToWord(P_wd, P_document, rg);//將目錄提取到新文件檔中
                    object P_str_path = G_SaveFileDialog.FileName;//設定儲存的文件名稱
                    P_document.SaveAs(//儲存Word文件
                        ref P_str_path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    object P_Save = false;//設定參數為不儲存
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref P_Save, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            btn_Open.Enabled = true;//啟用打開按鈕
                            Clipboard.Clear();//清空剪下板訊息
                            MessageBox.Show(//提示已經建立Word
                                "目錄已經提取完成！", "提示！");
                        }));
                });
        }

        /// <summary>
        /// 將目錄提取到新文件檔中
        /// </summary>
        /// <param name="P_wd">將要提取目錄的文件檔</param>
        /// <param name="P_document">新建文件檔</param>
        /// <param name="rg">文件檔範圍</param>
        private void WordToWord(Word.Document P_wd, Word.Document P_document, Word.Range rg)
        {
            object P_start = System.Reflection.Missing.Value;
            object p_end = System.Reflection.Missing.Value;
            object P_UseHeadingStyles = true;//是否使用內置樣式建立目錄
            object P_UpperHeadingLevel = 1;//目錄起始的標題級別
            object P_LowerHeadingLevel = 9;//目錄結束的標題級別
            object P_UseFields = false;//是否使用TC(目錄項)建立目錄
            object P_TableID = 1;//單字母標識符，用於根據TC域建立目錄
            object P_RightAlignPageNumbers = false;//目錄是否右邊距對齊
            object P_IncludePageNumbers = false;//目錄中是否包含頁碼
            object P_AddedStyles = null;//目錄其它樣式的字串名稱
            object P_UseHyperlinks = false;//是否將文件檔發佈到WEB
            object P_HidePageNumbersInWeb = false;//目錄中的頁碼是否被隱藏
            P_wd.TablesOfContents.Add(rg, ref P_UseHeadingStyles,//將提取的目錄插入到文件檔的開始位置
                ref P_UpperHeadingLevel, ref P_LowerHeadingLevel,
                ref P_UseFields, ref P_TableID, ref P_RightAlignPageNumbers,
                ref P_IncludePageNumbers, ref P_AddedStyles, ref P_UseHyperlinks,
                ref P_HidePageNumbersInWeb, ref G_missing);
            if (P_wd.Fields.Count >= 1)
            {
                P_wd.Paragraphs[1].Range.Cut();//剪下文件檔開始位置的目錄訊息
                P_document.Range(ref P_start, ref p_end).Paste();//將目錄訊息貼上到新文件檔
            }
        }

        private void btn_Path_Click(object sender, EventArgs e)
        {
            G_SaveFileDialog = new SaveFileDialog();//建立儲存文件對話框對像 
            G_SaveFileDialog.Filter = "*.doc|*.doc";//篩選文件
            DialogResult P_DialogResult = //打開儲存文件對話框
                G_SaveFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判斷是否儲存文件
            {
                btn_SaveAs.Enabled = true;//啟用儲存按鈕
                txt_Path.Text = G_SaveFileDialog.FileName;//顯示儲存文件位置
            }
        }
    }
}
