using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern
{
    class Client
    {
        public static void Main(String [] args)
        {
            LoggerFactory factory;
            Logger logger;
            factory = (LoggerFactory)XML.Getbean();
            if(factory!=null)
            {
                factory.writeLog();
            }
            else
            {
                Console.WriteLine("打开xml文件错误");
            }
            
        }
    }
}
