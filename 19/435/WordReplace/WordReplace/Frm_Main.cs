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

namespace WordReplace
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private OpenFileDialog G_OpenFileDialog;//定義打開文件對話框欄位
        private Word.Application G_WordApplication;//定義Word應用程式欄位
        private object G_Missing = //定義G_Missing欄位並新增參考
            System.Reflection.Missing.Value;

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog = new OpenFileDialog();//建立打開文件對話框物件
            G_OpenFileDialog.Filter = "*.doc|*.doc";//篩選文件
            DialogResult P_DialogResult =//彈出打開文件對話框
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認是否選擇文件
            {
                txt_Find.ReadOnly = false;//取消文字框的只讀狀態
                txt_Replace.ReadOnly = false;//取消文字框的只讀狀態
                txt_path.Text = G_OpenFileDialog.FileName;//顯示選擇文件的路徑
            }
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {
            if (txt_Replace.Text != string.Empty//如果文字框有內容則啟用開始替換按鈕
                && txt_Find.Text != string.Empty)
            {
                btn_Begin.Enabled = true;//啟用開始替換按鈕
            }
        }

        private void txt_Replace_TextChanged(object sender, EventArgs e)
        {
            if (txt_Replace.Text != string.Empty//如果文字框有內容則啟用開始替換按鈕
                && txt_Find.Text != string.Empty)
            {
                btn_Begin.Enabled = true;//啟用開始替換按鈕
            }
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            btn_Begin.Enabled = false;//停用替換按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (o) =>//使用Lambda表達式
                {
                    G_WordApplication =//建立Word應用程式物件
                         new Microsoft.Office.Interop.Word.Application();
                    object P_FilePath = G_OpenFileDialog.FileName;//建立Object物件
                    Word.Document P_Document = G_WordApplication.Documents.Open(//打開Word文件檔
                        ref P_FilePath, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing);
                    Word.Range P_Range = //得到文件檔範圍
                        P_Document.Range(ref G_Missing, ref G_Missing);
                    Word.Find P_Find = //得到Find物件
                        P_Range.Find;
                    this.Invoke(//在視窗線程中執行
                        (MethodInvoker)(() =>//使用Lambda表達式
                        {
                            P_Find.Text = txt_Find.Text;//設定搜尋的文字
                            P_Find.Replacement.Text = txt_Replace.Text;//設定替換的文字
                        }));
                    object P_Replace = Word.WdReplace.wdReplaceAll;//定義替換方式物件
                    bool P_bl = P_Find.Execute(//開始替換
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing, ref P_Replace,
                        ref G_Missing, ref G_Missing, ref G_Missing, ref G_Missing);
                    G_WordApplication.Documents.Save(//儲存文件檔
                        ref G_Missing, ref G_Missing);
                    ((Word._Document)P_Document).Close(//關閉文件檔
                        ref G_Missing, ref G_Missing, ref G_Missing);
                    ((Word._Application)G_WordApplication).Quit(//退出Word應用程式
                        ref G_Missing, ref G_Missing, ref G_Missing);
                    this.Invoke(//在視窗線程中執行
                        (MethodInvoker)(() =>//使用Lambda表達式
                        {
                            if (P_bl)//查看是否找到並替換
                            {
                                MessageBox.Show(//彈出消息對話框
                                    "找到字串並替換", "提示！");
                                btn_Display.Enabled = true;//啟用顯示文件按鈕
                            }
                            else
                            {
                                MessageBox.Show(//彈出消息對話框
                                    "沒有找到字串", "提示！");
                            }
                            btn_Begin.Enabled = true;//啟用開始替換按鈕
                        }));
                });
        }

        private void btn_Display_Click(object sender, EventArgs e)
        {
            btn_Display.Enabled = false;//停用顯示文件按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (o) =>//使用Lambda表達式
                {
                    G_WordApplication =//建立Word應用程式物件
                         new Microsoft.Office.Interop.Word.Application();
                    G_WordApplication.Visible = true;//Word應用程式可在桌面顯示
                    object P_FilePath = G_OpenFileDialog.FileName;//得到文件路徑訊息
                    Word.Document P_Document = G_WordApplication.Documents.Open(//打開文件
                        ref P_FilePath, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing, ref G_Missing, ref G_Missing,
                        ref G_Missing);
                    this.Invoke(//在視窗線程中執行
                        (MethodInvoker)(() =>
                        {
                            btn_Display.Enabled = true;//啟用顯示文件按鈕
                        }));
                });
        }
    }
}
