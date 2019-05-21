using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NavigationForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Clear();//清空listView1中的原有內容
            listView1.LargeImageList = imageList1;//設定目前項以大圖標的形式顯示時用到的圖像
            listView1.Items.Add("設定上下班時間", "設定上下班時間", 0);//向listView1中新增項「設定上下班時間」
            listView1.Items.Add("是否啟用短信提醒", "是否啟用短信提醒", 1);//向listView1中新增項「是否啟用短信提醒」
            listView1.Items.Add("設定密碼", "設定密碼", 2);//向listView1中新增項「設定密碼」
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;//設定listView1的繫結屬性為未繫結
            button1.Dock = DockStyle.Top;//設定button1的繫結屬性為上端繫結
            button2.Dock = DockStyle.Bottom;//設定button2的繫結屬性為底端繫結
            button3.SendToBack();//將button3發送到Z順序的後面
            button3.Dock = DockStyle.Bottom;//設定button3的繫結屬性為底端繫結
            listView1.BringToFront();//將listView1帶到Z順序的前面
            listView1.Dock = DockStyle.Bottom;//設定listView1的繫結屬性為底端繫結
            listView1.Clear();//清空listView1中的原有內容
            listView1.Items.Add("設定上下班時間", "設定上下班時間", 0);//向listView1中新增「設定上下班時間」
            listView1.Items.Add("是否啟用短信提醒", "是否啟用短信提醒", 1);//向listView1中新增「是否啟用短信提醒」
            listView1.Items.Add("設定密碼", "設定密碼", 2);//向listView1中新增「設定密碼」
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;//設定listView1的繫結屬性為未繫結
            button2.Dock = DockStyle.Top;//設定button2的繫結屬性為上端繫結
            button1.SendToBack();//將控制元件button1發送到Z順序的後面
            button1.Dock = DockStyle.Top;//設定button1的繫結屬性為上端繫結
            button3.Dock = DockStyle.Bottom;//設定button3的繫結屬性為底端繫結
            listView1.Dock = DockStyle.Bottom;//設定listView1的繫結屬性為底端繫結
            listView1.Clear();//清空listView1中的原有內容
            listView1.Items.Add("近期工作記錄", "近期工作記錄", 3);//向listView1中新增「近期工作記錄」
            listView1.Items.Add("近期工作計劃", "近期工作計劃", 4);//向listView1中新增「近期工作計劃」
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;//設定listView1的繫結屬性為未繫結
            button3.SendToBack();//將button3發送到Z順序的後面
            button3.Dock = DockStyle.Top;//設定button3的繫結屬性為上端繫結
            button2.SendToBack();//將button2發送到Z順序的後面
            button2.Dock = DockStyle.Top;//設定button2的繫結屬性為上端繫結
            button1.SendToBack();//將button1發送到Z順序的後面
            button1.Dock = DockStyle.Top;//設定button1的繫結屬性為上端繫結
            listView1.Dock = DockStyle.Bottom;//設定listView1的繫結屬性為底端繫結
            listView1.Clear();//清空listView1中的原有內容
            listView1.Items.Add("編輯工作進度報告", "編輯工作進度報告", 5);//向listView1中新增「編輯工作進度報告」
            listView1.Items.Add("編輯項目設計圖", "編輯項目設計圖", 6);//向listView1中新增「編輯項目設計圖」
        }
    }
}