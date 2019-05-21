namespace BeautifulProgressBar
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
            this.BeautifulProgressBar1 = new WindowsFormsControlLibrary.SmoothProgressBar();
            this.BeautifulProgressBar2 = new WindowsFormsControlLibrary.SmoothProgressBar();
            this.StartOrStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BeautifulProgressBar1
            // 
            this.BeautifulProgressBar1.BackColor = System.Drawing.Color.MistyRose;
            this.BeautifulProgressBar1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BeautifulProgressBar1.Location = new System.Drawing.Point(23, 13);
            this.BeautifulProgressBar1.Maximum = 100;
            this.BeautifulProgressBar1.Minimum = 0;
            this.BeautifulProgressBar1.Name = "BeautifulProgressBar1";
            this.BeautifulProgressBar1.ProgressBarColor = System.Drawing.Color.Blue;
            this.BeautifulProgressBar1.Size = new System.Drawing.Size(150, 30);
            this.BeautifulProgressBar1.TabIndex = 4;
            this.BeautifulProgressBar1.Value = 0;
            // 
            // BeautifulProgressBar2
            // 
            this.BeautifulProgressBar2.BackColor = System.Drawing.Color.Blue;
            this.BeautifulProgressBar2.Location = new System.Drawing.Point(23, 49);
            this.BeautifulProgressBar2.Maximum = 100;
            this.BeautifulProgressBar2.Minimum = 0;
            this.BeautifulProgressBar2.Name = "BeautifulProgressBar2";
            this.BeautifulProgressBar2.ProgressBarColor = System.Drawing.Color.MediumSpringGreen;
            this.BeautifulProgressBar2.Size = new System.Drawing.Size(150, 30);
            this.BeautifulProgressBar2.TabIndex = 3;
            this.BeautifulProgressBar2.Value = 0;
            // 
            // StartOrStop
            // 
            this.StartOrStop.Location = new System.Drawing.Point(61, 85);
            this.StartOrStop.Name = "StartOrStop";
            this.StartOrStop.Size = new System.Drawing.Size(75, 28);
            this.StartOrStop.TabIndex = 2;
            this.StartOrStop.Text = "開始";
            this.StartOrStop.UseVisualStyleBackColor = true;
            this.StartOrStop.Click += new System.EventHandler(this.StartOrStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 125);
            this.Controls.Add(this.StartOrStop);
            this.Controls.Add(this.BeautifulProgressBar2);
            this.Controls.Add(this.BeautifulProgressBar1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自製平滑進度列控制元件";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsControlLibrary.SmoothProgressBar BeautifulProgressBar1;
        private WindowsFormsControlLibrary.SmoothProgressBar BeautifulProgressBar2;
        private System.Windows.Forms.Button StartOrStop;
        private System.Windows.Forms.Timer timer1;
    }
}

