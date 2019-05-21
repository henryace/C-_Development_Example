using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FindThis
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int intIndex = //搜尋指定項的索引
                this.listBox1.FindString(cbox_Select.Text);
            if (intIndex != ListBox.NoMatches)
            {
                listBox1.SelectedIndex = intIndex;//選中指定項
                MessageBox.Show(//彈出消息對話框
                    "指定項的索引是：" + intIndex.ToString(),
                    "提示!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(//彈出消息對話框
                    "沒有找到相關的選項",
                    "訊息提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("C#編程詞典");//向控制元件中新增資料項
            listBox1.Items.Add("C#編程寶典");//向控制元件中新增資料項
            listBox1.Items.Add("C#視頻學");//向控制元件中新增資料項
            listBox1.Items.Add("C#範例寶典");//向控制元件中新增資料項
            listBox1.Items.Add("C#實點寶典");//向控制元件中新增資料項
            cbox_Select.SelectedIndex = 0;//設定控制元件預設選擇項
        }
    }
}