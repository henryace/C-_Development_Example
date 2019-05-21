namespace ArrayRank
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
            this.btn_GetArray = new System.Windows.Forms.Button();
            this.txt_display = new System.Windows.Forms.TextBox();
            this.lab_Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_GetArray
            // 
            this.btn_GetArray.Location = new System.Drawing.Point(12, 10);
            this.btn_GetArray.Name = "btn_GetArray";
            this.btn_GetArray.Size = new System.Drawing.Size(105, 23);
            this.btn_GetArray.TabIndex = 0;
            this.btn_GetArray.Text = "隨機產生陣列";
            this.btn_GetArray.UseVisualStyleBackColor = true;
            this.btn_GetArray.Click += new System.EventHandler(this.btn_GetArray_Click);
            // 
            // txt_display
            // 
            this.txt_display.Location = new System.Drawing.Point(0, 41);
            this.txt_display.Multiline = true;
            this.txt_display.Name = "txt_display";
            this.txt_display.Size = new System.Drawing.Size(347, 78);
            this.txt_display.TabIndex = 1;
            // 
            // lab_Message
            // 
            this.lab_Message.AutoSize = true;
            this.lab_Message.Location = new System.Drawing.Point(127, 16);
            this.lab_Message.Name = "lab_Message";
            this.lab_Message.Size = new System.Drawing.Size(0, 12);
            this.lab_Message.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 124);
            this.Controls.Add(this.lab_Message);
            this.Controls.Add(this.txt_display);
            this.Controls.Add(this.btn_GetArray);
            this.Name = "Frm_Main";
            this.Text = "取得二維陣列的行數與列數";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetArray;
        private System.Windows.Forms.TextBox txt_display;
        private System.Windows.Forms.Label lab_Message;

    }
}

