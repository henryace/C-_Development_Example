namespace AddToListBox
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
            this.components = new System.ComponentModel.Container();
            this.lb_Str = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.messageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testDataSet = new AddToListBox.testDataSet();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Str
            // 
            this.lb_Str.FormattingEnabled = true;
            this.lb_Str.ItemHeight = 12;
            this.lb_Str.Location = new System.Drawing.Point(6, 12);
            this.lb_Str.Name = "lb_Str";
            this.lb_Str.Size = new System.Drawing.Size(347, 160);
            this.lb_Str.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Str);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "內容";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Add);
            this.groupBox2.Location = new System.Drawing.Point(5, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(77, 20);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(201, 23);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "將ACCESS中的資料新增到ListBox";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // messageBindingSource
            // 
            this.messageBindingSource.DataSource = this.testDataSet;
            this.messageBindingSource.Position = 0;
            // 
            // testDataSet
            // 
            this.testDataSet.DataSetName = "testDataSet";
            this.testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 246);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "將資料庫資料新增到組合框中";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Str;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.BindingSource messageBindingSource;
        private testDataSet testDataSet;
    }
}

