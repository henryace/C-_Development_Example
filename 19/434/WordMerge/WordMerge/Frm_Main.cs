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

namespace WordMerge
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Word.Application G_wa;//定義Word應用程式
        private object G_missing = //定義G_missing欄位並新增參考
            System.Reflection.Missing.Value;
        private OpenFileDialog G_OpenFileDialog;//定義打開文件對話框
        private SaveFileDialog G_SaveFileDialog;//定義儲存文件對話框
        private List<string> G_Str_Files = new List<string>();//定義字串集合

        private void btn_split_Click(object sender, EventArgs e)
        {
            btn_Merge.Enabled = false;//停用合併按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式物件
                    Word.Document P_MainDocument =//新建合併文件檔物件
                        G_wa.Documents.Add(ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing);
                    foreach (string P_Str in G_Str_Files)//深度搜尋文件檔的集合
                    {
                        object P_strs = P_Str;//建立object物件
                        Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                            ref P_strs, ref G_missing, ref G_missing, ref G_missing
                            , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                            , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                            , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                        Word.Range P_Range_temp = //得到文件檔全部範圍
                            P_Document.Range(ref G_missing, ref G_missing);
                        P_Range_temp.Select();//選擇文件檔全部範圍
                        P_Range_temp.Copy();//複製文件檔全部範圍
                        Word.Range P_Range_temp2 =//得到文件檔的範圍
                            P_MainDocument.Range(ref G_missing, ref G_missing);
                        object P_end = Word.WdCollapseDirection.wdCollapseEnd;//建立object物件
                        P_Range_temp2.Collapse(ref P_end);//折疊文件檔範圍
                        P_Range_temp2.Select();//選擇檔的最後位置
                        P_Range_temp2.Paste();//貼上文件檔內容
                        ((Word._Document)P_Document).Close(ref G_missing, ref G_missing,//關閉文件檔
                            ref G_missing);
                    }
                    object P_SavePath = G_SaveFileDialog.FileName;//建立object物件
                    P_MainDocument.SaveAs(//儲存合併後的文件檔
                        ref P_SavePath, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            Clipboard.Clear();//清空剪下板
                            MessageBox.Show(//提示已經建立Word
                                "成功合併Word文件檔！", "提示！");
                            btn_Merge.Enabled = true;//啟用合併按鈕
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
                lb_FileCollection.Items.Add(G_OpenFileDialog.FileName);
                G_Str_Files.Add(G_OpenFileDialog.FileName);
                btn_Save.Enabled = true;
                txt_path.Text = //顯示將要打開的文件
                    G_OpenFileDialog.FileName;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            G_SaveFileDialog = //建立儲存文件對話框物件
                new SaveFileDialog();
            G_SaveFileDialog.Filter = "*.doc|*.doc";
            DialogResult P_DialogResult = //打開儲存文件對話框
                G_SaveFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判斷是否儲存文件
            {
                btn_Merge.Enabled = true;//啟用合併按鈕
                txt_SavePath.Text = //顯示儲存文件路徑
                    G_SaveFileDialog.FileName;
            }
        }
    }
}
