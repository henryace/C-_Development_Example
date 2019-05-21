namespace TypeOf
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
            this.rtbox_text = new System.Windows.Forms.RichTextBox();
            this.btn_Get = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbox_text
            // 
            this.rtbox_text.Location = new System.Drawing.Point(0, 2);
            this.rtbox_text.Name = "rtbox_text";
            this.rtbox_text.Size = new System.Drawing.Size(321, 262);
            this.rtbox_text.TabIndex = 3;
            this.rtbox_text.Text = "";
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(119, 266);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(75, 23);
            this.btn_Get.TabIndex = 2;
            this.btn_Get.Text = "取得";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 292);
            this.Controls.Add(this.rtbox_text);
            this.Controls.Add(this.btn_Get);
            this.Name = "Form1";
            this.Text = "使用typeof運算符取得類別的內部結構";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_text;
        private System.Windows.Forms.Button btn_Get;
    }
}

