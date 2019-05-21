using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RefreshFormByChildForm
{
    public partial class Frm_Child : Form
    {
        public Frm_Child()
        {
            InitializeComponent();
        }
        ///<summary>
        /// 本實例僅可建立一個視窗，因此在這裡屏蔽關閉按鈕;最大化後沒有實際意義，因此關閉MaximizeBox屬性值為False
        ///</summary>

        #region 變數的宣告
        public event EventHandler UpdateDataGridView = null;//定義一個處理更新DataGridView控制元件內容的方法
        public static string DeleteID;  //定義一個表示刪除資料編號的字串
        public static string idContent; //該變數用來存儲資料編號
        public static string nameContent;//該變數用來存儲姓名
        public static string phoneContent;//該變數用來存儲電話
        public static string addressContent;//該變數用來存儲住址
        public static bool GlobalFlag; //該變數用來標識是否建立新的子視窗
        #endregion

        protected void UpdateData()
        {
            if (UpdateDataGridView != null)//當觸發更新DataGridView事件時
            {
                UpdateDataGridView(this, EventArgs.Empty);//更新DataGridView控制元件中的內容
            }
        }

        private void Frm_Child_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Main.flag = false; //設定該值為false表示可以建立新視窗
        }

        private void Frm_Child_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Frm_Main.IDArray.Length; i++) //循環深度搜尋陣列中的每一個元素
            {
                comboBox1.Items.Add(Frm_Main.IDArray[i].ToString());//向Combobox控制元件中新增內容
                comboBox1.SelectedIndex = 0;//設定目前選中項的索引為0
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            GlobalFlag = false; //設定全局變數表示為false
            if (comboBox1.Items.Count > 1)//當ComboBox中剩不小於2條內容時
            {
                DeleteID = comboBox1.SelectedItem.ToString();//將選中項轉化為int型
                if (comboBox1.Items.Count != 0)//當ComboBox中剩1條內容時
                {
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    comboBox1.SelectedIndex = 0;
                }
            }
            UpdateData();//更新Combobox控制元件中的內容
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            id.Clear(); //清空編號文字框中的內容
            name.Clear();//清空姓名文字框中的內容
            phone.Clear();//清空電話號碼文字框中的內容
            address.Clear();//清空居住地址文字框中的內容
            id.Focus();//設定目前鼠標的焦點在編號文字框中
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            GlobalFlag = true; //設定標識的值為true
            if (!(comboBox1.Items.Equals(idContent)))//當Combobox控制元件中不存在將新增的訊息時
            {
                comboBox1.Items.Add(idContent);//在Combobox控制元件中新增一條記錄
            }
            UpdateData();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            idContent = id.Text; //儲存新新增記錄的編號
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            nameContent = name.Text;//儲存填入的姓名
        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
            phoneContent = phone.Text;//儲存填入的電話號碼
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            addressContent = address.Text;//儲存填入的地址訊息
        }
    }
}
