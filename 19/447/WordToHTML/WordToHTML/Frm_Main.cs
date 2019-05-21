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

namespace WordToHTML
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
        private object G_FilePath;//定義文件檔路徑欄位

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = //建立打開文件對話框對像
                new OpenFileDialog();
            P_OpenFileDialog.Filter = "*.doc|*.doc";
            DialogResult P_DialogResult =//瀏覽資料夾
                P_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇資料夾
            {
                btn_New.Enabled = false;//停用新建按鈕
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
                                btn_SaveAs.Enabled = true;//啟用轉換按鈕
                            }));
                    });
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按鈕
            btn_Open.Enabled = false;//停用打開按鈕
            FolderBrowserDialog P_FolderBrowserDialog = //建立瀏覽資料夾對像
                new FolderBrowserDialog();
            DialogResult P_DialogResult = //彈出瀏覽資料夾對話框
                P_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判斷是否確認選擇資料夾
            {
                G_FilePath = string.Format(//計算文件儲存路徑
                    @"{0}\{1}", P_FolderBrowserDialog.SelectedPath,
                    DateTime.Now.ToString("yyyy年M月d日h時m分s秒fff毫秒") + ".doc");
                ThreadPool.QueueUserWorkItem(//開始線程池
                    (pp) =>//使用lambda表達式
                    {
                        G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
                        G_wa.Visible = true;//將文件檔設定為可見
                        object P_obj = "Normal.dot";//定義文件檔模板
                        Word.Document P_wd = G_wa.Documents.Add(//向Word應用程式中新增文件檔
                            ref P_obj, ref G_missing, ref G_missing, ref G_missing);
                        P_wd.SaveAs(//儲存Word文件
                            ref G_FilePath,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing);
                        this.Invoke(//視窗線程
                            (MethodInvoker)(() =>//使用Lambda表達式
                            {
                                btn_SaveAs.Enabled = true;//啟用轉換按鈕
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
            SaveFileDialog P_SaveFileDialog = //建立儲存文件對話框對像
                new SaveFileDialog();
            P_SaveFileDialog.Filter = "*.html|*.html";//篩選文件擴展名
            DialogResult P_DialogResult = //打開儲存文件對話框
                P_SaveFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判斷是否確認儲存文件
            {
                object P_str_path = P_SaveFileDialog.FileName;//建立object對像
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
                        object P_Format = Word.WdSaveFormat.wdFormatHTML;//建立儲存文件檔參數
                        P_wd.SaveAs(//儲存Word文件
                            ref P_str_path,
                            ref P_Format, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing);
                        ((Word._Application)G_wa.Application).Quit(//退出應用程式
                            ref G_missing, ref G_missing, ref G_missing);
                        this.Invoke(//呼叫視窗線程
                            (MethodInvoker)(() =>//使用lambda表達式
                            {
                                btn_Open.Enabled = true;//啟用打開按鈕
                                btn_New.Enabled = true;//啟用新建按鈕
                                MessageBox.Show(//提示已經建立Word
                                    "文件已經建立", "提示！");
                            }));
                    });
            }
        }
    }
}
