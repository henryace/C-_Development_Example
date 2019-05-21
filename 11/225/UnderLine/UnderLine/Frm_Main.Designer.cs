namespace UnderLine
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
            this.btn_DisplayUnderLine = new System.Windows.Forms.Button();
            this.txt_Str = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_DisplayUnderLine
            // 
            this.btn_DisplayUnderLine.Location = new System.Drawing.Point(116, 140);
            this.btn_DisplayUnderLine.Name = "btn_DisplayUnderLine";
            this.btn_DisplayUnderLine.Size = new System.Drawing.Size(75, 23);
            this.btn_DisplayUnderLine.TabIndex = 0;
            this.btn_DisplayUnderLine.Text = "顯示下劃線";
            this.btn_DisplayUnderLine.UseVisualStyleBackColor = true;
            this.btn_DisplayUnderLine.Click += new System.EventHandler(this.btn_DisplayUnderLine_Click);
            // 
            // txt_Str
            // 
            this.txt_Str.Font = new System.Drawing.Font("細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Str.Location = new System.Drawing.Point(0, 0);
            this.txt_Str.Multiline = true;
            this.txt_Str.Name = "txt_Str";
            this.txt_Str.Size = new System.Drawing.Size(315, 134);
            this.txt_Str.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 165);
            this.Controls.Add(this.txt_Str);
            this.Controls.Add(this.btn_DisplayUnderLine);
            this.Name = "Frm_Main";
            this.Text = "在TextBox控制元件底端顯示下劃線";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DisplayUnderLine;
        private System.Windows.Forms.TextBox txt_Str;
    }
}

