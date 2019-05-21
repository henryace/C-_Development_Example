using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace WordToSql
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Word.Application G_wa;//定義Word應用程式欄位
        private object G_missing = //定義G_missing欄位並新增參考
            System.Reflection.Missing.Value;

        private void btn_display_Click(object sender, EventArgs e)
        {
            btn_display.Enabled = false;
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
                    G_wa.Visible = true;
                    object P_Path = Directory.GetCurrentDirectory() + @"\Word.doc";
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                        ref P_Path, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//視窗線程執行
                        (MethodInvoker)(() =>//使用Lambda表達式
                        {
                            btn_Write.Enabled = true;//啟用插入資料按鈕
                        }));
                });
        }

        private void btn_DisplayData_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = //繫結資料庫中的資料
              new DataTier(txt_Server.Text,
                  txt_DataBase.Text,
                  txt_UserName.Text,
                  txt_PassWord.Text).GetMessage();
            this.Height = 500;//設定視窗高度
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            try
            {
                G_wa.ActiveDocument.Save();//儲存文件檔
                object P_Save = false;//建立object對像
                ((Word._Application)G_wa.Application).Quit(//退出應用程式
                     ref P_Save, ref G_missing, ref G_missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(//彈出消息對話框
                    ex.Message, "提示！");
            }
            btn_Write.Enabled = false;//停用插入資料按鈕
            try
            {
                InsertData();//執行插入資料方法
                btn_display.Enabled = true;//啟用顯示文件檔按鈕
            }
            catch (Exception ex)
            {
                MessageBox.Show(//彈出消息對話框
                    "插入訊息失敗，請確認Word中添入的訊息是否正確\r\n"
                    + ex.Message, "提示！");
            }
        }


        /// <summary>
        /// 向SQL資料庫插入資料方法
        /// </summary>
        private void InsertData()
        {
            G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
            object P_Path = Directory.GetCurrentDirectory() + @"\Word.doc";
            Word.Document P_Document = G_wa.Documents.Open(//打開Word文件檔
                ref P_Path, ref G_missing, ref G_missing, ref G_missing
                , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
            try
            {
                Word.Range P_Range =//得到文件檔範圍
                    P_Document.Range(ref G_missing, ref G_missing);
                Word.Table P_Table = P_Range.Tables[1];//得到文件檔內的表格對像
                List<InstanceClass> P_List_InstanceClass = //建立集合對像
                    new List<InstanceClass>();
                for (int i = 2; i < 7; i++)
                {
                    if (P_Table.Cell(i, 1).Range.Text != "\r\a" &&//判斷表格內是否已經新增訊息
                        P_Table.Cell(i, 2).Range.Text != "\r\a" &&
                        P_Table.Cell(i, 3).Range.Text != "\r\a" &&
                        P_Table.Cell(i, 4).Range.Text != "\r\a")
                    {
                        P_List_InstanceClass.Add(//向資料集合中新增資料
                            new InstanceClass()
                            {
                                Name = P_Table.Cell(i, 1).Range.Text.Replace("\r\a", ""),
                                Chinese = float.Parse(P_Table.Cell(i, 2).Range.Text.Replace("\r\a", "")),
                                Math = float.Parse(P_Table.Cell(i, 3).Range.Text.Replace("\r\a", "")),
                                English = float.Parse(P_Table.Cell(i, 4).Range.Text.Replace("\r\a", ""))
                            });
                    }
                }
                new DataTier(txt_Server.Text, txt_DataBase.Text, txt_UserName.Text,//向SQL資料庫中插入資料
                    txt_PassWord.Text).InsertMessage(P_List_InstanceClass);
                object P_Save = false;//建立object對像
                ((Word._Application)G_wa.Application).Quit(//退出應用程式
                     ref P_Save, ref G_missing, ref G_missing);
                this.Invoke(//視窗線程執行
                    (MethodInvoker)(() =>//使用Lambda表達式
                    {
                        MessageBox.Show("向SQL中插入資料成功！", "提示！");
                    }));
            }
            catch (Exception ex)
            {
                object P_Save = false;//建立object對像
                ((Word._Application)G_wa.Application).Quit(//退出應用程式
                     ref P_Save, ref G_missing, ref G_missing);
                throw new Exception(ex.Message);//將異常拋向上一層
            }
        }
    }
}
