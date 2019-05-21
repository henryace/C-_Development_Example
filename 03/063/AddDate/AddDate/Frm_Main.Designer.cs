namespace AddDate
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
            this.btn_AddM = new System.Windows.Forms.Button();
            this.btn_AddH = new System.Windows.Forms.Button();
            this.btn_addD = new System.Windows.Forms.Button();
            this.lab_time = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AddM
            // 
            this.btn_AddM.Location = new System.Drawing.Point(31, 67);
            this.btn_AddM.Name = "btn_AddM";
            this.btn_AddM.Size = new System.Drawing.Size(70, 23);
            this.btn_AddM.TabIndex = 1;
            this.btn_AddM.Text = "加1分鐘";
            this.btn_AddM.UseVisualStyleBackColor = true;
            this.btn_AddM.Click += new System.EventHandler(this.btn_AddM_Click);
            // 
            // btn_AddH
            // 
            this.btn_AddH.Location = new System.Drawing.Point(146, 67);
            this.btn_AddH.Name = "btn_AddH";
            this.btn_AddH.Size = new System.Drawing.Size(70, 23);
            this.btn_AddH.TabIndex = 2;
            this.btn_AddH.Text = "加1小時";
            this.btn_AddH.UseVisualStyleBackColor = true;
            this.btn_AddH.Click += new System.EventHandler(this.btn_AddH_Click);
            // 
            // btn_addD
            // 
            this.btn_addD.Location = new System.Drawing.Point(266, 67);
            this.btn_addD.Name = "btn_addD";
            this.btn_addD.Size = new System.Drawing.Size(70, 23);
            this.btn_addD.TabIndex = 3;
            this.btn_addD.Text = "加1天";
            this.btn_addD.UseVisualStyleBackColor = true;
            this.btn_addD.Click += new System.EventHandler(this.btn_addD_Click);
            // 
            // lab_time
            // 
            this.lab_time.AutoSize = true;
            this.lab_time.Location = new System.Drawing.Point(80, 30);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(41, 12);
            this.lab_time.TabIndex = 4;
            this.lab_time.Text = "時間：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_time);
            this.groupBox1.Controls.Add(this.btn_AddM);
            this.groupBox1.Controls.Add(this.btn_addD);
            this.groupBox1.Controls.Add(this.btn_AddH);
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增時間間隔";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 107);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用DateAdd方法向指定日期新增一段時間間隔";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_AddM;
        private System.Windows.Forms.Button btn_AddH;
        private System.Windows.Forms.Button btn_addD;
        private System.Windows.Forms.Label lab_time;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

