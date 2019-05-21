using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetString
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            string str = "\"";//定義字符串變數str並賦值為引號
            string P_strOne, P_strTwo, P_strThree;//定義三個字符串變數
            P_strOne = "Hello,\"C#\";";//為第一個字符串變數賦值
            P_strTwo = "Hello," + '\u0022' + "C#" + '\u0022' + ";";//為第二個字符串變數賦值
            P_strThree = "Hello," + str + "C#" + str + ";";//為第三個字符串變數賦值
            MessageBox.Show(//在消息提示框中輸出三個字符串
                P_strOne + "     " + P_strTwo + "     " + P_strThree);
        }
    }
}
