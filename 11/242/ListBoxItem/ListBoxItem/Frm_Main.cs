using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListBoxItem
{
    public partial class ListBoxItem : Form
    {
        public ListBoxItem()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("香蕉");//向listBox1控制元件中新增「香蕉」
            listBox1.Items.Add("蘋果");//向listBox1控制元件中新增「蘋果」
            listBox1.Items.Add("雪梨");//向listBox1控制元件中新增「雪梨」
            listBox1.Items.Add("西紅柿");//向listBox1控制元件中新增「西紅柿」
            listBox1.Items.Add("橘子");//向listBox1控制元件中新增「橘子」
            listBox1.Items.Add("甘蔗");//向listBox1控制元件中新增「甘蔗」
            listBox1.Items.Add("西瓜");//向listBox1控制元件中新增「西瓜」
            listBox1.Items.Add("橙子");//向listBox1控制元件中新增「橙子」
            listBox1.Items.Add("柚子");//向listBox1控制元件中新增「柚子」
            listBox1.Items.Add("獼猴桃");//向listBox1控制元件中新增「獼猴桃」
            DecideTrueOrFalse();//當listBox1中不存在選擇項時，設定所有按鈕為不可用狀態
        }

        private void allLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.SelectedItems.Count; )//循環深度搜尋listBox2中的所有選定項
            {
                listBox1.Items.Add(listBox2.SelectedItems[i]);//向listBox1中新增listBox2中選定的項
                listBox2.Items.Remove(listBox2.SelectedItems[i]);//移除listBox2中的選定項
            }
            DecideTrueOrFalse();//當listBox1中不存在選擇項時，設定所有按鈕為不可用狀態
        }

        private void left_Click(object sender, EventArgs e)
        {
            DecideTrueOrFalse();//當listBox1中不存在選擇項時，設定所有按鈕為不可用狀態
            object SettleOnItem = listBox2.SelectedItem;//儲存listBox2中的選定項
            if (listBox1.Items.Contains(SettleOnItem))//當listBox1中已存在該項時
            {
                MessageBox.Show(SettleOnItem.ToString() + "已存在！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);//彈出該項已存在的訊息
            }
            else//當listBox1中不存在該項時
            {
                listBox2.Items.Remove(SettleOnItem);//從listBox2中移除該項
                listBox1.Items.Add(SettleOnItem);//向listBox1中新增該項
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)//當listBox1中的選定項為空時
            {
                allRight.Enabled = false;//設定全部右移的按鈕為不可用狀態
                allLeft.Enabled = false;//設定全部左移的按鈕為不可用狀態
                right.Enabled = false; //設定右移的按鈕為不可用狀態
                left.Enabled = false; //設定左移的按鈕為不可用狀態
            }
            else if (listBox1.SelectedItems.Count == 1)//當listBox1中的選定項為1時
            {
                allRight.Enabled = false;//設定全部右移的按鈕為不可用狀態
                allLeft.Enabled = false;//設定全部左移的按鈕為不可用狀態
                right.Enabled = true; //設定右移的按鈕為可用狀態
                left.Enabled = false; //設定左移的按鈕為不可用狀態
            }
            else if (listBox1.SelectedItems.Count > 1)//當listBox1中的選定項大於1時
            {
                right.Enabled = false;//設定右移的按鈕為可用狀態
                left.Enabled = false;  //設定左移的按鈕為不可用狀態
                allLeft.Enabled = false; //設定全部左移的按鈕為不可用狀態
                allRight.Enabled = true; //設定全部右移的按鈕為可用狀態
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            DecideTrueOrFalse();//當listBox1中不存在選擇項時，設定所有按鈕為不可用狀態
            object SettleOnItem = listBox1.SelectedItem;//儲存listBox1中的選定項
            if (listBox2.Items.Contains(SettleOnItem)) //當listBox2中已存在該項時
            {
                MessageBox.Show(SettleOnItem.ToString() + "已存在！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);//彈出該項已存在的訊息
            }
            else//當listBox2中不存在該項時
            {
                listBox1.Items.Remove(SettleOnItem);//從listBox1中移除該項
                listBox2.Items.Add(SettleOnItem);//向listBox2中新增該項
            }
        }

        private void allRight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.SelectedItems.Count; )//循環深度搜尋listBox1中選定的各項
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);//向listBox2中新增listBox1中選定的各項
                listBox1.Items.Remove(listBox1.SelectedItems[i]);//從listBox1中移除listBox1中選定的項
            }
            DecideTrueOrFalse();//當listBox1中不存在選擇項時，設定所有按鈕為不可用狀態
        }

        private void DecideTrueOrFalse()
        {
            if (listBox1.SelectedItem == null)//當listBox1中不存在選擇項時，設定所有按鈕為不可用狀態
            {
                allRight.Enabled = false;//設定全部右移按鈕為不可用狀態
                allLeft.Enabled = false;//設定全部左移按鈕為不可用狀態
                right.Enabled = false;//設定右移按鈕為不可用狀態
                left.Enabled = false;//設定左移按鈕為不可用狀態
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)//當listBox2中的選擇項不為空時
            {
                allRight.Enabled = false;//設定全部右移的按鈕為不可用狀態
                allLeft.Enabled = false;//設定全部左移的按鈕為不可用狀態
                right.Enabled = false; //設定右移按鈕為不可用狀態
                left.Enabled = false; //設定左移按鈕為不可用狀態
            }
            else if (listBox2.SelectedItems.Count == 1) //當listBox2中的選擇項為1時
            {
                allRight.Enabled = false;//設定全部右移按鈕為不可用狀態
                allLeft.Enabled = false; //設定全部左移按鈕為不可用狀態
                right.Enabled = false; //設定右移按鈕為不可用狀態
                left.Enabled = true;   //設定左移按鈕為可用狀態
            }
            else if (listBox2.SelectedItems.Count > 1)//當listBox2中的選定項大於1時
            {
                right.Enabled = false;//設定右移按鈕為不可用狀態
                left.Enabled = false;//設定左移按鈕為不可用狀態
                allLeft.Enabled = true; //設定全部左移按鈕為可用狀態
                allRight.Enabled = false;//設定全部右移按鈕為不可用狀態
            }
        }
    }
}
