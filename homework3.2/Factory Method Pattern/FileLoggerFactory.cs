using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern
{
    class FileLoggerFactory:LoggerFactory
    {
         Logger LoggerFactory.creatLogger()
        {
            Logger logger = new FileLogger();
            return logger;
        }

    }
}
