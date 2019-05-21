using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AccessToWord
{
    class DataTier
    {
        private string OLEConnection = string.Format(//定義連接字串
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id=Admin; Password=",
            System.IO.Directory.GetCurrentDirectory() + @"\access.mdb");

        /// <summary>
        /// 從資料庫中得到資料集合的方法
        /// </summary>
        /// <returns>返回資料集合</returns>
        public List<InstanceClass> GetMessage()
        {
            OleDbDataAdapter P_OleDbDataAdapter = //建立資料適配器對像
                new OleDbDataAdapter(
                "select * from tb_grade", OLEConnection);
            DataTable dt = new DataTable();//建立資料表對像
            P_OleDbDataAdapter.Fill(dt);//填充資料表
            List<InstanceClass> P_List_InstanceClass =//建立資料集合對像
                new List<InstanceClass>();
            foreach (DataRow dr in dt.Rows)//深度搜尋資料表
            {
                P_List_InstanceClass.Add(//向資料集合中新增資料
                    new InstanceClass()
                    {
                        id = (int)dr[0],
                        Name = dr[1].ToString(),
                        Chinese = (float)dr[2],
                        Math = (float)dr[3],
                        English = (float)dr[4]
                    });
            }
            return P_List_InstanceClass;//返回資料集合對像
        }
    }
}
