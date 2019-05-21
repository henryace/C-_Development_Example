using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace UseBackgroundWorker
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int numberToCompute = 0;
        private int highestPercentageReached = 0;

        //在另一個線程上執行事件處理和序
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ComputeFibonacci((int)e.Argument, this.backgroundWorker1, e);
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)//是否有錯誤訊息
            {
                MessageBox.Show(//彈出消息對話框
                    e.Error.Message);
            }
            else if (e.Cancelled)//異步操作是否被取消
            {
                resultLabel.Text = "Canceled";//返回字符串對像
            }
            else
            {
                resultLabel.Text = e.Result.ToString();//顯示結果
            }
            numericUpDown1.Enabled = true;//啟用numericUpDown控制元件
            startAsyncButton.Enabled = true;//啟用開始按鈕
            cancelAsyncButton.Enabled = false;//停用取消按鈕
        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
           
            resultLabel.Text = String.Empty;//得到空字符串對像
            this.numericUpDown1.Enabled = false;//停用numericUpDown控制元件
            this.startAsyncButton.Enabled = false;//停用開始按鈕
            this.cancelAsyncButton.Enabled = true;//啟用取消按鈕
            numberToCompute = (int)numericUpDown1.Value;//得到numericUpDown控制元件的值
            highestPercentageReached = 0;//設置值為0
            backgroundWorker1.RunWorkerAsync(numberToCompute);//開始執行後台操作
        }

        long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if ((n < 0) || (n > 91))
            {
                throw new ArgumentException(//拋出異常
                    "value must be >= 0 and <= 91", "n");
            }
            long result = 0;//聲明長整型變量並賦值
            if (worker.CancellationPending)//判斷是否已經取消後台操作
            {
                e.Cancel = true;//設置取消事件
            }
            else
            {
                if (n < 2)
                {
                    result = 1;//方法返回1
                }
                else
                {
                    result = ComputeFibonacci(n - 1, worker, e) +//使用遞迴得到結果
                             ComputeFibonacci(n - 2, worker, e);
                }

                int percentComplete =
                    (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }

            return result;//返回結果
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();//取消掛起的後台操作
            cancelAsyncButton.Enabled = false;//停用取消按鈕

        }
    }
}