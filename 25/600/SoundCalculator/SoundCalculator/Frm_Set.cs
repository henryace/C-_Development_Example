﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace SoundCalculator
{
    public partial class Frm_Set : Form
    {
        public Frm_Set()
        {
            InitializeComponent();
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void button25_Click(object sender, EventArgs e)
        {
            Clear_Control(groupBox1.Controls, Frm_Main.VoxPath.Length);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        public void Clear_Control(Control.ControlCollection Con, int m)
        {
            int tem_n = 0;
            foreach (Control C in Con)
            { //深度搜尋可視化元件中的所有控制元件
                if (C.GetType().Name == "TextBox")  //判斷是否為TextBox控制元件
                {
                    WritePrivateProfileString("Vox", ((TextBox)C).Tag.ToString(), ((TextBox)C).Text, Application.StartupPath + "\\Tem_File.ini");
                    tem_n += 1;
                }
                if (tem_n > m)
                    break;
            }
        }

        public void Clear_Control(Control.ControlCollection Con, int n, string Path)
        {
            foreach (Control C in Con)
            { //深度搜尋可視化元件中的所有控制元件
                if (C.GetType().Name == "TextBox")  //判斷是否為TextBox控制元件
                {
                    if (Convert.ToInt32(((TextBox)C).Tag.ToString()) == n)
                    {
                        ((TextBox)C).Text = Path;
                        break;
                    }

                }
            }
        }

        public void GetIni(Control.ControlCollection Con)
        {
            StringBuilder temp = new StringBuilder(255);
            if (System.IO.File.Exists(Application.StartupPath + "\\Tem_File.ini") == true)
            {
                foreach (Control C in Con)
                { //深度搜尋可視化元件中的所有控制元件
                    if (C.GetType().Name == "TextBox")  //判斷是否為TextBox控制元件
                    {
                        GetPrivateProfileString("Vox", ((TextBox)C).Tag.ToString(), "資料讀取錯誤。", temp, 255, Application.StartupPath + "\\Tem_File.ini");
                        ((TextBox)C).Text = temp.ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Clear_Control(groupBox1.Controls, Convert.ToInt32(((Button)sender).Tag.ToString()), openFileDialog1.FileName);
            }
        }

        private void Frm_Set_Load(object sender, EventArgs e)
        {
            GetIni(groupBox1.Controls);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
