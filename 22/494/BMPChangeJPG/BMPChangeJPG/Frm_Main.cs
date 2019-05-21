using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace BMPChangeJPG
{
    public partial class Frm_Main : Form
    {
        Bitmap bitmap;//定義Bitmap類
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();		//實例化OpenFileDialog類
            openFileDialog.Filter = "*.bmp|*.bmp";						//設定文件類型
            openFileDialog.Title = "打開圖像文件";						//設定「打開文件」對話框的標題
            openFileDialog.Multiselect = false;							//只能選擇一個文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)			//打開文件對話框
            {
                if (bitmap != null)									//如果bitmap不為空
                {
                    bitmap.Dispose();								//釋放資源
                }
                string fileName = openFileDialog.FileName;					//取得選擇文件的路徑
                bitmap = new Bitmap(fileName);							//實例化bitmapod 
                if (bitmap.Width > bitmap.Height)							//如果圖片的寬度大於高度
                {
                    pictureBox.Width = panel2.Width;						//設定控制元件的寬度
                    pictureBox.Height = (int)((double)bitmap.Height * panel2.Width / bitmap.Width);		//設定控制元件的高度
                }
                else
                {
                    pictureBox.Height = panel2.Height;						//設定控制元件的高度
                    pictureBox.Width = (int)((double)bitmap.Width * panel2.Height / bitmap.Height);		//設定控制元件的寬度
                }
                pictureBox.Image = bitmap;								//顯示圖片
                FileInfo f = new FileInfo(fileName);							//實例化FileInfo類
                this.Text = "圖像轉換:" + f.Name;							//在視窗標題欄中顯示圖片的名稱
                this.label1.Text = f.Name;								//顯示圖片的名稱
                buttonConvert.Enabled = true;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null)								//如果沒有選擇項
            {
                return;//退出本次操作
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();			//實例化SaveFileDialog類
                saveFileDialog.Title = "轉化為:";							//設定標題
                saveFileDialog.OverwritePrompt = true;						//如果文件名存在則提示
                saveFileDialog.CheckPathExists = true;						//如果文件的路徑不存在則提示
                saveFileDialog.Filter = comboBox.Text + "|" + comboBox.Text;		//設定文件類型
                if (saveFileDialog.ShowDialog() == DialogResult.OK)			//打開「另存為」對話框
                {
                    string fileName = saveFileDialog.FileName;				//取得另存為的文件路徑和文件名
                    bitmap.Save(fileName, ImageFormat.Jpeg); 				//呼叫Save方法將圖片儲存為Jpeg格式
                    FileInfo f = new FileInfo(fileName);						//實例化FileInfo類
                    this.Text = "圖像轉換:" + f.Name;						//在視窗標題欄中顯示轉換的文件名
                    label1.Text = f.Name;
                }
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            pictureBox.Top = panel1.Top;
            pictureBox.Left = panel1.Left;
            if (bitmap != null)
            {
                if (bitmap.Width > bitmap.Height)
                {
                    pictureBox.Width = panel2.Width;
                    pictureBox.Height = (int)((double)bitmap.Height * panel2.Width / bitmap.Width);
                }
                else
                {
                    pictureBox.Height = panel2.Height;
                    pictureBox.Width = (int)((double)bitmap.Width * panel2.Height / bitmap.Height);
                }
            }
            else
            {
                pictureBox.Width = panel2.Width;
                pictureBox.Height = panel2.Height;
            }
            pictureBox.Refresh();
        }
    }
}