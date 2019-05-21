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

namespace Real_TimeToSQL
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
        private Thread G_th;//定義線程欄位
        private List<InstanceClass> G_List_InstanceClass = //定義資料集合欄位並賦值
            new List<InstanceClass>();

        private void btn_display_Click(object sender, EventArgs e)
        {
            btn_display.Enabled = false;
            ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
                    G_wa.Visible = true;
                    object P_Path = Directory.GetCurrentDirectory() + @"\Word.doc";
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文檔
                        ref P_Path, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    TrackData();//將Word資料更新到SQL
                });
        }

        /// <summary>
        /// 跟蹤Word文檔資料並更新到SQL的方法
        /// </summary>
        private void TrackData()
        {
            G_th = new Thread(//使用線程
                () =>
                {
                    while (true)
                    {
                        try
                        {
                            Word.Range P_Rang = G_wa.ActiveDocument.Range(
                                ref G_missing, ref G_missing);
                            Word.Table P_Table = P_Rang.Tables[1];
                            List<InstanceClass> P_List_InstanceClass = //建立集合對像
                                new List<InstanceClass>();
                            List<InstanceClass> P_List_InstanceClass_temp = //建立集合對像
                                new List<InstanceClass>();
                            for (int i = 2; i < 7; i++)
                            {
                                try
                                {
                                    if (P_Table.Cell(i, 1).Range.Text != "\r\a" &&//判斷表格內是否已經新增訊息
                                        P_Table.Cell(i, 2).Range.Text != "\r\a" &&
                                        P_Table.Cell(i, 3).Range.Text != "\r\a" &&
                                        P_Table.Cell(i, 4).Range.Text != "\r\a")
                                    {
                                        P_List_InstanceClass_temp.Add(//向資料集合中新增資料
                                            new InstanceClass()
                                            {
                                                Name = P_Table.Cell(i, 1).Range.Text.Replace("\r\a", ""),
                                                Chinese = float.Parse(P_Table.Cell(i, 2).Range.Text.Replace("\r\a", "")),
                                                Math = float.Parse(P_Table.Cell(i, 3).Range.Text.Replace("\r\a", "")),
                                                English = float.Parse(P_Table.Cell(i, 4).Range.Text.Replace("\r\a", ""))
                                            });
                                    }
                                }
                                catch (Exception ex)
                                {
                                    this.Invoke(
                                        (MethodInvoker)(() =>
                                        {
                                            this.Text = "請輸入正確的訊息！" + ex.Message;
                                        }));
                                }
                            }
                            if (ListToList(P_List_InstanceClass, P_List_InstanceClass_temp))//判斷資料是否有更新
                            {
                                P_List_InstanceClass = P_List_InstanceClass_temp;//同步兩個集合內所有元素
                                new DataTier(txt_Server.Text, txt_DataBase.Text, txt_UserName.Text,//更新SQL中的資料
                                    txt_PassWord.Text).InsertMessage(P_List_InstanceClass_temp);
                                this.Invoke(
                                    (MethodInvoker)(() =>
                                    {
                                        dgv_Message.DataSource = new DataTier(//重新繫結資料
                                            txt_Server.Text, txt_DataBase.Text,
                                            txt_UserName.Text, txt_PassWord.Text).GetMessage();
                                    }));
                            }
                        }
                        catch (Exception ex)
                        {
                            object P_Save = false;//建立object對像
                            this.Invoke(
                                (MethodInvoker)(() =>
                                {
                                    btn_display.Enabled = true;//啟用跟蹤資料按鈕
                                    MessageBox.Show("Word應程式操作異常,\r\n操作線程已經關閉\r\n" + ex.Message, "錯誤！");
                                }));
                            G_th.Abort();//退出監視線程
                        }
                        Thread.Sleep(100);
                    }
                });
            G_th.IsBackground = true;
            G_th.Start();
        }

        private bool ListToList(List<InstanceClass> l1, List<InstanceClass> l2)
        {
            if (l1.Count != l2.Count) return true;//判斷集合中元素數量是否相同
            for (int i = 0; i < l1.Count; i++)//深度搜尋集合
            {
                if (l1[i].Name != l2[i].Name) return true;//判斷兩個集合中元素是否相同
                if (l1[i].Chinese != l2[i].Chinese) return true;//判斷兩個集合中元素是否相同
                if (l1[i].Math != l2[i].Math) return true;//判斷兩個集合中元素是否相同
                if (l1[i].English != l2[i].English) return true;//判斷兩個集合中元素是否相同
            }
            return false;//全部相同則返回false
        }
    }
}
