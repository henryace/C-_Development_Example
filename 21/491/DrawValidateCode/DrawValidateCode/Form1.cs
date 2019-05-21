using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawValidateCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }

        private string CheckCode()								//此方法產生
        {
            int number;
            char code;
            string checkCode = String.Empty;					//聲明變數存儲隨機產生的4位英文或數字
            Random random = new Random();						//產生隨機數
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();							//返回非負隨機數
                if (number % 2 == 0)							//判斷數字是否為偶數
                    code = (char)('0' + (char)(number % 10));
                else											//如果不是偶數
                    code = (char)('A' + (char)(number % 26));
                checkCode += " " + code.ToString();				//累加字串
            }
            return checkCode;									//返回產生的字串
        }

        private void CodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 9.5)), 22);
            Graphics g = Graphics.FromImage(image);					//建立Graphics對像
            try
            {
                Random random = new Random();						//產生隨機產生器
                g.Clear(Color.White); 								//清空圖片背景色
                for (int i = 0; i < 3; i++)							//畫圖片的背景噪音線
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold));
                g.DrawString(checkCode, font, new SolidBrush(Color.Red), 2, 2);
                for (int i = 0; i < 150; i++)						//畫圖片的前景噪音點
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //畫圖片的邊框線
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                this.pictureBox1.Width = image.Width;				//設定PictureBox的寬度
                this.pictureBox1.Height = image.Height;				//設定PictureBox的高度
                this.pictureBox1.BackgroundImage = image;			//設定PictureBox的背景圖像
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodeImage(CheckCode());

        }
    }
}