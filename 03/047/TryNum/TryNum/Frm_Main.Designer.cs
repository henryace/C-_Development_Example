namespace TryNum
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
            this.txt_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_true
            // 
            this.btn_true.Location = new System.Drawing.Point(105, 56);
            this.btn_true.Name = "btn_true";
            this.btn_true.Size = new System.Drawing.Size(86, 23);
            this.btn_true.TabIndex = 0;
            this.btn_true.Text = "判斷";
            this.btn_true.UseVisualStyleBackColor = true;
            this.btn_true.Click += new System.EventHandler(this.btn_true_Click);
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(155, 24);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(63, 21);
            this.txt_value.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "請輸入貨幣值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "元";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 90);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.btn_true);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "判斷輸入的貨幣值是否為數字";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_true;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

