using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.MatchCollection matches =//使用正規化運算式搜尋重複出現單詞的集合
                System.Text.RegularExpressions.Regex.Matches(label1.Text,
                @"\b(?<word>\w+)\s+(\k<word>)\b", System.Text.
                RegularExpressions.RegexOptions.Compiled | System.Text.
                RegularExpressions.RegexOptions.IgnoreCase);
            if (matches.Count != 0)//如果集合中有內容
            {
                foreach (System.Text.RegularExpressions.Match//深度搜尋集合
                    match in matches)
                {
                    string word = match.Groups["word"].Value;//取得重複出現的單詞
                    MessageBox.Show(word.ToString(), "英文單詞");//彈出消息對話框
                }
            }
            else { MessageBox.Show("沒有重複的單詞"); }//彈出消息對話框
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =//建立字串物件
                "The the quick brown fox  fox jumped over the lazy dog dog.";
        }
    }
}