using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
namespace Playflv
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string xmlPath = "";											//記錄XML文件路徑
        string[] flv = new string[3];										//記錄FLV文件的相關訊息
        FileInfo fi;													// FileInfo對像
        string strg;
        AxShockwaveFlashObjects.AxShockwaveFlash ax;						// AxShockwaveFlash對像用於播放flash

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            AddFlash();
            this.Height = 307;
            strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\FLVPlayer";
            strg += @"\FLVplayer.swf";
            ax.Movie = strg;
        }

        private void AddFlash()
        {
            ax = new AxShockwaveFlashObjects.AxShockwaveFlash();
            panel1.Controls.Add(ax);
            ax.Dock = DockStyle.Fill;
            ax.ScaleMode = 1;
        }

        private void ChangeFlv(string path)
        {
            //取得XML文件的路徑
            xmlPath = Application.StartupPath.ToString();
            xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            xmlPath += @"\FLVPlayer";
            xmlPath += @"\list.xml";
            XmlDocument doc = new XmlDocument();						//建立XmlDocument實例
            doc.Load(xmlPath);										//載入XML文件
            XmlNode nodePath = doc.SelectSingleNode("flvLists/item");			//打開節點
            XmlElement xe = (XmlElement)nodePath;
            xe.SetAttribute("title", path);									//設定元素的屬性
            doc.Save(xmlPath);										//儲存
        }

        private void playFLV(string path)									//播放FLV文件的方法
        {
            FileInfo fi2 = new FileInfo(path);								//實例化FileInfo
            if (fi2.Exists)											//如果文件存在
            {
                Directory.CreateDirectory("c:\\flvVidio");						//新建資料夾
                //隨機產生文件名
                string newPath = "c:\\flvVidio\\" + DateTime.Now.Year + DateTime.Now.Second + ".flv";
                File.Copy(path, newPath);								//將原FLV文件複製到新建的資料夾中
                ChangeFlv(newPath);									//修改XML文件中的播放地址
                this.Text = listView1.SelectedItems[0].SubItems[0].Text;			//顯示正在播放的文件名稱
                ax.Dispose();											//釋放
                AddFlash();											//重新新增播放器
                ax.Movie = strg;										//設定Movie屬性
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)						//判斷是否新增了要播放的文件
                {
                    string path = listView1.SelectedItems[0].SubItems[1].Text;		//取得FLV文件的路徑
                    playFLV(path);									//呼叫playFLV方法播放FLV文件
                }
            }
            catch { }
        }

        private void 清空列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void 打開文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)				//選擇文件
            {
                listView1.Items.Clear();									//清空ListView控制元件
                string[] files = openFileDialog1.FileNames;					//宣告陣列存儲選擇的文件
                for (int i = 0; i < files.Length; i++)							//深度搜尋陣列
                {
                    string flvPath = files[i];								//取得路徑
                    //取得文件名稱
                    string flvName = flvPath.Substring(flvPath.LastIndexOf("\\") + 1, flvPath.Length - flvPath.LastIndexOf("\\") - 1);
                    fi = new FileInfo(flvPath);							//實例化FileInfo
                    flv[0] = flvName;									//文件名稱
                    flv[1] = flvPath;									//文件路徑
                    flv[2] = Convert.ToString(fi.Length / 1024) + "KB";			//文件大小
                    ListViewItem lvi = new ListViewItem(flv);				//建立ListViewItem實例
                    listView1.Items.Add(lvi);							//新增到ListView控制元件中
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ChangeFlv("");
                ax.Dispose();
                Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                fso.DeleteFolder("c:\\flvVidio", true);
            }
            catch { }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (this.Height <= 307)
            {
                this.Height = 448;
                panel2.BackgroundImage = (Image)Properties.Resources.up;
            }
            else
            {
                this.Height = 307;
                panel2.BackgroundImage = (Image)Properties.Resources.down;
            }
        }

        private void 刪除選中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {
                    string flvPath = files[i];
                    string flvName = flvPath.Substring(flvPath.LastIndexOf("\\") + 1, flvPath.Length - flvPath.LastIndexOf("\\") - 1);
                    string fileType = flvName.Substring(flvName.LastIndexOf(".") + 1, flvName.Length - 1 - flvName.LastIndexOf("."));
                    if (fileType.ToLower() == "flv")
                    {
                        fi = new FileInfo(flvPath);
                        flv[0] = flvName;
                        flv[1] = flvPath;
                        flv[2] = Convert.ToString(fi.Length / 1024) + "KB";
                        ListViewItem lvi = new ListViewItem(flv);
                        listView1.Items.Add(lvi);
                    }
                }
            }
        }
    }
}
