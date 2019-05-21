namespace DisableMenuItem
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
            this.menus_Main = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Enable = new System.Windows.Forms.Button();
            this.btn_Disable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menus_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menus_Main
            // 
            this.menus_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menus_Main.Location = new System.Drawing.Point(0, 0);
            this.menus_Main.Name = "menus_Main";
            this.menus_Main.Size = new System.Drawing.Size(341, 25);
            this.menus_Main.TabIndex = 0;
            this.menus_Main.Text = "menuStrip1";
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
            // btn_Enable
            // 
            this.btn_Enable.Location = new System.Drawing.Point(64, 20);
            this.btn_Enable.Name = "btn_Enable";
            this.btn_Enable.Size = new System.Drawing.Size(75, 23);
            this.btn_Enable.TabIndex = 1;
            this.btn_Enable.Text = "啟用功能表項";
            this.btn_Enable.UseVisualStyleBackColor = true;
            this.btn_Enable.Click += new System.EventHandler(this.btn_Enable_Click);
            // 
            // btn_Disable
            // 
            this.btn_Disable.Location = new System.Drawing.Point(204, 20);
            this.btn_Disable.Name = "btn_Disable";
            this.btn_Disable.Size = new System.Drawing.Size(75, 23);
            this.btn_Disable.TabIndex = 2;
            this.btn_Disable.Text = "停用功能表項";
            this.btn_Disable.UseVisualStyleBackColor = true;
            this.btn_Disable.Click += new System.EventHandler(this.btn_Disable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Enable);
            this.groupBox1.Controls.Add(this.btn_Disable);
            this.groupBox1.Location = new System.Drawing.Point(0, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 142);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menus_Main);
            this.MainMenuStrip = this.menus_Main;
            this.Name = "Frm_Main";
            this.Text = "設定功能表項是否可用";
            this.menus_Main.ResumeLayout(false);
            this.menus_Main.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menus_Main;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出QToolStripMenuItem;
        private System.Windows.Forms.Button btn_Enable;
        private System.Windows.Forms.Button btn_Disable;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

