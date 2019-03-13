using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern
{
    class DatabaseLoggerFactory:LoggerFactory
    {
        public Logger creatLogger()
        {
            Logger logger = new DatabaseLogger();
            return logger;
        }

        public Logger creatLogger(String args)
        {
            Logger logger = new DatabaseLogger();
            return logger;
        }
        public Logger creatLogger(Object obj)
        {
            Logger logger = new DatabaseLogger();
            return logger;
        }
    }
}
