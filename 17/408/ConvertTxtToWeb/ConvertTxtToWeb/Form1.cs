using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConvertTxtToWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strContent = "明日科技有限公司是一家以計算機軟體技術為核心的高科技企業，多年來始終致力於行業管理軟體開發、數字化出版物製作、計算機網絡系統綜合應用以及行業電子商務網站開發領域，涉及生產、管理、控制、倉儲、物流、營銷、服務等行業。公司擁有軟體開發和項目實施方面的資深專家和學習型技術團隊，多年來積累了豐富的技術文檔和學習資料，公司的開發團隊不僅是開拓進取的技術實踐者，更致力於成為技術的普及和傳播者。";
                string strCompany = "吉林省明日科技有限公司";
                string strWeb = "www.mingrisoft.com";
                string strFileName = "公司網頁.htm";
                richTextBox1.Clear();
                richTextBox1.AppendText("<HTML>");
                richTextBox1.AppendText("<HEAD>");
                richTextBox1.AppendText("<TITLE>");
                richTextBox1.AppendText(strCompany);
                richTextBox1.AppendText("</TITLE>");
                richTextBox1.AppendText("</HEAD>");
                richTextBox1.AppendText("<BODY BGCOLOR='TAN'>");
                richTextBox1.AppendText("<CENTER>");
                richTextBox1.AppendText("<H2>" + strCompany + "</H2>");
                String strHyper = "<H4><A HREF='" + strWeb + "'>歡迎訪問明日科技公司網站：";
                richTextBox1.AppendText(strHyper + strWeb + "</A></H4>");
                richTextBox1.AppendText("</CENTER>");
                richTextBox1.AppendText(strContent);
                richTextBox1.AppendText("</BODY>");
                richTextBox1.AppendText("</HTML>");
                richTextBox1.SaveFile(strFileName, RichTextBoxStreamType.PlainText);
                System.Diagnostics.Process.Start(strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
