using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace TempFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Path.GetTempFileName();//得到臨時文件名稱
            FileInfo fin = new FileInfo(textBox1.Text);//建立文件物件
            fin.AppendText();//向文件內追回文字
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();//關閉視窗
        }
    }
}