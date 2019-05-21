namespace OnlyDigit
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Str
            // 
            this.txt_Str.Location = new System.Drawing.Point(133, 40);
            this.txt_Str.Name = "txt_Str";
            this.txt_Str.ShortcutsEnabled = false;
            this.txt_Str.Size = new System.Drawing.Size(184, 21);
            this.txt_Str.TabIndex = 0;
            this.txt_Str.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Str_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "只允許輸入數字：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 94);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Str);
            this.Name = "Frm_Main";
            this.Text = "只允許輸入數字的TextBox控制元件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Str;
        private System.Windows.Forms.Label label1;
    }
}

