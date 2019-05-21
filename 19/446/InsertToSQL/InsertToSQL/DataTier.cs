using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace InsertToSQL
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
        public List<InstanceClass> GetMessage()
        {
            string P_Str_Connection = string.Format(//建立資料庫連接字串
                "server={0};database={1};uid={2};pwd={3}",
                G_Server, G_DataBase, G_UserName, G_Password);
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter//建立資料適配器對像
            ("select * from tb_grade", P_Str_Connection);
            DataTable dt = new DataTable();//建立資料表對像
            P_SqlDataAdapter.Fill(dt);//填充資料表
            List<InstanceClass> P_List_InstanceClass =//建立資料集合對像
                new List<InstanceClass>();
            foreach (DataRow dr in dt.Rows)//深度搜尋資料表
            {
                P_List_InstanceClass.Add(//向資料集合中新增資料
                    new InstanceClass()
                    {
                        //id = (int)dr[0],
                        Name = dr[1].ToString().Trim(),
                        Chinese = (double)dr[2],
                        Math = (double)dr[3],
                        English = (double)dr[4]
                    });
            }
            return P_List_InstanceClass;//返回資料集合對像
        }

        /// <summary>
        /// 向資料庫中插入資料的方法
        /// </summary>
        /// <param name="ls">資料集合</param>
        public void InsertMessage(List<InstanceClass> ls)
        {
            string P_Str_Connection = string.Format(//建立資料庫連接字串
                "server={0};database={1};uid={2};pwd={3}",
                G_Server, G_DataBase, G_UserName, G_Password);
            using (SqlConnection P_Connection =
                new SqlConnection(P_Str_Connection))
            {
                P_Connection.Open();
                foreach (InstanceClass ic in ls)
                {
                    SqlCommand P_Command = new SqlCommand();//建立Sql命令對像
                    P_Command.Connection = P_Connection;//設定連接屬性
                    P_Command.CommandText = string.Format(//設定命令字串
                        "insert into tb_grade(Names,Chinese,Math,English) values(@Name,@Chinese,@Math,@English)");
                    P_Command.Parameters.Add("@Name", SqlDbType.Char, 50).Value = ic.Name;
                    P_Command.Parameters.Add("@Chinese", SqlDbType.Float).Value = ic.Chinese;
                    P_Command.Parameters.Add("@Math", SqlDbType.Float).Value = ic.Math;
                    P_Command.Parameters.Add("@English", SqlDbType.Float).Value = ic.English;
                    P_Command.ExecuteNonQuery();
                }
            }
        }
    }
}
