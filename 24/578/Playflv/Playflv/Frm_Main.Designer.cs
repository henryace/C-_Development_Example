namespace Playflv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刪除選中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 276);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(299, 138);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路徑";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            this.columnHeader3.Width = 81;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空列表ToolStripMenuItem,
            this.打開文件ToolStripMenuItem,
            this.刪除選中ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 92);
            // 
            // 清空列表ToolStripMenuItem
            // 
            this.清空列表ToolStripMenuItem.AutoSize = false;
            this.清空列表ToolStripMenuItem.Image = global::Playflv.Properties.Resources.圖標__190_;
            this.清空列表ToolStripMenuItem.Name = "清空列表ToolStripMenuItem";
            this.清空列表ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空列表ToolStripMenuItem.Text = "清空列表";
            this.清空列表ToolStripMenuItem.Click += new System.EventHandler(this.清空列表ToolStripMenuItem_Click);
            // 
            // 打開文件ToolStripMenuItem
            // 
            this.打開文件ToolStripMenuItem.AutoSize = false;
            this.打開文件ToolStripMenuItem.Image = global::Playflv.Properties.Resources.圖標__220_;
            this.打開文件ToolStripMenuItem.Name = "打開文件ToolStripMenuItem";
            this.打開文件ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打開文件ToolStripMenuItem.Text = "打開文件";
            this.打開文件ToolStripMenuItem.Click += new System.EventHandler(this.打開文件ToolStripMenuItem_Click);
            // 
            // 刪除選中ToolStripMenuItem
            // 
            this.刪除選中ToolStripMenuItem.AutoSize = false;
            this.刪除選中ToolStripMenuItem.Image = global::Playflv.Properties.Resources.刪除;
            this.刪除選中ToolStripMenuItem.Name = "刪除選中ToolStripMenuItem";
            this.刪除選中ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.刪除選中ToolStripMenuItem.Text = "刪除選中";
            this.刪除選中ToolStripMenuItem.Click += new System.EventHandler(this.刪除選中ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.AutoSize = false;
            this.退出ToolStripMenuItem.Image = global::Playflv.Properties.Resources.圖標__8_;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出程式";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "FLV|*.flv";
            this.openFileDialog1.Multiselect = true;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 263);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Playflv.Properties.Resources.down;
            this.panel2.Location = new System.Drawing.Point(1, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 11);
            this.panel2.TabIndex = 5;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // Frm_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 416);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放FLV文件";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 刪除選中ToolStripMenuItem;


    }
}

