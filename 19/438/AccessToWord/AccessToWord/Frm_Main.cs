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

namespace AccessToWord
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
            btn_New.Enabled = false;//停用新建按鈕
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Word.Application();//建立應用程式對像
                    object P_obj = "Normal.dot";//定義文檔模板
                    Word.Document P_wd = G_wa.Documents.Add();
                    Word.Range P_Range = P_wd.Range(//得到文檔範圍
                        ref G_missing, ref G_missing);
                    DataTier P_DataTier = new DataTier();//建立資料層對像
                    List<InstanceClass> P_List_InstanceClass //得到資料集合
                        = P_DataTier.GetMessage();
                    object o1 = Word.WdDefaultTableBehavior.//設定文檔中表格格式
                        wdWord8TableBehavior;
                    object o2 = Word.WdAutoFitBehavior.//設定文檔中表格格式
                        wdAutoFitWindow;
                    Word.Table P_WordTable = P_Range.Tables.Add(P_Range,//在文檔中新增表格
                        P_List_InstanceClass.Count + 2, 5, ref o1, ref o2);
                    P_WordTable.Cell(1, 1).Range.Text = "ID";//向表格中新增訊息
                    P_WordTable.Cell(1, 2).Range.Text = "姓名";//向表格中新增訊息
                    P_WordTable.Cell(1, 3).Range.Text = "語文成績";//向表格中新增訊息
                    P_WordTable.Cell(1, 4).Range.Text = "數學成績";//向表格中新增訊息
                    P_WordTable.Cell(1, 5).Range.Text = "英語成績";//向表格中新增訊息
                    for (int i = 2; i < P_List_InstanceClass.Count + 2; i++)
                    {
                        P_WordTable.Cell(i, 1).Range.Text =//向表格中新增訊息
                            P_List_InstanceClass[i - 2].id.ToString();
                        P_WordTable.Cell(i, 2).Range.Text =//向表格中新增訊息
                            P_List_InstanceClass[i - 2].Name;
                        P_WordTable.Cell(i, 3).Range.Text =//向表格中新增訊息
                            P_List_InstanceClass[i - 2].Chinese.ToString();
                        P_WordTable.Cell(i, 4).Range.Text =//向表格中新增訊息
                            P_List_InstanceClass[i - 2].Math.ToString();
                        P_WordTable.Cell(i, 5).Range.Text =//向表格中新增訊息
                            P_List_InstanceClass[i - 2].English.ToString();
                    }
                    float P_Chinese = 0;//定義變數用於計算資料列
                    float P_Math = 0;//定義變數用於計算資料列
                    float P_English = 0;//定義變數用於計算資料列
                    P_List_InstanceClass.
                        ForEach((Instance) =>//使用Lambda表達式
                        {
                            P_Chinese += ((InstanceClass)Instance).Chinese;//計算資料列
                            P_Math += ((InstanceClass)Instance).Math;//計算資料列
                            P_English += ((InstanceClass)Instance).English;//計算資料列
                        });
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2,//向表格中新增訊息
                        1).Range.Text = "科目總成績";
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2, 3).//向表格中新增訊息
                        Range.Text = P_Chinese.ToString();
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2, 4).//向表格中新增訊息
                        Range.Text = P_Math.ToString();
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2, 5).//向表格中新增訊息
                        Range.Text = P_English.ToString();
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
                            MessageBox.Show(//彈出消息對話框
                                "成功建立Word文檔！", "提示！");
                            btn_display.Enabled = true;//啟用顯示按鈕
                        }));
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog = //建立瀏覽資料夾對像
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
            G_wa = //建立應用程式對像
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
