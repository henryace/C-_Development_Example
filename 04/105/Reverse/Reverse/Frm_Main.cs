using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reverse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private string[] G_str_array;//定義字串陣列欄位

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_str_array = new string[] { "C#編程詞典", "C#編程寶典", "C#開發實戰寶典", "視頻學C#", "C#範例大全" };//為字串陣列欄位賦值
            foreach (string str in G_str_array)//深度搜尋字串陣列集合
            {
                lab_str.Text += str + Environment.NewLine;//顯示字串陣列

            }
        }

        private void btn_Reverse_Click(object sender, EventArgs e)
        {
            lab_str2.Text = string.Empty;//清空訊息
            foreach (string str in G_str_array.Reverse())//深度搜尋反轉後的字串陣列
            {
                lab_str2.Text += str + Environment.NewLine;//顯示字串陣列
            }
        }
    }
}