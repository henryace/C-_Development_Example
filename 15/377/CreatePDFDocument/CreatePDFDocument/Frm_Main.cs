using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CreatePDFDocument
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //該變數儲存PDF的文檔名
        public static string filePath = "";

        //建立PDF文檔
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); 				//給出文件儲存訊息，確定儲存位置
            saveFileDialog.Filter = "PDF文件（*.PDF）|*.PDF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                //開始建立PDF文檔，首先宣告一個Document物件
                Document document = new Document();
                //使用指定的路徑和建立模式初始化文件流物件
                PdfWriter.getInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();										//打開文檔
                BaseFont baseFont = BaseFont.createFont(@"c:\windows\fonts\SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20); 	//設定文檔字體樣式
                document.Add(new Paragraph(richTextBox1.Text, font)); 			//新增內容至PDF文檔中
                document.Close();										//關閉文檔
                MessageBox.Show("恭喜你，文件檔建立成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
