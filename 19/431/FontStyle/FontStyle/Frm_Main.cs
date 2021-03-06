﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace FontStyle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            txt_Text.Text =//向控制元件中新增字串
                string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n",
                "泉眼無聲惜細流，",
                "樹陰照水愛晴柔。",
                "小荷才露尖尖角，",
                "早有蜻蜓立上頭。");
            cbox_Select.SelectedIndex = 0;//設定預設選項索引為0
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            this.Width = 765;//設定視窗寬度
            textBox1.Text = txt_Text.Text;//得到預覽文字
            textBox1.Font = new Font(//設定文字字體與文字大小
                rbtn_Font1.Checked ? rbtn_Font1.Text :
                rbtn_Font2.Checked ? rbtn_Font2.Text :
                rbtn_Font3.Checked ? rbtn_Font3.Text : "細明體"
                , int.Parse(cbox_Select.SelectedItem.ToString()));
        }

        private Word.Application G_wa;//定義Word應用程式欄位
        private object G_missing = //定義missing欄位並賦值
            System.Reflection.Missing.Value;
        private object G_str_path;//定義文件儲存路徑欄位
        private FolderBrowserDialog G_FolderBrowserDialog;//定義資料夾瀏覽對話框欄位


        private void btn_Select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog =//建立瀏覽資料夾物件
              new FolderBrowserDialog();
            DialogResult P_DialogResult = //瀏覽資料夾
                G_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//確認已經選擇資料夾
            {
                btn_New.Enabled = true;//啟用新建按鈕
                txt_Path.Text = //顯示選擇路徑
                    G_FolderBrowserDialog.SelectedPath;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按鈕
            ThreadPool.QueueUserWorkItem(//使用線程池
                (P_temp) =>//使用lambda表達式
                {
                    G_wa = new Word.Application();//建立Word應用程式物件
                    Word.Document P_wd = G_wa.Documents.Add(//建立新文件檔
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;
                    Word.Paragraph p = P_wd.Paragraphs[1];
                    this.Invoke(//開始執行視窗線程
                            (MethodInvoker)(() =>//使用lambda表達式
                            {
                                P_Range.Text = txt_Text.Text;//向文件檔中新增文字
                                P_Range.Font.Name =//設定文字字體
                                        rbtn_Font1.Checked ? rbtn_Font1.Text :
                                        rbtn_Font2.Checked ? rbtn_Font2.Text :
                                        rbtn_Font3.Checked ? rbtn_Font3.Text : "細明體";
                                P_Range.Font.Size = //設定文字大小
                                    int.Parse(cbox_Select.SelectedItem.ToString());
                            }));
                    G_str_path = string.Format(//計算文件儲存路徑
                        @"{0}\{1}", G_FolderBrowserDialog.SelectedPath,
                        DateTime.Now.ToString("yyyy年M月d日h時s分m秒fff毫秒") + ".doc");
                    P_wd.SaveAs(//儲存Word文件
                        ref G_str_path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//開始執行視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            btn_Display.Enabled = true;//啟用顯示按鈕
                            MessageBox.Show("成功建立Word文件檔！", "提示！");
                        }));
                });
        }

        private void btn_Display_Click(object sender, EventArgs e)
        {
            G_wa = //建立應用程式物件
                 new Microsoft.Office.Interop.Word.Application();
            G_wa.Visible = true;//將文件檔設定為可見
            Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                ref G_str_path, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing);
        }


    }
}
