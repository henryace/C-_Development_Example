using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcRMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //定義3個float類型的二維陣列，作為矩陣
            float[,] MatrixEin = new float[3, 3];
            float[,] MatrixZwei = new float[3, 3];
            float[,] MatrixResult = new float[3, 3];
            //為第一個矩陣中的各個項賦值
            MatrixEin[0, 0] = 2;
            MatrixEin[0, 1] = 2;
            MatrixEin[0, 2] = 1;
            MatrixEin[1, 0] = 1;
            MatrixEin[1, 1] = 1;
            MatrixEin[1, 2] = 1;
            MatrixEin[2, 0] = 1;
            MatrixEin[2, 1] = 0;
            MatrixEin[2, 2] = 1;
            //為第二個矩陣中的各個項賦值
            MatrixZwei[0, 0] = 0;
            MatrixZwei[0, 1] = 1;
            MatrixZwei[0, 2] = 2;
            MatrixZwei[1, 0] = 0;
            MatrixZwei[1, 1] = 1;
            MatrixZwei[1, 2] = 1;
            MatrixZwei[2, 0] = 0;
            MatrixZwei[2, 1] = 1;
            MatrixZwei[2, 2] = 2;
            lab_First.Text += "第一個矩陣：\n";
            //循環深度搜尋第一個矩陣並輸出
            for (int i = 0; i < 3; i++)
            {
                lab_First.Text += "|     ";
                for (int j = 0; j < 3; j++)
                {
                    lab_First.Text += MatrixEin[i, j] + "   ";
                }
                lab_First.Text += "   |\r\n";
            }
            lab_Second.Text = "第二個矩陣：\n";
            //循環深度搜尋第二個矩陣並輸出
            for (int i = 0; i < 3; i++)
            {
                lab_Second.Text += "|     ";
                for (int j = 0; j < 3; j++)
                {
                    lab_Second.Text += MatrixZwei[i, j] + "   ";
                }
                lab_Second.Text += "   |\r\n";
            }
            MultiplyMatrix(MatrixEin, MatrixZwei, MatrixResult);//呼叫自定義方法計算兩個矩陣的乘積
            lab_Result.Text = "兩個矩陣的乘積：\n";
            //循環深度搜尋新得到的矩陣並輸出
            for (int i = 0; i < 3; i++)
            {
                lab_Result.Text += "|     ";
                for (int j = 0; j < 3; j++)
                {
                    lab_Result.Text += MatrixResult[i, j] + "   ";
                }
                lab_Result.Text += "   |\r\n";
            }
        }

        #region 矩陣乘法
        public void MultiplyMatrix(float[,] MatrixEin, float[,] MatrixZwei, float[,] MatrixResult)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        MatrixResult[i, j] += MatrixEin[i, k] * MatrixZwei[k, j];//計算矩陣的乘積
                    }
                }
            }
        }
        #endregion
    }
}
