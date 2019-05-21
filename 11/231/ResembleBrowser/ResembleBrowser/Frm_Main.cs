using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResembleBrowser
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private bool State = false;//定義一個全局變數標識

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_Url.Items.Add("http://www.mingribook.com/");//向ComboBox控制元件中新增網址「http://www.mingribook.com/」
            cbox_Url.Items.Add("http://www.baidu.com/");//向ComboBox控制元件中新增網址「http://www.baidu.com/」
            cbox_Url.Items.Add("http://www.sina.com.cn/");//向ComboBox控制元件中新增網址「http://www.sina.com.cn/」
            cbox_Url.Items.Add("http://www.163.com/");//向ComboBox控制元件中新增網址「http://www.163.com/」
            cbox_Url.Items.Add("http://www.qq.com/");//向ComboBox控制元件中新增網址「http://www.qq.com/」
        }

        private void cbox_Url_TextChanged(object sender, EventArgs e)
        {
            if (State)//當變數的值為真時
            {
                string importText = cbox_Url.Text;//取得輸入的文字
                int index = cbox_Url.FindString(importText);//在ComboBox集合中搜尋匹配的文字
                if (index >= 0)//當有搜尋結果時 
                {
                    State = false;//關閉編輯狀態
                    cbox_Url.SelectedIndex = index;//找到對應項
                    State = true;//打開編輯狀態
                    cbox_Url.Select(importText.Length, cbox_Url.Text.Length);//設定文字的選擇長度
                }
            }
        }

        private void cbox_Url_KeyDown(object sender, KeyEventArgs e)
        {
            State = (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete);//當按鍵既不是Back鍵又不是Delete鍵時
            cbox_Url.DroppedDown = true;//當有按鍵被按下時顯示下拉列表
        }

    }
}
