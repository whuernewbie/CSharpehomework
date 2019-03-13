using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern
{
    class FileLogger:Logger
    {
        public void WriteLog()
        {
            Console.WriteLine("文件日志记录");
        }
    }
}
