namespace GetWeek
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
            this.btn_GetWeek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GetWeek
            // 
            this.btn_GetWeek.Location = new System.Drawing.Point(106, 44);
            this.btn_GetWeek.Name = "btn_GetWeek";
            this.btn_GetWeek.Size = new System.Drawing.Size(125, 23);
            this.btn_GetWeek.TabIndex = 0;
            this.btn_GetWeek.Text = "顯示星期訊息";
            this.btn_GetWeek.UseVisualStyleBackColor = true;
            this.btn_GetWeek.Click += new System.EventHandler(this.btn_GetWeek_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 105);
            this.Controls.Add(this.btn_GetWeek);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取得目前日期是星期幾";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetWeek;
    }
}

