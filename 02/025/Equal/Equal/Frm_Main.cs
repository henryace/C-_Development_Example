using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equal
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            object P_obj = rbtn_target1.Checked ? //正確的為變數新增參考
                (object)"C# 編程詞典" : new System.IO.FileInfo(@"d:\");
            if (rbtn_class1.Checked)//判斷選擇了哪一個類型
            {
                if (P_obj is System.String)//判斷物件是否為字符串類型
                    MessageBox.Show(//提示相容訊息
                        "物件與指定類型相容", "提示！");
                else
                    MessageBox.Show(//提示不相容訊息
                        "物件與指定類型不相容", "提示！");
            }
            else
            {
                if (P_obj is System.IO.FileInfo)//判斷物件是否為文件類型
                    MessageBox.Show(//提示相容訊息
                        "物件與指定類型相容", "提示！");
                else
                    MessageBox.Show(//提示不相容訊息
                        "物件與指定類型不相容", "提示！");
            }
        }
    }
}
