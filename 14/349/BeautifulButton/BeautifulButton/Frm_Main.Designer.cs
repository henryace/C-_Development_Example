namespace BeautifulButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.transparencyButton1 = new BeautifulButton.TransparencyButton();
            this.SuspendLayout();
            // 
            // transparencyButton1
            // 
            this.transparencyButton1.BackColor = System.Drawing.Color.Transparent;
            this.transparencyButton1.CFontDeepness = 2;
            this.transparencyButton1.CTransparence = 1;
            this.transparencyButton1.Degree = 10;
            this.transparencyButton1.Font = new System.Drawing.Font("華文彩雲", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.transparencyButton1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.transparencyButton1.Location = new System.Drawing.Point(159, 141);
            this.transparencyButton1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.transparencyButton1.Name = "transparencyButton1";
            this.transparencyButton1.NText = "確定";
            this.transparencyButton1.ShineColor = System.Drawing.Color.Navy;
            this.transparencyButton1.Size = new System.Drawing.Size(83, 41);
            this.transparencyButton1.TabIndex = 0;
            this.transparencyButton1.UndersideShine = System.Drawing.Color.LightSteelBlue;
            this.transparencyButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.transparencyButton1_MouseClick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(430, 296);
            this.Controls.Add(this.transparencyButton1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定義水晶按鈕控制元件";
            this.ResumeLayout(false);

        }

        #endregion

        private TransparencyButton transparencyButton1;
    }
}

