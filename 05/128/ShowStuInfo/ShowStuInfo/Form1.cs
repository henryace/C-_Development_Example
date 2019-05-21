using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowStuInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class BStuInfo<T>
        {
            public T ID; //聲明學生編號欄位 
            public T Name; //聲明姓名欄位 
            public T Sex; //聲明性別欄位 
            public T Age; //聲明年齡欄位 
            public T Birthday; //聲明生日欄位 
            public T Grade; //聲明班級欄位
        }
        class HStuInfo<T> : BStuInfo<T>//繼承自BStuInfo泛型類
        {
            public T Chinese; //聲明語文成績欄位
            public T Math; //聲明數學成績欄位
            public T English; //聲明英語成績欄位
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HStuInfo<object> Exte = new HStuInfo<object>();//實例化衍生類物件
            //透過衍生類物件參考學生訊息相關的欄位，並為其賦值
            Exte.ID = 1;
            Exte.Name = "小王";
            Exte.Sex = "男";
            Exte.Age = 16;
            Exte.Birthday = Convert.ToDateTime("1993-11-29");
            Exte.Grade = "三年五班";
            Exte.Chinese = 145;
            Exte.Math = 140;
            Exte.English = 137;
            //將學生訊息顯示在TextBox文字框中
            textBox1.Text = Exte.ID.ToString();
            textBox2.Text = Exte.Name.ToString();
            textBox3.Text = Exte.Sex.ToString();
            textBox4.Text = Exte.Age.ToString();
            textBox5.Text = Exte.Birthday.ToString();
            textBox6.Text = Exte.Grade.ToString();
            textBox7.Text = Exte.Chinese.ToString();
            textBox8.Text = Exte.Math.ToString();
            textBox9.Text = Exte.English.ToString();
        }
    }
}
