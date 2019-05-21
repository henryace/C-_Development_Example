using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TypeOf
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            Type type = typeof(System.Int32);//取得int類型的Type物件
            foreach (MethodInfo method in type.GetMethods())//深度搜尋string類別中定義的所有公共方法
            {
                rtbox_text.AppendText(
                    "方法名稱：" + method.Name + Environment.NewLine);//輸出方法名稱
                foreach (ParameterInfo parameter in method.GetParameters())//深度搜尋公共方法中所有參數
                {
                    rtbox_text.AppendText(
                        "  參數：" + parameter.Name + Environment.NewLine);//輸出參數名稱
                }
            }
        }
    }
}
