namespace BoldItem
{
    partial class Main_Main
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
            this.menus_Bold = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Bold = new System.Windows.Forms.Button();
            this.menus_Bold.SuspendLayout();
            this.SuspendLayout();
            // 
            // menus_Bold
            // 
            this.menus_Bold.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menus_Bold.Location = new System.Drawing.Point(0, 0);
            this.menus_Bold.Name = "menus_Bold";
            this.menus_Bold.Size = new System.Drawing.Size(305, 25);
            this.menus_Bold.TabIndex = 0;
            this.menus_Bold.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打開OToolStripMenuItem,
            this.退出QToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.文件ToolStripMenuItem.Text = "文件&F";
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
            // btn_Bold
            // 
            this.btn_Bold.Location = new System.Drawing.Point(74, 121);
            this.btn_Bold.Name = "btn_Bold";
            this.btn_Bold.Size = new System.Drawing.Size(169, 23);
            this.btn_Bold.TabIndex = 1;
            this.btn_Bold.Text = "將功能表項的字體設定為粗體";
            this.btn_Bold.UseVisualStyleBackColor = true;
            this.btn_Bold.Click += new System.EventHandler(this.btn_Bold_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 166);
            this.Controls.Add(this.btn_Bold);
            this.Controls.Add(this.menus_Bold);
            this.MainMenuStrip = this.menus_Bold;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "將功能表項的字體設定為粗體";
            this.menus_Bold.ResumeLayout(false);
            this.menus_Bold.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menus_Bold;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出QToolStripMenuItem;
        private System.Windows.Forms.Button btn_Bold;
    }
}

