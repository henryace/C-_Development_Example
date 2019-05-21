using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AgentObjects;

namespace OfficeAgent
{
    public partial class Frm_Main : Form
    {
        IAgentCtlCharacterEx ICCE;//定義一個類IAgentCtlCharacterEx物件
        IAgentCtlRequest ICR;//定義一個類IagentCtlRequest物件
        //定義一個字串陣列，用來存儲精靈的各種動作
        string[] strAgents = new string[10] { "Acknowledge", "LookDown", "Sad", "Alert", "LookDownBlink", "Search", "Announce", "LookUp", "Think", "Blink" };

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < strAgents.Length; i++)//循環深度搜尋
            {
                listBox1.Items.Add(strAgents[i]);//向控制元件listBox1中新增字串陣列中的內容
            }
            ICR = axAgent1.Characters.Load("merlin", "merlin.acs");//載入指定文件
            ICCE = axAgent1.Characters.Character("merlin");//設定模擬Office助手的表情
            ICCE.Show(0);//顯示模擬Office助手錶情
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICCE.StopAll("");//停止所有模擬Office助手錶情
            ICCE.Play(strAgents[listBox1.SelectedIndex]);//顯示控制元件listBox1中選定的表情
        }
    }
}