using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RemoveBlank
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_RemoveBlank_Click(object sender, EventArgs e)
        {
            char[] P_chr = txt_str.Text.ToCharArray();//得到字符陣列
            IEnumerator P_ienumerator_chr = //得到列舉器
                P_chr.GetEnumerator();
            StringBuilder P_stringbuilder = //建立stringbuilder對像
                new StringBuilder();
            while (P_ienumerator_chr.MoveNext())//開始列舉
            {
                P_stringbuilder.Append(//向stringbuilder對像中新增非空格字符
                    (char)P_ienumerator_chr.Current != ' ' ?
                    P_ienumerator_chr.Current.ToString() : string.Empty);
            }
            txt_removeblank.Text = //得到沒有空格的字串
                P_stringbuilder.ToString();
        }
    }
}
