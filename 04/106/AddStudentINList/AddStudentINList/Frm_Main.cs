using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AddStudentINList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ArrayList P_list_StudentInfo = new ArrayList();//實例化集合物件
            string[] P_str_Students, P_str_Info;//定義兩個字串陣列，分別用來記錄學生整體訊息和分解後的訊息
            string P_str_Student = "";//定義一個字串變數，用來記錄所有學生訊息
            //向集合中新增學生訊息
            P_list_StudentInfo.Add("小王 男 1980-01-01");
            P_list_StudentInfo.Add("小劉 女 1981-01-01");
            P_list_StudentInfo.Add("小趙 男 1990-01-01");
            P_list_StudentInfo.Add("小呂 男 1995-01-01");
            P_list_StudentInfo.Add("小梁 男 2000-01-01");
            foreach (string Pc_str_Student in P_list_StudentInfo)//深度搜尋集合
            {
                P_str_Student += Pc_str_Student + ",";//記錄所有學生訊息
            }
            P_str_Students = P_str_Student.Split(',');//將學生訊息存儲在一個字串陣列中
            dgv_Info.Rows.Add(5);//為DataGridView控制元件新增5行
            for (int i = 0; i < P_str_Students.Length - 1; i++)//深度搜尋存儲學生整體訊息的陣列
            {
                P_str_Info = P_str_Students[i].Split(' ');//將學生整體訊息進行分解
                dgv_Info.Rows[i].Cells[0].Value = P_str_Info[0];//顯示學生姓名
                dgv_Info.Rows[i].Cells[1].Value = P_str_Info[1];//顯示性別
                dgv_Info.Rows[i].Cells[2].Value = P_str_Info[2];//顯示出生年月
            }
        }
    }
}
