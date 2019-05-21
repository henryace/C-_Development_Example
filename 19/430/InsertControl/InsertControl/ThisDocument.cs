using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace InsertControl
{
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            Word.Range P_Range1 = this.Paragraphs[1].Range;								//得到文件檔範圍
            Microsoft.Office.Tools.Word.Controls.Button P_btn =								//向文件檔中新增按鈕
                this.Controls.AddButton(P_Range1, 50, 20, "button1");
            P_btn.Text = "Button按鈕";												//設定按鈕內容
            P_btn.Height = 50;													//設定按鈕高度
            P_btn.Width = 100;													//設定按鈕寬度
            P_btn.Click += new EventHandler(P_btn_Click);									//新增按一下事件

        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion

        void P_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("感謝您對明日圖書的支持！", "提示！");//彈出消息對話框
        }
    }
}
