using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace TimeTask
{
    class DataTier
    {
        public void Add(string date, string task)
        {
            string P_Connection = string.Format(//建立資料庫連接字串
              "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //建立連接對像
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//連接到資料庫
            string P_str = string.Format("insert into tb_task values('{0}','{1}')",
                date, task);
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令對像
                P_str, P_OLEDBConnection);
            P_OLEDBCommand.ExecuteNonQuery();
        }

        public void Delete(string date, string task)
        {
            string P_Connection = string.Format(//建立資料庫連接字串
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //建立連接對像
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//連接到資料庫
            string P_str = string.Format("delete from tb_task where time=#{0}# and task='{1}'",
                date, task);
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令對像
                P_str, P_OLEDBConnection);
            P_OLEDBCommand.ExecuteNonQuery();
        }

        public List<task> Select()
        {
            string P_Connection = string.Format(//建立資料庫連接字串
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //建立連接對像
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//連接到資料庫
            string P_str = string.Format("select * from tb_task");
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//建立命令對像
                P_str, P_OLEDBConnection);
            OleDbDataReader P_Reader = //得到資料讀取器
             P_OLEDBCommand.ExecuteReader();
            List<task> P_Task = new List<task>();
            while (P_Reader.Read())//讀取資料
            {
                P_Task.Add(new task() //將資料放入集合
                {
                    Date = Convert.ToDateTime(P_Reader[0]),
                    Task = P_Reader[1].ToString()
                });
            }
            return P_Task;
        }
    }
}
