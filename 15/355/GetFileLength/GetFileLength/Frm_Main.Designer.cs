﻿namespace GetFileLength
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
            this.btn_Get = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(74, 36);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(124, 23);
            this.btn_Get.TabIndex = 0;
            this.btn_Get.Text = "選擇檔案判斷大小";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Get);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 91);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取得檔案的大小";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

