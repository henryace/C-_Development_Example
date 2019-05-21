using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ProductElectronQuote
{
    public partial class Frm_Main : Form
    {
        Hashtable ht = new Hashtable(); 	//初始化一個哈希表對像
        string str; 					//初始化一個字串str
        public Frm_Main()
        {
            InitializeComponent();
            str = Application.StartupPath + "\\Image";//儲存商品圖片所在的路徑
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(str);//初始化一個DirectoryInfo類的對象
            GetAllFiles(dir); 					//取得指定路徑下的所有文件
            foreach (DictionaryEntry de in ht) 		//循環哈希表中的所有資料
                this.comboBox1.Items.Add(de.Key); 	//向comboBox1中新增內容
        }

        public void GetAllFiles(DirectoryInfo dir)
        {
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos(); 	//初始化一個FileSystemInfo類型的實例
            foreach (FileSystemInfo i in fileinfo) 				//循環深度搜尋fileinfo下的所有內容
            {
                if (i is DirectoryInfo) 			//當在DirectoryInfo中存在i時
                {
                    GetAllFiles((DirectoryInfo)i); 	//取得i下的所有文件
                }
                else						//當在DirectoryInfo中不存在i時
                {
                    string str = i.FullName; 		//記錄i的絕對路徑
                    int b = str.LastIndexOf("\\");	//取得字串下與指定項匹配的最後一個索引
                    string strType = str.Substring(b + 1);			//取得文件的後綴名
                    //當圖片類型為「jpg」或者「bmp」時
                    if (strType.Substring(strType.Length - 3).ToLower() == "jpg" || strType.Substring(strType.Length - 3).ToLower() == "bmp")
                    {
                        ht.Add(strType.Substring(0, strType.Length - 4), strType);	//向哈希表中新增內容
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ht.Values.Count > 0)
            {
                showPic(ht[this.comboBox1.Text].ToString());
            }
            else
            {
                MessageBox.Show("目前還沒有海報訊息！！！");
            }
        }

        private void showPic(string name)
        {
            this.pictureBox1.ImageLocation = str + "\\" + name;//設定在pictureBox1中顯示圖片的路徑
        }
    }
}