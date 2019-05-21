using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace FileComminuteUnite
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 分割檔案
        /// <summary>
        /// 分割檔案
        /// </summary>
        /// <param name="strFlag">分割單位</param>
        /// <param name="intFlag">分割大小</param>
        /// <param name="strPath">分割後的檔案存放路徑</param>
        /// <param name="strFile">要分割的檔案</param>
        /// <param name="PBar">進度列顯示</param>
        public void SplitFile(string strFlag, int intFlag, string strPath, string strFile, ProgressBar PBar)
        {
            int iFileSize = 0;
            //根據選擇來設定分割的小檔案的大小
            switch (strFlag)
            {
                case "Byte":
                    iFileSize = intFlag;
                    break;
                case "KB":
                    iFileSize = intFlag * 1024;
                    break;
                case "MB":
                    iFileSize = intFlag * 1024 * 1024;
                    break;
                case "GB":
                    iFileSize = intFlag * 1024 * 1024 * 1024;
                    break;
            }
            //以檔案的全路徑對應的字串和檔案打開模式來初始化FileStream檔案流實例
            FileStream SplitFileStream = new FileStream(strFile, FileMode.Open);
            //以FileStream檔案流來初始化BinaryReader檔案閱讀器
            BinaryReader SplitFileReader = new BinaryReader(SplitFileStream);
            //每次分割讀取的最大資料
            byte[] TempBytes;
            //小檔案總數
            int iFileCount = (int)(SplitFileStream.Length / iFileSize);
            PBar.Maximum = iFileCount;
            if (SplitFileStream.Length % iFileSize != 0) iFileCount++;
            string[] TempExtra = strFile.Split('.');
            //循環將大檔案分割成多個小檔案
            for (int i = 1; i <= iFileCount; i++)
            {
                //確定小檔案的檔案名稱
                string sTempFileName = strPath + @"\" + i.ToString().PadLeft(4, '0') + "." + TempExtra[TempExtra.Length - 1]; //小檔案名
                //根據檔案名稱和檔案打開模式來初始化FileStream檔案流實例
                FileStream TempStream = new FileStream(sTempFileName, FileMode.OpenOrCreate);
                //以FileStream實例來建立、初始化BinaryWriter書寫器實例
                BinaryWriter TempWriter = new BinaryWriter(TempStream);
                //從大檔案中讀取指定大小資料
                TempBytes = SplitFileReader.ReadBytes(iFileSize);
                //把此資料寫入小檔案
                TempWriter.Write(TempBytes);
                //關閉書寫器，形成小檔案
                TempWriter.Close();
                //關閉檔案流
                TempStream.Close();
                PBar.Value = i - 1;
            }
            //關閉大檔案閱讀器
            SplitFileReader.Close();
            SplitFileStream.Close();
            MessageBox.Show("檔案分割成功!");
        }
        #endregion

        private void frmSplit_Load(object sender, EventArgs e)
        {
            timer1.Start();//啟動計時器
        }

        //選擇要分割的檔案
        private void btnSFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
            }
        }

        //執行檔案分割操作
        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLength.Text == "" || txtFile.Text.Trim() == "" || txtPath.Text.Trim() == "")
                {
                    MessageBox.Show("請將訊息填寫完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLength.Focus();
                }
                else if (cboxUnit.Text == "")
                {
                    MessageBox.Show("請選擇要分割的檔案單位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboxUnit.Focus();
                }
                else
                {
                    SplitFile(cboxUnit.Text, Convert.ToInt32(txtLength.Text.Trim()), txtPath.Text, txtFile.Text, progressBar);
                }
            }
            catch { }
        }

        //選擇分割後的檔案存放路徑
        private void btnSPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        //監視「分割」/「合併」按鈕的可用狀態
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtFile.Text != "" && txtPath.Text != "")
                btnSplit.Enabled = true;
            else
                btnSplit.Enabled = false;
        }
    }
}