using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChuffedFarm
{
    public partial class Frm_Main : Form
    {

        private PlantState PlantState = PlantState.Nothing;
        private CPictureBox cpbxSeed;
        private int intAmount;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void pbxSeed_MouseEnter(object sender, EventArgs e)
        {
            this.pbxInseminate.Image = ChuffedFarm.Properties.Resources.播種1;
        }

        private void pbxSeed_MouseLeave(object sender, EventArgs e)
        {
            this.pbxInseminate.Image = ChuffedFarm.Properties.Resources.播種;
        }

        private void pbxVegetate_MouseEnter(object sender, EventArgs e)
        {
            this.pbxVegetate.Image = ChuffedFarm.Properties.Resources.生長1;
        }

        private void pbxVegetate_MouseLeave(object sender, EventArgs e)
        {
            this.pbxVegetate.Image = ChuffedFarm.Properties.Resources.生長;
        }

        private void pbxBlossomOut_MouseEnter(object sender, EventArgs e)
        {
            this.pbxBlossomOut.Image = ChuffedFarm.Properties.Resources.開花1;
        }

        private void pbxBlossomOut_MouseLeave(object sender, EventArgs e)
        {
            this.pbxBlossomOut.Image = ChuffedFarm.Properties.Resources.開花;
        }

        private void pbxMakeFruitage_MouseEnter(object sender, EventArgs e)
        {
            this.pbxMakeFruitage.Image = ChuffedFarm.Properties.Resources.結果1;
        }

        private void pbxMakeFruitage_MouseLeave(object sender, EventArgs e)
        {
            this.pbxMakeFruitage.Image = ChuffedFarm.Properties.Resources.結果;
        }

        private void pbxHarvest_MouseEnter(object sender, EventArgs e)
        {
            this.pbxHarvest.Image = ChuffedFarm.Properties.Resources.收穫1;
        }

        private void pbxHarvest_MouseLeave(object sender, EventArgs e)
        {
            this.pbxHarvest.Image = ChuffedFarm.Properties.Resources.收穫;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.cpbxSeed != null)//若已產生CPictureBox控制元件實例
            {
                if (this.Bounds.Contains(Cursor.Position))//若光標在視窗內
                {
                    if (this.cpbxSeed.IsInseminate == false)//若種子還未種下
                    {
                        if (this.PlantState == PlantState.Inseminate)//若是種植狀態
                        {
                            this.cpbxSeed.Location = new Point(e.X - 20, e.Y - 40);
                        }
                    }
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (this.cpbxSeed != null)
            {
                this.cpbxSeed.IsInseminate = true;//表示種下
            }
        }

        private void cpbxSeed_Click(object sender, EventArgs e)
        {
            if (this.cpbxSeed != null)
            {
                this.cpbxSeed.IsInseminate = true;//表示種下
            }
        }

        private void pbxInseminate_Click(object sender, EventArgs e)
        {
            //什麼時候可以種植
            if (PlantState != PlantState.Nothing && PlantState != PlantState.Harvest && PlantState != PlantState.Inseminate)
            {
                MessageBox.Show("還未收穫，無法播種!");
                return;
            }
            //
            this.PlantState = PlantState.Inseminate;
            this.cpbxSeed = new CPictureBox();
            //
            this.cpbxSeed.BackColor = System.Drawing.Color.Transparent;
            this.cpbxSeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpbxSeed.Image = ChuffedFarm.Properties.Resources.seed2;
            this.cpbxSeed.Size = new System.Drawing.Size(ChuffedFarm.Properties.Resources.seed2.Width, ChuffedFarm.Properties.Resources.seed2.Height);//52.28
            this.cpbxSeed.Location = new System.Drawing.Point(this.pbxInseminate.Location.X - 50, this.pbxInseminate.Location.Y - 80);
            //
            this.cpbxSeed.TabStop = true;
            this.cpbxSeed.IsInseminate = false;//剛剛建立種子實例，還未種下
            this.cpbxSeed.Click += new System.EventHandler(this.cpbxSeed_Click);
            this.Controls.Add(this.cpbxSeed);
            //
            tipSeed.SetToolTip(this.cpbxSeed, "這是種子");
        }

        private void pbxVegetate_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("還未播種，怎麼長啊", "訊息提示！");
                return;
            }
            if (PlantState == PlantState.BlossomOut)
            {
                MessageBox.Show("正在開花，不能進入生長期！", "訊息提示！");
                return;
            }
            if (PlantState == PlantState.MakeFruitage)
            {
                MessageBox.Show("正在結果，不能進入生長期！", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("農場裡都沒有農作物了，怎麼長呀！", "訊息提示！");
                return;
            }

            this.PlantState = PlantState.Vegetate;

            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                tipSeed.SetToolTip(cpbx, "");//已經開始生長，不再是種子，無需提示
                cpbx.Size = new Size(ChuffedFarm.Properties.Resources.grow.Width, ChuffedFarm.Properties.Resources.grow.Height);
                cpbx.Image = ChuffedFarm.Properties.Resources.grow;
            }
        }

        private void pbxBlossomOut_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("還未播種，能開花嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Inseminate)
            {
                MessageBox.Show("剛剛播完種，還未生長，能開花嗎？", "訊息提示！");
                return;
            }
            if (PlantState == PlantState.MakeFruitage)
            {
                MessageBox.Show("正在結果，不能開花了！", "訊息提示！");
                return;
            }
            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("農場裡都沒有農作物了，怎麼開花呀！", "訊息提示！");
                return;
            }

            this.PlantState = PlantState.BlossomOut;
            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                cpbx.Image = ChuffedFarm.Properties.Resources.bloom;
            }
        }

        private void pbxMakeFruitage_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("還未播種，能結果嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Inseminate)
            {
                MessageBox.Show("剛剛播完種，還未生長，能結果嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Vegetate)
            {
                MessageBox.Show("還處在生長期，並未開花，能結果嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("農場裡都沒有農作物了，怎麼結果呀！", "訊息提示！");
                return;
            }

            this.PlantState = PlantState.MakeFruitage;
            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                cpbx.Image = ChuffedFarm.Properties.Resources.fruit;
            }
        }

        private void pbxHarvest_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("還未播種，能收穫嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Inseminate)
            {
                MessageBox.Show("剛剛播完種，還未生長，能收穫嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.Vegetate)
            {
                MessageBox.Show("還處在生長期，並未開花，能收穫嗎？", "訊息提示！");
                return;
            }

            if (PlantState == PlantState.BlossomOut)
            {
                MessageBox.Show("正在花期，並未結果，能收穫嗎？", "訊息提示！");
                return;
            }


            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("已經收過了！", "訊息提示！");
                return;
            }

            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                intAmount++;
                cpbx.Dispose();
            }
            if (cons.Count<Control>() > 0)
            {
                pbxHarvest_Click(sender, e);
            }
            this.PlantState = PlantState.Harvest;
            lbAmount.Text = "你的倉庫裡有" + intAmount.ToString() + "個果實！";
        }

        /// <summary>
        /// 取得動態產生的自定義PictureBox控制元件
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Control> GetCPictureBoxes()
        {
            return this.Controls.Cast<Control>().Where(con => (con.GetType() == typeof(CPictureBox)));//Linq查詢技術
        }
    }
}