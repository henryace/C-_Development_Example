namespace ComboBoxFind
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
            this.cbox_Find = new System.Windows.Forms.ComboBox();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbox_Find
            // 
            this.cbox_Find.FormattingEnabled = true;
            this.cbox_Find.Location = new System.Drawing.Point(56, 33);
            this.cbox_Find.Name = "cbox_Find";
            this.cbox_Find.Size = new System.Drawing.Size(203, 20);
            this.cbox_Find.TabIndex = 0;
            // 
            // btn_Begin
            // 
            this.btn_Begin.Location = new System.Drawing.Point(89, 68);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(138, 23);
            this.btn_Begin.TabIndex = 1;
            this.btn_Begin.Text = "實現自動查詢功能";
            this.btn_Begin.UseVisualStyleBackColor = true;
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 103);
            this.Controls.Add(this.btn_Begin);
            this.Controls.Add(this.cbox_Find);
            this.Name = "Frm_Main";
            this.Text = "實現帶查詢功能的ComboBox控制元件";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_Find;
        private System.Windows.Forms.Button btn_Begin;
    }
}

