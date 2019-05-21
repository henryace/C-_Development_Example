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
using System.IO;

namespace WordToTxt
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
        private OpenFileDialog G_OpenFileDialog;//定義打開檔案對話框欄位
        private FolderBrowserDialog G_FolderBrowserDailog;//定義瀏覽資料夾對話框欄位

        private void btn_Get_Click(object sender, EventArgs e)
        {
            btn_Get.Enabled = false;//啟用建立按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
                    object P_OpenFileDialog = //建立object對像
                        G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文檔
                        ref P_OpenFileDialog, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_Document.Range(
                        ref G_missing, ref G_missing);
                    string P_Str = P_Range.Text;
                    string G_str_path = string.Format(//計算檔案儲存路徑
                     @"{0}\{1}", G_FolderBrowserDailog.SelectedPath,
                     DateTime.Now.ToString("yyyy年M月d日h時m分s秒fff毫秒") + ".txt");
                    using (StreamWriter P_StreamWrite = new StreamWriter(//建立StreamWriter對像
                        G_str_path, true))
                    {
                        P_StreamWrite.Write(P_Str);//向檔案中寫入字串
                        P_StreamWrite.Flush();//將訊息寫入基礎流
                    }
                    ((Word._Document)P_Document).Close(ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            Clipboard.Clear();//清空剪下板
                            MessageBox.Show(//提示已經建立Word
                                "成功建立文字檔案！", "提示！");
                            btn_Get.Enabled = true;//停用建立按鈕
                        }));
                });
        }


        private void txt_select_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog//建立檔案對話框對像
                = new OpenFileDialog();
            G_OpenFileDialog.Filter = //篩選檔案
                "*.doc|*.doc";
            DialogResult P_DialogResult =//打開檔案對話框
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇檔案
            {
                btn_Save.Enabled = true;
                txt_path.Text = //顯示將要打開的檔案
                    G_OpenFileDialog.FileName;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDailog = //建立瀏覽資料夾對像
                new FolderBrowserDialog();
            DialogResult P_DialogResult = //打開瀏覽資料夾對話框
                G_FolderBrowserDailog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判斷是否選擇資料夾
            {
                btn_Get.Enabled = true;//啟用分割按鈕
                txt_SavePath.Text = //顯示選擇路徑
                    G_FolderBrowserDailog.SelectedPath;
            }
        }
    }
}
