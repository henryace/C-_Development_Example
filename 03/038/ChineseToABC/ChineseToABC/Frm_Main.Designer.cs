namespace ChineseToABC
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
            this.txt_Chinese = new System.Windows.Forms.TextBox();
            this.txt_PinYIn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Chinese
            // 
            this.txt_Chinese.Location = new System.Drawing.Point(12, 18);
            this.txt_Chinese.Name = "txt_Chinese";
            this.txt_Chinese.Size = new System.Drawing.Size(310, 21);
            this.txt_Chinese.TabIndex = 0;
            this.txt_Chinese.TextChanged += new System.EventHandler(this.txt_Chinese_TextChanged);
            // 
            // txt_PinYIn
            // 
            this.txt_PinYIn.Location = new System.Drawing.Point(12, 55);
            this.txt_PinYIn.Name = "txt_PinYIn";
            this.txt_PinYIn.ReadOnly = true;
            this.txt_PinYIn.Size = new System.Drawing.Size(310, 21);
            this.txt_PinYIn.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 91);
            this.Controls.Add(this.txt_PinYIn);
            this.Controls.Add(this.txt_Chinese);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "將中文字轉換為拼音";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Chinese;
        private System.Windows.Forms.TextBox txt_PinYIn;
    }
}

