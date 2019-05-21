using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace FromTable
{
    class DataTier
    {
        public DataTable GetDate()
        {
            string P_Connection = string.Format(//建立資料庫連接字串
              "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbDataAdapter P_DataAdapter = new OleDbDataAdapter(//建立資料適配器物件
                @"select id as 編號,Name as 名稱,Begin as 開始時間,
                Factory as 配件廠家名稱,Phone as 電話,Address as 聯繫地址 from [tb_Ware] 
                inner join [tb_Number] on [tb_Ware].Number=[tb_Number].Number",
                P_Connection);
            DataTable dt = new DataTable();//建立資料表
            P_DataAdapter.Fill(dt);//填充資料表
            return dt;//返回資料表
        }
    }
}
