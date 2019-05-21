using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowBusStation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static IList<object> items = new List<object>();//定義一個泛型對象，用於存儲物件
        /// <summary>
        /// 透過迭代器取得泛型中的所有對象值
        /// </summary>
        /// <param Node="n">泛型物件</param>
        /// <returns>IEnumerable<object></returns>
        public static IEnumerable<object> GetValues()
        {
            if (items != null)//如果泛型不為空
            {
                foreach (object i in items)//深度搜尋泛型中的對象
                    yield return i;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //向泛型集合中新增站點資料
            items.Add("長新東路");
            items.Add("同康路");
            items.Add("農行干校");
            items.Add("八里堡");
            items.Add("東榮大路");
            items.Add("二木材");
            items.Add("膠合板廠");
            items.Add("阜豐路");
            items.Add("榮光路");
            items.Add("東盛路");
            items.Add("安樂路");
            items.Add("嶺東路");
            items.Add("公平路");
            items.Add(108);
            items.Add(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (object i in GetValues())//深度搜尋泛型集合
                listView1.Items.Add(i.ToString());//在列表檢視中顯示公交車站點
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();//關閉目前視窗
        }
    }
}
