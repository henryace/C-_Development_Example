using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreStuInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        partial class CommInfo
        {
            /// <summary>
            /// 編號
            /// </summary>
            public object ID;
            /// <summary>
            /// 姓名
            /// </summary>
            public object Name;
            /// <summary>
            /// 性別
            /// </summary>
            object sex;
            public object Sex
            {
                get
                {
                    if ((bool)sex == true)
                        sex = "男";
                    else
                        sex = "女";
                    return sex;
                }
                set { sex = value; }
            }
            /// <summary>
            /// 年齡
            /// </summary>
            public object Age;
            /// <summary>
            /// 出生年月
            /// </summary>
            public object Birthday;
        }

        partial class CommInfo
        {
            /// <summary>
            /// 年級
            /// </summary>
            public object Grade;
            /// <summary>
            /// 班級
            /// </summary>
            public object Class;
            /// <summary>
            /// 班主任
            /// </summary>
            public object Director;
        }

        CommInfo Comminfo = new CommInfo();//實例化分部類物件
        private void Form1_Load(object sender, EventArgs e)
        {
            //為分部類中的各個屬性賦值
            Comminfo.ID = "0001";
            Comminfo.Name = "劉同學";
            Comminfo.Sex = false;
            Comminfo.Age = 25;
            Comminfo.Birthday = Convert.ToDateTime("1985-04-25");
            Comminfo.Grade = 3;
            Comminfo.Class = 5;
            Comminfo.Director = "王老師";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //透過訪問分部類中的屬性顯示學生訊息
            textBox_ID.Text = Comminfo.ID.ToString();
            textBox_Name.Text = Comminfo.Name.ToString();
            textBox_Sex.Text = Comminfo.Sex.ToString();
            textBox_Age.Text = Comminfo.Age.ToString();
            textBox_Birthday.Text = Comminfo.Birthday.ToString();
            textBox_Grade.Text = Comminfo.Grade.ToString();
            textBox_Class.Text = Comminfo.Class.ToString();
            textBox_Director.Text = Comminfo.Director.ToString();
        }
    }
}
