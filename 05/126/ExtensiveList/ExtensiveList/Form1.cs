using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtensiveList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Types<T>
        {
            public T Num; //聲明編號欄位 
            public T Name; //聲明姓名欄位 
            public T Sex; //聲明性別欄位 
            public T Age; //聲明年齡欄位 
            public T Birthday; //聲明生日欄位 
            public T Salary; //聲明薪水欄位 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Types<object> Exte = new Types<object>();//實例化泛型類物件
            //為泛型類中聲明的欄位進行賦值，存儲不同類型的值
            Exte.Num = 1;
            Exte.Name = "王老師";
            Exte.Sex = "男";
            Exte.Age = 25;
            Exte.Birthday = Convert.ToDateTime("1986-06-08");
            Exte.Salary = 1500.45F;
            //將泛型類中各欄位的值顯示在文字框中
            textBox1.Text = Exte.Num.ToString();
            textBox2.Text = Exte.Name.ToString();
            textBox3.Text = Exte.Sex.ToString();
            textBox4.Text = Exte.Age.ToString();
            textBox5.Text = Exte.Birthday.ToString();
            textBox6.Text = Exte.Salary.ToString();
        }
    }
}
