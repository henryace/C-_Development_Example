namespace NChangeFormSize
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
            this.btn_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Stop
            // 
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.Location = new System.Drawing.Point(59, 24);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(135, 45);
            this.btn_Stop.TabIndex = 0;
            this.btn_Stop.Text = "禁止改變視窗的大小";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 92);
            this.Controls.Add(this.btn_Stop);
            this.Name = "Frm_Main";
            this.Text = "禁止改變視窗的大小";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Stop;
    }
}

