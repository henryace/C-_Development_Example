namespace ToStringFormat
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
            this.lb_Format = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Format
            // 
            this.lb_Format.AutoSize = true;
            this.lb_Format.Location = new System.Drawing.Point(23, 24);
            this.lb_Format.Name = "lb_Format";
            this.lb_Format.Size = new System.Drawing.Size(53, 12);
            this.lb_Format.TabIndex = 0;
            this.lb_Format.Text = "格式化：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 163);
            this.Controls.Add(this.lb_Format);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用ToString方法格式化日期";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Format;
    }
}

