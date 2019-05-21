using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelToWinForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 打開Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            OpenFileDialog.Title = "打開Excel文件";//設定打開對話框標題
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                WBrowser_Excel.Navigate(OpenFileDialog.FileName);//在視窗中顯示Excel文件內容
            }
        }
    }
}
