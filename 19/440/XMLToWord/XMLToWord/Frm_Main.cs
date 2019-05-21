using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace XMLToWord
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
            G_FolderBrowserDialog =//建立瀏覽資料夾對像
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
            btn_New.Enabled = false;//停用新建按鈕
            ThreadPool.QueueUserWorkItem(//使用線程池
                (P_temp) =>//使用lambda表達式
                {
                    G_wa = new Word.Application();//建立Word應用程式對像
                    Word.Document P_wd = G_wa.Documents.Add(//建立新文件檔
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;//得到文件檔段落範圍
                    XmlDocument P_XML = new XmlDocument();//建立XML對像
                    P_XML.Load("test.xml");//打開XML文件檔
                    XmlElement P_XmlElement = P_XML.DocumentElement;//得到XML根節點
                    XmlNodeList P_XmlNodeList = P_XmlElement.ChildNodes;//得到子節點集合
                    string P_Str_Message = string.Empty;//建立空字串對像
                    foreach (XmlNode xn in P_XmlNodeList)//遍例所有子節點
                    {
                        foreach (XmlNode xn2 in xn.ChildNodes)//遍例子節點中的節點
                        {
                            P_Str_Message += xn2.InnerText + " ";//得到字串訊息
                        }
                        P_Str_Message += "\r\n";
                    }
                    P_Range.Text = P_Str_Message;//向Word中新增字串訊息
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
            G_wa = //建立應用程式對像
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
