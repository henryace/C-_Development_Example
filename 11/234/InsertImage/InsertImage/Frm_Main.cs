using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_InsertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = //建立打開文件對話框物件
                new OpenFileDialog();
            P_OpenFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";
            DialogResult P_DialogResult = //彈出打開文件對話框
                P_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判斷是否選中文件
            {
                Clipboard.SetDataObject(//將圖像放入剪貼簿
                    Image.FromFile(P_OpenFileDialog.FileName), false);
                if (rtbox_Display.CanPaste(//判斷剪貼簿內是否是圖像
                    DataFormats.GetFormat(DataFormats.Bitmap)))
                {
                    rtbox_Display.Paste();//貼上剪貼簿的內容到控制元件中
                }
            }
        }
    }
}
