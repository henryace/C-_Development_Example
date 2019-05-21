namespace Txt_PassWord
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
            this.btn_Str = new System.Windows.Forms.Button();
            this.btn_PassWord = new System.Windows.Forms.Button();
            this.txt_Change = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Str
            // 
            this.btn_Str.Location = new System.Drawing.Point(35, 77);
            this.btn_Str.Name = "btn_Str";
            this.btn_Str.Size = new System.Drawing.Size(104, 23);
            this.btn_Str.TabIndex = 0;
            this.btn_Str.Text = "轉換為字串輸入";
            this.btn_Str.UseVisualStyleBackColor = true;
            this.btn_Str.Click += new System.EventHandler(this.btn_Str_Click);
            // 
            // btn_PassWord
            // 
            this.btn_PassWord.Location = new System.Drawing.Point(157, 77);
            this.btn_PassWord.Name = "btn_PassWord";
            this.btn_PassWord.Size = new System.Drawing.Size(104, 23);
            this.btn_PassWord.TabIndex = 1;
            this.btn_PassWord.Text = "轉換為密碼輸入";
            this.btn_PassWord.UseVisualStyleBackColor = true;
            this.btn_PassWord.Click += new System.EventHandler(this.btn_PassWord_Click);
            // 
            // txt_Change
            // 
            this.txt_Change.Location = new System.Drawing.Point(98, 35);
            this.txt_Change.Name = "txt_Change";
            this.txt_Change.Size = new System.Drawing.Size(100, 21);
            this.txt_Change.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 112);
            this.Controls.Add(this.txt_Change);
            this.Controls.Add(this.btn_PassWord);
            this.Controls.Add(this.btn_Str);
            this.Name = "Frm_Main";
            this.Text = "製作密碼文字框";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Str;
        private System.Windows.Forms.Button btn_PassWord;
        private System.Windows.Forms.TextBox txt_Change;
    }
}

