using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

namespace ApplicationInWord
{
    public partial class ThisDocument
    {
        #region 私有欄位
        private object G_Missing = System.Reflection.Missing.Value;//建立Missing對像
        private List<Student> G_List_Student = new List<Student>();//建立集合對像
        private TextBox G_Txt_Name;//定義TextBox類型欄位
        private TextBox G_Txt_Age;//定義TextBox類型欄位
        private TextBox G_Txt_Chinese;//定義TextBox類型欄位
        private TextBox G_Txt_Math;//定義TextBox類型欄位
        private TextBox G_Txt_English;//定義TextBox類型欄位
        private DataGridView G_Dgv_Data;//定義DataGridView類型欄位
        #endregion

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            #region 新增姓名文字框
            Word.Range P_Range = //得到文檔區域
                this.ActiveWindow.Document.Range(ref G_Missing, ref G_Missing);
            P_Range.Text = "姓名：    ";//新增文字內容
            object P_Range_O = Word.WdCollapseDirection.wdCollapseEnd;//建立折疊參數對像
            P_Range.Collapse(ref P_Range_O);//折疊Range
            G_Txt_Name = //新增控制元件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Name");
            #endregion
            #region 新增年齡文字框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs[this.Paragraphs.Count - 1].Range;//得到最後一個段落
            G_Txt_Age = //新增控制元件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Age");
            P_Range = this.Paragraphs[this.Paragraphs.Count - 1].Range;//得到最後一個段落
            object P_Range_O2 = Word.WdCollapseDirection.wdCollapseStart;//建立折疊參數對像
            P_Range.Collapse(ref P_Range_O2);//折疊Range
            P_Range.Text = "年齡：    ";//新增文字
            #endregion
            AddControl(P_Range, P_Range_O);//向文檔中新增控制元件
        }

        private void AddControl(Word.Range P_Range, object P_Range_O)
        {
            #region 新增語文成績文字框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;
            P_Range.Text = "語文成績：";
            P_Range.Collapse(ref P_Range_O);
            G_Txt_Chinese = this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Chinese");
            #endregion

            #region 新增數學成績文字框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最後一個段落
            P_Range.Text = "數學成績：";//新增文字內容
            P_Range.Collapse(ref P_Range_O);//折疊Range
            G_Txt_Math = //新增控制元件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Math");
            #endregion

            #region 新增英語成績文字框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最後一個段落
            P_Range.Text = "英語成績：";//新增文字內容
            P_Range.Collapse(ref P_Range_O);//折疊Range
            G_Txt_English = //新增控制元件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_English");
            #endregion

            #region 新增按鈕
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最後一個段落
            Button P_Btn_OK = //新增按鈕控制元件
                this.Controls.AddButton(P_Range, 100, 20, "P_Btn_OK");
            P_Btn_OK.Click += //為按鈕新增事件
                new EventHandler(P_Btn_OK_Click);
            P_Btn_OK.Text = "新增";//設定按鈕文字內容
            #endregion

            #region 新增文字內容
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最後一個段落
            P_Range.Text = "顯示資料：";//顯示文字訊息
            #endregion

            #region 新增DataGridView控制元件
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//新增新段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最後一個段落
            G_Dgv_Data = //新增控制元件
                this.Controls.AddDataGridView(P_Range, 400, 200, "P_Dgv");
            G_Dgv_Data.DataSource = G_List_Student;//將資料繫結到DataGridView控制元件
            #endregion
        }


        /// <summary>
        /// 點擊鼠標按鈕事件
        /// </summary>
        /// <param name="sender">按鈕對像</param>
        /// <param name="e">事件參數</param>
        void P_Btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                G_List_Student.Add(new Student()//為集合新增對像
                {
                    Name = G_Txt_Name.Text,
                    Age = int.Parse(G_Txt_Age.Text),
                    Chinese = double.Parse(G_Txt_Chinese.Text),
                    Math = double.Parse(G_Txt_Math.Text),
                    English = double.Parse(G_Txt_English.Text)
                });
                G_Dgv_Data.DataSource = null;//繫結資料為空
                G_Dgv_Data.DataSource = G_List_Student;//繫結到集合
                Clear();//清空TextBox控制元件中的文字內容
            }
            catch (Exception ex)
            {
                MessageBox.Show("請添入正確的數值！\r\n" + ex.Message, "錯誤！");
            }
        }

        /// <summary>
        /// 清空所有文字框方法
        /// </summary>
        void Clear()
        {
            foreach (Control c in Controls)//深度搜尋控制元件集合
            {
                TextBox P_TextBox = c as TextBox;//將Control對像轉換為TextBox對像
                if (P_TextBox != null)//是否轉換成功
                {
                    P_TextBox.Clear();//清空控制元件中的文字訊息
                }
            }
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO 設計器產生的程式碼

        /// <summary>
        /// 設計器支持所需的方法 - 不要
        /// 使用程式碼編輯器修改此方法的內容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
