namespace CheckBoxInTreeView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("一年一班");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("一年二班");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("一年三班");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("一年級", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("二年一班");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("二年二班");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("二年三班");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("二年級", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 6);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "節點1";
            treeNode1.Text = "一年一班";
            treeNode2.Name = "節點3";
            treeNode2.Text = "一年二班";
            treeNode3.Name = "節點4";
            treeNode3.Text = "一年三班";
            treeNode4.Name = "節點0";
            treeNode4.Text = "一年級";
            treeNode5.Name = "節點8";
            treeNode5.Text = "二年一班";
            treeNode6.Name = "節點10";
            treeNode6.Text = "二年二班";
            treeNode7.Name = "節點11";
            treeNode7.Text = "二年三班";
            treeNode8.Name = "二年級";
            treeNode8.Text = "二年級";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(270, 189);
            this.treeView1.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 207);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "實現帶復選框TtreeView控制元件 ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;

    }
}

