using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace AddTable
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
        private object G_str_path;//定義文件儲存路徑欄位
        private FolderBrowserDialog G_FolderBrowserDialog;//定義資料夾瀏覽對話框欄位

        private void btn_Select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog =//建立瀏覽資料夾物件
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
            G_ToolProgressBar.Minimum = 1;//設定進度列最小值
            G_ToolProgressBar.Maximum = //設定進度列最大值
                int.Parse(txt_row.Text) + 1;
            btn_New.Enabled = false;//停用新建按鈕
            ThreadPool.QueueUserWorkItem(//使用線程池
                (P_temp) =>//使用lambda表達式
                {
                    G_wa = new Word.Application();//建立Word應用程式物件
                    Word.Document P_wd = G_wa.Documents.Add(//建立新文件檔
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;//得到文件檔範圍物件
                    object P_DefaultTable = //建立表格參數物件
                        Word.WdDefaultTableBehavior.wdWord8TableBehavior;
                    object P_AutoFit = //建立表格參數物件
                        Word.WdAutoFitBehavior.wdAutoFitWindow;
                    Word.Table P_WordTable = P_Range.Tables.Add(//向文件檔中新增表格
                        P_Range,
                        int.Parse(txt_row.Text),
                        int.Parse(txt_column.Text),
                        ref P_DefaultTable, ref P_AutoFit);
                    for (int i = 1; i < int.Parse(txt_row.Text) + 1; i++)
                    {
                        for (int j = 1; j < int.Parse(txt_column.Text) + 1; j++)
                        {
                            P_WordTable.Cell(i, j).Range.Text =//使用雙層循環向表格中新增資料
                                string.Format("{0}行 {1}列", i.ToString(), j.ToString());
                            Thread.Sleep(10);//線程掛起10毫秒
                        }
                        this.Invoke(//呼叫視窗線程
                            (MethodInvoker)(() => //使用Lambda表達式
                            {
                                G_ToolProgressBar.Value = i + 1;//設定進度訊息
                            }));
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
                    this.Invoke(//開始執行視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            btn_Display.Enabled = true;//啟用顯示按鈕
                            MessageBox.Show("成功建立Word文件檔！", "提示！");
                        }));
                });
        }

        private void btn_Display_Click(object sender, EventArgs e)
        {
            G_wa = //建立應用程式物件
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