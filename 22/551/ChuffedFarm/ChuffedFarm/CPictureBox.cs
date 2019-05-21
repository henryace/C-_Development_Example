using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChuffedFarm
{
    public partial class CPictureBox : PictureBox
    {
        public CPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private bool boolIsInseminate;
        [Browsable(true), Category("自定義"), Description("確定目前的種子是否已種下")] //在「屬性」視窗中顯示IsFollow屬性
        public bool IsInseminate
        {
            get { return boolIsInseminate; }
            set
            {
                boolIsInseminate = value;
                this.Invalidate();
            }
        }
    }
}
