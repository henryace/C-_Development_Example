using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace GridToWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Fruit>() {//繫結資料集合
            new Fruit(){Name="蘋果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鴨梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.Columns[0].Width = 200;//設定列寬度
            dgv_Message.Columns[1].Width = 170;//設定列寬度
        }

        private Word.Application G_wa;//定義Word應用程式欄位
        private object G_missing = //定義G_missing欄位並新增參考
            System.Reflection.Missing.Value;

        private void btn_OutPut_Click(object sender, EventArgs e)
        {
            List<Fruit> P_Fruit = new List<Fruit>();//建立資料集合
            foreach (DataGridViewRow dgvr in dgv_Message.Rows)
            {
                P_Fruit.Add(new Fruit()//向資料集合新增資料
                {
                    Name = dgvr.Cells[0].Value.ToString(),
                    Price = Convert.ToSingle(dgvr.Cells[1].Value.ToString())
                });
            }
            SaveFileDialog P_SaveFileDialog =//建立儲存文件對話框物件
                new SaveFileDialog();
            P_SaveFileDialog.Filter = "*.doc|*.doc";
            if (DialogResult.OK ==//確認是否儲存文件
                P_SaveFileDialog.ShowDialog())
            {
                ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//建立應用程式物件
                    object P_obj = "Normal.dot";//定義文檔模板
                    Word.Document P_wd = G_wa.Documents.Add(//向Word應用程式中新增文檔
                        ref P_obj, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Range(//得到文檔範圍
                        ref G_missing, ref G_missing);
                    object o1 = Word.WdDefaultTableBehavior.//設定文檔中表格格式
                        wdWord8TableBehavior;
                    object o2 = Word.WdAutoFitBehavior.//設定文檔中表格格式
                        wdAutoFitWindow;
                    Word.Table P_WordTable = P_Range.Tables.Add(P_Range,//在文檔中新增表格
                        P_Fruit.Count, 2, ref o1, ref o2);
                    P_WordTable.Cell(1, 1).Range.Text = "水果";//向表格中新增訊息
                    P_WordTable.Cell(1, 2).Range.Text = "價格";//向表格中新增訊息
                    for (int i = 2; i < P_Fruit.Count + 1; i++)
                    {
                        P_WordTable.Cell(i, 1).Range.Text =//向表格中新增訊息
                            P_Fruit[i - 2].Name;
                        P_WordTable.Cell(i, 2).Range.Text =//向表格中新增訊息
                            P_Fruit[i - 2].Price.ToString();
                    }
                    object P_Path = P_SaveFileDialog.FileName;
                    P_wd.SaveAs(//儲存Word文件
                        ref P_Path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出應用程式
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            MessageBox.Show(//彈出消息對話框
                                "成功建立Word文檔！", "提示！");
                        }));
                });
            }
        }
    }
}
