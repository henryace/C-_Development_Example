using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private OpenFileDialog G_OpenFileDialog = //聲明打開文件對話框欄位並賦值
            new OpenFileDialog();
        private SaveFileDialog G_SaveFileDialog = //聲明儲存文件對話框欄位並賦值
            new SaveFileDialog();

        private void btn_Open_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void 打開RTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog.Filter = "text.rtf|*.rtf*";//篩選文件訊息
            if (this.G_OpenFileDialog.ShowDialog() == DialogResult.OK)//判斷是否打開文件
            {
                rtbox_Display.LoadFile(//載入rtf文件
                    G_OpenFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void 儲存成TXT文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbox_Display.Text != "")//判斷控制元件中是否有文字內容
            {
                G_SaveFileDialog.DefaultExt = "*.txt";//設定文件預設擴展名
                G_SaveFileDialog.Filter = "Txt Files|*.txt";//篩選文件訊息
                if (this.G_SaveFileDialog.ShowDialog() == DialogResult.OK)//判斷是否確認儲存文件
                {
                    rtbox_Display.SaveFile(//儲存文件
                        this.G_SaveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("儲存成功", "訊息提示",//彈出消息對話框
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("請打開文件", "訊息提示", //彈出消息對話框
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
