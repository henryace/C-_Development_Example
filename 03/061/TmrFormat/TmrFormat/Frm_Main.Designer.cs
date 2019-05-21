namespace TmrFormat
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
            this.btn_GetTime = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_time = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GetTime
            // 
            this.btn_GetTime.Location = new System.Drawing.Point(109, 16);
            this.btn_GetTime.Name = "btn_GetTime";
            this.btn_GetTime.Size = new System.Drawing.Size(86, 23);
            this.btn_GetTime.TabIndex = 0;
            this.btn_GetTime.Text = "取得系統時間";
            this.btn_GetTime.UseVisualStyleBackColor = true;
            this.btn_GetTime.Click += new System.EventHandler(this.btn_GetTime_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_time);
            this.groupBox1.Controls.Add(this.btn_GetTime);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "顯示系統時間";
            // 
            // lab_time
            // 
            this.lab_time.AutoSize = true;
            this.lab_time.Location = new System.Drawing.Point(27, 41);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(0, 12);
            this.lab_time.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 181);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "將日期格式化為指定格式";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_time;
    }
}

