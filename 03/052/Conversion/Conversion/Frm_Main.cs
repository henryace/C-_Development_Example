using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conversion
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_transform_Click(object sender, EventArgs e)
        {
            try
            {
                Action();//呼叫Action方法進行轉換操作
            }
            catch (Exception ex)
            {
                MessageBox.Show(//如果出現異常則提示錯誤訊息
                    ex.Message + " 請重新輸入", "出錯！");
            }
        }

        /// <summary>
        /// 此方法用於進制轉換
        /// </summary>
        private void Action()
        {
            if (cbox_select.SelectedIndex != 3)//判斷用戶輸入是否為十六進制數
            {
                long P_lint_value;//定義長整型變數
                if (long.TryParse(txt_value.Text, out P_lint_value))//判斷輸入數值是否正確並賦值
                {
                    if (cbox_select.SelectedIndex == 0)//判斷用戶輸入的是否為十進制數
                    {
                        switch (cbox_select2.SelectedIndex)
                        {
                            case 0:
                                txt_result.Text = txt_value.Text;//將十進制轉為十進制
                                break;
                            case 1:
                                txt_result.Text = //將十進制轉為二進制
                                    new Transform().TenToBinary(long.Parse(txt_value.Text));
                                break;
                            case 2:
                                txt_result.Text = //將十進制轉為八進制
                                    new Transform().TenToEight(long.Parse(txt_value.Text));
                                break;
                            case 3:
                                txt_result.Text = //將十進制轉為十六進制
                                    new Transform().TenToSixteen(long.Parse(txt_value.Text));
                                break;
                        }
                    }
                    else
                    {
                        if (cbox_select.SelectedIndex == 1)//判斷用戶輸入的是否為二進制數
                        {
                            switch (cbox_select2.SelectedIndex)
                            {
                                case 0:
                                    txt_result.Text = //將二進制轉為十進制
                                        new Transform().BinaryToTen(long.Parse(txt_value.Text));
                                    break;
                                case 1:
                                    txt_result.Text = txt_value.Text;//將二進制轉為二進制
                                    break;
                                case 2:
                                    txt_result.Text = //將二進制轉為八進制
                                        new Transform().BinaryToEight(long.Parse(txt_value.Text));
                                    break;
                                case 3:
                                    txt_result.Text = //將二進制轉為十六進制
                                        new Transform().BinaryToSixteen(long.Parse(txt_value.Text));
                                    break;
                            }
                        }
                        else
                        {
                            if (cbox_select.SelectedIndex == 2)//判斷用戶輸入的是否為八進制數
                            {
                                switch (cbox_select2.SelectedIndex)
                                {
                                    case 0:
                                        txt_result.Text = //將八進制轉為十進制
                                            new Transform().EightToTen(long.Parse(txt_value.Text));
                                        break;
                                    case 1:
                                        txt_result.Text = //將八進制轉為二進制
                                            new Transform().EightToBinary(long.Parse(txt_value.Text));
                                        break;
                                    case 2:
                                        txt_result.Text = txt_value.Text;//將八進制轉為八進制
                                        break;
                                    case 3:
                                        txt_result.Text = //將八進制轉為十六進制
                                            new Transform().EightToSixteen(long.Parse(txt_value.Text));
                                        break;
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("請輸入正確數值！", "提示！");//提示錯誤訊息
                }
            }
            else
            {
                switch (cbox_select2.SelectedIndex)
                {
                    case 0:
                        txt_result.Text = //將十六進制轉為十進制
                            new Transform().SixteenToTen(txt_value.Text);
                        break;
                    case 1:
                        txt_result.Text = //將十六進制轉為二進制
                            new Transform().SixteenToBinary(txt_value.Text);
                        break;
                    case 2:
                        txt_result.Text = //將十六進制轉為八進制
                            new Transform().SixteenToEight(txt_value.Text);
                        break;
                    case 3:
                        txt_result.Text = //將十六進制轉為十六進制
                            txt_value.Text;
                        break;
                }
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//初始化Cbox_select默認選項
            cbox_select2.SelectedIndex = 3;//初始化Cbox_select2默認選項
        }
    }
}
