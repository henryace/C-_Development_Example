using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace SelectXMLByHasTable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 在XML文件中搜尋電台地址及名稱
        /// <summary>
        /// 在XML文件中搜尋電台地址及名稱
        /// </summary>
        /// <param name="strPath">XML文件路徑</param>
        /// <returns>Hashtable對象，用來記錄找到的電台地址及名稱</returns>
        static Hashtable SelectXML(string strPath)
        {
            Hashtable HTable = new Hashtable();//實例化雜湊表物件
            XmlDocument doc = new XmlDocument();//實例化XML文檔物件
            doc.Load(strPath);//載入XML文檔
            XmlNodeList xnl = doc.SelectSingleNode("BCastInfo").ChildNodes;//取得NewDataSet節點的所有子節點
            string strVersion = "";//定義一個字串，用來記錄電台地址
            string strInfo = "";//定義一個字串，用來記錄電台名稱
            foreach (XmlNode xn in xnl)//深度搜尋所有子節點
            {
                XmlElement xe = (XmlElement)xn;//將子節點類型轉換為XmlElement類型
                if (xe.Name == "DInfo")//判斷節點名為DInfo
                {
                    XmlNodeList xnlChild = xe.ChildNodes;//繼續取得xe子節點的所有子節點
                    foreach (XmlNode xnChild in xnlChild)//深度搜尋
                    {
                        XmlElement xeChild = (XmlElement)xnChild;//轉換類型
                        if (xeChild.Name == "Address")
                        {
                            strVersion = xeChild.InnerText;//記錄電台地址
                        }
                        if (xeChild.Name == "Name")
                        {
                            strInfo = xeChild.InnerText;//記錄電台名稱
                        }
                    }
                    HTable.Add(strVersion, strInfo);//向雜湊表中新增鍵值
                }
            }
            return HTable;
        }
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Hashtable myHashtable = SelectXML("BroadCastInfo.xml");//使用自定義方法實例化哈希表物件
            IDictionaryEnumerator IDEnumerator = myHashtable.GetEnumerator();//循環訪問雜湊表
            while (IDEnumerator.MoveNext())
            {
                cbox_Name.Items.Add(IDEnumerator.Value.ToString());//顯示電台名稱
                cbox_NetAddress.Items.Add(IDEnumerator.Key.ToString());//顯示電台網址
            }
            cbox_Name.SelectedIndex = cbox_NetAddress.SelectedIndex = 0;//設定默認選項
        }
    }
}
