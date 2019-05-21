namespace SelectDefault
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的設計器變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的資源。
        /// </summary>
        /// <param name="disposing">如果應釋放托管資源，為 true；否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 視窗設計器產生的程式碼

        /// <summary>
        /// 設計器支持所需的方法 - 不要
        /// 使用程式碼編輯器修改此方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbox_Select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbox_Select
            // 
            this.cbox_Select.FormattingEnabled = true;
            this.cbox_Select.Items.AddRange(new object[] {
            "第一項",
            "第二項",
            "第3項",
            "第4項",
            "第5項",
            "第6項"});
            this.cbox_Select.Location = new System.Drawing.Point(170, 39);
            this.cbox_Select.Name = "cbox_Select";
            this.cbox_Select.Size = new System.Drawing.Size(121, 20);
            this.cbox_Select.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "預設選擇第一項：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 93);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_Select);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定ComboBox控制元件的預設選項為第一項";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_Select;
        private System.Windows.Forms.Label label1;
    }
}

