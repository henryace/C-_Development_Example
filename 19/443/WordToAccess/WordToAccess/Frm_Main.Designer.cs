﻿namespace WordToAccess
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_DisplayData = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.btn_display = new System.Windows.Forms.Button();
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_DisplayData);
            this.groupBox1.Controls.Add(this.btn_Write);
            this.groupBox1.Controls.Add(this.btn_display);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 148);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "將資料寫入Access";
            // 
            // btn_DisplayData
            // 
            this.btn_DisplayData.Location = new System.Drawing.Point(83, 110);
            this.btn_DisplayData.Name = "btn_DisplayData";
            this.btn_DisplayData.Size = new System.Drawing.Size(187, 23);
            this.btn_DisplayData.TabIndex = 2;
            this.btn_DisplayData.Text = "顯示Access中的資料";
            this.btn_DisplayData.UseVisualStyleBackColor = true;
            this.btn_DisplayData.Click += new System.EventHandler(this.btn_DisplayData_Click);
            // 
            // btn_Write
            // 
            this.btn_Write.Enabled = false;
            this.btn_Write.Location = new System.Drawing.Point(83, 71);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(187, 23);
            this.btn_Write.TabIndex = 0;
            this.btn_Write.Text = "將Word文件檔中的資料寫入Access";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_display
            // 
            this.btn_display.Location = new System.Drawing.Point(83, 32);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(187, 23);
            this.btn_display.TabIndex = 1;
            this.btn_display.Text = "顯示Word文件檔並手動新增資料";
            this.btn_display.UseVisualStyleBackColor = true;
            this.btn_display.Click += new System.EventHandler(this.btn_display_Click);
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(12, 173);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(360, 245);
            this.dgv_Message.TabIndex = 3;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 167);
            this.Controls.Add(this.dgv_Message);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "讀取Word文件檔中表格資料到Access資料庫";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Button btn_display;
        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.Button btn_DisplayData;
    }
}

