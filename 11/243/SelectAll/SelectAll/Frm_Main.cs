using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SelectAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("遊戲");//向控制元件中新增資料項
            this.listBox1.Items.Add("看書");//向控制元件中新增資料項
            this.listBox1.Items.Add("上網");//向控制元件中新增資料項
            this.listBox1.Items.Add("音樂");//向控制元件中新增資料項
            this.listBox1.Items.Add("電影");//向控制元件中新增資料項
        }

        private void bntList_Click(object sender, EventArgs e)
        {
            this.listBox1.SelectionMode = SelectionMode.MultiExtended;//可能選多項
            for (int i = 0; i < listBox1.Items.Count; i++)//深度搜尋資料項集合
            {
                this.listBox1.SetSelected(i, true);//選定資料項
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對話框
                listBox1.SelectedItems.Count.ToString() + "項被選中", "提示！");
        }
    }
}