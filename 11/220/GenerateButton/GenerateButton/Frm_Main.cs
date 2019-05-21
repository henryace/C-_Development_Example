using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenerateButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Random G_Random = new Random();

        private void Frm_Main_MouseClick(object sender, MouseEventArgs e)
        {
            Button bt = new Button()//建立按鈕物件
            {
                Text = "動態產生按鈕",//設定按鈕的文字訊息
                ForeColor = Color.FromArgb(//設定按鈕的前景顏色
                G_Random.Next(0, 255),
                G_Random.Next(0, 255),
                G_Random.Next(0, 255)),
                AutoSize = true,//設定按鈕自動調整大小
                Location = e.Location//設定按鈕位置
            };
            Controls.Add(bt);//將按鈕加入控制元件集合
        }
    }
}
