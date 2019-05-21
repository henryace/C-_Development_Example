using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DisplayRTFFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string fileName = ""; //該變數用來儲存文件的內容
        private OpenFileDialog G_OpenFileDialog = //定義打開文件對話框欄位並賦值
            new OpenFileDialog();
        private SaveFileDialog G_SaveFileDialog = //定義儲存文件對話框欄位並賦值
            new SaveFileDialog();

        private void 打開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)Menu_Main.Items["文件ToolStripMenuItem"]).//停用儲存功能
                DropDownItems["儲存ToolStripMenuItem"].Enabled = false;
            G_OpenFileDialog.Filter = "RTF文件(*.RTF)|*.RTF";//設定打開文件的過濾參數
            if (G_OpenFileDialog.ShowDialog() == DialogResult.OK && G_OpenFileDialog.FileName.Length > 0)//當打開的文件內容不為空且點擊「打開」按鈕時
            {
                fileName = G_OpenFileDialog.FileName;//儲存打開文件的文件名
                this.richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);//從指定位置載入RTF文件
            }
        }

        private void 清空ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();//清空RichTextBox控制元件中的內容
            richTextBox1.Focus();//時RichTextBox控制元件取得焦點
        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileName))//如果存在該文件
            {
                richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichNoOleObjs);//在指定路徑下儲存
                MessageBox.Show("儲存成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出儲存成功的提示訊息
                richTextBox1.Clear();//清空RichTextBox控制元件中的內容
            }
            else//當不存在該文件時
            {
                G_SaveFileDialog.Filter = "RTF文件(*.RTF)|*.RTF";//設定儲存文件的儲存格式
                if (G_SaveFileDialog.ShowDialog() == DialogResult.OK && G_SaveFileDialog.FileName.Length > 0)//當儲存文件的文件名存在且點擊的是「儲存」按鈕時
                {
                    richTextBox1.SaveFile(G_SaveFileDialog.FileName + ".RTF");//在指定位置下儲存RTF文件
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出應用程式
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")//當RichTextBox控制元件中存在內容時
            {
                ((ToolStripMenuItem)Menu_Main.Items["文件ToolStripMenuItem"]).//啟用儲存功能
                    DropDownItems["儲存ToolStripMenuItem"].Enabled = true;
            }
            else//當RichTextBox控制元件中不存在內容時
            {
                ((ToolStripMenuItem)Menu_Main.Items["文件ToolStripMenuItem"]).//停用儲存功能
                    DropDownItems["儲存ToolStripMenuItem"].Enabled = false;
            }
        }
    }
}
