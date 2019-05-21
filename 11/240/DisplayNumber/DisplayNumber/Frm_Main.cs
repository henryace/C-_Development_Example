using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//參考與輸入輸出流有關的命名空間

namespace DisplayNumber
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private static string temp = "tomorrow.RTF";//用來儲存RTF文件的路徑
        private RichTextBoxEx richTextBox1 = new RichTextBoxEx();//聲明一個自定義類的實例
        private void DisplayNumber_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Parent = this.groupBox1;//設定自定義類的父容器
            this.groupBox1.Controls.Add(this.richTextBox1);//向指定的父容器中新增控制元件
            if (File.Exists(temp))//當存在該RTF文件時
            {
                this.richTextBox1.LoadFile(temp, RichTextBoxStreamType.RichText);//將該文件顯示在RichTextBox控制元件中
            }
            richTextBox1.SelectionBullet = true;//設定RichTextBox控制元件標識項目符號的值為true
        }

        private void programNumeration_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionBullet)//當RichTextBox控制元件標識項目符號的值為true時
            {
                richTextBox1.SelectionBullet = false;//設定RichTextBox控制元件標識項目符號的值為false
            }
            else //當RichTextBox控制元件標識項目符號的值為false時
            {
                richTextBox1.SelectionBullet = true;//設定RichTextBox控制元件標識項目符號的值為true
            }
        }

        private void unfold_Click(object sender, EventArgs e)
        {
            OpenFileDialog TxTOpenDialog = new OpenFileDialog();//聲明一個打開文件對話框的對象
            TxTOpenDialog.Filter = "RTF文件(*.RTF)|*.RTF";//設定打開文件的格式
            if (TxTOpenDialog.ShowDialog() == DialogResult.OK)//當單擊「打開」按鈕時
            {
                temp = TxTOpenDialog.FileName;//儲存打開文件的路徑
                this.richTextBox1.LoadFile(TxTOpenDialog.FileName, RichTextBoxStreamType.RichText);//在RichTextBox控制元件中打開文件
                MessageBox.Show("讀取成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出讀取成功的訊息提示
            }
        }

        private void hold_Click(object sender, EventArgs e)
        {
            SaveFileDialog TxTSaveDialog = new SaveFileDialog();//聲明一個儲存文件對話框物件
            TxTSaveDialog.Filter = "RTF文件（*.RTF)|*.RTF";//設定儲存文件的格式
            if (File.Exists(temp))//當在指定路徑下存在該文件時
            {
                this.richTextBox1.SaveFile(temp, RichTextBoxStreamType.RichText);//在指定路徑下儲存該文件
                MessageBox.Show("儲存成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出儲存成功的訊息提示
                this.richTextBox1.Clear();//清空RichTextBox控制元件中的原有內容
            }
            else//當在指定路徑下不存在該文件時
            {
                if (TxTSaveDialog.ShowDialog() == DialogResult.OK)//當單擊「儲存」按鈕時
                {
                    this.richTextBox1.SaveFile(TxTSaveDialog.FileName, RichTextBoxStreamType.RichText);//以指定的格式儲存該文件
                    MessageBox.Show("儲存成功！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//彈出儲存成功的訊息提示
                    this.richTextBox1.Clear();//清空RichTextBox控制元件中的原有內容
                }
            }
        }

        private void figuresNumeration_Click(object sender, EventArgs e)
        {
            richTextBox1.BulletType = RichTextBoxEx.AdvRichTextBulletType.Number;//設定文件的項目編號屬性
        }
    }
}
