using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeopleSpeakByMState
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")//判斷是否輸入了姓名
            {
                Console.WriteLine("請輸入姓名：");
                return;
            }
            richTextBox1.Clear();//清空文字框內容
            string strName = textBox1.Text;//記錄用戶輸入的名字
            People[] people = new People[2];//聲明People類型陣列
            people[0] = new Chinese();//使用第一個衍生類別物件初始化陣列的第一個元素
            people[1] = new American();//使用第二個衍生類別物件初始化陣列的第二個元素
            for (int i = 0; i < people.Length; i++)//深度搜尋賦值後的陣列
            {
                people[i].Say(richTextBox1, strName);//根據陣列元素呼叫相應衍生類別中的重寫方法
            }
        }
    }
    class People//定義基底類別
    {
        public virtual void Say(RichTextBox rtbox, string name)//定義一個虛方法，用來表示人的說話行為
        {
            rtbox.Text += name;//輸出人的名字
        }
    }
    class Chinese : People//定義衍生類別，繼承於People類別
    {
        public override void Say(RichTextBox rtbox, string name)//重寫基底類別中的虛方法
        {
            base.Say(rtbox, name + "說漢語！\n");
        }
    }
    class American : People//定義衍生類別，繼承於People類別
    {
        public override void Say(RichTextBox rtbox, string name)//重寫基底類別中的虛方法
        {
            base.Say(rtbox, name + "說英語！");
        }
    }
}
