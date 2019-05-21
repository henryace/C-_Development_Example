using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ListLyric
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 當單擊「退出」按鈕時
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //退出應用程式
        }
        #endregion

        #region 當有歌詞存在時直接載入
        private void ListLyric_Load(object sender, EventArgs e)
        {
            if (File.Exists("青花瓷.lrc"))//當存在歌詞「青花瓷」時
            {
                listLyric("青花瓷.lrc");//在RichTextBox中顯示已存在的歌詞
            }
        }
        #endregion

        #region  取得MP3的歌詞
        /// <summary>
        /// 取得MP3的歌詞
        /// </summary>
        /// <param FileName="string">歌詞路徑</param>
        public string[] LRC_Lyric(string FileName)
        {
            ArrayList ArrLyric = new ArrayList();//宣告一個使用大小可動態增加的陣列對像
            FileStream fs = new FileStream(@FileName, FileMode.Open, FileAccess.Read, FileShare.None);//定義一個公開以文件為主的 Stream，既支持同步讀寫操作，也支持異步讀寫操作的對象。
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);//宣告一個讀取資料的對象
            sr.BaseStream.Seek(0, SeekOrigin.Begin);//從指定的起始點開始讀取資料
            string Tem_strLine = sr.ReadLine();//讀取目前流中的一行資料
            string Tem_Str = "";//定義一個string型臨時變數Tem_Str
            string sp = "";//定義一個string型臨時變數sp
            int Tem_p = 0;//記錄目前[的位置
            int Tem_q = 0;//記錄目前]的位置
            string Tem_Time = "";//記錄播放時間
            string Tem_Slyrec = "";//記錄歌詞
            bool Tem_bool = true;//循環條件

            while (Tem_strLine != null) //只要目前流中還存在資料就繼續循環
            {
                Tem_bool = true; //設定Tem_bool的值為true
                Tem_Str = Tem_strLine;//為變數Tem_Str賦值
                sp = Tem_strLine;//為變數sp賦值
                if (sp.IndexOf(Convert.ToChar("[")) == -1 || sp.Trim() == "")//當"["字符在此字串中的第一個匹配項的索引為-1或當從目前 String 對象的開始和末尾移除所有空白字符後保留的字串為空值時
                {
                    Tem_strLine = sr.ReadLine();//繼續從流中讀取資料
                    continue;//跳出此層循環
                }

                sp = sp.Substring(sp.IndexOf(Convert.ToChar("[")) + 1, 1);//從此實例檢索子字串。子字串從指定的字符位置開始且具有指定的長度
                Tem_Slyrec = Tem_Str.Substring(Tem_Str.LastIndexOf(Convert.ToChar("]")) + 1, Tem_Str.Length - (Tem_Str.LastIndexOf(Convert.ToChar("]")) + 1));//截取歌詞中「[」和「]」中的內容
                if (EstimateFig(sp))//當字串中存在數字時
                {
                    while (Tem_bool)//只要Tem_bool為真就不斷的循環
                    {
                        Tem_p = Tem_Str.IndexOf(Convert.ToChar("["));//取得字符「[」的索引
                        Tem_q = Tem_Str.IndexOf(Convert.ToChar("]"));//取得字符「]」的索引
                        Tem_Time = Tem_Str.Substring(Tem_p + 1, Tem_q - Tem_p - 1);//取得目前行的播放時間
                        ArrLyric.Add(Tem_Time + "|" + Tem_Slyrec); //在播放時間和歌詞之間新增「|」
                        if (Tem_q != Tem_Str.LastIndexOf(Convert.ToChar("]"))) //當沒有循環到字串的結尾時
                            Tem_Str = Tem_Str.Substring(Tem_q + 1, Tem_Str.Length - Tem_q - 1);//儲存字串的值
                        else                  //當循環到結尾時
                            Tem_bool = false;//設定Tem_bool的值為false
                    }
                }
                Tem_strLine = sr.ReadLine();//從目前流中讀取一行資料
            }
            sr.Dispose(); //釋放由sr對像使用的所有資源
            fs.Dispose(); //釋放由fs對像使用的所有資源

            int Tem_DatetimeUp;//記錄前一個時間
            int Tem_DstetimeDown;//記錄後一個時間
            string Tem_taxisTime = "";//記當截取後的時間字串
            string Tem_Transitorily = "";//排序時臨時存儲的字串
            string[] ArrayStr = new string[ArrLyric.Count];//定義一個string型的陣列ArrayStr
            for (int i = 0; i < ArrayStr.Length; i++)//循環深度搜尋陣列ArrayStr中的每一個元素
            {
                Tem_Str = ArrLyric[i].ToString();//記錄陣列ArrayStr中的元素
                Tem_taxisTime = Tem_Str.Substring(0, Tem_Str.LastIndexOf(Convert.ToChar("|")));//截取歌詞的播放時間
                Tem_taxisTime = BuildMillisecond(Tem_taxisTime);//儲存歌詞的播放時間總數
                ArrayStr[i] = Tem_taxisTime + "|" + Tem_Str.Substring(Tem_Str.LastIndexOf(Convert.ToChar("|")) + 1, Tem_Str.Length - Tem_Str.LastIndexOf(Convert.ToChar("|")) - 1);//將時間和歌詞內容賦值給字符陣列ArrayStr
            }
            string iStr = "";//定義一個string型的變數iStr
            string jStr = "";//定義一個string型的變數jStr
            for (int i = 0; i < ArrayStr.Length - 2; i++) //循環深度搜尋陣列ArrayStr中的每一行資料
            {
                for (int j = 0; j < ArrayStr.Length - 1 - i; j++)//循環深度搜尋陣列ArrayStr中的每一行資料
                {
                    iStr = ArrayStr[j];//記錄陣列ArrayStr中的目前資料
                    jStr = ArrayStr[j + 1];//記錄陣列ArrayStr中的下一條資料
                    Tem_taxisTime = iStr.Substring(0, iStr.LastIndexOf(Convert.ToChar("|")));//截取目前行中的時間部分
                    Tem_DatetimeUp = Convert.ToInt32(Tem_taxisTime);//將時間類型轉化為整型
                    Tem_taxisTime = jStr.Substring(0, jStr.LastIndexOf(Convert.ToChar("|")));//截取下一行中的時間部分
                    Tem_DstetimeDown = Convert.ToInt32(Tem_taxisTime);//將時間類型轉化為整型
                    if (Tem_DstetimeDown < Tem_DatetimeUp) //當下一行的時間小於目前行的時間
                    {
                        Tem_Transitorily = ArrayStr[j];//記錄目前行的時間
                        ArrayStr[j] = ArrayStr[j + 1];//為目前行的時間重新賦值
                        ArrayStr[j + 1] = Tem_Transitorily;//為下一行的時間賦值
                    }
                }
            }
            return ArrayStr;//返回陣列ArrayStr
        }
        #endregion

        #region  在字串中截取數字
        /// <summary>
        /// 在字串中截取數字
        /// </summary>
        /// <param Istr="string">包含數字的字串</param>
        public bool EstimateFig(string Istr)
        {
            string Tem_Sint = "";//定義一個string型變數Tem_Sint
            bool Tem_Bool = false;//定一個Tem_Bool型變數Tem_Bool
            CharEnumerator Tem_CharEnum = Istr.GetEnumerator();//定義一個支持循環訪問 String 對象並讀取它的各個字符的對象
            while (Tem_CharEnum.MoveNext())//循環訪問字串中的每一個字符
            {
                byte[] Tem_byte = new byte[1];//定義一個字節型陣列
                Tem_byte = System.Text.Encoding.ASCII.GetBytes(Tem_CharEnum.Current.ToString());//儲存目前字串的編碼類型
                int Tem_ASCII_Code = (short)(Tem_byte[0]);//將字節陣列中的字符轉化為int型的
                if (Tem_ASCII_Code >= 48 && Tem_ASCII_Code <= 57)//當該字符為數字時
                    Tem_Sint += Tem_CharEnum.Current.ToString();//儲存該字符的值
            }
            if (Tem_Sint != "")//當變數Tem_Sint的值不為空時
                Tem_Bool = true;//設定Tem_Bool的值為true
            return Tem_Bool;//返回Tem_Bool的值
        }
        #endregion

        #region  計算時間的毫秒數
        /// <summary>
        /// 計算時間的毫秒數
        /// </summary>
        /// <param Istr="string">時間</param>
        public string BuildMillisecond(string Istr)
        {
            string Tem_Value = ""; //定義一個string型的變數Tem_Value
            int Tem_Cent = 0;//定義一個int型的變數Tem_Cent
            int Tem_Sec = 0;//定義一個int型的變數Tem_Sec
            int Tem_Mill = 0;//定義一個int型的變數Tem_Mill
            Tem_Cent = Convert.ToInt32(Istr.Substring(0, Istr.IndexOf(Convert.ToChar(":"))));//取得歌詞播放多少分鐘
            Tem_Sec = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(":")) + 1, Istr.IndexOf(Convert.ToChar(".")) - Istr.IndexOf(Convert.ToChar(":")) - 1));//取得歌詞播放的秒數
            Tem_Mill = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(".")) + 1, Istr.Length - Istr.IndexOf(Convert.ToChar(".")) - 1));//取得歌詞的播放毫秒數
            Tem_Cent = Tem_Cent * 60000 + Tem_Sec * 1000 + Tem_Mill;//計算歌詞播放的總時間數
            Tem_Value = Tem_Cent.ToString();//儲存歌詞的播放時間
            return Tem_Value;//返回歌詞的播放時間
        }
        #endregion

        #region 打開歌曲的歌詞
        private void unfold_Click(object sender, EventArgs e)
        {
            string filePath = null;//定義一個字串，並為其賦值為null
            OpenFileDialog LyricDialog = new OpenFileDialog();//定義一個提示用戶打開文件對像
            LyricDialog.Filter = "LRC文件（*.LRC）|*.LRC";//設定打開文件的過濾參數
            if (LyricDialog.ShowDialog() == DialogResult.OK)//當用戶選定所要打開的文件點擊「打開」按鈕時
            {
                filePath = LyricDialog.FileName;//將選定文件的路徑名稱賦值給變數filePath
                listLyric(filePath);//顯示指定路徑下的歌詞
                unfold.Enabled = false;//設定打開按鈕的可用狀態為不可用
            }
        }
        #endregion

        #region 自定義顯示歌詞的ListLyric方法
        private void listLyric(string lyricName)
        {
            ArrayList GetArrLyric = new ArrayList();//宣告一個使用大小可動態增加的陣列對像
            GetArrLyric = new ArrayList(LRC_Lyric(lyricName));//為宣告的動態陣列對像賦值
            for (int i = 0; i < GetArrLyric.Count; i++)//循環深度搜尋陣列中的每一個元素
            {
                richTextBox1.Text += GetArrLyric[i].ToString() + "\r";//將讀出的內容顯示在RichTextBox中
            }
        }
        #endregion

    }
}