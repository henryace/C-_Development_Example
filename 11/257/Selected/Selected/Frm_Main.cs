using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Selected
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void ckInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInfo.Checked == true)//判斷是否選中基本檔案
            {
                ckLinfo.Visible = true;//顯示基本檔案訊息
                CheckAll(ckLinfo);//選中所有基本檔案
            }
            else
            {
                ckLinfo.Visible = false;//隱藏基本檔案訊息
                CheckAllEsce(ckLinfo);//取消選中所有基本檔案
            }
        }

        private void ckShop_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShop.Checked == true)//判斷是否選中進貨管理
            {
                cklShop.Visible = true;//顯示進貨管理訊息
                CheckAll(cklShop);//選中所有進貨管理
            }
            else
            {
                cklShop.Visible = false;//隱藏進貨管理訊息
                CheckAllEsce(cklShop);//取消選中所有進貨管理
            }

        }

        private void ckSell_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSell.Checked == true)//判斷是否選中銷售管理
            {
                cklSell.Visible = true;//顯示銷售管理訊息
                CheckAll(cklSell);//選中所有銷售管理
            }
            else
            {
                cklSell.Visible = false;//隱藏銷售管理訊息
                CheckAllEsce(cklSell);//取消選中所有銷售管理
            }
        }

        private void ckMange_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMange.Checked == true)//判斷是否選中庫存管理
            {
                cklMange.Visible = true;//顯示庫存管理
                CheckAll(cklMange);//選中所有庫存管理
            }
            else
            {
                cklMange.Visible = false;//隱藏庫存管理
                CheckAllEsce(cklMange);//取消選中所有庫存管理
            }
        }
        /// <summary>
        /// 全部選中方法
        /// </summary>
        /// <param name="chckList">控制元件物件</param>
        public void CheckAll(CheckedListBox ckl)
        {
            for (int i = 0; i < ckl.Items.Count; i++)//深度搜尋控制元件中的項並賦值
            { ckl.SetItemCheckState(i, CheckState.Checked); }
        }

        /// <summary>
        /// 全部取選中方法
        /// </summary>
        /// <param name="chckList">控制元件物件</param>
        public void CheckAllEsce(CheckedListBox ckl)
        {
            for (int i = 0; i < ckl.Items.Count; i++)//深度搜尋控制元件中的項並賦值
            { ckl.SetItemCheckState(i, CheckState.Unchecked); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")//判斷用戶輸入是否為空
                {
                    MessageBox.Show(//彈出消息對話框
                        "用戶姓名不能為空", "提示");
                    return;
                }
                if (textBox2.Text == "")//判斷密碼輸入是否為空
                {
                    MessageBox.Show(//彈出消息對話框
                        "用戶密碼", "提示");
                    return;
                }
                if (radMan.Checked == false && //判斷用戶性別輸入是否為空
                    radWoman.Checked == false)
                {
                    MessageBox.Show(//彈出消息對話框
                        "請選擇用戶性別", "提示");
                    return;
                }
                if (ckInfo.Checked == false && ckMange.Checked == false && //判斷是否選擇權限
                    ckSell.Checked == false && ckShop.Checked == false)
                {
                    MessageBox.Show(//彈出消息對話框
                        "請任選一項用戶權限", "提示");
                    return;
                }
                string strName = textBox1.Text.ToString();//得到用戶名訊息
                string strPassword = textBox2.Text;//得到密碼訊息
                string strPhon = textBox3.Text;//得到電話訊息
                string srtEmail = textBox4.Text;//得到郵件地址訊息
                string strAdress = textBox5.Text;//得到地址訊息
                string strSex;//定義性別變數
                if (radWoman.Checked == true)//判斷用戶性別
                {
                    strSex = "女";//為性別變數賦值
                }
                else
                {
                    strSex = "男";//為性別變數賦值
                }

                string strCkNabge = "庫存管理：" + "\n";//建立字串物件
                string strCklsell = "銷售管理：" + "\n";//建立字串物件
                string strCklShop = "進貨管理:" + "\n";//建立字串物件
                string strCkl = "基本檔案:" + "\n";//建立字串物件
                if (ckLinfo.Visible == true)//判斷基本檔案中是否有選擇項
                {

                    for (int i = 0; i < ckLinfo.CheckedItems.Count; i++)
                    {

                        strCkl += //新增輸出訊息
                            ckLinfo.CheckedItems[i].ToString() + "\n";
                    }
                }
                if (cklMange.Visible == true)//判斷庫存管理中是否有選擇項
                {

                    for (int i = 0; i < cklMange.CheckedItems.Count; i++)
                    {
                        strCkNabge += //新增輸出訊息
                            cklMange.CheckedItems[i].ToString() + "\n";
                    }

                }
                if (cklSell.Visible == true)//判斷銷售管理中是否有選擇項
                {

                    for (int i = 0; i < cklSell.CheckedItems.Count; i++)
                    {
                        strCklsell += //新增輸出訊息
                            cklSell.CheckedItems[i].ToString() + "\n";
                    }

                }
                if (cklShop.Visible == true)//判斷進貨管理中是否有選擇項
                {
                    for (int i = 0; i < cklShop.CheckedItems.Count; i++)
                    {
                        strCklShop += //新增輸出訊息
                            cklShop.CheckedItems[i].ToString() + "\n";

                    }
                }
                MessageBox.Show(//彈出消息對話框，輸出用戶輸入權限訊息
                    "註冊訊息如下：" + "\n" + "姓名:" + strName +
                    "\n" + "密碼：" + strPassword + "\n" + "電話:" +
                    strPhon + "\n" + "信箱:" + srtEmail + "\n" +
                    "地址:" + strAdress + "\n" + "性別：" + strSex +
                    "\n" + "用戶權限如下：" + "\n" +
                    strCkl + strCkNabge + strCklsell + strCklShop, "訊息確認");
            }
            catch (Exception ee)
            {
                MessageBox.Show(//彈出消息對話框
                    ee.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radWoman.Checked = false;//取消選擇性別女
            radMan.Checked = false;//取消選擇性別男

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";//初始化控制元件
            textBox2.Text = "";//初始化控制元件
            textBox3.Text = "";//初始化控制元件
            textBox4.Text = "";//初始化控制元件
            textBox5.Text = "";//初始化控制元件
            radWoman.Checked = false;//初始化控制元件
            radMan.Checked = false;//初始化控制元件
            ckInfo.Checked = false;//初始化控制元件
            ckMange.Checked = false;//初始化控制元件
            ckSell.Checked = false;//初始化控制元件
            ckShop.Checked = false;//初始化控制元件
        }
    }
}