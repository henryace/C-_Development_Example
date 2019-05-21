using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;

namespace NewWord
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
            btn_New.Enabled = false;//將新建按鈕設定為不可用
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式物件
                    object P_obj = "Normal.dot";//定義文檔模板
                    Word.Document P_wd = G_wa.Documents.Add();
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
            G_FolderBrowserDialog = //建立瀏覽資料夾物件
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
            G_wa = //建立應用程式物件
                new Microsoft.Office.Interop.Word.Application();
            G_wa.Visible = true;//將文檔設定為可見
            Word.Document P_Document = G_wa.Documents.Open(//打開Word文檔
                ref G_str_path, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing);
        }
    }
}
