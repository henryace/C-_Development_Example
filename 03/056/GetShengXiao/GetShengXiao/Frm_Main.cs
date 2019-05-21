using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetShengXiao
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            System.Globalization.ChineseLunisolarCalendar chinseCaleander =//建立日曆物件
                 new System.Globalization.ChineseLunisolarCalendar();
            string TreeYear = "鼠牛虎兔龍蛇馬羊猴雞狗豬";//建立字串物件
            int intYear = chinseCaleander.GetSexagenaryYear(DateTime.Now);//計算年訊息
            string Tree = TreeYear.Substring(chinseCaleander.//得到生肖訊息
                GetTerrestrialBranch(intYear) - 1, 1);
            MessageBox.Show("今年是十二生肖" + Tree + "年",//輸出生肖訊息
                "判斷十二生肖", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}