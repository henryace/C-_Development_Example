using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertToSQL
{
    class Time
    {
        public string Times { get; set; }//時間字串
        public byte Hours { get; set; }//小時
        public byte Minutes { get; set; }//分鐘
        public byte Seconds { get; set; }//秒
        public bool Execute { set; get; }//任務是否已經執行
        public override string ToString()//重寫基底類的ToString方法
        {
            return Times;//返回時間字串
        }
    }
}
