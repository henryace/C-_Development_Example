using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChineseCode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            if (txt_Chinese.Text != string.Empty)//判斷輸入是否為空
            {
                try
                {
                    txt_Num.Text = //得到中文字區位碼訊息
                        getCode(txt_Chinese.Text);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(//使用消息對話框提示異常訊息
                        ex.Message + "請輸入正確的中文字", "出錯！");
                }
            }
        }
        /// <summary>
        /// 得到中文字區位碼方法
        /// </summary>
        /// <param name="strChinese">中文字字符</param>
        /// <returns>返回中文字區位碼</returns>
        public string getCode(string Chinese)
        {
            byte[] P_bt_array = Encoding.Default.GetBytes(Chinese);//得到中文字的Byte陣列
            int front = (short)(P_bt_array[0] - '\0');//將字節陣列的第一位轉換成short類型
            int back = (short)(P_bt_array[1] - '\0');//將字節陣列的第二位轉換成short類型
            return (front - 160).ToString() + (back - 160).ToString();//計算並返回區位碼
        }
    }
}
