using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace ChineseCode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public string txt = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateImage();
        }
        private void CreateImage()
        {
            //取得GB2312編碼頁（表） 
            Encoding gb = Encoding.GetEncoding("big5");
            //呼叫函數產生4個隨機中文中文字編碼 
            object[] bytes = CreateCode(4);
            //根據中文字編碼的字節陣列解碼出中文中文字 
            string str1 = gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[])));
            string str2 = gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[])));
            string str3 = gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[])));
            string str4 = gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[])));
            txt = str1 + str2 + str3 + str4;
            if (txt == null || txt == String.Empty)
            {
                return;
            }
            Bitmap image = new Bitmap((int)Math.Ceiling((txt.Length * 20.5)), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //產生隨機產生器
                Random random = new Random();
                //清空圖片背景色
                g.Clear(Color.White);
                //畫圖片的背景噪音線
                for (int i = 0; i < 2; i++)
                {
                    Point tem_Point_1 = new Point(random.Next(image.Width), random.Next(image.Height));
                    Point tem_Point_2 = new Point(random.Next(image.Width), random.Next(image.Height));
                    g.DrawLine(new Pen(Color.Black), tem_Point_1, tem_Point_2);
                }
                Font font = new Font("新細明體", 12, (FontStyle.Bold));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(txt, font, brush, 2, 2);
                //畫圖片的前景噪音點
                for (int i = 0; i < 100; i++)
                {
                    Point tem_point = new Point(random.Next(image.Width), random.Next(image.Height));
                    image.SetPixel(tem_point.X, tem_point.Y, Color.FromArgb(random.Next()));
                }
                //畫圖片的邊框線
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                pictureBox1.Image = image;
            }
            catch { }
        }

        /**/
        /* 
        此函數在中文字編碼範圍內隨機建立含兩個元素的十六進制字節陣列，每個字節陣列代表一個中文字，並將 
        四個字節陣列存儲在object陣列中。 
        參數：strlength，代表需要產生的中文字個數 
        */
        public static object[] CreateCode(int strlength)
        {
            //定義一個字串陣列儲存中文字編碼的組成元素 
            string[] r = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            //定義一個object陣列用來 
            object[] bytes = new object[strlength];
            /**/
            /*每循環一次產生一個含兩個元素的十六進制字節陣列，並將其放入bject陣列中 
         每個中文字有四個區位碼組成 
         區位碼第1位和區位碼第2位作為字節陣列第一個元素 
         區位碼第3位和區位碼第4位作為字節陣列第二個元素 
        */
            for (int i = 0; i < strlength; i++)
            {
                //區位碼第1位 
                int r1 = rnd.Next(11, 14);
                string str_r1 = r[r1].Trim();
                //區位碼第2位 
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);//更換隨機數發生器的種子避免產生重複值 
                int r2;
                if (r1 == 13)
                    r2 = rnd.Next(0, 7);
                else
                    r2 = rnd.Next(0, 16);
                string str_r2 = r[r2].Trim();
                //區位碼第3位 
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = r[r3].Trim();
                //區位碼第4位 
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = r[r4].Trim();
                //定義兩個字節變數存儲產生的隨機中文字區位碼 
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //將兩個字節變數存儲在字節陣列中 
                byte[] str_r = new byte[] { byte1, byte2 };
                //將產生的一個中文字的字節陣列放入object陣列中 
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
                return;
            else
            {
                if (txtCode.Text.Trim() == txt)
                {
                    MessageBox.Show("提示：驗證碼輸入正確！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("提示：驗證碼輸入錯誤，請重新輸入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
