using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DragControl
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //呼叫移動方法
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Tag = e.Location;//得到按鈕中鼠標坐標
            DoDragDrop(button1, DragDropEffects.Move);//開始托放操作
        }
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Tag = e.Location;//得到按鈕中鼠標坐標
            DoDragDrop(button2, DragDropEffects.Move);//開始托放操作
        }
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.Tag = e.Location;//得到按鈕中鼠標坐標
            DoDragDrop(button3, DragDropEffects.Move);//開始托放操作
        }
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.Tag = e.Location;//得到按鈕中鼠標坐標
            DoDragDrop(button4, DragDropEffects.Move);//開始托放操作
        }
        //在
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //判斷接對哪個按鈕操作//移動後的坐標
            object data = e.Data.GetData(typeof(Button));
            if (data == button1)
            {
                button1.Top = this.PointToClient(//計算按鈕的X坐標
                    new Point(e.X, e.Y)).Y - ((Point)button1.Tag).Y;
                button1.Left = this.PointToClient(//計算按鈕的Y坐標
                    new Point(e.X, e.Y)).X - ((Point)button1.Tag).X;
            }
            if (data == button2)
            {
                button2.Top = this.PointToClient(//計算按鈕的X坐標
                    new Point(e.X, e.Y)).Y - ((Point)button2.Tag).Y;
                button2.Left = this.PointToClient(//計算按鈕的Y坐標
                    new Point(e.X, e.Y)).X - ((Point)button2.Tag).X;
            }
            if (data == button3)
            {
                button3.Top = this.PointToClient(//計算按鈕的X坐標
                    new Point(e.X, e.Y)).Y - ((Point)button3.Tag).Y;
                button3.Left = this.PointToClient(//計算按鈕的Y坐標
                    new Point(e.X, e.Y)).X - ((Point)button3.Tag).X;
            }
            if (data == button4)
            {
                button4.Top = this.PointToClient(//計算按鈕的X坐標
                    new Point(e.X, e.Y)).Y - ((Point)button4.Tag).Y;
                button4.Left = this.PointToClient(//計算按鈕的Y坐標
                    new Point(e.X, e.Y)).X - ((Point)button4.Tag).X;
            }
        }
        //設定以何種方式移動
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;//設定托放效果
        }
    }
}