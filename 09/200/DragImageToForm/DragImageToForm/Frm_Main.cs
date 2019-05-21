using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//新增的命名空間，對文件進行操作
using System.Threading;//線程式的命名空間

namespace DragImageToForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public static bool Var_Style = true;
        public static string tempstr = "";

        /// <summary>
        /// 在視窗背景中顯示被拖放的圖片
        /// </summary>
        /// <param Frm="Form">視窗</param>
        /// <param e="DragEventArgs">DragDrop、DragEnter 或 DragOver 事件提供資料</param>
        public void SetDragImageToFrm(Form Frm, DragEventArgs e)
        {
            if (Var_Style == true)
            {
                e.Effect = DragDropEffects.Copy;//設定拖放操作中目標放置類型為複製
                String[] str_Drop = (String[])e.Data.GetData(DataFormats.FileDrop, true);//檢索資料格式相關聯的資料
                string tempstr;
                Bitmap bkImage;//定義Bitmap變數
                tempstr = str_Drop[0];//取得拖放文件的目錄
                try
                {
                    bkImage = new Bitmap(tempstr);//存儲拖放的圖片
                    //根據圖片設定視窗的大小
                    Frm.Size = new System.Drawing.Size(bkImage.Width + 6, bkImage.Height + 33);
                    Frm.BackgroundImage = bkImage;//在視窗背景中顯示圖片
                }
                catch { }
            }
        }

        private void Frm_Main_DragEnter(object sender, DragEventArgs e)
        {
            SetDragImageToFrm(this, e);//在視窗中顯示拖放到視窗上的圖片
        }
    }
}
