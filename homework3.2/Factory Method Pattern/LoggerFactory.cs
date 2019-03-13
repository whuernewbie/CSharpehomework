using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern
{
    /*interface LoggerFactory
    {
         Logger creatLogger();
        Logger creatLogger(String args);
        Logger creatLogger(Object obj);
        
    }*/
    abstract class LoggerFactory
    {
        public void writeLog()
        {
            Logger logger = this.creatLogger();
            logger.WriteLog();
        }
        public abstract Logger creatLogger();
    }
}
