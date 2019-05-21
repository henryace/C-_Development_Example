using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddTabPages
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.Normal;//設定選項標籤的外觀樣式
        }
        //新增選項標籤
        private void button1_Click(object sender, EventArgs e)
        {
            //宣告一個字串變數，用於產生新增選項標籤的名稱
            string Title = "新增選項標籤 " + (tabControl1.TabCount + 1).ToString();
            TabPage MyTabPage = new TabPage(Title);//建立TabPage物件
            //使用TabControl控制元件的TabPages 屬性的Add方法新增新的選項標籤
            tabControl1.TabPages.Add(MyTabPage);
            MessageBox.Show("現有" + tabControl1.TabCount + "個選項標籤");//取得選項標籤個數
        }
    }
}
