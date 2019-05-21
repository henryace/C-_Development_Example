using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace AddAndRemoveControl
{
    /// <summary>
    /// Frm_Login的摘要說明。
    /// </summary>
    public class Frm_Login : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label lbluPwd;
        private System.Windows.Forms.Label lbluName;
        private System.Windows.Forms.Button btnConcel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPasword;
        private System.ComponentModel.IContainer components = null;

        public Frm_Login()
        {
            //
            // Windows 視窗設計器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 呼叫後新增任何構造函數程式碼
            //
        }

        /// <summary>
        /// 清理所有正在使用的資源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 視窗設計器產生的程式碼
        /// <summary>
        /// 設計器支持所需的方法 - 不要使用程式碼編輯器修改
        /// 此方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPasword = new System.Windows.Forms.TextBox();
            this.lbluPwd = new System.Windows.Forms.Label();
            this.lbluName = new System.Windows.Forms.Label();
            this.btnConcel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(128, 23);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(208, 21);
            this.txtUser.TabIndex = 13;
            this.txtUser.Tag = "登入名：";
            // 
            // txtPasword
            // 
            this.txtPasword.Location = new System.Drawing.Point(128, 55);
            this.txtPasword.Name = "txtPasword";
            this.txtPasword.PasswordChar = '●';
            this.txtPasword.Size = new System.Drawing.Size(208, 21);
            this.txtPasword.TabIndex = 14;
            this.txtPasword.Tag = "密  碼：";
            // 
            // lbluPwd
            // 
            this.lbluPwd.AutoSize = true;
            this.lbluPwd.Location = new System.Drawing.Point(40, 55);
            this.lbluPwd.Name = "lbluPwd";
            this.lbluPwd.Size = new System.Drawing.Size(53, 12);
            this.lbluPwd.TabIndex = 12;
            this.lbluPwd.Text = "密  碼：";
            // 
            // lbluName
            // 
            this.lbluName.AutoSize = true;
            this.lbluName.Location = new System.Drawing.Point(40, 31);
            this.lbluName.Name = "lbluName";
            this.lbluName.Size = new System.Drawing.Size(53, 12);
            this.lbluName.TabIndex = 11;
            this.lbluName.Text = "登入名：";
            // 
            // btnConcel
            // 
            this.btnConcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConcel.Location = new System.Drawing.Point(188, 93);
            this.btnConcel.Name = "btnConcel";
            this.btnConcel.Size = new System.Drawing.Size(96, 23);
            this.btnConcel.TabIndex = 17;
            this.btnConcel.Text = "退出(&E)";
            this.btnConcel.Click += new System.EventHandler(this.btnConcel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(52, 93);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "確定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(376, 137);
            this.Controls.Add(this.lbluName);
            this.Controls.Add(this.btnConcel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPasword);
            this.Controls.Add(this.lbluPwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程式執行時智能增減控制元件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// 應用程式的主入口點。
        /// </summary>

        Frm_Main frm = new Frm_Main();//建立視窗物件
        private void btnOK_Click(object sender, System.EventArgs e)//確定
        {
            if (txtUser.Text == "")//如果用戶名為空
            {
                MessageBox.Show("請輸入用戶名");//彈出消息對話框
                return;//退出方法
            }
            else if (txtPasword.Text == "")//如果密碼為空
            {
                MessageBox.Show("請輸入用戶密碼");//彈出消息對話框
                return;//退出方法
            }
            else if (txtUser.Text == "Admin" &&//如果輸入的用戶名和密碼正確
                txtPasword.Text == "Admin")
            {
                frm.Show();//顯示視窗
                frm.button1.Visible = false;//隱藏Button按鈕
                frm.button4.Visible = false;//隱藏Button按鈕
                frm.Text = frm.Text + "    " + //顯示視窗標題
                    "操作員:" + txtUser.Text;
                this.Hide();//隱藏登入視窗
            }
            else if (txtUser.Text == "Mr" &&//如果輸入的用戶名和密碼正確
                txtPasword.Text == "Mrsoft")
            {
                frm.Show();//顯示視窗
                frm.Text = frm.Text + "    " +//顯示視窗標題
                    "系統管理員:" + txtPasword.Text;
                this.Hide();//隱藏登入視窗
            }
            else
            {
                MessageBox.Show("用戶名或密碼錯誤");//彈出消息對話框
                txtUser.Text = "";//清空用戶名
                txtPasword.Text = "";//清空密碼
                txtUser.Focus();//控制元件得到焦點
            }

        }

        private void btnConcel_Click(object sender, System.EventArgs e)//點擊取消按鈕
        {
            DialogResult bb = MessageBox.Show(//彈出消息對話框
                "是否要退出登入？", "退出登入", MessageBoxButtons.YesNo);
            if (Convert.ToString(bb) == "Yes")//如果點擊確定按鈕
            { Application.Exit(); }//退出應用程式
        }
    }
}
