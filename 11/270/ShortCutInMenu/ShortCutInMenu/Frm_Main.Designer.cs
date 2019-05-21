namespace ShortCutInMenu
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
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(413, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打開OToolStripMenuItem,
            this.退出QToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.文件FToolStripMenuItem.Text = "文件&F";
            // 
            // 打開OToolStripMenuItem
            // 
            this.打開OToolStripMenuItem.Name = "打開OToolStripMenuItem";
            this.打開OToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打開OToolStripMenuItem.Text = "打開&O";
            this.打開OToolStripMenuItem.Click += new System.EventHandler(this.打開OToolStripMenuItem_Click);
            // 
            // 退出QToolStripMenuItem
            // 
            this.退出QToolStripMenuItem.Name = "退出QToolStripMenuItem";
            this.退出QToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出QToolStripMenuItem.Text = "退出&Q";
            this.退出QToolStripMenuItem.Click += new System.EventHandler(this.退出QToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 254);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "為功能表新增快捷鍵";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出QToolStripMenuItem;
    }
}

