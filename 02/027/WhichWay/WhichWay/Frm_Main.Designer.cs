namespace WhichWay
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
            this.btn_go = new System.Windows.Forms.Button();
            this.rbtn_school = new System.Windows.Forms.RadioButton();
            this.rbtn_hospital = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(117, 50);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 23);
            this.btn_go.TabIndex = 0;
            this.btn_go.Text = "出發";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // rbtn_school
            // 
            this.rbtn_school.AutoSize = true;
            this.rbtn_school.Checked = true;
            this.rbtn_school.Location = new System.Drawing.Point(56, 26);
            this.rbtn_school.Name = "rbtn_school";
            this.rbtn_school.Size = new System.Drawing.Size(59, 16);
            this.rbtn_school.TabIndex = 1;
            this.rbtn_school.TabStop = true;
            this.rbtn_school.Text = "去學校";
            this.rbtn_school.UseVisualStyleBackColor = true;
            // 
            // rbtn_hospital
            // 
            this.rbtn_hospital.AutoSize = true;
            this.rbtn_hospital.Location = new System.Drawing.Point(195, 26);
            this.rbtn_hospital.Name = "rbtn_hospital";
            this.rbtn_hospital.Size = new System.Drawing.Size(59, 16);
            this.rbtn_hospital.TabIndex = 2;
            this.rbtn_hospital.TabStop = true;
            this.rbtn_hospital.Text = "去醫院";
            this.rbtn_hospital.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 83);
            this.Controls.Add(this.rbtn_hospital);
            this.Controls.Add(this.rbtn_school);
            this.Controls.Add(this.btn_go);
            this.Name = "Form1";
            this.Text = "小明去學校和醫院分別要走哪條路";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.RadioButton rbtn_school;
        private System.Windows.Forms.RadioButton rbtn_hospital;
    }
}

