namespace ExcelToAccess
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
            this.btn_Access = new System.Windows.Forms.Button();
            this.txt_Access = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbox_SheetName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Access);
            this.groupBox1.Controls.Add(this.txt_Access);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbox_SheetName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.txt_Path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // btn_Access
            // 
            this.btn_Access.Location = new System.Drawing.Point(263, 76);
            this.btn_Access.Name = "btn_Access";
            this.btn_Access.Size = new System.Drawing.Size(49, 23);
            this.btn_Access.TabIndex = 7;
            this.btn_Access.Text = "選擇";
            this.btn_Access.UseVisualStyleBackColor = true;
            this.btn_Access.Click += new System.EventHandler(this.btn_Access_Click);
            // 
            // txt_Access
            // 
            this.txt_Access.Location = new System.Drawing.Point(125, 78);
            this.txt_Access.Name = "txt_Access";
            this.txt_Access.ReadOnly = true;
            this.txt_Access.Size = new System.Drawing.Size(131, 21);
            this.txt_Access.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "請選擇Access文件：";
            // 
            // cbox_SheetName
            // 
            this.cbox_SheetName.FormattingEnabled = true;
            this.cbox_SheetName.Location = new System.Drawing.Point(125, 51);
            this.cbox_SheetName.Name = "cbox_SheetName";
            this.cbox_SheetName.Size = new System.Drawing.Size(131, 20);
            this.cbox_SheetName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "請選擇工作表：";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(263, 22);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(49, 23);
            this.btn_Select.TabIndex = 2;
            this.btn_Select.Text = "選擇";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(125, 24);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(131, 21);
            this.txt_Path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "請選擇Excel文件：";
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(201, 126);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(62, 23);
            this.btn_Export.TabIndex = 5;
            this.btn_Export.Text = "導出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(269, 126);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(62, 23);
            this.btn_Browse.TabIndex = 6;
            this.btn_Browse.Text = "查看";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 154);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "讀取Excel查詢結果到Access資料庫";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.ComboBox cbox_SheetName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Access;
        private System.Windows.Forms.TextBox txt_Access;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Browse;
    }
}

