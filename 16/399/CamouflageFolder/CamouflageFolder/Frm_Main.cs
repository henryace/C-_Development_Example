using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace CamouflageFolder
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private string GetFolType()
        {
            int Tid = comboBox1.SelectedIndex;							//取得選擇項索引
            switch (Tid)												//根據索引設定Windows文件標識符
            {
                case 0: return @"{20D04FE0-3AEA-1069-A2D8-08002B30309D}";	//我的電腦的Windows文件標識符
                case 1: return @"{450D8FBA-AD25-11D0-98A8-0800361B1103}";	//我的文檔Windows文件標識符
                case 2: return @"{992CFFA0-F557-101A-88EC-00DD010CCC48}";	//撥號網絡Windows文件標識符
                case 3: return @"{21EC2020-3AEA-1069-A2DD-08002B30309D}";	//控制面板Windows文件標識符
                case 4: return @"{D6277990-4C6A-11CF-8D87-00AA0060F5BF}";	//計劃任務Windows文件標識符
                case 5: return @"{2227A280-3AEA-1069-A2DE-08002B30309D}";	//列印機Windows文件標識符
                case 6: return @"{208D2C60-3AEA-1069-A2D7-08002B30309D}";	//網絡鄰居Windows文件標識符
                case 7: return @"{645FF040-5081-101B-9F08-00AA002F954E}";		//回收站Windows文件標識符
                case 8: return @"{85BBD920-42A0-1069-A2E4-08002B30309D}";	//公文包Windows文件標識符
                case 9: return @"{BD84B380-8CA2-1069-AB1D-08000948F534}";	//字體Windows文件標識符
                case 10: return @"{BDEADF00-C265-11d0-BCED-00A0C90AB50F}";	//Web 資料夾Windows文件標識符
            }
            //如果都不符合則返回我的電腦Windows文件標識符
            return @"{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath.Length >= 4)
                {
                    txtFolPath.Text = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("不能對盤符進行偽裝", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 11)
            {
                txtID.ReadOnly = false;
                txtID.Text = "";
            }
            else
            {
                txtID.ReadOnly = true;
                txtID.Text = GetFolType();
            }

        }

        private void Camouflage(string str)									//用於建立desktop.ini文件
        {
            StreamWriter sw = File.CreateText(txtFolPath.Text.Trim() + @"\desktop.ini");	//用desktop.ini文件建立StreamWriter實例
            sw.WriteLine(@"[.ShellClassInfo]");							//寫入「[.ShellClassInfo]」
            sw.WriteLine("CLSID=" + str);								//寫入Windows文件標識符
            sw.Close();												//關閉物件
            //設定desktop.ini文件為隱藏
            File.SetAttributes(txtFolPath.Text.Trim() + @"\desktop.ini", FileAttributes.Hidden);
            File.SetAttributes(txtFolPath.Text.Trim(), FileAttributes.System);		//設定資料夾屬性為系統屬性
            //彈出提示
            MessageBox.Show("偽裝成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtFolPath.Text == "")									//如果沒選擇文件
            {
                //彈出提示訊息
                MessageBox.Show("請選擇資料夾路徑！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else													//否則
            {
                try
                {
                    if (txtID.ReadOnly == false)							//如果自定義Windows文件標識符
                    {
                        string str = txtID.Text.Trim();						//取得選擇的Windows文件標識符
                        if (str.StartsWith("."))							//如果以「.」開頭
                            str = str.Substring(1);							//則去掉「.」
                        if (!str.StartsWith("{") || str.Trim().Length != 38)			//如果不以「{」開頭，並且長度錯誤
                        {
                            //彈出提示
                            MessageBox.Show("自定義類型錯誤！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else											//如果Windows文件標識符合法
                        {
                            Camouflage(str);							//呼叫Camouflage方法開始偽裝
                        }
                    }
                    else											//如果選擇預定的偽裝方式
                    {
                        //則首先要透過GetFolType方法取得Windows文件標識符，然後使用Camouflage方法開始偽裝
                        Camouflage(GetFolType());
                    }
                }
                catch
                {
                    MessageBox.Show("不要進行多次偽裝！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFolPath.Text == "")										//判斷是否選擇了需要還原偽裝的資料夾
            {
                MessageBox.Show("請選擇加密過的資料夾！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else													//如果選擇了資料夾
            {
                try
                {
                    FileInfo fi = new FileInfo(txtFolPath.Text.Trim() + @"\desktop.ini");	//建立FileInfo實例
                    if (!fi.Exists)										//如果不存在desktop.ini文件說明沒有被偽裝
                    {
                        MessageBox.Show("該資料夾沒有被偽裝！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else											//否則
                    {
                        System.Threading.Thread.Sleep(1000);				//睡眠線程
                        File.Delete(txtFolPath.Text + @"\desktop.ini");			//刪除資料夾下的desktop.ini文件
                        File.SetAttributes(txtFolPath.Text.Trim(), FileAttributes.System);//設定資料夾屬性為系統屬性
                        MessageBox.Show("還原成功", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("不要多次還原！");
                }
            }
        }
    }
}
