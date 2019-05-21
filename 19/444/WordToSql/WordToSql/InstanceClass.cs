using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordToSql
{
    /// <summary>
    /// 定義實體類
    /// </summary>
    class InstanceClass
    {
        public long id { get; set; }//定義id屬性
        public string Name { get; set; }//定義Name屬性
        public double Chinese { get; set; }//定義Chinese屬性
        public double Math { get; set; }//定義Math屬性
        public double English { get; set; }//定義English屬性
    }
}
