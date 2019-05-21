using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Getdirectory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode CountNode = new TreeNode("我的電腦");//初始化TreeView控制元件新增總結點
            TreeViewFile.Nodes.Add(CountNode);
            ListViewShow(CountNode);	//初始化ListView控制元件
        }

        private void ListViewShow(TreeNode NodeDir)//初始化ListView控制元件，把TrreView控制元件中的資料新增進來
        {
            ListViewFile.Clear();
            if (NodeDir.Parent == null)// 如果目前TreeView的父結點為空，就把我的電腦下的分區名稱新增進來
            {
                foreach (string DrvName in Directory.GetLogicalDrives())//取得硬盤分區名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName);
                    ListViewFile.Items.Add(ItemList);//新增進來
                }
            }
            else//如果目前TreeView的父結點不為空，把點擊的結點，做為一個目錄文件的總結點
            {
                foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))//編歷目前分區或文件夾所有目錄
                {
                    ListViewItem ItemList = new ListViewItem(DirName);
                    ListViewFile.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles((string)NodeDir.Tag))//編歷目前分區或文件夾所有目錄的文件
                {
                    ListViewItem ItemList = new ListViewItem(FileName);
                    ListViewFile.Items.Add(ItemList);
                }
            }
        }
        private void ListViewShow(string DirFileName)//取得當有文件夾內的文件和目錄
        {
            ListViewFile.Clear();//清空控制元件內容
            foreach (string DirName in Directory.GetDirectories(DirFileName))
            {
                ListViewItem ItemList = //建立控制元件項
                    new ListViewItem(DirName);
                ListViewFile.Items.Add(ItemList);//向控制元件新增項
            }
            foreach (string FileName in Directory.GetFiles(DirFileName))
            {
                ListViewItem ItemList = //建立控制元件項
                    new ListViewItem(FileName);
                ListViewFile.Items.Add(ItemList);//向控制元件新增項
            }
        }

        private void TreeViewShow(TreeNode NodeDir)//初始化TreeView控制元件
        {
            if (NodeDir.Nodes.Count == 0)//判斷節點數量是否為0
            {
                if (NodeDir.Parent == null)//如果結點為空顯示硬盤分區
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())
                    {
                        TreeNode aNode = new TreeNode(DrvName);//建立節點物件
                        aNode.Tag = DrvName;//向控制元件中新增資料
                        NodeDir.Nodes.Add(aNode);//新增節點
                    }
                }
                else// 不為空，顯示分區下文件夾
                {
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                    {
                        TreeNode aNode = new TreeNode(DirName);//建立節點物件
                        aNode.Tag = DirName;//向控制元件中新增資料
                        NodeDir.Nodes.Add(aNode);//新增節點
                    }
                }
            }
        }


        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewShow(e.Node);//初始化ListView控制元件
            TreeViewShow(e.Node);//初始化TreeView控制元件
        }

        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            foreach (int ListIndex in ListViewFile.SelectedIndices)
            {
                ListViewShow(//取得文件和目錄
                    ListViewFile.Items[ListIndex].Text);
            }
        }
    }
}