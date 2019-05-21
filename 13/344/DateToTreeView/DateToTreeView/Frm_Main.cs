using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DateToTreeView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //宣告本程式需要的變數
        public static string[,] recordInfo;

        //視窗載入時，顯示原有的資料
        private void Form1_Load(object sender, EventArgs e)
        {
            string P_Connection = string.Format(//建立資料庫連接字串
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbDataAdapter P_OLeDbDataAdapter = new OleDbDataAdapter(
                "select au_id as 用戶編號,au_lname as 用戶名,phone as 聯繫電話  from authors",
                P_Connection);
            DataSet ds = new DataSet();
            P_OLeDbDataAdapter.Fill(ds, "UserInfo");
            dataGridView1.DataSource = ds.Tables["UserInfo"].DefaultView;
            TreeNode treeNode = new TreeNode("用戶訊息", 0, 0);
            treeView1.Nodes.Add(treeNode);
            //預設情況下追加節點
            追加節點ToolStripMenuItem.Checked = true;
        }

        //DataGridView的按下鼠標事件
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                //定義一個二維陣列，陣列中的每一行代表DataGridView中的一條記錄
                recordInfo = new string[dataGridView1.Rows.Count, dataGridView1.Columns.Count];

                //當按下鼠標左鍵時，首先取得選定行，記錄每一行對應的訊息
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            recordInfo[i, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
            }
        }

        //當鼠標進入TreeView控制元件時，觸發的操作
        private void treeView1_MouseEnter(object sender, EventArgs e)
        {
            if (追加節點ToolStripMenuItem.Checked == true)
            {
                #region 程式碼區域
                if (recordInfo != null && recordInfo.Length != 0)
                {
                    //用雙重for循環深度搜尋陣列recordInfo中的內容
                    for (int i = 0; i < recordInfo.GetLength(0); i++)
                    {
                        for (int j = 0; j < recordInfo.GetLength(1); j++)
                        {
                            //判斷陣列中的值是否為空
                            if (recordInfo[i, j] != null)
                            {
                                if (j == 0)
                                {
                                    //向TreeView中加入節點
                                    TreeNode Node1 = new TreeNode(recordInfo[i, j].ToString());
                                    treeView1.SelectedNode.Nodes.Add(Node1);
                                    treeView1.SelectedNode = Node1;
                                }
                                else
                                {
                                    //新增子級節點下的子節點
                                    TreeNode Node2 = new TreeNode(recordInfo[i, j].ToString());
                                    treeView1.SelectedNode.Nodes.Add(Node2);
                                }
                            }

                        }
                        treeView1.SelectedNode = treeView1.Nodes[0];
                        treeView1.ExpandAll();
                    }
                    //清空recordInfo中的記錄
                    for (int m = 0; m < recordInfo.GetLength(0); m++)
                    {
                        for (int n = 0; n < recordInfo.GetLength(1); n++)
                        {
                            recordInfo[m, n] = null;
                        }
                    }
                }

                #endregion
            }
            if (清空內容ToolStripMenuItem.Checked == true)
            {
                if (treeView1.SelectedNode.Nodes.Count != 0)
                {
                    treeView1.SelectedNode.Remove();
                    TreeNode treeNode = new TreeNode("用戶訊息", 0, 0);
                    treeView1.Nodes.Add(treeNode);
                    treeView1.SelectedNode = treeNode;
                    #region 程式碼區域
                    if (recordInfo != null && recordInfo.Length != 0)
                    {
                        //用雙重for循環深度搜尋陣列recordInfo中的內容
                        for (int i = 0; i < recordInfo.GetLength(0); i++)
                        {
                            for (int j = 0; j < recordInfo.GetLength(1); j++)
                            {
                                //判斷陣列中的值是否為空
                                if (recordInfo[i, j] != null)
                                {
                                    if (j == 0)
                                    {
                                        //向TreeView中加入節點
                                        TreeNode Node1 = new TreeNode(recordInfo[i, j].ToString());
                                        treeView1.SelectedNode.Nodes.Add(Node1);
                                        treeView1.SelectedNode = Node1;
                                    }
                                    else
                                    {
                                        //新增子級節點下的子節點
                                        TreeNode Node2 = new TreeNode(recordInfo[i, j].ToString());
                                        treeView1.SelectedNode.Nodes.Add(Node2);
                                    }
                                }

                            }
                            treeView1.SelectedNode = treeView1.Nodes[0];
                            treeView1.ExpandAll();
                        }
                        //清空recordInfo中的記錄
                        for (int m = 0; m < recordInfo.GetLength(0); m++)
                        {
                            for (int n = 0; n < recordInfo.GetLength(1); n++)
                            {
                                recordInfo[m, n] = null;
                            }
                        }
                    }

                    #endregion
                    追加節點ToolStripMenuItem.Checked = true;
                    清空內容ToolStripMenuItem.Checked = false;
                }

            }
        }

        #region 預設項的設定
        private void 清空內容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (追加節點ToolStripMenuItem.Checked == true)
            {
                清空內容ToolStripMenuItem.Checked = true;
                追加節點ToolStripMenuItem.Checked = false;
            }
        }

        private void 追加節點ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (清空內容ToolStripMenuItem.Checked == true)
            {
                追加節點ToolStripMenuItem.Checked = true;
                清空內容ToolStripMenuItem.Checked = false;
            }
        }

        #endregion
    }
}
