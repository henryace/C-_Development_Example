using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace playflash
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        AxShockwaveFlashObjects.AxShockwaveFlash ax;//建立AxShockwaveFlash實例

        private void AddFlash()
        {
            ax = new AxShockwaveFlashObjects.AxShockwaveFlash();			//實例化AxShockwaveFlash對像
            panel1.Controls.Add(ax);									//新增到Panel控制元件中
            ax.Dock = DockStyle.Fill;									//設定填充模式
            ax.ScaleMode = 1;
            ax.Stop();												//停止，不播放
        }

        private void ControlState(int i)
        {
            if (i == 0)
            {
                播放ToolStripMenuItem.Enabled = false;
                第一幀ToolStripMenuItem.Enabled = false;
                向前ToolStripMenuItem.Enabled = false;
                向後ToolStripMenuItem.Enabled = false;
            }
            else
            {
                播放ToolStripMenuItem.Enabled = true;
                第一幀ToolStripMenuItem.Enabled = true;
                向前ToolStripMenuItem.Enabled = true;
                向後ToolStripMenuItem.Enabled = true;
            }
        }


        private void 打開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)				//如果選擇了FLASH文件
            {
                ax.Visible = true;										//顯示播放器
                string flashPath = openFileDialog1.FileName;					//取得FLASH文件路徑
                ax.Movie = flashPath;									//設定播放器的Movie屬性
                panel1.Visible = true;									//顯示Panel控制元件
                ControlState(1);										//激活功能表
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            AddFlash();												//視窗載入時新增播放器
            ax.Visible = false;											//隱藏播放器
            ControlState(0);											//設定功能表狀態
        }

        private void 關閉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Dispose();
            AddFlash();
            ControlState(0);
            ax.Stop();
            ax.Visible = false;
        }

        private void 向前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Back();// Back方法播放上一幀
        }

        private void 向後ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Forward();// Forward方法播放下一幀
        }

        private void 第一幀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Rewind();// Rewind方法播放第一幀
        }

        private void 播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (播放ToolStripMenuItem.CheckState == CheckState.Checked)
            {
                播放ToolStripMenuItem.CheckState = CheckState.Unchecked;
                ax.Stop();
            }
            else
            {
                播放ToolStripMenuItem.CheckState = CheckState.Checked;
                ax.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ax.Playing == true)
            {
                播放ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                播放ToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Size s = new Size(423, 386);
            if (this.Size == s)
            {
                panel1.Visible = true;
            }
            else
            {
                if (ax.Playing == false)
                {
                    this.BackColor = Color.Black;
                    panel1.Visible = false;
                }
            }
        }
    }
}
