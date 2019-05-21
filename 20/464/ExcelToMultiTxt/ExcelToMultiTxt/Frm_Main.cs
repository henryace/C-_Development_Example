using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ExcelToMultiTxt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//設定打開文件篩選器
            openFileDialog1.Title = "選擇Excel文件";//設定打開對話框標題
            openFileDialog1.Multiselect = false;//設定打開對話框中只能單選
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文字框中顯示Excel文件名
                CBoxBind();//對下拉列表進行資料繫結
            }
        }

        private void cbox_SheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_Count.Items.Clear();//清空下拉列表項
            for (int i = 1; i <= CBoxShowCount().Tables[0].Rows.Count; i++)//深度搜尋資料集中的行數
            {
                if (CBoxShowCount().Tables[0].Rows.Count % i == 0)
                    cbox_Count.Items.Add(i);//根據資料集行數確定下拉列表中的值
            }
            if (cbox_Count.Items.Count > 0)//如果下拉列表中有項
                cbox_Count.SelectedIndex = 0;//預設選擇第一項
        }

        private void btn_Txt_Click(object sender, EventArgs e)
        {
            WriteContent();//呼叫自定義方法分解Excel資料
            MessageBox.Show("已經將" + cbox_SheetName.Text + "工作表中的資料分解到了" + cbox_Count.Text + "個文字文件中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //取得指定Excel中的所有工作表，並繫結到下拉列表
        private void CBoxBind()
        {
            cbox_SheetName.Items.Clear();//清空下拉列表項
            //連接Excel資料庫
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=Excel 8.0");
            olecon.Open();//打開資料庫連接
            System.Data.DataTable DTable = olecon.GetSchema("Tables");//實例化表對像
            DataTableReader DTReader = new DataTableReader(DTable);//實例化表讀取對像
            while (DTReader.Read())//循環讀取
            {
                string P_str_Name = DTReader["Table_Name"].ToString().Replace('$', ' ').Trim();//記錄工作表名稱
                if (!cbox_SheetName.Items.Contains(P_str_Name))//判斷下拉列表中是否已經存在該工作表名稱
                {
                    cbox_SheetName.Items.Add(P_str_Name);//將工作表名新增到下拉列表中
                }
            }
            DTable = null;//清空表對像
            DTReader = null;//清空表讀取對像
            olecon.Close();//關閉資料庫連接
        }

        //取得Excel工作表中的資料
        private DataSet CBoxShowCount()
        {
            //連接Excel資料庫
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=Excel 8.0");
            OleDbDataAdapter oledbda = new OleDbDataAdapter("select * from [" + cbox_SheetName.Text + "$]", olecon);//從工作表中查詢資料
            DataSet myds = new DataSet();//實例化資料集對像
            oledbda.Fill(myds);//填充資料集
            return myds;//返回資料集
        }

        //將Excel資料分解到多個文字文件中
        private void WriteContent()
        {
            int P_int_Counts = CBoxShowCount().Tables[0].Rows.Count;//取得記錄總數
            int P_int_Page = Convert.ToInt32(cbox_Count.Text);//記錄要分解為幾個文件
            int P_int_PageRow = Convert.ToInt32(P_int_Counts / P_int_Page);//記錄每個文件的記錄數
            for (int i = 0; i < P_int_Page; i++)//循環訪問每個文件
            {
                using (StreamWriter SWriter = new StreamWriter(cbox_SheetName.Text + i + ".txt", false, Encoding.Default))//實例化寫入流對像
                {
                    string P_str_Content = "";//存儲讀取的內容
                    for (int r = i * P_int_PageRow; r < (i + 1) * P_int_PageRow; r++)//深度搜尋資料集中表的行數
                    {
                        if (r < P_int_Counts)//判斷深度搜尋到的行數是否小於總行數
                        {
                            for (int c = 0; c < CBoxShowCount().Tables[0].Columns.Count; c++)//深度搜尋資料集中表的列數
                            {
                                P_str_Content += CBoxShowCount().Tables[0].Rows[r][c].ToString() + "  ";//記錄目前深度搜尋到的內容
                            }
                            P_str_Content += Environment.NewLine;//字串換行
                        }
                    }
                    SWriter.Write(P_str_Content);//先文字文件中寫入內容
                    SWriter.Close();//關閉寫入流對像
                }
            }
        }
    }
}