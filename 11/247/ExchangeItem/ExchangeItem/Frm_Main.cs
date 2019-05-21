using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ExchangeItem
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public void AddList()//新增資料
        {
            string P_Connection = string.Format(//建立資料庫連接字串
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //建立連接物件
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//連接到資料庫
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令物件
                "select * from [message]",
                P_OLEDBConnection);
            OleDbDataReader P_Reader = //得到資料讀取器
                P_OLEDBCommand.ExecuteReader();
            while (P_Reader.Read())//讀取資料
            {
                lb_Source.Items.Add(P_Reader[0]);//將資料放入集合
            }
        }

        private void button2_Click(object sender, EventArgs e)//全部新增到選擇的項中
        {
            for (int i = 0; i < lb_Source.Items.Count; i++)
            {
                lb_Source.SelectedIndex = i;//按索引選中項
                lb_Choose.Items.Add(//新增新項
                    lb_Source.SelectedItem.ToString());
            }
            lb_Source.Items.Clear();//清空項
        }

        private void button3_Click(object sender, EventArgs e)//全部新增到資料源中
        {
            for (int i = 0; i < lb_Choose.Items.Count; i++)
            {
                lb_Choose.SelectedIndex = i;//按索引選中項
                lb_Source.Items.Add(//新增項
                    lb_Choose.SelectedItem.ToString());
            }
            lb_Choose.Items.Clear();//清空項
        }
        private void frmListBox_Load(object sender, EventArgs e)
        {
            AddList();//向控制元件中新增資料
        }

        private void button1_Click(object sender, EventArgs e)//單個新增到選擇的項中
        {
            if (lb_Source.SelectedIndex != -1)
            {
                this.lb_Choose.Items.Add(//新增項
                    this.lb_Source.SelectedItem.ToString());
                this.lb_Source.Items.Remove(//移除項
                    this.lb_Source.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)//單個新增到資料源中
        {
            if (lb_Choose.SelectedIndex != -1)
            {
                this.lb_Source.Items.Add(//新增項
                    this.lb_Choose.SelectedItem.ToString());
                this.lb_Choose.Items.Remove(//移除項
                    this.lb_Choose.SelectedItem);
            }
        }
    }
}