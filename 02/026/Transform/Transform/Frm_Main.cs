using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Transform
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            if (rbtn_object.Checked)//如果選擇轉換為object類型
            {
                using (FileStream P_filestream = //建立檔案流物件
                    new FileStream(@"d:\log.txt", System.IO.FileMode.Create))
                {
                    object P_object = //使用as關鍵字轉換類型
                        P_filestream as object;
                    if (P_object != null)//判斷轉換是否成功
                    {
                        MessageBox.Show("轉換為Object成功！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("轉換為Object不成功！", "提示！");
                    }
                }

            }
            if (rbtn_stream.Checked)//如果選擇轉換為stream類型
            {
                using (FileStream P_filestream =//建立檔案流物件
                    new FileStream(@"d:\log.txt", System.IO.FileMode.Create))
                {
                    object P_obj = P_filestream;
                    Stream P_stream = //使用as關鍵字轉換類型
                        P_obj as Stream;
                    if (P_stream != null)//判斷轉換是否成功
                    {
                        MessageBox.Show("轉換為Stream成功！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("轉換為Stream不成功！", "提示！");
                    }
                }
            }
            if (rbtn_string.Checked)//如果選擇轉換為string類型
            {
                using (FileStream P_filestream = //建立檔案流物件
                    new FileStream(@"d:\log.txt", System.IO.FileMode.Create))
                {
                    object P_obj = P_filestream;
                    string P_str = //使用as關鍵字轉換類型
                        P_obj as string;
                    if (P_str != null)//判斷轉換是否成功
                    {
                        MessageBox.Show("轉換為string成功！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("轉換為string不成功！", "提示！");
                    }
                }
            }
        }
    }
}
