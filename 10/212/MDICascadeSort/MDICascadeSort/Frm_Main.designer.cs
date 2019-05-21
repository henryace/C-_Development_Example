namespace MDICascadeSort
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.載入子視窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.層疊排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.載入子視窗ToolStripMenuItem,
            this.層疊排列ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(378, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 載入子視窗ToolStripMenuItem
            // 
            this.載入子視窗ToolStripMenuItem.Name = "載入子視窗ToolStripMenuItem";
            this.載入子視窗ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.載入子視窗ToolStripMenuItem.Text = "載入子視窗";
            this.載入子視窗ToolStripMenuItem.Click += new System.EventHandler(this.載入子視窗ToolStripMenuItem_Click);
            // 
            // 層疊排列ToolStripMenuItem
            // 
            this.層疊排列ToolStripMenuItem.Name = "層疊排列ToolStripMenuItem";
            this.層疊排列ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.層疊排列ToolStripMenuItem.Text = "層疊排列";
            this.層疊排列ToolStripMenuItem.Click += new System.EventHandler(this.層疊排列ToolStripMenuItem_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 209);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "對子視窗進行層疊排列";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 載入子視窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 層疊排列ToolStripMenuItem;
    }
}

