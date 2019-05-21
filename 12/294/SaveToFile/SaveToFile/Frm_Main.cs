using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaveToFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.txt|*.txt";//儲存檔案類型
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選定檔案
            {
                StreamWriter sw = new StreamWriter(//建立檔案寫入器
                    saveFileDialog1.FileName);
                sw.Write(txt_Message.Text);//向檔案中寫入文字訊息
                sw.Close();//關閉檔案流
            }
        }
    }
}
