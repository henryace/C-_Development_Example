﻿namespace AddArrayInArray
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
            this.btn_RArray = new System.Windows.Forms.Button();
            this.txt_RArray = new System.Windows.Forms.TextBox();
            this.txt_NArray = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbox_NArray = new System.Windows.Forms.RichTextBox();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.btn_NArray = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_RArray
            // 
            this.btn_RArray.Location = new System.Drawing.Point(15, 13);
            this.btn_RArray.Name = "btn_RArray";
            this.btn_RArray.Size = new System.Drawing.Size(97, 23);
            this.btn_RArray.TabIndex = 0;
            this.btn_RArray.Text = "隨機產生陣列";
            this.btn_RArray.UseVisualStyleBackColor = true;
            this.btn_RArray.Click += new System.EventHandler(this.btn_RArray_Click);
            // 
            // txt_RArray
            // 
            this.txt_RArray.Location = new System.Drawing.Point(119, 14);
            this.txt_RArray.Name = "txt_RArray";
            this.txt_RArray.Size = new System.Drawing.Size(200, 21);
            this.txt_RArray.TabIndex = 1;
            // 
            // txt_NArray
            // 
            this.txt_NArray.Location = new System.Drawing.Point(119, 43);
            this.txt_NArray.Name = "txt_NArray";
            this.txt_NArray.Size = new System.Drawing.Size(148, 21);
            this.txt_NArray.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "新陣列：";
            // 
            // rtbox_NArray
            // 
            this.rtbox_NArray.Location = new System.Drawing.Point(32, 91);
            this.rtbox_NArray.Name = "rtbox_NArray";
            this.rtbox_NArray.Size = new System.Drawing.Size(287, 44);
            this.rtbox_NArray.TabIndex = 5;
            this.rtbox_NArray.Text = "";
            // 
            // btn_Sure
            // 
            this.btn_Sure.Location = new System.Drawing.Point(273, 41);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(46, 23);
            this.btn_Sure.TabIndex = 7;
            this.btn_Sure.Text = "確定";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // btn_NArray
            // 
            this.btn_NArray.Location = new System.Drawing.Point(17, 41);
            this.btn_NArray.Name = "btn_NArray";
            this.btn_NArray.Size = new System.Drawing.Size(97, 23);
            this.btn_NArray.TabIndex = 8;
            this.btn_NArray.Text = "產生插入陣列";
            this.btn_NArray.UseVisualStyleBackColor = true;
            this.btn_NArray.Click += new System.EventHandler(this.btn_NArray_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 147);
            this.Controls.Add(this.btn_NArray);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.rtbox_NArray);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_NArray);
            this.Controls.Add(this.txt_RArray);
            this.Controls.Add(this.btn_RArray);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在陣列中新增一個陣列";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RArray;
        private System.Windows.Forms.TextBox txt_RArray;
        private System.Windows.Forms.TextBox txt_NArray;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbox_NArray;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.Button btn_NArray;
    }
}

