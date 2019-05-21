namespace BeautifulButton
{
    partial class TransparencyButton
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

        #region 元件設計器產生的程式碼

        /// <summary> 
        /// 設計器支持所需的方法 - 不要
        /// 使用程式碼編輯器修改此方法的內容。
        /// Devildom-bat
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TransparencyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "TransparencyButton";
            this.Size = new System.Drawing.Size(53, 25);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TransparencyButton_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TransparencyButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TransparencyButton_MouseUp);
            this.SizeChanged += new System.EventHandler(this.TransparencyButton_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
