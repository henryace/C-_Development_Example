using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BindToComboBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            cbox_Display.DataSource =//繫結到資料表中的資料
                new DataTier().GetMessage();
            cbox_Display.DisplayMember = "book";//設定顯示屬性
            cbox_Display.ValueMember = "count";//設定實際值
        }

        private void cbox_Display_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_Display.DisplayMember = "book";//設定顯示屬性
            cbox_Display.ValueMember = "count";//設定實際值
            lb_text.Text = //顯示圖書數量
                cbox_Display.SelectedValue.ToString() + " 本";
        }

    }
}
