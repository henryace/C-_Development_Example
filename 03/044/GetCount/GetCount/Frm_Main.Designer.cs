﻿namespace GetCount
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_str = new System.Windows.Forms.TextBox();
            this.btn_GetCount = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_count);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_str);
            this.groupBox1.Controls.Add(this.btn_GetCount);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "取得中文字數量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "個中文字";
            // 
            // txt_count
            // 
            this.txt_count.Location = new System.Drawing.Point(151, 53);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(52, 22);
            this.txt_count.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "請輸入中文字字符：";
            // 
            // txt_str
            // 
            this.txt_str.Location = new System.Drawing.Point(151, 23);
            this.txt_str.Name = "txt_str";
            this.txt_str.Size = new System.Drawing.Size(100, 22);
            this.txt_str.TabIndex = 6;
            // 
            // btn_GetCount
            // 
            this.btn_GetCount.Location = new System.Drawing.Point(46, 51);
            this.btn_GetCount.Name = "btn_GetCount";
            this.btn_GetCount.Size = new System.Drawing.Size(94, 23);
            this.btn_GetCount.TabIndex = 5;
            this.btn_GetCount.Text = "取得中文字數量";
            this.btn_GetCount.UseVisualStyleBackColor = true;
            this.btn_GetCount.Click += new System.EventHandler(this.btn_GetCount_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 104);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取得字串中中文字的個數";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_str;
        private System.Windows.Forms.Button btn_GetCount;

    }
}

