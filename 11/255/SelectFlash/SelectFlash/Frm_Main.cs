using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//聲明與文件的輸入輸出流有關的命名空間

namespace SelectFlash
{
    public partial class SelectFlash : Form
    {
        public SelectFlash()
        {
            InitializeComponent();
        }

        public static bool flag = false;//定義一個全局變數標識
        private void SelectFlash_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;//設定是否在listView1控制元件中顯示網格線
            listView1.Dock = DockStyle.Fill;//設定listView1控制元件在其父容器中的停靠方式
            listView1.Columns.Add("文件名稱", 120, HorizontalAlignment.Left);//在listView1中新增「文件名稱」列
            listView1.Columns.Add("文件屬性", 210, HorizontalAlignment.Left);//在listView1中新增「文件屬性」列
            listView1.Columns.Add("建立時間", 200, HorizontalAlignment.Left);//在listView1中新增「建立時間」列
            foreach (String fileName in Directory.GetFiles("C:\\"))//循環深度搜尋C盤目錄空間
            {
                FileInfo file = new FileInfo(fileName);//聲明一個操作文件的實例
                ListViewItem OptionItem = new ListViewItem(file.Name);//實例化一個listView控制元件中選擇項的實例
                OptionItem.SubItems.Add(file.Attributes.ToString());//在listView控制元件中新增文件屬性列
                OptionItem.SubItems.Add(file.CreationTime.ToString());//在listView控制元件中文件建立時間列
                listView1.Items.Add(OptionItem);//向listView控制元件中追加新新增的各列
            }
            listView1.HideSelection = true;//設定控制元件的高亮顯示屬性為true
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView1.SelectedItems[0].BackColor = Color.LightYellow;//設定目前選擇項為高亮
        }

        private void 取消選擇ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)//當listView1控制元件中的選擇項不為0時
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)//循環深度搜尋控制元件中的每一個選擇項
                {
                    if (listView1.SelectedItems[i].BackColor == Color.LightYellow)//當選擇項為高亮時
                    {
                        listView1.SelectedItems[i].BackColor = Color.White;//設定選擇項為白色
                    }
                }
            }
        }
    }
}
