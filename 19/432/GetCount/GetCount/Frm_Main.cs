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
using Office = Microsoft.Office.Core;

namespace GetCount
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
        private OpenFileDialog G_OpenFileDialog;//定義瀏覽資料夾欄位

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_Get.Enabled = false;//停用統計按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式物件
                    object P_OpenFileDialog = //建立object物件
                        G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                        ref P_OpenFileDialog, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    int P_count = 0;//定義計數器並初始化為0
                    foreach (Word.Paragraph paragraph in P_Document.Paragraphs)
                    {
                        Word.Range P_Range_temp = paragraph.Range;//得到段落文字範圍
                        foreach (char P_chr in P_Range_temp.Text)//深度搜尋每一個字符
                        {
                            P_count = //計數器開始計數
                                P_chr.ToString() != "\r" ?
                                rbtn_Blank.Checked ? ++P_count :
                                P_chr.ToString() != " " ? ++P_count :
                                P_count : P_count;
                        }
                    }
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            MessageBox.Show(//提示已經建立Word
                                string.Format("{0}共{1}個字符",
                                rbtn_Blank.Checked ? "記空格" : "不記空格",
                                P_count.ToString()), "提示！");
                            btn_Get.Enabled = true;//啟用統計按扭
                        }));
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog//建立文件對話框物件
                = new OpenFileDialog();
            G_OpenFileDialog.Filter = //篩選文件
                "*.doc|*.doc";
            DialogResult P_DialogResult =//打開文件對話框
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇文件
            {
                btn_Get.Enabled = true;//啟用統計字符按鈕
                btn_display.Enabled = true;//啟用顯示文件檔按鈕
                txt_path.Text = //顯示將要打開的文件
                    G_OpenFileDialog.FileName;
            }
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                (P_P) =>
                {
                    G_wa = //建立應用程式物件
                       new Microsoft.Office.Interop.Word.Application();
                    G_wa.Visible = true;//將文件檔設定為可見
                    object P_str_filename = G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                        ref P_str_filename, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing);
                });
        }
    }
}
