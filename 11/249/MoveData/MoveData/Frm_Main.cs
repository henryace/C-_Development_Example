using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoveData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void MoveData_Load(object sender, EventArgs e)
        {
            listView1.Items.Add("香蕉");//向listView1中新增「香蕉」項
            listView1.Items.Add("蘋果");//向listView1中新增「蘋果」項
            listView1.Items.Add("大鴨梨");//向listView1中新增「大鴨梨」項
            listView1.Items.Add("柿子");//向listView1中新增「柿子」項
            listView1.Items.Add("橘子");//向listView1中新增「橘子」項
            listView1.Items.Add("水蜜桃");//向listView1中新增「水蜜桃」項
            listView1.Items.Add("西瓜");//向listView1中新增「西瓜」項
            listView1.Items.Add("橙子");//向listView1中新增「橙子」項
            listView1.Items.Add("獼猴桃");//向listView1中新增「獼猴桃」項
            DecideTrueOrFalse();//當listBox1中沒有選擇項時使所有按鈕處於不可用狀態
        }

        private void allLeft_Click(object sender, EventArgs e)
        {
            DecideTrueOrFalse();//當listView1中沒有選擇項時使所有按鈕處於不可用狀態
            TransferLeftTechnique();//將listView2中的所有選擇項移動到listView1中
        }

        private void left_Click(object sender, EventArgs e)
        {
            DecideTrueOrFalse();//當listBox1中沒有選擇項時使所有按鈕處於不可用狀態
            TransferLeftTechnique();//將listView2中的所有選擇項移動到listView1中
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)//當listView1中的選擇項為0時
            {
                allRight.Enabled = false;//設定團購按鈕為不可用狀態
                allLeft.Enabled = false; //設定團退按鈕為不可用狀態
                right.Enabled = false;//設定單購按鈕為不可用狀態
                left.Enabled = false;//設定單退按鈕為不可用狀態
            }
            else if (listView1.SelectedItems.Count == 1)//當listView1中的選擇項為1時
            {
                allRight.Enabled = false;//設定團購按鈕為不可用狀態
                allLeft.Enabled = false;//設定團退按鈕為不可用狀態
                right.Enabled = true;//設定單購按鈕為可用狀態
                left.Enabled = false;//設定單退按鈕為不可用狀態
            }
            else if (listView1.SelectedItems.Count > 1) //當listView1中的選擇項大於1時
            {
                right.Enabled = false;//設定單購按鈕為不可用狀態
                left.Enabled = false;//設定單退按鈕為不可用狀態
                allLeft.Enabled = false;//設定團退按鈕為不可用狀態
                allRight.Enabled = true;//設定團購按鈕為可用狀態
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            DecideTrueOrFalse();//當listBox1中沒有選擇項時使所有按鈕處於不可用狀態
            TransferRightTechnique();//呼叫購物方法
        }

        private void TransferRightTechnique()
        {
            ListView.SelectedListViewItemCollection SettleOnItem = new ListView.SelectedListViewItemCollection(this.listView1);//定義一個選擇項的集合
            for (int i = 0; i < SettleOnItem.Count; )//循環深度搜尋選擇的每一項
            {
                listView2.Items.Add(SettleOnItem[i].Text);//向listView2中新增選擇項
                listView1.Items.Remove(SettleOnItem[i]);//從listView1中移除選擇項
            }
        }

        private void TransferLeftTechnique()
        {
            ListView.SelectedListViewItemCollection SettleOnItem = new ListView.SelectedListViewItemCollection(this.listView2);//定義一個選擇項的集合
            for (int i = 0; i < SettleOnItem.Count; )//循環深度搜尋選擇的每一項
            {
                listView1.Items.Add(SettleOnItem[i].Text);//向listView1中新增選擇項
                listView2.Items.Remove(SettleOnItem[i]);//從listView2中移除選擇項
            }
        }
        private void allRight_Click(object sender, EventArgs e)
        {
            DecideTrueOrFalse();//當listBox1中沒有選擇項時使所有按鈕處於不可用狀態
            TransferRightTechnique();//呼叫購物方法
        }

        private void DecideTrueOrFalse()
        {
            if (listView1.SelectedIndices.Count == 0)//當listView1中的選擇項為空時
            {
                allRight.Enabled = false;//設定團購按鈕為不可用狀態
                allLeft.Enabled = false;//設定團退按鈕為不可用狀態
                right.Enabled = false;//設定單購按鈕為不可用狀態
                left.Enabled = false;//設定單退按鈕為不可用狀態
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)//當listView2中的選擇項為0時
            {
                allRight.Enabled = false;//設定團購按鈕為不可用狀態
                allLeft.Enabled = false;//設定團退按鈕為不可用狀態
                right.Enabled = false;//設定單購按鈕為不可用狀態
                left.Enabled = false;//設定單退按鈕為不可用狀態
            }
            else if (listView2.SelectedItems.Count == 1)//當listView2中的選擇項為1時
            {
                allRight.Enabled = false;//設定團購按鈕為不可用狀態
                allLeft.Enabled = false;//設定團退按鈕為不可用狀態
                right.Enabled = false; //設定單購按鈕為不可用狀態
                left.Enabled = true;//設定單退按鈕為可用狀態
            }
            else if (listView2.SelectedItems.Count > 1)//當listView2中的選擇項為1時
            {
                right.Enabled = false;//設定單購按鈕為不可用狀態
                left.Enabled = false;//設定單退按鈕為不可用狀態
                allLeft.Enabled = true;//設定團退按鈕為可用狀態
                allRight.Enabled = false;//設定團購按鈕為不可用狀態
            }
        }
    }
}
