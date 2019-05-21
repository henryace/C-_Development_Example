using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SQLToWord
{
    class DataTier
    {
        public DataTier(string Server, string DataBase, string UserName, string Password)//定義對像構造器
        {
            this.G_Server = Server;//得到資料庫伺服器字串
            this.G_DataBase = DataBase;//得到資料庫名稱字串
            this.G_UserName = UserName;//得到資料庫用戶名字串
            this.G_Password = Password;//得到資料庫密碼字串
        }

        private string G_Server;//定義私有變數存放資料庫伺服器訊息
        private string G_DataBase;//定義私有變數存放資料庫名稱訊息
        private string G_UserName;//定義私有變數存放用戶名訊息
        private string G_Password;//定義私有變數存放密碼訊息

        /// <summary>
        /// 從資料庫中得到資料集合的方法
        /// </summary>
        /// <returns>返回資料集合</returns>
        public List<string> GetMessage()
        {
            string ConnectionStr = string.Format(//定義資料庫連接字串
           "server={0};database={1};uid={2};pwd={3}",
           G_Server, G_DataBase, G_UserName, G_Password);
            SqlDataAdapter P_SqlDataAdapter =//建立資料適配器對像
                new SqlDataAdapter("select * from tb_Message", ConnectionStr);
            DataTable P_DataTAble = new DataTable();//建立資料表對像
            P_SqlDataAdapter.Fill(P_DataTAble);//填充資料表
            List<string> P_List_Str = new List<string>();//定義資料集合
            foreach (DataRow P_dr in P_DataTAble.Rows)//深度搜尋資料表
            {
                P_List_Str.Add(P_dr[1].ToString());//向資料集合中新增資料
            }
            return P_List_Str;//返回資料集合對像
        }
    }
}
