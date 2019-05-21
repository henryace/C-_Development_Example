namespace textNewLine
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
            this.txt_Str = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Str
            // 
            this.txt_Str.Location = new System.Drawing.Point(0, 0);
            this.txt_Str.Multiline = true;
            this.txt_Str.Name = "txt_Str";
            this.txt_Str.Size = new System.Drawing.Size(339, 172);
            this.txt_Str.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(127, 182);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "新增字串";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 213);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_Str);
            this.Name = "Frm_Main";
            this.Text = "在TextBox控制元件中顯示換行符號";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Str;
        private System.Windows.Forms.Button btn_Add;
    }
}

