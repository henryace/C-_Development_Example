using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
namespace IMGAddDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public string flag = null;
        PropertyItem[] pi;
        string TakePicDateTime;
        int SpaceLocation;
        string pdt;
        string ptm;
        Bitmap Pic;
        Graphics g;
        Thread td;
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] IMG;
            listBox1.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IMG = openFileDialog1.FileNames;
                if (IMG.Length > 0)
                {
                    for (int i = 0; i < IMG.Length; i++)
                    {
                        listBox1.Items.Add(IMG[i]);
                    }
                }
                flag = IMG.Length.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            flag = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag == null || txtSavePath.Text == "")
            {
                return;
            }
            else
            {
                toolStripProgressBar1.Visible = true;
                td = new Thread(new ThreadStart(AddDate));
                td.Start();
            }
        }

        private void AddDate()
        {
            Font normalContentFont = new Font("細明體", 36, FontStyle.Bold);
            Color normalContentColor = Color.Red;
            int kk = 1;
            toolStripProgressBar1.Maximum = listBox1.Items.Count;
            toolStripProgressBar1.Minimum = 1;
            toolStripStatusLabel1.Text = "開始新增數位相片拍攝日期";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                pi = GetExif(listBox1.Items[i].ToString());
                //取得元資料中的拍照日期時間，以字串形式儲存
                TakePicDateTime = GetDateTime(pi);
                //分析字串分別儲存拍照日期和時間的標準格式
                SpaceLocation = TakePicDateTime.IndexOf(" ");
                pdt = TakePicDateTime.Substring(0, SpaceLocation);
                pdt = pdt.Replace(":", "-");
                ptm = TakePicDateTime.Substring(SpaceLocation + 1, TakePicDateTime.Length - SpaceLocation - 2);
                TakePicDateTime = pdt + " " + ptm;
                //由列表中的文件建立記憶體位圖物件
                Pic = new Bitmap(listBox1.Items[i].ToString());
                //由位圖物件建立Graphics對象的實例
                g = Graphics.FromImage(Pic);
                //繪製數位照片的日期/時間
                g.DrawString(TakePicDateTime, normalContentFont, new SolidBrush(normalContentColor),
            Pic.Width - 700, Pic.Height - 200);
                //將新增日期/時間戳後的圖像進行儲存
                if (txtSavePath.Text.Length == 3)
                {
                    Pic.Save(txtSavePath.Text + Path.GetFileName(listBox1.Items[i].ToString()));
                }
                else
                {
                    Pic.Save(txtSavePath.Text + "\\" + Path.GetFileName(listBox1.Items[i].ToString()));
                }
                //釋放記憶體位圖物件
                Pic.Dispose();
                toolStripProgressBar1.Value = kk;
                if (kk == listBox1.Items.Count)
                {
                    toolStripStatusLabel1.Text = "全部數位相片拍攝日期新增成功";
                    toolStripProgressBar1.Visible = false;
                    flag = null;
                    listBox1.Items.Clear();
                }
                kk++;
            }
        }

        #region 取得數位相片的拍攝日期
        //取得圖像文件的所有元資料屬性，儲存倒PropertyItem陣列
        public static PropertyItem[] GetExif(string fileName)
        {
            FileStream Mystream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //透過指定的資料流來建立Image
            Image image = Image.FromStream(Mystream, true, false);
            return image.PropertyItems;
        }

        //深度搜尋所有元資料，取得拍照日期/時間
        private string GetDateTime(System.Drawing.Imaging.PropertyItem[] parr)
        {
            Encoding ascii = Encoding.ASCII;
            //深度搜尋圖像文件元資料，檢索所有屬性
            foreach (PropertyItem pp in parr)
            {
                //如果是PropertyTagDateTime，則返回該屬性所對應的值
                if (pp.Id == 0x0132)
                {
                    return ascii.GetString(pp.Value);
                }
            }
            //若沒有相關的EXIF訊息則返回N/A
            return "N/A";
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (td != null)
            {
                td.Abort();
            }
        }
    }
}
