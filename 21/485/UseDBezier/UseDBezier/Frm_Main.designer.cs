namespace UseDBezier
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
            this.Draw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(75, 79);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(88, 23);
            this.Draw.TabIndex = 0;
            this.Draw.Text = "貝茲曲線";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 108);
            this.Controls.Add(this.Draw);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "繪製貝茲曲線";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Draw;
    }
}

