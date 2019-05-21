namespace GetGridData
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStrip_Kit = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Blank = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_All = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(337, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 213);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(338, 134);
            this.dataGridView2.TabIndex = 4;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(61, 184);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(223, 23);
            this.btn_Copy.TabIndex = 6;
            this.btn_Copy.Text = "將資料複製到另一個DataGridView";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_Kit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(355, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStrip_Kit
            // 
            this.ToolStrip_Kit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_Blank,
            this.Tool_All});
            this.ToolStrip_Kit.Name = "ToolStrip_Kit";
            this.ToolStrip_Kit.Size = new System.Drawing.Size(41, 20);
            this.ToolStrip_Kit.Text = "工具";
            // 
            // Tool_Blank
            // 
            this.Tool_Blank.Name = "Tool_Blank";
            this.Tool_Blank.Size = new System.Drawing.Size(160, 22);
            this.Tool_Blank.Text = "是否用*替換空格";
            this.Tool_Blank.Click += new System.EventHandler(this.Tool_Blank_Click);
            // 
            // Tool_All
            // 
            this.Tool_All.Name = "Tool_All";
            this.Tool_All.Size = new System.Drawing.Size(160, 22);
            this.Tool_All.Text = "是否全部替換";
            this.Tool_All.Click += new System.EventHandler(this.Tool_All_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 353);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "像Excel一樣複製DataGridView中資料";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_Kit;
        private System.Windows.Forms.ToolStripMenuItem Tool_Blank;
        private System.Windows.Forms.ToolStripMenuItem Tool_All;
    }
}

