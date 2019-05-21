using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//參考與文件輸入輸出流有關的命名空間


namespace CheckBoxInListView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void CheckBoxInListView_Load(object sender, EventArgs e)
        {
            listView1.CheckBoxes = true;//設定listView1的復選框屬性為真
            listView1.View = View.Details;//設定listView1的檢視方式
            listView1.GridLines = true;//設定listView1顯示網格線
            listView1.Columns.Add("文件名稱", 150, HorizontalAlignment.Left);//向listView1中新增「文件名稱」列
            listView1.Columns.Add("建立時間", 200, HorizontalAlignment.Left);//向listView1中新增「建立時間」列
            foreach (String fileName in Directory.GetFiles("C:\\"))//循環深度搜尋C盤的內容
            {
                FileInfo file = new FileInfo(fileName);//定義一個操作文件的實例
                ListViewItem OptionItem = new ListViewItem(file.Name);//定義一個listView選擇項的實例
                OptionItem.SubItems.Add(file.CreationTime.ToString());//向listView控制元件中新增文件建立時間列
                listView1.Items.Add(OptionItem);//執行新增操作
            }
        }

        private void checkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempItem in listView1.Items)//循環深度搜尋listView控制元件中的每一項
            {
                if (tempItem.Checked == false)//如果目前項處於未選中狀態
                {
                    tempItem.Checked = true;//設定目前項為選中狀態
                }
            }
        }

        private void cleanUp_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempItem in listView1.Items)//循環深度搜尋listView控制元件中的每一項
            {
                if (tempItem.Checked)//如果目前項處於選中狀態
                {
                    tempItem.Checked = false;//設定目前項為未選中狀態
                }
            }
        }
    }
}
