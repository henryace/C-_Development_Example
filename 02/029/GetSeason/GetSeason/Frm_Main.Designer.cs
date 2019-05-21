namespace GetSeason
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
            this.btn_true = new System.Windows.Forms.Button();
            this.cbox_select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_true
            // 
            this.btn_true.Location = new System.Drawing.Point(184, 18);
            this.btn_true.Name = "btn_true";
            this.btn_true.Size = new System.Drawing.Size(75, 23);
            this.btn_true.TabIndex = 0;
            this.btn_true.Text = "判斷季節";
            this.btn_true.UseVisualStyleBackColor = true;
            this.btn_true.Click += new System.EventHandler(this.btn_true_Click);
            // 
            // cbox_select
            // 
            this.cbox_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_select.FormattingEnabled = true;
            this.cbox_select.Items.AddRange(new object[] {
            "1月",
            "2月",
            "3月",
            "4月",
            "5月",
            "6月",
            "7月",
            "8月",
            "9月",
            "10月",
            "11月",
            "12月"});
            this.cbox_select.Location = new System.Drawing.Point(86, 20);
            this.cbox_select.Name = "cbox_select";
            this.cbox_select.Size = new System.Drawing.Size(90, 20);
            this.cbox_select.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "選擇月份：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 56);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_select);
            this.Controls.Add(this.btn_true);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "判斷指定月份屬於哪個季節";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_true;
        private System.Windows.Forms.ComboBox cbox_select;
        private System.Windows.Forms.Label label1;
    }
}

