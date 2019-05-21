namespace Using
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
            this.btn_true = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_true
            // 
            this.btn_true.Location = new System.Drawing.Point(83, 33);
            this.btn_true.Name = "btn_true";
            this.btn_true.Size = new System.Drawing.Size(112, 23);
            this.btn_true.TabIndex = 0;
            this.btn_true.Text = "建立並回收資源";
            this.btn_true.UseVisualStyleBackColor = true;
            this.btn_true.Click += new System.EventHandler(this.btn_true_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 82);
            this.Controls.Add(this.btn_true);
            this.Name = "Form1";
            this.Text = "使用using關鍵字有效回收資源";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_true;
    }
}

