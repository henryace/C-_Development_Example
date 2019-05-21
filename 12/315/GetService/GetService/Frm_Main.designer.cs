namespace GetService
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
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Status = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.White;
            this.btn_Start.Enabled = false;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.ForeColor = System.Drawing.Color.Red;
            this.btn_Start.Location = new System.Drawing.Point(102, 133);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(104, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "啟動IIS服務(&W)";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.Color.White;
            this.btn_Stop.Enabled = false;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.ForeColor = System.Drawing.Color.Red;
            this.btn_Stop.Location = new System.Drawing.Point(193, 213);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(104, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "停止IIS服務(&Q)";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Status
            // 
            this.btn_Status.BackColor = System.Drawing.Color.White;
            this.btn_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Status.ForeColor = System.Drawing.Color.Red;
            this.btn_Status.Location = new System.Drawing.Point(193, 56);
            this.btn_Status.Name = "btn_Status";
            this.btn_Status.Size = new System.Drawing.Size(104, 23);
            this.btn_Status.TabIndex = 2;
            this.btn_Status.Text = "IIS服務狀態(&D)";
            this.btn_Status.UseVisualStyleBackColor = false;
            this.btn_Status.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GetService.Properties.Resources._20080811_b7e5eb1623139377650eJ32s2hJgG4uy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 280);
            this.Controls.Add(this.btn_Status);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用ServiceController元件計算機的服務";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Status;
    }
}

