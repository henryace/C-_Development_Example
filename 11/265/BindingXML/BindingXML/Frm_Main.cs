using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//參考與輸入輸出文件流有關的命名空間
using System.Xml;//參考與XML有關的命名空間

namespace BindingXML
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private XmlDocument NexusDocument = new XmlDataDocument();//定義一個XML檔案物件
        private void BindingXML_Load(object sender, EventArgs e)
        {
            string filePath = "NexusPoint.xml";//定義一個變數儲存XML檔案的路徑
            if (File.Exists(filePath))//當在指定路徑下存在該檔案時
            {
                NexusDocument.Load(filePath);//載入該路徑下的XML檔案
                RecursionTreeControl(NexusDocument.DocumentElement, treeView1.Nodes);//將載入完成的XML檔案顯示在TreeView控制元件中
                treeView1.ExpandAll();//展開TreeView控制元件中的所有項
            }
        }
        /// <summary>
        /// RecursionTreeControl:表示將XML文件的內容顯示在TreeView控制元件中
        /// </summary>
        /// <param name="xmlNode">將要載入的XML文件中的節點元素</param>
        /// <param name="nodes">將要載入的XML文件中的節點集合</param>
        private void RecursionTreeControl(XmlNode xmlNode, TreeNodeCollection nodes)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)//循環深度搜尋目前元素的子元素集合
            {
                string temp = (node.Value != null ? node.Value : (node.Attributes != null && node.Attributes.Count > 0) ? node.Attributes[0].Value : node.Name);//表示TreeNode節點的文字內容
                TreeNode new_child = new TreeNode(temp);//定義一個TreeNode節點物件
                nodes.Add(new_child);//向目前TreeNodeCollection集合中新增目前節點
                RecursionTreeControl(node, new_child.Nodes);//呼叫本方法進行遞迴
            }
        }
    }
}
