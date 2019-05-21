using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCtrlStyle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.ImageList = imageList1;//設定控制元件的ImageList屬性為imageList1
            //第一個選項標籤的圖標是imageList1中索引為0的圖標
            tabPage1.ImageIndex = 0;
            tabPage1.Text = "C#編程詞典——全能版";//設定第一個選項標籤標題
            //第二個選項標籤的圖標是imageList1中索引為0的圖標
            tabPage2.ImageIndex = 0;
            tabPage2.Text = "C#編程詞典——珍藏版";//設定第二個選項標籤標題
            //將控制元件的Appearance屬性設定為Buttons，使選項標籤具有立體按鈕的外觀
            tabControl1.Appearance = TabAppearance.Buttons;
        }
    }
}