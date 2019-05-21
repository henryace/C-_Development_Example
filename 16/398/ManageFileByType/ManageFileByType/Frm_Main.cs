using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ManageFileByType
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();//建立FolderBrowserDialog物件
            if (FBDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了資料夾
            {
                string strPath = FBDialog.SelectedPath;//記錄選擇的資料夾
                if (strPath.EndsWith("\\"))
                    textBox1.Text = strPath;//顯示選擇的資料夾
                else
                    textBox1.Text = strPath + "\\";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> listExten = new List<string>();//建立泛型集合物件
            DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text);//建立DirectoryInfo物件
            FileInfo[] FInfos = DInfo.GetFiles();//取得資料夾中的所有文件
            string strExten = "";//定義一個變數，用來存儲文件擴展名
            foreach (FileInfo FInfo in FInfos)//深度搜尋所有文件
            {
                strExten = FInfo.Extension;//記錄文件擴展名
                if (!listExten.Contains(strExten))//判斷泛型集合中是否已經存在該擴展名
                {
                    listExten.Add(strExten.TrimStart('.'));//將擴展名去掉.之後新增到泛型集合中
                }
            }
            for (int i = 0; i < listExten.Count; i++)//深度搜尋泛型集合
            {
                Directory.CreateDirectory(textBox1.Text + listExten[i]);//建立資料夾
            }
            foreach (FileInfo FInfo in FInfos)//深度搜尋所有文件
            {
                FInfo.MoveTo(textBox1.Text + FInfo.Extension.TrimStart('.') + "\\" + FInfo.Name);//將文件移動到對應的資料夾中
            }
            MessageBox.Show("整理完畢！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);//打開資料夾進行查看
        }
    }
}
