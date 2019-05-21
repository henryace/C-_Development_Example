namespace SnatchDetailsInfoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButOpen = new System.Windows.Forms.ToolStripButton();
            this.ButPlay = new System.Windows.Forms.ToolStripButton();
            this.ButStop = new System.Windows.Forms.ToolStripButton();
            this.ButPause = new System.Windows.Forms.ToolStripButton();
            this.ButInfo = new System.Windows.Forms.ToolStripButton();
            this.optFile = new System.Windows.Forms.OpenFileDialog();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButOpen,
            this.ButPlay,
            this.ButStop,
            this.ButPause,
            this.ButInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 349);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(513, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButOpen
            // 
            this.ButOpen.Font = new System.Drawing.Font("細明體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButOpen.Image = ((System.Drawing.Image)(resources.GetObject("ButOpen.Image")));
            this.ButOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButOpen.Name = "ButOpen";
            this.ButOpen.Size = new System.Drawing.Size(76, 22);
            this.ButOpen.Text = "打開(&O)";
            this.ButOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButOpen.ToolTipText = "打開";
            this.ButOpen.Click += new System.EventHandler(this.ButOpen_Click);
            // 
            // ButPlay
            // 
            this.ButPlay.Font = new System.Drawing.Font("細明體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButPlay.Image = ((System.Drawing.Image)(resources.GetObject("ButPlay.Image")));
            this.ButPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButPlay.Name = "ButPlay";
            this.ButPlay.Size = new System.Drawing.Size(76, 22);
            this.ButPlay.Text = "播放(&P)";
            this.ButPlay.ToolTipText = "播放";
            this.ButPlay.Click += new System.EventHandler(this.ButPlay_Click);
            // 
            // ButStop
            // 
            this.ButStop.Font = new System.Drawing.Font("細明體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButStop.Image = ((System.Drawing.Image)(resources.GetObject("ButStop.Image")));
            this.ButStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButStop.Name = "ButStop";
            this.ButStop.Size = new System.Drawing.Size(76, 22);
            this.ButStop.Text = "停止(&S)";
            this.ButStop.ToolTipText = "停止";
            this.ButStop.Click += new System.EventHandler(this.ButStop_Click);
            // 
            // ButPause
            // 
            this.ButPause.Font = new System.Drawing.Font("細明體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButPause.Image = ((System.Drawing.Image)(resources.GetObject("ButPause.Image")));
            this.ButPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButPause.Name = "ButPause";
            this.ButPause.Size = new System.Drawing.Size(76, 22);
            this.ButPause.Text = "暫停(&A)";
            this.ButPause.ToolTipText = "暫停";
            this.ButPause.Click += new System.EventHandler(this.ButPause_Click);
            // 
            // ButInfo
            // 
            this.ButInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButInfo.Image = ((System.Drawing.Image)(resources.GetObject("ButInfo.Image")));
            this.ButInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButInfo.Name = "ButInfo";
            this.ButInfo.Size = new System.Drawing.Size(60, 22);
            this.ButInfo.Text = "歌曲訊息";
            this.ButInfo.Click += new System.EventHandler(this.ButInfo_Click);
            // 
            // optFile
            // 
            this.optFile.FileName = "optFile";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(513, 374);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 374);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取得多媒體詳細訊息列表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButOpen;
        private System.Windows.Forms.ToolStripButton ButPlay;
        private System.Windows.Forms.ToolStripButton ButStop;
        private System.Windows.Forms.ToolStripButton ButPause;
        private System.Windows.Forms.OpenFileDialog optFile;
        private System.Windows.Forms.ToolStripButton ButInfo;
    }
}

