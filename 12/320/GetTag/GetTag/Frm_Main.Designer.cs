namespace GetTag
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
            this.btn_Tag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Tag
            // 
            this.btn_Tag.Location = new System.Drawing.Point(67, 42);
            this.btn_Tag.Name = "btn_Tag";
            this.btn_Tag.Size = new System.Drawing.Size(197, 23);
            this.btn_Tag.TabIndex = 0;
            this.btn_Tag.Text = "Tag屬性應用";
            this.btn_Tag.UseVisualStyleBackColor = true;
            this.btn_Tag.Click += new System.EventHandler(this.btn_Tag_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 102);
            this.Controls.Add(this.btn_Tag);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用控制元件的Tag屬性傳遞訊息";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Tag;
    }
}

