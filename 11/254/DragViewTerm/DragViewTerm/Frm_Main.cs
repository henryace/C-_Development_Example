using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DragViewTerm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //起動拖放放操作，設定拖放類型
            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }
        //選擇要拖動的項
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            //取得ListView類型資料
            for (int i = 0; i <= e.Data.GetFormats().Length - 1; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            //判斷是否選擇拖放的項
            if (listView1.SelectedItems.Count == 0)
            {
                return;//退出方法
            }
            Point cp = listView1.PointToClient(new Point(e.X, e.Y));//定義項的坐標點
            ListViewItem dragToItem = listView1.GetItemAt(cp.X, cp.Y);//得到指定位置的項

            if (dragToItem == null)//判斷是否為空
            {
                return;//退出方法
            }
            List<ListViewItem> ls = new List<ListViewItem>();//建立項集合
            foreach (ListViewItem lvi in listView1.SelectedItems)//深度搜尋選中的項
            {
                ls.Add(lvi);//將選中項新增到集合
            }
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Remove(ls[i]);
            }
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Insert(dragToItem.Index, ls[i]);
            }
            ls.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ls.Add(listView1.Items[i]);
            }
            listView1.Items.Clear();
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Add(ls[i]);
            }
        }
    }
}