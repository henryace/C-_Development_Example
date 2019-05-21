using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StartFormByLClosePosition
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            RegistryKey myReg1, myReg2;//宣告註冊表物件
            myReg1 = Registry.CurrentUser;//取得目前用戶註冊表項
            try
            {
                myReg2 = myReg1.CreateSubKey("Software\\MySoft");//在註冊表項中建立子項
                this.Location = new Point(Convert.ToInt16(myReg2.GetValue("1")), Convert.ToInt16(myReg2.GetValue("2")));//設定視窗的顯示位置
            }
            catch { }
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryKey myReg1, myReg2;//宣告註冊表物件
            myReg1 = Registry.CurrentUser;//取得目前用戶註冊表項
            myReg2 = myReg1.CreateSubKey("Software\\MySoft");//在註冊表項中建立子項
            try
            {
                myReg2.SetValue("1", this.Location.X.ToString());//將視窗關閉位置的x坐標寫入註冊表
                myReg2.SetValue("2", this.Location.Y.ToString());//將視窗關閉位置的y坐標寫入註冊表
            }
            catch { }
        }
    }
}