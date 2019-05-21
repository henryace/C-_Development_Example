namespace GetDateDiff
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
            this.dtpicker_first = new System.Windows.Forms.DateTimePicker();
            this.dtpicker_second = new System.Windows.Forms.DateTimePicker();
            this.btn_Get = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpicker_first
            // 
            this.dtpicker_first.Location = new System.Drawing.Point(162, 26);
            this.dtpicker_first.Name = "dtpicker_first";
            this.dtpicker_first.Size = new System.Drawing.Size(122, 21);
            this.dtpicker_first.TabIndex = 0;
            // 
            // dtpicker_second
            // 
            this.dtpicker_second.Location = new System.Drawing.Point(162, 56);
            this.dtpicker_second.Name = "dtpicker_second";
            this.dtpicker_second.Size = new System.Drawing.Size(122, 21);
            this.dtpicker_second.TabIndex = 1;
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(125, 109);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(107, 23);
            this.btn_Get.TabIndex = 2;
            this.btn_Get.Text = "計算時間間隔";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpicker_first);
            this.groupBox1.Controls.Add(this.dtpicker_second);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "計算時間間隔";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "第一次取得時間：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "第二次取得時間：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 139);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Get);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用DateDiff方法取得日期時間的間隔數";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpicker_first;
        private System.Windows.Forms.DateTimePicker dtpicker_second;
        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

