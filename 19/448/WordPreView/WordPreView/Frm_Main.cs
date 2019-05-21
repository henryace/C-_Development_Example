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

namespace WordPreView
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

        private void btn_Open_Click(object sender, EventArgs e)
        {
            btn_Open.Enabled = false;//將打開按鈕設定為不可用
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = //建立應用程式對像
                         new Microsoft.Office.Interop.Word.Application();
                    G_wa.Visible = true;//將文件檔設定為可見
                    object P_FileName = G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                        ref P_FileName, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing);
                    P_Document.PrintPreview();//開始預覽
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog = //建立打開文件對話框對像
                new OpenFileDialog();
            DialogResult P_DialogResult =//瀏覽文件
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇文件
            {
                btn_Open.Enabled = true;//啟用打開按鈕
                txt_path.Text = //顯示選擇文件
                    G_OpenFileDialog.FileName;
            }
        }
    }
}
