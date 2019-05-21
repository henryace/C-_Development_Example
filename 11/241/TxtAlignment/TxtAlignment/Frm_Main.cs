using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//需參考命名空間Using System.IO

namespace TxtAlignment
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string temp = "tomorrow.RTF";//儲存文件的路徑
        private void TxtAlignment_Load(object sender, EventArgs e)
        {
            if (File.Exists(temp))//當在指定路徑下存在該文件時
            {
                this.richTextBox1.LoadFile(temp, RichTextBoxStreamType.RichText);//從指定的位置載入RTF文件
                unfold.Enabled = false;//設定「打開」按鈕為不可用狀態
            }
            hold.Enabled = false;//設定「儲存」按鈕為不可用狀態
        }

        private void unfold_Click(object sender, EventArgs e)
        {
            OpenFileDialog TxTOpenDialog = new OpenFileDialog();//聲明一個用於打開文件對話框的對象
            TxTOpenDialog.Filter = "RTF文件(*.RTF)|*.RTF";//定義打開文件對話框的過濾參數
            if (TxTOpenDialog.ShowDialog() == DialogResult.OK)//當在打開對話框中單擊「打開」按鈕時
            {
                temp = TxTOpenDialog.FileName;//儲存打開文件的路徑
                this.richTextBox1.LoadFile(TxTOpenDialog.FileName, RichTextBoxStreamType.RichText);//從指定的位置載入RTF文件
                hold.Enabled = false;//設定「儲存」按鈕為不可用狀態
                unfold.Enabled = false; //設定「打開」按鈕為不可用狀態
                MessageBox.Show("讀取成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出讀取成功時的提示訊息
            }
        }

        private void hold_Click(object sender, EventArgs e)
        {
            ConserveMeasure(temp);//在指定路徑下儲存文件
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            hold.Enabled = true;//
            if (this.richTextBox1.Text == "" || this.richTextBox1.Text == null)//
            {
                unfold.Enabled = true;//
            }
        }

        private void ConserveMeasure(string path)
        {
            SaveFileDialog TxTSaveDialog = new SaveFileDialog();//定義一個用於儲存文件的儲存對話框
            TxTSaveDialog.Filter = "RTF文件（*.RTF)|*.RTF";//設定儲存文件的過濾參數
            if (File.Exists(path))//當在指定路徑下存在該路徑時
            {
                this.richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);//儲存指定文件到指定位置
                MessageBox.Show("儲存成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出儲存成功的提示訊息
                this.richTextBox1.Clear();//清空RichTextBox控制元件中的所有內容
                hold.Enabled = false;//設定「儲存」按鈕為不可用狀態
            }
            else
            {
                if (TxTSaveDialog.ShowDialog() == DialogResult.OK)//當在儲存對話框中單擊「儲存」按鈕時
                {
                    this.richTextBox1.SaveFile(TxTSaveDialog.FileName, RichTextBoxStreamType.RichText);//儲存文件到指定的位置
                    MessageBox.Show("儲存成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出儲存成功的提示訊息
                    this.richTextBox1.Clear();//清空RichTextBox控制元件中的所有內容
                    hold.Enabled = false;//設定「儲存」按鈕為不可用狀態
                }
            }
        }

        private void justifyCenter_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;//設定選定的文字為居中對齊
        }

        private void justifyLeft_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;//設定選定的文字為左對齊
        }

        private void justifyRight_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;//設定選定的文字為右對齊
        }
    }
}
