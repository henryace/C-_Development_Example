using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ValidateIP
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (IPCheck(textBox1.Text))//驗證IP是否正確
            {
                MessageBox.Show("輸入ＩＰ正確");//彈出消息對話框
            }
            else { MessageBox.Show("輸入ＩＰ不正確"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證IP是否正確
        /// </summary>
        /// <param name="IP">IP地址字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IPCheck(string IP)
        {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";//建立正規化運算式字串
            return Regex.IsMatch(IP,//使用正規化運算式判斷是否匹配
                ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }
    }
}