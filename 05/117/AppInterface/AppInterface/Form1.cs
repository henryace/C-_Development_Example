using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 聲明一個介面，用於定義Seak方法，而具體Speak方法功能的實現是在類中進行的
        /// </summary>
        interface ISelectLanguage
        {
            void Speak(string str);
        }

        /// <summary>
        /// 如果跟中國人對話，則說漢語
        /// </summary>
        class C_SpeakChinese : ISelectLanguage
        {
            public void Speak(string str)
            {
                MessageBox.Show("您對中國友人說：" + str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 如果跟美國人對話，則說英語
        /// </summary>
        class C_SpeakEnglish : ISelectLanguage
        {
            public void Speak(string str)
            {
                MessageBox.Show("您對美國友人說：" + str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public bool CheckChinese(string str)
        {
            bool flag = false;
            UnicodeEncoding a = new UnicodeEncoding();
            byte[] b = a.GetBytes(str);
            for (int i = 0; i < b.Length; i++)
            {
                i++;
                if (b[i] != 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtContent.Text == "")
            {
                MessageBox.Show("不想跟友人說點什麼嗎？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)//與中國人對話
                {
                    if (CheckChinese(txtContent.Text))
                    {
                        ISelectLanguage Interface1 = new C_SpeakChinese();
                        Interface1.Speak(txtContent.Text);

                    }
                    else
                    {
                        MessageBox.Show("請和中國友人說漢語？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else//與美國人對話
                {
                    if (CheckChinese(txtContent.Text))
                    {
                        MessageBox.Show("請和美國友人說英語？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ISelectLanguage Interface1 = new C_SpeakEnglish();
                        Interface1.Speak(txtContent.Text);
                    }
                }
            }
        }
    }
}
