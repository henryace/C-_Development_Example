namespace CreateMultiSheet
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
            this.WBrowser_Excel = new System.Windows.Forms.WebBrowser();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MStrip_Open = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開Excel文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立工作表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MStrip_Open.SuspendLayout();
            this.SuspendLayout();
            // 
            // WBrowser_Excel
            // 
            this.WBrowser_Excel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBrowser_Excel.Location = new System.Drawing.Point(0, 24);
            this.WBrowser_Excel.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBrowser_Excel.Name = "WBrowser_Excel";
            this.WBrowser_Excel.Size = new System.Drawing.Size(550, 314);
            this.WBrowser_Excel.TabIndex = 1;
            // 
            // MStrip_Open
            // 
            this.MStrip_Open.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem});
            this.MStrip_Open.Location = new System.Drawing.Point(0, 0);
            this.MStrip_Open.Name = "MStrip_Open";
            this.MStrip_Open.Size = new System.Drawing.Size(550, 24);
            this.MStrip_Open.TabIndex = 2;
            this.MStrip_Open.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打開Excel文件ToolStripMenuItem,
            this.建立工作表ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 打開Excel文件ToolStripMenuItem
            // 
            this.打開Excel文件ToolStripMenuItem.Name = "打開Excel文件ToolStripMenuItem";
            this.打開Excel文件ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.打開Excel文件ToolStripMenuItem.Text = "打開Excel文件";
            this.打開Excel文件ToolStripMenuItem.Click += new System.EventHandler(this.打開Excel文件ToolStripMenuItem_Click);
            // 
            // 建立工作表ToolStripMenuItem
            // 
            this.建立工作表ToolStripMenuItem.Name = "建立工作表ToolStripMenuItem";
            this.建立工作表ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.建立工作表ToolStripMenuItem.Text = "建立工作表";
            this.建立工作表ToolStripMenuItem.Click += new System.EventHandler(this.建立工作表ToolStripMenuItem_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 338);
            this.Controls.Add(this.WBrowser_Excel);
            this.Controls.Add(this.MStrip_Open);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "為一個Excel文件建立多個工作表";
            this.MStrip_Open.ResumeLayout(false);
            this.MStrip_Open.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WBrowser_Excel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.MenuStrip MStrip_Open;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開Excel文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立工作表ToolStripMenuItem;
    }
}

