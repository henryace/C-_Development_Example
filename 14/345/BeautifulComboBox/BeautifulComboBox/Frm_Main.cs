using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulComboBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            beautyComboBox.Items.Add("白菜");//向ComboBox中新增「白菜」欄位
            beautyComboBox.Items.Add("蘿蔔");//向ComboBox中新增「蘿蔔」欄位
            beautyComboBox.Items.Add("土豆");//向ComboBox中新增「土豆」欄位
            beautyComboBox.Items.Add("洋蔥");//向ComboBox中新增「洋蔥」欄位
            beautyComboBox.Items.Add("南瓜");//向ComboBox中新增「南瓜」欄位
            beautyComboBox.SelectedIndex = 0;//設定ComboBox控制元件預設選中第一項
        }

        private void beautyComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics gComboBox = e.Graphics;//宣告一個GDI+繪圖圖面類的對象
            Rectangle rComboBox = e.Bounds;//宣告一個表示矩形的位置和大小類的對象
            Size imageSize = imageList1.ImageSize;//宣告一個有序整數對的對象
            FontDialog typeFace = new FontDialog();//定義一個字體類物件
            Font Style = typeFace.Font;//定義一個定義特定的文字格式類物件
            if (e.Index >= 0)//當繪製的索引項存在時
            {
                string temp = (string)beautyComboBox.Items[e.Index];//取得ComboBox控制元件索引項下的文字內容
                StringFormat stringFormat = new StringFormat();//定義一個封裝文字佈局訊息類的對象
                stringFormat.Alignment = StringAlignment.Near;//設定文字的佈局方式
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))//當繪製項沒有鍵盤加速鍵和焦點可視化提示時
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), rComboBox);//用指定的顏色填充自定義矩形的內部
                    imageList1.Draw(e.Graphics, rComboBox.Left, rComboBox.Top, e.Index);//在指定位置繪製指定索引的圖片
                    e.Graphics.DrawString(temp, Style, new SolidBrush(Color.Black), rComboBox.Left + imageSize.Width, rComboBox.Top);//在指定的位置並且用指定的Font物件繪製指定的文字字串
                    e.DrawFocusRectangle();//在指定的邊界範圍內繪製聚焦框
                }
                else //當繪製項有鍵盤加速鍵或者焦點可視化提示時
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), rComboBox);//用指定的顏色填充自定義矩形的內部
                    imageList1.Draw(e.Graphics, rComboBox.Left, rComboBox.Top, e.Index);//在指定位置繪製指定索引的圖片
                    e.Graphics.DrawString(temp, Style, new SolidBrush(Color.Black), rComboBox.Left + imageSize.Width, rComboBox.Top);//在指定的位置並且用指定的Font物件繪製指定的文字字串
                    e.DrawFocusRectangle();//在指定的邊界範圍內繪製聚焦框
                }
            }
        }
    }
}
