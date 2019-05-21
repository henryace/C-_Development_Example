using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreIDAndName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string id = "";//定義一個string類型的變數，用來記錄用戶編號
        private string name = "";//定義一個string類型的變數，用來記錄用戶姓名
        /// <summary>
        ///定義用戶編號屬性，該屬性為可讀可寫屬性
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /// <summary>
        ///定義用戶姓名屬性，該屬性為可讀可寫屬性
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ID = "BH001";//為用戶編號屬性賦值
            Name = "MR1";//為用戶姓名屬性賦值
            lab_First.Text = ID + "         " + Name;//顯示用戶編號和用戶姓名
            ID = "BH002";//重新為用戶編號屬性賦值
            Name = "MR2";//重新為用戶姓名屬性賦值
            lab_Second.Text = ID + "         " + Name;//顯示用戶編號和用戶姓名
        }
    }
}
