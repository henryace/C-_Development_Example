using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuVestige
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            btn_One.Image = //設定按鈕上的圖像
                global::MenuVestige.Properties.Resources.picture;
            btn_Tow.ForeColor = Color.Red;//設定按鈕前景色為紅色
            btn_Three.FlatStyle = FlatStyle.Flat;//設定按鈕以平面顯示
            btn_Three.ForeColor = Color.Blue;//設定按鈕前景色為藍色
            btn_Four.ForeColor = Color.Green;//設定按鈕前景色為綠色
            btn_Four.FlatStyle = FlatStyle.Popup;//得到焦點後按鈕為三維樣式
            btn_Five.FlatStyle = FlatStyle.Standard;//設定按鈕以三維樣式顯示
            btn_six.FlatStyle = FlatStyle.System;//按鈕外觀由操作系統決定
            btn_six.Font = new Font("隸書", 20);//設定按鈕文字字體
        }
    }
}
