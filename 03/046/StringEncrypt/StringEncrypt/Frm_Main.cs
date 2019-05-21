using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringEncrypt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            if (txt_password.Text.Length == 4)//判斷加密密鑰長度是否正確
            {
                try
                {
                    txt_EncryptStr.Text = //呼叫實例ToEncrypt方法得到加密後的字串
                        new Encrypt().ToEncrypt(
                        txt_password.Text, txt_str.Text);
                    //Encrypt P_Encrypt = new Encrypt();
                    //P_Encrypt.ToEncrypt(""
                }
                catch (Exception ex)//捕獲異常
                {
                    MessageBox.Show(ex.Message);//輸出異常訊息
                }
            }
            else
            {
                MessageBox.Show("密鑰長度不符！", "提示");//提示用戶輸入密鑰長度不正確
            }
        }
        private void btn_UnEncrypt_Click(object sender, EventArgs e)
        {
            if (txt_password2.Text.Length == 4)//判斷加密密鑰長度是否正確
            {
                try
                {
                    txt_str2.Text = //呼叫ToDecrypt方法得到解密後的字串
                        new Encrypt().ToDecrypt(
                        txt_password2.Text, txt_EncryptStr2.Text);
                }
                catch (Exception ex)//捕獲異常
                {
                    MessageBox.Show(ex.Message);//輸出異常訊息
                }
            }
            else
            {
                MessageBox.Show("密鑰長度不符！", "提示");//提示用戶輸入密鑰長度不正確
            }
        }
    }
}
