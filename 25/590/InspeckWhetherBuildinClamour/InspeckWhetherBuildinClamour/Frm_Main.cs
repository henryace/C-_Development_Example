using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InspeckWhetherBuildinClamour
{
    public partial class Frm_Main : Form
    {
        [DllImport("winmm.dll", EntryPoint = "waveOutGetNumDevs")]
        public static extern int waveOutGetNumDevs();
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (waveOutGetNumDevs() != 0) 	//當安裝聲卡時
            { this.radioButton1.Select(); }	//設定radioButton1按鈕為選定狀態
            else					//當沒有安裝聲卡時
            { this.radioButton2.Select(); }	//設定radioButton2按鈕為選定狀態
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}