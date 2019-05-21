using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goto
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string[] G_str_array = new string[] //定義陣列並初始化
        { 
        "C#範例寶典",
        "C#編程寶典",
        "C#視頻學",
        "C#項目開發全程實錄",
        "C#項目開發實例自學手冊",
        "C#編程詞典",
        "C#實戰寶典",
        "C#經驗技巧寶典",
        "C#入門模式",
        };

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            lbox_str.Items.AddRange(G_str_array);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            int i = 0;//定義計數器
        label1://定義標籤
            if (G_str_array[i].Contains(txt_query.Text))//判斷是否找到圖書
            {
                lbox_str.SelectedIndex = i;//選中搜尋到的結果
                MessageBox.Show(txt_query.Text + " 已經找到！", "提示！");//提示找到訊息
                return;
            }
            i++;
            if (i < G_str_array.Length) goto label1;//條件滿足則跳轉到標籤
            MessageBox.Show(txt_query.Text + " 沒有找到！", "提示！");//提示未找到訊息
        }

    }
}
