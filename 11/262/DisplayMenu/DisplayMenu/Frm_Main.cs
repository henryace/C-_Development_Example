using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region  將MenuStrip控制元件中的訊息新增到TreeView控制元件中
        /// <summary>
        /// 將MenuStrip控制元件中的首行命令項新增到TreeView控制元件中
        /// </summary>
        /// <param treeV="TreeView">TreeView控制元件</param>
        /// <param MenuS="MenuStrip">MenuStrip控制元件</param>
        public void GetMenu(TreeView treeV, MenuStrip MenuS)
        {
            bool Var_Bool = true;
            for (int i = 0; i < MenuS.Items.Count; i++) //深度搜尋MenuStrip組件中的一級功能表項
            {
                //將一級功能表項的名稱新增到TreeView組件的根節點中，並設定目前節點的子節點newNode1
                TreeNode newNode1 = treeV.Nodes.Add(MenuS.Items[i].Text);
                if (MenuS.Items[i].Enabled == false)//判斷目前項是否為可用
                {
                    newNode1.ForeColor = Color.Silver;//改變樹節點的字體顏色為不可用色
                    Var_Bool = false;
                }
                else
                {
                    newNode1.ForeColor = Color.Black;//改變樹節點的字體顏色為可用色
                    Var_Bool = true;
                }
                newNode1.Tag = 0;//標識，有子項的命令項
                //將目前功能表項的所有相關訊息存入到ToolStripDropDownItem物件中
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                GetCavernMenu(newNode1, newmenu, Var_Bool);//新增多層命令項
            }
        }

        /// <summary>
        /// 將MenuStrip控制元件中的多層命今項新增到TreeView控制元件中
        /// </summary>
        /// <param newNodeA="TreeNode">TreeNode物件</param>
        /// <param newmenuA="ToolStripDropDownItem">ToolStripDropDownItem物件</param>
        /// <param BL="bool">標識（是否可用）</param>
        public void GetCavernMenu(TreeNode newNodeA, ToolStripDropDownItem newmenuA, bool BL)
        {
            bool Var_Bool = true;
            if (newmenuA.HasDropDownItems && newmenuA.DropDownItems.Count > 0)
                for (int j = 0; j < newmenuA.DropDownItems.Count; j++)    //深度搜尋二級功能表項
                {
                    //將二級功能表名稱新增到TreeView組件的子節點newNode1中，並設定目前節點的子節點newNode2
                    TreeNode newNodeB = newNodeA.Nodes.Add(newmenuA.DropDownItems[j].Text);
                    Var_Bool = true;
                    if (BL == false)//判斷目前命令項的上一級命令是否可用
                    {
                        newNodeB.ForeColor = Color.Silver;//設定目前命令項的字體顏色為不可用色
                        newNodeB.Tag = 0;//標識，不顯示相應的視窗
                        Var_Bool = false;
                    }
                    else
                    {
                        if (newmenuA.DropDownItems[j].Enabled == false)//判斷目前命令項是否為可用
                        {
                            newNodeB.ForeColor = Color.Silver;//設定目前命令項的字體顏色為不可用色
                            newNodeB.Tag = 0;//標識，不顯示相應的視窗
                            Var_Bool = false;
                        }
                        else
                        {
                            newNodeA.ForeColor = Color.Black;//設定目前命令項的字體顏色為可用色
                            newNodeB.Tag = int.Parse(newmenuA.DropDownItems[j].Tag.ToString());//標識，顯示相應的視窗
                        }
                    }
                    //將目前功能表項的所有相關訊息存入到ToolStripDropDownItem物件中
                    ToolStripDropDownItem newmenuB = (ToolStripDropDownItem)newmenuA.DropDownItems[j];
                    if (newmenuB.HasDropDownItems && newmenuA.DropDownItems.Count > 0)//如果目前命令項有子項
                    {
                        newNodeB.Tag = 0;//標識，有子項的命令項
                        GetCavernMenu(newNodeB, newmenuB, Var_Bool);//呼叫遞迴方法
                    }
                }
        }
        #endregion

        #region  打開MenuStrip控制元件或TreeView控制元件相應的視窗
        /// <summary>
        /// 打開MenuStrip控制元件或TreeView控制元件相應的視窗
        /// </summary>
        /// <param n="int">標識</param>
        /// <param FName="string">名稱</param>
        public void frm_show(int n, string FName)
        {
            switch (n)//透過標識呼叫各子視窗
            {
                case 0: break;
                case 1:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 2:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 3:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 4:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 5:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 6:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 7:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 8:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 9:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 10:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 11:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 12:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 13:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 14:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 15:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 16:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 17:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 18:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 19:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 21:
                    {
                        //打開記事本
                        System.Diagnostics.Process.Start("notepad.exe");
                        break;
                    }
                case 22:
                    {
                        //打開計算器
                        System.Diagnostics.Process.Start("calc.exe");
                        break;
                    }
                case 23:
                    {
                        //打開WORD文檔
                        System.Diagnostics.Process.Start("WINWORD.EXE");
                        break;
                    }
                case 24:
                    {
                        //打開EXCEL文件
                        System.Diagnostics.Process.Start("EXCEL.EXE");
                        break;
                    }
                case 25:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 26:
                    {
                        if (MessageBox.Show("確認退出系統嗎？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            Application.Exit();//關閉目前工程
                        break;
                    }
                case 27:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 28:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 29:
                    {
                        Form2 fp = new Form2();//實例化一個視窗
                        fp.Text = FName;//設定視窗的名稱
                        fp.ShowDialog();//用模試對話框打開視窗
                        fp.Dispose();//釋放視窗的所有資原
                        break;
                    }
                case 30:
                    {
                        //打開幫助對話框
                        MessageBox.Show("\t你可以到明日科技網站\t\n\n\t  得到你想知道的\n\t    謝謝使用！！");
                        break;
                    }
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMenu(treeView1, menuStrip1);//將menuStrip1控制元件中的訊息新增到treeView1控制元件中
        }

        private void ToolStrip_1_Click(object sender, EventArgs e)
        {
            frm_show(//打開MenuStrip控制元件或TreeView控制元件相應的視窗
                Convert.ToInt16(((ToolStripMenuItem)sender).Tag.ToString()), ((ToolStripMenuItem)sender).Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frm_show(//打開MenuStrip控制元件或TreeView控制元件相應的視窗
                Convert.ToInt16(((ToolStripButton)sender).Tag.ToString()), ((ToolStripButton)sender).Text);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            frm_show(//打開MenuStrip控制元件或TreeView控制元件相應的視窗
                Convert.ToInt16(e.Node.Tag.ToString()), e.Node.Text);
        }
    }
}
