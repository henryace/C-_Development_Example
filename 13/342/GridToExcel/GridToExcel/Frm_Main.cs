using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace GridToExcel
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


        private Excel.Application G_ea;//定義Word應用程式欄位
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
            P_SaveFileDialog.Filter = "*.xls|*.xls";
            if (DialogResult.OK ==//確認是否儲存文件
                P_SaveFileDialog.ShowDialog())
            {
                ThreadPool.QueueUserWorkItem(//開始線程池
                (pp) =>//使用lambda表達式
                {
                    G_ea = new Microsoft.Office.Interop.Excel.Application();//建立應用程式物件
                    Excel.Workbook P_wk = G_ea.Workbooks.Add(G_missing);//建立Excel文檔
                    Excel.Worksheet P_ws = (Excel.Worksheet)P_wk.Worksheets.Add(//建立工作區域
                        G_missing, G_missing, G_missing, G_missing);
                    for (int i = 0; i < P_Fruit.Count; i++)
                    {
                        P_ws.Cells[i + 1, 1] = P_Fruit[i].Name;//向Excel文檔中寫入內容
                        P_ws.Cells[i + 1, 2] = P_Fruit[i].//向Excel文檔中寫入內容
                            Price.ToString();
                    }
                    P_wk.SaveAs(//儲存Word文件
                        P_SaveFileDialog.FileName, G_missing, G_missing, G_missing,
                        G_missing, G_missing, Excel.XlSaveAsAccessMode.xlShared, G_missing,
                        G_missing, G_missing, G_missing, G_missing);
                    ((Excel._Application)G_ea.Application).Quit();//退出應用程式

                    this.Invoke(//呼叫視窗線程
                        (MethodInvoker)(() =>//使用lambda表達式
                        {
                            MessageBox.Show(//彈出消息對話框
                                "成功建立Excel文件檔！", "提示！");
                        }));
                });
            }
        }
    }
}
