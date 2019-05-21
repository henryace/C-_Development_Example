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

namespace WordToMulti_Txt
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

        private void btn_split_Click(object sender, EventArgs e)
        {
            btn_split.Enabled = false;//停用分解按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
                    object P_OpenFileDialog = //建立object對像
                        G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                        ref P_OpenFileDialog, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    bool P_bl = false; ;
                    this.Invoke(//呼叫視窗線程
                         (MethodInvoker)(() =>//使用lambda表達式
                         {
                             P_bl = cbox_Select.SelectedIndex == 0;
                         }));
                    if (P_bl)//判斷使用什麼方式分割文件檔
                    {
                        foreach (Word.Paragraph Paragraph in G_wa.ActiveDocument.Paragraphs)
                        {
                            AddFile(Paragraph.Range.Text);//將文字內容寫入文字檔案
                        }
                    }
                    else
                    {
                        Word.Range P_Range = G_wa.ActiveDocument.Content;//得到文件檔區域
                        int P_int_count = P_Range.Text.Length;//得到文件檔字符總長度
                        int P_int_i = P_int_count / 100;//計算循環建立文件檔次數
                        if (P_int_i > 0)//如果文件檔內文字大於100個
                        {
                            for (int i = 0; i < P_int_i; i++)//開始循環建立文件檔
                            {
                                object P_o1 = i == 0 ? 0 : i * 100 + 1;//複製文件檔範圍的開始部份
                                object P_o2 = i * 100 + 101;//複製文件檔範圍的結尾部份
                                Word.Range P_Range_temp = //得到文件檔的範圍
                                    G_wa.ActiveDocument.Range(ref P_o1, ref P_o2);
                                AddFile(P_Range_temp.Text);//將文字內容寫入文字檔案
                            }
                            object P_o11 = P_int_i * 100 + 1;//複製文件檔範圍的開始部份
                            Word.Range P_Range_temp1 = //得到文件檔的範圍
                                G_wa.ActiveDocument.Range(ref P_o11, ref G_missing);
                            AddFile(P_Range_temp1.Text);//將文字內容寫入文字檔案
                        }
                        else
                        {
                            Word.Range P_Range2 = //得到文件檔區域
                                G_wa.ActiveDocument.Content;
                            AddFile(P_Range2.Text);//將文字內容寫入文字檔案
                        }
                    }
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            Clipboard.Clear();//清空剪下板
                            MessageBox.Show(//彈出消息對話框
                                "成功分解Word文件檔！", "提示！");
                            btn_split.Enabled = true;//啟用分解按鈕
                        }));
                });
        }

        /// <summary>
        /// 建立文字檔案方法
        /// </summary>
        private void AddFile(string text)
        {
            string G_str_path = string.Format(//計算檔案儲存路徑
                     @"{0}\{1}", G_FolderBrowserDailog.SelectedPath,
                     DateTime.Now.ToString("yyyy年M月d日h時m分s秒fff毫秒") + ".txt");
            using (StreamWriter P_StreamWriter =
                 new StreamWriter(G_str_path, true))
            {
                P_StreamWriter.Write(text);
                P_StreamWriter.Flush();
            }
            Thread.Sleep(5);
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
                btn_split.Enabled = true;//啟用分割按鈕
                txt_SavePath.Text = //顯示選擇路徑
                    G_FolderBrowserDailog.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbox_Select.SelectedIndex = 0;//設定預設選擇第一項
        }
    }
}
