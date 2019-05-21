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

        #region 合併檔案
        /// <summary>
        /// 合併檔案
        /// </summary>
        /// <param name="list">要合併的檔案集合</param>
        /// <param name="strPath">合併後的檔案名稱</param>
        /// <param name="PBar">進度列顯示</param>
        public void CombinFile(string[] strFile, string strPath, ProgressBar PBar)
        {
            PBar.Maximum = strFile.Length;
            FileStream AddStream = null;
            //以合併後的檔案名稱和打開方式來建立、初始化FileStream檔案流
            AddStream = new FileStream(strPath, FileMode.Append);
            //以FileStream檔案流來初始化BinaryWriter書寫器，此用以合併分割的檔案
            BinaryWriter AddWriter = new BinaryWriter(AddStream);
            FileStream TempStream = null;
            BinaryReader TempReader = null;
            //循環合併小檔案，並產生合併檔案
            for (int i = 0; i < strFile.Length; i++)
            {
                //以小檔案所對應的檔案名稱和打開模式來初始化FileStream檔案流，起讀取分割作用
                TempStream = new FileStream(strFile[i].ToString(), FileMode.Open);
                TempReader = new BinaryReader(TempStream);
                //讀取分割檔案中的資料，並產生合併後檔案
                AddWriter.Write(TempReader.ReadBytes((int)TempStream.Length));
                //關閉BinaryReader檔案閱讀器
                TempReader.Close();
                //關閉FileStream檔案流
                TempStream.Close();
                PBar.Value = i + 1;
            }
            //關閉BinaryWriter檔案書寫器
            AddWriter.Close();
            //關閉FileStream檔案流
            AddStream.Close();
            MessageBox.Show("檔案合併成功！");
        }
        #endregion

        private void frmSplit_Load(object sender, EventArgs e)
        {
            timer1.Start();//啟動計時器
        }

        //選擇要合成的檔案
        private void btnCFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Selectfile = "";
                string[] files = openFileDialog.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    Selectfile += "," + files[i].ToString();
                }
                if (Selectfile.StartsWith(","))
                {
                    Selectfile = Selectfile.Substring(1);
                }
                if (Selectfile.EndsWith(","))
                {
                    Selectfile.Remove(Selectfile.LastIndexOf(","), 1);
                }
                txtCFile.Text = Selectfile;
            }
        }

        //選擇合成後的檔案存放路徑
        private void btnCPath_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCPath.Text = saveFileDialog.FileName;
            }
        }

        //執行合成檔案操作
        private void btnCombin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCFile.Text.Trim() == "" || txtCPath.Text.Trim() == "")
                {
                    MessageBox.Show("請將訊息輸入完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtCFile.Text.IndexOf(",") == -1)
                        MessageBox.Show("請選擇要合成的檔案，最少為兩個！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        string[] strFiles = txtCFile.Text.Split(',');
                        CombinFile(strFiles, txtCPath.Text, progressBar);
                    }
                }
            }
            catch { }
        }

        //監視「合併」按鈕的可用狀態
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtCFile.Text != "" && txtCPath.Text != "")
                btnCombin.Enabled = true;
            else
                btnCombin.Enabled = false;
        }
    }
}