using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetSelectTabPage
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string P_str_TabName = tabControl1.SelectedTab.Text;//取得選擇的選項標籤名稱
            MessageBox.Show("您選擇的選項標籤為：" + P_str_TabName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//彈出訊息提示
        }
    }
}
