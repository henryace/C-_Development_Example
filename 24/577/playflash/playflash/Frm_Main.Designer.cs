namespace playflash
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關閉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.控制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第一幀ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.向前ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.向後ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.幫助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.控制CToolStripMenuItem,
            this.幫助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(417, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打開ToolStripMenuItem,
            this.關閉ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打開ToolStripMenuItem
            // 
            this.打開ToolStripMenuItem.Name = "打開ToolStripMenuItem";
            this.打開ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打開ToolStripMenuItem.Text = "打開";
            this.打開ToolStripMenuItem.Click += new System.EventHandler(this.打開ToolStripMenuItem_Click);
            // 
            // 關閉ToolStripMenuItem
            // 
            this.關閉ToolStripMenuItem.Name = "關閉ToolStripMenuItem";
            this.關閉ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.關閉ToolStripMenuItem.Text = "關閉";
            this.關閉ToolStripMenuItem.Click += new System.EventHandler(this.關閉ToolStripMenuItem_Click);
            // 
            // 控制CToolStripMenuItem
            // 
            this.控制CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.播放ToolStripMenuItem,
            this.第一幀ToolStripMenuItem,
            this.toolStripSeparator1,
            this.向前ToolStripMenuItem,
            this.向後ToolStripMenuItem});
            this.控制CToolStripMenuItem.Name = "控制CToolStripMenuItem";
            this.控制CToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.控制CToolStripMenuItem.Text = "控制(&C)";
            // 
            // 播放ToolStripMenuItem
            // 
            this.播放ToolStripMenuItem.Name = "播放ToolStripMenuItem";
            this.播放ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.播放ToolStripMenuItem.Text = "播放";
            this.播放ToolStripMenuItem.Click += new System.EventHandler(this.播放ToolStripMenuItem_Click);
            // 
            // 第一幀ToolStripMenuItem
            // 
            this.第一幀ToolStripMenuItem.Name = "第一幀ToolStripMenuItem";
            this.第一幀ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第一幀ToolStripMenuItem.Text = "第一幀";
            this.第一幀ToolStripMenuItem.Click += new System.EventHandler(this.第一幀ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // 向前ToolStripMenuItem
            // 
            this.向前ToolStripMenuItem.Name = "向前ToolStripMenuItem";
            this.向前ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.向前ToolStripMenuItem.Text = "向前";
            this.向前ToolStripMenuItem.Click += new System.EventHandler(this.向前ToolStripMenuItem_Click);
            // 
            // 向後ToolStripMenuItem
            // 
            this.向後ToolStripMenuItem.Name = "向後ToolStripMenuItem";
            this.向後ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.向後ToolStripMenuItem.Text = "向後";
            this.向後ToolStripMenuItem.Click += new System.EventHandler(this.向後ToolStripMenuItem_Click);
            // 
            // 幫助HToolStripMenuItem
            // 
            this.幫助HToolStripMenuItem.Name = "幫助HToolStripMenuItem";
            this.幫助HToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.幫助HToolStripMenuItem.Text = "幫助(&H)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "FLASH|*.swf";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::playflash.Properties.Resources.bg1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 330);
            this.panel1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放Flash動畫";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 控制CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 幫助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 播放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第一幀ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 向前ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 向後ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關閉ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}

