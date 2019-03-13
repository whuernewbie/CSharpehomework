using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern
{
    class DatabaseLogger:Logger
    {
        public void WriteLog()
        {
            Console.WriteLine("数据库日志记录");
        }
    }
}
