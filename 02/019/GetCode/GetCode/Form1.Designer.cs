namespace GetCode
{
    partial class Form1
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
            this.txt_Num = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_chr = new System.Windows.Forms.TextBox();
            this.btn_Get = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Num
            // 
            this.txt_Num.Location = new System.Drawing.Point(146, 52);
            this.txt_Num.Name = "txt_Num";
            this.txt_Num.Size = new System.Drawing.Size(100, 21);
            this.txt_Num.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "輸入一個中文字符：";
            // 
            // txt_chr
            // 
            this.txt_chr.Location = new System.Drawing.Point(146, 14);
            this.txt_chr.Name = "txt_chr";
            this.txt_chr.Size = new System.Drawing.Size(100, 21);
            this.txt_chr.TabIndex = 5;
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(26, 50);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(100, 23);
            this.btn_Get.TabIndex = 4;
            this.btn_Get.Text = "取得中文編碼值";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 89);
            this.Controls.Add(this.txt_Num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_chr);
            this.Controls.Add(this.btn_Get);
            this.Name = "Form1";
            this.Text = "取得中文編碼值";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_chr;
        private System.Windows.Forms.Button btn_Get;
    }
}

