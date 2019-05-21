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

namespace ICOChangeBMP
{
    public partial class Frm_Main : Form
    {
        Bitmap bitmap;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.ico|*.ico";
            openFileDialog.Title = "打開ICO文件";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
                string fileName = openFileDialog.FileName;
                bitmap = new Bitmap(fileName);
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
                pictureBox.Image = bitmap;
                FileInfo f = new FileInfo(fileName);
                this.Text = "圖像轉換:" + f.Name;
                this.label1.Text = f.Name;
                buttonConvert.Enabled = true;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null) 							//如果沒有選定項
            {
                return; 												//退出本次操作
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog(); 			//實例化SaveFileDialog類
                saveFileDialog.Title = "轉化為:"; 							//設定「另存為」對話框的題標
                saveFileDialog.OverwritePrompt = true; 						//如果文件名存在則提示
                saveFileDialog.CheckPathExists = true; 						//如果文件的路徑不存在則提示
                saveFileDialog.Filter = comboBox.Text + "|" + comboBox.Text; 		//設定文件類型
                if (saveFileDialog.ShowDialog() == DialogResult.OK) 			//打開「另存為」對話框
                {
                    string fileName = saveFileDialog.FileName; 				//取得另存為文件的路徑及名稱
                    bitmap.Save(fileName, ImageFormat.Bmp); 				//呼叫Save方法將圖片儲存為bmp格式
                    FileInfo f = new FileInfo(fileName); 						//實例化FileInfo類
                    this.Text = "圖像轉換:" + f.Name;	 					//設定視窗標題欄
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