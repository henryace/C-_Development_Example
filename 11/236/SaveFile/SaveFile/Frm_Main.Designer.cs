namespace SaveFile
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
            this.rtbox_Display = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開RTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.儲存成TXT文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbox_Display
            // 
            this.rtbox_Display.Location = new System.Drawing.Point(0, 28);
            this.rtbox_Display.Name = "rtbox_Display";
            this.rtbox_Display.Size = new System.Drawing.Size(354, 277);
            this.rtbox_Display.TabIndex = 3;
            this.rtbox_Display.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打開RTFToolStripMenuItem,
            this.儲存成TXT文件ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打開RTFToolStripMenuItem
            // 
            this.打開RTFToolStripMenuItem.Name = "打開RTFToolStripMenuItem";
            this.打開RTFToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.打開RTFToolStripMenuItem.Text = "打開RTF文件";
            this.打開RTFToolStripMenuItem.Click += new System.EventHandler(this.打開RTFToolStripMenuItem_Click);
            // 
            // 儲存成TXT文件ToolStripMenuItem
            // 
            this.儲存成TXT文件ToolStripMenuItem.Name = "儲存成TXT文件ToolStripMenuItem";
            this.儲存成TXT文件ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.儲存成TXT文件ToolStripMenuItem.Text = "儲存成TXT文件";
            this.儲存成TXT文件ToolStripMenuItem.Click += new System.EventHandler(this.儲存成TXT文件ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 305);
            this.Controls.Add(this.rtbox_Display);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用RichTextBox控制元件儲存文件";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_Display;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開RTFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 儲存成TXT文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

