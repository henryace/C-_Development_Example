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

namespace InsertToSQL
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
                    Word.Document P_Document = G_wa.Documents.Open(//打開Word文檔
                        ref P_Path, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//視窗線程執行
                        (MethodInvoker)(() =>//使用Lambda表達式
                        {
                            btn_display.Enabled = true;
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
            this.Height = 517;//設定視窗高度
        }

        /// <summary>
        /// 向SQL資料庫插入資料方法
        /// </summary>
        private void InsertData()
        {
            try
            {
                G_wa.ActiveDocument.Save();//儲存文檔
                object P_Save = false;//建立object對像
                ((Word._Application)G_wa.Application).Quit(//退出應用程式
                     ref P_Save, ref G_missing, ref G_missing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            btn_Begin.Enabled = false;//停用插入資料按鈕
            G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式對像
            object P_Path = Directory.GetCurrentDirectory() + @"\Word.doc";
            Word.Document P_Document = G_wa.Documents.Open(//打開Word文檔
                ref P_Path, ref G_missing, ref G_missing, ref G_missing
                , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
            try
            {
                Word.Range P_Range =//得到文檔範圍
                    P_Document.Range(ref G_missing, ref G_missing);
                Word.Table P_Table = P_Range.Tables[1];//得到文檔內的表格對像
                List<InstanceClass> P_List_InstanceClass = //建立集合對像
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format(//提示異常訊息
                            "Word表格中第{0}行資料不正確，插入失敗！" +
                            ex.Message, (i - 1).ToString()), "錯誤！");
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
                        dgv_Message.DataSource = //繫結資料庫中的資料
                          new DataTier(txt_Server.Text,
                              txt_DataBase.Text,
                              txt_UserName.Text,
                              txt_PassWord.Text).GetMessage();
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

        private void btn_SetTask_Click(object sender, EventArgs e)
        {
            this.Width = 697;//設定視窗寬度
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            this.Width = 444;//設定視窗寬度
        }

        private void btn_Hide_Click(object sender, EventArgs e)
        {
            this.Height = 254;//設定視窗高度
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            btn_Begin.Enabled = false;
            Thread P_th = new Thread(//建立線程
                () => //使用Lambda表達式
                {
                    while (true)//開始無限循環
                    {
                        this.Invoke(//在視窗線程中執行
                            (MethodInvoker)(() =>//使用Lambda表達式
                            {
                                foreach (object P_O in lbox_Task.Items)
                                {
                                    Time P_Time = (Time)P_O;//將對像轉換為Time類型
                                    if (P_Time.Hours.ToString() == //判斷時間是否相等
                                        DateTime.Now.Hour.ToString() &&
                                        P_Time.Minutes.ToString() ==
                                        DateTime.Now.Minute.ToString() &&
                                        P_Time.Seconds.ToString() ==
                                        DateTime.Now.Second.ToString())
                                    {
                                        if (P_Time.Execute)//判斷任務是否已經執行
                                        {
                                            P_Time.Execute = false;//設定任務為已執行
                                            InsertData();//開始插入資料
                                        }
                                    }
                                }
                                if ("0" == DateTime.Now.Hour.ToString() &&//是否重置任務
                                     "0" == DateTime.Now.Minute.ToString() &&
                                     "0" == DateTime.Now.Second.ToString())
                                {
                                    foreach (object P_1 in lbox_Task.Items)
                                    {
                                        ((Time)P_1).Execute = true;
                                    }
                                }
                            }));
                        Thread.Sleep(1000);//線程掛起1秒鐘
                    }
                });
            P_th.IsBackground = true;//設定線程為後台線程
            P_th.Start();//線程開始執行
        }

        private void btn_RemoveTask_Click(object sender, EventArgs e)
        {
            if (lbox_Task.SelectedIndex != -1)//如果選擇了正確的選項
            {
                lbox_Task.Items.RemoveAt(lbox_Task.SelectedIndex);//刪除選擇的項
            }
        }

        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            lbox_Task.Items.Add(new Time()//向集合中新增元素
            {
                Times = string.Format("任務時間：每日{0}時{1}分{2}秒",
                txt_Hours.Text, txt_Minutes.Text, txt_Seconds.Text),
                Hours = byte.Parse(txt_Hours.Text),
                Minutes = byte.Parse(txt_Minutes.Text),
                Seconds = byte.Parse(txt_Seconds.Text),
                Execute = true
            });
        }


    }
}
