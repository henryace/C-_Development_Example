using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicturesInComboBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private ImageList G_ImageList;//聲明ImageList欄位


        private void cbox_DisplayPictures_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (G_ImageList != null)//判斷ImageList是否為空
            {
                Graphics g = e.Graphics;//得到繪圖物件
                Rectangle r = e.Bounds;//得到繪圖範圍
                Size imageSize = G_ImageList.ImageSize;//取得圖像大小
                if (e.Index >= 0)//判斷是否有繪製項
                {
                    Font fn = new Font("細明體", 10, FontStyle.Bold);//建立字體物件
                    string s = cbox_DisplayPictures.Items[e.Index].ToString();//得到繪製項的字串
                    DrawItemState dis = e.State;
                    if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightYellow), r);//畫條目背景
                        G_ImageList.Draw(e.Graphics, r.Left, r.Top, e.Index);//繪製圖像
                        e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black),//顯示字串
                            r.Left + imageSize.Width, r.Top);
                        e.DrawFocusRectangle();//顯示取得焦點時的虛線框
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), r);//畫條目背景
                        G_ImageList.Draw(e.Graphics, r.Left, r.Top, e.Index);//繪製圖像
                        e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black),//顯示字串 
                            r.Left + imageSize.Width, r.Top);
                        e.DrawFocusRectangle();//顯示取得焦點時的虛線框 
                    }
                }
            }
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            btn_Begin.Enabled = false;//停用開始按鈕
            cbox_DisplayPictures.DrawMode = DrawMode.OwnerDrawFixed;//設定繪製元素方式
            cbox_DisplayPictures.DropDownStyle = //設定組合框樣式
                ComboBoxStyle.DropDownList;
            cbox_DisplayPictures.Items.Add("小車");//新增項
            cbox_DisplayPictures.Items.Add("卡車");//新增項
            cbox_DisplayPictures.Items.Add("工具");//新增項
            cbox_DisplayPictures.Items.Add("朋友");//新增項
            G_ImageList = new ImageList();//建立ImageList物件
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.a);//新增圖片
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.b);//新增圖片
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.c);//新增圖片
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.d);//新增圖片
        }
    }
}
