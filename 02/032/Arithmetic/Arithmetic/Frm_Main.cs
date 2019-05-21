using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            int P_int_temp;//定義整型變數
            if (int.TryParse(txt_value.Text, out P_int_temp))//為變數賦值
            {
                lb_result.Text = //輸出計算結果
                    "計算結果為：" + Get(P_int_temp).ToString();
            }
            else
            {
                MessageBox.Show(//提示輸入正確數值
                    "請輸入正確的數值！", "提示！");
            }
        }

        /// <summary>
        /// 遞迴算法
        /// </summary>
        /// <param name="i">參與計算的數值</param>
        /// <returns>計算結果</returns>
        int Get(int i)
        {
            if (i <= 0)							//判斷數值是否小於0
                return 0;						//返回數值0
            else if (i >= 0 && i <= 2)			//判斷位數是否大於等於0並且小於等於2
                return 1;						//返回數值1
            else								//如果不滿足上述條件執行下面語句
                return Get(i - 1) + Get(i - 2);	//返回指定位數前兩位數的和
        }
    }
}
