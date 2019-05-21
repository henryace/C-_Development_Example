using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetFocus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void AllControl_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.CornflowerBlue;//當目前控制元件成為活動控制元件時設定它的背景顏色為藍色
        }

        private void AllControl_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;//當目前控制元件成為不活動控制元件時設定它的背景顏色為白色
        }

        private void AllControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //當按下「Enter」鍵時
            {
                int n = Convert.ToInt32(((TextBox)sender).Tag.ToString());//取得控制元件標識
                Clear_Control(groupBox1.Controls, n, 6); //進入下一個控制元件
            }
        }
        #region  深度搜尋指定的控制元件
        /// <summary>
        /// 深度搜尋指定的控制元件
        /// </summary>
        /// <param Con="ControlCollection">可視化控制元件</param>
        /// <param n="int">控制元件標識</param>
        /// <param m="int">最大標識</param>
        public void Clear_Control(Control.ControlCollection Con, int n, int m)
        {
            int tem_n = 0;//初始化一個int型變數
            foreach (Control C in Con)//深度搜尋可視化元件中的所有控制元件
            {
                if (C.GetType().Name == "TextBox")  //判斷是否為TextBox控制元件
                {
                    if (n == m)//當循環至最後一個控制元件時
                        tem_n = 1;//設定控制元件標識的值為1
                    else //當沒有循環到最後一個控制元件時
                        tem_n = n + 1;//使控制元件的標識值遞增1
                    if (Convert.ToInt32(((TextBox)C).Tag.ToString()) == tem_n)//當與目前控制元件關聯的資料對像為下一個控制元件時
                        ((TextBox)C).Focus();//為目前控制元件設定焦點
                }
            }
        }
        #endregion

    }
}
