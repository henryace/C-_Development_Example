using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulTextBox
{
    public partial class NumberBox : TextBox
    {
        public NumberBox()
        {
            InitializeComponent();
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberBox1_KeyPress);//重載事件
            this.Leave += new System.EventHandler(this.numberBox1_Leave);
        }

        #region 常量
        const Int64 UpLine64 = +9223372036854775807;
        const Int64 DownLine64 = -9223372036854775808;
        public static bool ifInt = true;
        #endregion

        #region 新增屬性
        public enum StyleSort
        {
            Null = 0,//無
            Integer = 1,//整數
            Decimal = 2,//小數
        }

        private StyleSort TDataStyle = StyleSort.Integer;
        [Browsable(true), Category("資料文字框"), Description("資料的分類")] //在「屬性」視窗中顯示DataStyle屬性
        public StyleSort DataStyle
        {
            get { return TDataStyle; }
            set
            {
                TDataStyle = value;
                if (ifInt)
                {
                    SetTextBox();
                }
                ifInt = true;
            }
        }

        private int TDecimalDigit = 2;
        [Browsable(true), Category("資料文字框"), Description("保留的小數位數")] //在「屬性」視窗中顯示DecimalDigit屬性
        public int DecimalDigit
        {
            get { return TDecimalDigit; }
            set
            {
                TDecimalDigit = value;
                if (TDecimalDigit < 1)
                    TDecimalDigit = 1;
                if (TDecimalDigit < this.ReservedDigit)
                    this.ReservedDigit = TDecimalDigit;
                SetTextBox();
            }
        }

        public enum Reserved
        {
            MinInt = 0,//保留最小整數
            Round = 1,//四捨五入
            MaxInt = 2,//保留最大整數
            Tropism = 3,//小數取位（不進行捨入）
        }

        private Reserved TReservedStyle = Reserved.Round;
        [Browsable(true), Category("資料文字框"), Description("小數保留的類型")] //在「屬性」視窗中顯示ReservedStyle屬性
        public Reserved ReservedStyle
        {
            get { return TReservedStyle; }
            set
            {
                TReservedStyle = value;
                SetTextBox();
            }
        }

        private int TReservedDigit = 1;
        [Browsable(true), Category("資料文字框"), Description("捨入後小數保留的位數")] //在「屬性」視窗中顯示ReservedDigit屬性
        public int ReservedDigit
        {
            get { return TReservedDigit; }
            set
            {
                TReservedDigit = value;
                if (TReservedDigit >= this.DecimalDigit)
                    TReservedDigit = this.DecimalDigit;
                else
                    SetTextBox();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 執行自定義控制元件的KeyPress事件
        /// </summary>
        protected virtual void numberBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Estimate_Key(e, ((TextBox)sender).Text, Convert.ToInt32(this.DataStyle));
        }

        /// <summary>
        /// 執行自定義控制元件的Leave事件
        /// </summary>
        public virtual void numberBox1_Leave(object sender, System.EventArgs e)
        {
            SetTextBox();
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 根據屬性設定文字框中的內容
        /// </summary>
        public void SetTextBox()
        {
            bool tem_BoolInt = true;//定義一個變數，判斷是否為數值型
            if (this.Multiline == true)//如果允許輸入多行
                return;//退出目前操作
            if (this.Text.Length == 0)//如果Text屬性為空
                return;//退出目前操作
            if (this.Text.Trim() == "-")
            {
                this.Text = "";
                return;//退出目前操作
            }
            else
            {
                char tem_char = '0';
                for (int i = 0; i < this.Text.Length - 1; i++)//循環深度搜尋文字框中的數值
                {
                    tem_char = Convert.ToChar(this.Text.Substring(i, 1));//取得單個字符
                    if ((tem_char > '9' || tem_char < '0'))//如果字符不是數字
                    {
                        if (!(tem_char == '.' || tem_char == '-'))//如果字符不是'.'和'-'
                        {
                            //目前文字不能轉換成數值型資料
                            MessageBox.Show("無法將字串轉換成整數或小數");
                            ifInt = false;
                            this.DataStyle = StyleSort.Null;
                            return;
                        }
                    }
                }

                if (tem_BoolInt)//如果是數值型
                {
                    Decimal tem_value = Convert.ToDecimal(this.Text);//取得目前的值
                    switch (Convert.ToInt32(this.DataStyle))//根據資料類型來進行操作
                    {
                        case 1://整型
                        case 2://小數
                            {
                                if (Math.Floor(tem_value) == tem_value)//如果輸入的是整型
                                    break;//不進行操作
                                switch (Convert.ToInt32(this.ReservedStyle))//判斷小數的保留類型
                                {
                                    case 0://保留最小整數
                                        {
                                            tem_value = Math.Floor(tem_value);
                                            break;
                                        }
                                    case 1://對小數進行四捨五入
                                        {
                                            if (Convert.ToInt32(this.DataStyle) == 1)
                                            {
                                                tem_value = Math.Round(tem_value, 1);
                                            }
                                            else
                                            {
                                                tem_value = Math.Round(tem_value, this.ReservedDigit);
                                            }
                                            break;
                                        }
                                    case 2://保留最大整數
                                        {
                                            tem_value = Convert.ToDecimal(this.Text);
                                            tem_value = Math.Ceiling(tem_value);
                                            break;
                                        }
                                    case 3://保留指定的小數位數
                                        {
                                            string var_str = this.Text;
                                            if (Convert.ToInt32(this.DataStyle) == 2)
                                            {
                                                tem_value = Convert.ToDecimal(var_str.Substring(0, var_str.IndexOf('.') + ReservedDigit + 1));
                                            }
                                            break;
                                        }

                                }
                                break;
                            }

                    }
                    this.Text = tem_value.ToString();//顯示保留後的資料
                }

            }
        }

        /// <summary>
        /// 文字框只能輸入數字型和單精度型的字串.
        /// </summary>
        /// <param name="e">KeyPressEventArgs類</param>
        /// <param name="s">文字框的字串</param>
        /// <param name="n">標識，判斷是字符型、數字型或單精度型</param>
        public void Estimate_Key(KeyPressEventArgs e, string s, int n)
        {
            string tem_s = "";
            if (e.KeyChar == '-')//如果鍵值為'-'
                //如果「-」不在起始位輸入，或以存在'-'
                if (this.SelectionStart != 0 && this.Text.Substring(0, 1) == "-" && this.SelectedText.IndexOf('-') < 0)
                    e.Handled = true;//處理KeyPress事件
            if (e.KeyChar != '\b')//如果目前鍵值不為backspace鍵
            {
                if (e.KeyChar <= '9' && e.KeyChar >= '0')//如果輸入的數字
                {
                    //根據鍵值組合輸入後文字
                    tem_s = s.Substring(0, this.SelectionStart) + e.KeyChar.ToString() + s.Substring(this.SelectionStart, this.Text.Length - this.SelectionLength - this.SelectionStart);
                    if (!Int64Bound(tem_s))//判斷是否在指定範圍內
                        e.Handled = true;//處理KeyPress事件
                }
            }

            switch (n)
            {
                case 0: break;//字串型
                case 1://整數型
                    {
                        //當輸入的鍵值不在0~9或回車鍵、backspace鍵
                        if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b' && e.KeyChar != '-')
                        {
                            e.Handled = true;//處理KeyPress事件
                        }
                        break;
                    }
                case 2://小數
                    {
                        //當輸入的鍵值不在0~9或回車鍵、backspace鍵、'.'
                        if ((!(e.KeyChar <= '9' && e.KeyChar >= '0')) && e.KeyChar != '.' && e.KeyChar != '\r' && e.KeyChar != '\b' && e.KeyChar != '-')
                        {
                            e.Handled = true;//處理KeyPress事件
                        }
                        else
                        {
                            if (e.KeyChar == '.' || e.KeyChar == '\r' || e.KeyChar == '\b')//如果輸入'.'
                            {
                                if (e.KeyChar != '\r' && e.KeyChar != '\b')
                                {
                                    if (s == "")//目前文字框為空
                                        e.Handled = true;   //處理KeyPress事件
                                    else
                                    {
                                        if (s.Length > 0)//當文字框不為空時
                                        {
                                            if (s.IndexOf(".") > -1)//搜尋是否已輸入過'.'
                                                if (this.SelectedText.IndexOf('.') < 0)
                                                    e.Handled = true;//處理KeyPress事件
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (s.IndexOf(".") > -1)//如果輸入了'.'
                                    if (((s.Length - s.IndexOf(".")) > DecimalDigit))//如果超出了小數的保留位數
                                    {
                                        if (this.SelectionStart > s.IndexOf("."))//如果在整數位輸入鍵值
                                        {
                                            if (this.SelectedText.Length == 0)//光標定位
                                                e.Handled = true;

                                        }
                                    }
                            }
                        }
                        break;
                    }
            }

            if (this.Text.Length > 0)//如果值不為空
            {
                if (this.DataStyle != StyleSort.Null && e.KeyChar == '\r')//如果目前輸入的是整數或小數，並且按回車鍵
                {
                    SetTextBox();//對值進行處理
                }
            }
        }

        /// <summary>
        /// 計算指定的字串是否可以轉換成Int64範圍內的數字
        /// </summary>
        /// <param IB="string">字串</param>
        /// <return>布爾型</return>
        public bool Int64Bound(string IB)
        {
            if (IB.IndexOf('-') > 0)//如果在文字框中除第一位以外，還有'-'符號
                return false;//資料錯誤
            double tem_d = Convert.ToDouble(IB);//將字符型轉換成雙精度型
            tem_d = Math.Floor(tem_d);//取整
            if (tem_d <= UpLine64 && tem_d >= DownLine64)//判斷整數位是否在Int64的範圍內
                return true;//資料正確
            else
                return false;
        }
        #endregion
    }
}
