using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GetGridData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //向DataGridView中新增資料
            this.dataGridView1.ColumnCount = 5;
            this.dataGridView1.Rows.Add(new string[] { "一", "二", "三", "四", "五" });
            this.dataGridView1.Rows.Add(new string[] { "六", "七", "八", "九", "十" });
            this.dataGridView1.Rows.Add(new string[] { "十一", "十二", "十三", "十四", "十五" });
            this.dataGridView1.Rows.Add(new string[] { "十六", "十七", "十八", "十九", "二十" });
            this.dataGridView1.Rows.Add(new string[] { "二十一", "二十二", "二十三", "二十四", "二十五" });
            this.dataGridView1.AutoResizeColumns();
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private string str = "";
        private bool Bool_Blank = false;//儲存格是否為空
        private bool Bool_All = false;//是否全部替換

        private void button1_Click(object sender, EventArgs e)
        {
            str = CopyDataGridView(dataGridView1);
            AddDataGridView(dataGridView2, str, Bool_Blank, Bool_All);
        }

        /// <summary>
        /// 透過剪貼簿複製DataGridView控制元件中所選中的內容.
        /// </summary>
        /// <param DGView="DataGridView">DataGridView類</param>
        /// <return>字串</return>
        public string CopyDataGridView(DataGridView DGView)
        {
            string tem_str = "";
            if (DGView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    //將資料新增到剪貼簿中
                    Clipboard.SetDataObject(DGView.GetClipboardContent());
                    //從剪貼簿中取得訊息
                    tem_str = Clipboard.GetText();
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    return "";
                }
            }
            return tem_str;
        }

        /// <summary>
        /// 將字串按指定的格式新增到DataGridView控制元件中（如果有被選中的儲存格，則修改儲存格中的內容）.
        /// </summary>
        /// <param DGView="DataGridView">DataGridView類</param>
        /// <param s="string">要替換的儲存格字串</param>
        /// <param Blank="bool">標識，如果是空格是否替換成空格</param>
        /// <param All="bool">標識，是否全部替換</param>
        public void AddDataGridView(DataGridView DGView, string s, bool Blank, bool All)
        {
            string tem_str = s;
            int tem_n = 0;
            int RowCount = 0;//行數
            int CellCount = 0;//列數
            bool tem_bool = true;
            string tem_s = "";
            if (s.IndexOf("\r\n") != -1)//如果替換的為多行
                while (tem_bool)//取得儲存格的行數和列數
                {
                    tem_s = "";
                    if (tem_str.IndexOf("\r\n") != -1)//如果取得的不是最後一行
                    {
                        tem_s = tem_str.Substring(0, tem_str.IndexOf("\r\n") + 2);//取得目前行中的資料
                        //取得目前行中能被識別的資料
                        tem_str = tem_str.Substring(tem_str.IndexOf("\r\n") + 2, tem_str.Length - tem_str.IndexOf("\r\n") - 2);
                        tem_n = 1;
                        while (tem_s.IndexOf("\t") > -1)//深度搜尋目前行中的空格
                        {
                            //去除已讀取的空格
                            tem_s = tem_s.Substring(tem_s.IndexOf("\t") + 1, tem_s.Length - tem_s.IndexOf("\t") - 1);
                            tem_n += 1;//取得列數
                        }
                        if (tem_n > CellCount)//判斷目前列數是否為最大列數
                            CellCount = tem_n;//取得最大的列數
                    }
                    else//如果讀取的是最後一行
                    {
                        tem_n = 1;
                        while (tem_s.IndexOf("\t") > -1)
                        {
                            tem_s = tem_s.Substring(tem_s.IndexOf("\t") + 1, tem_s.Length - tem_s.IndexOf("\t") - 1);
                            tem_n += 1;
                        }
                        if (tem_n > CellCount)
                            CellCount = tem_n;
                        tem_bool = false;//深度搜尋結束
                    }
                    ++RowCount;//讀取行數
                }
            else//如果讀取的為單行資料
            {
                tem_n = 1;
                tem_s = s;
                while (tem_s.IndexOf("\t") > -1)
                {
                    tem_s = tem_s.Substring(tem_s.IndexOf("\t") + 1, tem_s.Length - tem_s.IndexOf("\t") - 1);
                    tem_n += 1;
                }
                if (tem_n > CellCount)
                    CellCount = tem_n;
                ++RowCount;//讀取行數
            }
            string[,] Strarr = new string[RowCount, CellCount];//定義一個陣列，用於記錄複製的儲存格訊息

            tem_str = s;
            tem_n = 0;
            //將儲存格訊息新增到陣列中
            for (int i = 0; i < RowCount; i++)//深度搜尋儲存格的行
            {
                for (int j = 0; j < CellCount; j++)//深度搜尋儲存格的列
                {
                    tem_s = "";
                    if (tem_str.IndexOf("\r\n") != -1)//如果不是最後一行
                    {
                        if (tem_str.IndexOf("\t") <= -1)//設定讀取資料的位置
                            tem_n = tem_str.IndexOf("\r");//最後一個資料的位置
                        else
                            tem_n = tem_str.IndexOf("\t");//不是最後一個資料的位置
                        tem_s = tem_str.Substring(0, tem_str.IndexOf("\r\n") + 2);//讀取儲存格資料
                    }
                    else//如果是最後一行
                    {
                        if (tem_str.IndexOf("\t") <= -1)//設定讀取資料的位置
                            tem_n = tem_str.Length;//最後一個資料的位置
                        else
                            tem_n = tem_str.IndexOf("\t");//不是最後一個資料的位置
                        tem_s = tem_str;//讀取儲存格資料
                    }
                    if (tem_s.Length > 0)//如果目前行有資料
                    {
                        if (tem_s.Substring(0, 1) == "\t")//如果第一個字符為空
                            Strarr[i, j] = "";//向陣列中新增一個空記錄
                        else
                        {
                            Strarr[i, j] = tem_s.Substring(0, tem_n);//向陣列中新增資料
                        }
                    }
                    else
                        Strarr[i, j] = "";//向陣列中新增空記錄
                    if (tem_s.Length > tem_n)//如果記錄沒有讀取完
                        tem_str = tem_s.Substring(tem_n + 1, tem_s.Length - tem_n - 1);//取得沒有讀取的記錄
                }
                if (s.IndexOf("\r\n") > -1)//如果不是最後一行資料
                {
                    s = s.Substring(s.IndexOf("\r\n") + 2, s.Length - s.IndexOf("\r\n") - 2);//讀取下一行資料
                    tem_str = s;
                }
            }
            if (All)//如果要全部替換
                DGView.Rows.Clear();//清空DataGridView控制元件
            if (DGView.SelectedRows.Count == 0 && DGView.SelectedCells.Count == 0)//如果DataGridView中沒有資料
            {
                DGView.ColumnCount = CellCount;//設定列數
                string[] stra = new string[CellCount];//定義一個一維陣列
                //向DataGridView中新增行資料
                for (int i = 0; i < RowCount; i++)//讀取行
                {
                    for (int j = 0; j < CellCount; j++)//讀取列
                    {
                        if (Strarr[i, j] == "")//如果目前儲存格為空
                        {
                            if (Blank)//如果用*號替換
                                stra[j] = "*";//在空儲存格中新增*號
                            else
                                stra[j] = "";//以空格顯示空儲存格
                        }
                        else
                        {
                            stra[j] = Strarr[i, j];//記錄目前行中的訊息
                        }
                    }
                    DGView.Rows.Add(stra);//將行中的訊息新增到DataGridView控制元件

                }
                DGView.AutoResizeColumns();//向DataGridView控制元件新增所有的儲存格訊息
                DGView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;//將所選擇的儲存格複製到剪貼簿中
            }
            else//如果DataGridView中有資料
            {
                int maxrow = 0;//記錄DataGridView控制元件中最小儲存格的行數
                int maxcell = 0;//記錄DataGridView控制元件中最小儲存格的列數
                for (int i = 0; i < DGView.SelectedCells.Count; i++)//取得選中儲存格中最大儲存格的行數和列數
                {
                    if (DGView.SelectedCells[i].RowIndex > maxrow)//如果儲存格的行數大於目前指定的行數
                        maxrow = DGView.SelectedCells[i].RowIndex;//記錄目前儲存格的行數
                    if (DGView.SelectedCells[i].ColumnIndex > maxcell)//如果儲存格的列數大於目前指定的列數
                        maxcell = DGView.SelectedCells[i].ColumnIndex;//記錄目前儲存格的列數
                }
                int minrow = maxrow;//記錄DataGridView控制元件中最大儲存格的行數
                int mincell = maxcell;//記錄DataGridView控制元件中最大儲存格的列數
                for (int i = 0; i < DGView.SelectedCells.Count; i++)//取得選中儲存格中最小儲存格的行數和列數
                {
                    if (DGView.SelectedCells[i].RowIndex < minrow)//如果儲存格的行數小於目前指定的行數
                        minrow = DGView.SelectedCells[i].RowIndex;//記錄目前儲存格的行數
                    if (DGView.SelectedCells[i].ColumnIndex < mincell)//如果儲存格的列數小於目前指定的列數
                        mincell = DGView.SelectedCells[i].ColumnIndex;//記錄目前儲存格的列數
                }
                //向DataGridView控制元件中新增選中儲存格中最小儲存格與最大儲存格中的所有儲存格
                for (int i = 0; i < maxrow - (minrow - 1); i++)//深度搜尋行數
                {
                    if (i >= RowCount)//如果超出要新增的行數
                        break;//退出循環
                    for (int j = 0; j < maxcell - (mincell - 1); j++)//深度搜尋列數
                    {
                        if (j >= CellCount)//如果超出要新增的列數
                            break;//退出循環
                        if (Strarr[i, j] == "")//如果新增的儲存格為空
                        {
                            if (Blank)//如果用*號替換空格
                                DGView.Rows[i + minrow].Cells[j + mincell].Value = "*";//用*號替換空儲存格
                        }
                        else
                            DGView.Rows[i + minrow].Cells[j + mincell].Value = Strarr[i, j];//設定目前儲存格的值
                    }
                }
            }

        }

        private void Tool_Blank_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)//如果該項被選中
            {
                ((ToolStripMenuItem)sender).Checked = false;//取消該項的選中狀態
                Bool_Blank = false;//空儲存格不用*號替換
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;//設定該項被選中
                Bool_Blank = true;//空儲存格用*號替換
            }
        }

        private void Tool_All_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)//如果該項被選中
            {
                ((ToolStripMenuItem)sender).Checked = false;//取消該項的選中狀態
                Bool_All = false;//全部替換
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;//設定該項被選中
                Bool_All = true;//替換選中的部份
            }
        }
    }
}
