using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveTabPage
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
        //移除選項標籤
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)//判斷是否選擇了要移除的選項標籤
            {
                MessageBox.Show("請選擇要移除的選項標籤");//如果沒有選擇，彈出提示
            }
            else
            {
                //使用TabControl控制元件的TabPages屬性的Remove方法移除指定的選項標籤
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }
    }
}
